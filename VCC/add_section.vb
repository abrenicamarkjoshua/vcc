Imports System.Data.Odbc

Public Class add_section

    Private Sub add_section_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'enable_prompt = False
        'show_dashboard_after = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'can't be blank
        If has_blanks("all", New List(Of Control) From {TextBox1, TextBox2, cmb_day, txt_accessCode, txt_timein, txt_timeout}) Then
            Exit Sub
        End If
        'must be correct format
        'Try
        '    Dim timespan_timein As TimeSpan = New TimeSpan("text")
        'Catch ex As Exception
        '    MessageBox.Show("Please provide correct time format")
        '    Exit Sub
        'End Try
        'check if exist (duplicated)
        'If exist("SELECT COUNT(id) FROM sections WHERE professor = ? AND section = ? AND subject = ? AND schedule_day = ?", New ArrayList() From {LOGIN.user_info.Rows(0)("id").ToString(), sanitize(TextBox1.Text), sanitize(TextBox2.Text), cmb_day.Text}) Then
        '    MessageBox.Show("Section already exist in your account")
        '    Exit Sub
        'End If

        Dim timein As String
        Dim timeout As String 
        Try
            timein = CDate(txt_timein.Text).ToShortTimeString()
            datetime_timein.Text = timein
        Catch ex As Exception
            MessageBox.Show("Please provide correct time for time-in")
            Exit Sub
        End Try
        Try
            timeout = CDate(txt_timeout.Text).ToShortTimeString()
            datetime_timeout.Text = timeout
        Catch ex As Exception

            MessageBox.Show("Please provide correct time for time-out")
            Exit Sub
        End Try

        If timein = timeout Then
            MessageBox.Show("Time in and time out cannot be the same value")
            Exit Sub

        End If
        If datetime_timeout.Value < datetime_timein.Value Then
            MessageBox.Show("time out must not be before time in")
            Exit Sub

        End If
        If datetime_timeout.Value >= datetime_timein.Value.AddHours(1) Then
            'allow
        Else
            MessageBox.Show("Time out must be at least 1 hour duration")
            Exit Sub
        End If
        If datetime_timeout.Value > datetime_timeout.Value.AddHours(5) Then
            MessageBox.Show("Time out must not exceed 5 hours duration")
            Exit Sub
        End If
        Dim checktimein As String = (datetime_timein.Value.AddSeconds(1)).ToString("HH:mm:ss")
        Dim checktimeout As String = (datetime_timeout.Value.AddSeconds(-1)).ToString("HH:mm:ss")
        Dim accessCode As String = txt_accessCode.Text

        'check if section schedule conflicts with existing registered section schedule
        ' time specific ranges (in between time schedule / overlapping schedule conflict checking algorithm) is not yet resolved.
        ' only specific time AND day are checked

        'room checking not part of this system's scope, it's part of an MIS of the school.
        'subject-professor checking is not part of the system's scope, it's part of an MIS of the school.
        'break schedule requirement checking is not part of the system's scope, it's part of an MIS of the school.

        ''register section
        LOGIN.database.query2("SELECT schedule.*, sections.* FROM `schedule`, sections WHERE schedule.id = sections.schedule_id AND professor_id = ? AND day = ? AND time(?) BETWEEN timein and timeout", New ArrayList() From {LOGIN.user_info.Rows(0)("id"), cmb_day.Text, checktimein})
        If (LOGIN.database.result.Rows.Count > 0) Then
            MessageBox.Show("Schedule conflict in the same day with subject: " & LOGIN.database.result(0)("subject").ToString() & " with timein of : " & DateTime.Parse(LOGIN.database.result(0)("timein").ToString()).ToString("hh:mm tt") & " and timeout of " & DateTime.Parse(LOGIN.database.result(0)("timeout").ToString()).ToString("hh:mm tt") & " under section: " & LOGIN.database.result(0)("section").ToString())
            Exit Sub
        End If
        LOGIN.database.query2("SELECT schedule.*, sections.* FROM `schedule`, sections WHERE schedule.id = sections.schedule_id AND professor_id = ? AND day = ? AND time(?) BETWEEN timein and timeout", New ArrayList() From {LOGIN.user_info.Rows(0)("id"), cmb_day.Text, checktimeout})

        If (LOGIN.database.result.Rows.Count > 0) Then
            MessageBox.Show("Schedule conflict in the same day with subject: " & LOGIN.database.result(0)("subject").ToString() & " with timein of : " & DateTime.Parse(LOGIN.database.result(0)("timein").ToString()).ToString("hh:mm tt") & " and timeout of " & DateTime.Parse(LOGIN.database.result(0)("timeout").ToString()).ToString("hh:mm tt"))
            Exit Sub
        End If

        'LOGIN.database.query2("INSERT INTO sections(section, subject, professor, professor_name, schedule_day, timein, timeout) VALUES (?,?,?,?,?,?,?)", New ArrayList() From {sanitize(TextBox1.Text), sanitize(TextBox2.Text), LOGIN.user_info.Rows(0)("id").ToString(), LOGIN.user_info.Rows(0)("username").ToString(), cmb_day.Text, timein, timeout})

        Dim _cnn As OdbcConnection = LOGIN.database.con
        Dim _cmd As New OdbcCommand("INSERT INTO  `voicecommanddb`.`schedule` (`professor_id`,`day`,`timein`,`timeout`) VALUES ( ?, ?, time(?), time(?))", _cnn)

        _cmd.Parameters.AddWithValue("", LOGIN.professor.id)
        _cmd.Parameters.AddWithValue("", cmb_day.Text)
        _cmd.Parameters.AddWithValue("", timein)
        _cmd.Parameters.AddWithValue("", timeout)
        _cmd.Parameters.AddWithValue("", accessCode)


        '_cmd.CommandText = _query
        _cmd.Connection.Open()
        _cmd.ExecuteNonQuery()


        _cmd.CommandText = "SELECT last_insert_id()"


        Dim _lastUniqueID As Integer = _cmd.ExecuteScalar()



        'LOGIN.database.query("SELECT LAST_INSERT_ID()")
        'Dim _cnn As OdbcConnection = LOGIN.database.con
        'Dim _cmd As New OdbcCommand("INSERT INTO sections(section, subject, professor, professor_name) VALUES (?,?,?,?)", _cnn)
        '_cmd.Parameters.AddWithValue("", sanitize(TextBox1.Text))
        '_cmd.Parameters.AddWithValue("", sanitize(TextBox2.Text))
        '_cmd.Parameters.AddWithValue("", LOGIN.user_info.Rows(0)("id").ToString())
        '_cmd.Parameters.AddWithValue("", LOGIN.user_info.Rows(0)("username").ToString())

        ''## -- really should name the field-name Desc to another name. Desc is a reserved word in SQL for sorting Descending (Desc = Descending) --
        '' Dim _query As String = "INSERT INTO Order(Desc, Price) VALUES('Some value for Desc', 123.45)"


        ''_cmd.CommandText = _query
        '_cmd.Connection.Open()
        '_cmd.ExecuteNonQuery()


        '_cmd.CommandText = "SELECT last_insert_id()"


        'Dim _lastUniqueID As Integer = _cmd.ExecuteScalar()


        _cmd.Connection.Close()
        LOGIN.database.query2("INSERT INTO sections(section, subject, professor, professor_name, schedule_id, access_code) VALUES (?,?,?,?,?,?)", New ArrayList() From {TextBox1.Text, TextBox2.Text, LOGIN.professor.id, LOGIN.professor.username, _lastUniqueID.ToString(), accessCode})
        MessageBox.Show("Section successfully registered!")
        Dim controls As List(Of Control) = New List(Of Control) From {TextBox1, TextBox2, cmb_day, txt_accessCode}
        strategy_input.clear(controls)

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datetime_timein.ValueChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        strategy_window.closeWindowNoPrompt(Me)

    End Sub
End Class