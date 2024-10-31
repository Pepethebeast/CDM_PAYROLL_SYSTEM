Imports Microsoft
Imports FireSharp.Config
Imports Firebase.Database
Imports Firebase.Auth
Imports FireSharp.Interfaces
Imports Firebase.Database.Client
Imports FireSharp.Response
Imports System.Net
Public Class register_rfid

    Private connect1 As New FireSharp.Config.FirebaseConfig() With {
        .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
    }

    Private client As IFirebaseClient
    Private rfidData As String = String.Empty
    Public Property UserUID As String

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        add_employee.Show()
    End Sub
    Private WithEvents scanTimer As New Timer()
    Private scanProgress As Integer = 0

    Private Sub resgister_rfid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            client = New FireSharp.FirebaseClient(connect1)
        Catch ex As Exception
            MessageBox.Show("There was a problem connecting to Firebase: " & ex.Message)
        End Try
        ProgressBar1.Maximum = 100
        scanTimer.Interval = 50
        Me.KeyPreview = True
    End Sub

    Private Sub register_rfid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not String.IsNullOrEmpty(rfidData) Then
                scanProgress = 0
                ProgressBar1.Value = scanProgress
                scanTimer.Start()
            End If
        Else
            rfidData &= e.KeyChar
        End If
    End Sub

    Private Sub scanTimer_Tick(sender As Object, e As EventArgs) Handles scanTimer.Tick
        If scanProgress < 100 Then
            scanProgress += 20
            ProgressBar1.Value = scanProgress
        Else
            scanTimer.Stop()
            MessageBox.Show("RFID Scanned: " & rfidData)
            Button4.Visible = True
            ProgressBar1.Visible = False
            Label2.Text = "RFID Scanned Successful"

            Dim save = client.Set($"usersTbl/{UserUID}/rfidTag", rfidData)
            ProgressBar1.Value = 0
        End If
    End Sub


End Class