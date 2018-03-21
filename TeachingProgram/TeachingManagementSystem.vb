Imports System.IO

Public Class TeachingManagementSystem
    Public RowsNum = 15
    Public ImportFilePath = ""
    Public AllData(399) As String
    'ALLData数组中数据含义：0：文件地址，1：学期总数，千位/学分上限百位十位个位，2：分配方式，3：行数，4-399：数据
    '所以一共可以存99种课程信息。

    Private Sub TeachingManagementSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设置窗体不可最大化，不可更改大小
        FormBorderStyle = BorderStyle.FixedSingle
        MaximizeBox = False

        '课程信息初始设定为15行
        For a = 0 To 15
            CourseTable.Rows.Add()
        Next

        '设定data数组的初始值
        AllData(1) = ""
        AllData(2) = "0"
        AllData(3) = CStr(RowsNum)
        For a = 4 To 399
            AllData(a) = ""
        Next

        EnableItems(False)
    End Sub

    '关闭窗体之前弹出是否保存的消息框
    Private Sub TeachingManagementSystem_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Dim buttom = vbYesNo + vbDefaultButton2
        Dim response = MsgBox("您想在退出之前保存所做的更改吗？", buttom)

        If response = vbYes Then
            If AllData(0) <> "" Then
                File.WriteAllLines(AllData(0), AllData, System.Text.Encoding.Default)
                MsgBox("保存成功")
            Else
                MsgBox("保存失败")
            End If
        End If
    End Sub

    '右键datagridview，添加一行
    Private Sub AddRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRowToolStripMenuItem.Click
        CourseTable.Rows.Add()
        RowsNum = RowsNum + 1
        AllData(3) = CStr(RowsNum)
    End Sub

    '右键datagridview，删除一行
    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        For Each row As DataGridViewCell In CourseTable.SelectedCells
            If row.RowIndex < 0 Then
                RowsNum = 0
                AllData(3) = CStr(RowsNum)
            Else
                RowsNum = RowsNum - 1
                AllData(3) = CStr(RowsNum)
                AllData(row.RowIndex * 4 + 4) = ""
                AllData(row.RowIndex * 4 + 5) = ""
                AllData(row.RowIndex * 4 + 6) = ""
                AllData(row.RowIndex * 4 + 7) = ""
                CourseTable.Rows.RemoveAt(row.RowIndex)
            End If
        Next
    End Sub

    '新建教学计划编制文件
    Private Sub NewTeaching_Click(sender As Object, e As EventArgs) Handles NewTeaching.Click
        Dim newProjectPath = FolderBrowserDialog1.ShowDialog()
        If newProjectPath = DialogResult.OK Then
            AllData(0) = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        Dim projectName = InputBox("请输入教学计划编制名称：", "输入框", "")

        If projectName = "" Then
            MsgBox("输入名不能为空")
            Exit Sub
        End If

        '判断文件是否存在,若不存在，则新建文件并写入数据
        If Dir(AllData(0) + "\" + projectName) = "" Then
            AllData(0) = AllData(0) + "\" + projectName + ".tms"
            File.WriteAllLines(AllData(0), AllData, System.Text.Encoding.Default)
            EnableItems(True)
        Else
            MsgBox("已有同名文件！")
        End If
    End Sub

    '打开教学计划编制文件
    Private Sub OpenTeaching_Click(sender As Object, e As EventArgs) Handles OpenTeaching.Click
        OpenFileDialog1.Filter = "Teaching Management System Files (*.tms)|*.tms"
        If Not OpenFileDialog1.ShowDialog(Me) = vbOK Then
            Exit Sub
        End If

        AllData = File.ReadAllLines(OpenFileDialog1.FileName, System.Text.Encoding.Default)
        '打开后赋值
        Terms.Text = CInt(AllData(1)) \ 1000
        MaxCredit.Text = CInt(AllData(1)) Mod 1000
        If (AllData(2) = "1") Then
            RadioButton2.Checked = True
        Else
            RadioButton1.Checked = True
        End If
        CourseTable.Rows.Clear()
        RowsNum = CInt(AllData(3))
        For a = 1 To RowsNum
            CourseTable.Rows.Add()
            For b = 0 To 3
                CourseTable(b, a - 1).Value = AllData(4 * a + b)
            Next
        Next
        EnableItems(True)
        MsgBox("打开成功！")
    End Sub

    '保存教学计划编制文件
    Private Sub SaveTeaching_Click(sender As Object, e As EventArgs) Handles SaveTeaching.Click
        Try
            AllData(1) = CStr(CInt(MaxCredit.Text) + CInt(Terms.Text) * 1000)
            File.WriteAllLines(AllData(0), AllData, System.Text.Encoding.Default)
            MsgBox("保存成功！")
        Catch ex As Exception
            MsgBox("保存失败！数据不符合规范")
        End Try
    End Sub

    '选择集中分配or均匀分配课程
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If (RadioButton1.Checked) Then
            AllData(2) = "0"
        Else
            AllData(2) = "1"
        End If
    End Sub

    '选择集中分配or均匀分配课程
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If (RadioButton1.Checked) Then
            AllData(2) = "0"
        Else
            AllData(2) = "1"
        End If
    End Sub

    Private Sub CourseTable_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles CourseTable.CellEndEdit
        For Each cell As DataGridViewCell In CourseTable.SelectedCells
            If CourseTable(cell.ColumnIndex, cell.RowIndex).Value <> "" Then
                AllData(cell.RowIndex * 4 + cell.ColumnIndex + 4) = CourseTable(cell.ColumnIndex, cell.RowIndex).Value.ToString
            Else
                AllData(cell.RowIndex * 4 + cell.ColumnIndex + 4) = ""
                CourseTable(cell.ColumnIndex, cell.RowIndex).Value = ""
            End If
        Next
    End Sub

    '导入Excel数据
    Private Sub ImportData_Click(sender As Object, e As EventArgs) Handles ImportData.Click
        OpenFileDialog1.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
        If Not OpenFileDialog1.ShowDialog(Me) = vbOK Then
            Exit Sub
        End If
        ImportFilePath = OpenFileDialog1.FileName

        Try
            Dim xlApp = CreateObject("Excel.Application")
            Dim xlBook = xlApp.Workbooks.Open(ImportFilePath)
            Dim xlSheet = xlBook.worksheets(1)

            Dim excelRow = 0

            xlSheet.Activate() '激活工作表
            CourseTable.Rows.Clear()

            While xlSheet.Cells(excelRow + 2, 1).Text.ToString <> ""
                CourseTable.Rows.Add()
                excelRow = excelRow + 1
            End While

            For a = 1 To excelRow
                For b = 1 To 4
                    CourseTable(b - 1, a - 1).Value = xlSheet.Cells(a + 1, b).Text
                    AllData(4 * a + b - 1) = xlSheet.Cells(a + 1, b).Text
                Next
            Next

            MsgBox("导入完成")
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

    '开始计算
    Private Sub Output_Click(sender As Object, e As EventArgs) Handles Output.Click
        If IsNumeric(Terms.Text) And InStr(Terms.Text, " ") = 0 And Terms.Text <> "" And IsNumeric(MaxCredit.Text) And InStr(MaxCredit.Text, " ") = 0 And MaxCredit.Text <> "" And CheckData() Then
            Consequence.Show()
        Else
            MsgBox("您有未填写或填写不正确的数据哦")
        End If
    End Sub

    '软件信息
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SoftwareInfo.Show()
    End Sub

    '使组件可用or不可用
    Function EnableItems(flag)
        Terms.Enabled = flag
        MaxCredit.Enabled = flag
        RadioButton1.Enabled = flag
        RadioButton2.Enabled = flag
        CourseTable.Enabled = flag
        SaveTeaching.Enabled = flag
        ImportData.Enabled = flag
        Output.Enabled = flag
        Return Nothing
    End Function

    '检查输入的数据是否合法，主要判别是否有空值，是否有课序号重复的值，是否有先修课不合法的值。
    Function CheckData()
        Dim dataRow = 0
        Dim target() As String
        For a = 0 To CourseTable.RowCount - 1
            If CourseTable(0, a).Value <> "" Then
                dataRow = dataRow + 1
            End If
        Next


        For a = 0 To dataRow - 1
            For b = a + 1 To dataRow - 1
                If CourseTable(0, b).Value = CourseTable(0, a).Value Then
                    Return False
                    Exit Function
                End If
            Next
        Next

        Dim flag = 0
        For a = 0 To dataRow - 1

            target = Split(CourseTable(3, a).Value, "&")
            For c = 0 To target.Length - 1
                flag = 0

                For b = 0 To dataRow - 1
                    If target(c) <> CourseTable(0, b).Value And CourseTable(3, a).Value <> "" Then
                        flag = flag + 1
                    End If
                Next

                If flag = dataRow Then
                    Return False
                    Exit Function
                End If
            Next
        Next
        Return True
    End Function

End Class