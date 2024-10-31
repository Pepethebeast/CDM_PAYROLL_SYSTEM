Imports System.Windows.Forms
Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Interfaces
Imports System.IO
Imports System.Threading

Public Class RFID_Based_Attendance
    Private WithEvents rfidReader As New IO.Ports.SerialPort()
    Private firestoreClient As IFirebaseClient

    Public Sub New()
        InitializeComponent()
        InitializeFirebase()
        InitializeRFIDReader()
    End Sub


    Private lblStatus As Label
    Private lstAttendance As ListBox

    Private Sub InitializeFirebase()
        Dim config = New FirebaseConfig() With {
            .AuthSecret = "ivwZ5tA6oaxVQs1uQNnSecoaSqm38VwV6eJtc7Bn",
            .BasePath = "https://admin-cdm-payroll-db-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }
        firestoreClient = New FireSharp.FirebaseClient(config)
    End Sub

    Private Sub InitializeRFIDReader()
        rfidReader.PortName = "COM1" ' Change this to match your RFID reader's COM port
        rfidReader.BaudRate = 9600  ' Change this to match your RFID reader's baud rate
        rfidReader.DataBits = 8
        rfidReader.Parity = IO.Ports.Parity.None
        rfidReader.StopBits = IO.Ports.StopBits.One

        Try
            rfidReader.Open()

        Catch ex As Exception
            MessageBox.Show("Error connecting to RFID reader: " & ex.Message)
        End Try
    End Sub

    Private Sub rfidReader_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles rfidReader.DataReceived
        Dim rfidTag As String = rfidReader.ReadLine().Trim()
        Me.Invoke(Sub() ProcessAttendance(rfidTag))
    End Sub

    Private Async Sub ProcessAttendance(rfidTag As String)
        lblStatus.Text = "Processing tag: " & rfidTag

        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim attendanceRecord = New With {
            .RFIDTag = rfidTag,
            .Timestamp = timestamp
        }

        Try
            Await firestoreClient.PushAsync("attendance", attendanceRecord)
            lstAttendance.Items.Add($"{timestamp} - {rfidTag}")
            lblStatus.Text = "Attendance recorded for tag: " & rfidTag
        Catch ex As Exception
            MessageBox.Show("Error recording attendance: " & ex.Message)
            lblStatus.Text = "Error recording attendance"
        End Try

        Thread.Sleep(1000) ' Wait for 1 second before allowing next scan
        lblStatus.Text = "Waiting for tag..."
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If rfidReader.IsOpen Then
            rfidReader.Close()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub RFID_Based_Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class