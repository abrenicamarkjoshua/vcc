Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Net.Sockets
Imports System.Threading
Imports System.Net

Public Class screenmonitor
    Inherits Panel
    Private ipaddress As String
    Private connected As Boolean
    Public port As String
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
    Public mylabel As Label = New Label
    Public WithEvents mypicturebox As PictureBox = New PictureBox

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
    End Sub

    Public Sub invokethread()
        mylabel.Text = wordcall
        mylabel.Tag = wordcall & "|" & myname & "|" & ipaddress & "|" & port
        mylabel.Left = 0
        mylabel.Top = 0
        mylabel.ForeColor = Color.White
        mylabel.Font = New Font("Microsoft Sans Serif", 10)
        mylabel.Visible = True
        mylabel.Name = "lbl_ipaddress"
        mylabel.BackColor = Color.FromArgb(100, 140, 0, 230)
        mypicturebox.Left = 0
        mypicturebox.Tag = wordcall & "|" & myname & "|" & ipaddress & "|" & port
        mypicturebox.Width = Me.Width
        mypicturebox.Height = Me.Height
        mypicturebox.BackgroundImageLayout = ImageLayout.Stretch
        mypicturebox.Top = mylabel.Height

        Me.Controls.Add(mylabel)
        Me.Controls.Add(mypicturebox)

        getImage.Start()
    End Sub

    Public Sub stopoperation()
        enablereceiveimage = False

        Try
            'getImage.Abort()
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
