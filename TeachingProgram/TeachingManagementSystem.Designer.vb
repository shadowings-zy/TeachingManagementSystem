<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeachingManagementSystem
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
        Me.components = New System.ComponentModel.Container()
        Me.CourseTable = New System.Windows.Forms.DataGridView()
        Me.CourseNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prerequisite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CourseLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.MaxCredit = New System.Windows.Forms.TextBox()
        Me.Terms = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Output = New System.Windows.Forms.Button()
        Me.ImportData = New System.Windows.Forms.Button()
        Me.SaveTeaching = New System.Windows.Forms.Button()
        Me.OpenTeaching = New System.Windows.Forms.Button()
        Me.NewTeaching = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.CourseTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dataContextMenuStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CourseTable
        '
        Me.CourseTable.AllowUserToAddRows = False
        Me.CourseTable.AllowUserToDeleteRows = False
        Me.CourseTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CourseTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CourseNumber, Me.CourseName, Me.Credit, Me.Prerequisite})
        Me.CourseTable.ContextMenuStrip = Me.dataContextMenuStrip
        Me.CourseTable.Location = New System.Drawing.Point(12, 50)
        Me.CourseTable.Name = "CourseTable"
        Me.CourseTable.RowHeadersVisible = False
        Me.CourseTable.RowTemplate.Height = 23
        Me.CourseTable.Size = New System.Drawing.Size(443, 472)
        Me.CourseTable.TabIndex = 0
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
        'dataContextMenuStrip
        '
        Me.dataContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddRowToolStripMenuItem, Me.DeleteRowToolStripMenuItem})
        Me.dataContextMenuStrip.Name = "ContextMenuStrip1"
        Me.dataContextMenuStrip.Size = New System.Drawing.Size(173, 48)
        '
        'AddRowToolStripMenuItem
        '
        Me.AddRowToolStripMenuItem.Name = "AddRowToolStripMenuItem"
        Me.AddRowToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.AddRowToolStripMenuItem.Text = "在最下方添加一列"
        '
        'DeleteRowToolStripMenuItem
        '
        Me.DeleteRowToolStripMenuItem.Name = "DeleteRowToolStripMenuItem"
        Me.DeleteRowToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.DeleteRowToolStripMenuItem.Text = "删除选中的所有列"
        '
        'CourseLabel
        '
        Me.CourseLabel.AutoSize = True
        Me.CourseLabel.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CourseLabel.Location = New System.Drawing.Point(187, 12)
        Me.CourseLabel.Name = "CourseLabel"
        Me.CourseLabel.Size = New System.Drawing.Size(92, 27)
        Me.CourseLabel.TabIndex = 1
        Me.CourseLabel.Text = "课程信息"
        Me.CourseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CourseTable)
        Me.Panel1.Controls.Add(Me.CourseLabel)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 538)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Controls.Add(Me.MaxCredit)
        Me.Panel2.Controls.Add(Me.Terms)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(486, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 177)
        Me.Panel2.TabIndex = 3
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(125, 135)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(98, 21)
        Me.RadioButton2.TabIndex = 8
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "集中分配课程"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(21, 135)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(98, 21)
        Me.RadioButton1.TabIndex = 7
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "均匀分配课程"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'MaxCredit
        '
        Me.MaxCredit.Location = New System.Drawing.Point(88, 98)
        Me.MaxCredit.Name = "MaxCredit"
        Me.MaxCredit.Size = New System.Drawing.Size(143, 21)
        Me.MaxCredit.TabIndex = 6
        '
        'Terms
        '
        Me.Terms.Location = New System.Drawing.Point(88, 61)
        Me.Terms.Name = "Terms"
        Me.Terms.Size = New System.Drawing.Size(143, 21)
        Me.Terms.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "学分上限"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "学期总数"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 27)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "教学计划设置"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Output)
        Me.Panel3.Controls.Add(Me.ImportData)
        Me.Panel3.Controls.Add(Me.SaveTeaching)
        Me.Panel3.Controls.Add(Me.OpenTeaching)
        Me.Panel3.Controls.Add(Me.NewTeaching)
        Me.Panel3.Location = New System.Drawing.Point(486, 196)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(255, 256)
        Me.Panel3.TabIndex = 4
        '
        'Output
        '
        Me.Output.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Output.Location = New System.Drawing.Point(4, 188)
        Me.Output.Name = "Output"
        Me.Output.Size = New System.Drawing.Size(246, 60)
        Me.Output.TabIndex = 4
        Me.Output.Text = "生成结果"
        Me.Output.UseVisualStyleBackColor = True
        '
        'ImportData
        '
        Me.ImportData.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ImportData.Location = New System.Drawing.Point(4, 142)
        Me.ImportData.Name = "ImportData"
        Me.ImportData.Size = New System.Drawing.Size(246, 40)
        Me.ImportData.TabIndex = 3
        Me.ImportData.Text = "导入Excel文件数据"
        Me.ImportData.UseVisualStyleBackColor = True
        '
        'SaveTeaching
        '
        Me.SaveTeaching.AutoSize = True
        Me.SaveTeaching.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SaveTeaching.Location = New System.Drawing.Point(4, 96)
        Me.SaveTeaching.Name = "SaveTeaching"
        Me.SaveTeaching.Size = New System.Drawing.Size(246, 40)
        Me.SaveTeaching.TabIndex = 2
        Me.SaveTeaching.Text = "保存教学计划编制"
        Me.SaveTeaching.UseVisualStyleBackColor = True
        '
        'OpenTeaching
        '
        Me.OpenTeaching.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpenTeaching.Location = New System.Drawing.Point(4, 50)
        Me.OpenTeaching.Name = "OpenTeaching"
        Me.OpenTeaching.Size = New System.Drawing.Size(246, 40)
        Me.OpenTeaching.TabIndex = 1
        Me.OpenTeaching.Text = "打开教学计划编制"
        Me.OpenTeaching.UseVisualStyleBackColor = True
        '
        'NewTeaching
        '
        Me.NewTeaching.BackColor = System.Drawing.SystemColors.Control
        Me.NewTeaching.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NewTeaching.ForeColor = System.Drawing.Color.Black
        Me.NewTeaching.Location = New System.Drawing.Point(4, 4)
        Me.NewTeaching.Name = "NewTeaching"
        Me.NewTeaching.Size = New System.Drawing.Size(246, 40)
        Me.NewTeaching.TabIndex = 0
        Me.NewTeaching.Text = "新建教学计划编制"
        Me.NewTeaching.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Image = Global.TeachingProgram.My.Resources.Resources.ZY
        Me.Button1.Location = New System.Drawing.Point(486, 459)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(255, 91)
        Me.Button1.TabIndex = 5
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TeachingManagementSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 562)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TeachingManagementSystem"
        Me.Text = "教学计划编制系统"
        CType(Me.CourseTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dataContextMenuStrip.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CourseTable As DataGridView
    Friend WithEvents CourseLabel As Label
    Friend WithEvents dataContextMenuStrip As ContextMenuStrip
    Friend WithEvents AddRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MaxCredit As TextBox
    Friend WithEvents Terms As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Output As Button
    Friend WithEvents ImportData As Button
    Friend WithEvents SaveTeaching As Button
    Friend WithEvents OpenTeaching As Button
    Friend WithEvents NewTeaching As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents CourseNumber As DataGridViewTextBoxColumn
    Friend WithEvents CourseName As DataGridViewTextBoxColumn
    Friend WithEvents Credit As DataGridViewTextBoxColumn
    Friend WithEvents Prerequisite As DataGridViewTextBoxColumn
End Class
