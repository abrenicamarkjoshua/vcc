Imports MySql.Data.MySqlClient
Imports System.Speech.Recognition

Public Class frmMonitoring
    Private list_monitors As List(Of screenmonitor)

    Private Sub frmMonitoring_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'frmMenu.checknetwork()

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub load_monitors()

    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadMonitor.Start()

                Try
                    rec.LoadGrammar(grammarmonitor)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarmonitor)
                    rec.UnloadGrammar(grammarspecial)
                Catch : End Try

                Try
                    For Each mymonitor As screenmonitor In MonitorPanel.Controls
                        mymonitor.stopoperation()
                    Next
                Catch : End Try

                If nextform = "Menu" Then
                    frmMenu.isActivate = True
                    frmMenu.Show()
                ElseIf nextform = "Speech" Then
                    Try
                        frmSpeechRecognition.rec.RecognizeAsync(1)
                    Catch : End Try
                End If

                Me.Close()
            End If
        End If
    End Sub

    Public nextform As String

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        For Each mymonitor As screenmonitor In MonitorPanel.Controls
            mymonitor.stopoperation()
        Next

        FullScreen.Stop()
        LoadMonitor.Stop()

        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarmonitor)
        Catch : End Try
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.ForeColor = Color.White
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.ForeColor = Color.LawnGreen
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Dim compcount As Integer = 0
    Dim wordcall() As String
    Dim computername() As String
    Dim ipaddress() As String
    Dim imageport() As String
    Public computerdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public conpip As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private Sub LoadMonitor_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMonitor.Tick
        LoadMonitor.Stop()

        sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
        Dim selcomp As New MySqlCommand(sql, con)
        selcomp.Parameters.AddWithValue("?name", My.Computer.Name)
        selcomp.Parameters.AddWithValue("?ip", v4())
        da = New MySqlDataAdapter(selcomp)
        da.Fill(ds, "computermonitor")

        Dim leftmargin As Integer = 0
        Dim topmargin As Integer = 0

        If ds.Tables("computermonitor").Rows.Count > 0 Then
            If Not ds.Tables("computermonitor").Rows.Count = compcount Then
                For Each monitors As screenmonitor In MonitorPanel.Controls
                    MonitorPanel.Controls.Remove(monitors)
                Next

                compcount = 0

                Dim computerschoice As New Choices()
                computerdic = New Dictionary(Of String, String)
                conpip = New Dictionary(Of String, String)

                For i As Integer = 0 To ds.Tables("computermonitor").Rows.Count - 1
                    topmargin = ((i \ 3) * 223) + (i \ 3) * 5
                    leftmargin = (((i Mod 3)) * 300) + (i Mod 3) * 5

                    Dim monitor As screenmonitor = New screenmonitor(ds.Tables("computermonitor").Rows(i).Item("ipaddress").ToString, ds.Tables("computermonitor").Rows(i).Item("imageport").ToString, ds.Tables("computermonitor").Rows(i).Item("computername").ToString, ds.Tables("computermonitor").Rows(i).Item("wordcall").ToString)
                    monitor.Left = leftmargin
                    monitor.Top = topmargin
                    monitor.Width = 300
                    monitor.Tag = i
                    monitor.Name = "monitor" & i.ToString
                    monitor.Height = 200 + 23
                    monitor.BackgroundImageLayout = ImageLayout.Stretch
                    monitor.BackColor = Color.Black
                    'monitor.BackgroundImage = My.Resources.advanceSettings

                    'topmargin = topmargin + 50 + 10 + 323
                    monitor.Visible = True

                    Try
                        monitor.invokethread()
                    Catch ex As Exception
                    End Try

                    AddHandler monitor.mypicturebox.Click, AddressOf ScreenBoxClick

                    MonitorPanel.Controls.Add(monitor)

                    compcount = compcount + 1

                    Try
                        computerschoice.Add(ds.Tables("computermonitor").Rows(i).Item("wordcall").ToString)
                        computerdic.Add(ds.Tables("computermonitor").Rows(i).Item("wordcall").ToString, ds.Tables("computermonitor").Rows(i).Item("computername").ToString)
                        conpip.Add(ds.Tables("computermonitor").Rows(i).Item("wordcall").ToString, ds.Tables("computermonitor").Rows(i).Item("ipaddress").ToString)
                    Catch : End Try

                    'leftmargin = leftmargin + 300 + 5
                Next

                Try
                    rec.UnloadGrammar(grammarspecial)
                Catch : End Try

                gr = New GrammarBuilder

                gr.Append(computerschoice)

                grammarspecial = New Grammar(gr)

                Try
                    rec.LoadGrammar(grammarspecial)
                Catch : End Try
            Else
                Dim computerschoice As New Choices()

                For a = 0 To ds.Tables("computermonitor").Rows.Count - 1
                    For Each mymonitor As screenmonitor In MonitorPanel.Controls
                        If mymonitor.mylabel.Tag = ds.Tables("computermonitor").Rows(a).Item("computername").ToString & "|" & ds.Tables("computermonitor").Rows(a).Item("ipaddress").ToString Then
                            If Not mymonitor.mylabel.Text = ds.Tables("computermonitor").Rows(a).Item("wordcall").ToString Then
                                mymonitor.mylabel.Text = ds.Tables("computermonitor").Rows(a).Item("wordcall").ToString

                                Try
                                    computerschoice.Add(ds.Tables("computermonitor").Rows(a).Item("wordcall").ToString)
                                    computerdic.Add(ds.Tables("computermonitor").Rows(a).Item("wordcall").ToString, ds.Tables("computermonitor").Rows(a).Item("computername").ToString)
                                    conpip.Add(ds.Tables("computermonitor").Rows(a).Item("wordcall").ToString, ds.Tables("computermonitor").Rows(a).Item("ipaddress").ToString)
                                Catch : End Try

                                Try
                                    rec.UnloadGrammar(grammarspecial)
                                Catch : End Try

                                gr = New GrammarBuilder

                                gr.Append(computerschoice)

                                grammarspecial = New Grammar(gr)
                                Try
                                    rec.LoadGrammar(grammarspecial)
                                Catch : End Try

                                Exit For
                            End If
                        End If
                    Next
                Next
            End If

            ds.Tables("computermonitor").Clear()
        Else
            Try
                rec.UnloadGrammar(grammarspecial)
            Catch : End Try

            For Each monitors As screenmonitor In MonitorPanel.Controls
                MonitorPanel.Controls.Remove(monitors)
            Next
        End If
    End Sub

    Private gr As New GrammarBuilder
    Dim grammarspecial As Grammar

    Sub LoadSpecial()

    End Sub

    Dim isFullScreen As Boolean = False

    Public selectedcomputername, selectedipaddress, selectedwordcall As String
    Public selectedcount As Integer

    Private Sub ScreenBoxClick(ByVal sender As Object, ByVal e As EventArgs)
        If isFullScreen = False Then
            Dim monitor As PictureBox = DirectCast(sender, PictureBox)

            MonitorPanel.AutoScroll = False

            Dim screeninfo() As String = monitor.Tag.ToString.Split("|")

            monitor.Parent.Width = MonitorPanel.Width
            monitor.Parent.Height = MonitorPanel.Height
            monitor.Width = MonitorPanel.Width
            monitor.Height = MonitorPanel.Height
            monitor.Parent.Left = 0
            monitor.Parent.Top = 0

            monitor.Parent.BringToFront()

            selectedcomputername = screeninfo(1)
            selectedipaddress = screeninfo(2)
            selectedwordcall = screeninfo(0)
            selectedcount = monitor.Parent.Tag

            lblSelected.Text = selectedcomputername & " (" & selectedipaddress & ")"

            lblScreen.Text = lblSelected.Text

            isFullScreen = True

            ShowCommands()
            HideAll()
        Else
            For Each monitor As screenmonitor In MonitorPanel.Controls
                If LCase(monitor.mylabel.Text) = LCase(selectedwordcall) Then
                    monitor.Width = 300
                    monitor.Height = 200 + monitor.mylabel.Height
                    monitor.Left = (((selectedcount Mod 3)) * 300) + (selectedcount Mod 3) * 5
                    monitor.Top = ((selectedcount \ 3) * 223) + (selectedcount \ 3) * 5
                    monitor.mypicturebox.Width = 300
                    monitor.mypicturebox.Height = 200
                    monitor.mypicturebox.Top = monitor.mylabel.Height

                    MonitorPanel.AutoScroll = True
                    isFullScreen = False

                    selectedcomputername = ""
                    selectedipaddress = ""
                    selectedwordcall = ""
                    selectedcount = 0
                    lblSelected.Text = ""

                    HideCommands()
                    ShowAll()
                End If
            Next
        End If
    End Sub

    Private Sub FullScreenPanel_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FullScreenPanel.VisibleChanged
        If FullScreenPanel.Visible = True Then
            ShowCommands()
            HideAll()
        Else
            HideCommands()
            ShowAll()
        End If
    End Sub

    Sub ShowCommands()
        lblRestart.Visible = True
        lblShutdown.Visible = True
        lblLock.Visible = True
        lblUnlock.Visible = True
        lblLogout.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True
    End Sub

    Sub HideCommands()
        lblRestart.Visible = False
        lblShutdown.Visible = False
        lblLock.Visible = False
        lblUnlock.Visible = False
        lblLogout.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
    End Sub

    Sub ShowAll()
        lblAllRestart.Visible = True
        lblAllShutdown.Visible = True
        lblAllLock.Visible = True
        lblAllUnlock.Visible = True
        lblAllLogout.Visible = True
        Label11.Visible = True
        Label10.Visible = True
        Label9.Visible = True
        Label8.Visible = True
    End Sub

    Sub HideAll()
        lblAllRestart.Visible = False
        lblAllShutdown.Visible = False
        lblAllLock.Visible = False
        lblAllUnlock.Visible = False
        lblAllLogout.Visible = False
        Label11.Visible = False
        Label10.Visible = False
        Label9.Visible = False
        Label8.Visible = False
    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            For Each mymonitor As screenmonitor In MonitorPanel.Controls
                mymonitor.stopoperation()
            Next

            LoadMonitor.Stop()

            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarmonitor)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "back" Then
            If isFullScreen = True Then
                For Each monitor As screenmonitor In MonitorPanel.Controls
                    If LCase(monitor.mylabel.Text) = LCase(selectedwordcall) Then
                        monitor.Width = 300
                        monitor.Height = 200 + monitor.mylabel.Height
                        monitor.Left = (((selectedcount Mod 3)) * 300) + (selectedcount Mod 3) * 5
                        monitor.Top = ((selectedcount \ 3) * 223) + (selectedcount \ 3) * 5
                        monitor.mypicturebox.Width = 300
                        monitor.mypicturebox.Height = 200
                        monitor.mypicturebox.Top = monitor.mylabel.Height

                        MonitorPanel.AutoScroll = True
                        isFullScreen = False

                        selectedcomputername = ""
                        selectedipaddress = ""
                        selectedwordcall = ""
                        selectedcount = 0
                        lblSelected.Text = ""

                        HideCommands()
                        ShowAll()
                    End If
                Next
            End If
        ElseIf e.Result.Text = "lock-unit" Then
            If isFullScreen = True Then
                message = "Locking Unit"

                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", selectedcomputername)
                addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
                addcomm.Parameters.AddWithValue("?command", "lock")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If
        ElseIf e.Result.Text = "unlock-unit" Then
            If isFullScreen = True Then
                message = "Unlocking Unit"

                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", selectedcomputername)
                addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
                addcomm.Parameters.AddWithValue("?command", "unlock")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If
        ElseIf e.Result.Text = "restart-unit" Then
            If isFullScreen = True Then
                message = "Restarting Unit"

                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", selectedcomputername)
                addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
                addcomm.Parameters.AddWithValue("?command", "restart")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If
        ElseIf e.Result.Text = "shutdown-unit" Then
            If isFullScreen = True Then
                message = "Shutting Down Unit"

                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", selectedcomputername)
                addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
                addcomm.Parameters.AddWithValue("?command", "shutdown")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If
        ElseIf e.Result.Text = "all-restart-unit" Then
            If isFullScreen = False Then
                isVoice = True

                RestartAll()
            End If
        ElseIf e.Result.Text = "all-shutdown-unit" Then
            If isFullScreen = False Then
                isVoice = True

                ShutdownAll()
            End If
        ElseIf e.Result.Text = "all-lock-unit" Then
            If isFullScreen = False Then
                isVoice = True

                LockAll()
            End If
        ElseIf e.Result.Text = "all-unlock-unit" Then
            If isFullScreen = False Then
                isVoice = True

                UnlockAll()
            End If
        ElseIf e.Result.Text = "all-logout-student" Or e.Result.Text = "all-logout-students" Then
            If isFullScreen = False Then
                isVoice = True

                LogoutAll()
            End If
        Else
            For Each monitors As screenmonitor In MonitorPanel.Controls
                If LCase(monitors.mylabel.Text) = LCase(e.Result.Text) Then

                    MonitorPanel.AutoScroll = False

                    Dim screeninfo() As String = monitors.mypicturebox.Tag.ToString.Split("|")

                    monitors.mypicturebox.Parent.Width = MonitorPanel.Width
                    monitors.mypicturebox.Parent.Height = MonitorPanel.Height
                    monitors.mypicturebox.Width = MonitorPanel.Width
                    monitors.mypicturebox.Height = MonitorPanel.Height
                    monitors.mypicturebox.Parent.Left = 0
                    monitors.mypicturebox.Parent.Top = 0

                    monitors.mypicturebox.Parent.BringToFront()

                    selectedcomputername = screeninfo(1)
                    selectedipaddress = screeninfo(2)
                    selectedwordcall = screeninfo(0)
                    selectedcount = monitors.mypicturebox.Parent.Tag

                    lblSelected.Text = selectedcomputername & " (" & selectedipaddress & ")"

                    lblScreen.Text = lblSelected.Text

                    isFullScreen = True

                    ShowCommands()
                    HideAll()
                End If
            Next
        End If
    End Sub

    Private Sub lblRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRestart.Click
        If selectedcomputername = "" Then
            message = "Please select a computer that you watn to Restart"
            MsgBox("Please select a computer that you want to Restart", MsgBoxStyle.Information, "Restart Unit")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to Restart " & selectedcomputername & "(" & selectedipaddress & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Restart Unit") = MsgBoxResult.Yes Then
            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", selectedcomputername)
            addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
            addcomm.Parameters.AddWithValue("?command", "restart")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "Restarting " & selectedcomputername
        End If
    End Sub

    Private Sub lblRestart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRestart.MouseLeave
        lblRestart.ForeColor = Color.White
        lblRestart.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblRestart_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblRestart.MouseMove
        lblRestart.ForeColor = Color.LawnGreen
        lblRestart.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShutdown.Click
        If selectedcomputername = "" Then
            message = "Please select a computer that you watn to Shutdown"
            MsgBox("Please select a computer that you want to Shutdown", MsgBoxStyle.Information, "Shutdown Unit")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to Shutdown " & selectedcomputername & "(" & selectedipaddress & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Shutdown Unit") = MsgBoxResult.Yes Then
            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", selectedcomputername)
            addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
            addcomm.Parameters.AddWithValue("?command", "shutdown")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "Shutting Down " & selectedcomputername
        End If
    End Sub

    Private Sub lblShutdown_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShutdown.MouseLeave
        lblShutdown.ForeColor = Color.White
        lblShutdown.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblShutdown_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShutdown.MouseMove
        lblShutdown.ForeColor = Color.LawnGreen
        lblShutdown.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLock.Click
        If selectedcomputername = "" Then
            message = "Please select a computer that you want to Lock"
            MsgBox("Please select a computer that you want to Lock", MsgBoxStyle.Information, "Lock Unit")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to Lock " & selectedcomputername & "(" & selectedipaddress & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Lock Unit") = MsgBoxResult.Yes Then
            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", selectedcomputername)
            addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
            addcomm.Parameters.AddWithValue("?command", "lock")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "Locking " & selectedcomputername
        End If
    End Sub

    Private Sub lblUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUnlock.Click
        If selectedcomputername = "" Then
            message = "Please select a computer that you want to Unlock"
            MsgBox("Please select a computer that you want to Unlock", MsgBoxStyle.Information, "Unlock Unit")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to Unlock " & selectedcomputername & "(" & selectedipaddress & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Unlock Unit") = MsgBoxResult.Yes Then
            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", selectedcomputername)
            addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
            addcomm.Parameters.AddWithValue("?command", "unlock")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "Unlocking " & selectedcomputername
        End If
    End Sub

    Private Sub lblLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogout.Click
        If selectedcomputername = "" Then
            message = "Please select a computer that you want to Logout Student"
            MsgBox("Please select a computer that you want to Logout Student", MsgBoxStyle.Information, "Force Logout")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to Force Logout the Student on " & selectedcomputername & "(" & selectedipaddress & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Force Logout") = MsgBoxResult.Yes Then
            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", selectedcomputername)
            addcomm.Parameters.AddWithValue("?ip", selectedipaddress)
            addcomm.Parameters.AddWithValue("?command", "log-out")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "Logging Out Student on " & selectedcomputername
        End If
    End Sub

    Private Sub lblLock_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLock.MouseLeave
        lblLock.ForeColor = Color.White
        lblLock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblLock_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLock.MouseMove
        lblLock.ForeColor = Color.LawnGreen
        lblLock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblUnlock_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUnlock.MouseLeave
        lblUnlock.ForeColor = Color.White
        lblUnlock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblUnlock_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblUnlock.MouseMove
        lblUnlock.ForeColor = Color.LawnGreen
        lblUnlock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblLogout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogout.MouseLeave
        lblLogout.ForeColor = Color.White
        lblLogout.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblLogout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLogout.MouseMove
        lblLogout.ForeColor = Color.LawnGreen
        lblLogout.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub FullScreen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreen.Tick
        For Each monitor As screenmonitor In MonitorPanel.Controls
            If LCase(monitor.mylabel.Text) = LCase(selectedwordcall) Then
                pbScreen.Image = monitor.mypicturebox.Image
            End If
        Next
    End Sub

    Private Sub pbScreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbScreen.Click
        FullScreen.Stop()

        FullScreenPanel.Visible = False

        selectedcomputername = ""
        selectedipaddress = ""
        selectedwordcall = ""

        lblSelected.Text = ""

        lblScreen.Text = ""

        isFullScreen = False
    End Sub

    Dim isVoice As Boolean = False

    Private Sub lblAllRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllRestart.Click
        isVoice = False

        RestartAll()
    End Sub

    Sub RestartAll()
        If isVoice = True Then
            GoTo res
        End If

        If MsgBox("Are you sure you want to Restart All Unit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Restart All Unit") = MsgBoxResult.Yes Then
