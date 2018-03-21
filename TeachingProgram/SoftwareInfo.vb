Public Class SoftwareInfo
    Private Sub SoftwareInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设置窗体不可最大化，不可更改大小
        FormBorderStyle = BorderStyle.FixedSingle
        MaximizeBox = False
    End Sub
End Class