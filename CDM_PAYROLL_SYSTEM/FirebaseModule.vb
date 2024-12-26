Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Firebase.Auth.Providers
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports System.IO.Ports
Module FirebaseModule
    Public WithEvents SerialPort As New SerialPort()
    Private client As IFirebaseClient
    Public IsExiting As Boolean = False
    ' Configuration for FireSharp (Realtime Database)
    Private ReadOnly FirebaseConfig As New FirebaseConfig With {
        .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
    }

    ' Function to get the Firebase client for Realtime Database
    Public Function GetAvailableComPort() As String
        Dim availablePorts = SerialPort.GetPortNames()
        If availablePorts.Length > 0 Then
            Return availablePorts(0) ' Return the first available port
        Else
            Throw New Exception("No COM ports detected.")
        End If
    End Function
    Public Function GetFirebaseClient() As IFirebaseClient
        If client Is Nothing Then
            client = New FireSharp.FirebaseClient(FirebaseConfig)
        End If
        Return client
    End Function

    ' Function to get the Firebase Authentication Provider for authentication tasks
    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"

    Public numericGuid As String = New String(Guid.NewGuid().ToString().Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 8)
    Public today As String = DateTime.Now.ToString("yyyy-MM-dd")
    Public nowTime As String = DateTime.Now.ToString("HH:mm:ss")

    ' Shared method to initialize and detect serial port
    Public Sub InitializeSerialPort()
        Dim availablePorts = SerialPort.GetPortNames()

        If availablePorts.Length = 0 Then
            Throw New Exception("No COM ports detected. Please connect a device and try again.")
        End If

        Try
            ' Open the first available port
            SerialPort = New SerialPort(availablePorts(0)) With {
                .BaudRate = 9600,
                .DataBits = 8,
                .StopBits = StopBits.One,
                .Parity = Parity.None
            }
            SerialPort.Open()
            Debug.WriteLine($"Serial port opened successfully on {SerialPort.PortName}")
        Catch ex As Exception
            Throw New Exception("Failed to initialize the serial port: " & ex.Message)
        End Try
    End Sub
    Public Function IsSerialPortAvailable() As Boolean
        Try
            Dim availablePorts = IO.Ports.SerialPort.GetPortNames()
            Return availablePorts.Length > 0 ' Return True if at least one port is available
        Catch ex As Exception
            Debug.WriteLine("Error checking serial ports: " & ex.Message)
            Return False
        End Try
    End Function
    ' Start checking ports with a timer
    Public Async Function GetRegisteredFingerprintAsync() As Task(Of Boolean)
        Dim client = GetFirebaseClient()
        Dim response = Await client.GetAsync($"AdminTbl/Admin1/Fingerprint")
        Return Not String.IsNullOrEmpty(response.Body)
    End Function

    Public Sub CheckAndOpenSerialPort()
        Try
            If SerialPort Is Nothing OrElse Not SerialPort.IsOpen Then
                Dim availablePorts = SerialPort.GetPortNames()

                If availablePorts.Length = 0 Then
                    Throw New Exception("No COM ports detected. Please connect a device.")
                End If

                ' Open the first available port
                SerialPort = New SerialPort(availablePorts(0)) With {
                    .BaudRate = 9600,
                    .DataBits = 8,
                    .StopBits = StopBits.One,
                    .Parity = Parity.None
                }
                SerialPort.Open()
                Debug.WriteLine($"Serial port opened on {SerialPort.PortName}")
            Else
                Debug.WriteLine("Serial port is already open.")
            End If
        Catch ex As Exception
            Throw New Exception("Error checking or opening the serial port: " & ex.Message)
        End Try
    End Sub

    ' Method to close the serial port
    Public Sub CloseSerialPort()
        Try
            If SerialPort IsNot Nothing AndAlso SerialPort.IsOpen Then
                SerialPort.Close()
                Debug.WriteLine("Serial port closed successfully.")
            End If
        Catch ex As Exception
            Debug.WriteLine("Error closing serial port: " & ex.Message)
        End Try
    End Sub
End Module
