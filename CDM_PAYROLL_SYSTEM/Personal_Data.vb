﻿Imports FireSharp.Config
Imports System.IO

Public Class PersonalData
    Public Property employeeID As String
    Public Property firstName As String
    Public Property lastName As String
    Public Property name As String
    Public Property age As String
    Public Property email As String
    Public Property civil_status As String
    Public Property contact As String
    Public Property date_of_birth As String
    Public Property position As String
    Public Property date_hired As String
    Public Property department As String
    Public Property description As String
    Public Property designation As String
    Public Property no_of_units As String
    Public Property image As String
    Public Property password As String
    Public Property rfidTag As String
    Public Property face_id As String
    Public Property UID As String
    Public Property time_stamp As String
    Public Property createdAt As CreatedAte

    Public Class CreatedAte
        Public Property nanoseconds As Long
        Public Property seconds As Long
    End Class
    Public Class Employee
        Public Property employee_id As String
        Public Property name As String
        Public Property department As String
        Public Property designation As String
    End Class
    Public Class EmployeeSessionToday
        Public Property session_id As String
        Public Property date_stamp As DateTime
        Public Property time_in_stamp As String
        Public Property time_out_stamp As String
    End Class
    Public Class PerWeek
        Public Property session_id As String
        Public Property date_stamp As DateTime
        Public Property time_in_stamp As String
        Public Property time_out_stamp As String
        Public Property TotalPayPeriod As String
    End Class
End Class
