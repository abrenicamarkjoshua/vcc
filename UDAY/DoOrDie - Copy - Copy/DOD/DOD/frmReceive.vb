Imports MySql.Data.MySqlClient

Public Class frmReceive

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()

                dtpDate.Focus()

                Try
                    rec.LoadGrammar(grammarreceive)
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
                    rec.UnloadGrammar(grammarreceive)

                    frmSpeechRecognition.rec.RecognizeAsync(1)
                Catch : End Try

                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        message = "closing"

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarreceive)
        Catch : End Try

        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.ForeColor = Color.White
        lblCancel.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.ForeColor = Color.LawnGreen
        lblCancel.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Private Sub lblContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContinue.Click
        isVoice = False

        ReceiveActivity()
    End Sub

    Sub ReceiveActivity()
        If lblComputer.Text = "All Computer" Then
            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim complist As New MySqlCommand(sql, con)
            complist.Parameters.AddWithValue("?name", My.Computer.Name)
            complist.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(complist)
            ds.Clear()
            da.Fill(ds, "complist")

            If ds.Tables("complist").Rows.Count > 0 Then
                For a = 1 To ds.Tables("complist").Rows.Count
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", ds.Tables("complist").Rows(a - 1).Item("computername").ToString)
                    addcomm.Parameters.AddWithValue("?ip", ds.Tables("complist").Rows(a - 1).Item("ipaddress").ToString)
                    addcomm.Parameters.AddWithValue("?comm", "return")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                Next

                message = "Successfully Returned the Activity of All Clients"

                If isVoice = False Then
                    MsgBox("Successfully Returned the Activity of All Clients for " & dtpDate.Text, MsgBoxStyle.Information, "Return Activity")
                End If
            End If
        Else
            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", lblComputer.Text)
            addcomm.Parameters.AddWithValue("?ip", lblComputer.Tag)
            addcomm.Parameters.AddWithValue("?comm", "return")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "Successfully Returned the Activity of " & lblWordcall.Text

            If isVoice = False Then
                MsgBox("Successfully Returned the Activity of " & lblWordcall.Text & " for " & dtpDate.Text, MsgBoxStyle.Information, "Return Activity")
            End If
        End If

        isReceive = True

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarreceive)
        Catch : End Try

        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Dim isVoice As Boolean = False

    Private Sub lblContinue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblContinue.MouseLeave
        lblContinue.ForeColor = Color.White
        lblContinue.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblContinue_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContinue.MouseMove
        lblContinue.ForeColor = Color.LawnGreen
        lblContinue.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Dim isReceive As Boolean = False

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            If isReceive = False Then
                message = "closing"
            End If

            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarreceive)
            Catch : End Try

            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "continue" Then
            isVoice = True

            ReceiveActivity()
        ElseIf e.Result.Text = "today" Then
            dtpDate.Value = Today.Month & "/" & Today.Day & "/" & Today.Year
        ElseIf e.Result.Text = "yesterday" Then
            dtpDate.Value = Today.Month & "/" & CInt(Today.Day) - 1 & "/" & Today.Year
        End If
    End Sub

End Class