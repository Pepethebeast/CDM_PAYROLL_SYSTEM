Imports FireSharp.Config
Imports System.IO

Public Class PersonalData
    Public Property Employee_ID As String
    Public Property Name As String
    Public Property Age As String
    Public Property Email_Address As String
    Public Property CivilStatus As String
    Public Property Contact As String
    Public Property DateOfBirth As String
    Public Property Position As String
    Public Property DateHired As String
    Public Property Department As String
    Public Property Description As String
    Public Property Designation As String
    Public Property NoofUnits As String
    Public Property Image As String
    Public Property Password As String
    Public Property rfidtag As String
    Public Property createdAt As CreatedAte

    Public Class CreatedAte
        Public Property seconds As String
        Public Property nanoseconds As String
    End Class

End Class
