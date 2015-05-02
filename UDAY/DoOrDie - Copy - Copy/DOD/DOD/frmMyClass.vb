Imports MySql.Data.MySqlClient

Public Class frmMyClass
    Public major, year, section, subject As String

    Private Sub frmMyClass_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Dim isLogin As Boolean = False

    Private Sub frmMyClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With frmMenu
            major = .major
            year = .year
            section = .section
            subject = .subject

            lblSection.Text = .lblSection.Text
        End With

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public Sub LoadStudents()
        sql = "SELECT * FROM tbl_student WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user ORDER BY studentlname ASC"
        Dim selstud As New MySqlCommand(sql, con)
        selstud.Parameters.AddWithValue("?major", major)
        selstud.Parameters.AddWithValue("?year", year)
        selstud.Parameters.AddWithValue("?section", section)
        selstud.Parameters.AddWithValue("?subject", subject)
        selstud.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(selstud)
        da.Fill(ds, "stud")

        If ds.Tables("stud").Rows.Count > 0 Then
            If Not ds.Tables("stud").Rows.Count = lvAttendance.Items.Count Then
                lvAttendance.Items.Clear()
                lblCount.Text = ds.Tables("stud").Rows.Count

                For a = 1 To ds.Tables("stud").Rows.Count
                    Dim lv As ListViewItem = lvAttendance.Items.Add(ds.Tables("stud").Rows(a - 1).Item("studentid").ToString)
                    lv.SubItems.Add(ds.Tables("stud").Rows(a - 1).Item("studentlname").ToString & ", " & ds.Tables("stud").Rows(a - 1).Item("studentfname").ToString & " " & ds.Tables("stud").Rows(a - 1).Item("studentmname").ToString)
                    lv.SubItems.Add(ds.Tables("stud").Rows(a - 1).Item("studentlname").ToString)
                    lv.SubItems.Add(ds.Tables("stud").Rows(a - 1).Item("studentfname").ToString)
                    lv.SubItems.Add(ds.Tables("stud").Rows(a - 1).Item("studentmname").ToString)
                    lv.SubItems.Add(ds.Tables("stud").Rows(a - 1).Item("studentpass").ToString)
                    lv.SubItems.Add(ds.Tables("stud").Rows(a - 1).Item("status").ToString)
                Next

                ds.Tables("stud").Clear()
            End If
        Else
            lvAttendance.Items.Clear()
        End If
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadStudents()

                Try
                    rec.LoadGrammar(grammarclass)
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

                LoadStud.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarclass)
                Catch : End Try

                frmMenu.isActivate = True
                frmMenu.Show()

                Me.Close()
            End If
        End If
    End Sub

    Private Sub LoadStud_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadStud.Tick
        LoadStudents()
    End Sub

    Private Sub lvAttendance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAttendance.Click
        If lvAttendance.Items.Count > 0 Then
            txtStudentid.Text = lvAttendance.FocusedItem.Text
            txtStudentid.Tag = lvAttendance.FocusedItem.Text
            txtLastname.Text = lvAttendance.FocusedItem.SubItems(2).Text
            txtFirstname.Text = lvAttendance.FocusedItem.SubItems(3).Text
            txtMiddlename.Text = lvAttendance.FocusedItem.SubItems(4).Text
            txtPassword.Text = lvAttendance.FocusedItem.SubItems(5).Text
            txtPassword.Tag = lvAttendance.FocusedItem.SubItems(5).Text

            If lvAttendance.FocusedItem.SubItems(6).Text = "Offline" Then
                isLogin = False
            Else
                isLogin = True
            End If
        End If
    End Sub

    Private Sub lvAttendance_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAttendance.SelectedIndexChanged

    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        If lblDelete.Text = "Delete" Then
            If txtStudentid.Text = "" Then
                message = "Please select a student that you want to Delete"

                Exit Sub
            End If

            sql = "DELETE FROM tbl_student WHERE studentid=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
            Dim delstud As New MySqlCommand(sql, con)
            delstud.Parameters.AddWithValue("?id", txtStudentid.Tag)
            delstud.Parameters.AddWithValue("?major", major)
            delstud.Parameters.AddWithValue("?year", year)
            delstud.Parameters.AddWithValue("?section", section)
            delstud.Parameters.AddWithValue("?subject", subject)
            delstud.Parameters.AddWithValue("?user", frmMenu.username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            delstud.ExecuteNonQuery()
            con.Close()

            message = "Successfully Deleted a Student"

            txtStudentid.Text = ""
            txtStudentid.Tag = ""
            txtLastname.Text = ""
            txtFirstname.Text = ""
            txtMiddlename.Text = ""
            txtPassword.Text = ""
            txtPassword.Tag = ""
            txtRetype.Text = ""

            LoadStudents()
        Else
            lblAdd.Text = "Add"
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lvAttendance.Enabled = True
            lblView.Enabled = True
            lblActivity.Enabled = True
            lblExport.Enabled = True
            lblLogout.Enabled = True

            txtStudentid.Enabled = False
            txtLastname.Enabled = False
            txtFirstname.Enabled = False
            txtMiddlename.Enabled = False
            txtPassword.Enabled = False
            txtRetype.Visible = False
            txtRetype.Text = ""
            Label9.Visible = False
        End If
    End Sub

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        If lblEdit.Text = "Edit" Then
            If txtStudentid.Text = "" Then
                message = "Please select a student that you want to Edit"

                Exit Sub
            End If

            lblEdit.Text = "Update"
            lblDelete.Text = "Cancel"

            lblAdd.Enabled = False
            lvAttendance.Enabled = False
            lblView.Enabled = False
            lblExport.Enabled = False
            lblLogout.Enabled = False
            lblActivity.Enabled = False

            txtStudentid.Enabled = True
            txtLastname.Enabled = True
            txtFirstname.Enabled = True
            txtMiddlename.Enabled = True
            txtPassword.Enabled = True
            txtRetype.Visible = True
            txtRetype.Text = ""
            Label9.Visible = True

            txtStudentid.Focus()
        Else
            SaveStudent()
        End If
    End Sub

    Dim isVoice As Boolean = False

    Sub SaveStudent()
        If txtStudentid.Text = "" Then
            message = "Please enter the Student ID of the Student"

            If isVoice = False Then
                MsgBox("Please enter the Student ID of the Student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtStudentid.Focus()
            Exit Sub
        End If

        If txtStudentid.Text.Length < 7 Then
            message = "Please enter a valid Student ID of the Student"

            If isVoice = False Then
                MsgBox("Please enter a valid Student ID of the Student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtStudentid.Focus()
            Exit Sub
        End If

        If txtLastname.Text = "" Then
            message = "Please enter the Last Name of the Student"

            If isVoice = False Then
                MsgBox("Please enter the Last Name of the Student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtLastname.Focus()
            Exit Sub
        End If

        If txtFirstname.Text = "" Then
            message = "Please enter the First Name of the Student"

            If isVoice = False Then
                MsgBox("Please enter the First Name of the Student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtFirstname.Focus()
            Exit Sub
        End If

        If txtPassword.Text = "" Then
            message = "Please enter the Password of the Student"

            If isVoice = False Then
                MsgBox("Please enter the Password of the Student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtPassword.Focus()
            Exit Sub
        End If

        If Not txtPassword.Tag = txtPassword.Text Then
            If txtRetype.Text = "" Then
                message = "Please retype the Password of the Student"

                If isVoice = False Then
                    MsgBox("Please retype the Password of the Student", MsgBoxStyle.Information, "Student Registration")
                End If

                txtRetype.Focus()
                Exit Sub
            End If

            If Not txtPassword.Text = txtRetype.Text Then
                message = "Passwords do not match"

                If isVoice = False Then
                    MsgBox("Passwords do not match", MsgBoxStyle.Information, "Student Registration")
                End If

                txtPassword.Focus()
                Exit Sub
            End If
        End If

        If Not txtRetype.Text = "" Then
            If Not txtPassword.Text = txtRetype.Text Then
                message = "Passwords do not match"

                If isVoice = False Then
                    MsgBox("Passwords do not match", MsgBoxStyle.Information, "Student Registration")
                End If

                txtPassword.Focus()
                Exit Sub
            End If
        End If

        If lblEdit.Text = "Save" Then
            sql = "SELECT * FROM tbl_student WHERE LCASE(studentid)=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
            Dim exstud As New MySqlCommand(sql, con)
            exstud.Parameters.AddWithValue("?id", LCase(txtStudentid.Text))
            exstud.Parameters.AddWithValue("?major", major)
            exstud.Parameters.AddWithValue("?year", year)
            exstud.Parameters.AddWithValue("?section", section)
            exstud.Parameters.AddWithValue("?subject", subject)
            exstud.Parameters.AddWithValue("?user", frmMenu.username)
            da = New MySqlDataAdapter(exstud)
            da.Fill(ds, "exstud")

            If ds.Tables("exstud").Rows.Count > 0 Then
                ds.Tables("exstud").Clear()

                message = "The Student ID that you're trying to use already exist"

                If isVoice = False Then
                    MsgBox("The student ID that you're trying to use already exist", MsgBoxStyle.Information, "Student Registration")
                End If

                txtStudentid.Focus()
                Exit Sub
            End If

            sql = "INSERT INTO tbl_student VALUES(?id,?last,?first,?mid,?major,?year,?section,?subject,?pass,?user,?status)"
            Dim addstud As New MySqlCommand(sql, con)
            addstud.Parameters.AddWithValue("?id", txtStudentid.Text)
            addstud.Parameters.AddWithValue("?last", txtLastname.Text)
            addstud.Parameters.AddWithValue("?first", txtFirstname.Text)
            addstud.Parameters.AddWithValue("?mid", txtMiddlename.Text)
            addstud.Parameters.AddWithValue("?major", major)
            addstud.Parameters.AddWithValue("?year", year)
            addstud.Parameters.AddWithValue("?section", section)
            addstud.Parameters.AddWithValue("?subject", subject)
            addstud.Parameters.AddWithValue("?pass", txtPassword.Text)
            addstud.Parameters.AddWithValue("?user", frmMenu.username)
            addstud.Parameters.AddWithValue("?status", "Offline")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addstud.ExecuteNonQuery()
            con.Close()

            message = "Successfully Registered a new student"

            If isVoice = False Then
                MsgBox("Successfully Registered a new student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtStudentid.Text = ""
            txtStudentid.Tag = ""
            txtLastname.Text = ""
            txtFirstname.Text = ""
            txtMiddlename.Text = ""
            txtPassword.Text = ""
            txtPassword.Tag = ""
            txtRetype.Text = ""

            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lvAttendance.Enabled = True
            lblView.Enabled = True
            lblExport.Enabled = True
            lblLogout.Enabled = True
            lblActivity.Enabled = True

            txtStudentid.Enabled = False
            txtLastname.Enabled = False
            txtFirstname.Enabled = False
            txtMiddlename.Enabled = False
            txtPassword.Enabled = False
            txtRetype.Visible = False
            Label9.Visible = False

            LoadStudents()
        Else
            sql = "SELECT * FROM tbl_student WHERE LCASE(studentid)=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user AND (NOT LCASE(studentid)=?sid)"
            Dim exstud As New MySqlCommand(sql, con)
            exstud.Parameters.AddWithValue("?id", LCase(txtStudentid.Text))
            exstud.Parameters.AddWithValue("?major", major)
            exstud.Parameters.AddWithValue("?year", year)
            exstud.Parameters.AddWithValue("?section", section)
            exstud.Parameters.AddWithValue("?subject", subject)
            exstud.Parameters.AddWithValue("?user", frmMenu.username)
            exstud.Parameters.AddWithValue("?sid", LCase(txtStudentid.Tag))
            da = New MySqlDataAdapter(exstud)
            da.Fill(ds, "exstud")

            If ds.Tables("exstud").Rows.Count > 0 Then
                ds.Tables("exstud").Clear()

                message = "The Student ID that you're trying to use already exist"

                If isVoice = False Then
                    MsgBox("The student ID that you're trying to use already exist", MsgBoxStyle.Information, "Student Registration")
                End If

                txtStudentid.Focus()
                Exit Sub
            End If

            sql = "UPDATE tbl_student SET studentid=?id, studentlname=?last, studentfname=?first, studentmname=?mid, studentpass=?pass WHERE studentid=?sid AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
            Dim upstud As New MySqlCommand(sql, con)
            upstud.Parameters.AddWithValue("?id", txtStudentid.Text)
            upstud.Parameters.AddWithValue("?last", txtLastname.Text)
            upstud.Parameters.AddWithValue("?first", txtFirstname.Text)
            upstud.Parameters.AddWithValue("?mid", txtMiddlename.Text)
            upstud.Parameters.AddWithValue("?pass", txtPassword.Text)
            upstud.Parameters.AddWithValue("?sid", txtStudentid.Tag)
            upstud.Parameters.AddWithValue("?major", major)
            upstud.Parameters.AddWithValue("?year", year)
            upstud.Parameters.AddWithValue("?section", section)
            upstud.Parameters.AddWithValue("?subject", subject)
            upstud.Parameters.AddWithValue("?user", frmMenu.username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upstud.ExecuteNonQuery()
            con.Close()

            message = "Successfully Updated the Information of a Student"

            If isVoice = False Then
                MsgBox("Successfully Updated the Information of a Student", MsgBoxStyle.Information, "Student Registration")
            End If

            txtStudentid.Text = ""
            txtStudentid.Tag = ""
            txtLastname.Text = ""
            txtFirstname.Text = ""
            txtMiddlename.Text = ""
            txtPassword.Text = ""
            txtPassword.Tag = ""
            txtRetype.Text = ""

            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lvAttendance.Enabled = True
            lblView.Enabled = True
            lblExport.Enabled = True
            lblLogout.Enabled = True
            lblActivity.Enabled = True

            txtStudentid.Enabled = False
            txtLastname.Enabled = False
            txtFirstname.Enabled = False
            txtMiddlename.Enabled = False
            txtPassword.Enabled = False
            txtRetype.Visible = False
            Label9.Visible = False

            LoadStudents()
        End If
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        txtStudentid.Text = ""
        txtStudentid.Tag = ""
        txtLastname.Text = ""
        txtFirstname.Text = ""
        txtMiddlename.Text = ""
        txtPassword.Text = ""
        txtPassword.Tag = ""
        txtRetype.Text = ""

        lblEdit.Text = "Save"
        lblDelete.Text = "Cancel"

        lblAdd.Enabled = False
        lvAttendance.Enabled = False
        lblView.Enabled = False
        lblExport.Enabled = False
        lblLogout.Enabled = False
        lblActivity.Enabled = False

        txtStudentid.Enabled = True
        txtLastname.Enabled = True
        txtFirstname.Enabled = True
        txtMiddlename.Enabled = True
        txtPassword.Enabled = True
        txtRetype.Visible = True
        Label9.Visible = True

        message = "Please enter the Information of the Student"

        txtStudentid.Focus()
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarclass)
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

    Private Sub lblView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblView.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarclass)
        Catch : End Try
        frmAttendance.prevform = "class"
        frmAttendance.lblTitle.Text = UCase(major) & year & UCase(section) & " - " & subject
        frmAttendance.ShowDialog()
    End Sub

    Private Sub lblView_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblView.MouseLeave
        lblView.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblView.MouseMove
        lblView.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If lblEdit.Text = "Edit" Then
            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvAttendance, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
            ToolTip3.Show("Click here to View the Attendance of the Students", Me.lblView, 5000)

            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvAttendance, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
            ToolTip3.Show("Click here to View the Attendance of the Students", Me.lblView, 5000)
        ElseIf lblEdit.Text = "Save" Then
            ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
        ElseIf lblEdit.Text = "Update" Then
            ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
            ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
            ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)
        End If
    End Sub

    Private Sub lblHelp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHelp.MouseLeave
        lblHelp.ForeColor = Color.White
        lblHelp.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblHelp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblHelp.MouseMove
        lblHelp.ForeColor = Color.LawnGreen
        lblHelp.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
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

    Private Sub txtStudentid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtLastname.Focus()
        End If
    End Sub

    Private Sub txtStudentid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Dim isDelete As Boolean = False

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If isDelete = False Then
            If e.Result.Text = "close" Then
                message = "Closing"
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarclass)
                Catch : End Try
                Animation.Tag = "Hide"
                Animation.Start()
            ElseIf e.Result.Text = "total" Then
                If lvAttendance.Items.Count = 1 Then
                    message = "You have 1 student in your current section"
                ElseIf lvAttendance.Items.Count > 1 Then
                    message = "You have " & lvAttendance.Items.Count & " students in your current section"
                Else
                    message = "You have no student in your current section"
                End If
            ElseIf e.Result.Text = "total-students" Then
                If lvAttendance.Items.Count = 1 Then
                    message = "You have 1 student in your current section"
                ElseIf lvAttendance.Items.Count > 1 Then
                    message = "You have " & lvAttendance.Items.Count & " students in your current section"
                Else
                    message = "You have no student in your current section"
                End If
            ElseIf e.Result.Text = "logout-student" Then
logout:
                If txtStudentid.Tag = "" Then
                    message = "Please select a student that you want to Logout"

                    Exit Sub
                End If

                If isLogin = True Then
                    sql = "UPDATE tbl_student SET status='Offline' WHERE studentid=?id AND accountuser=?user"
                    Dim upstud As New MySqlCommand(sql, con)
                    upstud.Parameters.AddWithValue("?id", txtStudentid.Tag)
                    upstud.Parameters.AddWithValue("?user", frmMenu.username)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    upstud.ExecuteNonQuery()
                    con.Close()

                    message = "Successfully Logged out the student"
                Else
                    message = "The student is not logged in"
                End If
            ElseIf e.Result.Text = "help" Then
                If lblEdit.Text = "Edit" Then
                    ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvAttendance, 5000)
                    ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
                    ToolTip3.Show("Click here to View the Attendance of the Students", Me.lblView, 5000)

                    ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvAttendance, 5000)
                    ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
                    ToolTip3.Show("Click here to View the Attendance of the Students", Me.lblView, 5000)
                ElseIf lblEdit.Text = "Save" Then
                    ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
                    ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

                    ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
                    ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
                ElseIf lblEdit.Text = "Update" Then
                    ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
                    ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

                    ToolTip1.Show("Fill up the Form", Me.txtStudentid, 5000)
                    ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)
                End If
            ElseIf e.Result.Text = "export-attendance-and-activities" Then
                GoTo exp
            ElseIf e.Result.Text = "export" Then
exp:
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarclass)
                Catch : End Try

                frmExport.ShowDialog()
            ElseIf e.Result.Text = "add" Then
                If lblAdd.Enabled = True Then
                    txtStudentid.Text = ""
                    txtStudentid.Tag = ""
                    txtLastname.Text = ""
                    txtFirstname.Text = ""
                    txtMiddlename.Text = ""
                    txtPassword.Text = ""
                    txtPassword.Tag = ""
                    txtRetype.Text = ""

                    lblEdit.Text = "Save"
                    lblDelete.Text = "Cancel"

                    lblAdd.Enabled = False
                    lvAttendance.Enabled = False
                    lblView.Enabled = False

                    txtStudentid.Enabled = True
                    txtLastname.Enabled = True
                    txtFirstname.Enabled = True
                    txtMiddlename.Enabled = True
                    txtPassword.Enabled = True
                    txtRetype.Visible = True
                    Label9.Visible = True

                    message = "Please enter the Information of the Student"

                    txtStudentid.Focus()
                End If
            ElseIf e.Result.Text = "logout" Then
                GoTo logout
            ElseIf e.Result.Text = "edit" Then
                If lblEdit.Text = "Edit" Then
                    If txtStudentid.Text = "" Then
                        message = "Please select a student that you want to Edit"

                        Exit Sub
                    End If

                    lblEdit.Text = "Update"
                    lblDelete.Text = "Cancel"

                    lblAdd.Enabled = False
                    lvAttendance.Enabled = False
                    lblView.Enabled = False

                    txtStudentid.Enabled = True
                    txtLastname.Enabled = True
                    txtFirstname.Enabled = True
                    txtMiddlename.Enabled = True
                    txtPassword.Enabled = True
                    txtRetype.Visible = True
                    txtRetype.Text = ""
                    Label9.Visible = True

                    txtStudentid.Focus()
                End If
            ElseIf e.Result.Text = "save" Then
                If lblEdit.Text = "Save" Then
                    SaveStudent()
                End If
            ElseIf e.Result.Text = "update" Then
                If lblEdit.Text = "Update" Then
                    SaveStudent()
                End If
            ElseIf e.Result.Text = "cancel" Then
                If lblDelete.Text = "Cancel" Then
                    If lblEdit.Text = "Save" Then
                        message = "Registration was Cancel"
                    Else
                        message = "Updating Student was Cancel"
                    End If

                    lblAdd.Text = "Add"
                    lblEdit.Text = "Edit"
                    lblDelete.Text = "Delete"

                    lblAdd.Enabled = True
                    lvAttendance.Enabled = True
                    lblView.Enabled = True

                    txtStudentid.Enabled = False
                    txtLastname.Enabled = False
                    txtFirstname.Enabled = False
                    txtMiddlename.Enabled = False
                    txtPassword.Enabled = False
                    txtRetype.Visible = False
                    txtRetype.Text = ""
                    Label9.Visible = False
                End If
            ElseIf e.Result.Text = "delete" Then
                If lblDelete.Text = "Delete" Then
                    If txtStudentid.Text = "" Then
                        message = "Please select a student that you want to Delete"
                        MsgBox("Please select a student that you want to Delete", MsgBoxStyle.Information, "Delete Student")

                        Exit Sub
                    End If

                    message = "Press 'Yes' to delete the Student.. and 'No' to cancel"

                    If MsgBox("Are you sure you want to Delete the Student?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Student") = MsgBoxResult.Yes Then
                        sql = "DELETE FROM tbl_student WHERE studentid=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
                        Dim delstud As New MySqlCommand(sql, con)
                        delstud.Parameters.AddWithValue("?id", txtStudentid.Tag)
                        delstud.Parameters.AddWithValue("?major", major)
                        delstud.Parameters.AddWithValue("?year", year)
                        delstud.Parameters.AddWithValue("?section", section)
                        delstud.Parameters.AddWithValue("?subject", subject)
                        delstud.Parameters.AddWithValue("?user", frmMenu.username)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        delstud.ExecuteNonQuery()
                        con.Close()

                        message = "Deleting of Student was successful"
                        MsgBox("Deleting of Student was successful", MsgBoxStyle.Information, "Delete Student")

                        txtStudentid.Text = ""
                        txtStudentid.Tag = ""
                        txtLastname.Text = ""
                        txtFirstname.Text = ""
                        txtMiddlename.Text = ""
                        txtPassword.Text = ""
                        txtPassword.Tag = ""
                        txtRetype.Text = ""

                        LoadStudents()
                    End If
                End If
            ElseIf e.Result.Text = "attendance" Then
                If lblView.Enabled = True Then
                    Try
                        rec.RecognizeAsyncStop()
                        rec.UnloadGrammar(grammarclass)
                    Catch : End Try

                    frmAttendance.prevform = "class"
                    frmAttendance.lblTitle.Text = UCase(major) & year & UCase(section) & " - " & subject
                    frmAttendance.ShowDialog()
                End If
            ElseIf e.Result.Text = "refresh" Then
                If lvAttendance.Enabled = True Then
                    message = "Loading List of Students"
                    lvAttendance.Items.Clear()

                    Threading.Thread.Sleep(1000)

                    LoadStudents()
                End If
            ElseIf e.Result.Text = "student-activity" Then
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarclass)
                Catch : End Try

                frmActivity.ShowDialog()
            End If
        Else
            If e.Result.Text = "yes" Then

            ElseIf e.Result.Text = "no" Then
                message = "Deleting of Student was cancel"
                isDelete = False
            End If
        End If
    End Sub

    Private Sub lblActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblActivity.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarclass)
        Catch : End Try

        frmActivity.ShowDialog()
    End Sub

    Private Sub lblActivity_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblActivity.MouseLeave
        lblActivity.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblActivity_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblActivity.MouseMove
        lblActivity.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExport.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarclass)
        Catch : End Try

        frmExport.ShowDialog()
    End Sub

    Private Sub lblExport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExport.MouseLeave
        lblExport.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblExport_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblExport.MouseMove
        lblExport.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogout.Click
        If txtStudentid.Tag = "" Then
            MsgBox("Please select a student that you want to Logout", MsgBoxStyle.Information, "Logout Student")

            Exit Sub
        End If

        If isLogin = True Then
            If MsgBox("Are you sure you want to Logout the account of " & txtLastname.Text & ", " & txtFirstname.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Logout Student") = MsgBoxResult.Yes Then
                sql = "UPDATE tbl_student SET status='Offline' WHERE studentid=?id AND accountuser=?user"
                Dim upstud As New MySqlCommand(sql, con)
                upstud.Parameters.AddWithValue("?id", txtStudentid.Tag)
                upstud.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upstud.ExecuteNonQuery()
                con.Close()

                message = "Successfully Logged out the student"
                MsgBox("Successfully Logged Out the Student", MsgBoxStyle.Information, "Logout Student")
            End If
        Else
            message = "The student is not logged in"
            MsgBox("The Student is not logged in", MsgBoxStyle.Information, "Logout Student")
        End If
    End Sub

    Private Sub lblLogout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogout.MouseLeave
        lblLogout.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblLogout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLogout.MouseMove
        lblLogout.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub txtStudentid_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStudentid.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLastname.Focus()
        End If
    End Sub

    Private Sub txtStudentid_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtStudentid.MaskInputRejected

    End Sub
End Class