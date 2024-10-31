Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Text
Imports Newtonsoft.Json
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports FontAwesome.Sharp
Imports Newtonsoft.Json.Linq
Imports RestSharp
Imports Firebase.Auth
Imports System.Threading.Tasks
Imports Firebase.Auth.Providers
Imports System.Net.Http
Imports System.ComponentModel
Imports DirectShowLib.DMO
Imports Firebase.Database.Client
Imports System.Windows.Input

Public Class add_account

    Private Const FirebaseAuthUrl As String = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Private authProvider As FirebaseAuthProvider
    Private verificationCodeExpiration As DateTime
    Private Const SenderEmail As String = "payrollcdm504@gmail.com"
    Private Const SmtpHost As String = "smtp.gmail.com"
    Private Const SmtpPort As Integer = 587
    Dim firebaseclient As IFirebaseClient = FirebaseModule.GetFirebaseClient()
    Private verificationCode As String
    Dim onlyID = GenerateID()
    Public Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create() ' Use SHA256.Create() directly
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()

            For Each b As Byte In bytes
                builder.Append(b.ToString("x2")) ' Convert each byte to hex format
            Next

            Return builder.ToString() ' Return the hashed password as a hex string
        End Using
    End Function
    Public Function VerifyPassword(plainPassword As String, hashedPassword As String) As Boolean
        Dim hashedInputPassword As String = HashPassword(plainPassword)
        Return hashedInputPassword.Equals(hashedPassword)
    End Function
    Private Function GenerateRandomKey(length As Integer) As String
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim random As New Random()
        Dim result As New System.Text.StringBuilder(length)
        For i As Integer = 1 To length
            result.Append(chars(random.Next(chars.Length)))

        Next
        Return result.ToString()
    End Function

    Private Function GenerateID() As String
        Dim yearPart As String = DateTime.Now.Year.ToString().Substring(2, 2)
        Dim rnd As New Random()
        Dim secondPart As String = rnd.Next(0, 1000000).ToString("D6")
        Dim generatedID As String = yearPart & "-" & secondPart

        Return generatedID
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                verificationCode = GenerateRandomKey(6)
                verificationCodeExpiration = DateTime.UtcNow.AddHours(1)
                Dim smtpClient As New SmtpClient(SmtpHost, SmtpPort)
                smtpClient.EnableSsl = True
                smtpClient.Credentials = New NetworkCredential(SenderEmail, "oxub yeaa gwov pxif")

                Dim mailMessage As New MailMessage()
                mailMessage.From = New MailAddress(SenderEmail)
                mailMessage.To.Add(TextBox1.Text)
                mailMessage.Subject = "Email Verification Code"
                mailMessage.Body = $"Your verification code is: {verificationCode}"

                smtpClient.Send(mailMessage)
                Button1.Enabled = False
                Button1.BackColor = Color.Gray
                Timer1.Start()
                MessageBox.Show("Verification code sent successfully!")
            Catch ex As Exception
                MessageBox.Show($"Error sending email: {ex.Message}")
            End Try
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
        Employee_Dashboard.Show()
    End Sub

    Private Sub add_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label8.Text = "Account ID: " & GenerateID()

        Try
            Dim firebaseclient As IFirebaseClient = FirebaseModule.GetFirebaseClient()
        Catch
            MessageBox.Show("There was a problem connecting to Firebase.")
        End Try
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
       String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
       String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Please fill all required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If TextBox2.Text <> TextBox3.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If TextBox6.Text <> verificationCode Then
            MessageBox.Show("Invalid verification code.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If DateTime.UtcNow > verificationCodeExpiration Then
            MessageBox.Show("Verification code has expired. Please request a new code.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim email As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        Dim client As New HttpClient()
        Dim requestUri As String = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}"
        Dim jsonPayload = JsonConvert.SerializeObject(New With {
        .email = email,
        .password = password,
        .returnSecureToken = True
    })

        Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

        Try
            Dim response = Await client.PostAsync(requestUri, content)
            If response.IsSuccessStatusCode Then
                Dim resultJson = Await response.Content.ReadAsStringAsync()
                Dim resultData = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(resultJson)
                Dim uid = resultData("localId")
                MessageBox.Show("Account created successfully! " + Label8.Text)

                ' Hash the password
                Dim passwordhasher = HashPassword(TextBox2.Text)

                Dim now As DateTime = DateTime.UtcNow
                Dim unixTimestamp As Long = CLng((now - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds)
                Dim nanoSeconds As Integer = now.Millisecond * 1000000  ' Convert milliseconds to nanoseconds

                ' Prepare the personal data object with the creation timestamp
                Dim PD As New PersonalData With {
                .Email_Address = TextBox1.Text,
                .Password = passwordhasher,
                .createdAt = New PersonalData.CreatedAte With {
                .nanoseconds = nanoSeconds,
                .seconds = unixTimestamp
                },
                .Employee_ID = onlyID
            }

                ' Save the data to Firebase
                Dim save = firebaseclient.Set("usersTbl/" + uid, PD)
                Label9.Text = GenerateID()

                Dim rfidregisteruid As New register_rfid
                rfidregisteruid.UserUID = uid
                rfidregisteruid.Show()
                Me.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox6.Clear()
            Else
                Dim errorJson = Await response.Content.ReadAsStringAsync()
                Dim errorData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(errorJson)
                MessageBox.Show("Error: " & errorData("error")("message").ToString())
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button1.Enabled = True
        Button1.BackColor = Color.DarkSeaGreen
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            TextBox3.PasswordChar = ""
        Else
            TextBox3.PasswordChar = "*"
        End If
    End Sub

    Private ReadOnly inputPattern As String = "^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$"
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox2.Text, inputPattern) Then
            TextBox2.ForeColor = Color.Green
            Label6.Visible = False
        Else
            Label6.Text = "Password must contain Number, Capslock and Special Characters."
            Label6.ForeColor = Color.Maroon
            Label6.Visible = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Define the email pattern to include "@pnm.edu.ph"
        Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@pnm\.edu\.ph$"

        ' Check if the input matches the required email pattern
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, emailPattern) Then
            TextBox1.ForeColor = Color.Green
            Label9.Visible = False
        Else
            Label9.Text = "Email must be in the format: username@pnm.edu.ph"
            Label9.ForeColor = Color.Maroon
            Label9.Visible = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
