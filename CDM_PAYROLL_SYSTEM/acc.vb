Imports System.Data
Imports System.Collections.Generic
Imports FireSharp.Response
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports Firebase
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.IO
Imports System.Net.Http
Imports System.Security.Cryptography
Imports Firebase.Auth.Providers
Imports System.Threading.Tasks
Imports System
Imports System.Windows.Forms
Imports System.Diagnostics
Imports FirebaseAdmin
Imports System.Reflection
Imports Google.Apis.Auth.OAuth2
Imports System.Net
Imports System.Net.Mail
Imports DocumentFormat.OpenXml.Bibliography

Public Class acc

    Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

    Private Sub acc_load(sender As Object, e As EventArgs) Handles MyBase.Load

        loademployeedata()
        'TextBox4.Text = "Scan your rfid_tag"
        DGVuserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub
    Private Sub acc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    ' load users from firebase into datagridview

    Public Async Function GetAllUserUIDs() As Task(Of List(Of String))
        Dim uids As New List(Of String)

        Try
            ' Get data from usersTbl
            Dim response As FirebaseResponse = Await client.GetAsync("usersTbl")
            Dim data As JObject = JObject.Parse(response.Body)

            ' Loop through each UID in usersTbl
            For Each item In data.Properties()
                uids.Add(item.Name)  ' Add each UID to the list
            Next
        Catch ex As Exception
            MessageBox.Show("Error retrieving UIDs: " & ex.Message)
        End Try

        Return uids
    End Function


    Sub loademployeedata(Optional keyword As String = "")
        Try
            Dim srrecord = client.Get("usersTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(srrecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                MessageBox.Show("No employee data! Please add an employee", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Update each PersonalData object to include the UID
            For Each kvp As KeyValuePair(Of String, PersonalData) In employees
                kvp.Value.UID = kvp.Key
            Next

            ' Filter employees to exclude those with a null or empty UID
            Dim employeelist As List(Of PersonalData) = employees.Values.
            Where(Function(emp) Not String.IsNullOrEmpty(emp.UID) AndAlso Not String.IsNullOrEmpty(emp.employeeID)).
            ToList()

            ' Clear and set up DataGridView columns
            DGVuserData.DataSource = Nothing
            DGVuserData.Columns.Clear()
            DGVuserData.AutoGenerateColumns = False

            ' Add columns to DataGridView, including UID
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "employeeID", .HeaderText = "Employee ID", .Name = "employeeID"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email", .Name = "email"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "firstName", .HeaderText = "First Name", .Name = "firstName"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "lastName", .HeaderText = "Last Name", .Name = "lastName"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "password", .HeaderText = "Password", .Name = "password"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "rfidTag", .HeaderText = "RFID Tag", .Name = "rfidTag"})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "Info", .Name = "editButton", .Text = "View", .UseColumnTextForButtonValue = True})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "Password", .Name = "resetpassword", .Text = "Reset", .UseColumnTextForButtonValue = True})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "RFID", .Name = "rfid_register.dgv", .Text = "Register", .UseColumnTextForButtonValue = True})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "Email", .Name = "verification", .Text = "Verify", .UseColumnTextForButtonValue = True})

            ' Set DataGridView styles
            DGVuserData.EnableHeadersVisualStyles = False
            DGVuserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
            DGVuserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVuserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVuserData.ColumnHeadersHeight = 40 ' Increase header height
            DGVuserData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVuserData.DefaultCellStyle.Font = New Font("Roboto", 12)
            DGVuserData.ColumnHeadersDefaultCellStyle.Font = New Font("Roboto", 8, FontStyle.Regular)
            DGVuserData.RowTemplate.Height = 40
            DGVuserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGVuserData.BorderStyle = BorderStyle.None
            DGVuserData.BackgroundColor = Color.White
            DGVuserData.GridColor = Color.White
            DGVuserData.RowHeadersVisible = False
            DGVuserData.EnableHeadersVisualStyles = False
            DGVuserData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            DGVuserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVuserData.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            DGVuserData.DefaultCellStyle.SelectionForeColor = Color.Black
            DGVuserData.DataSource = employeelist
            DGVuserData.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' event handlers
    Private Sub label1_click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Main_Dashboard.Show()
    End Sub

    Private Sub label2_click(sender As Object, e As EventArgs) Handles Label2.Click
        List_of_Employees.Show()
        Me.Hide()
    End Sub

    Private Sub label5_click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        payroll_dashboard.Show()
    End Sub

    Private Sub iconbutton1_click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Me.Hide()
        Main_Dashboard.Show()
    End Sub

    Private Sub iconbutton2_click(sender As Object, e As EventArgs) Handles IconButton2.Click
        loademployeedata()
        'TextBox4.Clear()

        'TextBox4.Text = "Scan your rfid_tag"
    End Sub

    'Public Function verifypassword(plainpassword As String, hashedpassword As String) As Boolean
    '    Dim hashedinputpassword As String = TextBox4.Text(plainpassword)
    '    Return hashedinputpassword.Equals(hashedpassword)
    'End Function

    Private Function safegetstring(value As Object) As String
        ' returns an empty string if the value is dbnull or null
        Return If(value Is Nothing OrElse IsDBNull(value), String.Empty, value.ToString())
    End Function

    Private Sub iconbutton4_click(sender As Object, e As EventArgs) Handles IconButton4.Click
        If DGVuserData.SelectedRows.Count = 1 Then
            Dim result As DialogResult = MessageBox.Show("Do you want to force change email or password?", "BRUTE FORCE EDIT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If result = DialogResult.Yes Then
                ' Get the selected row (index 0, since there is only one selected row)
                Dim selectedRow As DataGridViewRow = DGVuserData.SelectedRows(0)
                Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
                Dim password As String = selectedRow.Cells("password").Value.ToString()
                Dim email As String = selectedRow.Cells("email").Value.ToString()

                Dim force_change As New brute_foce_password
                force_change.password = password
                force_change.received_email = email
                force_change.user_uid = selectedUID
                force_change.Show()
            Else
            End If
        Else
            MessageBox.Show("No row selected", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Async Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        If DGVuserData.SelectedRows.Count = 1 Then
            ' Ask for confirmation before deleting
            Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If result = DialogResult.Yes Then
                ' Get the selected row (index 0, since there is only one selected row)
                Dim selectedRow As DataGridViewRow = DGVuserData.SelectedRows(0)
                Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
                Dim employeeID As String = selectedRow.Cells("employeeID").Value.ToString()

                ' Delete the data from Firebase (based on UID)
                Dim numericGuid As String = New String(Guid.NewGuid().ToString().Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 8)
                client.Delete("usersTbl/" & selectedUID)
                client.Delete("EmployeeDataTbl/" & selectedUID)
                client.Set("ReportTbl/account/" & numericGuid + "/" & "Message/", "Account deletion for employee ID: " + employeeID)
                client.Set("ReportTbl/account/" & numericGuid + "/" & "Date/", DateTime.Now)

                If String.IsNullOrEmpty(selectedUID) Then
                    MessageBox.Show("No valid UID found for the selected user. Cannot delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Try
                    ' Delete the user from Firebase Database (assuming you have a client to do this)
                    client.Delete("usersTbl/" & selectedUID)

                    ' Get the path to the user's AppData folder
                    Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

                    ' Combine the AppData path with your app's folder and the credential file name
                    Dim credentialPath As String = Path.Combine(appDataPath, "CDM_PAYROLL_SYSTEM", "cdm-payroll-system-firebase-adminsdk-9mm0e-ccf4eb02cc.json")

                    ' Check if FirebaseApp instance exists; use DefaultInstance if available
                    Dim app As FirebaseApp
                    If FirebaseApp.DefaultInstance Is Nothing Then
                        ' Check if the credential file exists
                        If File.Exists(credentialPath) Then
                            ' Create FirebaseApp using the credential file
                            app = FirebaseApp.Create(New AppOptions() With {
                    .Credential = GoogleCredential.FromFile(credentialPath)
                })
                        Else
                            ' Handle the case where the file doesn't exist
                            MessageBox.Show("Credential file not found at: " & credentialPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    Else
                        ' Use the existing FirebaseApp instance
                        app = FirebaseApp.DefaultInstance
                    End If

                    ' Get FirebaseAuth instance using the specific FirebaseApp
                    Dim auth As FirebaseAuth = FirebaseAuth.GetAuth(app)

                    ' Use Await for the async call to delete the user
                    Await auth.DeleteUserAsync(selectedUID)

                    ' Inform the user that the deletion was successful
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show($"An error occurred while deleting the user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Textbox4_Enter(sender As Object, e As EventArgs)
        'TextBox4.Text = ""
    End Sub
    Private Sub InitializeFirebaseApp()
        Try
            ' Get the directory where the executable is located (the application directory)
            Dim appDirectory As String = Application.StartupPath

            ' Combine it with the relative path to the credential file
            Dim credentialPath As String = Path.Combine(appDirectory, "cdm-payroll-system-firebase-adminsdk-9mm0e-ccf4eb02cc.json")

            ' Check if the credential file exists
            If File.Exists(credentialPath) Then
                ' Set the environment variable
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath)

                ' Initialize Firebase using the credentials file
                If FirebaseApp.DefaultInstance Is Nothing Then
                    FirebaseApp.Create(New AppOptions() With {
                    .Credential = GoogleCredential.FromFile(credentialPath)
                })
                End If
            Else
                ' Show an error message if the file is not found
                MessageBox.Show("Credential file not found at the specified path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Firebase initialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Async Sub DGVuserData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVuserData.CellContentClick

        If e.RowIndex >= 0 AndAlso (e.ColumnIndex = DGVuserData.Columns("rfid_register.dgv").Index OrElse e.ColumnIndex = DGVuserData.Columns("editButton").Index OrElse e.ColumnIndex = DGVuserData.Columns("verification").Index OrElse e.ColumnIndex = DGVuserData.Columns("resetpassword").Index) Then
            ' Retrieve the data from the clicked row
            Dim uid As String = DGVuserData.Rows(e.RowIndex).Cells("UID").Value.ToString()
            Dim selectedRow As DataGridViewRow = DGVuserData.Rows(e.RowIndex)

            If e.ColumnIndex = DGVuserData.Columns("rfid_register.dgv").Index Then
                ' RFID Register button clicked
                Dim rfidForm As New register_rfid()
                Dim userData As String = selectedRow.Cells("employeeID").Value.ToString
                rfidForm.UserUID = uid ' Set the UID property
                rfidForm.add_employee_id = userData
                rfidForm.Show()

            ElseIf e.ColumnIndex = DGVuserData.Columns("editButton").Index Then

                Dim userData As String = selectedRow.Cells("employeeID").Value.ToString() ' Replace "UserDataColumnName" with the actual column name
                Dim email_received As String = selectedRow.Cells("email").Value.ToString()
                Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
                Dim name_received As String = selectedRow.Cells("firstName").Value.ToString() + " " + selectedRow.Cells("lastName").Value.ToString()
                Dim add_employee_info As New add_employee
                add_employee_info.received_name = name_received
                add_employee_info.add_employee_id = userData
                add_employee_info.received_email = email_received
                add_employee_info.user_uid = selectedUID
                add_employee_info.Show()

            ElseIf e.ColumnIndex = DGVuserData.Columns("verification").Index Then
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
                    Dim reportTbl = client.Set("ReportTbl/account/" & FirebaseModule.numericGuid & "/message", "Email verification sent to " + userRecord.Email)
                    reportTbl = client.Set("ReportTbl/" & "account/" & FirebaseModule.numericGuid & "/Date", FirebaseModule.today + " " + FirebaseModule.nowTime)
                    Dim notifiactionTbl = client.Set($"NotificationTbl/{uid}/" & FirebaseModule.numericGuid & "/id", FirebaseModule.numericGuid)
                    notifiactionTbl = client.Set($"NotificationTbl/{uid}/" & FirebaseModule.numericGuid & "/message", "Verification link has been sent to your email " + DateTime.Now)
                    notifiactionTbl = client.Set($"NotificationTbl/{uid}/" & FirebaseModule.numericGuid & "/title", "Email Verification")
                    MessageBox.Show($"Verification email sent to {userRecord.Email}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show($"An error occurred while sending the verification email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf e.ColumnIndex = DGVuserData.Columns("resetpassword").Index Then
                Try
                    ' Retrieve user data and email from the selected row
                    Dim userData As String = selectedRow.Cells("employeeID").Value.ToString() ' Replace with actual column name
                    Dim emailReceived As String = selectedRow.Cells("email").Value.ToString()

                    ' Initialize Firebase App
                    InitializeFirebaseApp()

                    ' Fetch user details from Firebase
                    Dim userRecord As UserRecord = Await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(emailReceived)

                    ' Check if email is verified
                    If userRecord.EmailVerified Then
                        ' Proceed with password reset
                        SendPasswordResetEmail(emailReceived)
                        Dim reportTbl = client.Set("ReportTbl/account/" & FirebaseModule.numericGuid & "/message", "Reset password link has been sent to " + emailReceived)
                        reportTbl = client.Set("ReportTbl/account/" & FirebaseModule.numericGuid & "/Date", FirebaseModule.today + " " + FirebaseModule.nowTime)
                    Else
                        ' Show message box for unverified email
                        MessageBox.Show($"The email '{emailReceived}' is not verified. Please verify the email before resetting the password.", "Email Not Verified", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Catch ex As Exception
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
    Private Sub AddChangePasswordButton()
        If Not DGVuserData.Columns.Contains("changePassword") Then
            Dim changePasswordButton As New DataGridViewButtonColumn()
            changePasswordButton.Name = "changePassword"
            changePasswordButton.HeaderText = "Change Password"
            changePasswordButton.Text = "Change"
            changePasswordButton.UseColumnTextForButtonValue = True
            DGVuserData.Columns.Add(changePasswordButton)
        End If
    End Sub
    Public Async Function ChangeUserPassword(uid As String, newPassword As String) As Task
        Try
            ' Ensure Firebase is initialized
            InitializeFirebaseApp()

            ' Update user's password
            Dim updatedUser = Await FirebaseAuth.DefaultInstance.UpdateUserAsync(New UserRecordArgs() With {
                .Uid = uid,
                .Password = newPassword
            })

            MessageBox.Show($"Password for user {updatedUser.Uid} updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error updating password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Async Sub SendPasswordResetEmail(toEmail As String)
        Try
            ' Initialize Firebase App if not already initialized
            InitializeFirebaseApp()

            ' Generate the password reset link for the provided email

            Dim resetLink As String = Await FirebaseAuth.DefaultInstance.GeneratePasswordResetLinkAsync(toEmail)

            ' Send the reset link via SMTP email
            Dim subject As String = "Password Reset Request"
            Dim body As String = $"Hello,<br><br>Click the link below to reset your password:<br>" &
                             $"<a href='{resetLink}'>{resetLink}</a><br><br>Thank you."

            ' Call the SendEmail method to send the email
            SendEmail(toEmail, subject, body)

            MessageBox.Show("Password reset email sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As FirebaseAdmin.Auth.FirebaseAuthException When ex.AuthErrorCode = FirebaseAdmin.Auth.AuthErrorCode.UserNotFound
            MessageBox.Show($"The email address '{toEmail}' is not associated with an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Hide()
        register_rfid.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim selectedRow = DGVuserData.CurrentRow
        If selectedRow IsNot Nothing Then
            Dim selectedUID = selectedRow.Cells("UID").Value.ToString ' Get the UID from the selected row

            ' Pass the UID to register_rfid
            Dim rfidForm As New register_rfid
            rfidForm.UserUID = selectedUID ' Set the UID property
            rfidForm.Show()
            ' Optionally hide the current form
        Else
            MessageBox.Show("Please select a row to continue.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        RFID_Based_Attendance.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        Dim keyword As String = TextBox5.Text.Trim()
        loademployeedata(keyword)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        ' Check if data is already loaded
        If DGVuserData.DataSource Is Nothing Then Return

        ' Get the search text and remove leading/trailing spaces
        Dim searchText As String = TextBox5.Text.Trim().ToLower()

        ' Cast the DataSource back to a list of PersonalData
        Dim employeeList As List(Of PersonalData) = TryCast(DGVuserData.DataSource, List(Of PersonalData))
        If employeeList Is Nothing Then Return

        ' Check if searchText is empty
        If String.IsNullOrEmpty(searchText) Then
            ' If empty, show all records
            DGVuserData.DataSource = Nothing
            DGVuserData.DataSource = employeeList
        Else
            ' If not empty, filter the data based on search text
            Dim filteredList = employeeList.Where(Function(emp) _
            emp.employeeID.ToLower().Contains(searchText) OrElse
            emp.email.ToLower().Contains(searchText) OrElse
            emp.firstName.ToLower().Contains(searchText)
        ).ToList()

            ' Update the DataGridView with the filtered list
            DGVuserData.DataSource = Nothing
            DGVuserData.DataSource = filteredList
        End If
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Hide()
        reports.Show()
    End Sub

    Private Sub DGVuserData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVuserData.CellFormatting
        If DGVuserData.Columns(e.ColumnIndex).Name = "password" AndAlso e.Value IsNot Nothing Then
            ' Replace the actual value with masked characters
            e.Value = New String("•"c, e.Value.ToString().Length)
            e.FormattingApplied = True
        End If
    End Sub


    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
