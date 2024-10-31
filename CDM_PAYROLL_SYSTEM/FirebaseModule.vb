Imports FireSharp.Config
Imports FireSharp.Interfaces

Module FirebaseModule

    Private client As IFirebaseClient
    Private ReadOnly FirebaseConfig As New FirebaseConfig With {
            .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }

    ' Function to get the Firebase client
    Public Function GetFirebaseClient() As IFirebaseClient
        If client Is Nothing Then
            client = New FireSharp.FirebaseClient(FirebaseConfig)
        End If
        Return client
    End Function

End Module