res:
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim selcomps As New MySqlCommand(sql, con)
            selcomps.Parameters.AddWithValue("?name", My.Computer.Name)
            selcomps.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcomps)
            ds.Clear()
            da.Fill(ds, "selcomps")

            If ds.Tables("selcomps").Rows.Count > 0 Then
                For a = 1 To ds.Tables("selcomps").Rows.Count
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", ds.Tables("selcomps").Rows(a - 1).Item("computername"))
                    addcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomps").Rows(a - 1).Item("ipaddress"))
                    addcomm.Parameters.AddWithValue("?command", "restart")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                Next
            End If

            message = "Restarting All Unit"
        End If
    End Sub

    Sub ShutdownAll()
        If isVoice = True Then
            GoTo res
        End If

        If MsgBox("Are you sure you want to Shutdown All Unit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Shutdown All Unit") = MsgBoxResult.Yes Then
res:
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim selcomps As New MySqlCommand(sql, con)
            selcomps.Parameters.AddWithValue("?name", My.Computer.Name)
            selcomps.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcomps)
            ds.Clear()
            da.Fill(ds, "selcomps")

            If ds.Tables("selcomps").Rows.Count > 0 Then
                For a = 1 To ds.Tables("selcomps").Rows.Count
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", ds.Tables("selcomps").Rows(a - 1).Item("computername"))
                    addcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomps").Rows(a - 1).Item("ipaddress"))
                    addcomm.Parameters.AddWithValue("?command", "shutdown")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                Next
            End If

            message = "Shutting Down All Unit"
        End If
    End Sub

    Sub LockAll()
        If isVoice = True Then
            GoTo res
        End If

        If MsgBox("Are you sure you want to Lock All Unit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Lock All Unit") = MsgBoxResult.Yes Then
