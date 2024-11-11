﻿Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FirebaseAuth
Imports Firebase.Auth.Providers
Imports Newtonsoft.Json
Imports Firebase.Auth
Module FirebaseModule
    Private client As IFirebaseClient

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

End Module
