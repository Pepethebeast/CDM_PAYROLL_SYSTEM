Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Text
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports Firebase.Database
Imports Firebase.Database.Query
Imports System.Threading.Tasks
Imports Firebase.Auth.Providers
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports System.Net
Imports System.Net.Mail

Public Class add_account

    Public FirebaseApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs" ' Replace with your Firebase API key

    Private firebaseAuthProvider As FirebaseAuthClient

    Public Sub InitializeFirebase()
        Dim config = New FirebaseAuthConfig() With {
        .ApiKey = FirebaseApiKey,
        .AuthDomain = "" ' Optional: only if you have one
    }

        ' Initialize the providers
        config.Providers = New FirebaseAuthProvider() {
        New EmailProvider()}
        ' You can add other providers here if needed, like GoogleProvider or FacebookProvider


        firebaseAuthProvider = New FirebaseAuthClient(config)
    End Sub

    ' Firebase configuration
    Private Const FirebaseAuthUrl As String = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@pnm\.edu\.ph$"
    Dim inputPattern As String = "^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$"
    ' Corrected code to initialize FirebaseAuthProvider
    Dim authProvider As FirebaseAuthProvider

    ' Hash password using SHA256
    Public Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' Form load event
    Private Sub add_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim firebaseclient As IFirebaseClient = FirebaseModule.GetFirebaseClient()
        Catch
            MessageBox.Show("There was a problem connecting to Firebase.")
        End Try

    End Sub
    Private Sub add_account_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub SendEmail(toEmail As String, subject As String, body As String)
        Try
            Dim smtpClient As New SmtpClient("smtp.gmail.com") ' Replace with your SMTP server
            smtpClient.Port = 587 ' Replace with your SMTP port
            smtpClient.Credentials = New NetworkCredential("payrollcdm504@gmail.com", "dursccvkavjmzrka")
            smtpClient.EnableSsl = True

            Dim mailMessage As New MailMessage()
            mailMessage.From = New MailAddress("cdmpayroll@pnm.edu.ph")
            mailMessage.To.Add(toEmail)
            mailMessage.Subject = subject
            mailMessage.Body = body
            mailMessage.IsBodyHtml = True

            smtpClient.Send(mailMessage)
        Catch ex As Exception
            MessageBox.Show($"Email sending error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub InitializeFirebaseApp()
        Try
            ' Check if FirebaseApp instance already exists
            If FirebaseApp.DefaultInstance Is Nothing Then
                FirebaseApp.Create(New AppOptions() With {
                .Credential = GoogleCredential.FromFile("C:\Users\Zedrick\Documents\Visual Basic\CDM_PAYROLL_SYSTEM\CDM_PAYROLL_SYSTEM\cdm-payroll-system-firebase-adminsdk-9mm0e-ccf4eb02cc.json")
            })
            End If
        Catch ex As Exception
            MessageBox.Show($"Firebase initialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim client444 As IFirebaseClient = FirebaseModule.GetFirebaseClient
        If String.IsNullOrWhiteSpace(nametextbox.Text) OrElse
       String.IsNullOrWhiteSpace(emailtextbox.Text) OrElse
       String.IsNullOrWhiteSpace(passwordtextbox.Text) OrElse
       String.IsNullOrWhiteSpace(confirmpasswordtextbox.Text) OrElse
       String.IsNullOrWhiteSpace(employee_id_textbox.Text) Then
            MessageBox.Show("Please fill all required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf passwordtextbox.Text <> confirmpasswordtextbox.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(emailtextbox.Text, emailPattern) Then
            MessageBox.Show("Please use email format: @pnm.edu.ph", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(passwordtextbox.Text, inputPattern) Then
            MessageBox.Show("Please use a strong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            Dim email As String = emailtextbox.Text
            Dim password As String = passwordtextbox.Text

            Dim client As New HttpClient()
            Dim requestUri As String = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}"
            Dim jsonPayload = JsonConvert.SerializeObject(New With {
            .email = email,
            .password = password,
            .returnSecureToken = True
        })

            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Try
                ' Send the request to create the account
                Dim response = Await client.PostAsync(requestUri, content)

                If response.IsSuccessStatusCode Then
                    ' Parse the response
                    Dim resultJson = Await response.Content.ReadAsStringAsync()
                    Dim resultData = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(resultJson)
                    Dim uid = resultData("localId")
                    MessageBox.Show("Account created successfully!")

                    ' Hash the password
                    Dim passwordhasher = HashPassword(passwordtextbox.Text)

                    ' Prepare the personal data object
                    Dim now As DateTime = DateTime.UtcNow
                    Dim unixTimestamp As Long = CLng((now - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds)
                    Dim nanoSeconds As Integer = now.Millisecond * 1000000  ' Convert milliseconds to nanoseconds

                    Dim PD As New PersonalData With {
            .firstName = nametextbox.Text,
            .lastName = TextBox1.Text,
            .email = email,
            .password = passwordhasher,
            .createdAt = New PersonalData.CreatedAte With {
                .nanoseconds = nanoSeconds,
                .seconds = unixTimestamp
            },
            .employeeID = employee_id_textbox.Text
        }

                    ' Save the data to Firebase 
                    Dim save = client444.Set("usersTbl/" + uid, PD)
                    Dim reportuser = client444.Set("ReportTbl/" & "account/" & FirebaseModule.numericGuid & "/" + "message", "Account creation successfully for employee: " + employee_id_textbox.Text)
                    reportuser = client444.Set("ReportTbl/" & "account/" & FirebaseModule.numericGuid & "/Date", FirebaseModule.today + " " + FirebaseModule.nowTime)
                    Dim save2 = client444.Set("NotificationTbl/" & uid + "/", "Your account was successfully created by admin.")

                    Try
                        ' Initialize Firebase if not already done
                        InitializeFirebaseApp()

                        ' Fetch the user by UID
                        Dim auth As FirebaseAuth = FirebaseAuth.DefaultInstance
                        Dim userRecord As UserRecord = Await auth.GetUserAsync(uid)

                        ' Check if user has an email
                        If String.IsNullOrEmpty(userRecord.Email) Then
                            MessageBox.Show("The user does not have an email address associated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        ' Generate verification link
                        Dim link As String = Await FirebaseAuth.DefaultInstance.GenerateEmailVerificationLinkAsync(userRecord.Email)

                        ' Optional: Display the link (for debugging purposes)
                        Console.WriteLine($"Verification link: {link}")

                        ' Send email using your SMTP setup
                        SendEmail(userRecord.Email, "Verify Your Email", $"Please verify your email using this link: {link}")
                        Dim reportTbl = client444.Set("ReportTbl/account/" & FirebaseModule.numericGuid, "Email verification sent to " + userRecord.Email)
                        reportTbl = client444.Set("ReportTbl/account/" & FirebaseModule.numericGuid & "/Date", FirebaseModule.today + " " + FirebaseModule.nowTime)
                        Dim notifiactionTbl = client444.Set($"NotificationTbl/{uid}/" & FirebaseModule.numericGuid & "/id", FirebaseModule.numericGuid)
                        notifiactionTbl = client444.Set($"NotificationTbl/{uid}/" & FirebaseModule.numericGuid & "/message", "Verification link has been sent to your email " + DateTime.Now)
                        notifiactionTbl = client444.Set($"NotificationTbl/{uid}/" & FirebaseModule.numericGuid & "/title", "Email Verification")
                        MessageBox.Show($"Verification email sent to {userRecord.Email}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show($"An error occurred while sending the Firebase verification email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    ' Proceed to RFID registration
                    Dim account_info As New add_employee
                    account_info.user_uid = uid
                    account_info.received_name = nametextbox.Text + " " + TextBox1.Text
                    account_info.received_email = email
                    account_info.add_employee_id = employee_id_textbox.Text
                    account_info.Show()
                    Me.Hide()
                    ClearFields() ' Call a separate method to clear fields

                Else
                    ' Handle account creation failure
                    Dim errorJson = Await response.Content.ReadAsStringAsync()
                    Dim errorData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(errorJson)
                    MessageBox.Show("Error: " & errorData("error")("message").ToString())
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try

            Return
        End If
    End Sub


    Private Sub ClearFields()
        emailtextbox.Clear()
        passwordtextbox.Clear()
        confirmpasswordtextbox.Clear()
        nametextbox.Clear()
        employee_id_textbox.Clear() ' Also clear employee ID textbox
    End Sub

    Private Sub nametextbox_TextChanged(sender As Object, e As EventArgs) Handles nametextbox.TextChanged

    End Sub

    Private Sub emailtextbox_TextChanged(sender As Object, e As EventArgs) Handles emailtextbox.TextChanged

        ' Check if the input matches the required email pattern
        If System.Text.RegularExpressions.Regex.IsMatch(emailtextbox.Text, emailPattern) Then
            Label8.Visible = False
        Else
            Label8.Text = "Email must be in the format: username@pnm.edu.ph"
            Label8.ForeColor = Color.Maroon
            Label8.Visible = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox3.Checked = True Then
            confirmpasswordtextbox.PasswordChar = ""
        Else
            confirmpasswordtextbox.PasswordChar = "*"
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            passwordtextbox.PasswordChar = ""
        Else
            passwordtextbox.PasswordChar = "*"
        End If
    End Sub

    Private Sub passwordtextbox_TextChanged(sender As Object, e As EventArgs) Handles passwordtextbox.TextChanged

        If System.Text.RegularExpressions.Regex.IsMatch(passwordtextbox.Text, inputPattern) Then
            Label6.Visible = False
        Else
            Label6.Text = "Password must contain Number, Capslock and Special Characters."
            Label6.ForeColor = Color.Maroon
            Label6.Visible = True
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        Employee_Dashboard.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class
