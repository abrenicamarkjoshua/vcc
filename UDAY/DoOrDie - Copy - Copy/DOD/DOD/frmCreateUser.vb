Imports MySql.Data.MySqlClient

Public Class frmCreateUser
    Dim tbl_section As New DataTable
    Dim tip As New ToolTip

    Private Sub frmCreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

    End Sub

    Private Sub frmCreateUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbl_section.Columns.Add("accountuser")
        tbl_section.Columns.Add("major")
        tbl_section.Columns.Add("year")
        tbl_section.Columns.Add("section")
        tbl_section.Columns.Add("subject")
        tbl_section.Columns.Add("daysched")
        tbl_section.Columns.Add("dayin")
        tbl_section.Columns.Add("dayout")
        tbl_section.Columns.Add("status")

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Sub ClearFields()
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtRetype.Text = ""
        txtLastname.Text = ""
        txtFirstname.Text = ""
        txtMiddlename.Text = ""

        cmbDay.Text = Today.DayOfWeek.ToString
        txtIN.Text = ""
        txtOUT.Text = ""
        txtMajor.Text = ""
        txtYear.Text = ""
        txtSection.Text = ""
        txtSubject.Text = ""

        lvSections.Items.Clear()
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

    Dim nextform As String

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                ClearFields()

                Try
                    rec.LoadGrammar(grammarnew)
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
                    rec.UnloadGrammar(grammarnew)
                Catch ex As Exception

                End Try

                If nextform = "Lock" Then
                    frmLock.Animation.Tag = "Show"
                    frmLock.Animation.Start()
                ElseIf nextform = "Menu" Then
                    frmLock.isLogin = True
                    frmMenu.Show()
                End If

                Me.Close()
            End If
        End If
    End Sub

    Private Sub MoveIndicator_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveIndicator.Tick
        ShowMessage.Tag = "Hide"
        ShowMessage.Start()

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
                PersonalPanel.Visible = False
                SchedulePanel.Visible = True
            End If
        End If
    End Sub

#Region "... Draggable"

    Dim currx, curry As Integer
    Dim isDraggable As Boolean = False

    Private Sub frmCreateUser_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        isDraggable = True
        currx = Windows.Forms.Cursor.Position.X - Me.Left
        curry = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmCreateUser_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If isDraggable = True Then
            Me.Left = Windows.Forms.Cursor.Position.X - currx
            Me.Top = Windows.Forms.Cursor.Position.Y - curry
        End If
    End Sub

    Private Sub frmCreateUser_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        isDraggable = False
    End Sub

    Private Sub PersonalPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PersonalPanel.MouseDown
        isDraggable = True
        currx = Windows.Forms.Cursor.Position.X - Me.Left
        curry = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub PersonalPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PersonalPanel.MouseMove
        If isDraggable = True Then
            Me.Left = Windows.Forms.Cursor.Position.X - currx
            Me.Top = Windows.Forms.Cursor.Position.Y - curry
        End If
    End Sub

    Private Sub PersonalPanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PersonalPanel.MouseUp
        isDraggable = False
    End Sub

    Private Sub SchedulePanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SchedulePanel.MouseDown
        isDraggable = True
        currx = Windows.Forms.Cursor.Position.X - Me.Left
        curry = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub SchedulePanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SchedulePanel.MouseMove
        If isDraggable = True Then
            Me.Left = Windows.Forms.Cursor.Position.X - currx
            Me.Top = Windows.Forms.Cursor.Position.Y - curry
        End If
    End Sub

    Private Sub SchedulePanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SchedulePanel.MouseUp
        isDraggable = False
    End Sub

