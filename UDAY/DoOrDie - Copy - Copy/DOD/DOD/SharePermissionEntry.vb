Public Class SharePermissionEntry

    Private _DomainName As String = String.Empty
    ''' <summary>
    ''' The domain name that the user/group in the UserOrGroupName property belongs to
    ''' </summary>
    Public Property DomainName() As String
        Get
            Return _DomainName
        End Get
        Set(ByVal value As String)
            _DomainName = value
        End Set
    End Property

    Private _UserOrGroupName As String = String.Empty
    ''' <summary>
    ''' The name of the user or group that should be granted/denied permission
    ''' </summary>
    Public Property UserOrGroupName() As String
        Get
            Return _UserOrGroupName
        End Get
        Set(ByVal value As String)
            _UserOrGroupName = value
        End Set
    End Property

    Private _Permission As SharedFolder.SharePermissions
    ''' <summary>
    ''' The share permission to grant or deny for the account in UserOrGroupName
    ''' </summary>
    Public Property Permission() As SharedFolder.SharePermissions
        Get
            Return _Permission
        End Get
        Set(ByVal value As SharedFolder.SharePermissions)
            _Permission = value
        End Set
    End Property

    Private _AllowOrDeny As Boolean = True
    ''' <summary>
    ''' Set to True to allow the rights specified in the Permission property and False to deny the rights specified in the Permission property. 
    ''' Default is True.
    ''' </summary>
    Public Property AllowOrDeny() As Boolean
        Get
            Return _AllowOrDeny
        End Get
        Set(ByVal value As Boolean)
            _AllowOrDeny = value
        End Set
    End Property

    ''' <summary>
    ''' Creates a new instance of the SharePermissionEntry class
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Creates a new instance of the SharePermissionEntry class and populates each of the properties within the instance
    ''' </summary>
    ''' <param name="Domain">The domain that the user in the AccountName argument belongs to. 
    ''' Pass String.Empty or Nothing here if you are specifying a 'well known' identity such as the Everyone group in the AccountName argument</param>
    ''' <param name="AccountName">The username or group name that this permission entry relates to</param>
    ''' <param name="DesiredPermission">The share permission to grant/deny</param>
    ''' <param name="AlloworDenyPermission">True to allow the permission, False to deny the permission</param>
    Public Sub New(ByVal Domain As String, ByVal AccountName As String, ByVal DesiredPermission As SharedFolder.SharePermissions, ByVal AlloworDenyPermission As Boolean)
        DomainName = Domain
        UserOrGroupName = AccountName
        Permission = desiredpermission
        AllowOrDeny = AlloworDenyPermission
    End Sub

End Class
