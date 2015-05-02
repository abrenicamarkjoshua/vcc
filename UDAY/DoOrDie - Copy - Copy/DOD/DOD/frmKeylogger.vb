Public Class frmKeylogger
    Public sock As Integer

    Private Sub frmKeylogger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmMain.S.Send(sock, "getlog")
    End Sub
End Class