Public Class student
    Inherits user
    Implements IUser
    Public ReadOnly Property studentId() As String
        Get
            Return Me.id
        End Get
    End Property

    Public Sub New(ByVal username As String, ByVal password As String)
        MyBase.New(username, password)


    End Sub
    Public Sub login() Implements IUser.login

        'Select Case Me._userType
        '    Case userTypeEnum.professor
        '        database.query2("UPDATE users SET loggedIn = 'loggedin', ipaddress = ? WHERE id = ?", New ArrayList() From {Me._ipaddress, Me._id})
        '        output.message("Welcome " & _username)
        '        If CType(Me, professor).enable_tutorial Then

        '            tutorial_mode.Show()
        '        Else
        '            MY_ACCOUNT.Show()
        '            DASHBOARD.Show()
        '            DASHBOARD.user = Me
        '        End If

        '    Case userTypeEnum.student

        'register this computer
        'Register/update this client to the system if..

        If database.exist("SELECT COUNT(`computername`) FROM computers WHERE computername = ? AND ipaddress = ?", New ArrayList() From {strategy_localComputer.getComputerName(), strategy_localComputer.getIpAddress()}) Then
            'update
            database.query2("UPDATE computers SET connected = 'true' WHERE ipaddress = ? AND computername = ?", New ArrayList() From {strategy_localComputer.getIpAddress(), strategy_localComputer.getComputerName()})
        Else
            'insert
            'if not server

            database.query2("INSERT INTO computers(`computername`,`ipaddress`,`connected`,`word`) VALUES (?,?,?,?)", New ArrayList() From {strategy_localComputer.getComputerName(), strategy_localComputer.getIpAddress(), "yes", strategy_localComputer.getComputerName()})

        End If


        STUDENT_MODULE.Show()
        ' database.query2("UPDATE student_section SET loggedIn = 'loggedin', ipaddress = ? WHERE student_id = ?", New ArrayList() From {Me._ipaddress, Me._id})
        database.query2("UPDATE students SET loggedIn = 'loggedin', ipaddress = ? WHERE student_id = ?", New ArrayList() From {Me._ipaddress, Me._id})
        VCC.LOGIN.Hide()
        ' End Select
    End Sub
    Public Sub logout(ByVal ipaddress As String) Implements IUser.logout
        'if ipaddress is this local machine, no need to send the command to the other pc.
        If (ipaddress = strategy_localComputer.getIpAddress()) Then
            
            'update user status in database
            STUDENT_MODULE.Close()
            lecture.Close()


             VCC.LOGIN.Show()

            database.query2("UPDATE students SET loggedin = ''  WHERE student_id = ?", New ArrayList() From {id})
            ' database.query2("UPDATE computers SET timeout = ?  WHERE ipaddress = ?", New ArrayList() From {"", strategy_localComputer.getIpAddress()})

            'else if ipaddress is not on local machine
        Else
            'if SELECT * FROM students WHERE     
            sender_class.send_message("logout@student@" & id, ipaddress)
           
        End If
    End Sub
End Class
