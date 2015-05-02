Imports MySql.Data.MySqlClient
Imports System.Speech.Recognition
Imports System.Speech.Synthesis

Public Class frmMenu
    Public nextform As String
    Public isExit As Boolean
    Public lastname, firstname, middlename, major, year, section, subject, daysched, dayin, dayout As String
    Public username As String
    Public password As String
    Public wordtype As String
    Public isTutorial As String
    Public isFirst As Boolean
    Public isActivate As Boolean = True
    Public isSharing As Boolean = False

    Public WithEvents menurec As New System.Speech.Recognition.SpeechRecognitionEngine

    Private Sub frmMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isActivate = True Then
            If isTutorial = "No" Then
                Animation.Tag = "Show"
                Animation.Start()
            Else
                isExit = False
                Animation.Tag = "Hide"
                Animation.Start()
            End If
        End If
    End Sub

    Public gender As String

    Sub CheckNetwork()
        sql = "SELECT * FROM tbl_computer"
        da = New MySqlDataAdapter(sql, con)
        da.Fill(ds, "check")

        If ds.Tables("check").Rows.Count > 0 Then
            For a = 1 To ds.Tables("check").Rows.Count
                If My.Computer.Network.Ping(ds.Tables("check").Rows(a - 1).Item("ipaddress")) Then
                    Continue For
                Else
                    deletelist.Add(ds.Tables("check").Rows(a - 1).Item("ipaddress"))
                End If
            Next

            ds.Tables("check").Clear()

            DeleteComputer()
            deletelist.Clear()
        End If
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CheckNetwork()

        lblUsername.Text = username
        lblFullname.Text = lastname & ", " & firstname & " " & middlename
        lblSchedule.Text = daysched & " | " & dayin & " - " & dayout
        lblSection.Text = major & year & section & " - " & subject
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                Try
                    menurec.LoadGrammar(grammar2)
                    menurec.SetInputToDefaultAudioDevice()
                    menurec.RecognizeAsync(1)
                Catch : End Try
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    menurec.RecognizeAsyncStop()
                    menurec.UnloadGrammar(grammar2)
                Catch : End Try

                If isExit = True Then
                    frmLock.Animation.Tag = "Show"
                    frmLock.Animation.Start()

                    Me.Close()
                Else
                    isActivate = False

                    If nextform = "Voice" Then
                        frmSpeechRecognition.Show()
                    ElseIf nextform = "Network" Then
                        frmNetwork.Show()
                    ElseIf nextform = "Application" Then
                        frmApplication.Show()
                    ElseIf nextform = "Keyword" Then
                        frmKeyword.Show()
                    ElseIf nextform = "Class" Then
                        frmMyClass.Show()
                    ElseIf nextform = "Word" Then
                        frmWord.Show()
                    ElseIf nextform = "Remote" Then
                        frmMonitoring.nextform = "Menu"
                        frmMonitoring.Show()
                    ElseIf nextform = "Account" Then
                        frmAccount.Show()
                    Else
                        frmTutorial.Show()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lblStartTutorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStartTutorial.Click
        isTutorial = "Yes"
        frmTutorial.isFirst = False
        nextform = "Tutorial"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub pbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbStart.Click
        isExit = False
        nextform = "Voice"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub NetworkPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NetworkPanel.Click
        isExit = False
        nextform = "Network"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub NetworkPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NetworkPanel.MouseLeave
        lblHL.Left = NetworkPanel.Left - 4
        lblHL.Top = NetworkPanel.Top - 4
        lblHL.Visible = False

        lblNetwork.ForeColor = Color.White
    End Sub

    Public thread_checknetwork As Threading.Thread = New Threading.Thread(AddressOf t_checknetwork)
    Dim checknetworkactive As Boolean = True
    Dim deletelist As New List(Of String)

    Private Sub t_checknetwork()
        While checknetworkactive
            
        End While
    End Sub

    Sub DeleteComputer()
        For a = 1 To deletelist.Count
            sql = "DELETE FROM tbl_computer WHERE ipaddress=?ip"
            Dim delcomp As New MySqlCommand(sql, con)
            delcomp.Parameters.AddWithValue("?ip", deletelist(a - 1))

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            delcomp.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Private Sub NetworkPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NetworkPanel.MouseMove
        lblHL.Left = NetworkPanel.Left - 4
        lblHL.Top = NetworkPanel.Top - 4
        lblHL.Visible = True

        lblNetwork.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNetwork.Click
        isExit = False
        nextform = "Network"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblNetwork_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNetwork.MouseLeave
        lblHL.Left = NetworkPanel.Left - 4
        lblHL.Top = NetworkPanel.Top - 4
        lblHL.Visible = False

        lblNetwork.ForeColor = Color.White
    End Sub

    Private Sub lblNetwork_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblNetwork.MouseMove
        lblHL.Left = NetworkPanel.Left - 4
        lblHL.Top = NetworkPanel.Top - 4
        lblHL.Visible = True
        lblNetwork.ForeColor = Color.LawnGreen
    End Sub

    Private Sub ApplicationPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplicationPanel.Click
        isExit = False
        nextform = "Application"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub ApplicationPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplicationPanel.MouseLeave
        lblHL.Left = ApplicationPanel.Left - 4
        lblHL.Top = ApplicationPanel.Top - 4
        lblHL.Visible = False

        lblApplication.ForeColor = Color.White
    End Sub

    Private Sub ApplicationPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ApplicationPanel.MouseMove
        lblHL.Left = ApplicationPanel.Left - 4
        lblHL.Top = ApplicationPanel.Top - 4
        lblHL.Visible = True

        lblApplication.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblApplication.Click
        isExit = False
        nextform = "Application"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblApplication_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblApplication.MouseLeave
        lblHL.Left = ApplicationPanel.Left - 4
        lblHL.Top = ApplicationPanel.Top - 4
        lblHL.Visible = False
        lblApplication.ForeColor = Color.White
    End Sub

    Private Sub lblApplication_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblApplication.MouseMove
        lblHL.Left = ApplicationPanel.Left - 4
        lblHL.Top = ApplicationPanel.Top - 4
        lblHL.Visible = True
        lblApplication.ForeColor = Color.LawnGreen
    End Sub

    Private Sub KeywordPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KeywordPanel.Click
        isExit = False
        nextform = "Keyword"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblKeyword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblKeyword.Click
        isExit = False
        nextform = "Keyword"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub KeywordPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles KeywordPanel.MouseLeave
        lblHL.Left = KeywordPanel.Left - 4
        lblHL.Top = KeywordPanel.Top - 4
        lblHL.Visible = False

        lblKeyword.ForeColor = Color.White
    End Sub

    Private Sub KeywordPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles KeywordPanel.MouseMove
        lblHL.Left = KeywordPanel.Left - 4
        lblHL.Top = KeywordPanel.Top - 4
        lblHL.Visible = True

        lblKeyword.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblKeyword_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblKeyword.MouseLeave
        lblHL.Left = KeywordPanel.Left - 4
        lblHL.Top = KeywordPanel.Top - 4
        lblHL.Visible = False
        lblKeyword.ForeColor = Color.White
    End Sub

    Private Sub lblKeyword_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblKeyword.MouseMove
        lblHL.Left = KeywordPanel.Left - 4
        lblHL.Top = KeywordPanel.Top - 4
        lblHL.Visible = True
        lblKeyword.ForeColor = Color.LawnGreen
    End Sub

    Private Sub ClassPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClassPanel.Click
        isExit = False
        nextform = "Class"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClass.Click
        isExit = False
        nextform = "Class"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub ClassPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClassPanel.MouseLeave
        lblHL.Left = ClassPanel.Left - 4
        lblHL.Top = ClassPanel.Top - 4
        lblHL.Visible = False

        lblClass.ForeColor = Color.White
    End Sub

    Private Sub ClassPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ClassPanel.MouseMove
        lblHL.Left = ClassPanel.Left - 4
        lblHL.Top = ClassPanel.Top - 4
        lblHL.Visible = True

        lblClass.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblClass_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClass.MouseLeave
        lblHL.Left = ClassPanel.Left - 4
        lblHL.Top = ClassPanel.Top - 4
        lblHL.Visible = False
        lblClass.ForeColor = Color.White
    End Sub

    Private Sub lblClass_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClass.MouseMove
        lblHL.Left = ClassPanel.Left - 4
        lblHL.Top = ClassPanel.Top - 4
        lblHL.Visible = True
        lblClass.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogout.Click
        sql = "UPDATE tbl_schedule SET status='Offline'"
        Dim upsch As New MySqlCommand(sql, con)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        upsch.ExecuteNonQuery()
        con.Close()

        isExit = True
        menurec.RecognizeAsyncStop()

        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblLogout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogout.MouseLeave
        lblLogout.ForeColor = Color.White
        lblLogout.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblLogout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLogout.MouseMove
        lblLogout.ForeColor = Color.LawnGreen
        lblLogout.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub lblWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWord.Click
        isExit = False
        nextform = "Word"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub ApplicationPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ApplicationPanel.Paint

    End Sub

    Private Sub TimerPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonitoringPanel.Click
        isExit = False
        nextform = "Remote"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub TimerPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonitoringPanel.MouseLeave
        lblHL.Left = MonitoringPanel.Left - 4
        lblHL.Top = MonitoringPanel.Top - 4
        lblHL.Visible = False
        lblMonitoring.ForeColor = Color.White
    End Sub

    Private Sub TimerPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MonitoringPanel.MouseMove
        lblHL.Left = MonitoringPanel.Left - 4
        lblHL.Top = MonitoringPanel.Top - 4
        lblHL.Visible = True
        lblMonitoring.ForeColor = Color.LawnGreen
    End Sub

    Private Sub TimerPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MonitoringPanel.Paint

    End Sub

    Private Sub lblTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonitoring.Click
        isExit = False
        nextform = "Remote"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblTimer_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMonitoring.MouseLeave
        lblHL.Left = MonitoringPanel.Left - 4
        lblHL.Top = MonitoringPanel.Top - 4
        lblHL.Visible = False
        lblMonitoring.ForeColor = Color.White
    End Sub

    Private Sub lblTimer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblMonitoring.MouseMove
        lblHL.Left = MonitoringPanel.Left - 4
        lblHL.Top = MonitoringPanel.Top - 4
        lblHL.Visible = True
        lblMonitoring.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblAccSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAccSetting.Click
        isExit = False
        nextform = "Account"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblAccSetting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAccSetting.MouseLeave
        lblHL.Left = AccSettingPanel.Left - 4
        lblHL.Top = AccSettingPanel.Top - 4
        lblHL.Visible = False

        lblAccSetting.ForeColor = Color.White
    End Sub

    Private Sub lblAccSetting_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAccSetting.MouseMove
        lblHL.Left = AccSettingPanel.Left - 4
        lblHL.Top = AccSettingPanel.Top - 4
        lblHL.Visible = True

        lblAccSetting.ForeColor = Color.LawnGreen
    End Sub

    Private Sub WordSetting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WordSetting.Click
        isExit = False
        nextform = "Word"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub WordSetting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles WordSetting.MouseLeave
        lblHL.Left = WordSetting.Left - 4
        lblHL.Top = WordSetting.Top - 4
        lblHL.Visible = False

        lblWord.ForeColor = Color.White
    End Sub

    Private Sub WordSetting_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WordSetting.MouseMove
        lblHL.Left = WordSetting.Left - 4
        lblHL.Top = WordSetting.Top - 4
        lblHL.Visible = True

        lblWord.ForeColor = Color.LawnGreen
    End Sub

    Private Sub WordSetting_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles WordSetting.Paint

    End Sub

    Private Sub lblWord_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblWord.MouseLeave
        lblHL.Left = WordSetting.Left - 4
        lblHL.Top = WordSetting.Top - 4
        lblHL.Visible = False
        lblWord.ForeColor = Color.White
    End Sub

    Private Sub lblWord_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblWord.MouseMove
        lblHL.Left = WordSetting.Left - 4
        lblHL.Top = WordSetting.Top - 4
        lblHL.Visible = True
        lblWord.ForeColor = Color.LawnGreen
    End Sub

    Private Sub KeywordPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles KeywordPanel.Paint

    End Sub

    Private Sub lblChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChange.Click
        menurec.RecognizeAsyncStop()

        frmChangeSection.ShowDialog()
    End Sub

    Private Sub lblChange_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChange.MouseLeave
        lblHL.Left = SectionPanel.Left - 4
        lblHL.Top = SectionPanel.Top - 4
        lblHL.Visible = False

        lblChange.ForeColor = Color.White
    End Sub

    Private Sub lblChange_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblChange.MouseMove
        lblHL.Left = SectionPanel.Left - 4
        lblHL.Top = SectionPanel.Top - 4
        lblHL.Visible = True

        lblChange.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblStartTutorial_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStartTutorial.MouseLeave
        lblHL.Left = TutorialPanel.Left - 4
        lblHL.Top = TutorialPanel.Top - 4
        lblHL.Visible = False

        lblStartTutorial.ForeColor = Color.White
    End Sub

    Private Sub lblStartTutorial_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblStartTutorial.MouseMove
        lblHL.Left = TutorialPanel.Left - 4
        lblHL.Top = TutorialPanel.Top - 4
        lblHL.Visible = True

        lblStartTutorial.ForeColor = Color.LawnGreen
    End Sub

    Private Sub lblAlternative_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAlternative.Click
        menurec.RecognizeAsyncStop()

        frmAlternative.ShowDialog()
    End Sub

    Private Sub lblAlternative_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        lblAlternative.ForeColor = Color.White
        lblAlternative.Font = New Font("Segoe UI", 10, FontStyle.Regular)
    End Sub

    Private Sub lblAlternative_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        lblAlternative.ForeColor = Color.LawnGreen
        lblAlternative.Font = New Font("Segoe UI Semibold", 10, FontStyle.Underline)
    End Sub

    Public isLoaded As Boolean = False

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles menurec.SpeechRecognized
        If e.Result.Text = "my class" Then
            isExit = False
            nextform = "Class"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "exit program" Then
            If MsgBox("Are you sure you want to Exit Program?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit Program") = MsgBoxResult.Yes Then
                Try
                    sql = "UPDATE tbl_schedule SET status='Offline'"
                    Dim upsch As New MySqlCommand(sql, con)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    upsch.ExecuteNonQuery()
                    con.Close()

                    Try
                        thread_speaker.Abort()
                    Catch : End Try

                    Try
                        frmLock.start_sending.Abort()
                    Catch : End Try

                    Try
                        frmSpeechRecognition.start_sending.Abort()
                    Catch : End Try
                Catch : End Try

                End
            End If
        ElseIf e.Result.Text = "network setting" Then
            isExit = False
            nextform = "Network"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "application setting" Then
            isExit = False
            nextform = "Application"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "keyword setting" Then
            isExit = False
            nextform = "Keyword"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "train speech-engine" Then
            GoTo tse
        ElseIf e.Result.Text = "train-speech engine" Then
            GoTo tse
        ElseIf e.Result.Text = "train speech" Then
