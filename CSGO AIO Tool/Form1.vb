Public Class Form1
    Dim globalsteampath, globalcsgopath As String
    Public globalcrosshair As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        globalsteampath = GetSteamFolder()
        If globalsteampath IsNot Nothing Then
            globalcsgopath = globalsteampath & "\steamapps\common\Counter-Strike Global Offensive\csgo"
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
            Return String.Format("Launch options:" + options + " succesfully added. " & vbLf)
        Else
            Return "ERROR: No launch options found. " & vbLf
        End If
    End Function
    Public Function GetSteamFolder() As String
        If Not My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", Nothing) Is Nothing Then
            Dim steampath As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", Nothing)
            Return steampath
        Else
            If MsgBox("There was an error reading your steam installation path." & vbLf & "Would you like to set your steam installation path manually?", MsgBoxStyle.YesNo, "Error fetching steam installation path from registry") = MsgBoxResult.Yes Then
                Dim steampath As String
                Dim fbd As New FolderBrowserDialog
                Using fbd
                    fbd.Description = "Show me the way to your steam installation path"
                    fbd.RootFolder = Environment.SpecialFolder.MyComputer
                    If fbd.ShowDialog = DialogResult.OK Then
                        steampath = fbd.SelectedPath().ToString
                        Return steampath
                    End If
                End Using
            Else
                MsgBox("Closing program..")
                Application.Exit()
            End If
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Crosshair_selector.Show()
    End Sub
End Class
