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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(15, 243)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(375, 31)
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
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(372, 20)
        Me.TextBox1.TabIndex = 2
        '
        'frmBinding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 286)
        Me.Controls.Add(Me.TextBox1)
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
    Friend WithEvents TextBox1 As TextBox
End Class
