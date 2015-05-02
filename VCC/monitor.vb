Public Class monitor
    Private list_monitors As List(Of screenmonitor)
    Private leftmargin As Integer = 20
    Private topmargin As Integer = 20

    Private Sub monitor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For Each mymonitor As screenmonitor In Me.Controls
            mymonitor.stopoperation()

        Next
    End Sub
    Private Sub monitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strategy_network.checkNetwork()
        load_monitors()
        Timer1.Start()

    End Sub
    Private Sub load_monitors()
        Dim computers As DataTable = LOGIN.database.query("SELECT * FROM computers")

        Dim table As TableLayoutPanel = New TableLayoutPanel()
        Dim leftmargin As Integer = 10
        table.ColumnCount = 5
        table.RowCount = 1
        For i As Integer = 0 To computers.Rows.Count - 1
            Dim monitor As screenmonitor = New screenmonitor(computers.Rows(i)("ipaddress").ToString(), computers.Rows(i)("imageport").ToString(), computers.Rows(i)("computername").ToString(), computers.Rows(i)("word").ToString())
            monitor.Left = leftmargin
            monitor.Top = topmargin
            monitor.Width = 300
            monitor.Height = 200 + 23
            monitor.BackgroundImageLayout = ImageLayout.Stretch
            monitor.BackColor = Color.Black
            ' monitor.BackgroundImage = My.Resources.advanceSettings

            'topmargin = topmargin + 50 + 10 + 323
            monitor.Visible = True
            monitor.invokethread()
            table.RowCount = i Mod 5

            Me.Controls.Add(monitor)
            leftmargin = leftmargin + 300 + 5
        Next
    End Sub

    Private Sub monitor_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class