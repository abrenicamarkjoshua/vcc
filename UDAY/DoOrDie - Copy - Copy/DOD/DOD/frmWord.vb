Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Imports System.Speech.Recognition

Public Class frmWord
    Public isTutorial As String = "No"

    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer

    Public Sub LoadCommands()

    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                If isTutorial = "Yes" Then
                    message = "In Word Setting, you can set text to be printed by the System."
                End If

                Try
                    rec.LoadGrammar(grammarword)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try

                LoadType()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarword)
                    rec.UnloadGrammar(grammarspecial)
                Catch : End Try

                If isTutorial = "No" Then
                    frmMenu.isActivate = True
                    frmMenu.Show()
                ElseIf isTutorial = "Skip" Then
                Else
                    frmTutorial.MoveIndicator.Tag = "Keyword"
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
            rec.UnloadGrammar(grammarword)
            rec.UnloadGrammar(grammarspecial)
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

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub frmWord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isTutorial = "Yes" Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click

    End Sub

    Dim wordtype As String = ""
    Dim worduser As String = ""

    Private gr As New GrammarBuilder
    Dim grammarspecial As Grammar

    Dim wordlist As New List(Of String)

    Sub LoadType()
        lvType.Items.Clear()
        lvType.Tag = ""
        lvList.Items.Clear()
        lvList.Tag = ""
        wordtype = ""
        worduser = ""

        Try
            sql = "SELECT * FROM tbl_wordtype WHERE accountuser='System' OR accountuser=?user"
            Dim wordtypes As New MySqlCommand(sql, con)
            wordtypes.Parameters.AddWithValue("?user", frmMenu.username)

            da = New MySqlDataAdapter(wordtypes)
            ds.Clear()
            da.Fill(ds, "wordtype")

            wordlist.Clear()

            If ds.Tables("wordtype").Rows.Count > 0 Then
                Dim wordchoice As New Choices

                For a = 1 To ds.Tables("wordtype").Rows.Count
                    Dim lv As ListViewItem = lvType.Items.Add(ds.Tables("wordtype").Rows(a - 1).Item("wordtype").ToString)
                    lv.SubItems.Add(ds.Tables("wordtype").Rows(a - 1).Item("accountuser").ToString)

                    Try
                        wordchoice.Add(LCase(ds.Tables("wordtype").Rows(a - 1).Item("wordtype").ToString))
                        wordlist.Add(LCase(ds.Tables("wordtype").Rows(a - 1).Item("wordtype").ToString))
                    Catch : End Try
                Next

                lblSelected.Text = frmMenu.wordtype
                wordtype = frmMenu.wordtype

                LoadWords()

                Try
                    rec.UnloadGrammar(grammarspecial)
                Catch : End Try

                gr = New GrammarBuilder

                gr.Append(wordchoice)

                grammarspecial = New Grammar(gr)
                Try
                    rec.LoadGrammar(grammarspecial)
                Catch : End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading - Word Setting")
        End Try
    End Sub

    Sub LoadWords()
        lvList.Items.Clear()
        lvList.Tag = ""
        txtPrint.Text = ""
        txtWordCall.Text = ""

        Try
            sql = "SELECT * FROM tbl_word WHERE avail=?type AND (accountuser=?user OR accountuser='System')"
            Dim wordlist As New MySqlCommand(sql, con)
            wordlist.Parameters.AddWithValue("?type", wordtype)
            wordlist.Parameters.AddWithValue("?user", frmMenu.username)

            da = New MySqlDataAdapter(wordlist)
            ds.Clear()
            da.Fill(ds, "wordlist")

            If ds.Tables("wordlist").Rows.Count > 0 Then
                For a = 1 To ds.Tables("wordlist").Rows.Count
                    Dim lv As ListViewItem = lvList.Items.Add(ds.Tables("wordlist").Rows(a - 1).Item("wordcall").ToString)
                    lv.SubItems.Add(ds.Tables("wordlist").Rows(a - 1).Item("toprint").ToString)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading Words List")
        End Try
    End Sub

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        isVoice = False

        AddWord()
    End Sub

    Sub AddWord()
        If wordtype = "" Then
            message = "Please select a word type to add new words"

            If isVoice = False Then
                MsgBox("Please select a word type to add new words", MsgBoxStyle.Information, "Word Setting")
            End If

            Exit Sub
        End If

        If isVoice = True Then
            message = "Add"
        End If

        lblAdd.Enabled = False
        lblEdit.Text = "Save"
        lblDelete.Text = "Cancel"
        lblManage.Enabled = False

        txtWordCall.Enabled = True
        txtPrint.Enabled = True

        lvList.Enabled = False
        lvType.Enabled = False

        txtWordCall.Text = ""
        txtWordCall.Tag = ""
        txtPrint.Text = ""

        txtWordCall.Focus()
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Public isSystem As Boolean = False

    Sub SaveUpdate()
        If txtWordCall.Text = "" Then
            message = "Please enter the Word Call"

            If isVoice = False Then
                MsgBox("Please enter the word call", MsgBoxStyle.Information, "Word Setting")
            End If

            txtWordCall.Focus()
            Exit Sub
        End If

        If txtPrint.Text = "" Then
            message = "Please enter the Text-to-Print"

            If isVoice = False Then
                MsgBox("Please enter the Text-to-Print", MsgBoxStyle.Information, "Word Setting")
            End If

            txtPrint.Focus()
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
            message = "The wordcall is already used in one of the computer."

            If isVoice = False Then
                MsgBox("The wordcall is already used in one of the computer", MsgBoxStyle.Information, "Word Setting")
            End If

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

            If isVoice = False Then
                MsgBox("The wordcall is already used in one of the Application in Application Setting", MsgBoxStyle.Information, "Word Setting")
            End If

            txtWordCall.Focus()
            Exit Sub
        End If

        '~~> Check if Conflict with Application Type
        sql = "SELECT * FROM tbl_apptype WHERE LCASE(appname)=?word"
        Dim apptype As New MySqlCommand(sql, con)
        apptype.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
        apptype.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(apptype)
        ds.Clear()
        da.Fill(ds, "apptype")

        If ds.Tables("apptype").Rows.Count > 0 Then
            message = "The wordcall is already used in one of the Application Type"

            If isVoice = False Then
                MsgBox("The wordcall is already used in one of the Application Type", MsgBoxStyle.Information, "Word Setting")
            End If

            txtWordCall.Focus()
            Exit Sub
        End If

        '~~> Check if Conflict with keyword Setting
        sql = "SELECT * FROM tbl_keyword WHERE LCASE(keywordcall)=?word AND (accountuser=?user OR isSystem='Yes')"
        Dim keyword As New MySqlCommand(sql, con)
        keyword.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
        keyword.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(keyword)
        ds.Clear()
        da.Fill(ds, "keyword")

        If ds.Tables("keyword").Rows.Count > 0 Then
            message = "The wordcall is already used in one of the Word in Keyword Setting"

            If isVoice = False Then
                MsgBox("The wordcall is already used in one of the Word in Keyword Setting", MsgBoxStyle.Information, "Word Setting")
            End If

            txtWordCall.Focus()
            Exit Sub
        End If

        If lblEdit.Text = "Save" Then
            '~~> Check if conflict with other Word
            sql = "SELECT * FROM tbl_word WHERE LCASE(wordcall)=?word AND (accountuser=?user OR accountuser='System') AND avail=?type"
            Dim exword As New MySqlCommand(sql, con)
            exword.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
            exword.Parameters.AddWithValue("?user", frmMenu.username)
            exword.Parameters.AddWithValue("?type", wordtype)
            da = New MySqlDataAdapter(exword)
            ds.Clear()
            da.Fill(ds, "exword")

            If ds.Tables("exword").Rows.Count > 0 Then
                message = "The wordcall that you're trying to use already exist"

                If isVoice = False Then
                    MsgBox("The wordcall that you're trying to use already exist", MsgBoxStyle.Information, "Word Setting")
                End If

                txtWordCall.Focus()
                Exit Sub
            End If

            '~~> If not, Save the New Word
            sql = "INSERT INTO tbl_word VALUES(?word,?print,?avail,?user)"
            Dim addword As New MySqlCommand(sql, con)
            addword.Parameters.AddWithValue("?word", txtWordCall.Text)
            addword.Parameters.AddWithValue("?print", txtPrint.Text)
            addword.Parameters.AddWithValue("?avail", wordtype)
            addword.Parameters.AddWithValue("?user", frmMenu.username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addword.ExecuteNonQuery()
            con.Close()

            message = "Successfully Register a New Word"

            If isVoice = False Then
                MsgBox("Successfully Register a New Word", MsgBoxStyle.Information, "Word Setting")
            End If

            LoadWords()

            lblAdd.Enabled = True
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"
            lblManage.Enabled = True

            txtWordCall.Enabled = False
            txtPrint.Enabled = False

            lvList.Enabled = True
            lvType.Enabled = True
        Else
            '~~> Check if conflict with other Word
            sql = "SELECT * FROM tbl_word WHERE LCASE(wordcall)=?word AND (accountuser=?user OR accountuser='System') AND avail=?type AND (NOT LCASE(wordcall)=?call)"
            Dim exword As New MySqlCommand(sql, con)
            exword.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
            exword.Parameters.AddWithValue("?user", frmMenu.username)
            exword.Parameters.AddWithValue("?type", wordtype)
            exword.Parameters.AddWithValue("?call", LCase(txtWordCall.Tag))
            da = New MySqlDataAdapter(exword)
            ds.Clear()
            da.Fill(ds, "exword")

            If ds.Tables("exword").Rows.Count > 0 Then
                message = "The wordcall that you're trying to use already exist"

                If isVoice = False Then
                    MsgBox("The wordcall that you're trying to use already exist", MsgBoxStyle.Information, "Word Setting")
                End If

                txtWordCall.Focus()
                Exit Sub
            End If

            '~~> If not, Update the Word
            sql = "UPDATE tbl_word SET wordcall=?word, toprint=?print WHERE wordcall=?call AND accountuser=?user"
            Dim upword As New MySqlCommand(sql, con)
            upword.Parameters.AddWithValue("?word", txtWordCall.Text)
            upword.Parameters.AddWithValue("?print", txtPrint.Text)
            upword.Parameters.AddWithValue("?call", txtWordCall.Tag)
            upword.Parameters.AddWithValue("?user", frmMenu.username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upword.ExecuteNonQuery()
            con.Close()

            message = "Successfully Updated a Word"

            If isVoice = False Then
                MsgBox("Successfully Updated a Word", MsgBoxStyle.Information, "Word Setting")
            End If

            LoadWords()

            lblAdd.Enabled = True
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"
            lblManage.Enabled = True

            txtWordCall.Enabled = False
            txtPrint.Enabled = False

            lvList.Enabled = True
            lvType.Enabled = True
        End If
    End Sub

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        isVoice = False

        If lblEdit.Text = "Edit" Then
            Edit()
        Else
            SaveUpdate()
        End If
    End Sub

    Sub Edit()
        If txtWordCall.Tag = "" Then
            message = "Please select a Word from the List that you want to Edit"

            If isVoice = False Then
                MsgBox("Please select a Word from the list that you want to Edit", MsgBoxStyle.Information, "Word Setting")
            End If

            Exit Sub
        End If

        If isVoice = True Then
            message = "Edit"
        End If

        lblAdd.Enabled = False
        lblEdit.Text = "Update"
        lblDelete.Text = "Cancel"
        lblManage.Enabled = False

        txtWordCall.Enabled = True
        txtPrint.Enabled = True

        lvList.Enabled = False
        lvType.Enabled = False

        txtWordCall.Focus()
    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Sub DeleteWord()
        '~~> Delete
        If txtWordCall.Text = "" Then
            message = "Please select a Word that you want to Delete"

            If isVoice = False Then
                MsgBox("Please select a word that you want to delete", MsgBoxStyle.Information, "Word Setting")
            End If

            Exit Sub
        End If

        If isVoice = True Then
            GoTo skip
        Else
            If MsgBox("Are you sure you want to Delete the Word?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Word Setting") = MsgBoxResult.Yes Then
skip:
                sql = "DELETE FROM tbl_word WHERE wordcall=?word AND accountuser=?user"
                Dim delword As New MySqlCommand(sql, con)
                delword.Parameters.AddWithValue("?word", txtWordCall.Tag)
                delword.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delword.ExecuteNonQuery()
                con.Close()

                message = "Successfully Deleted a Word"

                If isVoice = False Then
                    MsgBox("Successfully Deleted a Word", MsgBoxStyle.Information, "Word Setting")
                End If

                LoadWords()
            End If
        End If
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        isVoice = False

        If lblDelete.Text = "Delete" Then
            DeleteWord()
        Else
            Cancel()
        End If
    End Sub

    Sub Cancel()
        '~~> Cancel
        lblAdd.Enabled = True
        lblManage.Enabled = True
        lblEdit.Text = "Edit"
        lblDelete.Text = "Delete"

        txtWordCall.Enabled = False
        txtPrint.Enabled = False

        txtWordCall.Text = txtWordCall.Tag
        txtPrint.Text = txtPrint.Tag

        lvList.Enabled = True
        lvType.Enabled = True
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lvList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvList.Click
        If lvList.Items.Count > 0 Then
            lvList.Tag = lvList.FocusedItem.Text
            txtWordCall.Text = lvList.FocusedItem.Text
            txtWordCall.Tag = lvList.FocusedItem.Text
            txtPrint.Text = lvList.FocusedItem.SubItems(1).Text
        End If
    End Sub

    Private Sub lvDisable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged

    End Sub

    Private Sub txtWordCall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWordCall.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPrint.Focus()
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

    Private Sub txtPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrint.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveUpdate()
        End If
    End Sub

    Private Sub txtPrint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrint.KeyPress

    End Sub

    Private Sub txtPrint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrint.TextChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarword)
                rec.UnloadGrammar(grammarspecial)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "help" Then

        ElseIf e.Result.Text = "add" Then
            If lblAdd.Enabled = True Then
                AddWord()
            End If
        ElseIf e.Result.Text = "edit" Then
            If lblEdit.Text = "Edit" Then
                isVoice = True

                Edit()
            End If
        ElseIf e.Result.Text = "update" Then
            If lblEdit.Text = "Update" Then
                isVoice = True

                Update()
            End If
        ElseIf e.Result.Text = "save" Then
            If lblEdit.Text = "Save" Then
                isVoice = True

                SaveUpdate()
            End If
        ElseIf e.Result.Text = "cancel" Then
            If lblDelete.Text = "Cancel" Then
                message = "Cancel"

                isVoice = False

                Cancel()
            End If
        ElseIf e.Result.Text = "delete" Then
            If lblDelete.Text = "Delete" Then
                isVoice = False

                DeleteWord()
            End If
        ElseIf e.Result.Text = "manage" Then
            If lblManage.Enabled = True Then
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarword)
                    rec.UnloadGrammar(grammarspecial)
                Catch : End Try

                frmWordType.ShowDialog()
            End If
        Else
            If lvType.Enabled = True Then
                If wordlist.Contains(e.Result.Text) Then
                    For a = 1 To lvType.Items.Count
                        If LCase(lvType.Items(a - 1).Text) = LCase(e.Result.Text) Then
                            lvType.Items(a - 1).Focused = True

                            wordtype = lvType.Items(a - 1).Text
                            worduser = lvType.Items(a - 1).SubItems(1).Text

                            lvType.Items(a - 1).Selected = True

                            lblSelected.Text = wordtype

                            sql = "UPDATE tbl_account SET wordtype=?word WHERE accountuser=?user"
                            Dim upacc As New MySqlCommand(sql, con)
                            upacc.Parameters.AddWithValue("?word", wordtype)
                            upacc.Parameters.AddWithValue("?user", frmMenu.username)

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            upacc.ExecuteNonQuery()
                            con.Close()

                            frmMenu.wordtype = wordtype

                            LoadWords()

                            Exit Sub
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Dim selindex As Integer

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lvType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvType.Click
        If lvType.Items.Count > 0 Then
            wordtype = lvType.FocusedItem.Text
            worduser = lvType.FocusedItem.SubItems(1).Text

            lblSelected.Text = wordtype

            sql = "UPDATE tbl_account SET wordtype=?word WHERE accountuser=?user"
            Dim upacc As New MySqlCommand(sql, con)
            upacc.Parameters.AddWithValue("?word", wordtype)
            upacc.Parameters.AddWithValue("?user", frmMenu.username)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upacc.ExecuteNonQuery()
            con.Close()

            LoadWords()
        End If
    End Sub

    Private Sub lvType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvType.SelectedIndexChanged

    End Sub

    Dim isType As Boolean = False

    Private Sub lblAddType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblManage.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarword)
            rec.UnloadGrammar(grammarspecial)
        Catch : End Try

        frmWordType.ShowDialog()
    End Sub

    Private Sub lblAddType_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblManage.MouseLeave
        lblManage.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAddType_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblManage.MouseMove
        lblManage.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

End Class