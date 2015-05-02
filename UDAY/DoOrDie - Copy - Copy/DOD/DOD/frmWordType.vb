Imports MySql.Data.MySqlClient

Public Class frmWordType

    Private Sub frmWordType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Sub LoadType()
        lvType.Items.Clear()
        lvType.Tag = ""
        txtName.Text = ""
        wordtype = ""
        worduser = False

        Try
            sql = "SELECT * FROM tbl_wordtype WHERE accountuser='System' OR accountuser=?user"
            Dim wordtype As New MySqlCommand(sql, con)
            wordtype.Parameters.AddWithValue("?user", frmMenu.username)

            da = New MySqlDataAdapter(wordtype)
            ds.Clear()
            da.Fill(ds, "wordtype")

            If ds.Tables("wordtype").Rows.Count > 0 Then
                For a = 1 To ds.Tables("wordtype").Rows.Count
                    Dim lv As ListViewItem = lvType.Items.Add(ds.Tables("wordtype").Rows(a - 1).Item("wordtype").ToString)
                    lv.SubItems.Add(ds.Tables("wordtype").Rows(a - 1).Item("accountuser").ToString)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading Word Type")
        End Try
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadType()

                Try
                    rec.LoadGrammar(grammartype)
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
                    rec.UnloadGrammar(grammartype)
                Catch : End Try

                If frmWord.Visible = True Then
                    Try
                        frmWord.rec.LoadGrammar(grammarword)
                        frmWord.rec.SetInputToDefaultAudioDevice()
                        frmWord.rec.RecognizeAsync(1)
                    Catch : End Try

                    frmWord.LoadType()
                End If

                Me.Close()
            End If
        End If
    End Sub

    Dim wordtype As String = ""
    Dim worduser As Boolean = False

    Private Sub lvType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvType.Click
        If lvType.Items.Count > 0 Then
            wordtype = lvType.FocusedItem.Text

            If lvType.FocusedItem.SubItems(1).Text = "System" Then
                worduser = False
            Else
                worduser = True
            End If
        End If
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        Add()
    End Sub

    Sub Add()
        lblAdd.Enabled = False
        lblEdit.Text = "Save"
        lblDelete.Text = "Cancel"

        lvType.Enabled = False
        txtName.Text = ""
        txtName.Enabled = True

        txtName.Focus()
    End Sub

    Dim isVoice As Boolean = False

    Sub Delete()
        If wordtype = "" Then
            message = "Please select a Word Type that you want to Delete"

            If isVoice = False Then
                MsgBox("Please select a word type that you want to Delete", MsgBoxStyle.Information, "Delete Type")
            End If

            Exit Sub
        End If

        If isVoice = True Then
            If worduser = False Then
                message = "You are unable to delete a system's default word type"

                Exit Sub
            End If

            GoTo skip
        Else
            If worduser = False Then
                message = "You are unable to delete a system's default word type"

                MsgBox("You are unable to delete a system's default word type", MsgBoxStyle.Information, "Delete Type")

                Exit Sub
            End If

            If MsgBox("Are you sure you want to Delete the Word Type (" & wordtype & ") ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Type") = MsgBoxResult.Yes Then