tse:
            Dim process As New Process()

            process.StartInfo.FileName = "C:\Windows\sysnative\Speech\speechUX\SpeechUXWiz.exe"
            process.StartInfo.Arguments = "UserTraining"
            process.Start()
        ElseIf e.Result.Text = "start tutorial" Then
            isTutorial = "Yes"
            frmTutorial.isFirst = False
            nextform = "Tutorial"
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "start voice-command" Then
            GoTo vc
        ElseIf e.Result.Text = "start-voice command" Then
            GoTo vc
        ElseIf e.Result.Text = "voice command" Then
vc:
            isExit = False
            nextform = "Voice"
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "voice alternative" Then
            Try
                menurec.RecognizeAsyncStop()
            Catch : End Try

            frmAlternative.ShowDialog()
        ElseIf e.Result.Text = "good morning" Then
            If TimeOfDay.Hour < 12 Then
                If gender = "Male" Then
                    message = "Good morning sir"
                Else
                    message = "Good morning ma'am"
                End If
            Else
                If gender = "Male" Then
                    message = "Sir.. it should be Good Afternoon"
                Else
                    message = "Ma'am.. it should be Good Afternoon"
                End If
            End If
        ElseIf e.Result.Text = "logout account" Then
            GoTo out
        ElseIf e.Result.Text = "log out" Then
