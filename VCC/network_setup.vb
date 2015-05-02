Imports System.Net.Dns


Public Class network_setup
    Public dt_computers_detected As DataTable = New DataTable()
  
    Private Sub user_network_setup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        list_computers()
        ' GetIPAddress()

        refresh_list()
        'Timer1.Start()
    End Sub
    Public Sub refresh2()
        'For i As Integer = 0 To login.listener.list_of_computers.Rows.Count - 1
        '    If list_computer_detected.Items.ContainsKey(login.listener.list_of_computers.Rows(i)("computer_name").ToString()) = False Then
        '        list_computer_detected.Items.Add(login.listener.list_of_computers.Rows(i)("computer_name").ToString())
        '        list_computer_detected.Items(i).SubItems.Add(login.listener.list_of_computers.Rows(i)("ip_address").ToString())

        '    End If


        'Next
        refresh_list()

    End Sub

    Public Sub refresh_list()
        listview_computers.Items.Clear()
        LOGIN.database.query("SELECT * FROM  computers")
        If LOGIN.database.result.Rows.Count = 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To LOGIN.database.result.Rows.Count - 1
            listview_computers.Items.Add(LOGIN.database.result.Rows(i)("word").ToString())
            listview_computers.Items(i).SubItems.Add(LOGIN.database.result.Rows(i)("computername").ToString())
            listview_computers.Items(i).SubItems.Add(LOGIN.database.result.Rows(i)("ipaddress").ToString())
            listview_computers.Items(i).SubItems.Add(LOGIN.database.result.Rows(i)("id").ToString())

        Next
    End Sub
    Private Sub GetIPAddress()

        'Dim strHostName As String = System.Net.Dns.GetHostName()

        'Dim strIPAddress As String = GetHostByName(strHostName).AddressList(0).ToString()



        'MessageBox.Show("Host Name: " & strHostName & "; IP Address: " & strIPAddress)

    End Sub

    Private Sub list_computers()
        listview_computers.Items.Clear()
        LOGIN.database.query("SELECT * FROM computers")
        For i As Integer = 0 To LOGIN.database.result.Rows.Count - 1
            listview_computers.Items.Add(LOGIN.database.result.Rows(i)("word").ToString())
            listview_computers.Items(i).SubItems.Add(LOGIN.database.result.Rows(i)("computername").ToString())
            listview_computers.Items(i).SubItems.Add(LOGIN.database.result.Rows(i)("ipaddress").ToString())
            listview_computers.Items(i).SubItems.Add(LOGIN.database.result.Rows(i)("id").ToString())
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If exist("SELECT COUNT(word) FROM computers WHERE word = ?", New ArrayList() From {txt_word.Text}) Then
            MessageBox.Show("That word is already registered")
            Exit Sub
        End If

        LOGIN.database.query2("INSERT INTO computers (`word`, `computername`, `ipaddress`) VALUES (?,?,?)", New ArrayList() From {txt_word.Text, lbl_computername.Text, lbl_ipaddress.Text})
        list_computers()

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub



    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If listview_computers.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select computer from the list you wish to remove")
            Exit Sub
        End If
        If (MessageBox.Show("Are you sure you want to remove this computer? '" + listview_computers.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        LOGIN.database.query("DELETE FROM computers WHERE id = '" + listview_computers.SelectedItems(0).SubItems(3).Text + "'")
        list_computers()
        lbl_computername.Text = ""
        lbl_ipaddress.Text = ""
        txt_word.Text = ""
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If listview_computers.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select computer from the list you wish to update")
            Exit Sub
        End If
        If (MessageBox.Show("Are you sure you want to update this computer? '" + listview_computers.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        LOGIN.database.query2("UPDATE computers SET word = ?, computername = ?, ipaddress = ? WHERE id = '" + listview_computers.SelectedItems(0).SubItems(3).Text + "'", New ArrayList() From {sanitize(txt_word.Text), sanitize(lbl_computername.Text), sanitize(lbl_ipaddress.Text)})
        list_computers()
    End Sub

    Private Sub list_computer_detected_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        refresh2()
    End Sub

    Private Sub listview_computers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_computers.Click
        txt_word.Text = listview_computers.SelectedItems(0).SubItems(0).Text
        lbl_computername.Text = listview_computers.SelectedItems(0).SubItems(1).Text
        lbl_ipaddress.Text = listview_computers.SelectedItems(0).SubItems(2).Text

    End Sub

    Private Sub listview_computers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_computers.SelectedIndexChanged

    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        listview_computers.Refresh()
        txt_word.Text = ""
        lbl_computername.Text = ""
        lbl_ipaddress.Text = ""
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        user_network_setup_Load(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        strategy_window.closeWindowReturnDashboard(Me)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim message As String = "Network setup lets you set a word to call the client computers to perform voice-command activities. You first click the registered clients before updating it's network word call"
        LOGIN.message = message
        ToolTip1.Show("STEP1. SELECT A CLIENT", Me.listview_computers, 3600000)
        ToolTip2.Show("STEP2. ENTER A NETWORK WORD TO CALL", Me.txt_word, 3600000)
        ToolTip3.Show("STEP2. CLICK UPDATE TO SET CLIENT'S NETWORK WORD TO CALL", Me.btn_update, 3600000)

    End Sub
End Class