Public Class professor
    Inherits user
    Implements IUser


    Private _enable_tutorial As Boolean
    Private _enable_tutorial_voice As Boolean
    Public ReadOnly Property enable_tutorial() As Boolean
        Get
            Return Me._enable_tutorial
        End Get
    End Property
    Public ReadOnly Property enable_tutorial_voice() As Boolean
        Get
            Return Me._enable_tutorial_voice
        End Get
    End Property
    Public Sub New(ByVal username As String, ByVal password As String)
        MyBase.New(username, password)

        Me._enable_tutorial = IIf(Me._details("enable_tutorial").ToString() = "yes", True, False)
        Me._enable_tutorial_voice = IIf(Me._details("enable_tutorial_voice").ToString() = "yes", True, False)
    End Sub
    Public Sub login() Implements IUser.login


        output.message("Welcome " & _username)
        VCC.LOGIN.Hide()
        If enable_tutorial = True Then

            tutorial_mode.Show()
        Else

            DASHBOARD.professor = Me
            MY_ACCOUNT.Show()
        End If
        database.query2("UPDATE users SET loggedIn = 'loggedin', ipaddress = ? WHERE id = ?", New ArrayList() From {Me._ipaddress, Me._id})

    End Sub
   
    Public Sub logout(ByVal ipaddress As String) Implements IUser.logout
        'if ipaddress is this local machine, no need to send the command to the other pc.
        If (IpAddress = strategy_localComputer.getIpAddress()) Then
            'this is highly coupled. needs refactoring, after you read and master that book.
          
                    DASHBOARD.Close()

             
            
            database.query("UPDATE sections SET status = 'Offline'")
           
            'update user status in database
           

            VCC.LOGIN.Show()
            database.query2("UPDATE users SET loggedin = '' WHERE id = ?", New ArrayList() From {id})


            'if ipaddress is not on local machine
        Else
            sender_class.send_message("logout@professor@" & id, ipaddress)
                
        End If
    End Sub
End Class
