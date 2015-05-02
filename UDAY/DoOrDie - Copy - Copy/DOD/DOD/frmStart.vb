Imports MySql.Data.MySqlClient

Public Class frmStart

    Private Sub frmStart_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub

    Private Sub frmStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        sql = "SELECT * FROM tbl_screensharing"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "ss")

        If ds.Tables("ss").Rows.Count > 0 Then
            Dim image As Byte() = DirectCast(ds.Tables("ss").Rows(0).Item("image"), Byte())

            Bytes2Image(image)
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub

    Sub Bytes2Image(ByVal ImageData As Byte())
        Dim ms As New IO.MemoryStream

        ms.Write(ImageData, 0, ImageData.Length)
        PictureBox1.Image = System.Drawing.Image.FromStream(ms)

        ms.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()

                Timer1.Start()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
            Else
                Animation.Stop()

                Timer1.Stop()

                Me.Close()
            End If
        End If
    End Sub

End Class