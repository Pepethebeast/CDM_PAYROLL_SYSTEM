<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class payslip
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payslip))
        TableLayoutPanel7 = New TableLayoutPanel()
        Button4 = New Button()
        Button3 = New Button()
        Panel7 = New Panel()
        Button1 = New Button()
        TableLayoutPanel6 = New TableLayoutPanel()
        Label24 = New Label()
        TextBox6 = New TextBox()
        Label36 = New Label()
        TextBox8 = New TextBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        TextBox7 = New TextBox()
        Label2 = New Label()
        Label25 = New Label()
        TextBox5 = New TextBox()
        TextBox2 = New TextBox()
        Label26 = New Label()
        Label30 = New Label()
        TextBox3 = New TextBox()
        Label32 = New Label()
        TextBox4 = New TextBox()
        Label23 = New Label()
        Label22 = New Label()
        Panel4 = New Panel()
        TableLayoutPanel5 = New TableLayoutPanel()
        Label7 = New Label()
        PictureBox9 = New PictureBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        position_to_textbox = New Label()
        Label29 = New Label()
        Label40 = New Label()
        Label41 = New Label()
        Label10 = New Label()
        Label13 = New Label()
        designation_to_textbox = New Label()
        noUnits = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label34 = New Label()
        Label12 = New Label()
        Label33 = New Label()
        Label16 = New Label()
        GroupBox4 = New GroupBox()
        PictureBox11 = New PictureBox()
        Label4 = New Label()
        PictureBox4 = New PictureBox()
        printDoc = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        Panel1 = New Panel()
        TableLayoutPanel4 = New TableLayoutPanel()
        Label1 = New Label()
        Label5 = New Label()
        Label19 = New Label()
        Label20 = New Label()
        Label21 = New Label()
        Label27 = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        Label18 = New Label()
        Label17 = New Label()
        Label11 = New Label()
        Label6 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label3 = New Label()
        TableLayoutPanel7.SuspendLayout()
        Panel7.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel4.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        CType(PictureBox9, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        GroupBox4.SuspendLayout()
        CType(PictureBox11, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel7
        ' 
        TableLayoutPanel7.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel7.ColumnCount = 2
        TableLayoutPanel7.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3336029F))
        TableLayoutPanel7.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33362F))
        TableLayoutPanel7.Controls.Add(Button4, 1, 0)
        TableLayoutPanel7.Controls.Add(Button3, 0, 0)
        TableLayoutPanel7.Location = New Point(522, 194)
        TableLayoutPanel7.Name = "TableLayoutPanel7"
        TableLayoutPanel7.RowCount = 1
        TableLayoutPanel7.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel7.Size = New Size(267, 50)
        TableLayoutPanel7.TabIndex = 50
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.DarkSeaGreen
        Button4.Location = New Point(136, 4)
        Button4.Name = "Button4"
        Button4.Size = New Size(125, 42)
        Button4.TabIndex = 49
        Button4.Text = "Calculate"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.DarkSeaGreen
        Button3.Location = New Point(4, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(125, 42)
        Button3.TabIndex = 48
        Button3.Text = "Verify Time Records"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = SystemColors.Window
        Panel7.BorderStyle = BorderStyle.FixedSingle
        Panel7.Controls.Add(Button1)
        Panel7.Controls.Add(TableLayoutPanel7)
        Panel7.Controls.Add(TableLayoutPanel6)
        Panel7.Controls.Add(TableLayoutPanel1)
        Panel7.Controls.Add(Label23)
        Panel7.Controls.Add(Label22)
        Panel7.Location = New Point(310, 68)
        Panel7.Margin = New Padding(4, 3, 4, 3)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(849, 352)
        Panel7.TabIndex = 38
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkSeaGreen
        Button1.Location = New Point(522, 261)
        Button1.Name = "Button1"
        Button1.Size = New Size(267, 42)
        Button1.TabIndex = 51
        Button1.Text = "PRINT PAY SLIP"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 2
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
        TableLayoutPanel6.Controls.Add(Label24, 0, 0)
        TableLayoutPanel6.Controls.Add(TextBox6, 1, 0)
        TableLayoutPanel6.Controls.Add(Label36, 0, 1)
        TableLayoutPanel6.Controls.Add(TextBox8, 1, 1)
        TableLayoutPanel6.Location = New Point(451, 73)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 2
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0006237F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0006237F))
        TableLayoutPanel6.Size = New Size(374, 104)
        TableLayoutPanel6.TabIndex = 47
        ' 
        ' Label24
        ' 
        Label24.Anchor = AnchorStyles.None
        Label24.AutoSize = True
        Label24.BackColor = Color.Transparent
        Label24.Cursor = Cursors.Hand
        Label24.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label24.ForeColor = SystemColors.ActiveCaptionText
        Label24.Location = New Point(26, 17)
        Label24.Margin = New Padding(4, 0, 4, 0)
        Label24.Name = "Label24"
        Label24.Size = New Size(97, 18)
        Label24.TabIndex = 49
        Label24.Text = "Base Salary:"
        ' 
        ' TextBox6
        ' 
        TextBox6.Anchor = AnchorStyles.None
        TextBox6.Location = New Point(152, 14)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(219, 23)
        TextBox6.TabIndex = 57
        TextBox6.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label36
        ' 
        Label36.Anchor = AnchorStyles.None
        Label36.AutoSize = True
        Label36.BackColor = Color.Transparent
        Label36.Cursor = Cursors.Hand
        Label36.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label36.ForeColor = SystemColors.ActiveCaptionText
        Label36.Location = New Point(33, 69)
        Label36.Margin = New Padding(4, 0, 4, 0)
        Label36.Name = "Label36"
        Label36.Size = New Size(83, 18)
        Label36.TabIndex = 55
        Label36.Text = "Deduction:"
        ' 
        ' TextBox8
        ' 
        TextBox8.Anchor = AnchorStyles.None
        TextBox8.Location = New Point(152, 66)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(219, 23)
        TextBox8.TabIndex = 58
        TextBox8.TextAlign = HorizontalAlignment.Center
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
        TableLayoutPanel1.Controls.Add(TextBox7, 1, 0)
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(Label25, 0, 1)
        TableLayoutPanel1.Controls.Add(TextBox5, 1, 4)
        TableLayoutPanel1.Controls.Add(TextBox2, 1, 1)
        TableLayoutPanel1.Controls.Add(Label26, 0, 2)
        TableLayoutPanel1.Controls.Add(Label30, 0, 4)
        TableLayoutPanel1.Controls.Add(TextBox3, 1, 2)
        TableLayoutPanel1.Controls.Add(Label32, 0, 3)
        TableLayoutPanel1.Controls.Add(TextBox4, 1, 3)
        TableLayoutPanel1.Location = New Point(33, 73)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 5
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.Size = New Size(399, 259)
        TableLayoutPanel1.TabIndex = 46
        ' 
        ' TextBox7
        ' 
        TextBox7.Anchor = AnchorStyles.None
        TextBox7.Location = New Point(162, 14)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(234, 23)
        TextBox7.TabIndex = 51
        TextBox7.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Cursor = Cursors.Hand
        Label2.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(35, 16)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 18)
        Label2.TabIndex = 50
        Label2.Text = "Fixed Rate:"
        ' 
        ' Label25
        ' 
        Label25.Anchor = AnchorStyles.None
        Label25.AutoSize = True
        Label25.BackColor = Color.Transparent
        Label25.Cursor = Cursors.Hand
        Label25.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label25.ForeColor = SystemColors.ActiveCaptionText
        Label25.Location = New Point(31, 67)
        Label25.Margin = New Padding(4, 0, 4, 0)
        Label25.Name = "Label25"
        Label25.Size = New Size(96, 18)
        Label25.TabIndex = 45
        Label25.Text = "Rate per unit"
        ' 
        ' TextBox5
        ' 
        TextBox5.Anchor = AnchorStyles.None
        TextBox5.Location = New Point(162, 220)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(234, 23)
        TextBox5.TabIndex = 56
        TextBox5.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(162, 65)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(234, 23)
        TextBox2.TabIndex = 47
        TextBox2.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label26
        ' 
        Label26.Anchor = AnchorStyles.None
        Label26.AutoSize = True
        Label26.BackColor = Color.Transparent
        Label26.Cursor = Cursors.Hand
        Label26.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label26.ForeColor = SystemColors.ActiveCaptionText
        Label26.Location = New Point(20, 118)
        Label26.Margin = New Padding(4, 0, 4, 0)
        Label26.Name = "Label26"
        Label26.Size = New Size(118, 18)
        Label26.TabIndex = 47
        Label26.Text = "Total no. of units"
        ' 
        ' Label30
        ' 
        Label30.Anchor = AnchorStyles.None
        Label30.AutoSize = True
        Label30.BackColor = Color.Transparent
        Label30.Cursor = Cursors.Hand
        Label30.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label30.ForeColor = SystemColors.ActiveCaptionText
        Label30.Location = New Point(29, 222)
        Label30.Margin = New Padding(4, 0, 4, 0)
        Label30.Name = "Label30"
        Label30.Size = New Size(101, 18)
        Label30.TabIndex = 51
        Label30.Text = "Missed Time:"
        ' 
        ' TextBox3
        ' 
        TextBox3.Anchor = AnchorStyles.None
        TextBox3.Location = New Point(162, 116)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(234, 23)
        TextBox3.TabIndex = 48
        TextBox3.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label32
        ' 
        Label32.Anchor = AnchorStyles.None
        Label32.AutoSize = True
        Label32.BackColor = Color.Transparent
        Label32.Cursor = Cursors.Hand
        Label32.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label32.ForeColor = SystemColors.ActiveCaptionText
        Label32.Location = New Point(18, 169)
        Label32.Margin = New Padding(4, 0, 4, 0)
        Label32.Name = "Label32"
        Label32.Size = New Size(123, 18)
        Label32.TabIndex = 53
        Label32.Text = "Total work hours:"
        ' 
        ' TextBox4
        ' 
        TextBox4.Anchor = AnchorStyles.None
        TextBox4.Location = New Point(162, 167)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(234, 23)
        TextBox4.TabIndex = 49
        TextBox4.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.BackColor = Color.Transparent
        Label23.Cursor = Cursors.Hand
        Label23.Font = New Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label23.ForeColor = Color.Maroon
        Label23.Location = New Point(33, 47)
        Label23.Margin = New Padding(4, 0, 4, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(231, 16)
        Label23.TabIndex = 30
        Label23.Text = "Breakdown of earnings and deductions"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.BackColor = Color.Transparent
        Label22.Cursor = Cursors.Hand
        Label22.Font = New Font("Arial", 14.25F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label22.Location = New Point(33, 19)
        Label22.Margin = New Padding(4, 0, 4, 0)
        Label22.Name = "Label22"
        Label22.Size = New Size(207, 23)
        Label22.TabIndex = 28
        Label22.Text = "Earnings Calculation"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(TableLayoutPanel5)
        Panel4.Controls.Add(TableLayoutPanel2)
        Panel4.Location = New Point(7, 68)
        Panel4.Margin = New Padding(4, 3, 4, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(295, 586)
        Panel4.TabIndex = 35
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 1
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel5.Controls.Add(Label7, 0, 0)
        TableLayoutPanel5.Controls.Add(PictureBox9, 0, 1)
        TableLayoutPanel5.Location = New Point(3, 3)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 2
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 80.0F))
        TableLayoutPanel5.Size = New Size(291, 201)
        TableLayoutPanel5.TabIndex = 51
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Cursor = Cursors.Hand
        Label7.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(67, 8)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(157, 23)
        Label7.TabIndex = 28
        Label7.Text = "Employee Details"
        ' 
        ' PictureBox9
        ' 
        PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), Image)
        PictureBox9.Location = New Point(4, 43)
        PictureBox9.Margin = New Padding(4, 3, 4, 3)
        PictureBox9.Name = "PictureBox9"
        PictureBox9.Size = New Size(283, 152)
        PictureBox9.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox9.TabIndex = 0
        PictureBox9.TabStop = False
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.BackColor = Color.White
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel2.Controls.Add(position_to_textbox, 1, 2)
        TableLayoutPanel2.Controls.Add(Label29, 0, 2)
        TableLayoutPanel2.Controls.Add(Label40, 1, 6)
        TableLayoutPanel2.Controls.Add(Label41, 1, 5)
        TableLayoutPanel2.Controls.Add(Label10, 0, 0)
        TableLayoutPanel2.Controls.Add(Label13, 0, 1)
        TableLayoutPanel2.Controls.Add(designation_to_textbox, 1, 4)
        TableLayoutPanel2.Controls.Add(noUnits, 1, 3)
        TableLayoutPanel2.Controls.Add(Label14, 0, 3)
        TableLayoutPanel2.Controls.Add(Label15, 0, 4)
        TableLayoutPanel2.Controls.Add(Label34, 1, 1)
        TableLayoutPanel2.Controls.Add(Label12, 0, 5)
        TableLayoutPanel2.Controls.Add(Label33, 1, 0)
        TableLayoutPanel2.Controls.Add(Label16, 0, 6)
        TableLayoutPanel2.Location = New Point(2, 212)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 7
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel2.Size = New Size(287, 277)
        TableLayoutPanel2.TabIndex = 46
        ' 
        ' position_to_textbox
        ' 
        position_to_textbox.Anchor = AnchorStyles.None
        position_to_textbox.AutoSize = True
        position_to_textbox.BackColor = Color.Transparent
        position_to_textbox.Cursor = Cursors.Hand
        position_to_textbox.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        position_to_textbox.ForeColor = SystemColors.ActiveCaptionText
        position_to_textbox.Location = New Point(180, 88)
        position_to_textbox.Margin = New Padding(4, 0, 4, 0)
        position_to_textbox.Name = "position_to_textbox"
        position_to_textbox.Size = New Size(69, 18)
        position_to_textbox.TabIndex = 45
        position_to_textbox.Text = "Position:"
        ' 
        ' Label29
        ' 
        Label29.Anchor = AnchorStyles.None
        Label29.AutoSize = True
        Label29.BackColor = Color.Transparent
        Label29.Cursor = Cursors.Hand
        Label29.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label29.ForeColor = SystemColors.ActiveCaptionText
        Label29.Location = New Point(32, 88)
        Label29.Margin = New Padding(4, 0, 4, 0)
        Label29.Name = "Label29"
        Label29.Size = New Size(78, 19)
        Label29.TabIndex = 44
        Label29.Text = "Position:"
        ' 
        ' Label40
        ' 
        Label40.Anchor = AnchorStyles.None
        Label40.AutoSize = True
        Label40.BackColor = Color.Transparent
        Label40.Cursor = Cursors.Hand
        Label40.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label40.ForeColor = SystemColors.ActiveCaptionText
        Label40.Location = New Point(168, 246)
        Label40.Margin = New Padding(4, 0, 4, 0)
        Label40.Name = "Label40"
        Label40.Size = New Size(93, 18)
        Label40.TabIndex = 42
        Label40.Text = "Alden Nayre"
        ' 
        ' Label41
        ' 
        Label41.Anchor = AnchorStyles.None
        Label41.AutoSize = True
        Label41.BackColor = Color.Transparent
        Label41.Cursor = Cursors.Hand
        Label41.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label41.ForeColor = SystemColors.ActiveCaptionText
        Label41.Location = New Point(168, 205)
        Label41.Margin = New Padding(4, 0, 4, 0)
        Label41.Name = "Label41"
        Label41.Size = New Size(93, 18)
        Label41.TabIndex = 43
        Label41.Text = "Alden Nayre"
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.None
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Cursor = Cursors.Hand
        Label10.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label10.ForeColor = SystemColors.ActiveCaptionText
        Label10.Location = New Point(16, 10)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(111, 19)
        Label10.TabIndex = 29
        Label10.Text = "Employee ID:"
        ' 
        ' Label13
        ' 
        Label13.Anchor = AnchorStyles.None
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Cursor = Cursors.Hand
        Label13.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label13.ForeColor = SystemColors.ActiveCaptionText
        Label13.Location = New Point(42, 49)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(59, 19)
        Label13.TabIndex = 32
        Label13.Text = "Name:"
        ' 
        ' designation_to_textbox
        ' 
        designation_to_textbox.Anchor = AnchorStyles.None
        designation_to_textbox.AutoSize = True
        designation_to_textbox.BackColor = Color.Transparent
        designation_to_textbox.Cursor = Cursors.Hand
        designation_to_textbox.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        designation_to_textbox.ForeColor = SystemColors.ActiveCaptionText
        designation_to_textbox.Location = New Point(168, 166)
        designation_to_textbox.Margin = New Padding(4, 0, 4, 0)
        designation_to_textbox.Name = "designation_to_textbox"
        designation_to_textbox.Size = New Size(93, 18)
        designation_to_textbox.TabIndex = 41
        designation_to_textbox.Text = "Alden Nayre"
        ' 
        ' noUnits
        ' 
        noUnits.Anchor = AnchorStyles.None
        noUnits.AutoSize = True
        noUnits.BackColor = Color.Transparent
        noUnits.Cursor = Cursors.Hand
        noUnits.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        noUnits.ForeColor = SystemColors.ActiveCaptionText
        noUnits.Location = New Point(168, 127)
        noUnits.Margin = New Padding(4, 0, 4, 0)
        noUnits.Name = "noUnits"
        noUnits.Size = New Size(93, 18)
        noUnits.TabIndex = 40
        noUnits.Text = "Alden Nayre"
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Cursor = Cursors.Hand
        Label14.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label14.ForeColor = SystemColors.ActiveCaptionText
        Label14.Location = New Point(19, 127)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(104, 19)
        Label14.TabIndex = 33
        Label14.Text = "No. of Units:"
        ' 
        ' Label15
        ' 
        Label15.Anchor = AnchorStyles.None
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Cursor = Cursors.Hand
        Label15.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label15.ForeColor = SystemColors.ActiveCaptionText
        Label15.Location = New Point(18, 166)
        Label15.Margin = New Padding(4, 0, 4, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(107, 19)
        Label15.TabIndex = 34
        Label15.Text = "Designation:"
        ' 
        ' Label34
        ' 
        Label34.Anchor = AnchorStyles.None
        Label34.AutoSize = True
        Label34.BackColor = Color.Transparent
        Label34.Cursor = Cursors.Hand
        Label34.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label34.ForeColor = SystemColors.ActiveCaptionText
        Label34.Location = New Point(202, 49)
        Label34.Margin = New Padding(4, 0, 4, 0)
        Label34.Name = "Label34"
        Label34.Size = New Size(26, 18)
        Label34.TabIndex = 38
        Label34.Text = "16"
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.None
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Cursor = Cursors.Hand
        Label12.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label12.ForeColor = SystemColors.ActiveCaptionText
        Label12.Location = New Point(20, 205)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(103, 19)
        Label12.TabIndex = 35
        Label12.Text = "Description:"
        ' 
        ' Label33
        ' 
        Label33.Anchor = AnchorStyles.None
        Label33.AutoSize = True
        Label33.BackColor = Color.Transparent
        Label33.Cursor = Cursors.Hand
        Label33.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label33.ForeColor = SystemColors.ActiveCaptionText
        Label33.Location = New Point(168, 10)
        Label33.Margin = New Padding(4, 0, 4, 0)
        Label33.Name = "Label33"
        Label33.Size = New Size(93, 18)
        Label33.TabIndex = 37
        Label33.Text = "Alden Nayre"
        ' 
        ' Label16
        ' 
        Label16.Anchor = AnchorStyles.None
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Cursor = Cursors.Hand
        Label16.Font = New Font("Arial", 12.0F, FontStyle.Bold)
        Label16.ForeColor = SystemColors.ActiveCaptionText
        Label16.Location = New Point(24, 246)
        Label16.Margin = New Padding(4, 0, 4, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(95, 19)
        Label16.TabIndex = 36
        Label16.Text = "Date Hired:"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.BackColor = Color.DarkSeaGreen
        GroupBox4.Controls.Add(PictureBox11)
        GroupBox4.Controls.Add(Label4)
        GroupBox4.Controls.Add(PictureBox4)
        GroupBox4.Location = New Point(3, 2)
        GroupBox4.Margin = New Padding(4, 3, 4, 3)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(4, 3, 4, 3)
        GroupBox4.Size = New Size(1163, 62)
        GroupBox4.TabIndex = 41
        GroupBox4.TabStop = False
        ' 
        ' PictureBox11
        ' 
        PictureBox11.BackColor = Color.Transparent
        PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), Image)
        PictureBox11.Location = New Point(1029, 3)
        PictureBox11.Margin = New Padding(4, 3, 4, 3)
        PictureBox11.Name = "PictureBox11"
        PictureBox11.Size = New Size(68, 59)
        PictureBox11.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox11.TabIndex = 21
        PictureBox11.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Cursor = Cursors.Hand
        Label4.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(19, 19)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(285, 22)
        Label4.TabIndex = 20
        Label4.Text = "Employee Payroll Calculations"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(1094, 3)
        PictureBox4.Margin = New Padding(4, 3, 4, 3)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(69, 59)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 19
        PictureBox4.TabStop = False
        ' 
        ' printDoc
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(TableLayoutPanel4)
        Panel1.Controls.Add(TableLayoutPanel3)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(310, 426)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(849, 228)
        Panel1.TabIndex = 42
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel4.ColumnCount = 2
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
        TableLayoutPanel4.Controls.Add(Label1, 1, 2)
        TableLayoutPanel4.Controls.Add(Label5, 1, 1)
        TableLayoutPanel4.Controls.Add(Label19, 1, 0)
        TableLayoutPanel4.Controls.Add(Label20, 0, 0)
        TableLayoutPanel4.Controls.Add(Label21, 0, 1)
        TableLayoutPanel4.Controls.Add(Label27, 0, 2)
        TableLayoutPanel4.Location = New Point(419, 52)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 3
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel4.Size = New Size(340, 140)
        TableLayoutPanel4.TabIndex = 30
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Cursor = Cursors.Hand
        Label1.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(231, 107)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(13, 18)
        Label1.TabIndex = 55
        Label1.Text = "-"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Cursor = Cursors.Hand
        Label5.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.ActiveCaptionText
        Label5.Location = New Point(231, 60)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(13, 18)
        Label5.TabIndex = 54
        Label5.Text = "-"
        ' 
        ' Label19
        ' 
        Label19.Anchor = AnchorStyles.None
        Label19.AutoSize = True
        Label19.BackColor = Color.Transparent
        Label19.Cursor = Cursors.Hand
        Label19.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = SystemColors.ActiveCaptionText
        Label19.Location = New Point(231, 14)
        Label19.Margin = New Padding(4, 0, 4, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(13, 18)
        Label19.TabIndex = 53
        Label19.Text = "-"
        ' 
        ' Label20
        ' 
        Label20.Anchor = AnchorStyles.None
        Label20.AutoSize = True
        Label20.BackColor = Color.Transparent
        Label20.Cursor = Cursors.Hand
        Label20.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = SystemColors.ActiveCaptionText
        Label20.Location = New Point(35, 14)
        Label20.Margin = New Padding(4, 0, 4, 0)
        Label20.Name = "Label20"
        Label20.Size = New Size(66, 18)
        Label20.TabIndex = 50
        Label20.Text = "Per day:"
        ' 
        ' Label21
        ' 
        Label21.Anchor = AnchorStyles.None
        Label21.AutoSize = True
        Label21.BackColor = Color.Transparent
        Label21.Cursor = Cursors.Hand
        Label21.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label21.ForeColor = SystemColors.ActiveCaptionText
        Label21.Location = New Point(32, 60)
        Label21.Margin = New Padding(4, 0, 4, 0)
        Label21.Name = "Label21"
        Label21.Size = New Size(71, 18)
        Label21.TabIndex = 51
        Label21.Text = "Per hour:"
        ' 
        ' Label27
        ' 
        Label27.Anchor = AnchorStyles.None
        Label27.AutoSize = True
        Label27.BackColor = Color.Transparent
        Label27.Cursor = Cursors.Hand
        Label27.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label27.ForeColor = SystemColors.ActiveCaptionText
        Label27.Location = New Point(24, 107)
        Label27.Margin = New Padding(4, 0, 4, 0)
        Label27.Name = "Label27"
        Label27.Size = New Size(87, 18)
        Label27.TabIndex = 52
        Label27.Text = "Per minute:"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
        TableLayoutPanel3.Controls.Add(Label18, 1, 2)
        TableLayoutPanel3.Controls.Add(Label17, 1, 1)
        TableLayoutPanel3.Controls.Add(Label11, 1, 0)
        TableLayoutPanel3.Controls.Add(Label6, 0, 0)
        TableLayoutPanel3.Controls.Add(Label8, 0, 1)
        TableLayoutPanel3.Controls.Add(Label9, 0, 2)
        TableLayoutPanel3.Location = New Point(34, 52)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 3
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.Size = New Size(340, 140)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' Label18
        ' 
        Label18.Anchor = AnchorStyles.None
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Cursor = Cursors.Hand
        Label18.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = SystemColors.ActiveCaptionText
        Label18.Location = New Point(231, 107)
        Label18.Margin = New Padding(4, 0, 4, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(13, 18)
        Label18.TabIndex = 55
        Label18.Text = "-"
        ' 
        ' Label17
        ' 
        Label17.Anchor = AnchorStyles.None
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Cursor = Cursors.Hand
        Label17.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = SystemColors.ActiveCaptionText
        Label17.Location = New Point(231, 60)
        Label17.Margin = New Padding(4, 0, 4, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(13, 18)
        Label17.TabIndex = 54
        Label17.Text = "-"
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.None
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Cursor = Cursors.Hand
        Label11.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = SystemColors.ActiveCaptionText
        Label11.Location = New Point(231, 14)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(13, 18)
        Label11.TabIndex = 53
        Label11.Text = "-"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Cursor = Cursors.Hand
        Label6.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.ActiveCaptionText
        Label6.Location = New Point(35, 14)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(66, 18)
        Label6.TabIndex = 50
        Label6.Text = "Per day:"
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.None
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Cursor = Cursors.Hand
        Label8.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.ActiveCaptionText
        Label8.Location = New Point(32, 60)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(71, 18)
        Label8.TabIndex = 51
        Label8.Text = "Per hour:"
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.None
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Cursor = Cursors.Hand
        Label9.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.ActiveCaptionText
        Label9.Location = New Point(24, 107)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(87, 18)
        Label9.TabIndex = 52
        Label9.Text = "Per minute:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Cursor = Cursors.Hand
        Label3.Font = New Font("Arial", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(34, 24)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(280, 16)
        Label3.TabIndex = 29
        Label3.Text = "Calculation for Salary and Deduction Details"
        ' 
        ' payslip
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1166, 661)
        Controls.Add(Panel1)
        Controls.Add(GroupBox4)
        Controls.Add(Panel7)
        Controls.Add(Panel4)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(4, 3, 4, 3)
        Name = "payslip"
        StartPosition = FormStartPosition.CenterScreen
        Text = "payslip"
        TableLayoutPanel7.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel6.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        Panel4.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        CType(PictureBox9, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        CType(PictureBox11, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        ResumeLayout(False)

    End Sub
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label41 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents designation_to_textbox As Label
    Friend WithEvents noUnits As Label
    Friend WithEvents Position As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents printDoc As Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents position_to_textbox As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Button1 As Button
End Class
