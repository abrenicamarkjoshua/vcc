

Public Class DEFAULT_STUDENT
    Public is_client As Boolean = True
    Private Sub refreshSubjectLists()
      
    End Sub
    Private Sub refresh_lists()
        'load all professor's sections
        listview_sections.Items.Clear()
        If IsNothing(LOGIN.professor) Then
            Exit Sub
        End If
        LOGIN.database.query2("SELECT sections.*, sections.id as TblSections_id, schedule.*, schedule.id as TblSchedule_id FROM sections, schedule WHERE sections.schedule_id = schedule.id AND sections.professor = ?", New ArrayList() From {LOGIN.professor.id})
        Dim dt_section As DataTable

        dt_section = LOGIN.database.result
        For i As Integer = 0 To dt_section.Rows.Count - 1
            listview_sections.Items.Add(dt_section.Rows(i)("section").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("subject").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("day").ToString())
            listview_sections.Items(i).SubItems.Add(DateTime.Parse(dt_section.Rows(i)("timein").ToString()).ToString("hh:mm tt"))
            listview_sections.Items(i).SubItems.Add(DateTime.Parse(dt_section.Rows(i)("timeout").ToString()).ToString("hh:mm tt"))
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("professor_name").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("TblSections_id").ToString())
        Next
    End Sub
    Private Sub DEFAULT_STUDENT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Panel1.Left = (Me.Width - Panel1.Width) / 2
        'Panel1.Top = (Me.Height - Panel1.Height) / 2

        'lblSection.Text = LOGIN.section
        'lblSubject.Text = LOGIN.subj
        'lblUsername.Text = LOGIN.username
        'If is_client = False Then
        '    lblUsername.Text = LOGIN.user_info.Rows(0)("username").ToString()
        'End If
        controllers_and_functions.add_enter_events(Me)
        If IsNothing(LOGIN.professor) Then
            Panel3.Hide()
            Panel1.Left = (Me.Width - Panel1.Width) / 2
            Panel1.Top = (Me.Height - Panel1.Height) / 2
        Else

           

            'lblSection.Text = LOGIN.section
            'lblSubject.Text = LOGIN.subj
            'lblUsername.Text = LOGIN.username
            'If is_client = False Then
            '    lblUsername.Text = LOGIN.user_info.Rows(0)("username").ToString()
            'End If
            If IsNothing(LOGIN.student) Then
                refresh_lists()
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        If IsNothing(LOGIN.professor) Then
            LOGIN.Show()
        End If

    End Sub



    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        'CHECK FOR BLANK FIELDS
        If has_blanks("all", New List(Of Control) From {txt_student_number, txt_fname, txt_lname, txt_password, txt_password2}) Then
            Exit Sub
        End If

        'CHECK IF PASSWORD DOENS'T MATCH
        If txt_password2.Text <> txt_password.Text Then
            MessageBox.Show("Passwords must match")
            Exit Sub
        End If
        Dim student_name As String = sanitize(txt_lname.Text + ", " + txt_fname.Text + " " + txt_mi.Text)

        ''CHECK IF STUDENT ALREADY EXIST
        If exist("SELECT COUNT(student_id) FROM students WHERE student_id = ? AND lastname = ? AND firstname = ? AND middle_initial = ?", New ArrayList() From {sanitize(txt_student_number.Text), sanitize(txt_lname.Text), sanitize(txt_fname.Text), sanitize(txt_mi.Text)}) Then
            MessageBox.Show("Student already exist")
            Exit Sub
        End If

        'check if student number already exist
        If exist("SELECT COUNT(student_id) FROM students WHERE student_id = ?", New ArrayList() From {sanitize(txt_student_number.Text)}) Then
            MessageBox.Show("Student number already exist")
            Exit Sub
        End If
        'CHECK IF STUDENT ALREADY EXIST. Version 2
        'If exist("SELECT COUNT(student_id) FROM student_section WHERE student_id = ? AND section = ? AND subject = ? AND professor_name = ?", New ArrayList() From {sanitize(txt_student_number.Text), lblSection.Text, lblSubject.Text, lblUsername.Text}) Then
        '    MessageBox.Show("Student already exist")
        '    Exit Sub
        'End If

        'ELSE, REGISTER
        LOGIN.database.query2("INSERT INTO `voicecommanddb`.`students` (`student_id`, `student_name`, `login_status`, `lastname`, `firstname`, `middle_initial`, `password`) VALUES (?,?,?,?,?,?,?)", New ArrayList() From {sanitize(txt_student_number.Text), student_name, "registered", sanitize(txt_lname.Text), sanitize(txt_fname.Text), sanitize(txt_mi.Text), hash(txt_password.Text, 20)})

        'LOGIN.database.query2("INSERT INTO `voicecommanddb`.`student_section` (`student_id`,`section`,`subject`,`professor_name`, `lastname`, `firstname`, `middle_initial`, `student_name`,`password`) VALUES(?,?,?,?,?,?,?,?,LEFT(SHA1(?),20))", New ArrayList() From {sanitize(txt_student_number.Text), lblSection.Text, lblSubject.Text, lblUsername.Text, sanitize(txt_lname.Text), sanitize(txt_fname.Text), sanitize(txt_mi.Text), student_name, txt_password.Text})

        'If is_client = False Then
        '    MessageBox.Show("Student successfully registered.")
        '    txt_fname.Text = ""
        '    txt_lname.Text = ""
        '    txt_mi.Text = ""
        '    txt_password.Text = ""
        '    txt_password2.Text = ""
        '    txt_student_number.Text = ""
        '    Exit Sub

        'End If
        If String.IsNullOrEmpty(LOGIN.database.db_error) Then
            MessageBox.Show("Student successfully registered. Please log in")

        End If

        'if it's student
        If IsNothing(LOGIN.professor) Then
            Me.Close()
            LOGIN.Show()

        Else
            txt_fname.Text = ""
            txt_lname.Text = ""
            txt_mi.Text = ""
            txt_password.Text = ""
            txt_password2.Text = ""
            txt_student_number.Text = ""

        End If


    End Sub

    Private Sub txt_set_server_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.Save()

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As AddStudentToSection = New AddStudentToSection()

        form.ShowDialog()
        form.Dispose()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub
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
            listview_sections.Items(i).SubItems.Add(dt.Rows(i)("professor_name").ToString())
        Next
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim studentnumber As String = txt_studentNumber.Text

        If listview_sections.SelectedItems.Count = 0 Then

            MessageBox.Show("Please select a section from the list")
            Exit Sub

        End If
        If String.IsNullOrEmpty(txt_studentNumber.Text) Then
            MessageBox.Show("Student number must not be empty")
            Exit Sub
        End If

        'check if student number exist
        If exist("SELECT COUNT(student_id) FROM students WHERE student_id = ?", New ArrayList() From {studentnumber}) = False Then
            MessageBox.Show("Student does not exist")
            Exit Sub

        End If

        'check if student exist in that subject schedule
        If (LOGIN.database.exist("SELECT COUNT(id) FROM student_section WHERE student_id = ? AND section = ? AND subject = ? AND day = ? AND timein = time(?) AND timeout = time(?) AND professor_name = ?", New ArrayList() From {
                                 studentnumber, listview_sections.SelectedItems(0).SubItems(0).Text, listview_sections.SelectedItems(0).SubItems(1).Text, listview_sections.SelectedItems(0).SubItems(2).Text, listview_sections.SelectedItems(0).SubItems(3).Text, listview_sections.SelectedItems(0).SubItems(4).Text, listview_sections.SelectedItems(0).SubItems(5).Text})) Then
            MessageBox.Show("Student already registered")
            Exit Sub
        End If

        'check if it conflicts with other schedules
        Dim checktimein As String = datetime_timein.Value.AddSeconds(1).ToString("HH:mm:ss")
        Dim checktimeout As String = datetime_timeout.Value.AddSeconds(-1).ToString("HH:mm:ss")
        LOGIN.database.query2("SELECT * from student_section  WHERE student_id = ? AND day = ? AND time(?) BETWEEN timein and timeout",
                              New ArrayList() From {studentnumber, listview_sections.SelectedItems(0).SubItems(2).Text, checktimein})
        If (LOGIN.database.result.Rows.Count > 0) Then
            MessageBox.Show("Schedule conflict in the same day with subject: " & LOGIN.database.result(0)("subject").ToString() & " with timein of : " & DateTime.Parse(LOGIN.database.result(0)("timein").ToString()).ToString("hh:mm tt") & " and timeout of " & DateTime.Parse(LOGIN.database.result(0)("timeout").ToString()).ToString("hh:mm tt") & " under section: " & LOGIN.database.result(0)("section").ToString())
            Exit Sub
        End If

        LOGIN.database.query2("SELECT * from student_section WHERE student_id = ? AND day = ? AND time(?) BETWEEN timein and timeout",
                              New ArrayList() From {studentnumber, listview_sections.SelectedItems(0).SubItems(2).Text, checktimeout})
        If (LOGIN.database.result.Rows.Count > 0) Then
            MessageBox.Show("Schedule conflict in the same day with subject: " & LOGIN.database.result(0)("subject").ToString() & " with timein of : " & DateTime.Parse(LOGIN.database.result(0)("timein").ToString()).ToString("hh:mm tt") & " and timeout of " & DateTime.Parse(LOGIN.database.result(0)("timeout").ToString()).ToString("hh:mm tt"))
            Exit Sub
        End If

        'register

        LOGIN.database.query2("INSERT INTO student_section(`student_id`,`section`,`subject`,`day`,`timein`,`timeout`,`professor_name`) VALUES (?,?,?,?,time(?),time(?),?)", New ArrayList() From {studentnumber, listview_sections.SelectedItems(0).SubItems(0).Text, listview_sections.SelectedItems(0).SubItems(1).Text, listview_sections.SelectedItems(0).SubItems(2).Text, listview_sections.SelectedItems(0).SubItems(3).Text, listview_sections.SelectedItems(0).SubItems(4).Text, listview_sections.SelectedItems(0).SubItems(5).Text})
        prompt.message("student successfully added!")

        refreshSubjectLists()
        txt_studentNumber.Text = ""
    End Sub

    Private Sub listview_sections_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_sections.Click
        datetime_timein.Text = listview_sections.SelectedItems(0).SubItems(3).Text
        datetime_timeout.Text = listview_sections.SelectedItems(0).SubItems(4).Text

    End Sub

    Private Sub listview_sections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_sections.SelectedIndexChanged

    End Sub
End Class