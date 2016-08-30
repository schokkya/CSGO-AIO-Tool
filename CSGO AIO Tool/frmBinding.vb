Public Class frmBinding
    Public currentkey, commands As String
    Private Sub binding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(frmMain.Location.X + 250, frmMain.Location.Y)
        currentkey = frmMain.currentkey
        Me.Text = "Set a binding for key: " & currentkey
        lblBinding.Text = "Set a binding for key: " & currentkey
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        Me.Close()
    End Sub
End Class