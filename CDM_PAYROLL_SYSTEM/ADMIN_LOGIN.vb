Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports Firebase.Database
Imports Firebase.Database.Query
Imports System.IO.Ports
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class ADMIN_LOGIN
    Dim WithEvents serialPort As New SerialPort("COM3", 115200)
    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Private Const AdminUID As String = "bGosQ0qr21OVzucmywytS5eMxDy2" ' The admin UID

    ' Define Firebase connection variables
    Dim fbClient As IFirebaseClient

    ' Define the fingerprint scanner object
    Dim fingerprintScanner As New FingerprintScanner() ' Assuming you have a custom class to interact with the fingerprint scanner

    ' Variable to store the registered fingerprint from Firebase
    Dim registeredFingerprint As String

    ' Flag for exiting the application
    Private isExiting As Boolean = False
    Private Sub FetchAdminData()
        Try
            ' Fetch data from Firebase using the admin ID path
            Dim response As FireSharp.Response.FirebaseResponse = fbClient.Get("AdminTbl/Admin1/")

            If response.StatusCode = Net.HttpStatusCode.OK Then
                ' Deserialize the response into a dictionary
                Dim adminData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response.Body)

                If adminData IsNot Nothing Then
                    ' Pass the data to the Main Dashboard form
                    Dim dashboard As New Main_Dashboard()
                    dashboard.adminID = adminData("AdminID").ToString()
                    dashboard.Fingerprint = adminData("Fingerprint").ToString()
                    dashboard.getName = adminData("Name").ToString()
                    dashboard.Permissions = adminData("Permissions").ToString()
                    dashboard.Role = adminData("Role").ToString()
                    dashboard.RoleID = adminData("RoleID").ToString()

                    ' Show the Main Dashboard form and hide the login form
                    dashboard.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("No data found in AdminTbl/Admin1/")
                End If
            Else
                MessageBox.Show("Failed to fetch data from Firebase.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub

    ' When form loads, initialize Firebase and get the registered fingerprint from Firebase
    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Dim incomingData As String = serialPort.ReadLine().Trim()

        If incomingData = "LOGIN_SUCCESS" Then
            Invoke(New System.Action(Sub() HandleLoginSuccess()))
        ElseIf incomingData = "LOGIN_FAILED" Then
            Invoke(New System.Action(Sub() HandleLoginFailed()))
        End If
    End Sub
    Private Sub HandleLoginFailed()
        MessageBox.Show("Login Failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If serialPort.IsOpen Then
            serialPort.Close()
        End If
    End Sub
    Private Sub HandleLoginSuccess()
        Timer1.Enabled = True
    End Sub
    Private Async Sub Admin_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        Try
            If Not serialPort.IsOpen Then
                serialPort.Open()
            End If
            ' Send command to initialize the fingerprint sensor and turn on LED (if applicable)
            serialPort.WriteLine("INIT_SENSOR")
        Catch ex As Exception
            MessageBox.Show("Error initializing serial port: " & ex.Message)
        End Try
        ' Initialize Firebase client
        fbClient = FirebaseModule.GetFirebaseClient()

        ' Retrieve the registered fingerprint from Firebase
        Await GetRegisteredFingerprint()
    End Sub

    ' Function to get the registered fingerprint from Firebase
    Private Async Function GetRegisteredFingerprint() As Task
        Try
            ' Get the registered fingerprint from the path AdminTbl/Admin1/Fingerprint
            Dim snapshot As String = Await Task.Run(Function()
                                                        ' Ensure you're using FirebaseClient and the correct method to query Firebase
                                                        Dim fbDatabase As New FirebaseClient("https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/")
                                                        ' The correct method for querying data
                                                        Return fbDatabase.Child("AdminTbl").Child("Admin1").Child("Fingerprint").OnceSingleAsync(Of String)()
                                                    End Function)

            registeredFingerprint = snapshot ' This holds the fingerprint ID stored in Firebase
        Catch ex As Exception
            MessageBox.Show("Error retrieving fingerprint data: " & ex.Message)
        End Try
    End Function

    ' Button click event for scanning fingerprint
    Private Sub btnScanFingerprint_Click(sender As Object, e As EventArgs)
        ' Start scanning the fingerprint
        Dim scannedFingerprint = fingerprintScanner.Scan

        ' Compare the scanned fingerprint with the registered fingerprint from Firebase
        If scannedFingerprint = registeredFingerprint Then
            ' If fingerprint matches, open the Main Dashboard
            MessageBox.Show("Fingerprint recognized. Access granted.")
            Main_Dashboard.Show()
            Hide() ' Hide the login form
        Else
            ' If fingerprint does not match, show an error message
            MessageBox.Show("Fingerprint not recognized. Access denied.")
        End If
    End Sub

    ' Confirmation for exiting the application
    Private Sub ADMIN_LOGIN_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to False
        If Not isExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                isExiting = True ' Set the flag to prevent further prompts
                Application.Exit() ' Exit the entire application
            End If
        End If
    End Sub

    ' Panel paint event handler
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Custom painting code can go here, if necessary
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Increment the progress bar
        ProgressBar1.Value += 20
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            Timer1.Enabled = False ' Stop the timer when progress is complete
            ProgressBar1.Value = 0
            serialPort.Close()
            MessageBox.Show("LOG IN SUCCESS!") ' Reset progress bar
            FetchAdminData()
        End If
    End Sub
End Class
' FingerprintScanner class definition
Public Class FingerprintScanner
    ' Simulated method for scanning a fingerprint
    Public Function Scan() As String
        ' Code to interact with your fingerprint scanner and return the scanned fingerprint ID as a string
        ' Replace this with the actual fingerprint scanning code
        Return "sample_fingerprint_id" ' This is just a placeholder for demonstration
    End Function
End Class