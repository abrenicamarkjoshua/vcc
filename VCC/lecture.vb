Imports System.IO
Imports System.Net.Sockets
Imports System.Threading
Imports System.Net
Imports System.Text
Imports System.Runtime.Serialization.Formatters.Binary
Public Class lecture
    Private Sub lecture_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        getImage.Abort()
    End Sub
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
    Private Sub receiveImage()
        Dim bf As New BinaryFormatter
        While active
            Try
                Dim server As New TcpListener(8085)
                server.Start()
                client = server.AcceptTcpClient
                nstream = client.GetStream
                PictureBox1.Image = bf.Deserialize(nstream)
                server.Stop()
            Catch ex As Exception
                Continue While
            End Try

        End While
       
    End Sub
    Private Sub Listen()
        getImage.Start()
    End Sub

    Private Sub lecture_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
       
    End Sub
    Private Sub lecture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Thread.Sleep(5000)
        'listening.Start()
        getImage.Start()
        Timer1.Start()
    End Sub


    Private Sub lecture_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Timer2.Start()

    End Sub
  
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Try
        '    Dim bf As New BinaryFormatter

        '    Dim server As New TcpListener(8085)
        '    server.Start()
        '    client = server.AcceptTcpClient
        '    nstream = client.GetStream
        '    PictureBox1.Image = bf.Deserialize(nstream)
        '    server.Stop()
        'Catch ex As Exception

        'End Try
        'Try

        '    Dim FilName As String = Environment.CurrentDirectory & "\" & "Mohy_Screen_shot.bmp"
        '    Dim fStram As New FileStream(FilName, FileMode.Create)
        '    'Creates the File Where we are going to receive the File From the Sender


        '    'Gets the IPAddress Where i have to Connect

        '    Dim ClientToSee As TcpClient
        '    Try
        '        ClientToSee = New TcpClient()
        '        ClientToSee.Connect(My.Settings.server, RequestPort)
        '        'Connects to the Image Sender

        '    Catch ex As Exception
        '        MsgBox("Sorry !!!,Please ReStart the Sender")

        '        fStram.Close()
        '        Exit Sub
        '    End Try


        '    Dim NStream As NetworkStream = New NetworkStream(ClientToSee.Client)
        '    'Gets the Stream to Communicate

        '    mReader = New BinaryReader(NStream)
        '    Dim buffer(1024 - 1) As Byte
        '    Do While True
        '        Dim bytesRead As Integer = mReader.Read(buffer, 0, buffer.Length)
        '        If bytesRead = 0 Then Exit Do
        '        fStram.Write(buffer, 0, bytesRead)
        '        fStram.Flush()
        '    Loop

        '    'Gets the Screen Shot and Closes the Stream
        '    fStram.Close()
        '    fStram.Dispose()
        '    fStram = Nothing
        '    ClientToSee.Close()

        '    'Finally Showing the Screen Shot in the Picture Box
        '    Dim fs As New System.IO.FileStream(FilName, IO.FileMode.Open, IO.FileAccess.Read)
        '    Dim imgCurrentPhoto As Image = Image.FromStream(fs)
        '    PictureBox1.Image = imgCurrentPhoto
        '    fs.Dispose()

        'Catch ex As Exception
        '    'MsgBox(ex.Message)
        'End Try
    End Sub
End Class