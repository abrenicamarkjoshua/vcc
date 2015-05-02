Imports System.IO


Public Class STUDENT_MODULE
    Private student_info As DataTable = New DataTable
    Private database As database = New database()
    Private timeleft As TimeSpan
    Private database2 As database = New database()
    Private section As String
    Private subject As String

    Private Sub listviewRefresh()
        listview_sections.Items.Clear()
        LOGIN.database.query2("SELECT * FROM student_section WHERE student_id = ?", New ArrayList() From {LOGIN.student.id})
        Dim dt As DataTable = LOGIN.database.result()
        For i As Integer = 0 To dt.Rows.Count - 1
            listview_sections.Items.Add(dt.Rows(i)("section").ToString())
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("subject").ToString())
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("day").ToString())
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("timein").ToString())
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("timeout").ToString())
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("active").ToString())
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("id").ToString())

        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        student_add_section.ShowDialog(Me)
    End Sub

    Private Sub STUDENT_MODULE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblWordCall.Width = Me.Width
        lblWordCall.Left = 0
        lblWordCall.SendToBack()

        Me.student_info = LOGIN.user_info

        lbl_student_id.Text = student_info.Rows(0)("student_id").ToString()
        lbl_student_name.Text = student_info.Rows(0)("student_name").ToString()

        Dim dt As DataTable = LOGIN.database.query("SELECT * FROM computers WHERE computername= '" & strategy_localComputer.getComputerName() & "'")

        lblWordCall.Text = dt.Rows(0)("word").ToString()

        listviewRefresh()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If timeleft.ToString() <> "00:00:00" Then
            Try
                Dim prompt2 As prompt = New prompt()
                prompt2.logout2()
                If prompt2.result = VCC.prompt.resultEnum.yes Then
                    LOGIN.database.query("UPDATE students SET timeleft = '00:00:00' WHERE student_id = '" & LOGIN.student.studentId & "'")
                    LOGIN.student().logout(LOGIN.student().IpAddress)
                    endActivity()
                    LOGIN.logout()

                End If
            Catch ex As Exception

            End Try

            Exit Sub
        End If
        Dim prompt As prompt = New prompt()
        prompt.logout()
        If prompt.result = VCC.prompt.resultEnum.yes Then
            'user.logout(LOGIN.user, LOGIN.user.IpAddress)
            LOGIN.student().logout(LOGIN.student().IpAddress)
            endActivity()
            LOGIN.logout()

        End If

    End Sub
    Public set_timein As String
    Public set_timeout As String
    Public set_days As String
    Public set_section_id As String

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private ipaddress As String = strategy_localComputer.getIpAddress()




    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblWordCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWordCall.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        add_studentSection.ShowDialog()
        add_studentSection.Dispose()
        listviewRefresh()

    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If listview_sections.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select subject schedule from the list")
            Exit Sub
        End If

        'if in the student_section, there is an active section then you are forced to select that subject until it is finished.
        If listview_sections.SelectedItems(0).SubItems(5).Text = "" Then
            MessageBox.Show("Please select the subject which is currently in active session.")
            Exit Sub
        End If

        timeleft = CType(LOGIN.student.detailsTable.Rows(0)("timeleft"), TimeSpan)
        If (timeleft.ToString() = "00:00:00") Then
            'either your time has ran out or activity is not yet initiated.
            Dim dt As DataTable = LOGIN.database.query("SELECT * FROM student_section  WHERE id = '" & listview_sections.SelectedItems(0).SubItems(6).Text & "'")
            'if it is 'initiated' you cannot enter the class untill...
            If dt.Rows(0)("timer_initiated").ToString() = "yes" Then
                MessageBox.Show("Activity is on going and your remaining time is 00:00:00. Please wait until the activity is finished")
            Else

                'if it is "" or blank AKA no activity is in active session, you can enter the class.
                'start timer1 to observe changes in 'timer_initiated'. if it changed, timer1.stop, timer2.start
                Timer1.Start()
                Button1.Enabled = False

            End If

        Else
            'else if you still have time left...
            'but if the activity is over and you still have time, 
            'either your terminal crashed or unexpectedly shutdown, or LAN connection was lost

            'but if the activity is still in session and you still have time...
            'just resume the time
            Timer2.Start()
            Button1.Enabled = False

        End If

        lbl_section.Text = listview_sections.SelectedItems(0).SubItems(0).Text
        section = listview_sections.SelectedItems(0).SubItems(0).Text
        lbl_subject.Text = listview_sections.SelectedItems(0).SubItems(1).Text
        subject = listview_sections.SelectedItems(0).SubItems(1).Text
        set_timein = listview_sections.SelectedItems(0).SubItems(3).Text
        set_timeout = listview_sections.SelectedItems(0).SubItems(4).Text
        set_days = listview_sections.SelectedItems(0).SubItems(2).Text
        set_section_id = listview_sections.SelectedItems(0).SubItems(6).Text

        'directory creation


        My.Computer.FileSystem.CreateDirectory(
  My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & LOGIN.student.studentId & "")

        'if it is already registered, no need to register
        If exist("SELECT COUNT(ID) FROM computers WHERE computername = ?", New ArrayList() From {strategy_localComputer.getComputerName()}) Then
            Exit Sub
        End If
        
    End Sub
    Private timeout As TimeSpan
    Private timestart As TimeSpan
    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'start timer1 to observe changes in 'timer_initiated' . if it changed, timer1.stop, timer2.start
        Dim dt As DataTable = database2.query("SELECT * FROM student_section WHERE id = '" & Me.set_section_id & "'")
        If dt.Rows(0)("active").ToString() = "yes" And dt.Rows(0)("timer_initiated").ToString() = "yes" Then
            'if my time is 00:00:00 then get time from professor else if i already have time left then resume deduction

            If LOGIN.student.detailsTable.Rows(0)("timeleft").ToString() = "00:00:00" Then
                'get time from professor
                Do Until timeleft.ToString() <> "00:00:00"
                    Dim dt_result As DataTable = database2.query("SELECT users.timeremaining FROM users, student_section WHERE users.username = student_section.professor_name  AND student_section.id = '" & Me.set_section_id & "'")
                    Dim mytimeleft As String = dt_result.Rows(0)("timeremaining").ToString()
                    timeleft = CType(dt_result.Rows(0)("timeremaining"), TimeSpan)

                Loop
                'database2.query("UPDATE students SET timeleft = '" & mytimeleft & "' WHERE  student_id = '" & LOGIN.student.studentId & "'")
                'start deduction
                Timer1.Stop()
                Timer2.Start()

            Else

                'resume deduction from last timer
                Timer1.Stop()
                Timer2.Start()
            End If
        End If

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer2.Start()
    End Sub
    Public Sub endActivity()
        'send my activity to server
        'delete my local file after sending my activity file
        Dim datetoday As String = Date.Now.Date.ToString("yyyy-MM-dd")
        Try
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & LOGIN.student.studentId & "") Then

                'MessageBox.Show("Error occured. You must have deleted your folder inside 'student activity' directory")

            Else
                'if it exist
                Dim fileEntries As String() = Directory.GetFiles(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & LOGIN.student.studentId & "")
                If fileEntries.Count() = 0 Then
                    'no activity
                    'RETURN HERE. WHAT IF STUDENT HAS 2 ACTIVITIES FOR THIS DAY. HOW WOULD YOU DISPLAY THOSE ACTIVITIES?
                    'check if i already logged in this day
                    If exist("SELECT COUNT(id) FROM attendance WHERE date = ? AND student_id = ? AND section = ? AND subject = ?", New ArrayList() From {datetoday, LOGIN.student.studentId, section, subject}) Then
                        'if already logged in, update 'sent activity', 'activity_path' = nothing/return here
                        'LOGIN.database.query2("UPDATE attendance SET has_activity = 'no' WHERE date = ? AND student_name = ? AND section = ? AND subject = ?", New ArrayList() From {datetoday, LOGIN.student.studentId, section, subject})
                    Else
                        'if not, insert into attendance(date, studentnumber, sent activity, activity path)
                        LOGIN.database.query2("INSERT INTO attendance(date, student_name, student_id, logged_in, has_activity, section, subject) VALUES (?,?,?,?,?,?,?)", New ArrayList() From {datetoday, LOGIN.student.details("student_name").ToString(), LOGIN.student.studentId, "yes", "no", section, subject})
                    End If

                Else
                    'has activity, send it to server
                    System.IO.Directory.CreateDirectory("\\" & My.Settings.server & "\Student Activity\" & section & "-" & subject & "\" & datetoday & "\" & LOGIN.student.studentId)
                    My.Computer.FileSystem.CopyDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & LOGIN.student.studentId & "",
   "\\" & My.Settings.server & "\Student Activity\" & section & "-" & subject & "\" & datetoday & "\" & LOGIN.student.studentId,
   True)
                    'no activity
                    'check if i already logged in this day
                    If exist("SELECT COUNT(id) FROM attendance WHERE date = ? AND student_id = ?", New ArrayList() From {datetoday, LOGIN.student.studentId}) Then
                        'if already logged in, update 'sent activity', 'activity_path' = something./return here
                        LOGIN.database.query2("UPDATE attendance SET has_activity = 'yes' WHERE date = ? AND student_id = ? AND section = ? AND subject = ?", New ArrayList() From {datetoday, LOGIN.student.studentId, section, subject})
                    Else
                        'if not, insert into attendance(date, studentnumber, sent activity, activity path)
                        LOGIN.database.query2("INSERT INTO attendance(date, student_name, student_id, logged_in, has_activity, section, subject) VALUES (?,?,?,?,?,?,?)", New ArrayList() From {datetoday, LOGIN.student.details("student_name").ToString(), LOGIN.student.studentId, "yes", "yes", section, subject})
                    End If

                End If
                
            End If

            'delete local files
            System.IO.Directory.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & LOGIN.student.studentId & "", True)
            'update attendance. set student has activity


        Catch ex As Exception

        End Try

        Me.Close()
        lecture.Close()
        LOGIN.Show()

    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick


        'if timeleft is 2 minutes left

        If timeleft.TotalSeconds <= 0 Then
            Timer2.Stop()
            database.query("UPDATE students SET timeleft = '00:00:00' WHERE student_id = '" & LOGIN.student.id & "'")
            'perform ending operation of student activity

            endActivity()

        Else
            timeleft = timeleft.Subtract(New TimeSpan(0, 0, 1))
            lbl_timeleft.Text = timeleft.ToString()
            database.query("UPDATE students SET timeleft = '" & timeleft.ToString() & "' WHERE student_id = '" & LOGIN.student.id & "'")

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        listviewRefresh()

    End Sub
End Class