out:
            sql = "UPDATE tbl_schedule SET status='Offline'"
            Dim upsch As New MySqlCommand(sql, con)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upsch.ExecuteNonQuery()
            con.Close()

            isExit = True

            Try
                menurec.RecognizeAsyncStop()
            Catch : End Try

            message = "Logging out your Account"

            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "good afternoon" Then
            If TimeOfDay.Hour < 12 Then
                If gender = "Male" Then
                    message = "Sir.. it should be Good Morning"
                Else
                    message = "Ma'am.. it should be Good Morning"
                End If
            Else
                If gender = "Male" Then
                    message = "Good afternoon Sir"
                Else
                    message = "Good afternoon Ma'am"
                End If
            End If
        ElseIf e.Result.Text = "word setting" Then
            isExit = False
            nextform = "Word"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "student monitoring" Then
            isExit = False
            nextform = "Remote"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "date today" Then
            message = "Today is " & Today
        ElseIf e.Result.Text = "tell date" Then
            message = "Today is " & Today
        ElseIf e.Result.Text = "tell time" Then
            message = "The time now is " & TimeOfDay.ToShortTimeString
        ElseIf e.Result.Text = "time today" Then
            message = "The time now is " & TimeOfDay.ToShortTimeString
        ElseIf e.Result.Text = "my account" Or e.Result.Text = "account setting" Then
            isExit = False
            nextform = "Account"
            Animation.Tag = "Hide"
            Animation.Start()

            GoTo success
        ElseIf e.Result.Text = "view attendance" Then
            Try
                menurec.RecognizeAsyncStop()
            Catch : End Try

            frmAttendance.lblTitle.Text = UCase(major) & year & UCase(section) & " - " & subject
            frmAttendance.ShowDialog()
        ElseIf e.Result.Text = "total students" Then
            sql = "SELECT * FROM tbl_student WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user ORDER BY studentlname ASC"
            Dim selstud As New MySqlCommand(sql, con)
            selstud.Parameters.AddWithValue("?major", major)
            selstud.Parameters.AddWithValue("?year", year)
            selstud.Parameters.AddWithValue("?section", section)
            selstud.Parameters.AddWithValue("?subject", subject)
            selstud.Parameters.AddWithValue("?user", username)
            da = New MySqlDataAdapter(selstud)
            da.Fill(ds, "stud")

            If ds.Tables("stud").Rows.Count = 1 Then
                message = "You have 1 student in your current section"
            ElseIf ds.Tables("stud").Rows.Count > 1 Then
                message = "You have " & ds.Tables("stud").Rows.Count & " students in your current section"
            Else
                message = "You have no student in your current section"
            End If

            ds.Tables("stud").Clear()
        ElseIf e.Result.Text = "client timer" Then
            GoTo timer
        ElseIf e.Result.Text = "timer setting" Then
