﻿Imports System.IO.Ports

Public Class register_fingerprint
    Dim WithEvents SerialPort As New SerialPort

    Private Sub register_fingerprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the serial port
        SerialPort.PortName = "COM3" ' Change to your ESP32 COM port
        SerialPort.BaudRate = 115200
        SerialPort.Parity = Parity.None
        SerialPort.DataBits = 8
        SerialPort.StopBits = StopBits.One
        SerialPort.Open()
        Timer2.Interval = 1000 ' Check every 1 second
        Timer2.Start()
    End Sub


    Private Sub btnRegisterFingerprint_Click(sender As Object, e As EventArgs) Handles btnRegisterFingerprint.Click
        If SerialPort.IsOpen Then
            Label2.Text = "Connecting..."
            SerialPort.WriteLine("REGISTER") ' Send command to ESP32
        Else
            Label2.Text = "Serial port not open!"
        End If
    End Sub

    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Dim response As String = SerialPort.ReadLine()

        ' Handle ESP32 responses
        Invoke(Sub()
                   Select Case response.Trim()
                       Case "REGISTRATION_SUCCESS"
                           ProgressBar1.Increment(5)

                           If ProgressBar1.Value >= 100 Then
                               Label2.Text = "Fingerprint registered successfully!"
                               Timer1.Stop() ' Stop the progress timer
                           End If
                           Me.Close() ' Close the form after successful registration
                       Case "REGISTRATION_FAILED"
                           Label2.Text = "Hold your finger!"
                       Case Else
                           Label2.Text = response
                   End Select
               End Sub)
    End Sub

    Private Sub register_fingerprint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort.IsOpen Then SerialPort.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        Main_Dashboard.Show()
    End Sub
    Dim previousPorts As New List(Of String)
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim availablePorts As String() = SerialPort.GetPortNames()
        Dim currentPorts As New List(Of String)(availablePorts)

        ' Check for new COM ports added
        For Each port In currentPorts
            If Not previousPorts.Contains(port) Then
                MessageBox.Show($"{port} is now available.", "COM Port Detected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next

        ' Check for removed COM ports
        For Each port In previousPorts
            If Not currentPorts.Contains(port) Then
                MessageBox.Show($"{port} is no longer available.", "COM Port Lost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Next

        ' Update previousPorts list
        previousPorts = New List(Of String)(currentPorts)
    End Sub

End Class