#End Region

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        isVoice = False

        If lblCancel.Text = "Cancel" Then
            message = "Press 'Yes' to cancel creating your account.. and 'No' to continue registration"
            If MsgBox("Are you sure you want to cancel Creating your Account?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel Account") = MsgBoxResult.Yes Then
                sql = "UPDATE tbl_oncreate SET onCreate='No'"
                Dim uponcreate As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                uponcreate.ExecuteNonQuery()
                con.Close()

                nextform = "Lock"

                message = "Registration was cancel"

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarnew)
                Catch : End Try

                Animation.Tag = "Hide"
                Animation.Start()
            End If
        Else
            lblContinue.Text = "Next"
            lblCancel.Text = "Cancel"
            MoveIndicator.Tag = "Personal"
            MoveIndicator.Start()
            lblPersonal.ForeColor = Color.LimeGreen
        End If
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

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContinue.Click
        isVoice = False

        If lblContinue.Text = "Next" Then
            CheckPersonal()
        Else
            CheckSection()
        End If
    End Sub

    Sub CheckPersonal()
        '~~> All fields must not be blank
        If txtUsername.Text = "" Then
            message = "Please enter your Username"

            If isVoice = False Then
                MsgBox("Please enter your Username", MsgBoxStyle.Information, "Create User")
            End If

            txtUsername.Focus()
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

            If isVoice = False Then
                MsgBox("Please enter your Password", MsgBoxStyle.Information, "Create User")
            End If

            txtPassword.Focus()
            Exit Sub
        End If

        If txtRetype.Text = "" Then
            message = "Please retype your Password"

            If isVoice = False Then
                MsgBox("Please retype your Password", MsgBoxStyle.Information, "Create User")
            End If

            txtRetype.Focus()
            Exit Sub
        End If

        If txtLastname.Text = "" Then
            message = "Please enter your Last Name"

            If isVoice = False Then
                MsgBox("Please enter your Last Name", MsgBoxStyle.Information, "Create User")
            End If

            txtLastname.Focus()
            Exit Sub
        End If

        If txtFirstname.Text = "" Then
            message = "Please enter your First Name"

            If isVoice = False Then
                MsgBox("Please enter your First Name", MsgBoxStyle.Information, "Create User")
            End If

            txtFirstname.Focus()
            Exit Sub
        End If

        If cmbGender.Text = "" Then
            message = "Please select your Gender"

            If isVoice = False Then
                MsgBox("Please select your Gender", MsgBoxStyle.Information, "Create User")
            End If

            cmbGender.Focus()
            cmbGender.DroppedDown = True
            Exit Sub
        End If

        If Not txtPassword.Text.ToString = txtRetype.Text.ToString Then
            message = "Passwords do not match"

            If isVoice = False Then
                MsgBox("Passwords do not match", MsgBoxStyle.Information, "Create User")
            End If

            txtPassword.Focus()
            Exit Sub
        End If

        '~~> Check if the Username already exist
        sql = "SELECT * FROM tbl_account WHERE accountuser=?user"
        Dim accexist As New MySqlCommand(sql, con)
        accexist.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        da = New MySqlDataAdapter(accexist)
        da.Fill(ds, "accex")

        If ds.Tables("accex").Rows.Count > 0 Then
            '~~> Username already exist
            ds.Tables("accex").Clear()

            message = "The username that you're trying to use already exist"

            If isVoice = False Then
                MsgBox("The username that you're trying to use already exist", MsgBoxStyle.Information, "Create User")
            End If

            txtUsername.Focus()
            Exit Sub
        End If

        message = "Next"

        '~~> If no conflict, then CheckSection
        lblContinue.Text = "Continue"
        lblCancel.Text = "Back"
        MoveIndicator.Tag = "Section"
        MoveIndicator.Start()
        lblSectionSchedule.ForeColor = Color.LimeGreen
    End Sub

    Sub CheckSection()
        '~~> Check if the new User registered atleast 1 section
        If lvSections.Items.Count = 0 Then
            message = "You must add atleast 1 section in order to create your account"

            If isVoice = False Then
                MsgBox("You must add atleast 1 section in order to create your account", MsgBoxStyle.Information, "Create User")
            End If

            Exit Sub
        End If

        '~~> Create Account
        sql = "INSERT INTO tbl_account VALUES(?user,?pass,?lastname,?firstname,?middle,?isTut,?gender,?type)"
        Dim addacc As New MySqlCommand(sql, con)
        addacc.Parameters.AddWithValue("?user", txtUsername.Text.ToString)
        addacc.Parameters.AddWithValue("?pass", txtPassword.Text.ToString)
        addacc.Parameters.AddWithValue("?lastname", txtLastname.Text.ToString)
        addacc.Parameters.AddWithValue("?firstname", txtFirstname.Text.ToString)
        addacc.Parameters.AddWithValue("?middle", txtMiddlename.Text.ToString)
        addacc.Parameters.AddWithValue("?isTut", "Yes")
        addacc.Parameters.AddWithValue("?gender", cmbGender.Text)
        addacc.Parameters.AddWithValue("?type", "HTML")

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        addacc.ExecuteNonQuery()
        con.Close()

        '~~> Add the sections
        For a = 1 To tbl_section.Rows.Count
            sql = "INSERT INTO tbl_schedule VALUES(?user,?major,?year,?section,?subject,?day,?in,?out,?status)"
            Dim addsec As New MySqlCommand(sql, con)
            addsec.Parameters.AddWithValue("?user", tbl_section.Rows(a - 1).Item("accountuser").ToString)
            addsec.Parameters.AddWithValue("?major", tbl_section.Rows(a - 1).Item("major").ToString)
            addsec.Parameters.AddWithValue("?year", CInt(tbl_section.Rows(a - 1).Item("year").ToString))
            addsec.Parameters.AddWithValue("?section", tbl_section.Rows(a - 1).Item("section").ToString)
            addsec.Parameters.AddWithValue("?subject", tbl_section.Rows(a - 1).Item("subject").ToString)
            addsec.Parameters.AddWithValue("?day", tbl_section.Rows(a - 1).Item("daysched").ToString)
            addsec.Parameters.AddWithValue("?in", tbl_section.Rows(a - 1).Item("dayin").ToString)
            addsec.Parameters.AddWithValue("?out", tbl_section.Rows(a - 1).Item("dayout").ToString)
            addsec.Parameters.AddWithValue("?status", tbl_section.Rows(a - 1).Item("status").ToString)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addsec.ExecuteNonQuery()
            con.Close()
        Next

        SectionSelection()
    End Sub

    Sub SectionSelection()
        Dim daytoday As String = CDate(Today).DayOfWeek.ToString
        Dim timetoday As String = CDate(TimeOfDay).ToShortTimeString

        '~~> Check if there's a schedule for the day today
        Dim selrec() As DataRow = tbl_section.Select("daysched='" & daytoday & "'")
        If selrec.Length = 1 Then
            With frmMenu
                .username = selrec(0).Item("accountuser").ToString
                .password = txtPassword.Text
                .lastname = txtLastname.Text
                .firstname = txtFirstname.Text
                .middlename = txtMiddlename.Text
                .gender = cmbGender.Text
                .wordtype = "HTML"
                .major = selrec(0).Item("major").ToString
                .year = selrec(0).Item("year").ToString
                .section = selrec(0).Item("section").ToString
                .subject = selrec(0).Item("subject").ToString
                .daysched = selrec(0).Item("daysched").ToString
                .dayin = selrec(0).Item("dayin").ToString
                .dayout = selrec(0).Item("dayout").ToString

                .isTutorial = "Yes"
                .isFirst = True
            End With

            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
            Dim upsch As New MySqlCommand(sql, con)
            upsch.Parameters.AddWithValue("?user", selrec(0).Item("accountuser").ToString)
            upsch.Parameters.AddWithValue("?day", selrec(0).Item("daysched").ToString)
            upsch.Parameters.AddWithValue("?in", selrec(0).Item("dayin").ToString)
            upsch.Parameters.AddWithValue("?out", selrec(0).Item("dayout").ToString)

            sql = "UPDATE tbl_oncreate SET onCreate='No'"
            Dim upoc As New MySqlCommand(sql, con)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upsch.ExecuteNonQuery()
            upoc.ExecuteNonQuery()
            con.Close()

            nextform = "Menu"
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf selrec.Length > 1 Then
            For a = 1 To selrec.Length
                Dim hin As Integer = CDate(selrec(a - 1).Item("dayin").ToString).Hour
                Dim hout As Integer = CDate(selrec(a - 1).Item("dayout").ToString).Hour
                Dim min As Integer = CDate(selrec(a - 1).Item("dayin").ToString).Minute
                Dim mout As Integer = CDate(selrec(a - 1).Item("dayout").ToString).Minute

                If CDate(timetoday).Hour > hin Then
                    If CDate(timetoday).Hour < hout Then
                        '~~> Open Main Menu (Update variables first)
                        With frmMenu
                            .username = selrec(a - 1).Item("accountuser").ToString
                            .password = txtPassword.Text
                            .lastname = txtLastname.Text
                            .firstname = txtFirstname.Text
                            .middlename = txtMiddlename.Text
                            .gender = cmbGender.Text
                            .wordtype = "HTML"
                            .major = selrec(a - 1).Item("major").ToString
                            .year = selrec(a - 1).Item("year").ToString
                            .section = selrec(a - 1).Item("section").ToString
                            .subject = selrec(a - 1).Item("subject").ToString
                            .daysched = selrec(a - 1).Item("daysched").ToString
                            .dayin = selrec(a - 1).Item("dayin").ToString
                            .dayout = selrec(a - 1).Item("dayout").ToString

                            .isTutorial = "Yes"
                            .isFirst = True

                            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                            Dim upsch As New MySqlCommand(sql, con)
                            upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                            upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                            upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                            upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                            sql = "UPDATE tbl_oncreate SET onCreate='No'"
                            Dim upoc As New MySqlCommand(sql, con)

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            upsch.ExecuteNonQuery()
                            upoc.ExecuteNonQuery()
                            con.Close()

                            GoTo skip
                        End With
                    ElseIf CDate(timetoday).Hour = hout Then
                        If CDate(TimeOfDay).Minute <= mout Then
                            '~~> Open Main Menu
                            With frmMenu
                                .username = selrec(a - 1).Item("accountuser").ToString
                                .password = txtPassword.Text
                                .lastname = txtLastname.Text
                                .firstname = txtFirstname.Text
                                .middlename = txtMiddlename.Text
                                .gender = cmbGender.Text
                                .wordtype = "HTML"
                                .major = selrec(a - 1).Item("major").ToString
                                .year = selrec(a - 1).Item("year").ToString
                                .section = selrec(a - 1).Item("section").ToString
                                .subject = selrec(a - 1).Item("subject").ToString
                                .daysched = selrec(a - 1).Item("daysched").ToString
                                .dayin = selrec(a - 1).Item("dayin").ToString
                                .dayout = selrec(a - 1).Item("dayout").ToString

                                .isTutorial = "Yes"
                                .isFirst = True

                                sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                                Dim upsch As New MySqlCommand(sql, con)
                                upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                                upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                                upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                                upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                                sql = "UPDATE tbl_oncreate SET onCreate='No'"
                                Dim upoc As New MySqlCommand(sql, con)

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                upsch.ExecuteNonQuery()
                                upoc.ExecuteNonQuery()
                                con.Close()

                                GoTo skip
                            End With
                        End If
                    End If
                ElseIf CDate(TimeOfDay).Hour = hin Then
                    If CDate(timetoday).Hour < hout Then
                        '~~> Open Main Menu
                        With frmMenu
                            .username = selrec(a - 1).Item("accountuser").ToString
                            .password = txtPassword.Text
                            .lastname = txtLastname.Text
                            .firstname = txtFirstname.Text
                            .middlename = txtMiddlename.Text
                            .gender = cmbGender.Text
                            .wordtype = "HTML"
                            .major = selrec(a - 1).Item("major").ToString
                            .year = selrec(a - 1).Item("year").ToString
                            .section = selrec(a - 1).Item("section").ToString
                            .subject = selrec(a - 1).Item("subject").ToString
                            .daysched = selrec(a - 1).Item("daysched").ToString
                            .dayin = selrec(a - 1).Item("dayin").ToString
                            .dayout = selrec(a - 1).Item("dayout").ToString

                            .isTutorial = "Yes"
                            .isFirst = True

                            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                            Dim upsch As New MySqlCommand(sql, con)
                            upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                            upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                            upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                            upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                            sql = "UPDATE tbl_oncreate SET onCreate='No'"
                            Dim upoc As New MySqlCommand(sql, con)

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            upsch.ExecuteNonQuery()
                            upoc.ExecuteNonQuery()
                            con.Close()

                            GoTo skip
                        End With
                    ElseIf CDate(timetoday).Hour = hout Then
                        If CDate(TimeOfDay).Minute <= mout Then
                            '~~> Open Main Menu
                            With frmMenu
                                .username = selrec(a - 1).Item("accountuser").ToString
                                .password = txtPassword.Text
                                .lastname = txtLastname.Text
                                .firstname = txtFirstname.Text
                                .middlename = txtMiddlename.Text
                                .gender = cmbGender.Text
                                .wordtype = "HTML"
                                .major = selrec(a - 1).Item("major").ToString
                                .year = selrec(a - 1).Item("year").ToString
                                .section = selrec(a - 1).Item("section").ToString
                                .subject = selrec(a - 1).Item("subject").ToString
                                .daysched = selrec(a - 1).Item("daysched").ToString
                                .dayin = selrec(a - 1).Item("dayin").ToString
                                .dayout = selrec(a - 1).Item("dayout").ToString

                                .isTutorial = "Yes"
                                .isFirst = True

                                sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                                Dim upsch As New MySqlCommand(sql, con)
                                upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                                upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                                upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                                upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                                sql = "UPDATE tbl_oncreate SET onCreate='No'"
                                Dim upoc As New MySqlCommand(sql, con)

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                upsch.ExecuteNonQuery()
                                upoc.ExecuteNonQuery()
                                con.Close()

                                GoTo skip
                            End With
                        End If
                    End If
                End If
            Next

            '~~> No schedule match for the Time
            With frmMenu
                .username = selrec(0).Item("accountuser").ToString
                .password = txtPassword.Text
                .lastname = txtLastname.Text
                .firstname = txtFirstname.Text
                .middlename = txtMiddlename.Text
                .gender = cmbGender.Text
                .wordtype = "HTML"
                .major = selrec(0).Item("major").ToString
                .year = selrec(0).Item("year").ToString
                .section = selrec(0).Item("section").ToString
                .subject = selrec(0).Item("subject").ToString
                .daysched = selrec(0).Item("daysched").ToString
                .dayin = selrec(0).Item("dayin").ToString
                .dayout = selrec(0).Item("dayout").ToString

                .isTutorial = "Yes"
                .isFirst = True

                sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                Dim upsch As New MySqlCommand(sql, con)
                upsch.Parameters.AddWithValue("?user", selrec(0).Item("accountuser").ToString)
                upsch.Parameters.AddWithValue("?day", selrec(0).Item("daysched").ToString)
                upsch.Parameters.AddWithValue("?in", selrec(0).Item("dayin").ToString)
                upsch.Parameters.AddWithValue("?out", selrec(0).Item("dayout").ToString)

                sql = "UPDATE tbl_oncreate SET onCreate='No'"
                Dim upoc As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upsch.ExecuteNonQuery()
                upoc.ExecuteNonQuery()
                con.Close()

                GoTo skip
            End With

            Exit Sub