skip:
                sql = "DELETE FROM tbl_wordtype WHERE wordtype=?type AND accountuser=?user"
                Dim wordtype As New MySqlCommand(sql, con)
                wordtype.Parameters.AddWithValue("?type", wordtype)
                wordtype.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                wordtype.ExecuteNonQuery()
                con.Close()

                message = "Successfully Deleted a Word Type"

                If isVoice = False Then
                    MsgBox("Successfully Deleted a Word Type", MsgBoxStyle.Information, "Delete Type")
                End If

                LoadType()
            End If
        End If
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        isVoice = False

        If lblDelete.Text = "Delete" Then
            Delete()
        Else
            Cancel()
        End If
    End Sub

    Sub Cancel()
        lblAdd.Enabled = True

        If lblEdit.Text = "Save" Then
            txtName.Text = ""
        Else
            txtName.Text = wordtype
        End If

        lblEdit.Text = "Edit"
        lblDelete.Text = "Delete"

        txtName.Enabled = True
        lvType.Enabled = True

        If isVoice = True Then
            message = "Cancel"
        End If
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        isVoice = False

        If lblEdit.Text = "Edit" Then
            Edit()
        ElseIf lblEdit.Text = "Save" Then
            SaveType()
        ElseIf lblEdit.Text = "Update" Then
            UpdateType()
        End If
    End Sub

    Sub Edit()
        If wordtype = "" Then
            message = "Please select a Word Type that you want to Delete"

            If isVoice = False Then
                MsgBox("Please select a word type that you want to Delete", MsgBoxStyle.Information, "Edit Type")
            End If

            Exit Sub
        End If

        If worduser = False Then
            message = "Unable to Edit a System's Default Word Type"

            If isVoice = False Then
                MsgBox("Unable to edit a system's default word type", MsgBoxStyle.Information, "Edit Type")
            End If

            Exit Sub
        End If

        If isVoice = True Then
            message = "Edit"
        End If

        lblAdd.Enabled = False
        lblEdit.Text = "Update"
        lblDelete.Text = "Cancel"

        lvType.Enabled = False
        txtName.Enabled = True

        txtName.Focus()
    End Sub

    Sub SaveType()
        If txtName.Text = "" Then
            message = "Please enter the new word type"

            If isVoice = False Then
                MsgBox("Please enter the new word type", MsgBoxStyle.Information, "Save Type")
            End If

            Exit Sub
        End If

        sql = "SELECT * FROM tbl_wordtype WHERE wordtype=?type AND (accountuser=?user OR accountuser='System')"
        Dim Seltype As New MySqlCommand(sql, con)
        Seltype.Parameters.AddWithValue("?type", txtName.Text)
        Seltype.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(Seltype)
        ds.Clear()
        da.Fill(ds, "seltype")

        If ds.Tables("seltype").Rows.Count > 0 Then
            message = "The wordtype that you're trying to use already exist"

            If isVoice = False Then
                MsgBox("The wordtype that you're trying to use already exist", MsgBoxStyle.Information, "Save Type")
            End If

            Exit Sub
        End If

        sql = "INSERT INTO tbl_wordtype VALUES(?type,?user)"
        Dim addtype As New MySqlCommand(sql, con)
        addtype.Parameters.AddWithValue("?type", txtName.Text)
        addtype.Parameters.AddWithValue("?user", frmMenu.username)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        addtype.ExecuteNonQuery()
        con.Close()

        message = "New word type successfully added"

        If isVoice = False Then
            MsgBox("New word type successfully added", MsgBoxStyle.Information, "Save Type")
        End If

        LoadType()

        lblAdd.Enabled = True
        lblEdit.Text = "Edit"
        lblDelete.Text = "Delete"

        lvType.Enabled = True
        txtName.Enabled = False
    End Sub

    Sub UpdateType()
        If txtName.Text = "" Then
            message = "Please enter the new word type"

            If isVoice = False Then
                MsgBox("Please enter the new word type", MsgBoxStyle.Information, "Update Type")
            End If

            Exit Sub
        End If

        sql = "SELECT * FROM tbl_wordtype WHERE wordtype=?type AND (accountuser=?user OR accountuser='System') AND NOT (wordtype=?word)"
        Dim Seltype As New MySqlCommand(sql, con)
        Seltype.Parameters.AddWithValue("?type", txtName.Text)
        Seltype.Parameters.AddWithValue("?user", frmMenu.username)
        Seltype.Parameters.AddWithValue("?word", wordtype)
        da = New MySqlDataAdapter(Seltype)
        ds.Clear()
        da.Fill(ds, "seltype")

        If ds.Tables("seltype").Rows.Count > 0 Then
            message = "The wordtype that you're trying to use already exist"

            If isVoice = False Then
                MsgBox("The wordtype that you're trying to use already exist", MsgBoxStyle.Information, "Update Type")
            End If

            Exit Sub
        End If

        sql = "UPDATE tbl_wordtype SET wordtype=?type WHERE wordtype=?word"
        Dim uptype As New MySqlCommand(sql, con)
        uptype.Parameters.AddWithValue("?type", txtName.Text)
        uptype.Parameters.AddWithValue("?word", wordtype)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        uptype.ExecuteNonQuery()
        con.Close()

        message = "Word Type successfully Updated"

        If isVoice = False Then
            MsgBox("Word Type successfully updated", MsgBoxStyle.Information, "Update Type")
        End If

        LoadType()

        lblAdd.Enabled = True
        lblEdit.Text = "Edit"
        lblDelete.Text = "Delete"

        lvType.Enabled = True
        txtName.Enabled = False
    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammartype)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "cancel" Then
            If LCase(lblDelete.Text) = "cancel" Then
                message = "cancel"

                Cancel()
            End If
        ElseIf e.Result.Text = "save" Then
            If LCase(lblEdit.Text) = "save" Then
                isVoice = True

                SaveType()
            End If
        ElseIf e.Result.Text = "update" Then
            If LCase(lblEdit.Text) = "update" Then
                isVoice = True

                UpdateType()
            End If
        ElseIf e.Result.Text = "delete" Then
            If LCase(lblDelete.Text) = "delete" Then
                isVoice = True

                Delete()
            End If
        ElseIf e.Result.Text = "add" Then
            If lblAdd.Enabled = True Then
                isVoice = True

                Add()
            End If
        ElseIf e.Result.Text = "edit" Then
            If lblEdit.Text = "Edit" Then
                isVoice = True

                Edit()
            End If
        ElseIf e.Result.Text = "help" Then
            message = "Showing Help"

            ShowHelp()
        End If
    End Sub

    Sub ShowHelp()

    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.ForeColor = Color.White
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.ForeColor = Color.LawnGreen
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

End Class