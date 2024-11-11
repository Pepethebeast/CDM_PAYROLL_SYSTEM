Public Class Main_Dashboard

    Dim former As New Form
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        former = Employee_Dashboard
        Me.Close()
        former.Show()


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        former = payroll
        Me.Close()
        former.Show()

    End Sub

    Private Sub Main_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        former = acc
        Me.Close()
        former.Show()

    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click
        former = payroll
        Me.Close()
        former.Show()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        former = RFID_Based_Attendance
        Me.Close()
        former.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        former = FaceRecognitionForm
        former.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        former = Employee_Dashboard
        Me.Close()
        former.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        former = acc
        Me.Close()
        former.Show()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub


    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class