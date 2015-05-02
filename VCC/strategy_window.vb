Public Class strategy_window
    Public Shared Sub closeWindowNoPrompt(ByVal form As Form)
        form.Close()
    End Sub
    Public Shared Sub closeWindow(ByVal form As Form)
        Try
            Dim prompt As prompt = New prompt()
            If prompt.closeWindow() = VCC.prompt.resultEnum.yes Then
                form.Close()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub closeWindowReturnLogin(ByRef form As Form)
        Try
          
                form.Close()
                VCC.LOGIN.Show()

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub closeWindowReturnDashboard(ByRef form As Form)
        Try
            Dim prompt As prompt = New prompt()
            If prompt.closeWindowReturnDashboard() = VCC.prompt.resultEnum.yes Then
                form.Close()
                VCC.DASHBOARD.Show()


            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
