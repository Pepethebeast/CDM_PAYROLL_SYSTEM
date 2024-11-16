Public Class Splash
    Private WithEvents connectionTimer As New Timer()

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MyProgress.Increment(5)

        If MyProgress.Value >= 100 Then
            Timer1.Stop() ' Stop the progress timer
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Optionally handle label click events if needed
    End Sub
End Class
