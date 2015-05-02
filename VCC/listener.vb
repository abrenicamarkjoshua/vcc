Imports System.Net
Imports System.Net.Sockets
Imports System.Diagnostics
Imports System.Text
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.IO
Imports System.Threading


Public Class listener
    Public list_of_computers As DataTable = New DataTable()
    Public login_status As String = "not logged in"
    Dim message As String
    Private messageArray As Array
    Private ctThread As Threading.Thread = New Threading.Thread(AddressOf listen)

    Private ctThread2 As Threading.Thread = New Threading.Thread(AddressOf WaitForRequest)

    Private sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Private client As Socket
    Private my_process As Process = New Process
    Public message1 As String = ""

    Public Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        Try
            If Directory.Exists(path) Then
                'Delete all files from the Directory
                For Each filepath As String In Directory.GetFiles(path)
                    File.Delete(filepath)
                Next
                'Delete all child Directories
                For Each dir As String In Directory.GetDirectories(path)
                    DeleteDirectory(dir)
                Next

                'Delete a Directory
                Directory.Delete(path)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Delete Directory")
        End Try
    End Sub

    Private Sub listen()
        While True
            Try
                sock = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                sock.Bind(New IPEndPoint(IPAddress.Any, 82))
                sock.Listen(3)
                Dim received As Integer = 0
                client = sock.Accept()
                Dim buffers(5120) As Byte
                received = client.Receive(buffers)
                If (received > 0) Then
                    message = Encoding.ASCII.GetString(buffers, 0, received)
                    If message = "close server" Then
                        Exit While
                    End If

                    Select Case message
                        Case "time"
                            Me.message1 = "time"
                        Case "open notepad"
                            Me.message1 = "open notepad"
                        Case "open visual studio"
                            Me.message1 = "open visual studio"
                        Case "lock_desktop"

                            Me.message1 = "lock_desktop"
                        Case "shared desktop"
                            Me.message1 = "shared desktop"
                        Case "close lecture"
                            Me.message1 = "close lecture"
                        Case "lock pc"

                        Case "wake up"

                        Case Else
                            'if it's not a usual message and it's a command for opening and closing document/application...
                            messageArray = message.Split("@") 'naisip ko dati 'space' instead of '@' kaso may mga folders na may spaces eh
                            ' example if the message is: open@network\joshua-pc\documents\lecture1.docx@WINWORD
                            Select Case messageArray(0)
                                Case "lock_desktop"
                                    Me.message1 = "lock_desktop"

                                    Dim sectionname As String = LOGIN.setsection
                                    'Create the section name folder, and send my contents to server's contents
                                    Dim studentname As String = LOGIN.user_info.Rows(0)("student_name").ToString()

                                    CopyDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "\\" & My.Settings.server & "\Student Activity\" & sectionname & "\" & studentname)

                                    DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Student Activity"))
                                    'send attendance
                                    LOGIN.database.query2("UPDATE attendance SET has_activity = 'yes' WHERE student_id = ? AND date = CURDATE()", New ArrayList() From {LOGIN.user_info.Rows(0)("student_id").ToString()})
                                    '    Case "logout"
                                    'Dim myname As String = messageArray(1)
                                    'Dim mystudentnumber As String = messageArray(2)
                                    'LOGIN.database.query2("UPDATE students SET login_status = 'offline' WHERE student_name = ? AND student_id = ?", New ArrayList() From {myname, mystudentnumber})
                                Case "logout"
                                    Select Case messageArray(1)
                                        Case "professor"

                                            Dim id As String = messageArray(2)
                                            LOGIN.database.query2("UPDATE users SET loggedin = ''  WHERE id = ?", New ArrayList() From {id})
                                            'if i'm logged in as professor, log me out
                                               Me.message1 = "logout professor"
                                           
                                        Case "student"

                                            Dim id As String = messageArray(2)
                                            LOGIN.database.query2("UPDATE students SET loggedin = ''  WHERE student_id = ?", New ArrayList() From {id})
                                            'if i'm logged in as student, log me out
                                                Me.message1 = "logout student"
                                          
                                    End Select
                                Case "authenticate"
                                    Dim student_name As String = messageArray(1)
                                    Dim student_number As String = messageArray(2)
                                    Dim ipaddress As String = messageArray(3)
                                    If exist("SELECT COUNT(`student_id`) FROM students WHERE student_name = ? AND student_id = ?", New ArrayList() From {student_name, student_number}) Then
                                        sender_class.send_message("grant access", ipaddress)
                                        Dim myname As String = messageArray(1)
                                        Dim mystudentnumber As String = messageArray(2)
                                        LOGIN.database.query2("UPDATE students SET login_status = 'online' WHERE student_name = ? AND student_id = ?", New ArrayList() From {myname, mystudentnumber})

                                    Else
                                        sender_class.send_message("no access", ipaddress)

                                    End If
                                Case "testing"
                                    Me.message1 = "testing"
                                Case "open"
                                    'messageArray(0) = open, messageArray(1) = network\joshua-pc\documents\lecture1.docx, messageArray(2) = WINWORD
                                    my_process.StartInfo.Arguments = """" + messageArray(1) + """"
                                    my_process.StartInfo.FileName = messageArray(2)
                                    my_process.Start()

                                Case "close"
                                    'close f:/activity1.docx winword 
                                    For Each proc As Process In Process.GetProcesses()
                                        Dim process_name As String = messageArray(2)
                                        If proc.ProcessName = process_name Then
                                            proc.CloseMainWindow()
                                            Exit For
                                        End If
                                    Next
                                Case "command"
                                    'commands for locking, waking, standye,...
                                    Select Case messageArray(1)
                                        Case "standby"
                                            Select Case messageArray(2)
                                                Case "unit"
                                                    'shutdown
                                                    Dim WM_SYSCOMMAND As Integer = &H112
                                                    Dim SC_MONITORPOWER As Integer = &HF170

                                                    sender_class.SendMessage(Me.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2)
                                            End Select
                                    End Select
                                Case "computer_name"
                                    ' if already exist don't continue.
                                    For i As Integer = 0 To list_of_computers.Rows.Count() - 1
                                        If list_of_computers.Rows(i)(0).ToString() = messageArray(1) Then
                                            Exit Select
                                        End If
                                    Next

                                    Dim newrow As DataRow = list_of_computers.NewRow()
                                    newrow("computer_name") = messageArray(1)
                                    newrow("ip_address") = messageArray(2)
                                    list_of_computers.Rows.Add(newrow)
                                    ' if logged in, then refresh.




                            End Select
                    End Select

                    'MessageBox.Show(message)
                End If
                sock.Close()
                client.Close()
                'client = Nothing
            Catch ex As System.Net.Sockets.SocketException
                ' Handle failed receive attempt
                'MessageBox.Show("Server now closed ")
                'MessageBox.Show(ex.Message)
                sock.Close()
                client.Close()
                'Exit While

            End Try
        End While
    End Sub

    Dim mReader As BinaryReader
    Dim mWriter As BinaryWriter = Nothing
    Const ListenPort As Int16 = 9876
    Const RequestPort As Int16 = 6789
    Shared NoofClients As Int16 = 0

    Private Sub listener_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        sender_class.send_message("close server", "127.0.0.1")
    End Sub 'Stores the Number of Image Sender Connected

    Public Sub server_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'listen()
        ctThread.SetApartmentState(ApartmentState.STA)
        ctThread.Start()
        'ctThread2.Start()
        list_of_computers.Columns.Add("computer_name")
        list_of_computers.Columns.Add("ip_address")
    End Sub
    Dim start As Boolean = True
    Const ConnectionPort As Int16 = 9876 'Connection Port Number

    Dim ServerIp As String
    Dim NetStream As NetworkStream
    Dim myReader As BinaryReader
    Dim myWriter As BinaryWriter
    Dim Look4Request As Thread = Nothing
   
    Sub Send_Screen_Shot()
        Try
            Dim FileName As String = Environment.CurrentDirectory & "\Mohiudeen_Screen.jpg"
            ScreenCapture.CurrentScreen() 'Capture the Current Screen
            'If File.Exists(FileName) Then
            '    File.Delete(FileName)
            'End If
            ScreenCapture.oBitMap.Save(FileName) 'Saves it to a File
            ScreenCapture.oBitMap = Nothing
            'Then,Sends the File to the Image Receiver
            Using FStreams As New FileStream(FileName, FileMode.Open)
                Dim buffer(1024 - 1) As Byte
                Do While True
                    Dim bytesRead As Integer = FStreams.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then Exit Do
                    Me.NetStream.Write(buffer, 0, bytesRead)
                    NetStream.Flush()
                Loop
                FStreams.Close()
                NetStream.Close()
            End Using
            'Finally Closes
        Catch ex As Exception
        End Try
    End Sub
    Sub WaitForRequest()
        'Dim myClient As New TcpClient
        'ServerIp = Dns.GetHostByName(computer_name2).AddressList(0).ToString()
        'myClient.Connect(ServerIp, 6789)
        'myClient.Close()
        'Gets the Receiver Address
        ' Dim ServerAddress As String = Dns.GetHostByName("main-pc").AddressList(0).ToString()
        Dim myListener As New TcpListener(RequestPort)
        'Dim myListener As New TcpListener(ServerAddress, RequestPort)
        myListener.Start()
        'If Connected Gets the Client Stream
        Try
            While (start)
                Try

                    Dim myClient As TcpClient = myListener.AcceptTcpClient
                    NetStream = myClient.GetStream
                    Try
                        Send_Screen_Shot() 'Sends the Screen Shot of the Desktop

                    Catch ex As Exception

                    End Try
                    'myClient.Close()
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    'Exit While
                End Try

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Try
                myReader.Close()
                NetStream.Close()
            Catch ex As Exception

            End Try

        End Try

    End Sub
End Class
