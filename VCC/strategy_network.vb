Imports System.Net.Sockets
Imports System.Text

Public Class strategy_network
    ''' <summary>
    ''' this function is invoked only for professors
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub checkNetwork()

        If IsNothing(LOGIN.professor) = False Then

            Dim database As database = New database()
            Dim computers As DataTable = database.query("SELECT * FROM computers")
            For i As Integer = 0 To computers.Rows.Count - 1
                'if detected record is this computer... (this computer is server by the way. prior to  IsNothing(LOGIN.professor) = False)
                If computers.Rows(i)("ipaddress").ToString() = strategy_localComputer.getIpAddress() Then
                    database.query2("DELETE from computers WHERE ipaddress = ?", New ArrayList() From {computers.Rows(i)("ipaddress").ToString()})
                End If
                'Try

                '    Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                '    sock.Connect(computers.Rows(i)("ipaddress").ToString(), 80)

                '    Dim buffer() As Byte = Encoding.ASCII.GetBytes("testing12345")
                '    sock.Send(buffer)

                'Catch ex As System.Net.Sockets.SocketException
                '    database.query2("delete from computers WHERE ipaddress = ?", New ArrayList() From {computers.Rows(i)("ipaddress").ToString()})
                'End Try
                Dim connectionsuccessful As Boolean = False
                Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim buffer() As Byte = Encoding.ASCII.GetBytes("asdf")
                Try
                    sock.Connect(computers.Rows(i)("ipaddress").ToString(), 82)
                    connectionsuccessful = True
                    sock.Close()
                Catch ex As System.Net.Sockets.SocketException

                End Try
                If connectionsuccessful Then

                Else
                    database.query2("delete from computers WHERE ipaddress = ?", New ArrayList() From {computers.Rows(i)("ipaddress").ToString()})

                End If
            Next

        End If
    End Sub
    Public Shared Function checkport(ByVal hostname As String, ByVal port As Integer
                             ) As Boolean
        Dim client As New TcpClient(AddressFamily.InterNetwork)


        client.BeginConnect(hostname, port,
                            Sub(x)
                                Dim tcp As TcpClient = CType(x.AsyncState, TcpClient)
                                Try
                                    tcp.EndConnect(x)

                                Catch ex As Exception
                                    'error

                                End Try
                                tcp.Close()
                            End Sub, client
                            )


        Return (False)
    End Function

End Class
