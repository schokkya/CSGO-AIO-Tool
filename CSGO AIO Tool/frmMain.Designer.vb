﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.tabfrm = New System.Windows.Forms.TabControl()
        Me.tabWelcome = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblCSGOpath = New System.Windows.Forms.Label()
        Me.btnIncorrectpath = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tabfrm.SuspendLayout()
        Me.tabWelcome.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabfrm
        '
        Me.tabfrm.Controls.Add(Me.tabWelcome)
        Me.tabfrm.Controls.Add(Me.TabPage2)
        Me.tabfrm.Controls.Add(Me.TabPage3)
        Me.tabfrm.Controls.Add(Me.TabPage4)
        Me.tabfrm.Controls.Add(Me.TabPage5)
        Me.tabfrm.Location = New System.Drawing.Point(0, -2)
        Me.tabfrm.Name = "tabfrm"
        Me.tabfrm.SelectedIndex = 0
        Me.tabfrm.Size = New System.Drawing.Size(754, 427)
        Me.tabfrm.TabIndex = 0
        '
        'tabWelcome
        '
        Me.tabWelcome.Controls.Add(Me.Button1)
        Me.tabWelcome.Controls.Add(Me.btnIncorrectpath)
        Me.tabWelcome.Controls.Add(Me.lblCSGOpath)
        Me.tabWelcome.Controls.Add(Me.txtStatus)
        Me.tabWelcome.Controls.Add(Me.btnBackup)
        Me.tabWelcome.Controls.Add(Me.lblWelcome)
        Me.tabWelcome.Location = New System.Drawing.Point(4, 22)
        Me.tabWelcome.Name = "tabWelcome"
        Me.tabWelcome.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWelcome.Size = New System.Drawing.Size(746, 401)
        Me.tabWelcome.TabIndex = 0
        Me.tabWelcome.Text = "Welcome"
        Me.tabWelcome.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(746, 401)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(746, 401)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(746, 401)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(746, 401)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Location = New System.Drawing.Point(8, 12)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(81, 13)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "<welcome text>"
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(11, 365)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(116, 27)
        Me.btnBackup.TabIndex = 1
        Me.btnBackup.Text = "Create Backup"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(413, 81)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(327, 311)
        Me.txtStatus.TabIndex = 2
        '
        'lblCSGOpath
        '
        Me.lblCSGOpath.AutoSize = True
        Me.lblCSGOpath.Location = New System.Drawing.Point(8, 138)
        Me.lblCSGOpath.Name = "lblCSGOpath"
        Me.lblCSGOpath.Size = New System.Drawing.Size(63, 13)
        Me.lblCSGOpath.TabIndex = 3
        Me.lblCSGOpath.Text = "<csgopath>"
        '
        'btnIncorrectpath
        '
        Me.btnIncorrectpath.Location = New System.Drawing.Point(11, 172)
        Me.btnIncorrectpath.Name = "btnIncorrectpath"
        Me.btnIncorrectpath.Size = New System.Drawing.Size(129, 23)
        Me.btnIncorrectpath.TabIndex = 4
        Me.btnIncorrectpath.Text = "Incorrect CSGO path?"
        Me.btnIncorrectpath.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(269, 365)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 424)
        Me.Controls.Add(Me.tabfrm)
        Me.Name = "frmMain"
        Me.Text = "CSGO AIO Tool"
        Me.tabfrm.ResumeLayout(False)
        Me.tabWelcome.ResumeLayout(False)
        Me.tabWelcome.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabfrm As TabControl
    Friend WithEvents tabWelcome As TabPage
    Friend WithEvents lblWelcome As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents btnBackup As Button
    Friend WithEvents lblCSGOpath As Label
    Friend WithEvents btnIncorrectpath As Button
    Friend WithEvents Button1 As Button
End Class
