Public Class PictureShow
    Dim Terms = CInt(TeachingManagementSystem.Terms.Text)
    Dim CoursesText() As String = {"a", "b", "c", "d", "e", "f", "g", "h"}
    Dim Matrix(,) As Integer = {
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1},
        {-1, -1, -1, -1, -1, -1, -1, -1}
    }

    Private Sub PictureShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设置窗体不可最大化，不可更改大小
        FormBorderStyle = BorderStyle.FixedSingle
        MaximizeBox = False
    End Sub

    '初始化面板，根据邻接矩阵和课程信息，在界面上画N个圆圈代表N种要排序的课程
    Private Sub getMatrixPictuer(Matrix(,) As Integer, Text() As String, Panel As Panel, drawWindow As Graphics)
        Dim drawPenRed As New Pen(Color.FromArgb(253, 121, 35), 6)
        Dim drawPenBlue As New Pen(Color.FromArgb(249, 178, 113), 3)
        Dim Xarray() = {250, 120, 380, 80, 420, 120, 380, 250}
        Dim Yarray() = {20, 70, 70, 180, 180, 290, 290, 340}

        If Matrix(0, 0) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 250, 20, 20, 20)
            Label1.Location = New Point(Xarray(0) - Label1.Size.Width / 2 + 12, (Yarray(0) - 30 + 12))
            Label1.Text = Text(0)
            Label1.Visible = True
        Else
            Label1.Visible = False
        End If

        If Matrix(0, 1) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 120, 70, 20, 20)
            Label2.Location = New Point(Xarray(1) - Label1.Size.Width / 2 + 12, (Yarray(1) - 30 + 12))
            Label2.Text = Text(1)
            Label2.Visible = True
        Else
            Label2.Visible = False
        End If

        If Matrix(0, 2) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 380, 70, 20, 20)
            Label3.Location = New Point(Xarray(2) - Label1.Size.Width / 2 + 12, (Yarray(2) - 30 + 12))
            Label3.Text = Text(2)
            Label3.Visible = True
        Else
            Label3.Visible = False
        End If

        If Matrix(0, 3) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 80, 180, 20, 20)
            Label4.Location = New Point(Xarray(3) - Label1.Size.Width - 25 + 12, (Yarray(3) + 12 - Label1.Size.Height / 2))
            Label4.Text = Text(3)
            Label4.Visible = True
        Else
            Label4.Visible = False
        End If

        If Matrix(0, 4) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 420, 180, 20, 20)
            Label5.Location = New Point(Xarray(4) + 25 + 12, (Yarray(4) + 12 - Label1.Size.Height / 2))
            Label5.Text = Text(4)
            Label5.Visible = True
        Else
            Label5.Visible = False
        End If

        If Matrix(0, 5) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 120, 290, 20, 20)
            Label6.Location = New Point(Xarray(5) - Label1.Size.Width / 2 + 12, (Yarray(5) + 15 + 12))
            Label6.Text = Text(5)
            Label6.Visible = True
        Else
            Label6.Visible = False
        End If

        If Matrix(0, 6) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 380, 290, 20, 20)
            Label7.Location = New Point(Xarray(6) - Label1.Size.Width / 2 + 12, (Yarray(6) + 15 + 12))
            Label7.Text = Text(6)
            Label7.Visible = True
        Else
            Label7.Visible = False
        End If

        If Matrix(0, 7) <> -1 Then
            drawWindow.DrawEllipse(drawPenRed, 250, 340, 20, 20)
            Label8.Location = New Point(Xarray(7) - Label1.Size.Width / 2 + 12, (Yarray(7) + 15 + 12))
            Label8.Text = Text(7)
            Label8.Visible = True
        Else
            Label8.Visible = False
        End If

        For a = 0 To 7
            For b = 0 To 7
                If Matrix(a, b) = 1 Then
                    Arrow(drawWindow, drawPenBlue, Xarray(a) + 10, Yarray(a) + 10, Xarray(b) + 10, Yarray(b) + 10, 15)
                End If
            Next
        Next

    End Sub

    '画箭头
    Private Sub Arrow(drawWindow As Graphics, drawPen As Pen, X0 As Single, Y0 As Single, x1 As Single, y1 As Single, ArrowLen As Single)
        Dim Xa As Single, Ya As Single, Xb As Single, Yb As Single, D As Double
        D = Math.Sqrt((y1 - Y0) * (y1 - Y0) + (x1 - X0) * (x1 - X0))
        If D > 0.0000000001 Then
            Xa = x1 + ArrowLen * ((X0 - x1) + (Y0 - y1) / 2) / D
            Ya = y1 + ArrowLen * ((Y0 - y1) - (X0 - x1) / 2) / D
            Xb = x1 + ArrowLen * ((X0 - x1) - (Y0 - y1) / 2) / D
            Yb = y1 + ArrowLen * ((Y0 - y1) + (X0 - x1) / 2) / D
            drawWindow.DrawLine(drawPen, Xa, Ya, x1, y1)
            drawWindow.DrawLine(drawPen, Xb, Yb, x1, y1)
            drawWindow.DrawLine(drawPen, X0, Y0, x1, y1)
        End If
    End Sub

    '拓扑排序功能函数，找到入度为0的节点
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

    '输出邻接矩阵
    Private Function ShowMatrix(CourseMatrix, CoursesNum)
        For a = 0 To CoursesNum - 1
            For b = 0 To CoursesNum - 1
                Matrix(a, b) = CourseMatrix(a, b)
                Console.Write(CourseMatrix(a, b))
                Console.Write(" ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()
        Return Nothing
    End Function

    '刷新界面
    Private Function getPicture()
        Refresh()

        Dim MyGraphics As Graphics = Panel1.CreateGraphics()    '声明一个Graphics类的对象并实例化
        getMatrixPictuer(Matrix, CoursesText, Panel1, MyGraphics)
        TreeView1.ExpandAll()
        Return Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CreditLimit = 0
        Dim NowCredit = 0
        Dim NowTerms = 0
        Dim CoursesNum = 0

        '获取课程总数和学分限制
        While CoursesNum < TeachingManagementSystem.CourseTable.RowCount
            If TeachingManagementSystem.CourseTable(0, CoursesNum).Value <> "" Then
                CreditLimit = CreditLimit + CInt(TeachingManagementSystem.CourseTable(2, CoursesNum).Value)
                CoursesText(CoursesNum) = TeachingManagementSystem.CourseTable(1, CoursesNum).Value
                CoursesNum = CoursesNum + 1
            Else
                Exit While
            End If
        End While

        CreditLimit = Consequence.CredictLimitFinal
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
                If InStr(TeachingManagementSystem.CourseTable(3, a).Value, TeachingManagementSystem.CourseTable(0, b).Value) > 0 Then
                    CourseMatrix(b, a) = 1
                End If
                Matrix(b, a) = CourseMatrix(b, a)
            Next
        Next

        ShowMatrix(Matrix, CoursesNum)
        getPicture()
        MsgBox("点击确定进行下一步")

        For a = 1 To CoursesNum
            Dim root = FindRoot(CourseMatrix, CoursesNum)
            If root >= 0 Then
                NowCredit = NowCredit + CInt(TeachingManagementSystem.CourseTable(2, root).Value)
                While NowCredit > CreditLimit
                    NowCredit = 0
                    NowCredit = NowCredit + CInt(TeachingManagementSystem.CourseTable(2, root).Value)
                    NowTerms = NowTerms + 1
                End While

                If NowCredit <= CreditLimit Then
                    Dim nodes As New TreeNode With {
                        .Text = TeachingManagementSystem.CourseTable(1, root).Value,
                        .Tag = NowTerms * 100 + root
                    }
                    TreeView1.Nodes(NowTerms).Nodes.Add(nodes)
                    ShowMatrix(CourseMatrix, CoursesNum)
                    getPicture()
                    MsgBox("点击确定进行下一步")
                End If
            End If
        Next

        TreeView1.ExpandAll()
    End Sub
End Class