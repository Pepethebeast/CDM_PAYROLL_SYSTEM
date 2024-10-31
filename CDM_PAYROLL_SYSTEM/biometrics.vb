Imports System.Windows

Public Class biometrics
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        FaceRecognitionForm.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        RFID_Based_Attendance.Show()

    End Sub
End Class