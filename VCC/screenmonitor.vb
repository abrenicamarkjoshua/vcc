Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Net.Sockets
Imports System.Threading
Imports System.Net

Public Class screenmonitor
    Inherits Panel
    Private ipaddress As String
    Private connected As Boolean
    Private port As String
    Private myname As String
    Private wordcall As String
    Dim mReader As BinaryReader
    Dim mWriter As BinaryWriter = Nothing
    Const ListenPort As Int16 = 9876
    Const RequestPort As Int16 = 6789
    Shared NoofClients As Int16 = 0 'Stores the Number of Image Sender Connected
    Dim client As New TcpClient
    Dim nstream As NetworkStream
    Dim listening As New Thread(AddressOf Listen)
    Public getImage As New Thread(AddressOf receiveImage)
    Public active As Boolean = True
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public enablereceiveimage As Boolean = True
    Private mylabel As Label = New Label
    Private WithEvents mypicturebox As PictureBox = New PictureBox

    Private Sub me_doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mypicturebox.DoubleClick
        If mypicturebox.Width = 1360 And mypicturebox.Height = 768 Then
            mypicturebox.Width = 300
            mypicturebox.Height = 200
            mypicturebox.Top = mylabel.Height
            mylabel.Top = mypicturebox.Height - mylabel.Height
            mylabel.Top = 0
            mylabel.Left = 0
            mylabel.Width = Me.Width
            Me.Width = 300
            Me.Height = 200 + mylabel.Height
        Else
            mypicturebox.Width = 1360
            mypicturebox.Height = 768
            mypicturebox.Top = mylabel.Height
            Me.Width = 1360
            Me.Height = 768 + mylabel.Height

            mylabel.Top = 0
            mylabel.Left = 0
            mylabel.Width = Me.Width
        End If

    End Sub
    Private server As TcpListener = New TcpListener(8099)
    Private Sub receiveImage()
        Dim bf As New BinaryFormatter
        While enablereceiveimage
            'If My.Computer.Network.Ping(Me.ipaddress) Then
            '    'continue
            'Else
            '    mypicturebox.BackgroundImage = My.Resources.disconnected
            'End If
            Try
                
                'server = New TcpListener(Dns.GetHostAddresses(Me.myname)(0), 8099)

                server = New TcpListener(port)
                server.Start()

                'Dim server2 As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                'Dim endpoint As New IPEndPoint(Net.IPAddress.Parse(Me.ipaddress), 8099)
                'server2.Bind(endpoint)

                client = server.AcceptTcpClient

                'Me.BackgroundImage = Nothing

                nstream = client.GetStream
                mypicturebox.BackgroundImage = bf.Deserialize(nstream)

                server.Stop()
            Catch ex As Exception
                'MessageBox.Show(ex.Message)

                server.Stop()
                'Continue While
            End Try
        End While
        'While enablereceiveimage


        '    Dim listimage As List(Of Bitmap) = New List(Of Bitmap)
        '    listimage.Add(My.Resources.fileSettings)
        '    listimage.Add(My.Resources.advanceSettings)
        '    listimage.Add(My.Resources.wordSettings)
        '    listimage.Add(My.Resources.login)
        '    listimage.Add(My.Resources.dashboard2)

        '    For Each myimage As Bitmap In listimage
        '        Me.BackgroundImage = myimage

        '        Threading.Thread.Sleep(1000)
        '        Application.DoEvents()
        '    Next

        'End While
    End Sub
    Private Sub Listen()
        getImage.Start()

    End Sub

    Public Sub New(ByVal ipaddress As String, ByVal port As String, ByVal name As String, ByVal wordcall As String)
        Me.ipaddress = ipaddress
        Me.port = port
        Me.wordcall = wordcall
        Me.myname = name
        'call and strat thread to recieve incoming stream from ipaddress
        Me.BackgroundImageLayout = ImageLayout.Stretch
        'Me.Label1.Text = ipaddress
        'Me.Label1.Left = 0
        'Me.Label1.Top = 0
        'Me.Label1.ForeColor = Color.DarkGreen
        'Me.Label1.Visible = True
        Dim cm As ContextMenu = New ContextMenu()
        Dim menuitem1 = New MenuItem("shutdown")
        AddHandler menuitem1.Click, AddressOf Me.onclick_shutdown
        cm.MenuItems.Add(menuitem1)
        Dim menuitem2 = New MenuItem("share desktop to this computer")
        AddHandler menuitem2.Click, AddressOf Me.onclick_startlecture
        cm.MenuItems.Add(menuitem2)
        Dim menuitem3 = New MenuItem("stop desktop sharing")
        AddHandler menuitem3.Click, AddressOf Me.onclick_stoplecture
        cm.MenuItems.Add(menuitem3)
        Dim menuitem4 = New MenuItem("lock pc")
        AddHandler menuitem4.Click, AddressOf Me.onclick_lockpc
        cm.MenuItems.Add(menuitem4)








        Me.ContextMenu = cm


    End Sub
    Private Sub onclick_lockpc(ByVal sender As Object, ByVal e As System.EventArgs)
        sender_class.send_message("close lecture", Me.ipaddress)
    End Sub
    Private Sub onclick_stoplecture(ByVal sender As Object, ByVal e As System.EventArgs)
        sender_class.send_message("close lecture", Me.ipaddress)
    End Sub
    Private Sub onclick_startlecture(ByVal sender As Object, ByVal e As System.EventArgs)
        sender_class.send_message("shared desktop", Me.ipaddress)
    End Sub

    Private Sub onclick_shutdown(ByVal sender As Object, ByVal e As System.EventArgs)
        sender_class.send_message("shutdown", Me.ipaddress)
    End Sub

    Public Sub invokethread()
        getImage.Start()

        mylabel.Text = ipaddress
        mylabel.Left = 0
        mylabel.Top = 0
        mylabel.ForeColor = Color.White
        mylabel.Font = New Font("Microsoft Sans Serif", 10)
        mylabel.Visible = True
        mylabel.Name = "lbl_ipaddress"
        mylabel.BackColor = Color.FromArgb(100, 140, 0, 230)
        mypicturebox.Left = 0
        mypicturebox.Width = Me.Width
        mypicturebox.Height = Me.Height
        mypicturebox.BackgroundImageLayout = ImageLayout.Stretch
        mypicturebox.Top = mylabel.Height
        Me.Controls.Add(mylabel)
        Me.Controls.Add(mypicturebox)
    End Sub
    Public Sub stopoperation()
        enablereceiveimage = False
        Try
            getImage.Abort()

        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()


    End Sub

End Class
