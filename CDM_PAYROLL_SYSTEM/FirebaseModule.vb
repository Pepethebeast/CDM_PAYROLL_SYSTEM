Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Firebase.Auth.Providers
Imports Newtonsoft.Json
Imports Firebase.Auth
Module FirebaseModule
    Private client As IFirebaseClient
    Public IsExiting As Boolean = False
    ' Configuration for FireSharp (Realtime Database)
    Private ReadOnly FirebaseConfig As New FirebaseConfig With {
        .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
    }

    ' Function to get the Firebase client for Realtime Database
    Public Function GetFirebaseClient() As IFirebaseClient
        If client Is Nothing Then
            client = New FireSharp.FirebaseClient(FirebaseConfig)
        End If
        Return client
    End Function

    ' Function to get the Firebase Authentication Provider for authentication tasks
    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"

    Public numericGuid As String = New String(Guid.NewGuid().ToString().Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 8)
End Module
