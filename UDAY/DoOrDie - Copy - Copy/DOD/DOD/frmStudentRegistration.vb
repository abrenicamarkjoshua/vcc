Imports MySql.Data.MySqlClient

Public Class frmStudentRegistration
    Public major, year, section, subject, user As String
    Public daysched, dayin, dayout As String

    Private Sub frmStudentRegistration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

    End Sub

    Private Sub frmStudentRegistration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isClose = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmStudentRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblUser.Text = user
        lblSection.Text = UCase(major) & year & UCase(section) & " - " & subject
        lblSchedule.Text = daysched & " | " & dayin & "-" & dayout

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Sub ClearFields()
        txtStudentid.Text = ""
        txtLastname.Text = ""
        txtFirstname.Text = ""
        txtMiddlename.Text = ""
        txtPassword.Text = ""
        txtRetype.Text = ""
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                ClearFields()

                CheckServer.Start()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                frmLock.Animation.Tag = "Show"
                frmLock.Animation.Start()

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblShowPassword_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowPassword.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub lblShowPassword_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowPassword.MouseLeave
        lblShowPassword.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowPassword_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowPassword.MouseMove
        lblShowPassword.BackColor = Color.FromArgb(0, 64, 102)
    End Sub

    Private Sub lblShowPassword_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowPassword.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub lblShowRetype_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseDown
        txtRetype.PasswordChar = ""
    End Sub

    Private Sub lblShowRetype_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowRetype.MouseLeave
        lblShowRetype.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowRetype_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseMove
        lblShowRetype.BackColor = Color.FromArgb(0, 64, 102)
    End Sub

    Private Sub lblShowRetype_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseUp
        txtRetype.PasswordChar = "*"
    End Sub

    Dim isClose As Boolean = False

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        isClose = True
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

    Private Sub lblClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClear.Click
        ClearFields()
    End Sub

    Private Sub lblClear_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClear.MouseLeave
        lblClear.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblClear_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClear.MouseMove
        lblClear.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Sub SaveStudent()
        If txtStudentid.Text = "" Then
            message = "Please enter the Student ID of the Student"
            MsgBox("Please enter the Student ID of the Student", MsgBoxStyle.Information, "Student Registration")

            txtStudentid.Focus()
            Exit Sub
        End If

        If txtStudentid.Text.Length < 7 Then
            message = "Please enter a valid Student ID of the Student"
            MsgBox("Please enter a valid Student ID of the Student", MsgBoxStyle.Information, "Student Registration")

            txtStudentid.Focus()
            Exit Sub
        End If

        If Trim(txtLastname.Text) = "" Then
            message = "Please enter the Last Name of the Student"
            MsgBox("Please enter the Last Name of the Student", MsgBoxStyle.Information, "Student Registration")

            txtLastname.Focus()
            Exit Sub
        End If

        If Trim(txtFirstname.Text) = "" Then
            message = "Please enter the First Name of the Student"
            MsgBox("Please enter the First Name of the Student", MsgBoxStyle.Information, "Student Registration")

            txtFirstname.Focus()
            Exit Sub
        End If

        If Trim(txtPassword.Text) = "" Then
            message = "Please enter the Password of the Student"
            MsgBox("Please enter the Password of the Student", MsgBoxStyle.Information, "Student Registration")

            txtPassword.Focus()
            Exit Sub
        End If

        If Trim(txtRetype.Text) = "" Then
            message = "Please retype the Password of the Student"
            MsgBox("Please retype the Password of the Student", MsgBoxStyle.Information, "Student Registration")

            txtRetype.Focus()
            Exit Sub
        End If

        If Not LCase(txtPassword.Text) = LCase(txtRetype.Text) Then
            message = "Passwords do not match.. Please try again"
            MsgBox("Passwords do not match.. Please try again", MsgBoxStyle.Information, "Student Registration")

            txtPassword.Focus()
            Exit Sub
        End If

        sql = "SELECT * FROM tbl_student WHERE studentid=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
        Dim exstud As New MySqlCommand(sql, con)
        exstud.Parameters.AddWithValue("?id", txtStudentid.Text)
        exstud.Parameters.AddWithValue("?major", major)
        exstud.Parameters.AddWithValue("?year", year)
        exstud.Parameters.AddWithValue("?section", section)
        exstud.Parameters.AddWithValue("?subject", subject)
        exstud.Parameters.AddWithValue("?user", user)
        da = New MySqlDataAdapter(exstud)
        ds.Clear()
        da.Fill(ds, "ex")

        If ds.Tables("ex").Rows.Count > 0 Then
            ds.Tables("ex").Clear()

            message = "The Student ID that you're trying to use already exist"
            MsgBox("The Student ID that you're trying to use already exist", MsgBoxStyle.Information, "Student Registration")

            txtStudentid.Focus()
            Exit Sub
        End If

        sql = "INSERT INTO tbl_student VALUES(?id,?last,?first,?mid,?major,?year,?section,?subject,?pass,?user,?status)"
        Dim addstud As New MySqlCommand(sql, con)
        addstud.Parameters.AddWithValue("?id", txtStudentid.Text)
        addstud.Parameters.AddWithValue("?last", FormatName(txtLastname.Text))
        addstud.Parameters.AddWithValue("?first", FormatName(txtFirstname.Text))
        addstud.Parameters.AddWithValue("?mid", FormatName(txtMiddlename.Text))
        addstud.Parameters.AddWithValue("?major", major)
        addstud.Parameters.AddWithValue("?year", year)
        addstud.Parameters.AddWithValue("?section", section)
        addstud.Parameters.AddWithValue("?subject", subject)
        addstud.Parameters.AddWithValue("?pass", LCase(txtPassword.Text))
        addstud.Parameters.AddWithValue("?user", user)
        addstud.Parameters.AddWithValue("?status", "Offline")

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        addstud.ExecuteNonQuery()
        con.Close()

        txtStudentid.Focus()

        message = "Student Account successfully registered"
        MsgBox("Student Account successfully registered", MsgBoxStyle.Information, "Student Registration")

        ClearFields()
    End Sub

    Private Function FormatName(ByVal name As String)
        Dim formatted As String = ""
        Dim newname As String = name.Replace(" ", "@")
        Dim nameinfo() As String = newname.Split("@")

        For a = 1 To nameinfo.Length
            If nameinfo(a - 1) = "" Then
                Continue For
            Else
                formatted = formatted & UCase(nameinfo(a - 1).Substring(0, 1)) & LCase(nameinfo(a - 1).Substring(1))
            End If
        Next

        Return formatted
    End Function

    Private Sub lblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSave.Click
        SaveStudent()
    End Sub

    Private Sub lblSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSave.MouseLeave
        lblSave.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSave.MouseMove
        lblSave.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub CheckServer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckServer.Tick
        sql = "SELECT * FROM tbl_schedule WHERE status='Online'"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "schinfo")

        If ds.Tables("schinfo").Rows.Count > 0 Then
            '~~> Get the Information of the Online Schedule
            servercount = 0

            user = ds.Tables("schinfo").Rows(0).Item("accountuser").ToString
            major = ds.Tables("schinfo").Rows(0).Item("major").ToString
            year = ds.Tables("schinfo").Rows(0).Item("year").ToString
            section = ds.Tables("schinfo").Rows(0).Item("section").ToString
            subject = ds.Tables("schinfo").Rows(0).Item("subject").ToString
            daysched = ds.Tables("schinfo").Rows(0).Item("daysched").ToString
            dayin = ds.Tables("schinfo").Rows(0).Item("dayin").ToString
            dayout = ds.Tables("schinfo").Rows(0).Item("dayout").ToString

            sql = "SELECT * FROM tbl_account WHERE accountuser=?user"
            Dim accinfo As New MySqlCommand(sql, con)
            accinfo.Parameters.AddWithValue("?user", user)
            da = New MySqlDataAdapter(accinfo)
            ds.Clear()
            da.Fill(ds, "accinfo")

            If ds.Tables("accinfo").Rows.Count > 0 Then
                lblFullname.Text = ds.Tables("accinfo").Rows(0).Item("firstname").ToString & " " & ds.Tables("accinfo").Rows(0).Item("lastname").ToString
                lblUser.Text = user
                lblSection.Text = UCase(major) & year & UCase(section) & " - " & subject
                lblSchedule.Text = daysched & " | " & dayin & "-" & dayout
            End If
        Else
            '~~> No Online Schedule Detected, therefore Back to Lock Screen
            If servercount = 100 Then
                CheckServer.Stop()

                Animation.Tag = "Hide"
                Animation.Start()
            Else
                servercount += 1
            End If
        End If
    End Sub

    Dim servercount As Integer = 0

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

    Private Sub txtLastname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLastname.TextChanged

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

    Private Sub txtFirstname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstname.TextChanged

    End Sub

    Private Sub txtMiddlename_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMiddlename.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
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

    Private Sub txtMiddlename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMiddlename.TextChanged

    End Sub

    Private Sub txtStudentid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtStudentid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtLastname.Focus()
        End If
    End Sub

    Private Sub txtStudentid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(45)
                If InStr("-", txtStudentid.Text) Then
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtStudentid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtRetype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetype.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveStudent()
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

    Private Sub txtRetype_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetype.TextChanged

    End Sub

    Private Sub txtStudentid_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentid.GotFocus

    End Sub

    Private Sub txtStudentid_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStudentid.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLastname.Focus()
        End If
    End Sub

    Private Sub txtStudentid_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStudentid.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtStudentid_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtStudentid.MaskInputRejected

    End Sub

End Class