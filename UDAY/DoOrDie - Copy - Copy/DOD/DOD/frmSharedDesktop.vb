Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Net.Sockets
Imports System.Threading

Public Class frmSharedDesktop
    Dim active As Boolean = True
    Dim client As New TcpClient
    Dim nstream As NetworkStream
    Public getImage As New Thread(AddressOf receiveImage)

    Private Sub frmSharedDesktop_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        getImage.Abort()
    End Sub

    Private Sub frmSharedDesktop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getImage.Start()
    End Sub

    Sub receiveImage()
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

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class