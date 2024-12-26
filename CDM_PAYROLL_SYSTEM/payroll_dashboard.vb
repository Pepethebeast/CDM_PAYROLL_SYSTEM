Public Class payroll_dashboard
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        payroll.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Main_Dashboard.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Hide()
        Employee_Dashboard.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        time_records_dashboard.Show()
        Me.Hide()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        acc.Show()
        Me.Hide()
    End Sub

    Private Sub payroll_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub payroll_dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to True
        If Not IsExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                IsExiting = True ' Set the flag to prevent further prompts
                Application.Exit() ' Exit the entire application
            End If
        End If
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Hide()
        reports.Show()
    End Sub
End Class