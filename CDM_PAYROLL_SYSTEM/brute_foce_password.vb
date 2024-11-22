Public Class brute_foce_password
    Public Property received_email
    Public Property user_uid As String
    Public Property password As String
    Private Sub brute_foce_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = received_email
        TextBox2.Text = password
        Label2.Text = $"UID: {user_uid}"
    End Sub
End Class