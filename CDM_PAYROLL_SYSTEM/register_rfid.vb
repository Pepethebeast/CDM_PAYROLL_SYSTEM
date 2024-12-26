Imports Microsoft
Imports FireSharp.Config
Imports Firebase.Database
Imports Firebase.Auth
Imports FireSharp.Interfaces
Imports System.IO.Ports
Imports Firebase.Database.Query
Imports Newtonsoft.Json.Linq
Imports Firebase.Auth.Providers
Imports System.Net
Imports FireSharp.Response

Public Class register_rfid
    Private WithEvents serialPort As New SerialPort()
    Public Property UserUID As String
    Public Property add_employee_id As String

    Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

    ' Form Load - Firebase setup and serial port
    Private Sub register_rfid_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Check if COM3 is available
            If Not FirebaseModule.IsSerialPortAvailable() Then
                MessageBox.Show("Error: Device not found. Please connect the device and try again.", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close() ' Close the form immediately if COM3 is not available
                Exit Sub
            End If

            ' Proceed with other initialization if the port is available
            ' (Add other initialization code here if needed)

        Catch ex As Exception
            Debug.WriteLine("Error in form load: " & ex.Message)
            MessageBox.Show("Error initializing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close() ' Close the form in case of any unexpected errors
        End Try
    End Sub

    ' Data received from serial port
    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Try
            Dim scannedRFID As String = serialPort.ReadLine().Trim().ToLower()
            Debug.WriteLine("Scanned RFID: " & scannedRFID)

            If scannedRFID.StartsWith("scanned rfid tag:") Then
                scannedRFID = scannedRFID.Substring("scanned rfid tag:".Length).Trim()
                Invoke(Sub()
                           Label2.Text = scannedRFID
                           Debug.WriteLine("Valid RFID detected: " & scannedRFID)
                           StartProgressBarAndSave(scannedRFID)
                       End Sub)
            End If

        Catch ex As Exception
            Debug.WriteLine("Error reading RFID: " & ex.Message)
        End Try
    End Sub

    Private Sub StartProgressBarAndSave(rfidTag As String)
        Debug.WriteLine("Starting progress bar and save process for RFID: " & rfidTag)
        ProgressBar1.Value = 0 ' Reset progress bar
        ProgressBar1.Visible = True ' Make sure the progress bar is visible
        Timer1.Start() ' Start the timer to fill the progress bar
        RegisterRFIDTag(rfidTag) ' Call the method to save the RFID tag to Firebase
    End Sub

    ' Timer to update the progress bar
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < ProgressBar1.Maximum Then
            ProgressBar1.Value += 5 ' Adjust increment as needed
        Else
            Timer1.Stop() ' Stop the timer when the progress bar is full
            ProgressBar1.Visible = False ' Hide the progress bar when done
        End If
    End Sub
    Private Async Function CheckRFIDExistsInDatabase(rfidTag As String) As Task(Of Boolean)
        Try
            ' Get reference to usersTbl
            Dim response = Await client.GetAsync("usersTbl/")

            If response.StatusCode = HttpStatusCode.OK Then
                ' Convert response to dictionary
                Dim users As Dictionary(Of String, Dictionary(Of String, String)) =
                response.ResultAs(Of Dictionary(Of String, Dictionary(Of String, String)))

                ' Check if RFID exists in any user's data
                If users IsNot Nothing Then
                    For Each user In users.Values
                        If user.ContainsKey("rfidTag") AndAlso
                       user("rfidTag").Equals(rfidTag, StringComparison.OrdinalIgnoreCase) Then
                            Return True ' RFID found
                        End If
                    Next
                End If
            End If
            Return False ' RFID not found
        Catch ex As Exception
            Debug.WriteLine("Error checking RFID existence: " & ex.Message)
            Return False
        End Try
    End Function
    ' Register RFID Tag to Firebase
    Private Async Sub RegisterRFIDTag(rfidTag As String)
        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient
        Debug.WriteLine("Attempting to register RFID: " & rfidTag)
        If client IsNot Nothing AndAlso Not String.IsNullOrEmpty(UserUID) Then
            Try
                ' First check if RFID already exists
                If Await CheckRFIDExistsInDatabase(rfidTag) Then
                    Debug.WriteLine("RFID already exists in database")
                    Invoke(Sub()
                               Label2.Text = "RFID already used"
                               Label2.ForeColor = Color.Red
                           End Sub)
                    MessageBox.Show("This RFID tag is already registered to another user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' If RFID doesn't exist, proceed with registration
                Dim path As String = $"usersTbl/{UserUID}/rfidTag"
                Debug.WriteLine("Sending RFID to Firebase path: " & path)

                Dim response As FirebaseResponse = Await client.SetAsync(path, rfidTag)
                If response.StatusCode = HttpStatusCode.OK Then
                    Debug.WriteLine("RFID registered successfully")
                    Invoke(Sub()
                               Label2.Text = "Registration successful"
                               Label2.ForeColor = Color.Green
                           End Sub)
                    Dim reportTbl = client.Set("ReportTbl/account/" & FirebaseModule.numericGuid & "/message", "RFID Registed to employee ID: " + add_employee_id)
                    reportTbl = client.Set("ReportTbl/account/" & FirebaseModule.numericGuid & "/Date", FirebaseModule.today + " " + FirebaseModule.nowTime)
                    MessageBox.Show("RFID tag registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Debug.WriteLine("Failed to register RFID. Status code: " & response.StatusCode)
                    Invoke(Sub()
                               Label2.Text = "Registration failed"
                               Label2.ForeColor = Color.Red
                           End Sub)
                    MessageBox.Show("Failed to register RFID tag.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                Debug.WriteLine("Error registering RFID: " & ex.Message)
                Invoke(Sub()
                           Label2.Text = "Registration failed"
                           Label2.ForeColor = Color.Red
                       End Sub)
                MessageBox.Show("Error registering RFID tag: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Debug.WriteLine("UserUID is not set or Firebase client is not initialized")
            Invoke(Sub()
                       Label2.Text = "Registration failed"
                       Label2.ForeColor = Color.Red
                   End Sub)
            MessageBox.Show("UserUID is not set or Firebase client is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Form closing - release serial port
    Private Sub rfidRegisterForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FirebaseModule.CloseSerialPort()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
    End Sub
End Class

