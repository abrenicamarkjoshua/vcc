Public Class tutorial_mode
    Protected Overrides Sub template1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
       
        LOGIN.database.query2("UPDATE users SET enable_tutorial = 'no' WHERE ID = ?", New ArrayList() From {LOGIN.user_info.Rows(0)("ID").ToString()})
        DASHBOARD.Show()
    End Sub
    Dim process As Process = New Process()
   
    Private Sub tutorial_mode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Visible = False
        btn_closeTutorial.Visible = False
        'Training the speech recognition

        process.StartInfo.FileName = "C:\Windows\sysnative\Speech\speechUX\SpeechUXWiz.exe"
        process.StartInfo.Arguments = "UserTraining"
        process.Start()
        Dim message As String = "First timers requires training the speech recognition to better recognize the user's voice commands"
        LOGIN.message = message


        Dim exited As Boolean = False

        While exited = False
            If process.HasExited = True Then

                'Register new sections
                MY_ACCOUNT.ShowDialog()
                MY_ACCOUNT.Dispose()


                'File settings

                LOGIN.message = "When you say 'SERVER OPEN LECTURE1' the system will recognize and open lecture 1 because it is registered here in the file settings. You add project files, lecture files, and other files you wish to open using the 'server open' command"
                'fileSettings.show_dashboard_after = False
                fileSettings.ShowDialog()
                fileSettings.Dispose()
                'Word settings
                LOGIN.message = "WORD SETTINGS ALLOWS YOU TO TYPE PROGRAMMING LANGUAGES BASED ON THESE SETTINGS. You start typing mode by saying 'server start typing' and stop it by saying 'server stop typing'"
                'WordSettings.show_dashboard_after = False
                WordSettings.ShowDialog()
                WordSettings.Dispose()
                'Network setup
                LOGIN.message = "Network setup allows you to configure what word to call registered clients. Allows you to see who are registered in the system."
                'network_setup.show_dashboard_after = False
                network_setup.ShowDialog()
                network_setup.Dispose()
                LOGIN.message = "Congratulations. Setup is finished and you can now use Voice Command Controller for IT laboratory"

                exited = True
            End If

        End While
        Label1.Text = "Congratulations. Setup is finished and you can now use Voice Command Controller for IT laboratory"
        Label1.Visible = True
        btn_closeTutorial.Visible = True

        'btn_main_close.Visible = True
        'return here. the close button for tutorial

    End Sub
   
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_closeTutorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_closeTutorial.Click
        strategy_window.closeWindowReturnDashboard(Me)
        'update to not set enable_tutorial

    End Sub
End Class