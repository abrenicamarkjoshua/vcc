Public Class add_section_with_access_code
    Public result As Boolean = False
    Public accesscode As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub add_section_with_access_code_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Field must not be empty")
            Exit Sub
        End If
        If TextBox1.Text = accesscode Then
            Me.result = True
            Me.Close()
        Else
            MessageBox.Show("Wrong access code")
        End If
    End Sub
End Class