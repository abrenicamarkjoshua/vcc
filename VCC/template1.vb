

Public Class template1
    Public enable_fadein As Boolean = True
    Public enable_fadeout As Boolean = True
    'Public enable_prompt As Boolean = True
    'Public show_dashboard_after As Boolean = True

    Protected Overridable Sub template1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If enable_prompt = True Then
        '    If (MessageBox.Show("Are you sure you want to close?. Please click 'yes' to confirm", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
        '        e.Cancel = True
        '        Exit Sub
        '    End If
        'End If

        'fadeout
        'If enable_fadein = True Then
        '    'Dim position As Integer = Me.Top + 20
        '    For i As Decimal = 1 To 0 Step -0.05
        '        Me.Opacity = i
        '        Threading.Thread.Sleep(1)
        '        'position = position - 1
        '        'Me.Top = position
        '        Application.DoEvents()
        '    Next

        'End If
        'For Each frm As Form In Application.OpenForms
        '    If frm.Name = "DASHBOARD" Then
        '        frm.Show()
        '    End If

        'Next
        '   If show_dashboard_after = True Then DASHBOARD.Show()

    End Sub

    Private Sub template1_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles Me.HelpRequested

    End Sub
    Private Sub template1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controllers_and_functions.add_enter_events(Me)
        'fadein
        If enable_fadein Then
            'Dim position As Integer = Me.Top + 20
            For i As Decimal = 0 To 1 Step 0.05
                Me.Opacity = i
                Threading.Thread.Sleep(1)
                'position = position - 1
                'Me.Top = position
                Application.DoEvents()
            Next
        End If

    End Sub

    Protected Sub btn_main_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class