
Public Class user


    Protected database As database = New database()
    Protected _id As String
    Protected _username As String
    Protected _password As String
    Protected _ipaddress As String = strategy_localComputer.getIpAddress()
    Protected _isLoggedIn As Boolean = False
    Protected _isProfessor As Boolean = False
    Protected _isStudent As Boolean = False
    Protected _lastIpAddress As String
    Public Enum userTypeEnum
        professor
        student
    End Enum
    Protected _userType As Integer
    Public ReadOnly Property username() As String
        Get
                Return Me._username
        End Get
    End Property

    Public ReadOnly Property UserType() As userTypeEnum
        Get
            Select Case _userType
                Case userTypeEnum.professor
                    Return userTypeEnum.professor

            End Select
            'Case 1
            Return userTypeEnum.student
        End Get

    End Property

    Protected _details As DataRow 'store here additional info. Table module pattern.
    Protected _detailsTable As DataTable
    Protected _exist As Boolean = False

    '''''''''''''''''''''''public Readonly Properties'''''''''''''''''''''
    Public ReadOnly Property id() As String
        Get
            Return Me._id
        End Get

    End Property
   
    ReadOnly Property Password() As String
        Get

            Return Me._password
        End Get

    End Property
    Public ReadOnly Property IpAddress() As String
        Get

            Return Me._ipaddress
        End Get

    End Property
    Public ReadOnly Property IsLoggedIn() As Boolean
        Get
            Return Me._isLoggedIn
        End Get

    End Property


    Public ReadOnly Property getLastIpAddress() As String
        Get
            Return Me._lastIpAddress
        End Get
    End Property

    Public ReadOnly Property details() As DataRow
        Get
            Return Me._details
        End Get
    End Property
    Public ReadOnly Property exist() As Boolean
        Get
            Return Me._exist
        End Get

    End Property

    Public ReadOnly Property detailsTable() As DataTable
        Get
            Return Me._detailsTable
        End Get

    End Property
    ''''''''''''''''''methods/procedures/functions''''''''''''''''''''''
    Public Sub New(ByVal username As String, ByVal password As String)
        Me._username = username
        Me._password = password

        'professor'''''''''''''''
        If database.exist("SELECT COUNT(id), users.* FROM users WHERE username = ? and password = left(sha1(?),20)", New ArrayList() From {username, password}) Then
            Me._username = database.result().Rows(0)("username")
            Me._lastIpAddress = database.result().Rows(0)("ipaddress")
            Me._id = database.result().Rows(0)("id")


            Me._userType = userTypeEnum.professor
            Me._isProfessor = True
            Me._isStudent = False

            Me._details = database.result().Rows(0)
            Me._detailsTable = database.result()
            Me._exist = True
            If (Me._details("loggedIn").ToString() = "loggedin") Then
                Me._isLoggedIn = True
            End If

            'student'''''''''''''''''
        ElseIf database.exist("SELECT COUNT(student_id), students.* FROM students WHERE student_id = ? and password = left(sha1(?),20)", New ArrayList() From {username, password}) Then
            Me._id = database.result().Rows(0)("student_id").ToString()

            Me._lastIpAddress = database.result().Rows(0)("ipaddress").ToString()
            If (database.result().Rows(0)("loggedin").ToString() = "loggedin") Then
                Me._isLoggedIn = True
            End If
            Me._detailsTable = database.result()
            Me._details = database.result().Rows(0)

            Me._userType = userTypeEnum.student
            Me._isProfessor = False
            Me._isStudent = True
            Me._exist = True

        Else
            Me._exist = False
        End If
    End Sub


    Public Function getAsProfessor() As professor
        Return New professor(_username, _password)
    End Function
    Public Function getAsStudent() As student
        Return New student(_username, _password)

    End Function

  
End Class
