Public Class SupperDupperBetterClassWithLogic
    Private continueValue As Boolean = True

    Function DoSuperComplicated(ByVal parameters As Parameters) As Boolean
        If parameters.Param4 Then
            'Do something
            Select Case parameters.Param2
                Case "Somevalue"
                    While continueValue
                        'Do Something
                        If parameters.Param5 Then
                            'Do something
                        ElseIf parameters.param6 = 1 Then
                            'Do something
                        End If
                    End While
            End Select
        End If

        Return True
    End Function
End Class


Public Class Parameters
    Public Property Param1() As String

    Public Property Param2() As String

    Public Property Param4() As Boolean

    Public Property Param5 As Boolean

    Public Property Param6 As Integer

    Public Property Param7 As String

    Public Property Param8 As String
End Class