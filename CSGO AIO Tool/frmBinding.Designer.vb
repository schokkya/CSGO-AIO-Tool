<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBinding
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblBinding = New System.Windows.Forms.Label()
        Me.txtBind = New System.Windows.Forms.TextBox()
        Me.lblBoundTo = New System.Windows.Forms.Label()
        Me.lblCommands = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(12, 80)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(445, 31)
        Me.btnConfirm.TabIndex = 0
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lblBinding
        '
        Me.lblBinding.AutoSize = True
        Me.lblBinding.Location = New System.Drawing.Point(12, 9)
        Me.lblBinding.Name = "lblBinding"
        Me.lblBinding.Size = New System.Drawing.Size(110, 13)
        Me.lblBinding.TabIndex = 1
        Me.lblBinding.Text = "Set a binding for key: "
        '
        'txtBind
        '
        Me.txtBind.Location = New System.Drawing.Point(15, 41)
        Me.txtBind.Name = "txtBind"
        Me.txtBind.Size = New System.Drawing.Size(442, 20)
        Me.txtBind.TabIndex = 2
        '
        'lblBoundTo
        '
        Me.lblBoundTo.AutoSize = True
        Me.lblBoundTo.Location = New System.Drawing.Point(12, 64)
        Me.lblBoundTo.Name = "lblBoundTo"
        Me.lblBoundTo.Size = New System.Drawing.Size(61, 13)
        Me.lblBoundTo.TabIndex = 3
        Me.lblBoundTo.Text = "BOUNDTO"
        '
        'lblCommands
        '
        Me.lblCommands.AutoSize = True
        Me.lblCommands.Location = New System.Drawing.Point(12, 114)
        Me.lblCommands.Name = "lblCommands"
        Me.lblCommands.Size = New System.Drawing.Size(156, 13)
        Me.lblCommands.TabIndex = 4
        Me.lblCommands.Text = "List of commands you can use: "
        '
        'frmBinding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(469, 450)
        Me.Controls.Add(Me.lblCommands)
        Me.Controls.Add(Me.lblBoundTo)
        Me.Controls.Add(Me.txtBind)
        Me.Controls.Add(Me.lblBinding)
        Me.Controls.Add(Me.btnConfirm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmBinding"
        Me.Text = "Set a binding for key: "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConfirm As Button
    Friend WithEvents lblBinding As Label
    Friend WithEvents txtBind As TextBox
    Friend WithEvents lblBoundTo As Label
    Friend WithEvents lblCommands As Label
End Class
