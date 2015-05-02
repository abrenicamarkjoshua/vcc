Imports MySql.Data.MySqlClient

Public Class frmAttendance

    Private Sub frmAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine
    Public prevform As String = ""

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadStudents()

                message = "You are now viewing the Student's Attendance for " & Today.ToShortDateString

                Try
                    rec.LoadGrammar(grammaratt)
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
                    rec.UnloadGrammar(grammaratt)
                Catch ex As Exception

                End Try

                If prevform = "class" Then
                    Try
                        frmMyClass.rec.LoadGrammar(grammarclass)
                        frmMyClass.rec.SetInputToDefaultAudioDevice()
                        frmMyClass.rec.RecognizeAsync(1)
                    Catch : End Try
                End If

                Me.Close()
            End If
        End If
    End Sub

    Public Sub LoadStudents()
        lvAttendance.Items.Clear()

        sql = "SELECT * FROM tbl_student WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user"
        Dim studlist As New MySqlCommand(sql, con)
        studlist.Parameters.AddWithValue("?major", frmMenu.major)
        studlist.Parameters.AddWithValue("?year", frmMenu.year)
        studlist.Parameters.AddWithValue("?section", frmMenu.section)
        studlist.Parameters.AddWithValue("?subject", frmMenu.subject)
        studlist.Parameters.AddWithValue("?user", frmMenu.username)

        da = New MySqlDataAdapter(studlist)
        ds.Clear()
        da.Fill(ds, "stud")

        If ds.Tables("stud").Rows.Count > 0 Then
            For a = 1 To ds.Tables("stud").Rows.Count
                With ds.Tables("stud").Rows(a - 1)
                    Dim lv As ListViewItem = lvAttendance.Items.Add(.Item("studentid").ToString)
                    lv.SubItems.Add(.Item("studentlname").ToString & ", " & .Item("studentfname").ToString & " " & .Item("studentmname").ToString)

                    '~~> Check for Attendance
                    sql = "SELECT * FROM tbl_attendance WHERE studentid=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user AND (loginfo=?log)"
                    Dim att As New MySqlCommand(sql, con)
                    att.Parameters.AddWithValue("?id", .Item("studentid").ToString)
                    att.Parameters.AddWithValue("?major", frmMenu.major)
                    att.Parameters.AddWithValue("?year", frmMenu.year)
                    att.Parameters.AddWithValue("?section", frmMenu.section)
                    att.Parameters.AddWithValue("?subject", frmMenu.subject)
                    att.Parameters.AddWithValue("?user", frmMenu.username)
                    att.Parameters.AddWithValue("?log", dtpDate.Value.ToShortDateString)
                    da = New MySqlDataAdapter(att)
                    da.Fill(ds, "att")

                    If ds.Tables("att").Rows.Count > 0 Then
                        lv.SubItems.Add("Present | " & ds.Tables("att").Rows(0).Item("computername").ToString)

                        ds.Tables("att").Clear()

                        Continue For
                    End If

                    ds.Tables("att").Clear()

                    lv.SubItems.Add("Absent")
                End With
            Next
        End If
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammaratt)
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

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammaratt)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "refresh" Then
            message = "Reloading Student's Attendance"
            LoadStudents()
        ElseIf e.Result.Text = "today" Then
            message = "Loading Attendance for Today"
            dtpDate.Value = Today.Date
            LoadStudents()
        ElseIf e.Result.Text = "yesterday" Then
            message = "Loading Attendance for Yesterday"
            dtpDate.Value = Today.Month & " " & CInt(Today.Day) - 1 & ", " & Today.Year
            LoadStudents()
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        LoadStudents()
    End Sub

End Class