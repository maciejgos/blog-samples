Public Class SupperDupperClassWithLogic
    Private continueValue As Boolean = True

    Function DoSuperComplicated(ByVal param1 As String, ByVal param2 As String, ByVal param4 As Boolean, ByVal param5 As Boolean, ByVal param6 As Integer, ByVal param7 As String, Optional ByVal param8 As String) As Boolean
        If param4 Then
            'Do something
            Select Case param2
                Case "Somevalue"
                    While continueValue
                        'Do Something
                        If param5 Then
                            'Do something
                        ElseIf param6 = 1 Then
                            'Do something
                        End If
                    End While
            End Select
        End If

        Return True
    End Function
End Class
