Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text

Module controllers_and_functions

    Public Function sanitize(ByVal my_string As String) As String

        Return Trim(my_string).Replace("\", "\\")

    End Function

    Public Function hash(ByVal string_value As String, ByVal limit As Integer) As String
        Return passwordEncryptSHA(string_value).Substring(0, limit)

    End Function
    Public Sub my_function(ByVal valname As Integer, ByRef valname2 As Integer)
        valname = valname + 1

        valname2 = valname2 + 1
        'do something

    End Sub
    Public Sub many_return(ByRef val1 As Integer, ByRef val2 As Integer, ByRef val3 As Integer)
        val1 = val1 + 1
        val2 = val2 + 2
        val3 = val3 + 3

    End Sub
    Public WithEvents myControl As TextBox

    Private Sub txt_input_KeyDown(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        If Convert.ToInt16(e.KeyChar) = 13 Then

            SendKeys.Send("{TAB}")
            Exit Sub
        End If

        'all capital letter
        'e.KeyChar = Char.ToUpper(e.KeyChar)


    End Sub


    Public Sub add_enter_events(ByVal my_form As Form)


        For Each my_control As Control In my_form.Controls

            If my_control.GetType() Is GetType(TextBox) Then

                my_form.ActiveControl = my_control
                AddHandler my_control.KeyPress, AddressOf txt_input_KeyDown

            Else
                add_events(my_control)

            End If



        Next

    End Sub
    Public Sub add_events(ByVal my_controls As Control)


        For Each txt_input As Control In my_controls.Controls

            If txt_input.GetType() = GetType(TextBox) Then


                AddHandler txt_input.KeyPress, AddressOf txt_input_KeyDown


            ElseIf (txt_input.GetType() = GetType(Panel) Or txt_input.GetType() = GetType(TabPage) Or txt_input.GetType() = GetType(GroupBox) Or txt_input.GetType() = GetType(TabControl)) Then

                add_events(txt_input)


            Else
            End If

        Next


    End Sub
    Public Function has_blanks(ByVal rule As String, ByVal textbox_or_combobox As List(Of Control))
        For Each item As Control In textbox_or_combobox
            If String.IsNullOrEmpty(item.Text) Then
                Select Case rule
                    Case "all"
                        MessageBox.Show("All fields are required")
                    Case "asterisk"
                        MessageBox.Show("All fields with asterisk are required")
                End Select
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Private Function passwordEncryptSHA(ByVal password As String) As String
        Dim sha As New SHA1CryptoServiceProvider ' declare sha as a new SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte ' and here is a byte variable

        bytesToHash = System.Text.Encoding.ASCII.GetBytes(password) ' covert the password into ASCII code

        bytesToHash = sha.ComputeHash(bytesToHash) ' this is where the magic starts and the encryption begins

        Dim encPassword As String = ""

        For Each b As Byte In bytesToHash
            encPassword += b.ToString("x2")
        Next

        Return encPassword ' boom there goes the encrypted password!

    End Function
    Public Function exist(ByVal count_query As String, ByVal arraylist As ArrayList) As Boolean
        LOGIN.database.query2(count_query, arraylist)
        Return IIf(CInt(LOGIN.database.dt.Rows(0)(0).ToString()) > 0, True, False)

    End Function
    'API with stringBuilder class

End Module