res:
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim selcomps As New MySqlCommand(sql, con)
            selcomps.Parameters.AddWithValue("?name", My.Computer.Name)
            selcomps.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcomps)
            ds.Clear()
            da.Fill(ds, "selcomps")

            If ds.Tables("selcomps").Rows.Count > 0 Then
                For a = 1 To ds.Tables("selcomps").Rows.Count
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", ds.Tables("selcomps").Rows(a - 1).Item("computername"))
                    addcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomps").Rows(a - 1).Item("ipaddress"))
                    addcomm.Parameters.AddWithValue("?command", "lock")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                Next
            End If

            message = "Locking All Unit"
        End If
    End Sub

    Sub UnlockAll()
        If isVoice = True Then
            GoTo res
        End If

        If MsgBox("Are you sure you want to Unlock All Unit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Unlock All Unit") = MsgBoxResult.Yes Then
res:
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim selcomps As New MySqlCommand(sql, con)
            selcomps.Parameters.AddWithValue("?name", My.Computer.Name)
            selcomps.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcomps)
            ds.Clear()
            da.Fill(ds, "selcomps")

            If ds.Tables("selcomps").Rows.Count > 0 Then
                For a = 1 To ds.Tables("selcomps").Rows.Count
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", ds.Tables("selcomps").Rows(a - 1).Item("computername"))
                    addcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomps").Rows(a - 1).Item("ipaddress"))
                    addcomm.Parameters.AddWithValue("?command", "unlock")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                Next
            End If

            message = "Unlock All Unit"
        End If
    End Sub

    Sub LogoutAll()
        If isVoice = True Then
            GoTo res
        End If

        If MsgBox("Are you sure you want to Logout All Students?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Logout All Students") = MsgBoxResult.Yes Then
