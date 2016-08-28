Public Class frmMain
    Dim globalsteampath, globalcsgopath As String
    Public globalcrosshair, globalcrossname As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome to CSGO AIO Tool!" & vbLf & "This tool allows you to optimize your computer/game it self for CSGO for a gaming experience." & vbLf & vbLf & "First let's start off by creating a backup of your CSGO files before we make any changes (RECOMMENDED)."
        globalsteampath = GetSteamFolder()

        If globalsteampath IsNot Nothing Then
            txtStatus.Text &= "[+] Steam path found!" & vbNewLine
            globalcsgopath = globalsteampath & "\steamapps\common\Counter-Strike Global Offensive\csgo"
            If globalcsgopath IsNot Nothing Then
                txtStatus.Text &= "[+] CSGO path found!" & vbNewLine
                lblCSGOpath.Text = "CSGO PATH: " & vbNewLine & globalcsgopath.ToString
            End If
        End If
    End Sub
    Public Function SetLaunchOptions(ByVal options As String) As String
        'Credits: Peter "rave" Ipsen
        '         Michael "bone" Hansen
        Dim success As Boolean = False
        Dim dirs As String() = IO.Directory.GetDirectories(globalsteampath + "\userdata\")
        For Each dir As String In dirs
            If IO.File.Exists(dir & Convert.ToString("\config\localconfig.vdf")) Then
                Dim localconfig As List(Of String) = IO.File.ReadAllLines(dir & Convert.ToString("\config\localconfig.vdf")).ToList()
                For i As Integer = 0 To localconfig.Count() - 1
                    If localconfig(i) = vbTab & vbTab & vbTab & vbTab & vbTab & """730""" Then
                        For j As Integer = i To localconfig.Count() - 1
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
    Public Function CreateBackup()
        Dim DateToday As String = String.Format("{0:dd.MM.yyyy - h.mm}", DateTime.Now)
        Dim dirs As String() = IO.Directory.GetDirectories(globalsteampath + "\userdata\")
        If Not IO.Directory.Exists(Application.StartupPath & "\Backups") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\Backups")
            If Not IO.Directory.Exists(Application.StartupPath & "\Backups\" & DateToday) Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\Backups\" & DateToday)

                For Each dir As String In dirs
                    If IO.Directory.Exists(dir & "\730\local\cfg") Then
                        If IO.File.Exists(dir & "\730\local\cfg\config.cfg") Then
                            IO.File.Copy(dir & "\730\local\cfg\config.cfg", Application.StartupPath & "\Backups\" & DateToday & "\config.cfg")
                            txtStatus.Text &= "[+] config.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine
                        End If
                        If IO.File.Exists(dir & "\730\local\cfg\video.txt") Then
                            IO.File.Copy(dir & "\730\local\cfg\video.txt", Application.StartupPath & "\Backups\" & DateToday & "\video.txt")
                            txtStatus.Text &= "[+] video.txt found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine
                        End If
                    End If
                Next

                If IO.File.Exists(globalcsgopath & "\cfg\autoexec.cfg") Then
                    IO.File.Copy((globalcsgopath & "\cfg\autoexec.cfg"), Application.StartupPath & "\Backups\" & DateToday & "\autoexec.cfg")
                    txtStatus.Text &= "[+] autoexec.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine
                End If
            End If
        Else
            If Not IO.Directory.Exists(Application.StartupPath & "\Backups\" & DateToday) Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\Backups\" & DateToday)

                For Each dir As String In dirs
                    If IO.Directory.Exists(dir & "\730\local\cfg") Then
                        If IO.File.Exists(dir & "\730\local\cfg\config.cfg") Then
                            IO.File.Copy(dir & "\730\local\cfg\config.cfg", Application.StartupPath & "\Backups\" & DateToday & "\config.cfg")
                            txtStatus.Text &= "[+] config.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine
                        End If
                        If IO.File.Exists(dir & "\730\local\cfg\video.txt") Then
                            IO.File.Copy(dir & "\730\local\cfg\video.txt", Application.StartupPath & "\Backups\" & DateToday & "\video.txt")
                            txtStatus.Text &= "[+] video.txt found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine
                        End If
                    End If
                Next

                If IO.File.Exists(globalcsgopath & "\cfg\autoexec.cfg") Then
                    IO.File.Copy((globalcsgopath & "\cfg\autoexec.cfg"), Application.StartupPath & "\Backups\" & DateToday & "\autoexec.cfg")
                    txtStatus.Text &= "[+] autoexec.cfg found and copied to: " & Application.StartupPath & "\Backups\" & DateToday & vbNewLine
                End If
            End If
        End If
    End Function

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        CreateBackup()
    End Sub

    Private Sub btnIncorrectpath_Click(sender As Object, e As EventArgs) Handles btnIncorrectpath.Click
        txtStatus.Text &= "[+] User attempting to change CSGO path.." & vbNewLine
        Dim fbd As New FolderBrowserDialog
        With fbd
            .ShowNewFolderButton = False
            .Description = "Show me the way to the STEAM folder containing the steam.exe"
            .RootFolder = Environment.SpecialFolder.MyComputer
            If .ShowDialog = DialogResult.OK Then
                If IO.File.Exists(.SelectedPath().ToString & "\steam.exe") Then
                    globalcsgopath = .SelectedPath().ToString & "\steamapps\common\Counter-Strike Global Offensive\csgo"
                    txtStatus.Text &= "[+] User changed CSGO path to: " & globalcsgopath & vbNewLine
                    lblCSGOpath.Text = "CSGO PATH: " & vbNewLine & globalcsgopath.ToString
                Else
                    MsgBox("steam.exe not found within given folder, please try again.", MsgBoxStyle.Critical)
                End If
            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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
