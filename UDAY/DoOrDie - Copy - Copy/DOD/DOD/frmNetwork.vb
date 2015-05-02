Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Imports System.Speech.Recognition

Public Class frmNetwork
    Public isTutorial As String = "No"

    Dim detectedcount As Integer = 0

    Sub LoadComputers()
        sql = "SELECT * FROM tbl_computer"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "comp")

        If ds.Tables("comp").Rows.Count > 0 Then
            If Not lvDetected.Items.Count = ds.Tables("comp").Rows.Count Then
                lvDetected.Items.Clear()

                For a = 1 To ds.Tables("comp").Rows.Count
                    Dim lv As ListViewItem = lvDetected.Items.Add(ds.Tables("comp").Rows(a - 1).Item("wordcall").ToString)
                    lv.SubItems.Add(ds.Tables("comp").Rows(a - 1).Item("ipaddress").ToString)
                    lv.SubItems.Add(ds.Tables("comp").Rows(a - 1).Item("computername").ToString)

                    If ds.Tables("comp").Rows(a - 1).Item("computername").ToString = My.Computer.Name Then
                        frmTutorial.compwordcall = ds.Tables("comp").Rows(a - 1).Item("wordcall").ToString
                    End If
                Next
            End If
        Else
            lvDetected.Items.Clear()
        End If
    End Sub

    Dim lvcount As Integer = 0

    Private Sub frmNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'frmMenu.checknetwork()

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

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadComputers()

                Try
                    netrec.LoadGrammar(grammarnet)
                    netrec.SetInputToDefaultAudioDevice()
                    netrec.RecognizeAsync(1)
                Catch : End Try

                If isTutorial = "Yes" Then
                    message = "In Network Setting, you can configure the word to call the registered clients."
                End If
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    netrec.RecognizeAsyncStop()
                    netrec.UnloadGrammar(grammarnet)
                Catch ex As Exception

                End Try

                If isTutorial = "No" Then
                    frmMenu.isActivate = True
                    frmMenu.Show()
                ElseIf isTutorial = "Skip" Then
                Else
                    frmTutorial.MoveIndicator.Tag = "Application"
                    frmTutorial.MoveIndicator.Start()
                End If

                Me.Close()
            End If
        End If
    End Sub

    Dim isDraggable As Boolean = False
    Dim currx, curry As Integer

    Private Sub frmNetwork_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        isDraggable = True
        currx = Windows.Forms.Cursor.Position.X - Me.Left
        curry = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmNetwork_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If isDraggable = True Then
            Me.Left = Windows.Forms.Cursor.Position.X - currx
            Me.Top = Windows.Forms.Cursor.Position.Y - curry
        End If
    End Sub

    Private Sub frmNetwork_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        isDraggable = False
    End Sub

    Private Sub lvDetected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetected.Click
        If lvDetected.Items.Count > 0 Then
            txtWordCall.Text = lvDetected.FocusedItem.Text
            txtWordCall.Tag = lvDetected.FocusedItem.Text
            txtIP.Text = lvDetected.FocusedItem.SubItems(1).Text
            txtName.Text = lvDetected.FocusedItem.SubItems(2).Text
        End If
    End Sub

    Dim editcount As Integer = 0

    Private Sub lblUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUpdate.Click
        If lblUpdate.Text = "Edit" Then
            If txtName.Text = "" Then
                message = "Please select a client on the List that you want to Edit"
                MsgBox("Please select a client on the list that you want to Edit", MsgBoxStyle.Information, "Network Setting")

                Exit Sub
            End If

            lblUpdate.Text = "Update"
            lblDelete.Text = "Cancel"

            txtWordCall.Enabled = True
            lvDetected.Enabled = False
        Else
            SaveUpdate()
        End If
    End Sub

    Sub SaveUpdate()
        If txtWordCall.Text = "" Then
            message = "Please enter the Word to call the Client"
            MsgBox("Please enter the Word to call the Client", MsgBoxStyle.Information, "Network Setting")

            txtWordCall.Focus()
            Exit Sub
        End If

        sql = "SELECT * FROM tbl_computer WHERE LCASE(wordcall)=?word AND (NOT computername=?comp)"
        Dim comp As New MySqlCommand(sql, con)
        comp.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
        comp.Parameters.AddWithValue("?comp", txtName.Text)
        da = New MySqlDataAdapter(comp)
        da.Fill(ds, "computer")

        If ds.Tables("computer").Rows.Count > 0 Then
            message = "The word call that you're trying to use already exist"
            MsgBox("The word call that you're trying to use already exist", MsgBoxStyle.Information, "Network Setting")

            txtWordCall.Focus()
            Exit Sub
        End If

        If isTutorial = "Yes" Then
            sql = "UPDATE tbl_computer SET wordcall=?word WHERE computername=?name"
            Dim upcomp As New MySqlCommand(sql, con)
            upcomp.Parameters.AddWithValue("?word", txtWordCall.Text)
            upcomp.Parameters.AddWithValue("?name", txtName.Text)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upcomp.ExecuteNonQuery()
            con.Close()
        Else
            sql = "UPDATE tbl_computer SET wordcall=?word WHERE computername=?name"
            Dim upcomp As New MySqlCommand(sql, con)
            upcomp.Parameters.AddWithValue("?word", txtWordCall.Text)
            upcomp.Parameters.AddWithValue("?name", txtName.Text)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upcomp.ExecuteNonQuery()
            con.Close()
        End If

        lblUpdate.Text = "Edit"
        lblDelete.Text = "Delete"

        txtWordCall.Enabled = False
        lvDetected.Enabled = True

        frmTutorial.compwordcall = txtWordCall.Text

        lvDetected.Items.Clear()

        LoadComputers()

        message = "Successfully Updated a Client's word call"
        MsgBox("Successfully Updated a Client's word call", MsgBoxStyle.Information, "Network Setting")
        isHelp = False

        txtName.Text = ""
        txtWordCall.Text = ""
        txtWordCall.Tag = ""
        txtIP.Text = ""
    End Sub

    Dim updatecount As Integer = 0

    Private Sub lblUpdate_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUpdate.MouseLeave
        lblUpdate.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblUpdate_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblUpdate.MouseMove
        lblUpdate.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            netrec.RecognizeAsyncStop()
            netrec.UnloadGrammar(grammarnet)
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

    Dim deletecount As Integer = 0

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        If lblDelete.Text = "Delete" Then
            If txtName.Text = "" Then
                message = "Please select a Client from the List that you want to Delete"
                MsgBox("Please select a Client from the List that you want to Delete", MsgBoxStyle.Information, "Network Setting")

                Exit Sub
            End If

            If txtName.Text = My.Computer.Name Then
                message = "Unable to Delete your Computer from the List"
                MsgBox("Unable to Delete your computer from the List", MsgBoxStyle.Information, "Network Setting")

                Exit Sub
            End If

            isMessagebox = True
            message = "Press 'Yes' to Delete the Client.. and 'No' to cancel"

            If MsgBox("Are you sure you want to Delete " & txtName.Text & " from the List of Detected Computers?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Detected Computer") = MsgBoxResult.Yes Then
                sql = "DELETE FROM tbl_computer WHERE computername=?name"
                Dim delcomp As New MySqlCommand(sql, con)
                delcomp.Parameters.AddWithValue("?name", txtName.Text)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delcomp.ExecuteNonQuery()
                con.Close()

                message = "A client has been Successfully Deleted"
                MsgBox("A client has been Successfully Deleted", MsgBoxStyle.Information, "Network Setting")

                isHelp = False

                LoadComputers()
            Else
                isMessagebox = False
            End If
        Else
            lblUpdate.Text = "Edit"
            lblDelete.Text = "Delete"

            txtWordCall.Enabled = False
            lvDetected.Enabled = True
        End If
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lvDetected_SearchForVirtualItem(ByVal sender As Object, ByVal e As System.Windows.Forms.SearchForVirtualItemEventArgs) Handles lvDetected.SearchForVirtualItem

    End Sub

    Private Sub lvDetected_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDetected.SelectedIndexChanged
        If lvDetected.Items.Count > 0 Then
            
        End If
    End Sub

    Public isHelp As Boolean = False
    Public isSelect As Boolean = False

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If lblUpdate.Text = "Edit" Then
            ToolTip1.Show("Select a Computer from the List that you want to Edit/Delete", Me.lvDetected, 5000)
            ToolTip1.Show("Select a Computer from the List that you want to Edit/Delete", Me.lvDetected, 5000)
        Else
            ToolTip1.Show("Enter the new Word Call for " & txtName.Text, Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Update' to save the changes made for " & txtName.Text, Me.lblUpdate, 5000)

            ToolTip1.Show("Enter the new Word Call for " & txtName.Text, Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Update' to save the changes made for " & txtName.Text, Me.lblUpdate, 5000)
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

    Private Sub txtWordCall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWordCall.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveUpdate()
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

    Public WithEvents netrec As New System.Speech.Recognition.SpeechRecognitionEngine
    Dim isMessagebox As Boolean = False

    Public Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles netrec.SpeechRecognized
       If e.Result.Text = "close" Then
            If isMessagebox = False Then
                message = "Closing"
                Try
                    netrec.RecognizeAsyncStop()
                    netrec.UnloadGrammar(grammarnet)
                Catch : End Try
                Animation.Tag = "Hide"
                Animation.Start()
            End If
        ElseIf e.Result.Text = "help" Then
            If isMessagebox = False Then
                If lblUpdate.Text = "Edit" Then
                    ToolTip1.Show("Select a Computer from the List that you want to Edit/Delete", Me.lvDetected, 5000)
                    ToolTip1.Show("Select a Computer from the List that you want to Edit/Delete", Me.lvDetected, 5000)
                Else
                    ToolTip1.Show("Enter the new Word Call for " & txtName.Text, Me.txtWordCall, 5000)
                    ToolTip2.Show("Click 'Update' to save the changes made for " & txtName.Text, Me.lblUpdate, 5000)

                    ToolTip1.Show("Enter the new Word Call for " & txtName.Text, Me.txtWordCall, 5000)
                    ToolTip2.Show("Click 'Update' to save the changes made for " & txtName.Text, Me.lblUpdate, 5000)
                End If
            End If
        ElseIf e.Result.Text = "delete" Then
            If isMessagebox = False Then
                If lblDelete.Text = "Delete" Then
                    If txtName.Text = "" Then
                        message = "Please select a Client from the List that you want to Delete"

                        Exit Sub
                    End If

                    If txtName.Text = My.Computer.Name Then
                        message = "Unable to Delete your Computer from the List"

                        Exit Sub
                    End If

                    message = "Press 'Yes' to delete the Client.. and 'No' to cancel"

                    If MsgBox("Are you sure you want to Delete the Client?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Network Setting") = MsgBoxResult.Yes Then
                        sql = "DELETE FROM tbl_computer WHERE computername=?name"
                        Dim delcomp As New MySqlCommand(sql, con)
                        delcomp.Parameters.AddWithValue("?name", txtName.Text)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        delcomp.ExecuteNonQuery()
                        con.Close()

                        message = "A client has been Successfully Deleted"

                        LoadComputers()
                        isHelp = False
                    End If
                End If
            End If
        ElseIf e.Result.Text = "cancel" Then
            If isMessagebox = False Then
                If lblDelete.Text = "cancel" Then
                    lblUpdate.Text = "Edit"
                    lblDelete.Text = "Delete"

                    txtWordCall.Enabled = False
                    lvDetected.Enabled = True
                End If
            End If
        ElseIf e.Result.Text = "edit" Then
            If isMessagebox = False Then
                If lblUpdate.Text = "Edit" Then
                    If txtName.Text = "" Then
                        message = "Please select a client on the List that you want to Edit"

                        Exit Sub
                    End If

                    lblUpdate.Text = "Update"
                    lblDelete.Text = "Cancel"

                    txtWordCall.Enabled = True
                    lvDetected.Enabled = False
                End If
            End If
        ElseIf e.Result.Text = "update" Then
            If isMessagebox = False Then
                If lblUpdate.Text = "Update" Then
                    SaveUpdate()
                End If
            End If
        End If
    End Sub

End Class