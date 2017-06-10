Imports NewFeatures

Public Class SupperDupperClassWithExternalLogic
    Private continueValue As Boolean = True

    Function DoSuperComplicated(ByVal parameters As Parameters) As Boolean
        Dim externalLogic As SomethingNew = New SomethingNew()

        If parameters.Param4 Then
            'Do something
            Select Case parameters.Param2
                Case "Somevalue"
                    While continueValue
                        'Do Something
                        externalLogic.DoSomethingNew(True)

                        If parameters.Param5 Then
                            'Do something
                        ElseIf parameters.Param6 = 1 Then
                            'Do something
                        End If
                    End While
            End Select
        End If

        Return True
    End Function
End Class
