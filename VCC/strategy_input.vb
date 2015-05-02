Public Class strategy_input
    Public Shared Function sanitize(ByVal inputString) As String
        'remove double spaces and leading/ending spaces
        Dim sanitizedString = inputString.ToString().Replace("  ", " ").Trim
        'additional sanitization process
        'goes here.

        Return sanitizedString
    End Function
    Public Shared Sub clear(ByRef controls As List(Of Control))
        For i As Integer = 0 To controls.Count - 1
            controls.Item(i).Text = ""
        Next
    End Sub

End Class
