Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmAccount

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammaracc)
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

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                Try
                    rec.LoadGrammar(grammaracc)
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
                    rec.UnloadGrammar(grammaracc)
                Catch : End Try

                frmMenu.isActivate = True
                frmMenu.Show()

                Me.Close()
            End If
        End If
    End Sub

    Public username, password, lastname, firstname, middlename, gender As String
    Public major, year, section, subject As String
    Public daysched, dayin, dayout As String
    Dim tbl_section As New DataTable

    Sub LoadSections()
        tbl_section.Clear()
        lvSections.Items.Clear()

        sql = "SELECT * FROM tbl_schedule WHERE accountuser=?user"
        Dim sch As New MySqlCommand(sql, con)
        sch.Parameters.AddWithValue("?user", username)
        da = New MySqlDataAdapter(sch)
        da.Fill(tbl_section)

        If tbl_section.Rows.Count > 0 Then
            For a = 1 To tbl_section.Rows.Count
                Dim lv As ListViewItem = lvSections.Items.Add(tbl_section.Rows(a - 1).Item("daysched").ToString)
                lv.SubItems.Add(tbl_section.Rows(a - 1).Item("year").ToString)
                lv.SubItems.Add(tbl_section.Rows(a - 1).Item("section").ToString)
                lv.SubItems.Add(tbl_section.Rows(a - 1).Item("subject").ToString)
                lv.SubItems.Add(tbl_section.Rows(a - 1).Item("major").ToString)
                lv.SubItems.Add(tbl_section.Rows(a - 1).Item("dayin").ToString)
                lv.SubItems.Add(tbl_section.Rows(a - 1).Item("dayout").ToString)
            Next
        End If
    End Sub

    Sub LoadInfo()
        With frmMenu
            username = .username
            password = .password
            lastname = .lastname
            firstname = .firstname
            middlename = .middlename
            gender = .gender
            major = .major
            year = .year
            section = .section
            subject = .subject
            daysched = .daysched
            dayin = .dayin
            dayout = .dayout
        End With

        lblUsername.Text = username
        lblLast.Text = lastname
        lblFirst.Text = firstname
        lblMiddle.Text = middlename
        lblGender.Text = gender
        lblPassword.Text = ""

        For a = 1 To password.Length
            lblPassword.Text = lblPassword.Text & "*"
        Next
    End Sub

    Private Sub frmAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfo()

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub lblChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChange.Click
        If lblChange.Text = "Change" Then
            lblChange.Text = "Save"
            lblSection.Text = "Cancel"

            lblUsername.Visible = False
            lblPassword.Visible = False
            lblLast.Visible = False
            lblFirst.Visible = False
            lblMiddle.Visible = False

            txtFirstname.Visible = True
            txtLastname.Visible = True
            txtMiddlename.Visible = True
            txtUsername.Visible = True
            txtPassword.Visible = True
            txtRetype.Visible = True
            cmbGender.Visible = True
            lblShowPass.Visible = True
            lblShowPass.BringToFront()
            lblShowRetype.Visible = True
            lblShowRetype.BringToFront()
            Label9.Visible = True
            Label3.Visible = True

            txtFirstname.Text = firstname
            txtLastname.Text = lastname
            txtMiddlename.Text = middlename
            txtUsername.Text = username
            txtPassword.Text = password
            txtRetype.Text = password
            cmbGender.Text = gender

            txtUsername.Focus()
        Else
            CheckPersonal()
        End If
    End Sub

    Sub CheckPersonal()
        '~~> All fields must not be blank
        If txtUsername.Text = "" Then
            message = "Please enter your Username"
            MsgBox("Please enter your Username", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        If LCase(txtUsername.Text) = "voicecommand" Or LCase(txtUsername.Text) = "voice" Or LCase(txtUsername.Text) = "student" Then
            message = "Unable to use " & txtUsername.Text & " as your username"

            If isVoice = False Then
                MsgBox("Unable to use " & txtUsername.Text & " as your username", MsgBoxStyle.Information, "Create User")
            End If

            txtUsername.Focus()
            Exit Sub
        End If

        If txtPassword.Text = "" Then
            message = "Please enter your Password"
            MsgBox("Please enter your Password", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        If txtRetype.Text = "" Then
            message = "Please retype your Password"
            MsgBox("Please retype your Password", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        If txtLastname.Text = "" Then
            message = "Please enter your Lastname"
            MsgBox("Please enter your Lastname", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        If txtFirstname.Text = "" Then
            message = "Please enter your Firstname"
            MsgBox("Please enter your Firstname", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        If cmbGender.Text = "" Then
            message = "Please select your Gender"
            MsgBox("Please select your Gender", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        If Not txtPassword.Text.ToString = txtRetype.Text.ToString Then
            message = "Passwords do not match. Please try again"
            MsgBox("Passwords do not match. Please try again.", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        '~~> Check if the Username already exist
        sql = "SELECT * FROM tbl_account WHERE accountuser=?user AND (NOT accountuser=?username)"
        Dim accexist As New MySqlCommand(sql, con)
        accexist.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        accexist.Parameters.AddWithValue("?username", username)
        da = New MySqlDataAdapter(accexist)
        da.Fill(ds, "accex")

        If ds.Tables("accex").Rows.Count > 0 Then
            '~~> Username already exist
            ds.Tables("accex").Clear()

            message = "The Username that you're trying to use already exist"
            MsgBox("The Username that you're trying to use already exist", MsgBoxStyle.Information, "Change Information")
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()

            Exit Sub
        End If

        '~~> If no conflict, Update the Personal Information
        sql = "UPDATE tbl_account SET accountuser=?user, accountpass=?pass, lastname=?last, firstname=?first, middlename=?mid, gender=?gender WHERE accountuser=?username"
        Dim upacc As New MySqlCommand(sql, con)
        upacc.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upacc.Parameters.AddWithValue("?pass", txtPassword.Text.ToString)
        upacc.Parameters.AddWithValue("?last", txtLastname.Text.ToString)
        upacc.Parameters.AddWithValue("?first", txtFirstname.Text.ToString)
        upacc.Parameters.AddWithValue("?mid", txtMiddlename.Text.ToString)
        upacc.Parameters.AddWithValue("?gender", cmbGender.Text)
        upacc.Parameters.AddWithValue("?username", username)

        '~~> Update the Application
        sql = "UPDATE tbl_application SET accountuser=?user WHERE accountuser=?username"
        Dim upapp As New MySqlCommand(sql, con)
        upapp.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upapp.Parameters.AddWithValue("?username", username)

        '~~> Update the Attendance
        sql = "UPDATE tbl_attendance SET accountuser=?user WHERE accountuser=?username"
        Dim upatt As New MySqlCommand(sql, con)
        upatt.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upatt.Parameters.AddWithValue("?username", username)

        '~~> Update the Schedule
        sql = "UPDATE tbl_schedule SET accountuser=?user WHERE accountuser=?username"
        Dim upsch As New MySqlCommand(sql, con)
        upsch.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upsch.Parameters.AddWithValue("?username", username)

        '~~> Update the Student
        sql = "UPDATE tbl_student SET accountuser=?user WHERE accountuser=?username"
        Dim upstu As New MySqlCommand(sql, con)
        upstu.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upstu.Parameters.AddWithValue("?username", username)

        '~~> Update the Word
        sql = "UPDATE tbl_word SET accountuser=?user WHERE accountuser=?username"
        Dim upword As New MySqlCommand(sql, con)
        upword.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upword.Parameters.AddWithValue("?username", username)

        '~~> Update the Keyword
        sql = "UPDATE tbl_keyword SET accountuser=?user WHERE accountuser=?username"
        Dim upkeyword As New MySqlCommand(sql, con)
        upkeyword.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        upkeyword.Parameters.AddWithValue("?username", username)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        upacc.ExecuteNonQuery()
        upapp.ExecuteNonQuery()
        upatt.ExecuteNonQuery()
        upsch.ExecuteNonQuery()
        upstu.ExecuteNonQuery()
        upword.ExecuteNonQuery()
        upkeyword.ExecuteNonQuery()
        con.Close()

        message = "Successfully Updated your Account Information"
        MsgBox("Successfully Updated your Account Information", MsgBoxStyle.Information, "Account Setting")

        With frmMenu
            username = txtUsername.Text
            password = txtPassword.Text
            lastname = txtLastname.Text
            firstname = txtFirstname.Text
            middlename = txtMiddlename.Text
            gender = cmbGender.Text

            .username = txtUsername.Text
            .password = txtPassword.Text
            .lastname = txtLastname.Text
            .firstname = txtFirstname.Text
            .middlename = txtMiddlename.Text
            .gender = cmbGender.Text

            .lblUsername.Text = username
            .lblFullname.Text = lastname & ", " & firstname & " " & middlename

            lblUsername.Text = username
            lblLast.Text = lastname
            lblFirst.Text = firstname
            lblMiddle.Text = middlename
            lblGender.Text = gender

            lblPassword.Text = ""

            For a = 1 To password.Length
                lblPassword.Text = lblPassword.Text & "*"
            Next

        End With

        lblChange.Text = "Change"
        lblSection.Text = "My Sections"

        lblUsername.Visible = True
        lblPassword.Visible = True
        lblLast.Visible = True
        lblFirst.Visible = True
        lblMiddle.Visible = True
        lblGender.Visible = True

        txtFirstname.Visible = False
        txtLastname.Visible = False
        txtMiddlename.Visible = False
        txtUsername.Visible = False
        txtPassword.Visible = False
        txtRetype.Visible = False
        cmbGender.Visible = False
        lblShowPass.Visible = False
        lblShowRetype.Visible = False
        Label9.Visible = False
        Label3.Visible = False
    End Sub

    Private Sub lblChange_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChange.MouseLeave
        lblChange.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblChange_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblChange.MouseMove
        lblChange.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblSection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSection.Click
        If lblSection.Text = "My Sections" Then
            lblChange.Visible = False
            lblSection.Text = "My Information"
            MoveIndicator.Tag = "Section"
            MoveIndicator.Start()
            lblSectionSchedule.ForeColor = Color.LimeGreen
        ElseIf lblSection.Text = "My Information" Then
            lblChange.Visible = True
            lblSection.Text = "My Sections"
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()
            lblPersonal.ForeColor = Color.LimeGreen
        Else
            lblChange.Text = "Change"
            lblSection.Text = "My Sections"

            lblUsername.Visible = True
            lblPassword.Visible = True
            lblLast.Visible = True
            lblFirst.Visible = True
            lblMiddle.Visible = True

            txtFirstname.Visible = False
            txtLastname.Visible = False
            txtMiddlename.Visible = False
            txtUsername.Visible = False
            txtPassword.Visible = False
            txtRetype.Visible = False
            cmbGender.Visible = False

            lblShowPass.Visible = False
            lblShowRetype.Visible = False
            Label9.Visible = False
            Label3.Visible = False
        End If
    End Sub

    Private Sub MoveIndicator_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveIndicator.Tick
        If MoveIndicator.Tag = "Personal" Then
            lblPersonal.ForeColor = Color.LawnGreen
            lblSectionSchedule.ForeColor = Color.White

            If lblIndicator.Left > 55 Then
                lblIndicator.Left -= 10
            ElseIf lblIndicator.Left > 25 Then
                lblIndicator.Left -= 3
            Else
                MoveIndicator.Stop()
                PersonalPanel.Visible = True
                SchedulePanel.Visible = False
            End If
        Else
            lblPersonal.ForeColor = Color.White
            lblSectionSchedule.ForeColor = Color.LawnGreen

            If lblIndicator.Left < 145 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 175 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()

                LoadSections()

                PersonalPanel.Visible = False
                SchedulePanel.Visible = True
            End If
        End If
    End Sub

    Private Sub lvSections_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSections.Click
        If lvSections.Items.Count > 0 Then
            lvSections.Tag = CStr(lvSections.FocusedItem.Index)

            cmbDay.Text = lvSections.FocusedItem.Text
            cmbDay.Tag = lvSections.FocusedItem.Text
            txtYear.Text = lvSections.FocusedItem.SubItems(1).Text
            txtYear.Tag = lvSections.FocusedItem.SubItems(1).Text
            txtSection.Text = lvSections.FocusedItem.SubItems(2).Text
            txtSection.Tag = lvSections.FocusedItem.SubItems(2).Text
            txtSubject.Text = lvSections.FocusedItem.SubItems(3).Text
            txtSubject.Tag = lvSections.FocusedItem.SubItems(3).Text
            txtMajor.Text = lvSections.FocusedItem.SubItems(4).Text
            txtMajor.Tag = lvSections.FocusedItem.SubItems(4).Text
            txtIN.Text = lvSections.FocusedItem.SubItems(5).Text.Substring(0, lvSections.FocusedItem.SubItems(5).Text.Length - 3)
            txtIN.Tag = lvSections.FocusedItem.SubItems(5).Text
            txtOUT.Text = lvSections.FocusedItem.SubItems(6).Text.Substring(0, lvSections.FocusedItem.SubItems(6).Text.Length - 3)
            txtOUT.Tag = lvSections.FocusedItem.SubItems(6).Text

            If lvSections.FocusedItem.SubItems(5).Text.Substring(lvSections.FocusedItem.SubItems(5).Text.Length - 2) = "AM" Then
                cmbIN.Text = "AM"
            Else
                cmbIN.Text = "PM"
            End If

            If lvSections.FocusedItem.SubItems(6).Text.Substring(lvSections.FocusedItem.SubItems(6).Text.Length - 2) = "AM" Then
                cmbOUT.Text = "AM"
            Else
                cmbOUT.Text = "PM"
            End If
        End If
    End Sub

    Sub ForceLogoutStudent()
        sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
        Dim complist As New MySqlCommand(sql, con)
        complist.Parameters.AddWithValue("?name", My.Computer.Name)
        complist.Parameters.AddWithValue("?ip", v4())
        da = New MySqlDataAdapter(complist)
        ds.Clear()
        da.Fill(ds, "complist")

        If ds.Tables("complist").Rows.Count > 0 Then
            For a = 1 To ds.Tables("complist").Rows.Count
                sql = "INSERT INTO tbl_commandpc VALUES('" & ds.Tables("complist").Rows(a - 1).Item("computername").ToString & "','" & ds.Tables("complist").Rows(a - 1).Item("ipaddress").ToString & "','Change','')"
                Dim addchange As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addchange.ExecuteNonQuery()
                con.Close()
            Next
        End If
    End Sub

    Private Sub lvSections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub ResetFields()
        cmbDay.Text = Today.DayOfWeek.ToString
        txtIN.Text = ""
        txtOUT.Text = ""
        txtMajor.Text = ""
        txtYear.Text = ""
        txtSection.Text = ""
        txtSubject.Text = ""
    End Sub

    Dim testsection As New DataTable

    Private Sub lblAECancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAECancel.Click
        lvSections.Enabled = True
        lblAECancel.Visible = False

        lblEdit.Enabled = True
        lblDelete.Enabled = True
        lblPersonal.Enabled = True
        lblSectionSchedule.Enabled = True
        lblSection.Enabled = True

        cmbDay.Enabled = False
        txtIN.Enabled = False
        txtOUT.Enabled = False
        txtMajor.Enabled = False
        txtYear.Enabled = False
        txtSection.Enabled = False
        txtSubject.Enabled = False

        If lblAdd.Text = "Save" Then
            ResetFields()
        End If

        lblAdd.Text = "Add"
    End Sub

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        isVoice = False

        If lblAdd.Text = "Add" Then
            lvSections.Enabled = False
            lblAECancel.Visible = True

            lblEdit.Enabled = False
            lblDelete.Enabled = False
            lblPersonal.Enabled = False
            lblSectionSchedule.Enabled = False
            lblSection.Enabled = False

            cmbDay.Enabled = True
            txtIN.Enabled = True
            txtOUT.Enabled = True
            txtMajor.Enabled = True
            txtYear.Enabled = True
            txtSection.Enabled = True
            txtSubject.Enabled = True
            cmbIN.Enabled = True
            cmbOUT.Enabled = True

            lblAdd.Text = "Save"
            cmbDay.Focus()
            cmbDay.DroppedDown = True

            ResetFields()
        Else
            SaveUpdate()
        End If
    End Sub

    Sub SaveUpdate()
        '~~> Check if all the fields are not empty
        If cmbDay.Text = "" Then
            message = "Please select a Day for your Schedule"

            If isVoice = False Then
                MsgBox("Please select a Day for your Schedule", MsgBoxStyle.Information, "Account Setting")
            End If

            cmbDay.Focus()
            cmbDay.DroppedDown = True
            Exit Sub
        End If

        If txtIN.Text = "" Then
            message = "Please enter the Time In for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter the Time In for your Schedule", MsgBoxStyle.Information, "Account Setting")
            End If

            txtIN.Focus()
            Exit Sub
        End If

        If txtOUT.Text = "" Then
            message = "Please enter the Time Out for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter the Time Out for your Schedule", MsgBoxStyle.Information, "Account Setting")
            End If

            txtOUT.Focus()
            Exit Sub
        End If

        If txtYear.Text = "" Then
            message = "Please enter the Year for your Section"

            If isVoice = False Then
                MsgBox("Please enter the Year for your Section", MsgBoxStyle.Information, "Account Setting")
            End If

            txtYear.Focus()
            Exit Sub
        End If

        If txtSection.Text = "" Then
            message = "Please enter the Section"

            If isVoice = False Then
                MsgBox("Please enter the Section", MsgBoxStyle.Information, "Account Setting")
            End If

            txtSection.Focus()
            Exit Sub
        End If

        If txtSubject.Text = "" Then
            message = "Please enter the Subject for your Section"

            If isVoice = False Then
                MsgBox("Please enter the Subject for your Section", MsgBoxStyle.Information, "Account Setting")
            End If

            txtSubject.Focus()
            Exit Sub
        End If

        Dim timein, timeout As String

        '~~> Check if the Time-In and Time-Out is a valid time
        Try
            timein = CDate(txtIN.Text.ToString & " " & cmbIN.Text).ToShortTimeString
        Catch ex As Exception
            message = "Please enter a valid Time for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter a Valid Time-In for your Schedule" & vbNewLine & vbNewLine & "Example:" & vbNewLine & "12:00 | 12pm | 12:30pm", MsgBoxStyle.Information, "Account Setting")
            End If

            txtIN.Focus()
            Exit Sub
        End Try

        Try
            timeout = CDate(txtOUT.Text.ToString & " " & cmbOUT.Text).ToShortTimeString
        Catch ex As Exception
            message = "Please enter a valid Time for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter a Valid Time-Out for your Schedule" & vbNewLine & vbNewLine & "Example:" & vbNewLine & "12:00 | 12pm | 12:30pm", MsgBoxStyle.Information, "Account Setting")
            End If

            txtOUT.Focus()
            Exit Sub
        End Try

        '~~> Time-Out must be greater than Time-IN
        If CDate(timein).Hour > CDate(timeout).Hour Then
            message = "Please enter a valid time for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter a Valid Time-In and Time-Out for your Schedule." & vbNewLine & vbNewLine & "Time-Out cannot be before or equal to Time-In", MsgBoxStyle.Information, "Account Setting")
            End If

            txtIN.Focus()
            Exit Sub
        ElseIf CDate(timein).Hour = CDate(timeout).Hour Then
            If CDate(timein).Minute >= CDate(timeout).Minute Then
                message = "Please enter a valid time for your Schedule"

                If isVoice = False Then
                    MsgBox("Please enter a Valid Time-In and Time-Out for your Schedule." & vbNewLine & vbNewLine & "Time-Out cannot be before or equal to Time-In", MsgBoxStyle.Information, "Account Setting")
                End If

                txtIN.Focus()
                Exit Sub
            End If
        Else
            If DateDiff(DateInterval.Hour, CDate(timein), CDate(timeout)) < 3 Then
                message = "The minimun laboratory hours is 3 hours"

                If isVoice = False Then
                    MsgBox("The minimum Laboratory hours is 3 hours", MsgBoxStyle.Information, "Account Setting")
                End If

                txtIN.Focus()
                Exit Sub
            End If
        End If

        If CDate(timein).Hour < 7 Then
            message = "The first laboratory must not earlier than 7am"

            If isVoice = False Then
                MsgBox("The first laboratory must not earlier than 7:00 am", MsgBoxStyle.Information, "Create User")
            End If

            txtIN.Focus()
            Exit Sub
        End If

        If CDate(timeout).Hour > 21 Then
            message = "The last laboratory must not exceed 9pm"

            If isVoice = False Then
                MsgBox("The last laboratory must not exceed 9:00 pm", MsgBoxStyle.Information, "Create User")
            End If

            txtOUT.Focus()
            Exit Sub
        End If

        If lblAdd.Text = "Save" Then
            '~~> Check if the same subject with same year/section is registered
            Dim selrow() As DataRow = tbl_section.Select("subject='" & txtSubject.Text.ToString & "' AND year=" & CInt(txtYear.Text.ToString) & " AND section='" & txtSection.Text.ToString & "' AND major='" & txtMajor.Text.ToString & "'")
            If selrow.Length > 0 Then
                '~~> same subject with same year/section is already registered
                message = "The Section and Schedule that you're trying to add already exist"

                If isVoice = False Then
                    MsgBox("The Section/Schedule that you're trying to add already exist", MsgBoxStyle.Information, "Account Setting")
                End If

                txtYear.Focus()
                Exit Sub
            End If

            '~~> Check if conflict with other schedule
            For a = 1 To tbl_section.Rows.Count
                Dim hin As Integer = CDate(tbl_section.Rows(a - 1).Item("dayin").ToString).Hour
                Dim hout As Integer = CDate(tbl_section.Rows(a - 1).Item("dayout").ToString).Hour
                Dim min As Integer = CDate(tbl_section.Rows(a - 1).Item("dayin").ToString).Minute
                Dim mout As Integer = CDate(tbl_section.Rows(a - 1).Item("dayout").ToString).Minute

                If cmbDay.Text.ToString = tbl_section.Rows(a - 1).Item("daysched").ToString Then
                    If CDate(timein).Hour > hout Then
                        Continue For
                    ElseIf CDate(timein).Hour = hout Then
                        If CDate(timein).Minute >= mout Then
                            Continue For
                        End If
                    Else
                        If CDate(timeout).Hour < hin Then
                            Continue For
                        ElseIf CDate(timeout).Hour = hin Then
                            If CDate(timeout).Minute <= min Then
                                Continue For
                            End If
                        End If
                    End If

                    message = "Unable to save new section and schedule.. conflict with other section and schedule"

                    If isVoice = False Then
                        MsgBox("Unable to Save new Section/Schedule. (Conflict with other Section/Schedule)" & vbNewLine & vbNewLine & "Subject: " & tbl_section.Rows(a - 1).Item("subject").ToString & vbNewLine & "Year: " & tbl_section.Rows(a - 1).Item("year").ToString & vbNewLine & "Section: " & tbl_section.Rows(a - 1).Item("section").ToString & vbNewLine & "Day: " & tbl_section.Rows(a - 1).Item("daysched").ToString & vbNewLine & "Time: " & tbl_section.Rows(a - 1).Item("dayin").ToString & " - " & tbl_section.Rows(a - 1).Item("dayout").ToString, MsgBoxStyle.Information, "Account Setting")
                    End If

                    Exit Sub
                End If
            Next

            testsection.Clear()

            '~~> Check if conflict with other professor
            sql = "SELECT * FROM tbl_schedule WHERE daysched=?day"
            Dim sch As New MySqlCommand(sql, con)
            sch.Parameters.AddWithValue("?day", cmbDay.Text.ToString)
            da = New MySqlDataAdapter(sch)
            da.Fill(testsection)

            If testsection.Rows.Count > 0 Then
                For a = 1 To testsection.Rows.Count
                    Dim hin As Integer = CDate(testsection.Rows(a - 1).Item("dayin").ToString).Hour
                    Dim hout As Integer = CDate(testsection.Rows(a - 1).Item("dayout").ToString).Hour
                    Dim min As Integer = CDate(testsection.Rows(a - 1).Item("dayin").ToString).Minute
                    Dim mout As Integer = CDate(testsection.Rows(a - 1).Item("dayout").ToString).Minute

                    If CDate(timein).Hour > hout Then
                        Continue For
                    ElseIf CDate(timein).Hour = hout Then
                        If CDate(timein).Minute >= mout Then
                            Continue For
                        End If
                    Else
                        If CDate(timeout).Hour < hin Then
                            Continue For
                        ElseIf CDate(timeout).Hour = hin Then
                            If CDate(timeout).Minute <= min Then
                                Continue For
                            End If
                        End If
                    End If

                    message = "Unable to save new section and schedule.. conflict with other section and schedule"

                    If isVoice = False Then
                        MsgBox("Unable to Save new Section/Schedule. (Conflict with other Section/Schedule)" & vbNewLine & vbNewLine & "Subject: " & testsection.Rows(a - 1).Item("subject").ToString & vbNewLine & "Year: " & testsection.Rows(a - 1).Item("year").ToString & vbNewLine & "Section: " & testsection.Rows(a - 1).Item("section").ToString & vbNewLine & "Day: " & testsection.Rows(a - 1).Item("daysched").ToString & vbNewLine & "Time: " & testsection.Rows(a - 1).Item("dayin").ToString & " - " & testsection.Rows(a - 1).Item("dayout").ToString, MsgBoxStyle.Information, "Account Setting")
                    End If

                    Exit Sub
                Next
            End If

            '~~> This means no conflict with other schedule, therefore, add the new section
            sql = "INSERT INTO tbl_schedule VALUES(?user,?major,?year,?section,?subject,?daysched,?dayin,?dayout,?sta)"
            Dim addsch As New MySqlCommand(sql, con)
            addsch.Parameters.AddWithValue("?user", username)
            addsch.Parameters.AddWithValue("?major", txtMajor.Text.ToString)
            addsch.Parameters.AddWithValue("?year", txtYear.Text.ToString)
            addsch.Parameters.AddWithValue("?section", txtSection.Text.ToString)
            addsch.Parameters.AddWithValue("?subject", txtSubject.Text.ToString)
            addsch.Parameters.AddWithValue("?daysched", cmbDay.Text.ToString)
            addsch.Parameters.AddWithValue("?dayin", timein)
            addsch.Parameters.AddWithValue("?dayout", timeout)
            addsch.Parameters.AddWithValue("?sta", "Offline")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addsch.ExecuteNonQuery()
            con.Close()

            LoadSections()

            '~~> Enable the Controls
            lvSections.Enabled = True
            lblAECancel.Visible = False

            lblEdit.Enabled = True
            lblDelete.Enabled = True
            lblPersonal.Enabled = True
            lblSectionSchedule.Enabled = True
            lblSection.Enabled = True

            cmbDay.Enabled = False
            txtIN.Enabled = False
            txtOUT.Enabled = False
            txtMajor.Enabled = False
            txtYear.Enabled = False
            txtSection.Enabled = False
            txtSubject.Enabled = False
            cmbIN.Enabled = False
            cmbOUT.Enabled = False

            lblAdd.Text = "Add"

            ResetFields()
        Else
            '~~> Check for Conflict first

            '~~> Check if the same subject with same year/section is registered
            Dim selrow() As DataRow = tbl_section.Select("subject='" & txtSubject.Text.ToString & "' AND year=" & CInt(txtYear.Text.ToString) & " AND section='" & txtSection.Text.ToString & "' AND major='" & txtMajor.Text.ToString & "' AND (NOT subject='" & txtSubject.Tag & "') AND (NOT year=" & CInt(txtYear.Tag) & ") AND (NOT section='" & txtSection.Tag & "')")
            If selrow.Length > 0 Then
                '~~> same subject with same year/section is already registered
                message = "The section and schedule that you're trying to add already exist"

                If isVoice = False Then
                    MsgBox("The Section/Schedule that you're trying to add already exist", MsgBoxStyle.Information, "Account Setting")
                End If

                txtYear.Focus()
                Exit Sub
            End If

            '~~> Check if conflict with other schedule
            For a = 1 To tbl_section.Rows.Count
                If tbl_section.Rows(a - 1).Item("subject").ToString = txtSubject.Tag Then
                    If tbl_section.Rows(a - 1).Item("year").ToString = txtYear.Tag Then
                        If tbl_section.Rows(a - 1).Item("section").ToString = txtSection.Tag Then
                            If tbl_section.Rows(a - 1).Item("major").ToString = txtMajor.Tag Then
                                Continue For
                            End If
                        End If
                    End If
                End If

                Dim hin As Integer = CDate(tbl_section.Rows(a - 1).Item("dayin").ToString).Hour
                Dim hout As Integer = CDate(tbl_section.Rows(a - 1).Item("dayout").ToString).Hour
                Dim min As Integer = CDate(tbl_section.Rows(a - 1).Item("dayin").ToString).Minute
                Dim mout As Integer = CDate(tbl_section.Rows(a - 1).Item("dayout").ToString).Minute

                If cmbDay.Text.ToString = tbl_section.Rows(a - 1).Item("daysched").ToString Then
                    If CDate(timein).Hour > hout Then
                        Continue For
                    ElseIf CDate(timein).Hour = hout Then
                        If CDate(timein).Minute >= mout Then
                            Continue For
                        End If
                    Else
                        If CDate(timeout).Hour < hin Then
                            Continue For
                        ElseIf CDate(timeout).Hour = hin Then
                            If CDate(timeout).Minute <= min Then
                                Continue For
                            End If
                        End If
                    End If

                    message = "Unable to save new section and schedule.. conflict with other section and schedule"

                    If isVoice = False Then
                        MsgBox("Unable to Save new Section/Schedule. (Conflict with other Section/Schedule)" & vbNewLine & vbNewLine & "Subject: " & tbl_section.Rows(a - 1).Item("subject").ToString & vbNewLine & "Year: " & tbl_section.Rows(a - 1).Item("year").ToString & vbNewLine & "Section: " & tbl_section.Rows(a - 1).Item("section").ToString & vbNewLine & "Day: " & tbl_section.Rows(a - 1).Item("daysched").ToString & vbNewLine & "Time: " & tbl_section.Rows(a - 1).Item("dayin").ToString & " - " & tbl_section.Rows(a - 1).Item("dayout").ToString, MsgBoxStyle.Information, "Account Setting")
                    End If

                    Exit Sub
                End If
            Next

            testsection.Clear()

            '~~> Check if conflict with other professor
            sql = "SELECT * FROM tbl_schedule WHERE daysched=?day AND (NOT accountuser=?user)"
            Dim sch As New MySqlCommand(sql, con)
            sch.Parameters.AddWithValue("?day", cmbDay.Text.ToString)
            sch.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
            da = New MySqlDataAdapter(sch)
            da.Fill(testsection)

            If testsection.Rows.Count > 0 Then
                For a = 1 To testsection.Rows.Count
                    Dim hin As Integer = CDate(testsection.Rows(a - 1).Item("dayin").ToString).Hour
                    Dim hout As Integer = CDate(testsection.Rows(a - 1).Item("dayout").ToString).Hour
                    Dim min As Integer = CDate(testsection.Rows(a - 1).Item("dayin").ToString).Minute
                    Dim mout As Integer = CDate(testsection.Rows(a - 1).Item("dayout").ToString).Minute

                    If CDate(timein).Hour > hout Then
                        Continue For
                    ElseIf CDate(timein).Hour = hout Then
                        If CDate(timein).Minute >= mout Then
                            Continue For
                        End If
                    Else
                        If CDate(timeout).Hour < hin Then
                            Continue For
                        ElseIf CDate(timeout).Hour = hin Then
                            If CDate(timeout).Minute <= min Then
                                Continue For
                            End If
                        End If
                    End If

                    message = "Unable to save new section and schedule.. conflict with other section and schedule"

                    If isVoice = False Then
                        MsgBox("Unable to Save new Section/Schedule. (Conflict with other Section/Schedule)" & vbNewLine & vbNewLine & "Subject: " & testsection.Rows(a - 1).Item("subject").ToString & vbNewLine & "Year: " & testsection.Rows(a - 1).Item("year").ToString & vbNewLine & "Section: " & testsection.Rows(a - 1).Item("section").ToString & vbNewLine & "Day: " & testsection.Rows(a - 1).Item("daysched").ToString & vbNewLine & "Time: " & testsection.Rows(a - 1).Item("dayin").ToString & " - " & testsection.Rows(a - 1).Item("dayout").ToString, MsgBoxStyle.Information, "Account Setting")
                    End If

                    Exit Sub
                Next
            End If

            If txtMajor.Tag = major Then
                If txtYear.Tag = year Then
                    If txtSection.Tag = section Then
                        If txtSubject.Tag = subject Then
                            '~~> Currently Used Section/Schedule, therefore force change of students, section, subject, year and major
                            ForceLogoutStudent()

                            With frmMenu
                                .major = txtMajor.Text.ToString
                                .year = txtYear.Text.ToString
                                .section = txtSection.Text.ToString
                                .subject = txtSubject.Text.ToString
                                .daysched = cmbDay.Text.ToString
                                .dayin = timein
                                .dayout = timeout

                                major = txtMajor.Text.ToString
                                year = txtYear.Text.ToString
                                section = txtSection.Text.ToString
                                subject = txtSubject.Text.ToString
                                daysched = cmbDay.Text.ToString
                                dayin = timein
                                dayout = timeout

                                .lblSection.Text = UCase(major & year & section & " - " & subject)
                                .lblSchedule.Text = daysched & " | " & dayin & " - " & dayout
                            End With
                        End If
                    End If
                End If
            End If

            '~~> This means no conflict with other schedule, therefore, update the section
            sql = "UPDATE tbl_schedule SET major=?major, year=?year, section=?section, subject=?subject, daysched=?day, dayin=?dayin, dayout=?dayout WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
            Dim upsch As New MySqlCommand(sql, con)
            upsch.Parameters.AddWithValue("?major", txtMajor.Text.ToString)
            upsch.Parameters.AddWithValue("?year", txtYear.Text.ToString)
            upsch.Parameters.AddWithValue("?section", txtSection.Text.ToString)
            upsch.Parameters.AddWithValue("?subject", txtSubject.Text.ToString)
            upsch.Parameters.AddWithValue("?day", cmbDay.Text.ToString)
            upsch.Parameters.AddWithValue("?dayin", timein)
            upsch.Parameters.AddWithValue("?dayout", timeout)
            upsch.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
            upsch.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
            upsch.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
            upsch.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
            upsch.Parameters.AddWithValue("?user", username)

            '~~> Also update the Attendance
            sql = "UPDATE tbl_attendance SET major=?major, year=?year, section=?section, subject=?subject WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
            Dim upatt As New MySqlCommand(sql, con)
            upatt.Parameters.AddWithValue("?major", txtMajor.Text.ToString)
            upatt.Parameters.AddWithValue("?year", txtYear.Text.ToString)
            upatt.Parameters.AddWithValue("?section", txtSection.Text.ToString)
            upatt.Parameters.AddWithValue("?subject", txtSubject.Text.ToString)
            upatt.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
            upatt.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
            upatt.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
            upatt.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
            upatt.Parameters.AddWithValue("?user", username)

            '~~> Also update the Students
            sql = "UPDATE tbl_student SET major=?major, year=?year, section=?section, subject=?subject WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
            Dim upstud As New MySqlCommand(sql, con)
            upstud.Parameters.AddWithValue("?major", txtMajor.Text.ToString)
            upstud.Parameters.AddWithValue("?year", txtYear.Text.ToString)
            upstud.Parameters.AddWithValue("?section", txtSection.Text.ToString)
            upstud.Parameters.AddWithValue("?subject", txtSubject.Text.ToString)
            upstud.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
            upstud.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
            upstud.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
            upstud.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
            upstud.Parameters.AddWithValue("?user", username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upsch.ExecuteNonQuery()
            upatt.ExecuteNonQuery()
            upstud.ExecuteNonQuery()
            con.Close()

            LoadSections()

            message = "Successfully Updated a Schedule"

            If isVoice = False Then
                MsgBox("Successfully Updated a Schedule", MsgBoxStyle.Information, "Account Setting")
            End If

            '~~> Enable the Controls
            lvSections.Enabled = True
            lblAECancel.Visible = False

            lblEdit.Enabled = True
            lblDelete.Enabled = True
            lblPersonal.Enabled = True
            lblSectionSchedule.Enabled = True
            lblSection.Enabled = True

            cmbDay.Enabled = False
            txtIN.Enabled = False
            txtOUT.Enabled = False
            txtMajor.Enabled = False
            txtYear.Enabled = False
            txtSection.Enabled = False
            txtSubject.Enabled = False
            cmbIN.Enabled = False
            cmbOUT.Enabled = False

            lblAdd.Text = "Add"

            ResetFields()
        End If
    End Sub

    Dim isVoice As Boolean = False

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        isVoice = False

        If lvSections.Tag = "" Then
            message = "Please select a schedule from the list that you want to Edit"

            If isVoice = False Then
                MsgBox("Please select a Schedule from the List first that you want to Edit", MsgBoxStyle.Information, "Account Setting")
            End If

            Exit Sub
        End If

        lvSections.Enabled = False
        lblAECancel.Visible = True

        lblEdit.Enabled = False
        lblDelete.Enabled = False
        lblPersonal.Enabled = False
        lblSectionSchedule.Enabled = False
        lblSection.Enabled = False

        cmbDay.Enabled = True
        txtIN.Enabled = True
        txtOUT.Enabled = True
        txtMajor.Enabled = True
        txtYear.Enabled = True
        txtSection.Enabled = True
        txtSubject.Enabled = True
        cmbIN.Enabled = True
        cmbOUT.Enabled = True

        lblAdd.Text = "Update"
    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        If lvSections.Tag = "" Then
            message = "Please select a schedule from the list first that you want to Delete"
            MsgBox("Please select a Schedule from the List first that you want to Delete", MsgBoxStyle.Information, "Account Setting")
            Exit Sub
        End If

        If subject = txtSubject.Tag Then
            If year = txtYear.Tag Then
                If section = txtSection.Tag Then
                    If major = txtMajor.Tag Then
                        message = "You cannot delete the schedule you are currently using"
                        MsgBox("You cannot delete the Schedule you are currently using", MsgBoxStyle.Information, "Account Setting")
                        Exit Sub
                    End If
                End If
            End If
        End If

        message = "Press 'Yes' to delete the selected section and schedule.. and 'No' to cancel"
        If MsgBox("Are you sure you want to Delete this Section/Schedule?" & vbNewLine & vbNewLine & "Day: " & lvSections.Items(CInt(lvSections.Tag)).Text & vbNewLine & "Time: " & lvSections.Items(CInt(lvSections.Tag)).SubItems(5).Text & " - " & lvSections.Items(CInt(lvSections.Tag)).SubItems(6).Text & vbNewLine & vbNewLine & "All Information including list of students and attendance will also be deleted", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Account Setting") = MsgBoxResult.Yes Then
            '~~> Delete Section/Schedule
            sql = "DELETE FROM tbl_schedule WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
            Dim delsch As New MySqlCommand(sql, con)
            delsch.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
            delsch.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
            delsch.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
            delsch.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
            delsch.Parameters.AddWithValue("?user", username)

            '~~> Delete Attendance
            sql = "DELETE FROM tbl_attendance WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
            Dim delatt As New MySqlCommand(sql, con)
            delatt.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
            delatt.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
            delatt.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
            delatt.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
            delatt.Parameters.AddWithValue("?user", username)

            '~~> Delete Students
            sql = "DELETE FROM tbl_attendance WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
            Dim delstud As New MySqlCommand(sql, con)
            delstud.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
            delstud.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
            delstud.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
            delstud.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
            delstud.Parameters.AddWithValue("?user", username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            delsch.ExecuteNonQuery()
            delatt.ExecuteNonQuery()
            delstud.ExecuteNonQuery()
            con.Close()

            LoadSections()

            message = "Successfully Deleted a section and schedule"
            MsgBox("Successfully Deleted a Section/Schedule", MsgBoxStyle.Information, "Account Setting")

            ResetFields()
            lvSections.Tag = ""
        End If
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblSection_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSection.MouseLeave
        lblSection.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblSection_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSection.MouseMove
        lblSection.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblAECancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAECancel.MouseLeave
        lblAECancel.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAECancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAECancel.MouseMove
        lblAECancel.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblShowPass_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowPass.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub lblShowPass_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowPass.MouseLeave
        lblShowPass.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowPass_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowPass.MouseMove
        lblShowPass.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblShowPass_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowPass.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub lblShowRetype_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseDown
        txtRetype.PasswordChar = ""
    End Sub

    Private Sub lblShowRetype_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowRetype.MouseLeave
        lblShowRetype.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowRetype_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseMove
        lblShowRetype.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblShowRetype_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseUp
        txtRetype.PasswordChar = "*"
    End Sub

    Private Sub txtYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSection.Focus()
        End If
    End Sub

    Private Sub txtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRetype.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtRetype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetype.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLastname.Focus()
        End If
    End Sub

    Private Sub txtRetype_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetype.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtRetype_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtLastname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastname.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFirstname.Focus()
        End If
    End Sub

    Private Sub txtLastname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastname.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(32)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtLastname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtFirstname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFirstname.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMiddlename.Focus()
        End If
    End Sub

    Private Sub txtFirstname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstname.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(32)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtFirstname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtMiddlename_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMiddlename.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckPersonal()
        End If
    End Sub

    Private Sub txtMiddlename_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiddlename.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(32)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtMiddlename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbDay.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIN.Focus()
        End If
    End Sub

    Private Sub cmbDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDay.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbIN.Focus()
        End If
    End Sub

    Private Sub txtIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIN.KeyPress
        Select Case e.KeyChar
            Case ChrW(32)
            Case ChrW(8)
            Case ChrW(48) To ChrW(58)
            Case ChrW(65)
            Case ChrW(77)
            Case ChrW(80)
            Case ChrW(109)
            Case ChrW(112)
            Case ChrW(97)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtIN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOUT.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbOUT.Focus()
        End If
    End Sub

    Private Sub txtOUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUT.KeyPress
        Select Case e.KeyChar
            Case ChrW(32)
            Case ChrW(8)
            Case ChrW(48) To ChrW(58)
            Case ChrW(65)
            Case ChrW(77)
            Case ChrW(80)
            Case ChrW(109)
            Case ChrW(112)
            Case ChrW(97)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtOUT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtMajor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMajor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtYear.Focus()
        End If
    End Sub

    Private Sub txtMajor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMajor.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtMajor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSection.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSubject.Focus()
        End If
    End Sub

    Private Sub txtSection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSection.KeyPress
        Select Case e.KeyChar
            Case ChrW(32)
            Case ChrW(8)
            Case ChrW(48) To ChrW(58)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtSection_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSubject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubject.KeyDown
        If e.KeyCode = Keys.Enter Then
            isVoice = False

            SaveUpdate()
        End If
    End Sub

    Private Sub txtSubject_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubject.KeyPress
        Select Case e.KeyChar
            Case ChrW(32)
            Case ChrW(8)
            Case ChrW(48) To ChrW(58)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(40)
            Case ChrW(41)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtMajor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMajor.SelectedIndexChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammaracc)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "change" Then
            If lblChange.Visible = True Then
                If lblChange.Text = "Change" Then
                    message = "Change Information"

                    lblChange.Text = "Save"
                    lblSection.Text = "Cancel"

                    lblUsername.Visible = False
                    lblPassword.Visible = False
                    lblLast.Visible = False
                    lblFirst.Visible = False
                    lblMiddle.Visible = False

                    txtFirstname.Visible = True
                    txtLastname.Visible = True
                    txtMiddlename.Visible = True
                    txtUsername.Visible = True
                    txtPassword.Visible = True
                    txtRetype.Visible = True
                    cmbGender.Visible = True
                    lblShowPass.Visible = True
                    lblShowPass.BringToFront()
                    lblShowRetype.Visible = True
                    lblShowRetype.BringToFront()
                    Label9.Visible = True

                    txtFirstname.Text = firstname
                    txtLastname.Text = lastname
                    txtMiddlename.Text = middlename
                    txtUsername.Text = username
                    txtPassword.Text = password
                    txtRetype.Text = password
                    cmbGender.Text = gender

                    txtUsername.Focus()
                End If
            End If
        ElseIf e.Result.Text = "save" Then
            If lblChange.Visible = True Then
                If lblChange.Text = "Save" Then
                    isVoice = True

                    CheckPersonal()
                End If

                Exit Sub
            End If

            If SchedulePanel.Visible = True Then
                If lblAdd.Text = "Save" Then
                    isVoice = True

                    SaveUpdate()
                End If
            End If
        ElseIf e.Result.Text = "cancel" Then
            If lblSection.Text = "Cancel" Then
                message = "Cancel"

                lblChange.Text = "Change"
                lblSection.Text = "My Sections"

                lblUsername.Visible = True
                lblPassword.Visible = True
                lblLast.Visible = True
                lblFirst.Visible = True
                lblMiddle.Visible = True

                txtFirstname.Visible = False
                txtLastname.Visible = False
                txtMiddlename.Visible = False
                txtUsername.Visible = False
                txtPassword.Visible = False
                txtRetype.Visible = False
                cmbGender.Visible = False

                lblShowPass.Visible = False
                lblShowRetype.Visible = False
                Label9.Visible = False

                Exit Sub
            End If

            If lblAECancel.Visible = True Then
                message = "cancel"

                lvSections.Enabled = True
                lblAECancel.Visible = False

                lblEdit.Enabled = True
                lblDelete.Enabled = True
                lblPersonal.Enabled = True
                lblSectionSchedule.Enabled = True
                lblSection.Enabled = True

                cmbDay.Enabled = False
                txtIN.Enabled = False
                txtOUT.Enabled = False
                txtMajor.Enabled = False
                txtYear.Enabled = False
                txtSection.Enabled = False
                txtSubject.Enabled = False

                If lblAdd.Text = "Save" Then
                    ResetFields()
                End If

                lblAdd.Text = "Add"
            End If
        ElseIf e.Result.Text = "Add" Then
            If SchedulePanel.Visible = True Then
                If lblAdd.Text = "Add" Then
                    message = "Add"

                    lvSections.Enabled = False
                    lblAECancel.Visible = True

                    lblEdit.Enabled = False
                    lblDelete.Enabled = False
                    lblPersonal.Enabled = False
                    lblSectionSchedule.Enabled = False
                    lblSection.Enabled = False

                    cmbDay.Enabled = True
                    txtIN.Enabled = True
                    txtOUT.Enabled = True
                    txtMajor.Enabled = True
                    txtYear.Enabled = True
                    txtSection.Enabled = True
                    txtSubject.Enabled = True
                    cmbIN.Enabled = True
                    cmbOUT.Enabled = True

                    lblAdd.Text = "Save"
                    cmbDay.Focus()
                    cmbDay.DroppedDown = True

                    ResetFields()
                End If
            End If
        ElseIf e.Result.Text = "Edit" Then
            If lblEdit.Visible = True Then
                If lvSections.Tag = "" Then
                    message = "Please select a schedule from the list that you want to Edit"

                    Exit Sub
                End If

                message = "Edit"

                lvSections.Enabled = False
                lblAECancel.Visible = True

                lblEdit.Enabled = False
                lblDelete.Enabled = False
                lblPersonal.Enabled = False
                lblSectionSchedule.Enabled = False
                lblSection.Enabled = False

                cmbDay.Enabled = True
                txtIN.Enabled = True
                txtOUT.Enabled = True
                txtMajor.Enabled = True
                txtYear.Enabled = True
                txtSection.Enabled = True
                txtSubject.Enabled = True
                cmbIN.Enabled = True
                cmbOUT.Enabled = True

                lblAdd.Text = "Update"
            End If
        ElseIf e.Result.Text = "Delete" Then
            If lblDelete.Visible = True Then
                If lvSections.Tag = "" Then
                    message = "Please select a schedule from the list first that you want to Delete"

                    Exit Sub
                End If

                If subject = txtSubject.Tag Then
                    If year = txtYear.Tag Then
                        If section = txtSection.Tag Then
                            If major = txtMajor.Tag Then
                                message = "You cannot delete the schedule you are currently using"

                                Exit Sub
                            End If
                        End If
                    End If
                End If

                '~~> Delete Section/Schedule
                sql = "DELETE FROM tbl_schedule WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
                Dim delsch As New MySqlCommand(sql, con)
                delsch.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
                delsch.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
                delsch.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
                delsch.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
                delsch.Parameters.AddWithValue("?user", username)

                '~~> Delete Attendance
                sql = "DELETE FROM tbl_attendance WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
                Dim delatt As New MySqlCommand(sql, con)
                delatt.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
                delatt.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
                delatt.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
                delatt.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
                delatt.Parameters.AddWithValue("?user", username)

                '~~> Delete Students
                sql = "DELETE FROM tbl_student WHERE major=?ma AND year=?ye AND section=?se AND subject=?su AND accountuser=?user"
                Dim delstud As New MySqlCommand(sql, con)
                delstud.Parameters.AddWithValue("?ma", txtMajor.Tag.ToString)
                delstud.Parameters.AddWithValue("?ye", txtYear.Tag.ToString)
                delstud.Parameters.AddWithValue("?se", txtSection.Tag.ToString)
                delstud.Parameters.AddWithValue("?su", txtSubject.Tag.ToString)
                delstud.Parameters.AddWithValue("?user", username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delsch.ExecuteNonQuery()
                delatt.ExecuteNonQuery()
                delstud.ExecuteNonQuery()
                con.Close()

                LoadSections()

                message = "Successfully Deleted a section and schedule"

                ResetFields()
                lvSections.Tag = ""
            End If
        End If
    End Sub

    Private Sub cmbDay_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDay.SelectedIndexChanged

    End Sub

    Private Sub cmbIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOUT.Focus()
        End If
    End Sub

    Private Sub cmbIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIN.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOUT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMajor.Focus()
        End If
    End Sub

    Private Sub cmbOUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOUT.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.TextChanged

    End Sub
End Class