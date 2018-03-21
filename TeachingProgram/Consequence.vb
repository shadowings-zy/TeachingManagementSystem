Public Class Consequence
    Dim Terms = CInt(TeachingManagementSystem.Terms.Text)
    Public CredictLimitFinal As Integer

    Private Sub Consequence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CreditLimit = 0
        Dim NowCredit = 0
        Dim NowTerms = 0
        Dim CoursesNum = 0

        '设置窗体不可最大化，不可更改大小
        FormBorderStyle = BorderStyle.FixedSingle
        MaximizeBox = False

        '获取课程总数和学分限制
        While CoursesNum < TeachingManagementSystem.CourseTable.RowCount
            If TeachingManagementSystem.CourseTable(0, CoursesNum).Value <> "" Then
                CreditLimit = CreditLimit + CInt(TeachingManagementSystem.CourseTable(2, CoursesNum).Value)
                CoursesNum = CoursesNum + 1
            Else
                Exit While
            End If
        End While

        If CoursesNum <= 0 Then
            MsgBox("数据不足，无法生成结果")
            Exit Sub
        End If

        '若为均匀分配，则每学期的学分限制的初始值为总学分/学期数+1，若不能分配，则学分限制变为总学分/学期数+2,以此类推，直至学分限制=学分上限。
        '若为集中分配，则为学分上限
        If TeachingManagementSystem.RadioButton1.Checked Then
            Dim AllCredit = CInt(TeachingManagementSystem.MaxCredit.Text)
            Calculate2(CoursesNum, NowCredit, AllCredit, NowTerms)  '判断能否分配，若连集中分配方式都无法正常分配的话，均匀方式更无法分配
            CreditLimit = CInt(CreditLimit / Terms + 1)

            While CreditLimit < AllCredit
                If Calculate1(CoursesNum, NowCredit, CreditLimit, NowTerms) Then
                    Exit While
                Else
                    CreditLimit = CreditLimit + 1
                End If
            End While
            CredictLimitFinal = CreditLimit
        Else
            CreditLimit = CInt(TeachingManagementSystem.MaxCredit.Text)
            CredictLimitFinal = CreditLimit
            Calculate2(CoursesNum, NowCredit, CreditLimit, NowTerms)
        End If
    End Sub

    '导出结果至Excel
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SavePath = ""
        Dim NewExcel = FolderBrowserDialog1.ShowDialog()
        If NewExcel = DialogResult.OK Then
            SavePath = FolderBrowserDialog1.SelectedPath()
        Else
            Exit Sub
        End If

        Dim ExportName = InputBox("请输入文件名称：", "输入框", "")
        If ExportName = "" Then
            MsgBox("输入文件名不能为空")
            Exit Sub
        End If

        If Dir(FolderBrowserDialog1.SelectedPath + "\" + ExportName) = "" Then '判断文件夹是否存在
            SavePath = SavePath + "\" + ExportName + ".xlsx"
        Else
            MsgBox("已有同名文件夹！")
            Exit Sub
        End If

        Try
            Dim xlApp = CreateObject("Excel.Application")
            Dim xlBook = xlApp.Workbooks.Add()
            Dim xlSheet = xlBook.Worksheets(1)
            xlSheet.Activate()

            Dim ExcelRow = 1

            For a = 0 To TreeView1.Nodes.Count - 1
                xlSheet.Cells(ExcelRow, 1) = TreeView1.Nodes(a).Text
                ExcelRow = ExcelRow + 1
                xlSheet.Cells(ExcelRow, 1) = "课程号"
                xlSheet.Cells(ExcelRow, 2) = "课程名称"
                xlSheet.Cells(ExcelRow, 3) = "学分"
                xlSheet.Cells(ExcelRow, 4) = "先修课"
                ExcelRow = ExcelRow + 1

                For Each ChildNode In TreeView1.Nodes(a).Nodes
                    Dim RealTag = ChildNode.Tag Mod 100
                    For c = 0 To 3
                        xlSheet.Cells(ExcelRow, c + 1) = TeachingManagementSystem.CourseTable(c, RealTag).Value
                    Next
                    ExcelRow = ExcelRow + 1
                Next

                ExcelRow = ExcelRow + 1
            Next

            xlBook.SaveAs(SavePath)

            MsgBox("导出完成")
            Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet)
            xlSheet = Nothing
            xlBook.Close()
            Runtime.InteropServices.Marshal.ReleaseComObject(xlBook)
            xlBook = Nothing
            xlApp.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            xlApp = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "出错啦！", MessageBoxButtons.OK)
        End Try
    End Sub

    '选择TreeView上的一个节点，在右面的datagridview中显示课程的具体信息
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        OutputTable.Rows.Clear()

        Dim RootTag = CInt(TreeView1.SelectedNode.Tag / 100) * 100
        For a = 0 To Terms - 1
            Dim Rows = 0
            If TreeView1.Nodes(a).Tag = RootTag Then
                For Each ChildNode In TreeView1.Nodes(a).Nodes
                    OutputTable.Rows.Add()
                    Rows = Rows + 1
                Next

                Dim b = 0
                For Each ChildNode In TreeView1.Nodes(a).Nodes
                    Dim RealTag = ChildNode.Tag Mod 100
                    For c = 0 To 3
                        OutputTable(c, b).Value = TeachingManagementSystem.CourseTable(c, RealTag).Value
                    Next
                    b = b + 1
                Next
            End If
        Next
    End Sub

    '拓扑排序功能函数，根据邻接矩阵选择入度为0的节点
    Private Function FindRoot(CourseMatrix, CoursesNum)
        Dim temp = 0
        Dim output = -1
        For a = 0 To CoursesNum - 1
            For b = 0 To CoursesNum - 1
                temp = temp + CourseMatrix(b, a)
            Next

            If temp = 0 Then
                output = a
                For b = 0 To CoursesNum - 1
                    If CourseMatrix(a, b) > 0 Then
                        CourseMatrix(a, b) = CourseMatrix(a, b) - 1
                    End If
                Next

                For b = 0 To CoursesNum - 1
                    CourseMatrix(b, a) = -1
                Next
                Exit For
            End If

            temp = 0
        Next

        Return output
    End Function

    '在控制台输出邻接矩阵（调试用函数）
    Private Function ShowMatrix(CourseMatrix, CoursesNum)
        '输出邻接矩阵
        For a = 0 To CoursesNum - 1
            For b = 0 To CoursesNum - 1
                Console.Write(CourseMatrix(a, b))
                Console.Write(" ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()
        Return Nothing
    End Function

    '拓扑排序功能函数，根据均匀分配课程的学分限制进行拓扑排序
    Private Function Calculate1(CoursesNum, NowCredit, CreditLimit, NowTerms)
        '构建学期树
        TreeView1.Nodes.Clear()

        For a = 1 To Terms
            Dim nodes As New TreeNode With {
                .Text = "第" + CStr(a) + "学期",
                .Tag = (a - 1) * 100
            }
            TreeView1.Nodes.Add(nodes)
        Next

        '构建邻接矩阵
        Dim CourseMatrix(CoursesNum - 1, CoursesNum - 1) As Integer
        For a = 0 To CoursesNum - 1
            For b = 0 To CoursesNum - 1
                '遍历查找（3，a）中的字符串有无（0，b）的数据
                If InStr(TeachingManagementSystem.CourseTable(3, a).Value, TeachingManagementSystem.CourseTable(0, b).Value) > 0 Then
                    CourseMatrix(b, a) = 1
                End If
            Next
        Next

        ShowMatrix(CourseMatrix, CoursesNum)

        For a = 1 To CoursesNum
            Dim root = FindRoot(CourseMatrix, CoursesNum)
            If root >= 0 Then
                NowCredit = NowCredit + CInt(TeachingManagementSystem.CourseTable(2, root).Value)
                While NowCredit > CreditLimit
                    NowCredit = 0
                    NowCredit = NowCredit + CInt(TeachingManagementSystem.CourseTable(2, root).Value)
                    NowTerms = NowTerms + 1
                    If NowTerms >= Terms Then
                        TreeView1.Nodes.Clear()
                        OutputTable.Rows.Clear()
                        Return False
                        Exit Function
                    End If
                End While

                If NowCredit <= CreditLimit Then
                    Dim nodes As New TreeNode With {
                        .Text = TeachingManagementSystem.CourseTable(1, root).Value,
                        .Tag = NowTerms * 100 + root
                    }
                    TreeView1.Nodes(NowTerms).Nodes.Add(nodes)
                    ShowMatrix(CourseMatrix, CoursesNum)
                End If
            End If
        Next

        TreeView1.ExpandAll()
        Return True
    End Function

    '拓扑排序功能函数，根据集中分配课程的学分限制进行拓扑排序
    Private Function Calculate2(CoursesNum, NowCredit, CreditLimit, NowTerms)
        '构建学期树
        TreeView1.Nodes.Clear()

        For a = 1 To Terms
            Dim nodes As New TreeNode With {
                .Text = "第" + CStr(a) + "学期",
                .Tag = (a - 1) * 100
            }
            TreeView1.Nodes.Add(nodes)
        Next

        '构建邻接矩阵
        Dim CourseMatrix(CoursesNum - 1, CoursesNum - 1) As Integer
        For a = 0 To CoursesNum - 1
            For b = 0 To CoursesNum - 1
                '遍历查找（3，a）中的字符串有无（0，b）的数据
                If InStr(TeachingManagementSystem.CourseTable(3, a).Value, TeachingManagementSystem.CourseTable(0, b).Value) > 0 Then
                    CourseMatrix(b, a) = 1
                End If
            Next
        Next

        ShowMatrix(CourseMatrix, CoursesNum)

        For a = 1 To CoursesNum
            Dim root = FindRoot(CourseMatrix, CoursesNum)
            If root >= 0 Then
                NowCredit = NowCredit + CInt(TeachingManagementSystem.CourseTable(2, root).Value)
                While NowCredit > CreditLimit
                    NowCredit = 0
                    NowCredit = NowCredit + CInt(TeachingManagementSystem.CourseTable(2, root).Value)
                    NowTerms = NowTerms + 1
                    If NowTerms >= Terms Then
                        MsgBox("课程太多，无法分配")
                        TreeView1.Nodes.Clear()
                        OutputTable.Rows.Clear()
                        Close()
                        Return False
                        Exit Function
                    End If
                End While

                If NowCredit <= CreditLimit Then
                    Dim nodes As New TreeNode With {
                        .Text = TeachingManagementSystem.CourseTable(1, root).Value,
                        .Tag = NowTerms * 100 + root
                    }
                    TreeView1.Nodes(NowTerms).Nodes.Add(nodes)
                    ShowMatrix(CourseMatrix, CoursesNum)
                End If
            End If
        Next

        TreeView1.ExpandAll()
        Return True
    End Function

    '进入图形化演示拓扑排序
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CoursesNum = 0
        While CoursesNum < TeachingManagementSystem.CourseTable.RowCount
            If TeachingManagementSystem.CourseTable(0, CoursesNum).Value <> "" Then
                CoursesNum = CoursesNum + 1
            Else
                Exit While
            End If
        End While

        If CoursesNum > 8 Then
            MsgBox("数据超过8个，演示效果过差，无法进行图形化演示")
        Else
            PictureShow.Show()
        End If
    End Sub
End Class