Public Class openning_of_files
    Public command_phrase As String = ""
    Private insertion_code As String = ""
    Public mode As String = "register"
    Private Sub openning_of_files_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        insertion_code = GetRandom(1, 2147483647).ToString().PadLeft(11, "0")
        Select Case mode
            Case "register"
                btn_register_phrase.Text = "register command"
            Case "update"
                btn_register_phrase.Text = "update command"
        End Select

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lbl_file_location.Text = ofd.FileName
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If ofd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lbl_application_location.Text = ofd.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
      
    End Sub

    Private Sub btn_register_phrase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register_phrase.Click
        Dim file_location As String = lbl_file_location.Text
        Dim application_location As String = lbl_application_location.Text
        Try
            'register or update?
            Select Case mode
                Case "register"
                    btn_register_phrase.Text = "register command"
                    Dim sql As String = "INSERT INTO voice_commands(phrase, command_type, command_type_id, user) VALUES ('" + sanitize(command_phrase) + "','openning of files','" + insertion_code + "','" + LOGIN.user_info.Rows(0)("id").ToString() + "')"

                    MessageBox.Show(sql)
                    sql = "INSERT INTO openning_of_files VALUES ('" + insertion_code + "','" + LOGIN.user_info.Rows(0)("id").ToString() + "','" + file_location + "','" + application_location + "')"
                    MessageBox.Show(sql)
                    LOGIN.database.query(sql)
                    'Success
                Case "update"
                    btn_register_phrase.Text = "update command"
            End Select

        Catch ex As Exception
            Exit Sub
            'if error, do not proceed
        End Try
        MessageBox.Show("SUCCESSFULLY REGISTERED!")
        'if no error, continue
        Me.Close()

    End Sub

    Public Sub New(ByVal mode As String, ByVal phrase As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.mode = mode
        Me.command_phrase = phrase
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class