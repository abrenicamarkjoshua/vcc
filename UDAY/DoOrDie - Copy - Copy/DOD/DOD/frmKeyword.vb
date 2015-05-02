Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis

Public Class frmKeyword
    Public isTutorial As String = "No"
    Public isSystem As Boolean = False

    Private Sub frmKeyword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isTutorial = "Yes" Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                If isTutorial = "Yes" Then
 
                    message = "In Keyword Setting, you can set default commands for the system."

                End If

                LoadKeyword()

                Try
                    rec.LoadGrammar(grammarkey)
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
                    rec.UnloadGrammar(grammarkey)
                Catch ex As Exception

                End Try

                If isTutorial = "No" Then
                    frmMenu.isActivate = True
                    frmMenu.Show()
                ElseIf isTutorial = "Skip" Then
                Else
                    frmTutorial.MoveIndicator.Tag = "Voice"
                    frmTutorial.MoveIndicator.Start()
                End If

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarkey)
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

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If lblEdit.Text = "Edit" Then
            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvKeyword, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)

            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvKeyword, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
        ElseIf lblEdit.Text = "Save" Then
            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
        ElseIf lblEdit.Text = "Update" Then
            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
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

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        lblAdd.Enabled = False
        lblEdit.Text = "Save"
        lblDelete.Text = "Cancel"

        lvKeyword.Enabled = False
        lvSystem.Enabled = False

        txtWordCall.Enabled = True
        txtCommand.Enabled = True

        txtWordCall.Text = ""
        txtCommand.Text = ""

        txtWordCall.Focus()
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        If lblEdit.Text = "Edit" Then
            If txtWordCall.Tag = "" Then
                message = "Please select a keyword that you want to Edit"
                MsgBox("Please select a Keyword that you want to Edit", MsgBoxStyle.Information, "Keyword Setting")

                Exit Sub
            End If

            If isSystem = True Then
                message = "Unable to Edit System's Keyword"
                MsgBox("Unable to Edit System's Keyword", MsgBoxStyle.Information, "Keyword Setting")

                Exit Sub
            End If

            lblAdd.Enabled = False
            lblEdit.Text = "Update"
            lblDelete.Text = "Cancel"

            lvKeyword.Enabled = False
            lvSystem.Enabled = False

            txtWordCall.Enabled = True
            txtCommand.Enabled = True

            txtWordCall.Focus()
        Else
            SaveUpdate()
        End If
    End Sub

    Sub SaveUpdate()
        If txtWordCall.Text = "" Then
            message = "Please enter the Word Call for the Keyword"
            MsgBox("Please enter the Word Call for the Keyword", MsgBoxStyle.Information, "Keyword Setting")

            txtWordCall.Focus()
            Exit Sub
        End If

        If txtCommand.Text = "" Then
            message = "Please enter the command to execute"
            MsgBox("Please enter the Command to Execute", MsgBoxStyle.Information, "Keyword Setting")

            txtCommand.Focus()
            Exit Sub
        End If

        '~~> Check if Conflict with Wordcall of Computer
        sql = "SELECT * FROM tbl_computer WHERE LCASE(wordcall)=?word"
        Dim comp As New MySqlCommand(sql, con)
        comp.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
        da = New MySqlDataAdapter(comp)
        ds.Clear()
        da.Fill(ds, "comp")

        If ds.Tables("comp").Rows.Count > 0 Then
            message = "The wordcall that you're trying to use already exist"
            MsgBox("The wordcall that you're trying to use already exist", MsgBoxStyle.Information, "Keyword Setting")

            txtWordCall.Focus()
            Exit Sub
        End If

        '~~> Check if Conflict with Application Setting
        sql = "SELECT * FROM tbl_application WHERE LCASE(wordcall)=?word AND accountuser=?user"
        Dim app As New MySqlCommand(sql, con)
        app.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
        app.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(app)
        ds.Clear()
        da.Fill(ds, "app")

        If ds.Tables("app").Rows.Count > 0 Then
            message = "The wordcall is already used in one of the Application in Application Setting"
            MsgBox("The wordcall is already used in one of the Application in Application Setting", MsgBoxStyle.Information, "Keyword Setting")

            txtWordCall.Focus()
            Exit Sub
        End If

        '~~> Check if Conflict with Word Setting
        sql = "SELECT * FROM tbl_word WHERE LCASE(wordcall)=?word AND accountuser=?user"
        Dim word As New MySqlCommand(sql, con)
        word.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
        word.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(word)
        ds.Clear()
        da.Fill(ds, "word")

        If ds.Tables("word").Rows.Count > 0 Then
            message = "The wordcall is already used in one of the Word in Word Setting"
            MsgBox("The wordcall is already used in one of the Word in word setting", MsgBoxStyle.Information, "Keyword Setting")

            txtWordCall.Focus()
            Exit Sub
        End If

        If lblEdit.Text = "Save" Then
            '~~> Check if Conflict with other Keyword
            sql = "SELECT * FROM tbl_keyword WHERE LCASE(keywordcall)=?word AND (accountuser=?user OR isSystem='Yes')"
            Dim key As New MySqlCommand(sql, con)
            key.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
            key.Parameters.AddWithValue("?user", frmMenu.username)
            da = New MySqlDataAdapter(key)
            ds.Clear()
            da.Fill(ds, "exkey")

            If ds.Tables("exkey").Rows.Count > 0 Then
                message = "The wordcall is already used in Keyword Setting"
                MsgBox("The Wordcall is already used in Keyword Setting", MsgBoxStyle.Information, "Keyword Setting")

                txtWordCall.Focus()
                Exit Sub
            End If

            '~~> If no conflict, Save the New KeyWord
            sql = "INSERT INTO tbl_keyword VALUES(?word,?comm,?user,?is)"
            Dim addkey As New MySqlCommand(sql, con)
            addkey.Parameters.AddWithValue("?word", txtWordCall.Text)
            addkey.Parameters.AddWithValue("?comm", txtCommand.Text)
            addkey.Parameters.AddWithValue("?user", frmMenu.username)
            addkey.Parameters.AddWithValue("?is", "No")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addkey.ExecuteNonQuery()
            con.Close()

            LoadKeyword()

            message = "Successfully Registered a Keyword"
            MsgBox("Successfully Registered a Keyword", MsgBoxStyle.Information, "Keyword Setting")

            lblAdd.Enabled = True
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lvKeyword.Enabled = True
            lvSystem.Enabled = True

            txtWordCall.Enabled = False
            txtCommand.Enabled = False
        Else
            '~~> Check if Conflict with other Keyword
            sql = "SELECT * FROM tbl_keyword WHERE LCASE(keywordcall)=?word AND (accountuser=?user OR isSystem='Yes') AND (NOT LCASE(keywordcall)=?key)"
            Dim key As New MySqlCommand(sql, con)
            key.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
            key.Parameters.AddWithValue("?user", frmMenu.username)
            key.Parameters.AddWithValue("?key", txtWordCall.Tag)
            da = New MySqlDataAdapter(key)
            ds.Clear()
            da.Fill(ds, "exkey")

            If ds.Tables("exkey").Rows.Count > 0 Then
                message = "The wordcall is already used in Keyword Setting"
                MsgBox("The Wordcall is already used in Keyword Setting", MsgBoxStyle.Information, "Keyword Setting")

                txtWordCall.Focus()
                Exit Sub
            End If

            '~~> If no conflict, Update the KeyWord
            sql = "UPDATE tbl_keyword SET keywordcall=?word, toprint=?comm WHERE accountuser=?user AND keywordcall=?key"
            Dim upkey As New MySqlCommand(sql, con)
            upkey.Parameters.AddWithValue("?word", txtWordCall.Text)
            upkey.Parameters.AddWithValue("?comm", txtCommand.Text)
            upkey.Parameters.AddWithValue("?user", frmMenu.username)
            upkey.Parameters.AddWithValue("?key", txtWordCall.Tag)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upkey.ExecuteNonQuery()
            con.Close()

            LoadKeyword()

            message = "Successfully Updated a Keyword"
            MsgBox("Successfully Updated a Keyword", MsgBoxStyle.Information, "Keyword Setting")

            lblAdd.Enabled = True
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lvKeyword.Enabled = True
            lvSystem.Enabled = True

            txtWordCall.Enabled = False
            txtCommand.Enabled = False
        End If
    End Sub

    Sub LoadKeyword()
        lvKeyword.Items.Clear()
        lvSystem.Items.Clear()
        isSystem = False
        txtWordCall.Text = ""
        txtWordCall.Tag = ""
        txtCommand.Text = ""

        sql = "SELECT * FROM tbl_keyword WHERE accountuser=?user"
        Dim selkey As New MySqlCommand(sql, con)
        selkey.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(selkey)
        ds.Clear()
        da.Fill(ds, "key")

        If ds.Tables("key").Rows.Count > 0 Then
            For a = 1 To ds.Tables("key").Rows.Count
                Dim lv As ListViewItem = lvKeyword.Items.Add(ds.Tables("key").Rows(a - 1).Item("keywordcall").ToString)
                lv.SubItems.Add(ds.Tables("key").Rows(a - 1).Item("toprint").ToString)
            Next
        End If

        sql = "SELECT * FROM tbl_keyword WHERE isSystem='Yes'"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "syskey")

        If ds.Tables("syskey").Rows.Count > 0 Then
            For a = 1 To ds.Tables("syskey").Rows.Count
                Dim lv As ListViewItem = lvSystem.Items.Add(ds.Tables("syskey").Rows(a - 1).Item("keywordcall").ToString)
                lv.SubItems.Add(ds.Tables("syskey").Rows(a - 1).Item("toprint").ToString)
            Next
        End If
    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        If lblDelete.Text = "Delete" Then
            If txtWordCall.Tag = "" Then
                message = "Please select a Keyword that you want to Delete"
                MsgBox("Please select a Keyword that you want to Delete", MsgBoxStyle.Information, "Keyword Setting")

                Exit Sub
            End If

            If isSystem = True Then
                message = "Unable to Delete System's Default Keyword"
                MsgBox("Unable to Delete System's Default Keyword", MsgBoxStyle.Information, "Keyword Setting")

                Exit Sub
            End If

            message = "Press 'Yes' to Delete a keyword.. and 'No' to cancel"

            If MsgBox("Are you sure you want to Delete a Keyword?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Keyword Setting") = MsgBoxResult.Yes Then
                sql = "DELETE FROM tbl_keyword WHERE keywordcall=?word AND accountuser=?user"
                Dim delkey As New MySqlCommand(sql, con)
                delkey.Parameters.AddWithValue("?word", txtWordCall.Tag)
                delkey.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delkey.ExecuteNonQuery()
                con.Close()

                message = "Keyword Successfully Deleted"
                MsgBox("Keyword successfully Deleted", MsgBoxStyle.Information, "Keyword Setting")

                LoadKeyword()
            End If
        Else
            lblAdd.Enabled = True
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lvKeyword.Enabled = True
            lvSystem.Enabled = True

            txtWordCall.Enabled = False
            txtCommand.Enabled = False
        End If
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lvKeyword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvKeyword.Click
        If lvKeyword.Items.Count > 0 Then
            isSystem = False

            txtWordCall.Text = lvKeyword.FocusedItem.Text
            txtWordCall.Tag = lvKeyword.FocusedItem.Text
            txtCommand.Text = lvKeyword.FocusedItem.SubItems(1).Text
        End If
    End Sub

    Private Sub lvKeyword_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvKeyword.SelectedIndexChanged

    End Sub

    Private Sub lvSystem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSystem.Click

    End Sub

    Private Sub lvSystem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSystem.SelectedIndexChanged

    End Sub

    Private Sub txtWordCall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWordCall.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCommand.Focus()
        End If
    End Sub

    Private Sub txtWordCall_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWordCall.KeyPress
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

    Private Sub txtWordCall_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWordCall.TextChanged

    End Sub

    Private Sub txtCommand_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCommand.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveUpdate()
        End If
    End Sub

    Private Sub txtCommand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCommand.TextChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "help" Then
            If lblEdit.Text = "Edit" Then
                ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvKeyword, 5000)
                ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)

                ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvKeyword, 5000)
                ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
            ElseIf lblEdit.Text = "Save" Then
                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
            ElseIf lblEdit.Text = "Update" Then
                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)
            End If
        ElseIf e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarkey)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "add" Then
            If lblAdd.Enabled = True Then
                lblAdd.Enabled = False
                lblEdit.Text = "Save"
                lblDelete.Text = "Cancel"

                lvKeyword.Enabled = False
                lvSystem.Enabled = False

                txtWordCall.Enabled = True
                txtCommand.Enabled = True

                txtWordCall.Text = ""
                txtCommand.Text = ""

                txtWordCall.Focus()
            End If
        ElseIf e.Result.Text = "edit" Then
            If lblEdit.Text = "Edit" Then
                If txtWordCall.Tag = "" Then
                    message = "Please select a keyword that you want to Edit"
                    MsgBox("Please select a Keyword that you want to Edit", MsgBoxStyle.Information, "Keyword Setting")

                    Exit Sub
                End If

                If isSystem = True Then
                    message = "Unable to Edit System's Keyword"
                    MsgBox("Unable to Edit System's Keyword", MsgBoxStyle.Information, "Keyword Setting")

                    Exit Sub
                End If

                lblAdd.Enabled = False
                lblEdit.Text = "Update"
                lblDelete.Text = "Cancel"

                lvKeyword.Enabled = False
                lvSystem.Enabled = False

                txtWordCall.Enabled = True
                txtCommand.Enabled = True

                txtWordCall.Focus()
            End If
        ElseIf e.Result.Text = "update" Then
            If lblEdit.Text = "Update" Then
                SaveUpdate()
            End If
        ElseIf e.Result.Text = "save" Then
            If lblEdit.Text = "Save" Then
                SaveUpdate()
            End If
        ElseIf e.Result.Text = "cancel" Then
            If lblDelete.Text = "Cancel" Then
                lblAdd.Enabled = True
                lblEdit.Text = "Edit"
                lblDelete.Text = "Delete"

                lvKeyword.Enabled = True
                lvSystem.Enabled = True

                txtWordCall.Enabled = False
                txtCommand.Enabled = False
            End If
        ElseIf e.Result.Text = "delete" Then
            If lblDelete.Text = "Delete" Then
                If txtWordCall.Tag = "" Then
                    message = "Please select a Keyword that you want to Delete"
                    MsgBox("Please select a Keyword that you want to Delete", MsgBoxStyle.Information, "Keyword Setting")

                    Exit Sub
                End If

                If isSystem = True Then
                    message = "Unable to Delete System's Default Keyword"
                    MsgBox("Unable to Delete System's Default Keyword", MsgBoxStyle.Information, "Keyword Setting")

                    Exit Sub
                End If

                message = "Press 'Yes' to Delete a keyword.. and 'No' to cancel"

                If MsgBox("Are you sure you want to Delete a Keyword?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Keyword Setting") = MsgBoxResult.Yes Then
                    sql = "DELETE FROM tbl_keyword WHERE keywordcall=?word AND accountuser=?user"
                    Dim delkey As New MySqlCommand(sql, con)
                    delkey.Parameters.AddWithValue("?word", txtWordCall.Tag)
                    delkey.Parameters.AddWithValue("?user", frmMenu.username)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    delkey.ExecuteNonQuery()
                    con.Close()

                    message = "Keyword Successfully Deleted"
                    MsgBox("Keyword successfully Deleted", MsgBoxStyle.Information, "Keyword Setting")

                    LoadKeyword()
                End If
            End If
        End If
    End Sub

End Class