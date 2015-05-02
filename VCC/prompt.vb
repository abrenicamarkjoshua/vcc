Public Class prompt
    Private _result As String

    Public Enum resultEnum
        yes
        no
        cancel
    End Enum
    Public Shared Sub message(ByVal message)
        MessageBox.Show(message)
    End Sub
    Public ReadOnly Property result() As resultEnum
        Get
            Return Me._result
        End Get
    End Property
    Public Function promptAndClose(ByVal prompt As String) As resultEnum
        Dim result As Integer = MessageBox.Show(prompt, "Confirm select and close ", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Return resultEnum.yes
        End If
        'else
        Return resultEnum.no
    End Function
    Public Function closeWindowReturnLogin() As resultEnum
        Dim result As Integer = MessageBox.Show("Are you sure you want to close this window and return to login form?", "Close confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Return resultEnum.yes
        End If
        'else
        Return resultEnum.no
    End Function
    Public Function closeWindowReturnDashboard() As resultEnum
        Dim result As Integer = MessageBox.Show("Are you sure you want to close this window and return to dashboard?", "Close confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Return resultEnum.yes

        End If
        'else
        Return resultEnum.no
    End Function
    Public Function closeWindow() As resultEnum
        Dim result As Integer = MessageBox.Show("Are you sure you want to close this window?", "Close confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Return resultEnum.yes
        End If
        'else
        Return resultEnum.no
    End Function
    Public Sub logout()
        Dim result As Integer = MessageBox.Show("Are you sure you want to logout?", "Logout confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me._result = resultEnum.yes
        Else
            Me._result = resultEnum.no
        End If
    End Sub
    Public Sub logout2()
        Dim result As Integer = MessageBox.Show("Are you sure you want to logout? Timer will be set to 0 and activity will end.", "Logout confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me._result = resultEnum.yes
        Else
            Me._result = resultEnum.no
        End If
    End Sub
    Public Sub logoutExistingLogin()
        Dim result As Integer = MessageBox.Show("System detected that you are already logged in. Are you sure you want to logout the previous login?", "Logout other logged in user from different pc", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me._result = resultEnum.yes
        Else
            Me._result = resultEnum.no
        End If
    End Sub
End Class
