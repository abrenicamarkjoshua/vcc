Imports System.Speech.Synthesis

Public Class DASHBOARD
    Public my_database As database = New database
    Public user_info As DataTable = New DataTable
    Public seconds_left As Integer
    Public professor As professor

    Private computers As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
    Public timeleft As TimeSpan = LOGIN.professor.detailsTable.Rows(0)("timeremaining")

    Private Sub DASHBOARD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strategy_network.checkNetwork()
        timer_refresher.Start()
        ' Add any initialization after the InitializeComponent() call.

        lbl_username.Text = user_info.Rows(0)("username").ToString()

        'my_database.query("SELECT * FROM computers")
        'For i As Integer = 0 To my_database.dt.Rows.Count - 1

        '    Me.computers.Add(my_database.dt.Rows(i)("word").ToString, New Dictionary(Of String, String) From {{"computername", my_database.dt.Rows(i)("computername").ToString()}, {"ipaddress", my_database.dt.Rows(i)("ipaddress").ToString()}})

        'Next

        'Create folder student activity
        '~~> Folder already created in the LOGIN form.

        'display my schedule
        '~~> Manual setting of Schedule in the MY_ACCOUNT form.

        'create subfolder under student activity
        '~~> Subfolder will be created upon setting the Section/Subject


        'resume timer upon detecting that the selected schedule's timer_initiated (table student_section) is equal to 'yes'
        LOGIN.database.query2("SELECT timer_initiated FROM student_section  WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})
        Dim dt As DataTable = LOGIN.database.result()
        If dt.Rows(0)("timer_initiated").ToString() = "yes" Then
            Timer1.Start()

        End If
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.user_info = LOGIN.user_info

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MY_ACCOUNT.openedInDashboard = True


        MY_ACCOUNT.ShowDialog()
        lbl_section.Text = LOGIN.section
        lbl_subject.Text = LOGIN.subj


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'speechrecognition2.Show()
        Me.Hide()
        Try
            SpeechRecognition.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        network_setup.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        fileSettings.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ' WordSettings.Show()
        wordsettings2.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        keywordsSettings.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim process As Process = New Process()
            process.StartInfo.FileName = "C:\Windows\sysnative\Speech\speechUX\SpeechUXWiz.exe"
            process.StartInfo.Arguments = "UserTraining"
            process.Start()
        Catch ex As Exception
            Dim process As Process = New Process()
            process.StartInfo.FileName = "C:\Windows\System32\Speech\speechUX\SpeechUXWiz.exe"
            process.StartInfo.Arguments = "UserTraining"
            process.Start()
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '
        'warning
        If timeleft.ToString() = "00:02:00" Then
            Dim builder As PromptBuilder = New PromptBuilder()
            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("Warning! 2 minutes remaining.")
            builder.EndVoice()
            Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)
        End If

        'time is up
        If timeleft.ToString() <= "00:00:00" Then
            Timer1.Stop()
            lbl_timeleft.Text = "00:00:00"
            timeleft = New TimeSpan()
            Dim builder As PromptBuilder = New PromptBuilder()
            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("Time is up!")
            builder.EndVoice()
            Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)
            'update to database
            LOGIN.database.query("UPDATE users SET timeremaining = '00:00:00'  WHERE id = '" & LOGIN.professor.id & "'")
            LOGIN.database.query2("UPDATE student_section SET timer_initiated = '' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})

            MessageBox.Show("Time is up!")
        Else
            'else

            timeleft = timeleft.Subtract(New TimeSpan(0, 0, 1))
            lbl_timeleft.Text = timeleft.ToString()
            SpeechRecognition.lbl_timeleft.Text = timeleft.ToString()
            'update to database
            LOGIN.database.query("UPDATE users SET timeremaining = '" & Me.timeleft.ToString() & "'  WHERE id = '" & LOGIN.professor.id & "'")
        End If
        

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        SetTimer.Show()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub DASHBOARD_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        lbl_section.Text = LOGIN.section
        lbl_subject.Text = LOGIN.subj

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DEFAULT_STUDENT.is_client = False
        DEFAULT_STUDENT.ShowDialog()
        DEFAULT_STUDENT.Dispose()

    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        attendance.ShowDialog()
        attendance.Dispose()

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        studentslist.ShowDialog()
        studentslist.Dispose()

    End Sub

    Private Sub btn_rat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_chat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If timeleft.ToString() <> "00:00:00" Then
            Try
                Dim prompt2 As prompt = New prompt()
                prompt2.logout2()
                If prompt2.result = VCC.prompt.resultEnum.yes Then

                    VCC.LOGIN.professor().logout(VCC.LOGIN.professor().IpAddress)
                    LOGIN.setsection = ""
                    strategy_window.closeWindowReturnLogin(Me)
                    LOGIN.database.query("UPDATE sections SET status = 'Offline' WHERE professor = '" & LOGIN.professor.id & "'")
                    LOGIN.database.query2("UPDATE student_section SET active = '' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})
                    LOGIN.database.query("UPDATE schedule SET status = 'Offline' WHERE professor_id = '" & LOGIN.professor.id & "'")
                    LOGIN.database.query("UPDATE users SET timeremaining = '00:00:00' WHERE id = '" & LOGIN.professor.id & "'")
                    LOGIN.setsection = ""
                    LOGIN.section = ""
                    LOGIN.subj = ""
                    LOGIN.sched_timein = ""
                    LOGIN.sched_timeout = ""
                    LOGIN.sched_day = ""
                    timeleft = New TimeSpan(0, 0, 0)
                    LOGIN.logout()
                    Exit Sub

                Else

                End If

            Catch ex As Exception

            End Try

        End If

        Dim prompt As prompt = New prompt()
        prompt.logout()
        If prompt.result = VCC.prompt.resultEnum.yes Then
            'user.logout(LOGIN.user, LOGIN.user.IpAddress)

            VCC.LOGIN.professor().logout(VCC.LOGIN.professor().IpAddress)
            LOGIN.setsection = ""
            strategy_window.closeWindowReturnLogin(Me)
            LOGIN.database.query("UPDATE sections SET status = 'Offline' WHERE professor = '" & LOGIN.professor.id & "'")
            LOGIN.database.query2("UPDATE student_section SET active = '' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})
            LOGIN.database.query("UPDATE schedule SET status = 'Offline' WHERE professor_id = '" & LOGIN.professor.id & "'")
            LOGIN.setsection = ""
            LOGIN.section = ""
            LOGIN.subj = ""
            LOGIN.sched_timein = ""
            LOGIN.sched_timeout = ""
            LOGIN.sched_day = ""

            LOGIN.logout()

        End If

       


    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        monitor.Show()

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Me.timeleft.ToString() = "00:00:00" Then
            Dim builder As PromptBuilder = New PromptBuilder()
            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("please set timer first")
            builder.EndVoice()
            Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)

        Else
            Dim builder = New PromptBuilder()
            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("timer started")
            builder.EndVoice()
            Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)

            Me.Timer1.Start()
            LOGIN.database.query2("UPDATE student_section SET timer_initiated = 'yes' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})

        End If


    End Sub

    Private Sub timer_refresher_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_refresher.Tick
       
    End Sub
End Class