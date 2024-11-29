Public Class Admin_Info
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        register_fingerprint.Show()
        Me.Close()
    End Sub
End Class