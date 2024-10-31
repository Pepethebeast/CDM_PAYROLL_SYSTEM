Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response

Module Connection


    Public Class FirebaseHelper
        Private Shared firebaseClient As IFirebaseClient

        ' Initialize Firebase with your credentials
        Public Shared Sub InitializeFirebase()
            Dim config = New FirebaseConfig() With {
                .AuthSecret = "ivwZ5tA6oaxVQs1uQNnSecoaSqm38VwV6eJtc7Bn",
                .BasePath = "https://admin-cdm-payroll-db-default-rtdb.asia-southeast1.firebasedatabase.app/"
            }

            firebaseClient = New FireSharp.FirebaseClient(config)

            If firebaseClient Is Nothing Then
                Throw New Exception("Failed to connect to Firebase")
            End If
        End Sub

        ' Get the Firebase client for reuse in other functions
        Public Shared Function GetFirebaseClient() As IFirebaseClient
            Return firebaseClient
        End Function
    End Class
    Public Class Employee
        Public Property EmployeeID As String
        Public Property Name As String
        Public Property Department As String
        Public Property Designation As String
    End Class

    Public Class Attendance
        Public Property EmployeeID As String
        Public Property TimeIn As String
        Public Property TimeOut As String
        Public Property Date123 As String
    End Class

End Module
