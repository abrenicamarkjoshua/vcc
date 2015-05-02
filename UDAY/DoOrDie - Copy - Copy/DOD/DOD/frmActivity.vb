Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmActivity
    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine
    Dim studentname, studentid As String

    Private Sub frmActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSection.Text = frmMenu.lblSection.Text

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadStudents()

                message = "You are now viewing the Students who's done with Activity for " & Today.ToShortDateString

                Try
                    rec.LoadGrammar(grammaract)
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
                    rec.UnloadGrammar(grammaract)
                Catch : End Try

                If frmMyClass.Visible = True Then
                    Try
                        frmMyClass.rec.LoadGrammar(grammarclass)
                        frmMyClass.rec.SetInputToDefaultAudioDevice()
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

    Sub LoadStudents()
        lvAttendance.Items.Clear()
        lvAttendance.Tag = ""

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
                    lv.SubItems.Add(.Item("studentlname").ToString)
                    lv.SubItems.Add(.Item("studentfname").ToString)
                    lv.SubItems.Add(.Item("studentmname").ToString)
                End With
            Next
        End If
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammaract)
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

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged

    End Sub

    Private Sub lvAttendance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAttendance.Click
        If lvAttendance.Items.Count > 0 Then
            studentid = lvAttendance.FocusedItem.Text
            studentname = lvAttendance.FocusedItem.SubItems(1).Text

            lblName.Text = studentid & " | " & studentname
        End If
    End Sub

    Private Sub lblView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblView.Click
        ViewActivity()
    End Sub

    Sub ViewActivity()
        If lblName.Text = "" Then
            message = "Please select a Student that you want to View Activity"
            MsgBox("Please select a Student that you want to View Activity", MsgBoxStyle.Information, "View Activity")

            Exit Sub
        End If

        If System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity", dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year, studentid)) Then
            '~~> The selected student had submitted an Activity
            message = "Opening the Activity of the Student"

            Process.Start("explorer.exe", Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity", dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year, studentid))
        Else
            message = "Unable to Locate the Activity of the Student"
            MsgBox("Unable to Locate the Activity of the Student", MsgBoxStyle.Information, "View Activity")
        End If
    End Sub

    Private Sub lblView_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblView.MouseLeave
        lblView.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblView.MouseMove
        lblView.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        Try
            If Directory.Exists(path) Then
                'Delete all files from the Directory
                For Each filepath As String In Directory.GetFiles(path)
                    File.Delete(filepath)
                Next
                'Delete all child Directories
                For Each dir As String In Directory.GetDirectories(path)
                    DeleteDirectory(dir)
                Next

                'Delete a Directory
                Directory.Delete(path)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClear.Click
        message = "Press 'Yes' to clear the activities.. and 'No' to cancel"
        If MsgBox("Are you sure you want to Clear All the Activities of Students?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Clear Activity") = MsgBoxResult.Yes Then
            DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity", dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year))

            message = "Successfully Cleared the Activity on " & dtpDate.Value.ToShortDateString
            MsgBox("Successfully Cleared the Activity on " & dtpDate.Value.ToShortDateString, MsgBoxStyle.Information, "Activity")
        End If
    End Sub

    Private Sub lblClear_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClear.MouseLeave
        lblClear.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblClear_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClear.MouseMove
        lblClear.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Dim isMessage As Boolean = False

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            If isMessage = False Then
                message = "Closing"
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammaract)
                Catch : End Try
                Animation.Tag = "Hide"
                Animation.Start()
            End If
        ElseIf e.Result.Text = "help" Then
            If isMessage = False Then
                ToolTip1.Show("Specify the Date to View Activity", Me.dtpDate, 5000)
                ToolTip2.Show("Select a Student that you want to View Activity", Me.lvAttendance, 5000)
                ToolTip3.Show("Click to Clear the Activities", Me.lblClear, 5000)
                ToolTip4.Show("Click to Browse for the Activity", Me.lblView, 5000)

                ToolTip1.Show("Specify the Date to View Activity", Me.dtpDate, 5000)
                ToolTip2.Show("Select a Student that you want to View Activity", Me.lvAttendance, 5000)
                ToolTip3.Show("Click to Clear the Activities", Me.lblClear, 5000)
                ToolTip4.Show("Click to Browse for the Activity", Me.lblView, 5000)
            End If
        ElseIf e.Result.Text = "clear-activity" Then
            If isMessage = False Then
                message = "Press 'Yes' to clear the activities.. and 'No' to cancel"
                If MsgBox("Are you sure you want to Clear All the Activities of Students?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Clear Activity") = MsgBoxResult.Yes Then
                    DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity", dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year))

                    message = "Successfully Cleared the Activity on " & dtpDate.Value.ToShortDateString
                    MsgBox("Successfully Cleared the Activity on " & dtpDate.Value.ToShortDateString, MsgBoxStyle.Information, "Activity")
                End If
            End If
        ElseIf e.Result.Text = "view-activity" Then
            If isMessage = False Then
                ViewActivity()
            End If
        ElseIf e.Result.Text = "view" Then
            If isMessage = False Then
                ViewActivity()
            End If
        ElseIf e.Result.Text = "refresh" Then
            If isMessage = False Then
                LoadStudents()
            End If
        ElseIf e.Result.Text = "yesterday" Then
            If isMessage = False Then
                dtpDate.Value = Today.Month & " " & CInt(Today.Day) - 1 & ", " & Today.Year

                LoadStudents()
            End If
        End If
    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        ToolTip1.Show("Specify the Date to View Activity", Me.dtpDate, 5000)
        ToolTip2.Show("Select a Student that you want to View Activity", Me.lvAttendance, 5000)
        ToolTip3.Show("Click to Clear the Activities", Me.lblClear, 5000)
        ToolTip4.Show("Click to Locate the Student Activity", Me.lblView, 5000)

        ToolTip1.Show("Specify the Date to View Activity", Me.dtpDate, 5000)
        ToolTip2.Show("Select a Student that you want to View Activity", Me.lvAttendance, 5000)
        ToolTip3.Show("Click to Clear the Activities", Me.lblClear, 5000)
        ToolTip4.Show("Click to Locate the Student Activity", Me.lblView, 5000)
    End Sub

    Private Sub lblHelp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHelp.MouseLeave
        lblHelp.ForeColor = Color.White
        lblHelp.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblHelp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblHelp.MouseMove
        lblHelp.ForeColor = Color.LawnGreen
        lblHelp.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

End Class