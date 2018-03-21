<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consequence
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.OutputTable = New System.Windows.Forms.DataGridView()
        Me.CourseNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prerequisite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.OutputTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(13, 13)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(250, 389)
        Me.TreeView1.TabIndex = 0
        '
        'OutputTable
        '
        Me.OutputTable.AllowUserToAddRows = False
        Me.OutputTable.AllowUserToDeleteRows = False
        Me.OutputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutputTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CourseNumber, Me.CourseName, Me.Credit, Me.Prerequisite})
        Me.OutputTable.Location = New System.Drawing.Point(279, 13)
        Me.OutputTable.Name = "OutputTable"
        Me.OutputTable.RowHeadersVisible = False
        Me.OutputTable.RowTemplate.Height = 23
        Me.OutputTable.Size = New System.Drawing.Size(443, 487)
        Me.OutputTable.TabIndex = 1
        '
        'CourseNumber
        '
        Me.CourseNumber.HeaderText = "课程号"
        Me.CourseNumber.Name = "CourseNumber"
        Me.CourseNumber.Width = 80
        '
        'CourseName
        '
        Me.CourseName.HeaderText = "课程名称"
        Me.CourseName.Name = "CourseName"
        Me.CourseName.Width = 150
        '
        'Credit
        '
        Me.Credit.HeaderText = "学分"
        Me.Credit.Name = "Credit"
        Me.Credit.Width = 60
        '
        'Prerequisite
        '
        Me.Prerequisite.HeaderText = "先修课"
        Me.Prerequisite.Name = "Prerequisite"
        Me.Prerequisite.Width = 150
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(13, 408)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(250, 43)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "导出为Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button2.Location = New System.Drawing.Point(13, 457)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(250, 43)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "图形化演示"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Consequence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 512)
        Me.Controls.Add(Me.OutputTable)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "Consequence"
        Me.Text = "Consequence"
        CType(Me.OutputTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents OutputTable As DataGridView
    Friend WithEvents CourseNumber As DataGridViewTextBoxColumn
    Friend WithEvents CourseName As DataGridViewTextBoxColumn
    Friend WithEvents Credit As DataGridViewTextBoxColumn
    Friend WithEvents Prerequisite As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button2 As Button
End Class
