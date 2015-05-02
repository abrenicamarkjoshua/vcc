Imports System.Data.Odbc
Public Class database

    Public con As New OdbcConnection
    Public da As New OdbcDataAdapter
    Public dt As New DataTable
    Public db_error As String = ""
    Public Sub New()
        Try
returnhere: con.ConnectionString = "Driver={MySQL ODBC 5.1 Driver};Server=" + My.Settings.server + ";Database=voicecommanddb;User=username;Password=nunaoppa;Option=3;"
            'con.ConnectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath.ToString() + "\worddatabase.accdb;Uid=Admin;Pwd=nunaoppa;"
            con.Open()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Unable to connect to server. Please set correct IP address of the server and make sure that the server is running and configured properly")
            'ERROR HANDLING
            emergency_setserver.ShowDialog()

            If emergency_setserver.emergency_exit_allow = True Then

                Exit Sub

            End If

            GoTo returnhere
            Exit Sub
        End Try

    End Sub
   
    Public Function query(ByVal var_query As String) As Object
        clearmemory()
        Try

            con.Open()
            dt = New DataTable
            da = New OdbcDataAdapter(var_query, con)
            da.Fill(dt)
            con.Close()
            Return dt
            'Return var_query

        Catch ex As Exception
            con.Close()
            Return "Unable to connect to server. Please set correct IP address of the server and make sure that the server is running and configured properly"
        End Try

    End Function
   
    Public Sub query2(ByVal var_query As String, ByVal array_param As ArrayList)
        clearmemory()
        Try
            'con.ConnectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Application.StartupPath.ToString() + "/worddatabase.accdb;Uid=Admin;Pwd=nunaoppa;"
            con.ConnectionString = "Driver={MySQL ODBC 5.1 Driver};Server=" + My.Settings.server + ";Database=voicecommanddb;User=username;Password=nunaoppa;Option=3;"

            con.Open()
            Dim my_command = New OdbcCommand(var_query, con)
            my_command.CommandText = var_query

            For Each parameter As String In array_param
                If parameter = "datenow" Then
                    parameter = DateTime.Now
                End If
                my_command.Parameters.AddWithValue("", parameter)
            Next

            dt = New DataTable()
            da = New OdbcDataAdapter(my_command)

            da.Fill(dt)
            'clearmemory()
            con.Close()
            Me.db_error = ""
        Catch ex As Exception

            MsgBox(ex.Message)

            'clearmemory()
            con.Close()
            Me.db_error = ex.Message
            emergency_setserver.ShowDialog()
            'uncomment this to debug and show error message
            'MessageBox.Show(ex.Message)

            Return

            'insert log function here
        End Try


    End Sub

    Public Function exist(ByVal count_query As String, ByVal arraylist As ArrayList) As Boolean
        query2(count_query, arraylist)
        Return IIf(CInt(dt.Rows(0)(0)) > 0, True, False)
    End Function

    Public Sub clearmemory()

        da.Dispose()
        dt.Dispose()
        con.Close()
    End Sub
    Public Function result() As DataTable
        Return Me.dt
    End Function

    Public Function return_first() As String
        Return Me.dt.Rows(0)(0).ToString()
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
