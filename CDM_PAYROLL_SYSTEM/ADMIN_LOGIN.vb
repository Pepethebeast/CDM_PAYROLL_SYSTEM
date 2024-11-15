Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class ADMIN_LOGIN

    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Private Const AdminUID As String = "bGosQ0qr21OVzucmywytS5eMxDy2" ' The admin UID

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim email = TextBox1.Text
        'Dim password = TextBox2.Text

        'If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
        '    MessageBox.Show("Please enter both email and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If

        'Try
        '    Using client As New HttpClient
        '        Dim requestUri = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}"

        '        Dim jsonPayload = JsonConvert.SerializeObject(New With {
        '            email,
        '            password,
        '            .returnSecureToken = True
        '        })

        '        Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

        '        Dim response = Await client.PostAsync(requestUri, content)

        '        If response.IsSuccessStatusCode Then
        '            Dim responseJson = Await response.Content.ReadAsStringAsync
        '            Dim responseData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseJson)

        '            If responseData.ContainsKey("localId") Then
        '                Dim uid = responseData("localId").ToString

        '                ' Check if the UID matches the admin UID
        '                If uid = AdminUID Then
        'MessageBox.Show($"ADMIN LOG IN SUCCESS!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Hide()
        Main_Dashboard.Show()
        '                Else
        '                    MessageBox.Show("ACCESS DENIED: ONLY ADMIN CAN LOG IN", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                End If
        '            Else
        '                MessageBox.Show("Error: UID not found in the response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End If
        '        Else
        '            Dim errorJson = Await response.Content.ReadAsStringAsync
        '            Dim errorData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(errorJson)

        '            If errorData.ContainsKey("error") AndAlso errorData("error").ContainsKey("message") Then
        '                Dim errorMessage = errorData("error")("message").ToString
        '                MessageBox.Show($"Login failed: {errorMessage}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                TextBox2.Clear()
        '            Else
        '                MessageBox.Show("An unknown error occurred during login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End If
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub ADMIN_LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Sub ADMIN_LOGIN_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to True
        If Not isExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                isExiting = True ' Set the flag to prevent further prompts
                Application.Exit() ' Exit the entire application
            End If
        End If
    End Sub

End Class