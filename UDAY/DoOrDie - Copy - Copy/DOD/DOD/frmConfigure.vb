Imports MySql.Data.MySqlClient

Public Class frmConfigure

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        message = "closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarconf)
        Catch : End Try
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.ForeColor = Color.White
        lblCancel.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.ForeColor = Color.LawnGreen
        lblCancel.Font = New Font("Segoe UI Semibold", 10, FontStyle.Underline)
    End Sub

    Private Sub lblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSave.Click
        SaveConfigure()
    End Sub

    Sub SaveConfigure()
        If txtPath.Text = "" Then
            message = "Unable to Save an empty configured path"
            MsgBox("Unable to Save an empty configured path", MsgBoxStyle.Information, "Configure Path")

            txtPath.Focus()
            Exit Sub
        End If

        If LCase(prevform) = "application" Then
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarconf)
            Catch : End Try

            sql = "UPDATE tbl_application SET conpath=?path WHERE wordcall=?word AND (accountuser=?user OR accountuser='')"
            Dim upcon As New MySqlCommand(sql, con)
            upcon.Parameters.AddWithValue("?path", txtPath.Text)
            upcon.Parameters.AddWithValue("?word", frmApplication.txtWordCall.Tag)
            upcon.Parameters.AddWithValue("?user", frmMenu.username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upcon.ExecuteNonQuery()
            con.Close()

            message = "Successfully configured the path of " & frmApplication.txtWordCall.Tag & " for clients"
            MsgBox("Successfully configured the Path of " & frmApplication.txtWordCall.Tag & " for clients", MsgBoxStyle.Information, "Configure Path")

            frmApplication.LoadApps()

            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf LCase(prevform) = "manage" Then
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarconf)
            Catch : End Try

            sql = "UPDATE tbl_apptype SET conpath=?path WHERE appname=?word"
            Dim upcon As New MySqlCommand(sql, con)
            upcon.Parameters.AddWithValue("?path", txtPath.Text)
            upcon.Parameters.AddWithValue("?word", frmManage.txtName.Tag)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upcon.ExecuteNonQuery()
            con.Close()

            message = "Successfully configured the path of " & frmManage.txtName.Tag & " for clients"
            MsgBox("Successfully configured the Path of " & frmManage.txtName.Tag & " for clients", MsgBoxStyle.Information, "Configure Path")

            frmManage.LoadApps()

            Animation.Tag = "Hide"
            Animation.Start()
        End If
    End Sub

    Private Sub lblSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSave.MouseLeave
        lblSave.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSave.MouseMove
        lblSave.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                Try
                    rec.LoadGrammar(grammarconf)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try

                txtPath.Focus()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarconf)
                Catch ex As Exception

                End Try

                If LCase(prevform) = "application" Then
                    Try
                        frmApplication.rec.LoadGrammar(grammarapp)
                        frmApplication.rec.SetInputToDefaultAudioDevice()
                        frmApplication.rec.RecognizeAsync(1)
                    Catch : End Try
                ElseIf LCase(prevform) = "manage" Then
                    Try
                        frmManage.rec.LoadGrammar(grammarmanage)
                        frmManage.rec.SetInputToDefaultAudioDevice()
                        frmManage.rec.RecognizeAsync(1)
                    Catch : End Try
                End If

                Me.Close()
            End If
        End If
    End Sub

    Public prevform As String = ""

    Private Sub frmConfigure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub txtPath_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPath.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveConfigure()
        End If
    End Sub

    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarconf)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "save" Then
            SaveConfigure()
        End If
    End Sub

End Class