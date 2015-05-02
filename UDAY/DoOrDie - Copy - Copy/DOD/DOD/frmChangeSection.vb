Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmChangeSection

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        message = "closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarsec)
        Catch : End Try
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.ForeColor = Color.White
        lblCancel.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.ForeColor = Color.LawnGreen
        lblCancel.Font = New Font("Segoe UI Semibold", 10, FontStyle.Underline)
    End Sub

    Public major, year, section, subject As String
    Public sectioninfo() As String

    Sub LoadSection()
        cmbSection.Items.Clear()
        cmbSection.Text = ""
        lvStudents.Items.Clear()
        lblTotal.Text = "0"

        sql = "SELECT * FROM tbl_schedule WHERE accountuser=?user"
        Dim schlist As New MySqlCommand(sql, con)
        schlist.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(schlist)
        ds.Clear()
        da.Fill(ds, "schlist")

        If ds.Tables("schlist").Rows.Count > 0 Then
            For a = 1 To ds.Tables("schlist").Rows.Count
                With ds.Tables("schlist").Rows(a - 1)
                    If .Item("major").ToString = "" Then
                        '~~> No Major
                        cmbSection.Items.Add(UCase(.Item("year").ToString & "|" & .Item("section").ToString & "|" & .Item("subject").ToString))
                    Else
                        cmbSection.Items.Add(UCase(.Item("major").ToString & "|" & .Item("year").ToString & "|" & .Item("section").ToString & "|" & .Item("subject").ToString))
                    End If
                End With
            Next
        End If
    End Sub

    Sub LoadStudents()
        lvStudents.Items.Clear()
        lblTotal.Text = "0"

        sectioninfo = cmbSection.SelectedItem.ToString.Split("|")

        If sectioninfo.Length = 3 Then
            major = ""
            year = sectioninfo(0)
            section = sectioninfo(1)
            subject = sectioninfo(2)
        Else
            major = sectioninfo(0)
            year = sectioninfo(1)
            section = sectioninfo(2)
            subject = sectioninfo(3)
        End If

        sql = "SELECT * FROM tbl_student WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
        Dim studlist As New MySqlCommand(sql, con)
        studlist.Parameters.AddWithValue("?major", major)
        studlist.Parameters.AddWithValue("?year", year)
        studlist.Parameters.AddWithValue("?section", section)
        studlist.Parameters.AddWithValue("?subject", subject)
        studlist.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(studlist)
        ds.Clear()
        da.Fill(ds, "studlist")

        If ds.Tables("studlist").Rows.Count > 0 Then
            lblTotal.Text = ds.Tables("studlist").Rows.Count

            For a = 1 To ds.Tables("studlist").Rows.Count
                With ds.Tables("studlist").Rows(a - 1)
                    Dim lv As ListViewItem = lvStudents.Items.Add(.Item("studentid").ToString)
                    lv.SubItems.Add(.Item("studentlname").ToString & ", " & .Item("studentfname").ToString & " " & .Item("studentmname").ToString)
                End With
            Next
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

                LoadSection()

                Try
                    rec.LoadGrammar(grammarsec)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try

                cmbSection.Focus()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarsec)
                Catch : End Try

                If nextform = "class" Then
                    Try
                        frmMyClass.rec.RecognizeAsync(1)
                    Catch : End Try
                Else
                    Try
                        frmMenu.menurec.LoadGrammar(grammar2)
                    Catch : End Try
                    Try
                        frmMenu.menurec.SetInputToDefaultAudioDevice()
                    Catch : End Try
                    Try
                        frmMenu.menurec.RecognizeAsync(1)
                    Catch : End Try
                End If

                Me.Close()
            End If
        End If
    End Sub

    Public nextform As String = ""

    Private Sub cmbSection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSection.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSection.SelectedIndexChanged
        LoadStudents()
    End Sub

    Private Sub lblChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChange.Click
        If lblTitle.Text = "Change Section" Then

            With frmMenu
                If .major = major Then
                    If .year = year Then
                        If .section = section Then
                            If .subject = subject Then
                                '~~> Selected Section is the Same as Current
                                Animation.Tag = "Hide"
                                Animation.Start()

                                Exit Sub
                            End If
                        End If
                    End If
                End If

                '~~> Force every Logged In student to Logged out when the time Runs Out
                sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
                Dim complist As New MySqlCommand(sql, con)
                complist.Parameters.AddWithValue("?name", My.Computer.Name)
                complist.Parameters.AddWithValue("?ip", v4())
                da = New MySqlDataAdapter(complist)
                ds.Clear()
                da.Fill(ds, "list")

                If ds.Tables("list").Rows.Count > 0 Then
                    For a = 1 To ds.Tables("list").Rows.Count
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", ds.Tables("list").Rows(a - 1).Item("computername").ToString)
                        addcomm.Parameters.AddWithValue("?ip", ds.Tables("list").Rows(a - 1).Item("ipaddress").ToString)
                        addcomm.Parameters.AddWithValue("?comm", "log-out")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    Next
                End If

                '~~> Logout the Current Section
                sql = "UPDATE tbl_schedule SET status='Offline'"
                Dim upsch As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upsch.ExecuteNonQuery()
                con.Close()

                '~~> Set the Selected Section 'Online'
                sql = "UPDATE tbl_schedule SET status='Online' WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
                Dim upon As New MySqlCommand(sql, con)
                upon.Parameters.AddWithValue("?major", major)
                upon.Parameters.AddWithValue("?year", year)
                upon.Parameters.AddWithValue("?section", section)
                upon.Parameters.AddWithValue("?subject", subject)
                upon.Parameters.AddWithValue("?user", .username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upon.ExecuteNonQuery()
                con.Close()

                '~~> Update the Information in User Account Panel
                sql = "SELECT * FROM tbl_schedule WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
                Dim selsch As New MySqlCommand(sql, con)
                selsch.Parameters.AddWithValue("?major", major)
                selsch.Parameters.AddWithValue("?year", year)
                selsch.Parameters.AddWithValue("?section", section)
                selsch.Parameters.AddWithValue("?subject", subject)
                selsch.Parameters.AddWithValue("?user", .username)
                da = New MySqlDataAdapter(selsch)
                ds.Clear()
                da.Fill(ds, "selsch")

                If ds.Tables("selsch").Rows.Count > 0 Then
                    daysched = ds.Tables("selsch").Rows(0).Item("daysched").ToString
                    dayin = ds.Tables("selsch").Rows(0).Item("dayin").ToString
                    dayout = ds.Tables("selsch").Rows(0).Item("dayout").ToString
                End If

                .major = major
                .year = year
                .section = section
                .subject = subject
                .daysched = daysched
                .dayin = dayin
                .dayout = dayout

                .lblSection.Text = UCase(major & year & section & " - " & subject)
                .lblSchedule.Text = daysched & " | " & dayin & " - " & dayout

                Animation.Tag = "Hide"
                Animation.Start()
            End With

        Else
            sectioninfo = cmbSection.SelectedItem.ToString.Split("|")

            If sectioninfo.Length = 3 Then
                major = ""
                year = sectioninfo(0)
                section = sectioninfo(1)
                subject = sectioninfo(2)
            Else
                major = sectioninfo(0)
                year = sectioninfo(1)
                section = sectioninfo(2)
                subject = sectioninfo(3)
            End If

            sql = "SELECT * FROM tbl_student WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
            Dim studlist As New MySqlCommand(sql, con)
            studlist.Parameters.AddWithValue("?major", major)
            studlist.Parameters.AddWithValue("?year", year)
            studlist.Parameters.AddWithValue("?section", section)
            studlist.Parameters.AddWithValue("?subject", subject)
            studlist.Parameters.AddWithValue("?user", frmMenu.username)
            da = New MySqlDataAdapter(studlist)
            ds.Clear()
            da.Fill(ds, "studlist")

            If ds.Tables("studlist").Rows.Count > 0 Then
                lblTotal.Text = ds.Tables("studlist").Rows.Count

                For a = 1 To ds.Tables("studlist").Rows.Count
                    With ds.Tables("studlist").Rows(a - 1)

                        sql = "INSERT INTO tbl_student VALUES(?id"
                    End With
                Next
            End If

        End If
    End Sub

    Public daysched, dayin, dayout As String

    Private Sub lblChange_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChange.MouseLeave
        lblChange.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblChange_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblChange.MouseMove
        lblChange.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub frmChangeSection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarsec)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "up" Then
            If cmbSection.Focused = True Then
                If cmbSection.SelectedIndex > 0 Then
                    cmbSection.SelectedIndex = cmbSection.SelectedIndex - 1
                End If
            End If
        ElseIf e.Result.Text = "down" Then
            If cmbSection.Focused = True Then
                If cmbSection.SelectedIndex < cmbSection.Items.Count - 1 Then
                    cmbSection.SelectedIndex = cmbSection.SelectedIndex + 1
                End If
            End If
        ElseIf e.Result.Text = "continue" Then
            With frmMenu
                If .major = major Then
                    If .year = year Then
                        If .section = section Then
                            If .subject = subject Then
                                '~~> Selected Section is the Same as Current
                                Animation.Tag = "Hide"
                                Animation.Start()

                                Exit Sub
                            End If
                        End If
                    End If
                End If

                '~~> Force every Logged In student to Logged out when the time Runs Out
                sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
                Dim complist As New MySqlCommand(sql, con)
                complist.Parameters.AddWithValue("?name", My.Computer.Name)
                complist.Parameters.AddWithValue("?ip", v4())
                da = New MySqlDataAdapter(complist)
                ds.Clear()
                da.Fill(ds, "list")

                If ds.Tables("list").Rows.Count > 0 Then
                    For a = 1 To ds.Tables("list").Rows.Count
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", ds.Tables("list").Rows(a - 1).Item("computername").ToString)
                        addcomm.Parameters.AddWithValue("?ip", ds.Tables("list").Rows(a - 1).Item("ipaddress").ToString)
                        addcomm.Parameters.AddWithValue("?comm", "logout")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    Next
                End If

                '~~> Logout the Current Section
                sql = "UPDATE tbl_schedule SET status='Offline'"
                Dim upsch As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upsch.ExecuteNonQuery()
                con.Close()

                '~~> Set the Selected Section 'Online'
                sql = "UPDATE tbl_schedule SET status='Online' WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
                Dim upon As New MySqlCommand(sql, con)
                upon.Parameters.AddWithValue("?major", major)
                upon.Parameters.AddWithValue("?year", year)
                upon.Parameters.AddWithValue("?section", section)
                upon.Parameters.AddWithValue("?subject", subject)
                upon.Parameters.AddWithValue("?user", .username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upon.ExecuteNonQuery()
                con.Close()

                '~~> Update the Information in User Account Panel
                sql = "SELECT * FROM tbl_schedule WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
                Dim selsch As New MySqlCommand(sql, con)
                selsch.Parameters.AddWithValue("?major", major)
                selsch.Parameters.AddWithValue("?year", year)
                selsch.Parameters.AddWithValue("?section", section)
                selsch.Parameters.AddWithValue("?subject", subject)
                selsch.Parameters.AddWithValue("?user", .username)
                da = New MySqlDataAdapter(selsch)
                ds.Clear()
                da.Fill(ds, "selsch")

                If ds.Tables("selsch").Rows.Count > 0 Then
                    daysched = ds.Tables("selsch").Rows(0).Item("daysched").ToString
                    dayin = ds.Tables("selsch").Rows(0).Item("dayin").ToString
                    dayout = ds.Tables("selsch").Rows(0).Item("dayout").ToString
                End If

                .major = major
                .year = year
                .section = section
                .subject = subject
                .daysched = daysched
                .dayin = dayin
                .dayout = dayout

                .lblSection.Text = UCase(major & year & section & " - " & subject)
                .lblSchedule.Text = daysched & " | " & dayin & " - " & dayout

                Animation.Tag = "Hide"
                Animation.Start()
            End With
        End If
    End Sub

    Private Sub lvStudents_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStudents.GotFocus
        cmbSection.Focus()
    End Sub

End Class