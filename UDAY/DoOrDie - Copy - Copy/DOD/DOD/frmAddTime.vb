Imports MySql.Data.MySqlClient

Public Class frmAddTime

    Private Sub frmAddTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()

                txtMinute.Focus()

                Try
                    rec.LoadGrammar(grammartime)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammartime)

                    frmSpeechRecognition.rec.RecognizeAsync(1)
                Catch : End Try

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammartime)
        Catch : End Try
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.ForeColor = Color.White
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.ForeColor = Color.LawnGreen
    End Sub

    Dim isVoice As Boolean = False

    Private Sub lblContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContinue.Click
        isVoice = False

        AddTime()
    End Sub

    Sub AddTime()
        If txtMinute.Text = "" Or CInt(txtMinute.Text) <= 0 Then
            message = "Please enter the number of minutes to be added"

            If isVoice = False Then
                MsgBox("Please enter the number of minutes to be added", MsgBoxStyle.Information, "Add Time")
            End If

            Exit Sub
        End If

        If lblComputer.Text = "All Computer" Then
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim selcomp As New MySqlCommand(sql, con)
            selcomp.Parameters.AddWithValue("?name", My.Computer.Name)
            selcomp.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcomp)
            da.Fill(ds, "selcomp")

            If ds.Tables("selcomp").Rows.Count > 0 Then
                For a = 1 To ds.Tables("selcomp").Rows.Count
                    If ds.Tables("selcomp").Rows(a - 1).Item("actdone") = "Yes" Then
                        Continue For
                    End If

                    sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                    Dim seltimer As New MySqlCommand(sql, con)
                    seltimer.Parameters.AddWithValue("?name", ds.Tables("selcomp").Rows(a - 1).Item("computername").ToString)
                    seltimer.Parameters.AddWithValue("?ip", ds.Tables("selcomp").Rows(a - 1).Item("ipaddress").ToString)
                    da = New MySqlDataAdapter(seltimer)
                    da.Fill(ds, "seltimer")

                    If ds.Tables("seltimer").Rows.Count > 0 Then
                        '~~> Update their Time in tbl_commandpc
                        ds.Tables("seltimer").Clear()

                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim upcomm As New MySqlCommand(sql, con)
                        upcomm.Parameters.AddWithValue("?name", ds.Tables("selcomp").Rows(a - 1).Item("computername").ToString)
                        upcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomp").Rows(a - 1).Item("ipaddress").ToString)
                        upcomm.Parameters.AddWithValue("?comm", "extend-time")
                        upcomm.Parameters.AddWithValue("?con", CInt(txtMinute.Text) * 60)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upcomm.ExecuteNonQuery()
                        con.Close()
                    Else
                        '~~> Add their Time in tbl_commandpc
                        ds.Tables("seltimer").Clear()

                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", ds.Tables("selcomp").Rows(a - 1).Item("computername").ToString)
                        addcomm.Parameters.AddWithValue("?ip", ds.Tables("selcomp").Rows(a - 1).Item("ipaddress").ToString)
                        addcomm.Parameters.AddWithValue("?comm", "add")
                        addcomm.Parameters.AddWithValue("?con", CInt(txtMinute.Text) * 60)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    End If
                Next

                ds.Tables("selcomp").Clear()

                message = "Successfully Added time to All Clients"
            End If
        Else
            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim extimer As New MySqlCommand(sql, con)
            extimer.Parameters.AddWithValue("?name", lblComputer.Text)
            extimer.Parameters.AddWithValue("?ip", lblComputer.Tag)
            da = New MySqlDataAdapter(extimer)
            da.Fill(ds, "timer")

            If ds.Tables("timer").Rows.Count > 0 Then
                '~~> Update their Time in tbl_commandpc
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim upcomm As New MySqlCommand(sql, con)
                upcomm.Parameters.AddWithValue("?name", lblComputer.Text)
                upcomm.Parameters.AddWithValue("?ip", lblComputer.Tag)
                upcomm.Parameters.AddWithValue("?comm", "extend-time")
                upcomm.Parameters.AddWithValue("?con", CInt(txtMinute.Text) * 60)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upcomm.ExecuteNonQuery()
                con.Close()
            Else
                '~~> Add their Time in tbl_commandpc
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", lblComputer.Text)
                addcomm.Parameters.AddWithValue("?ip", lblComputer.Tag)
                addcomm.Parameters.AddWithValue("?comm", "add")
                addcomm.Parameters.AddWithValue("?con", CInt(txtMinute.Text) * 60)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If

            ds.Tables("timer").Clear()

            If txtMinute.Text = 1 Then
                message = txtMinute.Text & " minute was added to " & lblComputer.Text

                If isVoice = False Then
                    MsgBox(txtMinute.Text & " minute was added to " & lblComputer.Text, MsgBoxStyle.Information, "Client Timer")
                End If
            Else
                message = txtMinute.Text & " minutes was added to " & lblComputer.Text

                If isVoice = False Then
                    MsgBox(txtMinute.Text & " minutes was added to " & lblComputer.Text, MsgBoxStyle.Information, "Client Timer")
                End If
            End If
        End If

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammartime)
        Catch : End Try
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblContinue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblContinue.MouseLeave
        lblContinue.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblContinue_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContinue.MouseMove
        lblContinue.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "closing"

            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammartime)
            Catch : End Try

            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "continue" Then
            isVoice = True

            AddTime()
        End If
    End Sub

End Class