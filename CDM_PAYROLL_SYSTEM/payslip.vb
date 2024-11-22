Imports System.Drawing.Printing
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Newtonsoft.Json
Imports System.IO
Imports Firebase.Storage
Imports FireSharp.Config
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf



Public Class payslip
    Public Property received_email As String
    Public Property user_uid As String
    Public Property add_employee_id As String
    Public Property received_name As String
    Public Property description As String
    Public Property designation As String
    Public Property no_ofUnits As String
    Public Property pag_ibig_no As String
    Public Property tax_code As String
    Public Property sss_no As String
    Public Property phil_health_no As String
    Public Property position123 As String
    Public Property date_hired As String
    Public Sub SetImage(image As Image)
        PictureBox9.Image = image
    End Sub

    Private Sub payroll_dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to True
        If Not IsExiting Then
            Dim result As DialogResult = MessageBox.Show("Do you want to back?", "Cancel Payroll", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                payroll.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub payslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If TextBox1.Text = Nothing OrElse TextBox2.Text = Nothing OrElse TextBox3.Text = Nothing OrElse TextBox4.Text = Nothing Then
        '    Button4.Enabled = False
        'Else
        '    Button4.Enabled = True
        'End If
        position_to_textbox.Text = position123
        Label33.Text = add_employee_id
        Label34.Text = received_name
        noUnits.Text = no_ofUnits
        TextBox3.Text = no_ofUnits
        designation_to_textbox.Text = designation
        Label41.Text = description
        Label40.Text = date_hired

        If position_to_textbox.Text = "Head" Then
            TextBox7.Text = "650"
        ElseIf position_to_textbox.Text = "Assistant Head" Then
            TextBox7.Text = "550"
        ElseIf position_to_textbox.Text = "Admin" Then
            TextBox7.Text = "400"
        Else
            TextBox7.Text = "0"
        End If

        If designation_to_textbox.Text = "Instructor non-Licensed" Then
            TextBox2.Text = "260"
        ElseIf designation_to_textbox.Text = "Instructor Licensed" Then
            TextBox2.Text = "310"
        ElseIf designation_to_textbox.Text = "Assistant Professor I" Then
            TextBox2.Text = "360"
        ElseIf designation_to_textbox.Text = "Assistant Professor II" Then
            TextBox2.Text = "410"
        ElseIf designation_to_textbox.Text = "Professor" Then
            TextBox2.Text = "885"
        End If

    End Sub
    Private Async Function UploadPdfToFirebase(filePath As String, fileName As String) As Task(Of String)
        Try
            Dim storage = New FirebaseStorage("gs://cdm-payroll-system.appspot.com")
            Dim fileStream As FileStream = New FileStream(filePath, FileMode.Open)
            Dim uploadTask = Await storage.Child("payslips").Child(fileName).PutAsync(fileStream)
            Return Await storage.Child("payslips").Child(fileName).GetDownloadUrlAsync()
        Catch ex As Exception
            MessageBox.Show($"Error uploading PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Private Sub PrintDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        Dim logo As Image = Image.FromFile("C:\Users\Zedrick\Documents\Visual Basic\CDM_PAYROLL_SYSTEM\CDM_PAYROLL_SYSTEM\images\logo.jpg")
        Dim logo2 As Image = Image.FromFile("C:\Users\Zedrick\Documents\Visual Basic\CDM_PAYROLL_SYSTEM\CDM_PAYROLL_SYSTEM\images\bayan_logo.jpg")
        ' Set the location and size for the logo
        Dim logoX As Integer = 50  ' Horizontal position
        Dim logoY As Integer = 25  ' Vertical position
        Dim logoWidth As Integer = 50  ' Width of the logo
        Dim logoHeight As Integer = 50  ' Height of the logo

        ' Draw the logo on the document at a fixed position
        e.Graphics.DrawImage(logo, 380, logoY, logoWidth, logoHeight)
        e.Graphics.DrawImage(logo2, 660, logoY, logoWidth, logoHeight)

        Dim fontTitle As New Font("Roboto", 14, FontStyle.Bold)
        Dim fontContent As New Font("Arial", 9, FontStyle.Regular)
        Dim fontsmall As New Font("Arial_rounded", 8, FontStyle.Regular)
        Dim brush As Brush = Brushes.Black
        Dim pen As New Pen(Color.Black, 1.5)
        Dim pen2 As New Pen(Color.Black, 3)

        ' Define starting positions and line height
        ' Define starting positions and line height
        Dim startX1 As Integer = 20 ' Start position for the first column
        Dim startX2 As Integer = 550 ' Start position for the second column
        Dim startY As Integer = 50 ' Start position for rows
        Dim lineHeight As Integer = 30 ' Space between rows

        ' Fonts for different parts of the text
        Dim fontLabel As New Font("Arial", 10, FontStyle.Bold) ' Font for labels (e.g., "Employee ID:")

        ' Text for employee info (First Column)
        Dim text1 As String = "Employee ID: "
        Dim text2 As String = "Name: "
        Dim text3 As String = "Email: "
        Dim text4 As String = "Date: "

        ' Measure the size of the label text (for optional alignment purposes)
        Dim text1Size As SizeF = e.Graphics.MeasureString(text1, fontLabel)
        Dim text2Size As SizeF = e.Graphics.MeasureString(text2, fontLabel)
        Dim text3Size As SizeF = e.Graphics.MeasureString(text3, fontLabel)
        Dim text4Size As SizeF = e.Graphics.MeasureString(text4, fontLabel)

        ' Text for employee info (Second Column)
        Dim text5 As String = "Position: "
        Dim text6 As String = "Description: "
        Dim text7 As String = "Designation: "
        Dim text8 As String = "Date Hired: "

        ' Measure the size of the label text (for optional alignment purposes)
        Dim text5Size As SizeF = e.Graphics.MeasureString(text5, fontLabel)
        Dim text6Size As SizeF = e.Graphics.MeasureString(text6, fontLabel)
        Dim text7Size As SizeF = e.Graphics.MeasureString(text7, fontLabel)
        Dim text8Size As SizeF = e.Graphics.MeasureString(text8, fontLabel)


        ' Company Title
        Dim titleText As String = "Colegio De Montalban"
        e.Graphics.DrawString(titleText, fontTitle, brush, (e.PageBounds.Width - e.Graphics.MeasureString(titleText, fontTitle).Width) / 2, 35)
        e.Graphics.DrawString("Kasiglahan Village, Rodriguez Rizal", fontsmall, brush, (e.PageBounds.Width - e.Graphics.MeasureString("Kasiglahan Village, Rodriguez Rizal", fontTitle).Width) / 1.7, 60)

        ' Adjust startY for the next section (move down after the title)
        startY += lineHeight ' Adding some space after the title

        ' Second text: "Payslip for the Period..."
        Dim payslipText As String = "Payslip for the Period October 20, 2024 - November 2, 2024 (Pay-out: " + DateTime.Now + ")"
        e.Graphics.DrawString(payslipText, fontsmall, brush, (e.PageBounds.Width - e.Graphics.MeasureString(payslipText, fontContent).Width) / 1.8, startY)

        ' Measure the size of the "Payslip" text to calculate the line position
        Dim textSize As SizeF = e.Graphics.MeasureString(payslipText, fontContent)

        ' Draw a solid line below the payslip text
        Dim lineStartY As Single = startY + textSize.Height + 10 ' Adjust the 10 to make the line closer to the text
        e.Graphics.DrawLine(pen2, 1, lineStartY, e.PageBounds.Width - 1, lineStartY)

        ' Adjust startY for employee information section (below the border line)
        startY = lineStartY + 10 ' Move 10 pixels below the line

        ' Draw text for the first column
        e.Graphics.DrawString(text1, fontLabel, Brushes.Black, startX1, startY)
        e.Graphics.DrawString(add_employee_id, fontContent, Brushes.Black, startX1 + text1Size.Width, startY) ' Add content with different font

        e.Graphics.DrawString(text2, fontLabel, Brushes.Black, startX1, startY + lineHeight)
        e.Graphics.DrawString(received_name, fontContent, Brushes.Black, startX1 + text2Size.Width, startY + lineHeight)

        e.Graphics.DrawString(text3, fontLabel, Brushes.Black, startX1, startY + 2 * lineHeight)
        e.Graphics.DrawString(received_email, fontContent, Brushes.Black, startX1 + text3Size.Width, startY + 2 * lineHeight)

        e.Graphics.DrawString(text4, fontLabel, Brushes.Black, startX1, startY + 3 * lineHeight)
        e.Graphics.DrawString(Date.Now, fontContent, Brushes.Black, startX1 + text4Size.Width, startY + 3 * lineHeight)

        ' Draw text for the second column
        e.Graphics.DrawString(text5, fontLabel, Brushes.Black, startX2, startY)
        e.Graphics.DrawString(position123, fontContent, Brushes.Black, startX2 + text5Size.Width, startY) ' Add content with different font

        e.Graphics.DrawString(text6, fontLabel, Brushes.Black, startX2, startY + lineHeight)
        e.Graphics.DrawString(description, fontContent, Brushes.Black, startX2 + text6Size.Width, startY + lineHeight)

        e.Graphics.DrawString(text7, fontLabel, Brushes.Black, startX2, startY + 2 * lineHeight)
        e.Graphics.DrawString(designation, fontContent, Brushes.Black, startX2 + text7Size.Width, startY + 2 * lineHeight)

        e.Graphics.DrawString(text8, fontLabel, Brushes.Black, startX2, startY + 3 * lineHeight)
        e.Graphics.DrawString(date_hired, fontContent, Brushes.Black, startX2 + text8Size.Width, startY + 3 * lineHeight)

        ' Adjust the starting position for the table
        startY += 125 ' Add extra space for the table header

        ' Define table headers and column widths
        Dim headers() As String = {"EARNINGS", "DEDUCTIONS"}
        Dim columnWidths() As Single = {540, 540} ' Adjust column widths as needed

        ' Calculate the total table width
        Dim totalTableWidth As Single = columnWidths.Sum()

        ' Calculate the starting X position for the table to be centered
        Dim tableStartX As Single = (e.PageBounds.Width - totalTableWidth) / 2

        ' Draw a border around the table (rectangle)
        e.Graphics.DrawRectangle(pen, tableStartX - 1, startY - 1, totalTableWidth + 2, (lineHeight * 8) + 1) ' Adjust total height to accommodate new header

        ' Draw the main headers with black background
        Dim headerHeight As Single = 25
        Dim headerTextY As Single = startY + (headerHeight - e.Graphics.MeasureString(headers(0), fontContent).Height) / 2
        Dim blackBrush As New SolidBrush(Color.Black)
        Dim whiteBrush As New SolidBrush(Color.White)

        For i As Integer = 0 To headers.Length - 1
            Dim headerSize As SizeF = e.Graphics.MeasureString(headers(i), fontContent)
            Dim headerX As Single = tableStartX + columnWidths.Take(i).Sum() + (columnWidths(i) - headerSize.Width) / 2
            Dim cellX As Single = tableStartX + columnWidths.Take(i).Sum()

            ' Fill main header background with black
            e.Graphics.FillRectangle(blackBrush, cellX, startY, columnWidths(i), headerHeight)
            ' Draw the white text centered in the main header
            e.Graphics.DrawString(headers(i), fontContent, whiteBrush, headerX, headerTextY)
        Next

        ' Move down to draw the "Description" row with reduced height
        Dim descriptionHeight As Single = lineHeight * 0.5 ' Adjusted height
        startY += headerHeight

        ' Draw the "Description" row with gray background, aligning text to the left
        Dim grayBrush As New SolidBrush(Color.Gray)
        Dim descriptionTextY As Single = startY + (descriptionHeight - e.Graphics.MeasureString("Details", fontContent).Height) / 2

        For i As Integer = 0 To headers.Length - 1
            Dim cellX As Single = tableStartX + columnWidths.Take(i).Sum()
            ' Fill the description header background with gray
            e.Graphics.FillRectangle(grayBrush, cellX, startY, columnWidths(i), descriptionHeight)

            ' Draw the "Description" text aligned to the left within the new row
            Dim descriptionX As Single = cellX + 5 ' Left-aligned with padding
            e.Graphics.DrawString("Details", fontContent, whiteBrush, descriptionX, descriptionTextY)
        Next
        startY -= 5
        ' Define sample data for earnings and deductions
        ' Extend the earnings and deductions data arrays to include two additional rows.
        Dim earnings As String() = {"Work hours:", "Rate per Unit:", "Rate per hour:", "Rate per day:", "Total no. of units:", "Base Earnings:", "", ""}
        Dim deductions As String() = {"Late time in:", "Absences:", "Other Deductions:", "Total Deductions:", "", ""}
        Dim earningsAmounts As String() = {TextBox4.Text, TextBox2.Text, Label17.Text, Label11.Text, TextBox3.Text, TextBox6.Text, "", ""} ' Add values for the new rows
        Dim deductionsAmounts As String() = {"", "", "", "", "", "", "", ""} ' Add values for the new rows

        ' Update row count to reflect the new rows.
        Dim rowCount As Integer = Math.Min(earnings.Length, deductions.Length) ' Now includes two more rows

        ' Draw the table rows with actual data
        startY += lineHeight ' Move to the next line after the headers

        ' Loop through the data dynamically based on the updated row count
        For i As Integer = 0 To rowCount - 1
            ' Draw earnings text
            e.Graphics.DrawString(earnings(i), fontContent, brush, tableStartX + 10, startY)
            e.Graphics.DrawString(earningsAmounts(i), fontContent, brush, tableStartX + 10 + columnWidths(0) / 2, startY) ' Center amount within the earnings column

            ' Draw deductions text
            e.Graphics.DrawString(deductions(i), fontContent, brush, tableStartX + 10 + columnWidths(0), startY) ' Move to the second column
            e.Graphics.DrawString(deductionsAmounts(i), fontContent, brush, tableStartX + 10 + columnWidths(0) + columnWidths(1) / 2, startY) ' Center amount within the deductions column

            ' Move to the next row position
            startY += lineHeight
        Next

        ' Draw the vertical divider line for the first table
        Dim columnDividerX As Single = tableStartX + columnWidths(0)
        Dim tableTopY As Single = startY - (lineHeight * 6 + 25)
        Dim tableHeight As Single = 35 + (lineHeight * rowCount)
        e.Graphics.DrawLine(pen, columnDividerX, tableTopY, columnDividerX, tableTopY + tableHeight)

        ' Move startY down to create space for the second table (if needed)
        startY += 20
        ' Draw the "NET EARNINGS" label with DarkSeaGreen background
        Dim netEarningsLabel As String = "NET EARNINGS: " + "99999"
        Dim netEarningsHeight As Single = lineHeight * 1.5 ' You can adjust this value for the desired height
        Dim netEarningsTextY As Single = startY + (netEarningsHeight - e.Graphics.MeasureString(netEarningsLabel, fontContent).Height) / 2 ' Centering the text vertically

        ' Set the background color for NET EARNINGS
        Dim darkSeaGreenBrush As New SolidBrush(Color.DarkSeaGreen)

        ' Fill the background for the "NET EARNINGS" row
        e.Graphics.FillRectangle(darkSeaGreenBrush, tableStartX, startY, totalTableWidth, netEarningsHeight)

        ' Draw the "NET EARNINGS" text aligned right to left (right aligned)
        e.Graphics.DrawString(netEarningsLabel, fontContent, Brushes.White, tableStartX + totalTableWidth - e.Graphics.MeasureString(netEarningsLabel, fontContent).Width, netEarningsTextY)

        ' Move startY down to create space for any subsequent content (if needed)
        startY += netEarningsHeight

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'TextBox1.Enabled = Not TextBox1.Enabled
        'TextBox2.Enabled = Not TextBox2.Enabled
        'TextBox3.Enabled = Not TextBox3.Enabled
        'TextBox4.Enabled = Not TextBox4.Enabled
        'TextBox5.Enabled = Not TextBox5.Enabled
        'TextBox6.Enabled = Not TextBox6.Enabled
        'TextBox7.Enabled = Not TextBox7.Enabled
        'TextBox8.Enabled = Not TextBox8.Enabled
        'Button4.Enabled = Not Button4.Enabled
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
            String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
            String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
            String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
            String.IsNullOrWhiteSpace(TextBox7.Text) Then
            MessageBox.Show("Complete the payroll process to save!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim rateperunit As Integer = Integer.Parse(TextBox2.Text)
            Dim totalunits_calc As Integer = Integer.Parse(TextBox3.Text)
            Dim etl As Integer = Integer.Parse(TextBox7.Text)
            Dim totalworkhours = Integer.Parse(TextBox4.Text)
            Dim perda_calc = ((rateperunit * totalunits_calc * 28) / 24) / 7
            Dim perhour_calc = (rateperunit * totalunits_calc) / 40
            Dim permin_calc = perhour_calc / 60
            Dim etl_calc = (((rateperunit * totalunits_calc * 28) / 24) / 7) + etl
            Dim every15days = ((((rateperunit * totalunits_calc * 28) / 24) / 7) + etl) * 15

            Label11.Text = "₱" & etl_calc.ToString("N2")
            Label17.Text = "₱" & perhour_calc.ToString("N2")
            Label18.Text = "₱" & permin_calc.ToString("N2")
            TextBox6.Text = "₱" & every15days.ToString("N2")
            Button2.Enabled = True
            Button1.Enabled = True
            Button2.BackColor = Color.DarkSeaGreen
            Button1.BackColor = Color.DarkSeaGreen

        End If

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles position_to_textbox.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label11.Text = "-" OrElse
            Label17.Text = "-" OrElse
            Label18.Text = "-" OrElse
            String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox6.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox7.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox8.Text) Then
            MessageBox.Show("Complete the payroll process to save!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim customSize As New PaperSize("CustomSize", 600, 1100) ' Width and height in hundredths of an inch
            printDoc.DefaultPageSettings.PaperSize = customSize
            PrintPreviewDialog1.Document = printDoc
            printDoc.DefaultPageSettings.Landscape = True
            PrintPreviewDialog1.ShowDialog()
        End If

    End Sub
    Public Property get_pey_period_hehe As String
    Public Property no As String
    Public Property agaga As String
    Public Property pogiako As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()
        ' Validate the input fields to ensure they are not empty or whitespace
        If String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox6.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox8.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox7.Text) Then
            MessageBox.Show("Complete the payroll process to save!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' Assuming get_pey_period_hehe contains the pay period string, e.g., "November 16-30 2024"
            Dim get_pey_period_hehe As String = "November 16-30 2024" ' Replace with your actual value

            ' Split the get_pey_period_hehe string into parts
            Dim parts As String() = get_pey_period_hehe.Split(" "c)

            If parts.Length = 3 Then
                ' Extract month, day range, and year from the split string
                Dim monthName As String = parts(0) ' "November"
                Dim daysRange As String = parts(1) ' "16-30"
                Dim year As Integer = Integer.Parse(parts(2)) ' "2024"

                ' Get the numeric month from the month name (e.g., "November" -> 11)
                Dim month As Integer = DateTime.ParseExact(monthName, "MMMM", Globalization.CultureInfo.InvariantCulture).Month

                ' Extract the start and end days from the day range
                Dim dayParts As String() = daysRange.Split("-"c)
                If dayParts.Length = 2 Then
                    Dim startDay As Integer = Integer.Parse(dayParts(0)) ' 16
                    Dim endDay As Integer = Integer.Parse(dayParts(1)) ' 30

                    ' Generate the start and end dates in the desired format (yyyy-MM-dd)
                    Dim startDate As New DateTime(year, month, startDay)
                    Dim endDate As New DateTime(year, month, endDay)

                    ' Now, generate the mapping of unique IDs to dates
                    Dim payPeriod As New Dictionary(Of String, String)()

                    ' Loop through the date range using a While loop (since DateTime doesn't support direct For loop)
                    Dim currentDate As DateTime = startDate
                    While currentDate <= endDate
                        Dim uniqueId As String = New Random().Next(1000000, 9999999).ToString() ' Generate a random 7-digit unique ID
                        payPeriod(uniqueId) = currentDate.ToString("yyyy-MM-dd")
                        currentDate = currentDate.AddDays(1) ' Increment the date by one day
                    End While

                    Dim PD As New PersonalData.Payslip With {
                        .PayslipID = numericGuid123,
                        .TotalDeduction = TextBox8.Text,
                        .TotalHours = TextBox4.Text,
                        .TotalSalary = TextBox1.Text,
                        .TotalYear = "1",
                    .PayOutDate = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
            }
                    ' Now save the result to Firebase

                    Dim script_for_payslip = "Your payslip for " + get_pey_period_hehe + " is now available"
                    Dim numericGuid As String = New String(Guid.NewGuid().ToString().Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 8)
                    ' Save the PayslipID under the user_uid
                    Dim savePayslipID = client.Set("EmployeePayrollDataTbl/" & user_uid & "/PayslipID/PayslipID", PD.PayslipID)
                    Dim payoutperiod = client.Set("EmployeePayrollDataTbl/" & user_uid & "/PayOutPeriod/PayOutPeriod", PD.PayOutDate)
                    Dim payslipreports = client.Set("ReportTbl/payslip/" & numericGuid, "Sucessfully payslip distribution to employee ID: " + add_employee_id)

                    ' Save the other payroll data under the user_uid
                    Dim saveTotalDeduction = client.Set("EmployeePayrollDataTbl/" & user_uid & "/TotalDeduction/total_deduction", PD.TotalDeduction)
                    Dim saveTotalHours = client.Set("EmployeePayrollDataTbl/" & user_uid & "/TotalHours/total_hours", PD.TotalHours)
                    Dim saveTotalSalary = client.Set("EmployeePayrollDataTbl/" & user_uid & "/TotalSalary/total_salary", PD.TotalSalary)
                    Dim saveTotalYear = client.Set("EmployeePayrollDataTbl/" & user_uid & "/TotalYear/total_year", PD.TotalYear)

                    Dim save2 = client.Set("NotificationTbl/" & user_uid & "/" & numericGuid & "/id", numericGuid)
                    save2 = client.Set("NotificationTbl/" & user_uid & "/" & numericGuid & "/message", script_for_payslip)
                    save2 = client.Set("NotificationTbl/" & user_uid & "/" & numericGuid & "/title", "Payslip")

                    MessageBox.Show("Data Saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Invalid day range format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid pay period format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    ' Helper function to generate a unique ID
    Dim numericGuid123 As String = New String(Guid.NewGuid().ToString("N").Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 9)

    ' Helper function to generate the JSON string from the pay period dictionary
    Private Function GenerateJsonString(payPeriod As Dictionary(Of String, String)) As String
        Dim jsonOutput As String = "{"
        For Each kvp In payPeriod
            jsonOutput &= String.Format("""{0}"": ""{1}"", ", kvp.Key, kvp.Value)
        Next
        ' Remove the last comma and add closing brace
        jsonOutput = jsonOutput.TrimEnd(New Char() {","c}) & "}"
        Return jsonOutput
    End Function


End Class