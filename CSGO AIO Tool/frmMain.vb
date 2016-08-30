Public Class frmMain
    Dim globalsteampath, globalcsgopath, backupdate As String
    Public globalcrosshair, globalcrossname, currentkey As String
    Dim OSversion As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        globalsteampath = GetSteamFolder()
        GetRefreshRate()
        CreateBackupList()
        OSversion = getOS()

        btnTilde.Text = "`" & vbNewLine & "~"
        btnquote.Text = "'" & vbNewLine & """"
        btncomma.Text = "," & vbNewLine & "<"
        btndot.Text = "." & vbNewLine & ">"
        btnforwardslash.Text = "/" & vbNewLine & "?"

        lblWelcome.Text = "Welcome to CSGO AIO Tool!" & vbLf & "This tool allows you to optimize your computer/game it self for CSGO for a gaming experience." & vbLf & vbLf & "First let's start off by creating a backup of your CSGO files before we make any changes (RECOMMENDED)."
        If globalsteampath IsNot Nothing Then
            txtStatus.AppendText("[+] Steam path found!" & vbNewLine)
            globalcsgopath = globalsteampath & "\steamapps\common\Counter-Strike Global Offensive\csgo"
            If globalcsgopath IsNot Nothing Then
                txtStatus.AppendText("[+] CSGO path found!" & vbNewLine)
                lblCSGOpath.Text = "CSGO PATH: " & vbNewLine & globalcsgopath.ToString
            End If
        End If
        If InputLanguage.CurrentInputLanguage.LayoutName.ToString = "US" Then
            radWASD.Checked = True
        Else
            radZQSD.Checked = True
        End If
    End Sub

    Public Function ApplyTextMod()
        If globalcsgopath IsNot Nothing Then
            If Not IO.File.Exists(globalcsgopath & "\resource\csgo_textmodorel.txt") Then
                IO.File.WriteAllText(globalcsgopath & "\resource\csgo_textmodorel.txt", My.Resources.csgo_textmodorel)
                txtStatus.AppendText("[+] Text mod copied to CSGO's resources folder" & vbNewLine)
            End If
        Else
            txtStatus.AppendText("[-] CSGO path was not found, cannot apply text mod" & vbNewLine)
        End If
        Return vbNullString
    End Function

    Public Function GetRefreshRate() As Integer
        Dim refresh As Integer
        Dim query As New System.Management.SelectQuery("Win32_VideoController")
        For Each obj As System.Management.ManagementObject In New System.Management.ManagementObjectSearcher(query).Get
            Dim CurrentRefreshRate As Object = obj("CurrentRefreshRate")
            If CurrentRefreshRate IsNot Nothing Then
                refresh = CInt(CurrentRefreshRate)
            End If
        Next
        Return refresh
    End Function

    Public Function SetLaunchOptions(ByVal options As String) As String
        'Credits: Peter "rave" Ipsen
        '         Michael "bone" Hansen
        Dim success As Boolean = False
        Dim dirs As String() = IO.Directory.GetDirectories(globalsteampath + "\userdata\")
        For Each dir As String In dirs
            If IO.File.Exists(dir & "\config\localconfig.vdf") Then
                Dim localconfig As List(Of String) = IO.File.ReadAllLines(dir & "\config\localconfig.vdf").ToList()
                For i = 0 To localconfig.Count - 1
                    If localconfig(i) = vbTab & vbTab & vbTab & vbTab & vbTab & """730""" Then
                        For j = i To localconfig.Count - 1
                            If localconfig(j) = vbTab & vbTab & vbTab & vbTab & vbTab & "}" Then
                                Exit For
                            ElseIf localconfig(j).Contains("LaunchOptions") Then
                                localconfig.Remove(localconfig(j))
                            End If
                        Next
                        Dim k As Integer = i + 2
                        localconfig.Insert(k, vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & """LaunchOptions""" & vbTab & """" + options + """")
                        IO.File.WriteAllLines(dir & Convert.ToString("\config\localconfig.vdf"), localconfig)
                        success = True
                    End If
                Next
            End If
        Next
        If success = True Then
            Return String.Format("Launch options: " + options + " succesfully added. " & vbNewLine)
        Else
            Return "ERROR: No launch options found. " & vbNewLine
        End If
    End Function

    Public Function GetCurrentResolution() As String
        Dim TempArray(22) As String
        Dim dirs As String() = IO.Directory.GetDirectories(globalsteampath + "\userdata\")
        For Each dir As String In dirs
            If IO.File.Exists(dir & "\730\local\cfg\video.txt") Then
                Dim videotxt As List(Of String) = IO.File.ReadAllLines(dir & "\730\local\cfg\video.txt").ToList()
                For i = 0 To videotxt.Count - 2
                    TempArray(i) = videotxt(i)
                Next
                Dim x As String = TempArray(17).Remove(0, 24)
                Dim y As String = TempArray(18).Remove(0, 30)
                If x.Contains("""") Then
                    x = x.Replace("""", "")
                End If
                If y.Contains("""") Then
                    y = y.Replace("""", "")
                End If
                Return x & " " & y
            End If
        Next
        Return "NO RES FOUND"
    End Function

    Public Function CreateBackup()
        Dim DateToday As String = String.Format("{0:dd.MM.yyyy - HH.mm}", DateTime.Now)
        backupdate = String.Format("{0:dd.MM.yyyy - HH.mm}", DateTime.Now)
        Dim dirs As String() = IO.Directory.GetDirectories(globalsteampath + "\userdata\")
        If Not IO.Directory.Exists(Application.StartupPath & "\Backups") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\Backups")
            If Not IO.Directory.Exists(Application.StartupPath & "\Backups\" & DateToday) Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\Backups\" & DateToday)
                For Each dir As String In dirs
                    If IO.Directory.Exists(dir & "\730\local\cfg") Then
                        If IO.File.Exists(dir & "\730\local\cfg\config.cfg") Then
                            If Not IO.File.Exists(Application.StartupPath & "\Backups\" & DateToday & "\config.cfg") Then
                                IO.File.Copy(dir & "\730\local\cfg\config.cfg", Application.StartupPath & "\Backups\" & DateToday & "\config.cfg")
                                txtStatus.AppendText("[+] config.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine)
                            End If
                        End If
                        If IO.File.Exists(dir & "\730\local\cfg\video.txt") Then
                            If Not IO.File.Exists(Application.StartupPath & "\Backups\" & DateToday & "\video.txt") Then
                                IO.File.Copy(dir & "\730\local\cfg\video.txt", Application.StartupPath & "\Backups\" & DateToday & "\video.txt")
                                txtStatus.AppendText("[+] video.txt found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine)
                            End If
                        End If
                    End If
                Next
                If IO.File.Exists(globalcsgopath & "\cfg\autoexec.cfg") Then
                    If Not IO.File.Exists(Application.StartupPath & "\Backups\" & DateToday & "\autoexec.cfg") Then
                        IO.File.Copy((globalcsgopath & "\cfg\autoexec.cfg"), Application.StartupPath & "\Backups\" & DateToday & "\autoexec.cfg")
                        txtStatus.AppendText("[+] autoexec.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine)
                    End If
                End If
            End If
        Else
            If Not IO.Directory.Exists(Application.StartupPath & "\Backups\" & DateToday) Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\Backups\" & DateToday)
                For Each dir As String In dirs
                    If IO.Directory.Exists(dir & "\730\local\cfg") Then
                        If IO.File.Exists(dir & "\730\local\cfg\config.cfg") Then
                            If Not IO.File.Exists(Application.StartupPath & "\Backups\" & DateToday & "\config.cfg") Then
                                IO.File.Copy(dir & "\730\local\cfg\config.cfg", Application.StartupPath & "\Backups\" & DateToday & "\config.cfg")
                                txtStatus.AppendText("[+] config.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine)
                            End If
                        End If
                        If IO.File.Exists(dir & "\730\local\cfg\video.txt") Then
                            If Not IO.File.Exists(Application.StartupPath & "\Backups\" & DateToday & "\video.txt") Then
                                IO.File.Copy(dir & "\730\local\cfg\video.txt", Application.StartupPath & "\Backups\" & DateToday & "\video.txt")
                                txtStatus.AppendText("[+] video.txt found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine)
                            End If
                        End If
                    End If
                Next
                If IO.File.Exists(globalcsgopath & "\cfg\autoexec.cfg") Then
                    If Not IO.File.Exists(Application.StartupPath & "\Backups\" & DateToday & "\autoexec.cfg") Then
                        IO.File.Copy((globalcsgopath & "\cfg\autoexec.cfg"), Application.StartupPath & "\Backups\" & DateToday & "\autoexec.cfg")
                        txtStatus.AppendText("[+] autoexec.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine)
                    End If
                End If
            End If
        End If
        CreateBackupList()
    End Function

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Dim DateToday As String = String.Format("{0:dd.MM.yyyy - HH.mm}", DateTime.Now)
        If Not DateToday = backupdate Then
            CreateBackup()
        Else
            txtStatus.AppendText("[-] Wait a minute before creating another backup" & vbNewLine)
        End If
    End Sub

    Private Sub btnIncorrectpath_Click(sender As Object, e As EventArgs) Handles btnIncorrectpath.Click
        txtStatus.AppendText("[+] User attempting to change CSGO path.." & vbNewLine)
        Dim fbd As New FolderBrowserDialog
        With fbd
            .ShowNewFolderButton = False
            .Description = "Show me the way to the STEAM folder containing the steam.exe"
            .RootFolder = Environment.SpecialFolder.MyComputer
            If .ShowDialog = DialogResult.OK Then
                If IO.File.Exists(.SelectedPath().ToString & "\steam.exe") Then
                    globalcsgopath = .SelectedPath().ToString & "\steamapps\common\Counter-Strike Global Offensive\csgo"
                    txtStatus.AppendText("[+] User changed CSGO path to: " & globalcsgopath & vbNewLine)
                    lblCSGOpath.Text = "CSGO PATH: " & vbNewLine & globalcsgopath.ToString
                Else
                    MsgBox("steam.exe not found within given folder, please try again.", MsgBoxStyle.Critical)
                End If
            Else
                txtStatus.AppendText("[-] User canceled the dialog" & vbNewLine)
            End If
        End With
    End Sub

    Public Function CreateBackupList()
        If IO.Directory.Exists(Application.StartupPath & "\Backups") Then
            lstBackups.Items.Clear()
            Dim dirs As String() = IO.Directory.GetDirectories(Application.StartupPath & "\Backups")
            For Each dir As String In dirs
                Dim backup As String = dir
                If backup.Contains(Application.StartupPath & "\Backups\") Then
                    backup = backup.Replace(Application.StartupPath & "\Backups\", "")
                End If
                lstBackups.Items.Add(backup)
            Next
        End If
    End Function

    Private Sub btnRestoreBackup_Click(sender As Object, e As EventArgs) Handles btnRestoreBackup.Click
        If Not lstBackups.SelectedIndex = -1 Then
            If IO.Directory.Exists(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem()) Then
                Dim dirs As String() = IO.Directory.GetDirectories(globalsteampath + "\userdata\")
                If IO.File.Exists(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem() & "\config.cfg") Then
                    For Each dir As String In dirs
                        If IO.Directory.Exists(dir & "\730\local\cfg") Then
                            IO.File.Copy(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem() & "\config.cfg", dir & "\730\local\cfg" & "\config.cfg", True)
                            txtStatus.AppendText("[+] config.cfg restored from backup '" & lstBackups.SelectedItem & "'" & vbNewLine)
                        End If
                    Next
                End If
                If IO.File.Exists(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem() & "\video.txt") Then
                    For Each dir As String In dirs
                        If IO.Directory.Exists(dir & "\730\local\cfg") Then
                            IO.File.Copy(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem() & "\video.txt", dir & "\730\local\cfg" & "\video.txt", True)
                            txtStatus.AppendText("[+] video.txt restored from backup '" & lstBackups.SelectedItem & "'" & vbNewLine)
                        End If
                    Next
                End If
                If IO.File.Exists(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem() & "\autoexec.cfg") Then
                    If IO.Directory.Exists(globalcsgopath & "\cfg") Then
                        IO.File.Copy(Application.StartupPath & "\Backups\" & lstBackups.SelectedItem() & "\autoexec.cfg", globalcsgopath & "\cfg" & "\video.txt", True)
                        txtStatus.AppendText("[+] autoexec.cfg restored from backup '" & lstBackups.SelectedItem & "'" & vbNewLine)
                    End If
                End If
            End If
        Else
            txtStatus.AppendText("[-] Select a backup you wish to restore from the list" & vbNewLine)
        End If
    End Sub

    Private Sub btnESC_Click(sender As Object, e As EventArgs) Handles btnESC.Click
        currentkey = "ESCAPE"
        frmBinding.Show()
    End Sub

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        currentkey = "F1"
        frmBinding.Show()
    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        currentkey = "F2"
        frmBinding.Show()
    End Sub

    Private Sub btnF3_Click(sender As Object, e As EventArgs) Handles btnF3.Click
        currentkey = "F3"
        frmBinding.Show()
    End Sub

    Private Sub btnF4_Click(sender As Object, e As EventArgs) Handles btnF4.Click
        currentkey = "F4"
        frmBinding.Show()
    End Sub

    Private Sub btnF5_Click(sender As Object, e As EventArgs) Handles btnF5.Click
        currentkey = "F5"
        frmBinding.Show()
    End Sub

    Private Sub btnF6_Click(sender As Object, e As EventArgs) Handles btnF6.Click
        currentkey = "F6"
        frmBinding.Show()
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        currentkey = "F7"
        frmBinding.Show()
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click
        currentkey = "F8"
        frmBinding.Show()
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        currentkey = "F9"
        frmBinding.Show()
    End Sub

    Private Sub btnF10_Click(sender As Object, e As EventArgs) Handles btnF10.Click
        currentkey = "F10"
        frmBinding.Show()
    End Sub

    Private Sub btnF11_Click(sender As Object, e As EventArgs) Handles btnF11.Click
        currentkey = "F11"
        frmBinding.Show()
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        currentkey = "F12"
        frmBinding.Show()
    End Sub

    Private Sub btnTilde_Click(sender As Object, e As EventArgs) Handles btnTilde.Click
        currentkey = "`"
        frmBinding.Show()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        currentkey = "1"
        frmBinding.Show()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        currentkey = "2"
        frmBinding.Show()
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        currentkey = "3"
        frmBinding.Show()
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        currentkey = "4"
        frmBinding.Show()
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        currentkey = "5"
        frmBinding.Show()
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        currentkey = "6"
        frmBinding.Show()
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        currentkey = "7"
        frmBinding.Show()
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        currentkey = "8"
        frmBinding.Show()
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        currentkey = "9"
        frmBinding.Show()
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        currentkey = "0"
        frmBinding.Show()
    End Sub

    Private Sub btnmin_Click(sender As Object, e As EventArgs) Handles btnmin.Click
        currentkey = "-"
        frmBinding.Show()
    End Sub

    Private Sub btnequals_Click(sender As Object, e As EventArgs) Handles btnequals.Click
        currentkey = "="
        frmBinding.Show()
    End Sub

    Private Sub btnBackspace_Click(sender As Object, e As EventArgs) Handles btnBackspace.Click
        currentkey = "backspace"
        frmBinding.Show()
    End Sub

    Private Sub btnTab_Click(sender As Object, e As EventArgs) Handles btnTab.Click
        currentkey = "TAB"
        frmBinding.Show()
    End Sub

    Private Sub btnq_Click(sender As Object, e As EventArgs) Handles btnq.Click
        If radZQSD.Checked = True Then
            MsgBox("RESERVED FOR MOVEMENT")
        Else
            currentkey = "q"
            frmBinding.Show()
        End If
    End Sub

    Private Sub btnw_Click(sender As Object, e As EventArgs) Handles btnw.Click
        If radWASD.Checked = True Then
            MsgBox("RESERVED FOR MOVEMENT")
        Else
            currentkey = "w"
            frmBinding.Show()
        End If
    End Sub

    Private Sub btne_Click(sender As Object, e As EventArgs) Handles btne.Click
        currentkey = "e"
        frmBinding.Show()
    End Sub

    Private Sub btnr_Click(sender As Object, e As EventArgs) Handles btnr.Click
        currentkey = "r"
        frmBinding.Show()
    End Sub

    Private Sub btnt_Click(sender As Object, e As EventArgs) Handles btnt.Click
        currentkey = "t"
        frmBinding.Show()
    End Sub

    Private Sub btny_Click(sender As Object, e As EventArgs) Handles btny.Click
        currentkey = "y"
        frmBinding.Show()
    End Sub

    Private Sub btnu_Click(sender As Object, e As EventArgs) Handles btnu.Click
        currentkey = "u"
        frmBinding.Show()
    End Sub

    Private Sub btni_Click(sender As Object, e As EventArgs) Handles btni.Click
        currentkey = "i"
        frmBinding.Show()
    End Sub

    Private Sub btno_Click(sender As Object, e As EventArgs) Handles btno.Click
        currentkey = "o"
        frmBinding.Show()
    End Sub

    Private Sub btnp_Click(sender As Object, e As EventArgs) Handles btnp.Click
        currentkey = "p"
        frmBinding.Show()
    End Sub

    Private Sub btnbropen_Click(sender As Object, e As EventArgs) Handles btnbropen.Click
        currentkey = "["
        frmBinding.Show()
    End Sub

    Private Sub btnbrclosed_Click(sender As Object, e As EventArgs) Handles btnbrclosed.Click
        currentkey = "]"
        frmBinding.Show()
    End Sub
    Private Sub btnbackslash_Click(sender As Object, e As EventArgs) Handles btnbackslash.Click
        currentkey = "\"
        frmBinding.Show()
    End Sub

    Private Sub btna_Click(sender As Object, e As EventArgs) Handles btna.Click
        If radWASD.Checked = True Then
            MsgBox("RESERVED FOR MOVEMENT")
        Else
            currentkey = "a"
            frmBinding.Show()
        End If
    End Sub

    Private Sub btnCaps_Click(sender As Object, e As EventArgs) Handles btnCaps.Click
        currentkey = "capslock"
        frmBinding.Show()
    End Sub

    Private Sub btns_Click(sender As Object, e As EventArgs) Handles btns.Click
        MsgBox("RESERVED FOR MOVEMENT")
    End Sub

    Private Sub btnd_Click(sender As Object, e As EventArgs) Handles btnd.Click
        MsgBox("RESERVED FOR MOVEMENT")
    End Sub

    Private Sub btnf_Click(sender As Object, e As EventArgs) Handles btnf.Click
        currentkey = "f"
        frmBinding.Show()
    End Sub

    Private Sub btng_Click(sender As Object, e As EventArgs) Handles btng.Click
        currentkey = "g"
        frmBinding.Show()
    End Sub

    Private Sub btnh_Click(sender As Object, e As EventArgs) Handles btnh.Click
        currentkey = "h"
        frmBinding.Show()
    End Sub

    Private Sub btnj_Click(sender As Object, e As EventArgs) Handles btnj.Click
        currentkey = "j"
        frmBinding.Show()
    End Sub

    Private Sub btnk_Click(sender As Object, e As EventArgs) Handles btnk.Click
        currentkey = "k"
        frmBinding.Show()
    End Sub

    Private Sub btnl_Click(sender As Object, e As EventArgs) Handles btnl.Click
        currentkey = "l"
        frmBinding.Show()
    End Sub

    Private Sub btnquote_Click(sender As Object, e As EventArgs) Handles btnquote.Click
        currentkey = "'"
        frmBinding.Show()
    End Sub

    Private Sub btnenter_Click(sender As Object, e As EventArgs) Handles btnenter.Click
        currentkey = "enter"
        frmBinding.Show()
    End Sub

    Private Sub btnrshift_Click(sender As Object, e As EventArgs) Handles btnrshift.Click
        currentkey = "rshift"
        frmBinding.Show()
    End Sub

    Private Sub btnshift_Click(sender As Object, e As EventArgs) Handles btnshift.Click
        currentkey = "shift"
        frmBinding.Show()
    End Sub

    Private Sub btnz_Click(sender As Object, e As EventArgs) Handles btnz.Click
        If radZQSD.Checked = True Then
            MsgBox("RESERVED FOR MOVEMENT")
        Else
            currentkey = "z"
            frmBinding.Show()
        End If
    End Sub

    Private Sub btnx_Click(sender As Object, e As EventArgs) Handles btnx.Click
        currentkey = "x"
        frmBinding.Show()
    End Sub

    Private Sub btnc_Click(sender As Object, e As EventArgs) Handles btnc.Click
        currentkey = "c"
        frmBinding.Show()
    End Sub

    Private Sub btnv_Click(sender As Object, e As EventArgs) Handles btnv.Click
        currentkey = "v"
        frmBinding.Show()
    End Sub

    Private Sub btnb_Click(sender As Object, e As EventArgs) Handles btnb.Click
        currentkey = "b"
        frmBinding.Show()
    End Sub

    Private Sub btnn_Click(sender As Object, e As EventArgs) Handles btnn.Click
        currentkey = "n"
        frmBinding.Show()
    End Sub

    Private Sub btnm_Click(sender As Object, e As EventArgs) Handles btnm.Click
        currentkey = "m"
        frmBinding.Show()
    End Sub

    Private Sub btncomma_Click(sender As Object, e As EventArgs) Handles btncomma.Click
        currentkey = ","
        frmBinding.Show()
    End Sub

    Private Sub btndot_Click(sender As Object, e As EventArgs) Handles btndot.Click
        currentkey = "."
        frmBinding.Show()
    End Sub

    Private Sub btnforwardslash_Click(sender As Object, e As EventArgs) Handles btnforwardslash.Click
        currentkey = "/"
        frmBinding.Show()
    End Sub

    Private Sub btnCTRL_Click(sender As Object, e As EventArgs) Handles btnCTRL.Click
        currentkey = "CTRL"
        frmBinding.Show()
    End Sub

    Private Sub btnALT_Click(sender As Object, e As EventArgs) Handles btnALT.Click
        currentkey = "ALT"
        frmBinding.Show()
    End Sub

    Private Sub btnspace_Click(sender As Object, e As EventArgs) Handles btnspace.Click
        currentkey = "SPACE"
        frmBinding.Show()
    End Sub

    Private Sub btnrALT_Click(sender As Object, e As EventArgs) Handles btnrALT.Click
        currentkey = "RALT"
        frmBinding.Show()
    End Sub

    Private Sub btnrCTRL_Click(sender As Object, e As EventArgs) Handles btnrCTRL.Click
        currentkey = "RCTRL"
        frmBinding.Show()
    End Sub

    Private Sub radWASD_CheckedChanged(sender As Object, e As EventArgs) Handles radWASD.CheckedChanged
        If radWASD.Checked = True Then
            btnw.Location = New Point(318, 132)
            btna.Location = New Point(287, 184)
            btnz.Location = New Point(322, 237)
            btnq.Location = New Point(265, 132)
        Else
            btnw.Location = New Point(322, 238)
            btna.Location = New Point(265, 132)
            btnz.Location = New Point(318, 132)
            btnq.Location = New Point(285, 184)
        End If
    End Sub

    Public Function getOS() As Integer
        If My.Computer.Info.OSFullName.Contains("10") Then
            Return 10
        ElseIf My.Computer.Info.OSFullName.Contains("8") Then
            Return 8
        ElseIf My.Computer.Info.OSFullName.Contains("7") Then
            Return 7
        End If
        Return 0
    End Function

    Private Sub btnCrosshairselector_Click(sender As Object, e As EventArgs)
        Crosshair_selector.Show()
    End Sub

    Public Function GetSteamFolder() As String
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", Nothing) IsNot Nothing Then
            Dim steampath As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", Nothing)
            Return steampath
        Else
            If MsgBox("There was an error reading your steam installation path." & vbLf & "Would you like to set your steam installation path manually?", MsgBoxStyle.YesNo, "Error fetching steam installation path from registry") = MsgBoxResult.Yes Then
                Dim steampath As String
                Dim fbd As New FolderBrowserDialog
                With fbd
                    .ShowNewFolderButton = False
                    .Description = "Show me the way to your steam installation path"
                    .RootFolder = Environment.SpecialFolder.MyComputer
                    If .ShowDialog = DialogResult.OK Then
                        steampath = .SelectedPath().ToString
                        Return steampath
                    End If
                End With
            Else
                MsgBox("Closing program..")
                Application.Exit()
            End If
        End If
        Return "Something went completely wrong here.."
    End Function

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class
