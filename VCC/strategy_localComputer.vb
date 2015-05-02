Imports System.Net.Dns

Public Class strategy_localComputer
    Public Shared Function getIpAddress() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim strIPAddress As String = GetHostByName(strHostName).AddressList(0).ToString()
        Return strIPAddress
    End Function
    Public Shared Function getComputerName() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Return strHostName
    End Function
    Public Shared Function generateImagePort() As String
        Dim database As database = New database()
        Dim generated_port As String = CInt(Math.Ceiling(Rnd() * 1023)) + 1
        If generated_port = "8099" Or generated_port = "8085" Or generated_port = "82" Or generated_port = "0" Then
            generated_port = CInt(Math.Ceiling(Rnd() * 1023)) + 1
        End If
        database.query("UPDATE computers SET imageport = '" & generated_port & "' WHERE ipaddress = '" & getIpAddress() & "'")

        Do Until database.exist("SELECT COUNT(id) FROM computers WHERE imageport = ? AND ipaddress != '" & getIpAddress() & "'", New ArrayList() From {generated_port}) = False
            generated_port = CInt(Math.Ceiling(Rnd() * 1023)) + 1
            database.query("UPDATE computers SET imageport = '" & generated_port & "' WHERE ipaddress = '" & getIpAddress() & "'")

        Loop


        Return generated_port
    End Function
End Class