timer:
            Try
                menurec.RecognizeAsyncStop()
            Catch : End Try

            frmTimer.ShowDialog()
        ElseIf e.Result.Text = "students activity" Then
            GoTo act
        ElseIf e.Result.Text = "view activity" Then
act:
            Try
                menurec.RecognizeAsyncStop()
            Catch : End Try

            frmActivity.ShowDialog()
        ElseIf e.Result.Text = "change section" Then
            GoTo sect
        ElseIf e.Result.Text = "section setting" Then
sect:
            Try
                menurec.RecognizeAsyncStop()
            Catch : End Try

            frmChangeSection.ShowDialog()
        End If

        Exit Sub

success:
        Try
            menurec.RecognizeAsyncStop()
        Catch : End Try
    End Sub

    Private Sub ClassPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ClassPanel.Paint

    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lblStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStart.Click
        sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
        Dim selcomp As New MySqlCommand(sql, con)
        selcomp.Parameters.AddWithValue("?name", My.Computer.Name)
        selcomp.Parameters.AddWithValue("?ip", v4())
        da = New MySqlDataAdapter(selcomp)
        da.Fill(ds, "complist")

        If ds.Tables("complist").Rows.Count > 0 Then
            For a = 1 To ds.Tables("complist").Rows.Count
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", ds.Tables("complist").Rows(a - 1).Item("computername").ToString)
                addcomm.Parameters.AddWithValue("?ip", ds.Tables("complist").Rows(a - 1).Item("ipaddress").ToString)
                addcomm.Parameters.AddWithValue("?comm", "start-time")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            Next

            message = "All client's time has been enabled"
        Else
            message = "No Client Computers detected"
        End If

        ds.Tables("complist").Clear()
    End Sub

    Private Sub lblStart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStart.MouseLeave
        lblStart.ForeColor = Color.White
        lblStart.Font = New Font("Segoe UI", 10, FontStyle.Regular)
    End Sub

    Private Sub lblStart_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblStart.MouseMove
        lblStart.ForeColor = Color.LawnGreen
        lblStart.Font = New Font("Segoe UI", 10, FontStyle.Underline)
    End Sub

    Private Sub NetworkPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles NetworkPanel.Paint

    End Sub

    Private Sub SectionPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SectionPanel.Click
        Try
            menurec.RecognizeAsyncStop()
        Catch : End Try

        frmChangeSection.ShowDialog()
    End Sub

    Private Sub SectionPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SectionPanel.MouseLeave
        lblHL.Left = SectionPanel.Left - 4
        lblHL.Top = SectionPanel.Top - 4
        lblHL.Visible = False

        lblChange.ForeColor = Color.White
    End Sub

    Private Sub SectionPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SectionPanel.MouseMove
        lblHL.Left = SectionPanel.Left - 4
        lblHL.Top = SectionPanel.Top - 4
        lblHL.Visible = True

        lblChange.ForeColor = Color.LawnGreen
    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SectionPanel.Paint

    End Sub

    Private Sub TimerPanel_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerPanel.Click
        Try
            menurec.RecognizeAsyncStop()
        Catch : End Try

        frmTimer.ShowDialog()
    End Sub

    Private Sub TimerPanel_MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerPanel.MouseLeave
        lblHL.Left = TimerPanel.Left - 4
        lblHL.Top = TimerPanel.Top - 4
        lblHL.Visible = False

        lblTimer.ForeColor = Color.White
    End Sub

    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TimerPanel.MouseMove
        lblHL.Left = TimerPanel.Left - 4
        lblHL.Top = TimerPanel.Top - 4
        lblHL.Visible = True

        lblTimer.ForeColor = Color.LawnGreen
    End Sub

    Private Sub TrainPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrainPanel.Click
        Dim process As New Process()

        Try
            process.StartInfo.FileName = "C:\Windows\sysnative\Speech\speechUX\SpeechUXWiz.exe"
            process.StartInfo.Arguments = "UserTraining"
            process.Start()
        Catch ex As Exception
            Try
                process.StartInfo.FileName = "C:\Windows\System32\Speech\speechUX\SpeechUXWiz.exe"
                process.StartInfo.Arguments = "UserTraining"
                process.Start()
            Catch exs As Exception
                message = "Unable to locate the Speech Recognition Training Wizard"
                MsgBox("Unable to locate the Speech Recognition Training Wizard", MsgBoxStyle.Information, "Training Wizard")
            End Try
        End Try
    End Sub

    Private Sub TrainPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrainPanel.MouseLeave
        lblHL.Left = TrainPanel.Left - 4
        lblHL.Top = TrainPanel.Top - 4
        lblHL.Visible = False

        lblTrain.ForeColor = Color.White
    End Sub

    Private Sub Panel4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrainPanel.MouseMove
        lblHL.Left = TrainPanel.Left - 4
        lblHL.Top = TrainPanel.Top - 4
        lblHL.Visible = True

        lblTrain.ForeColor = Color.LawnGreen
    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TrainPanel.Paint

    End Sub

    Private Sub lblTrain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrain.Click
        Dim process As New Process()

        Try
            process.StartInfo.FileName = "C:\Windows\sysnative\Speech\speechUX\SpeechUXWiz.exe"
            process.StartInfo.Arguments = "UserTraining"
            process.Start()
        Catch ex As Exception
            Try
                process.StartInfo.FileName = "C:\Windows\System32\Speech\speechUX\SpeechUXWiz.exe"
                process.StartInfo.Arguments = "UserTraining"
                process.Start()
            Catch exs As Exception
                message = "Unable to locate the Speech Recognition Training Wizard"
                MsgBox("Unable to locate the Speech Recognition Training Wizard", MsgBoxStyle.Information, "Training Wizard")
            End Try
        End Try
    End Sub

    Private Sub lblTrain_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTrain.MouseLeave
        lblHL.Left = TrainPanel.Left - 4
        lblHL.Top = TrainPanel.Top - 4
        lblHL.Visible = False

        lblTrain.ForeColor = Color.White
    End Sub

    Private Sub lblTrain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTrain.MouseMove
        lblHL.Left = TrainPanel.Left - 4
        lblHL.Top = TrainPanel.Top - 4
        lblHL.Visible = True

        lblTrain.ForeColor = Color.LawnGreen
    End Sub

    Private Sub TutorialPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TutorialPanel.Click
        isTutorial = "Yes"
        frmTutorial.isFirst = False
        nextform = "Tutorial"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub TutorialPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TutorialPanel.MouseLeave
        lblHL.Left = TutorialPanel.Left - 4
        lblHL.Top = TutorialPanel.Top - 4
        lblHL.Visible = False

        lblStartTutorial.ForeColor = Color.White
    End Sub

    Private Sub TutorialPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TutorialPanel.MouseMove
        lblHL.Left = TutorialPanel.Left - 4
        lblHL.Top = TutorialPanel.Top - 4
        lblHL.Visible = True

        lblStartTutorial.ForeColor = Color.LawnGreen
    End Sub

    Private Sub TutorialPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TutorialPanel.Paint

    End Sub

    Private Sub AccSettingPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccSettingPanel.Click
        isExit = False
        nextform = "Account"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub AccSettingPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccSettingPanel.MouseLeave
        lblHL.Left = AccSettingPanel.Left - 4
        lblHL.Top = AccSettingPanel.Top - 4
        lblHL.Visible = False

        lblAccSetting.ForeColor = Color.White
    End Sub

    Private Sub AccSettingPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AccSettingPanel.MouseMove
        lblHL.Left = AccSettingPanel.Left - 4
        lblHL.Top = AccSettingPanel.Top - 4
        lblHL.Visible = True

        lblAccSetting.ForeColor = Color.LawnGreen
    End Sub

    Private Sub AccSettingPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AccSettingPanel.Paint

    End Sub

    Private Sub AlternativePanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlternativePanel.Click
        Try
            menurec.RecognizeAsyncStop()
        Catch : End Try

        frmAlternative.ShowDialog()
    End Sub

    Private Sub AlternativePanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlternativePanel.MouseLeave
        lblHL.Left = AlternativePanel.Left - 4
        lblHL.Top = AlternativePanel.Top - 4
        lblHL.Visible = False

        lblAlternative.ForeColor = Color.White
    End Sub

    Private Sub AlternativePanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AlternativePanel.MouseMove
        lblHL.Left = AlternativePanel.Left - 4
        lblHL.Top = AlternativePanel.Top - 4
        lblHL.Visible = True

        lblAlternative.ForeColor = Color.LawnGreen
    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AlternativePanel.Paint

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub lblSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSystem.Click
        Try
            menurec.RecognizeAsyncStop()
        Catch : End Try

        frmBackupdb.ShowDialog()
    End Sub

    Private Sub lblSystem_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSystem.MouseLeave
        lblSystem.ForeColor = Color.White
        lblSystem.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
    End Sub

    Private Sub lblSystem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSystem.MouseMove
        lblSystem.ForeColor = Color.LawnGreen
        lblSystem.Font = New Font("Segoe UI Semibold", 10, FontStyle.Underline)
    End Sub

    Private Sub lblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExit.Click
        If MsgBox("Are you sure you want to Exit Program?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit Program") = MsgBoxResult.Yes Then
            Try
                sql = "UPDATE tbl_schedule SET status='Offline'"
                Dim upsch As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upsch.ExecuteNonQuery()
                con.Close()

                Try
                    thread_speaker.Abort()
                Catch : End Try

                Try
                    frmLock.start_sending.Abort()
                Catch : End Try

                Try
                    frmSpeechRecognition.start_sending.Abort()
                Catch : End Try
            Catch : End Try

            End
        End If
    End Sub

    Private Sub lblExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExit.MouseLeave
        lblExit.ForeColor = Color.White
        lblExit.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblExit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblExit.MouseMove
        lblExit.ForeColor = Color.LawnGreen
        lblExit.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

End Class