skip:

            nextform = "Menu"
            Animation.Tag = "Hide"
            Animation.Start()
        Else
            '~~> No schedule match for the day
            With frmMenu
                .username = tbl_section.Rows(0).Item("accountuser").ToString
                .password = txtPassword.Text
                .lastname = txtLastname.Text
                .firstname = txtFirstname.Text
                .middlename = txtMiddlename.Text
                .gender = cmbGender.Text
                .wordtype = "HTML"
                .major = tbl_section.Rows(0).Item("major").ToString
                .year = tbl_section.Rows(0).Item("year").ToString
                .section = tbl_section.Rows(0).Item("section").ToString
                .subject = tbl_section.Rows(0).Item("subject").ToString
                .daysched = tbl_section.Rows(0).Item("daysched").ToString
                .dayin = tbl_section.Rows(0).Item("dayin").ToString
                .dayout = tbl_section.Rows(0).Item("dayout").ToString

                .isTutorial = "Yes"
                .isFirst = True
            End With

            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
            Dim upsch As New MySqlCommand(sql, con)
            upsch.Parameters.AddWithValue("?user", tbl_section.Rows(0).Item("accountuser").ToString)
            upsch.Parameters.AddWithValue("?day", tbl_section.Rows(0).Item("daysched").ToString)
            upsch.Parameters.AddWithValue("?in", tbl_section.Rows(0).Item("dayin").ToString)
            upsch.Parameters.AddWithValue("?out", tbl_section.Rows(0).Item("dayout").ToString)

            sql = "UPDATE tbl_oncreate SET onCreate='No'"
            Dim upoc As New MySqlCommand(sql, con)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upsch.ExecuteNonQuery()
            upoc.ExecuteNonQuery()
            con.Close()

            nextform = "Menu"
            Animation.Tag = "Hide"
            Animation.Start()
        End If
    End Sub

    Private Sub lblContinue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblContinue.MouseLeave
        lblContinue.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblContinue_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContinue.MouseMove
        lblContinue.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Dim testsection As New DataTable

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        isVoice = False

        If lblAdd.Text = "Add" Then
            lvSections.Enabled = False
            lblAECancel.Visible = True

            lblEdit.Enabled = False
            lblDelete.Enabled = False
            lblPersonal.Enabled = False
            lblSectionSchedule.Enabled = False
            lblContinue.Enabled = False
            lblCancel.Enabled = False

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
        Else
            '~~> Check if all the fields are not empty
            SaveUpdate()
        End If
    End Sub

    Sub SaveUpdate()
        If cmbDay.Text = "" Then
            message = "Please select the Day of your Schedule"

            If isVoice = False Then
                MsgBox("Please select the Day of your Schedule", MsgBoxStyle.Information, "Create User")
            End If

            cmbDay.Focus()
            cmbDay.DroppedDown = True
            Exit Sub
        End If

        If txtIN.Text = "" Then
            message = "Please enter the time of your Schedule"

            If isVoice = False Then
                MsgBox("Please enter the time of your Schedule", MsgBoxStyle.Information, "Create User")
            End If

            txtIN.Focus()
            Exit Sub
        End If

        If txtOUT.Text = "" Then
            message = "Please enter the time of your Schedule"

            If isVoice = False Then
                MsgBox("Please enter the time of your Schedule", MsgBoxStyle.Information, "Create User")
            End If

            txtOUT.Focus()
            Exit Sub
        End If

        If txtYear.Text = "" Then
            message = "Please enter year of your Section"

            If isVoice = False Then
                MsgBox("Please enter year of your Section", MsgBoxStyle.Information, "Create User")
            End If

            txtYear.Focus()
            Exit Sub
        End If

        If txtSection.Text = "" Then
            message = "Please enter the Section"

            If isVoice = False Then
                MsgBox("Please enter the Section", MsgBoxStyle.Information, "Create User")
            End If

            txtSection.Focus()
            Exit Sub
        End If

        If txtSubject.Text = "" Then
            message = "Please enter the Subject of your Section"

            If isVoice = False Then
                MsgBox("Please enter the Subject of your Section", MsgBoxStyle.Information, "Create User")
            End If

            txtSubject.Focus()
            Exit Sub
        End If

        Dim timein, timeout As String

        '~~> Check if the Time-In and Time-Out is a valid time
        Try
            timein = CDate(txtIN.Text.ToString & " " & cmbIN.Text).ToShortTimeString
        Catch ex As Exception
            message = "Please enter the valid time for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter the valid time for your Schedule", MsgBoxStyle.Information, "Create User")
            End If

            txtIN.Focus()
            Exit Sub
        End Try

        Try
            timeout = CDate(txtOUT.Text.ToString & " " & cmbOUT.Text).ToShortTimeString
        Catch ex As Exception
            message = "Please enter the valid time for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter the valid time for your Schedule", MsgBoxStyle.Information, "Create User")
            End If

            txtOUT.Focus()
            Exit Sub
        End Try

        '~~> Time-Out must be greater than Time-IN
        If CDate(timein).Hour > CDate(timeout).Hour Then
            message = "Please enter a valid Time for your Schedule"

            If isVoice = False Then
                MsgBox("Please enter a valid time for your Schedule", MsgBoxStyle.Information, "Create User")
            End If

            txtIN.Focus()
            Exit Sub
        ElseIf CDate(timein).Hour = CDate(timeout).Hour Then
            If CDate(timein).Minute >= CDate(timeout).Minute Then
                message = "Please enter a valid Time for your Schedule"

                If isVoice = False Then
                    MsgBox("Please enter a valid time for your Schedule", MsgBoxStyle.Information, "Create User")
                End If

                txtIN.Focus()
                Exit Sub
            End If
        Else
            If DateDiff(DateInterval.Hour, CDate(timein), CDate(timeout)) < 3 Then
                message = "The minimun laboratory hours is 3 hours"

                If isVoice = False Then
                    MsgBox("The minimum Laboratory hours is 3 hours", MsgBoxStyle.Information, "Create User")
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
            '~~> Check for Conflict first
            If tbl_section.Rows.Count > 0 Then
                '~~> Check if the same subject with same year/section is registered
                Dim selrow() As DataRow = tbl_section.Select("subject='" & txtSubject.Text.ToString & "' AND year=" & CInt(txtYear.Text.ToString) & " AND section='" & txtSection.Text.ToString & "' AND major='" & txtMajor.Text.ToString & "'")
                If selrow.Length > 0 Then
                    '~~> same subject with same year/section is already registered
                    message = "The Section and Schedule that your trying to add already exist"

                    If isVoice = False Then
                        MsgBox("The section and Schedule that you're trying to add already exist", MsgBoxStyle.Information, "Create User")
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

                        message = "Unable to Save new Section and Schedule.. there was a conflict with other section and schedule"

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
                Dim newsec As DataRow = tbl_section.NewRow()
                newsec("accountuser") = txtUsername.Text.ToString
                newsec("major") = txtMajor.Text.ToString
                newsec("year") = txtYear.Text.ToString
                newsec("section") = txtSection.Text.ToString
                newsec("subject") = txtSubject.Text.ToString
                newsec("daysched") = cmbDay.Text.ToString
                newsec("dayin") = timein
                newsec("dayout") = timeout
                newsec("status") = "Offline"

                tbl_section.Rows.Add(newsec)

                Dim lv As ListViewItem = lvSections.Items.Add(cmbDay.Text.ToString)
                lv.SubItems.Add(txtYear.Text.ToString)
                lv.SubItems.Add(txtSection.Text.ToString)
                lv.SubItems.Add(txtSubject.Text.ToString)
                lv.SubItems.Add(txtMajor.Text.ToString)
                lv.SubItems.Add(timein)
                lv.SubItems.Add(timeout)

                message = "Section successfully Added"

                If isVoice = False Then
                    MsgBox("Section successfully Added", MsgBoxStyle.Information, "Create User")
                End If
            Else
                testsection.Clear()

                '~~> Check if conflict with other professor
                sql = "SELECT * FROM tbl_schedule WHERE daysched=?day"
                Dim schs As New MySqlCommand(sql, con)
                schs.Parameters.AddWithValue("?day", cmbDay.Text.ToString)
                da = New MySqlDataAdapter(schs)
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

                '~~> No conflict 'cause it is the first section, so just add the section
                Dim newsec As DataRow = tbl_section.NewRow()
                newsec("accountuser") = txtUsername.Text.ToString
                newsec("major") = txtMajor.Text.ToString
                newsec("year") = txtYear.Text.ToString
                newsec("section") = txtSection.Text.ToString
                newsec("subject") = txtSubject.Text.ToString
                newsec("daysched") = cmbDay.Text.ToString
                newsec("dayin") = timein
                newsec("dayout") = timeout
                newsec("status") = "Offline"

                tbl_section.Rows.Add(newsec)

                Dim lv As ListViewItem = lvSections.Items.Add(cmbDay.Text.ToString)
                lv.SubItems.Add(txtYear.Text.ToString)
                lv.SubItems.Add(txtSection.Text.ToString)
                lv.SubItems.Add(txtSubject.Text.ToString)
                lv.SubItems.Add(txtMajor.Text.ToString)
                lv.SubItems.Add(timein)
                lv.SubItems.Add(timeout)

                message = "Section successfully Added"

                If isVoice = False Then
                    MsgBox("Section successfully Added", MsgBoxStyle.Information, "Create User")
                End If
            End If

            '~~> Enable the Controls
            lvSections.Enabled = True
            lblAECancel.Visible = False

            lblEdit.Enabled = True
            lblDelete.Enabled = True
            lblPersonal.Enabled = True
            lblSectionSchedule.Enabled = True
            lblContinue.Enabled = True
            lblCancel.Enabled = True

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

            lvSections.Tag = ""

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

            '~~> This means no conflict with other schedule, therefore, update the section
            Dim selsec() As DataRow = tbl_section.Select("subject='" & txtSubject.Tag.ToString & "' AND year=" & CInt(txtYear.Tag.ToString) & " AND section='" & txtSection.Tag.ToString & "' AND major='" & txtMajor.Tag.ToString & "'")
            selsec(0).Item("major") = txtMajor.Text.ToString
            selsec(0).Item("year") = txtYear.Text.ToString
            selsec(0).Item("section") = txtSection.Text.ToString
            selsec(0).Item("subject") = txtSubject.Text.ToString
            selsec(0).Item("daysched") = cmbDay.Text.ToString
            selsec(0).Item("dayin") = timein
            selsec(0).Item("dayout") = timeout

            lvSections.Items(CInt(lvSections.Tag)).Text = cmbDay.Text
            lvSections.Items(CInt(lvSections.Tag)).SubItems(1).Text = txtYear.Text.ToString
            lvSections.Items(CInt(lvSections.Tag)).SubItems(2).Text = txtSection.Text.ToString
            lvSections.Items(CInt(lvSections.Tag)).SubItems(3).Text = txtSubject.Text.ToString
            lvSections.Items(CInt(lvSections.Tag)).SubItems(4).Text = txtMajor.Text.ToString
            lvSections.Items(CInt(lvSections.Tag)).SubItems(5).Text = timein
            lvSections.Items(CInt(lvSections.Tag)).SubItems(6).Text = timeout

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
            lblContinue.Enabled = True
            lblCancel.Enabled = True

            cmbDay.Enabled = False
            txtIN.Enabled = False
            txtOUT.Enabled = False
            txtMajor.Enabled = False
            txtYear.Enabled = False
            txtSection.Enabled = False
            txtSubject.Enabled = False
            cmbIN.Enabled = False
            cmbOUT.Enabled = False

            lvSections.Tag = ""

            lblAdd.Text = "Add"

            ResetFields()
        End If
    End Sub

    Private Sub lblAECancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAECancel.Click
        lvSections.Enabled = True
        lblAECancel.Visible = False

        lblEdit.Enabled = True
        lblDelete.Enabled = True
        lblPersonal.Enabled = True
        lblSectionSchedule.Enabled = True
        lblContinue.Enabled = True
        lblCancel.Enabled = True

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

    Private Sub lblAECancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAECancel.MouseLeave
        lblAECancel.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAECancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAECancel.MouseMove
        lblAECancel.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
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

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        isVoice = False

        Edit()
    End Sub

    Sub Edit()
        If lvSections.Tag = "" Then
            message = "Please select a Schedule from the list first that you want to Edit"

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
        lblContinue.Enabled = False
        lblCancel.Enabled = False

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

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        isVoice = False

        DeleteSection()
    End Sub

    Sub DeleteSection()
        If lvSections.Tag = "" Then
            message = "Please select a Schedule from the List first that you want to Delete"

            If isVoice = False Then
                MsgBox("Please select a Schedule from the List first that you want to Delete", MsgBoxStyle.Information, "Account Setting")
            End If

            Exit Sub
        End If

        If isVoice = True Then
            GoTo skip
        End If

        If MsgBox("Are you sure you want to Delete this Section/Schedule?" & vbNewLine & vbNewLine & "Day: " & lvSections.Items(CInt(lvSections.Tag)).Text & vbNewLine & "Time: " & lvSections.Items(CInt(lvSections.Tag)).SubItems(5).Text & " - " & lvSections.Items(CInt(lvSections.Tag)).SubItems(6).Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Account Setting") = MsgBoxResult.Yes Then
skip:
            tbl_section.AcceptChanges()
            For a = 1 To tbl_section.Rows.Count
                With tbl_section.Rows(a - 1)
                    If .Item("major").ToString = txtMajor.Tag.ToString Then
                        If .Item("year").ToString = txtYear.Tag.ToString Then
                            If .Item("section").ToString = txtSection.Tag.ToString Then
                                If .Item("subject").ToString = txtSubject.Tag.ToString Then
                                    lvSections.Items(CInt(lvSections.Tag)).Remove()

                                    .Delete()
                                End If
                            End If
                        End If
                    End If
                End With
            Next
            tbl_section.AcceptChanges()

            message = "Successfully Deleted a Section and Section"

            If isVoice = False Then
                MsgBox("Successfully Deleted a Section/Schedule", MsgBoxStyle.Information, "Account Setting")
            End If

            lvSections.Tag = ""

            ResetFields()
        End If
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If MoveIndicator.Tag = "Personal" Then
            If ToolTip1.GetToolTip(Me.txtUsername) = "" Then
                ToolTip1.Show("Fill up the Personal Information Form", Me.txtUsername, 5000)
                ToolTip2.Show("Click 'Next' to manage your Section/Schedule", Me.lblContinue, 5000)

                ToolTip1.Show("Fill up the Personal Information Form", Me.txtUsername, 5000)
                ToolTip2.Show("Click 'Next' to manage your Section/Schedule", Me.lblContinue, 5000)
            End If
        Else
            If lblAdd.Text = "Add" Then
                If lvSections.Items.Count > 0 Then
                    If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                        ToolTip1.Show("Click 'Continue' to create your Account", Me.lblContinue, 5000)
                        ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)

                        ToolTip1.Show("Click 'Continue' to create your Account", Me.lblAdd, 5000)
                        ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)
                    End If
                Else
                    If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                        ToolTip1.Show("Click 'Add' to add a Section/Schedule", Me.lblContinue, 5000)
                        ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)

                        ToolTip1.Show("Click 'Add' to add a Section/Schedule", Me.lblAdd, 5000)
                        ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)
                    End If
                End If
            ElseIf lblAdd.Text = "Save" Then
                If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                    ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                    ToolTip2.Show("Click 'Save' to save new Section/Schedule", Me.lblAdd, 5000)

                    ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                    ToolTip2.Show("Click 'Save' to save new Section/Schedule", Me.lblAdd, 5000)
                End If
            ElseIf lblAdd.Text = "Update" Then
                If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                    ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                    ToolTip2.Show("Click 'Update' to save changes of Section/Schedule", Me.lblAdd, 5000)

                    ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                    ToolTip2.Show("Click 'Update' to save changes of Section/Schedule", Me.lblAdd, 5000)
                End If
            End If
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

    Private Sub lvSections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSections.SelectedIndexChanged

    End Sub

    Private Sub lblShowPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShowPass.Click

    End Sub

    Private Sub lblShowRetype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShowRetype.Click

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

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged

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

    Private Sub txtRetype_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetype.TextChanged

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

            cmbGender.Focus()
            cmbGender.DroppedDown = True

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

    Private Sub cmbDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbDay.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIN.Focus()
        End If
    End Sub

    Private Sub cmbDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDay.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDay.SelectedIndexChanged

    End Sub

    Private Sub txtIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbIN.Focus()
        End If
    End Sub

    Private Sub txtIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIN.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(58)
                If InStr(":", txtIN.Text) Then
                    e.Handled = True
                End If
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
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(58)
                If InStr(":", txtOUT.Text) Then
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtOUT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtMajor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMajor.Click

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

    Private Sub txtSection_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSection.TextChanged

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

    Private Sub txtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.TextChanged

    End Sub

    Private Sub cmbGender_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGender.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lblContinue.Text = "Next" Then
                CheckPersonal()
            Else
                CheckSection()
            End If
        End If
    End Sub

    Private Sub cmbGender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbGender.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged

    End Sub

    Dim isMessage As Boolean = False
    Dim doWhat As String = ""

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "help" Then
            If isMessage = False Then
                If MoveIndicator.Tag = "Personal" Then
                    If ToolTip1.GetToolTip(Me.txtUsername) = "" Then
                        ToolTip1.Show("Fill up the Personal Information Form", Me.txtUsername, 5000)
                        ToolTip2.Show("Click 'Next' to manage your Section/Schedule", Me.lblContinue, 5000)

                        ToolTip1.Show("Fill up the Personal Information Form", Me.txtUsername, 5000)
                        ToolTip2.Show("Click 'Next' to manage your Section/Schedule", Me.lblContinue, 5000)
                    End If
                Else
                    If lblAdd.Text = "Add" Then
                        If lvSections.Items.Count > 0 Then
                            If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                                ToolTip1.Show("Click 'Continue' to create your Account", Me.lblContinue, 5000)
                                ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)

                                ToolTip1.Show("Click 'Continue' to create your Account", Me.lblAdd, 5000)
                                ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)
                            End If
                        Else
                            If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                                ToolTip1.Show("Click 'Add' to add a Section/Schedule", Me.lblContinue, 5000)
                                ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)

                                ToolTip1.Show("Click 'Add' to add a Section/Schedule", Me.lblAdd, 5000)
                                ToolTip2.Show("Select a Section/Schedule from the List to Edit/Delete", Me.lvSections, 5000)
                            End If
                        End If
                    ElseIf lblAdd.Text = "Save" Then
                        If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                            ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                            ToolTip2.Show("Click 'Save' to save new Section/Schedule", Me.lblAdd, 5000)

                            ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                            ToolTip2.Show("Click 'Save' to save new Section/Schedule", Me.lblAdd, 5000)
                        End If
                    ElseIf lblAdd.Text = "Update" Then
                        If ToolTip1.GetToolTip(Me.lblAdd) = "" Then
                            ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                            ToolTip2.Show("Click 'Update' to save changes of Section/Schedule", Me.lblAdd, 5000)

                            ToolTip1.Show("Fill up the Form", Me.cmbDay, 5000)
                            ToolTip2.Show("Click 'Update' to save changes of Section/Schedule", Me.lblAdd, 5000)
                        End If
                    End If
                End If
            End If
        ElseIf e.Result.Text = "cancel" Then
            If PersonalPanel.Visible = True Then
                If lblCancel.Enabled = True Then
                    If lblCancel.Text = "Cancel" Then
                        If MsgBox("Are you sure you want to Cancel Creating your Account?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Create User") = MsgBoxResult.Yes Then
                            sql = "UPDATE tbl_oncreate SET onCreate='No'"
                            Dim uponcreate As New MySqlCommand(sql, con)

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            uponcreate.ExecuteNonQuery()
                            con.Close()

                            nextform = "Lock"

                            message = "Registration was cancel"

                            Try
                                rec.RecognizeAsyncStop()
                                rec.UnloadGrammar(grammarnew)
                            Catch : End Try

                            Animation.Tag = "Hide"
                            Animation.Start()

                            Exit Sub
                        End If
                    End If
                End If

                If lblAECancel.Visible = True Then
                    message = "cancel"

                    lvSections.Enabled = True
                    lblAECancel.Visible = False

                    lblEdit.Enabled = True
                    lblDelete.Enabled = True
                    lblPersonal.Enabled = True
                    lblSectionSchedule.Enabled = True
                    lblContinue.Enabled = True
                    lblCancel.Enabled = True

                    cmbDay.Enabled = False
                    txtIN.Enabled = False
                    txtOUT.Enabled = False
                    cmbIN.Enabled = False
                    cmbOUT.Enabled = False
                    txtMajor.Enabled = False
                    txtYear.Enabled = False
                    txtSection.Enabled = False
                    txtSubject.Enabled = False

                    If lblAdd.Text = "Save" Then
                        ResetFields()
                    End If

                    lblAdd.Text = "Add"
                End If
            End If
        ElseIf e.Result.Text = "back" Then
            If SchedulePanel.Visible = True Then
                message = "Back"

                lblContinue.Text = "Next"
                lblCancel.Text = "Cancel"
                MoveIndicator.Tag = "Personal"
                MoveIndicator.Start()
                lblPersonal.ForeColor = Color.LimeGreen
            End If
        ElseIf e.Result.Text = "next" Then
            If PersonalPanel.Visible = True Then
                If lblContinue.Text = "Next" Then
                    CheckPersonal()
                End If
            End If
        ElseIf e.Result.Text = "continue" Then
            If SchedulePanel.Visible = True Then
                If lblContinue.Text = "Continue" Then
                    isVoice = True

                    CheckSection()
                End If
            End If
        ElseIf e.Result.Text = "add" Then
            If SchedulePanel.Visible = True Then
                If lblAdd.Text = "Add" Then
                    message = "Add"

                    lvSections.Enabled = False
                    lblAECancel.Visible = True

                    lblEdit.Enabled = False
                    lblDelete.Enabled = False
                    lblPersonal.Enabled = False
                    lblSectionSchedule.Enabled = False
                    lblContinue.Enabled = False
                    lblCancel.Enabled = False

                    cmbDay.Enabled = True
                    txtIN.Enabled = True
                    txtOUT.Enabled = True
                    cmbIN.Enabled = True
                    cmbOUT.Enabled = True
                    txtMajor.Enabled = True
                    txtYear.Enabled = True
                    txtSection.Enabled = True
                    txtSubject.Enabled = True

                    lblAdd.Text = "Save"
                    cmbDay.Focus()
                    cmbDay.DroppedDown = True
                End If
            End If
        ElseIf e.Result.Text = "edit" Then
            If SchedulePanel.Visible = True Then
                If lblEdit.Visible = True Then
                    If lblAECancel.Visible = False Then
                        isVoice = True

                        Edit()
                    End If
                End If
            End If
        ElseIf e.Result.Text = "delete" Then
            If SchedulePanel.Visible = True Then
                If lblDelete.Visible = True Then
                    If lblAECancel.Visible = False Then
                        isVoice = True

                        DeleteSection()
                    End If
                End If
            End If
        ElseIf e.Result.Text = "save" Then
            If SchedulePanel.Visible = True Then
                If lblAdd.Text = "Save" Then
                    isVoice = True

                    SaveUpdate()
                End If
            End If
        ElseIf e.Result.Text = "update" Then
            If SchedulePanel.Visible = True Then
                If lblAdd.Text = "Update" Then
                    isVoice = True

                    SaveUpdate()
                End If
            End If
        End If
    End Sub

    Private Sub SchedulePanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SchedulePanel.Paint

    End Sub

    Private Sub txtMajor_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMajor.TextChanged

    End Sub

    Private Sub txtIN_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIN.TextChanged

    End Sub

    Private Sub cmbIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOUT.Focus()
        End If
    End Sub

    Private Sub cmbIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIN.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtOUT_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOUT.TextChanged

    End Sub

    Private Sub cmbOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOUT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMajor.Focus()
        End If
    End Sub

    Private Sub cmbOUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOUT.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtMajor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMajor.SelectedIndexChanged

    End Sub

    Private Sub txtYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.SelectedIndexChanged
        If txtYear.Text = "1" Or txtYear.Text = "2" Then
            txtMajor.Enabled = False
            txtMajor.Text = ""
        Else
            txtMajor.Enabled = True
        End If
    End Sub

End Class