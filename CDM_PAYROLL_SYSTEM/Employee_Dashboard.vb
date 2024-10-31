Public Class Employee_Dashboard
    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        List_of_Employees.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        add_account.Show()
        Me.Close()


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Main_Dashboard.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Close
        payroll.Show
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        timeinout.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)
        Close
        acc.Show
    End Sub


    Private Sub Employee_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        payroll.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
        timeinout.Show()
    End Sub

    Private Sub Label6_Click_1(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
        acc.Show()
    End Sub



    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
        List_of_Employees.Show()
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Me.Close()
        add_employee.Show()
    End Sub
End Class