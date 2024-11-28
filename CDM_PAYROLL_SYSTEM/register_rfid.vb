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

    Private client As IFirebaseClient
    Public Property UserUID As String
    Public Property add_employee_id As String
    Private WithEvents serialPort As New SerialPort("COM3", 115200, Parity.None, 8, StopBits.One)

    ' Form Load - Firebase setup and serial port
    Private Sub register_rfid_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Check if COM3 is available
            If Not IsComPortAvailable("COM3") Then
                MessageBox.Show("Error: Device not found.", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close() ' Close the form if COM3 is not found
                Exit Sub
            End If

            ' Initialize Firebase connection
            Dim config As New FirebaseConfig() With {
            .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
            .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }
            client = New FireSharp.FirebaseClient(config)
            Debug.WriteLine("Firebase client initialized successfully")

            ' Initialize progress bar
            ProgressBar1.Value = 0
            ProgressBar1.Visible = False
            Timer1.Interval = 50

            ' Open COM3 for RFID data
            If Not serialPort.IsOpen Then
                serialPort.Open()
                Debug.WriteLine("Serial port opened successfully")
            End If

        Catch ex As Exception
            Debug.WriteLine("Error in form load: " & ex.Message)
            MessageBox.Show("Error initializing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function IsComPortAvailable(portName As String) As Boolean
        Try
            ' Try to open the port
            Using sp As New IO.Ports.SerialPort(portName)
                sp.Open()
                sp.Close()
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' Data received from serial port
    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Try
            ' Read the scanned RFID and normalize it
            Dim scannedRFID As String = serialPort.ReadLine().Trim().ToLower()
            Debug.WriteLine("Scanned RFID: " & scannedRFID)

            If scannedRFID.StartsWith("scanned rfid tag:") Then
                scannedRFID = scannedRFID.Substring("scanned rfid tag:".Length).Trim()
                Invoke(Sub()
                           Label2.Text = scannedRFID
                           Debug.WriteLine("Valid RFID detected: " & scannedRFID)
                           ' Start the progress bar and save to Firebase
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
        If serialPort.IsOpen Then
            serialPort.Close()
            Debug.WriteLine("Serial port closed")
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
    End Sub
End Class



'Private connect1 As New FireSharp.Config.FirebaseConfig() With {
'    .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
'    .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
'}

'Private client As IFirebaseClient
'Private rfidData As String = String.Empty
'Public Property NameforCamera As String
'Public Property UserUID As String
'Public Property EMAILFOR_FaceRecog As String

'Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
'    Me.Close()
'    acc.Show()
'End Sub

'Private WithEvents scanTimer As New Timer()
'Private scanProgress As Integer = 0

'Private Sub register_rfid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'    Try
'        client = New FireSharp.FirebaseClient(connect1)
'    Catch ex As Exception
'        MessageBox.Show("There was a problem connecting to Firebase: " & ex.Message)
'    End Try

'    ProgressBar1.Maximum = 100
'    scanTimer.Interval = 50
'    Me.KeyPreview = True
'End Sub

'Private Sub register_rfid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
'    If e.KeyChar = ChrW(Keys.Enter) Then
'        If Not String.IsNullOrEmpty(rfidData) Then
'            scanProgress = 0
'            ProgressBar1.Value = scanProgress
'            scanTimer.Start()
'        End If
'    Else
'        rfidData &= e.KeyChar
'    End If
'End Sub

'Private Async Sub scanTimer_Tick(sender As Object, e As EventArgs) Handles scanTimer.Tick
'    If scanProgress < 100 Then
'        scanProgress += 20
'        ProgressBar1.Value = scanProgress
'    Else
'        scanTimer.Stop()
'        Button4.Visible = True
'        ProgressBar1.Visible = False
'        Label2.Text = "RFID Scanned Successfully"

'        ' Check if the RFID tag is already registered
'        Dim existingTag = Await client.GetAsync("usersTbl")
'        Dim usersDict As JObject = existingTag.ResultAs(Of JObject)

'        Dim isTagInUse As Boolean = False

'        If usersDict IsNot Nothing Then
'            For Each user In usersDict.Properties()
'                Dim userDetails As JObject = CType(user.Value, JObject)

'                If userDetails.ContainsKey("rfidTag") AndAlso userDetails("rfidTag").ToString() = rfidData Then
'                    isTagInUse = True
'                    Label2.Text = "RFID TAG IS ALREADY USED"
'                    Button4.Visible = False
'                    Exit For
'                End If
'            Next
'        End If

'        ' If the tag is not in use, save it
'        If Not isTagInUse Then
'            Try
'                Dim save = Await client.SetAsync($"usersTbl/{UserUID}/rfidTag", rfidData)
'                Label2.Text = "RFID TAG REGISTERED SUCCESSFULLY"
'                rfidData = String.Empty ' Clear RFID data for the next scan
'            Catch ex As Exception
'                MessageBox.Show("Error registering RFID tag: " & ex.Message)
'            End Try
'        End If
'    End If
'End Sub

'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
'    ' Navigation or further actions can be implemented here\
'    Me.Close()
'End Sub

