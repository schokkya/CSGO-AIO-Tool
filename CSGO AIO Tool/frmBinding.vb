Public Class frmBinding
    Public currentkey As String
    Private Sub binding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim commands As String = ""

        lblCommands.Text = "List of commands you can use:" & vbNewLine & """command"" // Comment/info about command (layout)" & vbNewLine & """say"" <message> // Sends a message in in-game chat " _
            & vbNewLine & """say_team"" <message> // Sends a message in in-game teamchat" & vbNewLine & """+voicerecord"" // Hold bound button in to speak in voice comms." _
            & vbNewLine & """+lookatweapon"" // Press bound button to inspect weapon" & vbNewLine & """buymenu"" // Press bound button to open up the buy menu" & vbNewLine _
            & """drop"" // Press bound button to drop a weapon or C4" & vbNewLine & """+use"" // Press bound button to open doors, pick up weapon or defuse bomb -ESSENTIAL-" & vbNewLine _
            & """messagemode"" // Press bound button to open up chat menu" & vbNewLine & """messagemode2"" // Press bound button to open up team chat menu" & vbNewLine _
            & """teammenu"" // Press bound button to open up team selection menu" & vbNewLine & """toggleconsole"" // Press bound button to open/close console" & vbNewLine _
            & """vol0"" // Press bound button to set volume to 0 (custom command)" & vbNewLine & """vol001"" // Press bound button to set volume to 0.01 (custom command)" & vbNewLine _
            & """vol01"" // Press bound button to set volume to 0.1 (custom command)" & vbNewLine & """vol1"" // Press bound button to set volume to 1 (custom command)" & vbNewLine _
            & ""
        txtBind.Clear()
        Me.Location = New Point(frmMain.Location.X + 250, frmMain.Location.Y)
        currentkey = frmMain.currentkey
        Me.Text = "Set a binding for key: " & currentkey
        lblBinding.Text = "Set a binding for key: " & currentkey
        If commands = "" Then
            txtBind.Text = "bind """ & currentkey & """ " & """ """
        Else
            txtBind.Text = commands
        End If
        lblBoundTo.Text = txtBind.Text & " will be bound to: " & currentkey
    End Sub

    Private Sub txtBind_TextChanged(sender As Object, e As EventArgs) Handles txtBind.TextChanged
        lblBoundTo.Text = txtBind.Text & " will be bound to: " & currentkey
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Me.Close()
    End Sub
End Class