res:
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim selcomps As New MySqlCommand(sql, con)
            selcomps.Parameters.AddWithValue("?name", My.Computer.Name)
            selcomps.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcomps)
            ds.Clear()
            da.Fill(ds, "selcomps")

            If ds.Tables("selcomps").Rows.Count > 0 Then
                For a = 1 To ds.Tables("selcomps").Rows.Count
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", ds.Tables("selcomps").Rows(a - 1).Item("computername"))
                    addcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomps").Rows(a - 1).Item("ipaddress"))
                    addcomm.Parameters.AddWithValue("?command", "log-out")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                Next
            End If

            message = "Logging Out All Student"
        End If
    End Sub

    Private Sub lblAllRestart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllRestart.MouseLeave
        lblAllRestart.ForeColor = Color.White
        lblAllRestart.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblAllRestart_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAllRestart.MouseMove
        lblAllRestart.ForeColor = Color.LawnGreen
        lblAllRestart.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblAllShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllShutdown.Click
        isVoice = False

        ShutdownAll()
    End Sub

    Private Sub lblAllShutdown_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllShutdown.MouseLeave
        lblAllShutdown.ForeColor = Color.White
        lblAllShutdown.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblAllShutdown_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAllShutdown.MouseMove
        lblAllShutdown.ForeColor = Color.LawnGreen
        lblAllShutdown.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblAllLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllLock.Click
        isVoice = False

        LockAll()
    End Sub

    Private Sub lblAllLock_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllLock.MouseLeave
        lblAllLock.ForeColor = Color.White
        lblAllLock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblAllLock_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAllLock.MouseMove
        lblAllLock.ForeColor = Color.LawnGreen
        lblAllLock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblAllUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllUnlock.Click
        isVoice = False

        UnlockAll()
    End Sub

    Private Sub lblAllUnlock_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllUnlock.MouseLeave
        lblAllUnlock.ForeColor = Color.White
        lblAllUnlock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblAllUnlock_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAllUnlock.MouseMove
        lblAllUnlock.ForeColor = Color.LawnGreen
        lblAllUnlock.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblAllLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllLogout.Click
        isVoice = False

        LogoutAll()
    End Sub

    Private Sub lblAllLogout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllLogout.MouseLeave
        lblAllLogout.ForeColor = Color.White
        lblAllLogout.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblAllLogout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAllLogout.MouseMove
        lblAllLogout.ForeColor = Color.LawnGreen
        lblAllLogout.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub
End Class