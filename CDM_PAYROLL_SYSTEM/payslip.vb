Imports System.Drawing.Printing

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
    Public Property position As String
    Public Property date_hired As String
    Public Sub SetImage(image As Image)
        PictureBox9.Image = image
    End Sub

    Private Sub payslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label33.Text = add_employee_id
        Label34.Text = received_name
        Label35.Text = position
        Label36.Text = no_ofUnits
        Label37.Text = designation
        Label41.Text = description
        Label40.Text = date_hired
    End Sub
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
        Dim fontContent As New Font("Roboto", 10, FontStyle.Regular)
        Dim fontsmall As New Font("Arial_rounded", 8, FontStyle.Regular)
        Dim brush As Brush = Brushes.Black
        Dim pen As New Pen(Color.Black, 2)

        ' Define starting positions and line height
        Dim startX As Integer = 50
        Dim startY As Integer = 50
        Dim lineHeight As Integer = 30

        ' Text for employee info
        Dim text1 As String = "Employee ID: " + add_employee_id
        Dim text2 As String = "Name: " + received_name
        Dim text3 As String = "Designation: " + designation

        ' Measure the size of the text
        Dim text1Size As SizeF = e.Graphics.MeasureString(text1, fontContent)
        Dim text2Size As SizeF = e.Graphics.MeasureString(text2, fontContent)
        Dim text3Size As SizeF = e.Graphics.MeasureString(text3, fontContent)

        ' Calculate total width and positioning for employee information
        Dim totalWidth As Single = text1Size.Width + text2Size.Width + text3Size.Width
        Dim startAs3letters As Single = (e.PageBounds.Width - totalWidth) / 2

        ' Company Title
        Dim titleText As String = "Colegio De Montalban"
        e.Graphics.DrawString(titleText, fontTitle, brush, (e.PageBounds.Width - e.Graphics.MeasureString(titleText, fontTitle).Width) / 2, 35)
        e.Graphics.DrawString("Kasiglahan Village, Rodriguez Rizal", fontsmall, brush, (e.PageBounds.Width - e.Graphics.MeasureString("Kasiglahan Village, Rodriguez Rizal", fontTitle).Width) / 1.7, 60)

        ' Adjust startY for the next section (move down after the title)
        startY += lineHeight ' Adding some space after the title

        ' Second text: "Payslip for the Period..."
        Dim payslipText As String = "Payslip for the Period October 20, 2024 - November 2, 2024 (Pay-out: November 8, 2024)"
        e.Graphics.DrawString(payslipText, fontsmall, brush, (e.PageBounds.Width - e.Graphics.MeasureString(payslipText, fontContent).Width) / 1.6, startY)

        ' Measure the size of the "Payslip" text to calculate the line position
        Dim textSize As SizeF = e.Graphics.MeasureString(payslipText, fontContent)

        ' Draw a solid line below the payslip text
        Dim lineStartY As Single = startY + textSize.Height + 10 ' Adjust the 10 to make the line closer to the text
        e.Graphics.DrawLine(pen, 1, lineStartY, e.PageBounds.Width - 1, lineStartY)

        ' Adjust startY for employee information section (below the border line)
        startY = lineStartY + 10 ' Move 10 pixels below the line

        ' Employee Information
        e.Graphics.DrawString(text1, fontContent, brush, startX, startY)

        ' Draw the second text (in the middle space)
        e.Graphics.DrawString(text2, fontContent, brush, startX + text1Size.Width + (e.PageBounds.Width - totalWidth) / 3, startY)

        ' Draw the third text (centered in the last space)
        e.Graphics.DrawString(text3, fontContent, brush, startX + text1Size.Width + text2Size.Width + 2 * (e.PageBounds.Width - totalWidth) / 3, startY)

        ' Continue with other content
        startY += lineHeight
        e.Graphics.DrawString("Date:", fontContent, brush, startX, startY)

        ' Add the new text in one line
        startY += lineHeight ' Add some space between employee info and the new line

        ' Text for Tax Code, SSS No., Phil Health No., Pag-ibig
        Dim text4 As String = "Tax Code: " + tax_code
        Dim text5 As String = "SSS No. " + sss_no
        Dim text6 As String = "Phil Health No. " + phil_health_no
        Dim text7 As String = "Pag-ibig: " + pag_ibig_no

        ' Measure the text sizes
        Dim text4Size As SizeF = e.Graphics.MeasureString(text4, fontContent)
        Dim text5Size As SizeF = e.Graphics.MeasureString(text5, fontContent)
        Dim text6Size As SizeF = e.Graphics.MeasureString(text6, fontContent)
        Dim text7Size As SizeF = e.Graphics.MeasureString(text7, fontContent)

        e.Graphics.DrawLine(pen, 1, lineStartY, e.PageBounds.Width - 1, lineStartY)
        ' Calculate the total width of all four texts
        Dim total4TextWidth As Single = text4Size.Width + text5Size.Width + text6Size.Width + text7Size.Width

        ' Calculate the starting X position for the first text
        Dim startXFor4Texts As Single = (e.PageBounds.Width - total4TextWidth) / 2

        ' Draw the four texts with even spacing
        e.Graphics.DrawString(text4, fontContent, brush, startX, startY)
        e.Graphics.DrawString(text5, fontContent, brush, 1 + text4Size.Width + (e.PageBounds.Width - totalWidth) / 4, startY)
        e.Graphics.DrawString(text6, fontContent, brush, startX + text5Size.Width + text4Size.Width + 1.5 * (e.PageBounds.Width - totalWidth) / 4, startY)
        e.Graphics.DrawString(text7, fontContent, brush, startX + text6Size.Width + text5Size.Width + text5Size.Width + 2.5 * (e.PageBounds.Width - totalWidth) / 4, startY)

        ' Adjust the starting position for the table
        startY += lineHeight ' Add extra space for the table header

        ' Define table headers and column widths
        Dim headers() As String = {"EARNINGS", "DEDUCTIONS"}
        Dim columnWidths() As Single = {500, 500} ' Adjust column widths as needed

        ' Calculate the total table width
        Dim totalTableWidth As Single = columnWidths.Sum()

        ' Calculate the starting X position for the table to be centered
        Dim tableStartX As Single = (e.PageBounds.Width - totalTableWidth) / 2

        ' Draw a border around the table (rectangle)
        e.Graphics.DrawRectangle(pen, tableStartX - 1, startY - 1, totalTableWidth + 2, (lineHeight * 8) + 1) ' Adjust total height to accommodate new header

        ' Draw the main headers with black background
        Dim headerHeight As Single = lineHeight
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
        Dim descriptionTextY As Single = startY + (descriptionHeight - e.Graphics.MeasureString("Description", fontContent).Height) / 2

        For i As Integer = 0 To headers.Length - 1
            Dim cellX As Single = tableStartX + columnWidths.Take(i).Sum()
            ' Fill the description header background with gray
            e.Graphics.FillRectangle(grayBrush, cellX, startY, columnWidths(i), descriptionHeight)

            ' Draw the "Description" text aligned to the left within the new row
            Dim descriptionX As Single = cellX + 5 ' Left-aligned with padding
            e.Graphics.DrawString("Description", fontContent, whiteBrush, descriptionX, descriptionTextY)
        Next
        startY = 235
        ' Define sample data for earnings and deductions
        ' Extend the earnings and deductions data arrays to include two additional rows.
        Dim earnings As String() = {"Work hours:", "Rate per Unit:", "Rate per hour:", "Rate per day:", "Total no. of units:", "Base Earnings:", "", ""}
        Dim deductions As String() = {"Late time in:", "Absences:", "Other Deductions:", "Total Deductions:", "", ""}
        Dim earningsAmounts As String() = {"", "", "", "", "", "", "", ""} ' Add values for the new rows
        Dim deductionsAmounts As String() = {"", "", "", "", "", "", "", ""} ' Add values for the new rows

        ' Update row count to reflect the new rows.
        Dim rowCount As Integer = Math.Min(earnings.Length, deductions.Length) ' Now includes two more rows

        ' Draw the table rows with actual data
        startY += lineHeight ' Move to the next line after the headers

        ' Loop through the data dynamically based on the updated row count
        For i As Integer = 0 To rowCount - 1
            ' Draw earnings text
            e.Graphics.DrawString(earnings(i), fontContent, brush, tableStartX, startY)
            e.Graphics.DrawString(earningsAmounts(i), fontContent, brush, tableStartX + columnWidths(0) / 2, startY) ' Center amount within the earnings column

            ' Draw deductions text
            e.Graphics.DrawString(deductions(i), fontContent, brush, tableStartX + columnWidths(0), startY) ' Move to the second column
            e.Graphics.DrawString(deductionsAmounts(i), fontContent, brush, tableStartX + columnWidths(0) + columnWidths(1) / 2, startY) ' Center amount within the deductions column

            ' Move to the next row position
            startY += lineHeight
        Next

        ' Draw the vertical divider line for the first table
        Dim columnDividerX As Single = tableStartX + columnWidths(0)
        Dim tableTopY As Single = startY - (lineHeight * 6 + headerHeight)
        Dim tableHeight As Single = 32 + (lineHeight * rowCount)
        e.Graphics.DrawLine(pen, columnDividerX, tableTopY, columnDividerX, tableTopY + tableHeight)

        ' Move startY down to create space for the second table (if needed)
        startY += 8
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim customSize As New PaperSize("CustomSize", 600, 1100) ' Width and height in hundredths of an inch
        printDoc.DefaultPageSettings.PaperSize = customSize
        PrintPreviewDialog1.Document = printDoc
        printDoc.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Enabled = Not TextBox1.Enabled
        TextBox2.Enabled = Not TextBox2.Enabled
        TextBox3.Enabled = Not TextBox3.Enabled
        TextBox4.Enabled = Not TextBox4.Enabled
        TextBox5.Enabled = Not TextBox5.Enabled
        TextBox6.Enabled = Not TextBox6.Enabled
    End Sub
End Class