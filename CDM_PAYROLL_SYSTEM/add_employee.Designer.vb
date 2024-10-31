<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_employee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_employee))
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        Label9 = New Label()
        Label8 = New Label()
        GroupBox3 = New GroupBox()
        Button2 = New Button()
        Button1 = New Button()
        email = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label7 = New Label()
        PictureBox4 = New PictureBox()
        Description = New TextBox()
        GroupBox4 = New GroupBox()
        Label23 = New Label()
        Label4 = New Label()
        CivilStatus = New ComboBox()
        Department = New ComboBox()
        NoUnits = New TextBox()
        Label27 = New Label()
        Designation = New TextBox()
        Label28 = New Label()
        Label26 = New Label()
        Position = New TextBox()
        Label25 = New Label()
        DateOfBirth = New DateTimePicker()
        Label19 = New Label()
        Contact = New TextBox()
        Label18 = New Label()
        Suffix = New ComboBox()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        Lname = New TextBox()
        Mname = New TextBox()
        Fname = New TextBox()
        Label12 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Panel1 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label31 = New Label()
        Label30 = New Label()
        Label29 = New Label()
        Label22 = New Label()
        Label21 = New Label()
        Label17 = New Label()
        Label20 = New Label()
        Label5 = New Label()
        Label1 = New Label()
        Label6 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PictureBox13 = New PictureBox()
        DateHired = New DateTimePicker()
        Label24 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(PictureBox13, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Controls.Add(GroupBox3)
        GroupBox1.Location = New Point(264, 4)
        GroupBox1.Margin = New Padding(4, 3, 4, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 3, 4, 3)
        GroupBox1.Size = New Size(1085, 733)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.DarkSeaGreen
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Location = New Point(-3, -3)
        GroupBox2.Margin = New Padding(4, 3, 4, 3)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 3, 4, 3)
        GroupBox2.Size = New Size(1082, 100)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BorderStyle = BorderStyle.FixedSingle
        Label9.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(21, 58)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(183, 26)
        Label9.TabIndex = 1
        Label9.Text = "Personal Information"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(21, 19)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(193, 25)
        Label8.TabIndex = 0
        Label8.Text = "Add New Employee"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = Color.White
        GroupBox3.Controls.Add(Button2)
        GroupBox3.Controls.Add(Button1)
        GroupBox3.Controls.Add(email)
        GroupBox3.Controls.Add(TableLayoutPanel1)
        GroupBox3.Controls.Add(Description)
        GroupBox3.Controls.Add(GroupBox4)
        GroupBox3.Controls.Add(Label4)
        GroupBox3.Controls.Add(CivilStatus)
        GroupBox3.Controls.Add(Department)
        GroupBox3.Controls.Add(DateHired)
        GroupBox3.Controls.Add(NoUnits)
        GroupBox3.Controls.Add(Label27)
        GroupBox3.Controls.Add(Designation)
        GroupBox3.Controls.Add(Label28)
        GroupBox3.Controls.Add(Label26)
        GroupBox3.Controls.Add(Label24)
        GroupBox3.Controls.Add(Position)
        GroupBox3.Controls.Add(Label25)
        GroupBox3.Controls.Add(DateOfBirth)
        GroupBox3.Controls.Add(Label19)
        GroupBox3.Controls.Add(Contact)
        GroupBox3.Controls.Add(Label18)
        GroupBox3.Controls.Add(Suffix)
        GroupBox3.Controls.Add(Label16)
        GroupBox3.Controls.Add(Label15)
        GroupBox3.Controls.Add(Label14)
        GroupBox3.Controls.Add(Lname)
        GroupBox3.Controls.Add(Mname)
        GroupBox3.Controls.Add(Fname)
        GroupBox3.Controls.Add(Label12)
        GroupBox3.Controls.Add(Label11)
        GroupBox3.Controls.Add(Label10)
        GroupBox3.Font = New Font("Roboto", 12F)
        GroupBox3.Location = New Point(3, 103)
        GroupBox3.Margin = New Padding(4, 3, 4, 3)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(4, 3, 4, 3)
        GroupBox3.Size = New Size(1076, 647)
        GroupBox3.TabIndex = 0
        GroupBox3.TabStop = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = Color.IndianRed
        Button2.Font = New Font("Roboto", 9F)
        Button2.ForeColor = SystemColors.ControlText
        Button2.Location = New Point(47, 507)
        Button2.Margin = New Padding(4, 3, 4, 3)
        Button2.Name = "Button2"
        Button2.Size = New Size(76, 42)
        Button2.TabIndex = 35
        Button2.Text = "BACK"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.Gold
        Button1.Font = New Font("Roboto", 9F)
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(131, 507)
        Button1.Margin = New Padding(4, 3, 4, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(76, 42)
        Button1.TabIndex = 35
        Button1.Text = "REGISTER"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' email
        ' 
        email.AutoSize = True
        email.Font = New Font("Microsoft Uighur", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        email.Location = New Point(827, 122)
        email.Margin = New Padding(4, 0, 4, 0)
        email.Name = "email"
        email.Size = New Size(219, 36)
        email.TabIndex = 46
        email.Text = "johnzedrick24@gmail.com"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(Label7, 0, 1)
        TableLayoutPanel1.Controls.Add(PictureBox4, 0, 0)
        TableLayoutPanel1.Location = New Point(57, 16)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel1.Size = New Size(200, 191)
        TableLayoutPanel1.TabIndex = 45
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Font = New Font("Microsoft Uighur", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(59, 171)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(82, 20)
        Label7.TabIndex = 46
        Label7.Text = "ADD PICTURE"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Dock = DockStyle.Fill
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(3, 3)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(194, 165)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 47
        PictureBox4.TabStop = False
        ' 
        ' Description
        ' 
        Description.Location = New Point(582, 392)
        Description.Margin = New Padding(4, 3, 4, 3)
        Description.Name = "Description"
        Description.Size = New Size(207, 27)
        Description.TabIndex = 42
        ' 
        ' GroupBox4
        ' 
        GroupBox4.BackColor = Color.DarkSeaGreen
        GroupBox4.Controls.Add(Label23)
        GroupBox4.Location = New Point(-6, 253)
        GroupBox4.Margin = New Padding(4, 3, 4, 3)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(4, 3, 4, 3)
        GroupBox4.Size = New Size(1097, 56)
        GroupBox4.TabIndex = 23
        GroupBox4.TabStop = False
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.BorderStyle = BorderStyle.FixedSingle
        Label23.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label23.Location = New Point(26, 18)
        Label23.Margin = New Padding(4, 0, 4, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(153, 26)
        Label23.TabIndex = 1
        Label23.Text = "Work Information"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto", 12F)
        Label4.Location = New Point(441, 395)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(89, 19)
        Label4.TabIndex = 41
        Label4.Text = "Description"
        ' 
        ' CivilStatus
        ' 
        CivilStatus.FormattingEnabled = True
        CivilStatus.Items.AddRange(New Object() {"Single", "Married", "Divorced", "Separated", "Widowed"})
        CivilStatus.Location = New Point(827, 28)
        CivilStatus.Margin = New Padding(4, 3, 4, 3)
        CivilStatus.Name = "CivilStatus"
        CivilStatus.Size = New Size(194, 27)
        CivilStatus.TabIndex = 40
        ' 
        ' Department
        ' 
        Department.FormattingEnabled = True
        Department.Items.AddRange(New Object() {"Institute of Computer Studies", "Institute of Business", "Institute of Education"})
        Department.Location = New Point(161, 445)
        Department.Margin = New Padding(4, 3, 4, 3)
        Department.Name = "Department"
        Department.Size = New Size(207, 27)
        Department.TabIndex = 39
        ' 
        ' NoUnits
        ' 
        NoUnits.Location = New Point(582, 445)
        NoUnits.Margin = New Padding(4, 3, 4, 3)
        NoUnits.Name = "NoUnits"
        NoUnits.Size = New Size(207, 27)
        NoUnits.TabIndex = 34
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Roboto", 12F)
        Label27.Location = New Point(441, 448)
        Label27.Margin = New Padding(4, 0, 4, 0)
        Label27.Name = "Label27"
        Label27.Size = New Size(92, 19)
        Label27.TabIndex = 33
        Label27.Text = "No. of Units"
        ' 
        ' Designation
        ' 
        Designation.Location = New Point(581, 340)
        Designation.Margin = New Padding(4, 3, 4, 3)
        Designation.Name = "Designation"
        Designation.Size = New Size(207, 27)
        Designation.TabIndex = 32
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Font = New Font("Roboto", 12F)
        Label28.Location = New Point(441, 343)
        Label28.Margin = New Padding(4, 0, 4, 0)
        Label28.Name = "Label28"
        Label28.Size = New Size(94, 19)
        Label28.TabIndex = 31
        Label28.Text = "Designation"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Roboto", 12F)
        Label26.Location = New Point(31, 448)
        Label26.Margin = New Padding(4, 0, 4, 0)
        Label26.Name = "Label26"
        Label26.Size = New Size(92, 19)
        Label26.TabIndex = 27
        Label26.Text = "Department"
        ' 
        ' Position
        ' 
        Position.Location = New Point(161, 340)
        Position.Margin = New Padding(4, 3, 4, 3)
        Position.Name = "Position"
        Position.Size = New Size(207, 27)
        Position.TabIndex = 24
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Roboto", 12F)
        Label25.Location = New Point(32, 343)
        Label25.Margin = New Padding(4, 0, 4, 0)
        Label25.Name = "Label25"
        Label25.Size = New Size(67, 19)
        Label25.TabIndex = 23
        Label25.Text = "Position"
        ' 
        ' DateOfBirth
        ' 
        DateOfBirth.CalendarTrailingForeColor = Color.Green
        DateOfBirth.CustomFormat = ""
        DateOfBirth.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateOfBirth.Format = DateTimePickerFormat.Short
        DateOfBirth.Location = New Point(827, 78)
        DateOfBirth.Margin = New Padding(4, 3, 4, 3)
        DateOfBirth.Name = "DateOfBirth"
        DateOfBirth.Size = New Size(194, 24)
        DateOfBirth.TabIndex = 18
        DateOfBirth.Value = New Date(1990, 8, 27, 0, 0, 0, 0)
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Roboto", 12F)
        Label19.Location = New Point(649, 81)
        Label19.Margin = New Padding(4, 0, 4, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(98, 19)
        Label19.TabIndex = 17
        Label19.Text = "Date of Birth"
        ' 
        ' Contact
        ' 
        Contact.Location = New Point(827, 179)
        Contact.Margin = New Padding(4, 3, 4, 3)
        Contact.Name = "Contact"
        Contact.Size = New Size(194, 27)
        Contact.TabIndex = 16
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Roboto", 12F)
        Label18.Location = New Point(649, 186)
        Label18.Margin = New Padding(4, 0, 4, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(124, 19)
        Label18.TabIndex = 15
        Label18.Text = "Contact Number"
        ' 
        ' Suffix
        ' 
        Suffix.FormattingEnabled = True
        Suffix.Items.AddRange(New Object() {"", "Sr.", "Jr.", "I", "II", "III", "IV", "V"})
        Suffix.Location = New Point(441, 188)
        Suffix.Margin = New Padding(4, 3, 4, 3)
        Suffix.Name = "Suffix"
        Suffix.Size = New Size(87, 27)
        Suffix.TabIndex = 11
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Roboto", 12F)
        Label16.Location = New Point(649, 27)
        Label16.Margin = New Padding(4, 0, 4, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(89, 19)
        Label16.TabIndex = 10
        Label16.Text = "Civil Status"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Roboto", 12F)
        Label15.Location = New Point(302, 186)
        Label15.Margin = New Padding(4, 0, 4, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(50, 19)
        Label15.TabIndex = 5
        Label15.Text = "Suffix"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Roboto", 12F)
        Label14.Location = New Point(649, 133)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(110, 19)
        Label14.TabIndex = 8
        Label14.Text = "Email Address"
        ' 
        ' Lname
        ' 
        Lname.Location = New Point(440, 135)
        Lname.Margin = New Padding(4, 3, 4, 3)
        Lname.Name = "Lname"
        Lname.Size = New Size(157, 27)
        Lname.TabIndex = 6
        ' 
        ' Mname
        ' 
        Mname.Location = New Point(440, 83)
        Mname.Margin = New Padding(4, 3, 4, 3)
        Mname.Name = "Mname"
        Mname.Size = New Size(157, 27)
        Mname.TabIndex = 5
        ' 
        ' Fname
        ' 
        Fname.Location = New Point(440, 25)
        Fname.Margin = New Padding(4, 3, 4, 3)
        Fname.Name = "Fname"
        Fname.Size = New Size(157, 27)
        Fname.TabIndex = 4
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Roboto", 12F)
        Label12.Location = New Point(302, 133)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(86, 19)
        Label12.TabIndex = 3
        Label12.Text = "Last Name"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Roboto", 12F)
        Label11.Location = New Point(302, 79)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(103, 19)
        Label11.TabIndex = 2
        Label11.Text = "Middle Name"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Roboto", 12F)
        Label10.Location = New Point(302, 27)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 19)
        Label10.TabIndex = 1
        Label10.Text = "First Name"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(PictureBox13)
        Panel1.Location = New Point(0, 1)
        Panel1.Margin = New Padding(4, 3, 4, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(258, 1199)
        Panel1.TabIndex = 5
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.5714283F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 71.42857F))
        TableLayoutPanel2.Controls.Add(Label31, 0, 5)
        TableLayoutPanel2.Controls.Add(Label30, 0, 4)
        TableLayoutPanel2.Controls.Add(Label29, 0, 3)
        TableLayoutPanel2.Controls.Add(Label22, 0, 2)
        TableLayoutPanel2.Controls.Add(Label21, 0, 0)
        TableLayoutPanel2.Controls.Add(Label17, 0, 1)
        TableLayoutPanel2.Controls.Add(Label20, 1, 5)
        TableLayoutPanel2.Controls.Add(Label5, 1, 2)
        TableLayoutPanel2.Controls.Add(Label1, 1, 0)
        TableLayoutPanel2.Controls.Add(Label6, 1, 4)
        TableLayoutPanel2.Controls.Add(Label2, 1, 1)
        TableLayoutPanel2.Controls.Add(Label3, 1, 3)
        TableLayoutPanel2.Location = New Point(6, 225)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 6
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel2.Size = New Size(258, 435)
        TableLayoutPanel2.TabIndex = 32
        ' 
        ' Label31
        ' 
        Label31.Anchor = AnchorStyles.None
        Label31.AutoSize = True
        Label31.Cursor = Cursors.Hand
        Label31.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label31.Location = New Point(4, 375)
        Label31.Margin = New Padding(0)
        Label31.Name = "Label31"
        Label31.Size = New Size(64, 44)
        Label31.TabIndex = 24
        Label31.Text = "📖"
        Label31.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label30
        ' 
        Label30.Anchor = AnchorStyles.None
        Label30.AutoSize = True
        Label30.Cursor = Cursors.Hand
        Label30.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label30.Location = New Point(8, 302)
        Label30.Margin = New Padding(0)
        Label30.Name = "Label30"
        Label30.Size = New Size(57, 44)
        Label30.TabIndex = 23
        Label30.Text = "🔒"
        Label30.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label29
        ' 
        Label29.Anchor = AnchorStyles.None
        Label29.AutoSize = True
        Label29.Cursor = Cursors.Hand
        Label29.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label29.Location = New Point(4, 230)
        Label29.Margin = New Padding(0)
        Label29.Name = "Label29"
        Label29.Size = New Size(64, 44)
        Label29.TabIndex = 22
        Label29.Text = "🕙"
        Label29.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label22
        ' 
        Label22.Anchor = AnchorStyles.None
        Label22.AutoSize = True
        Label22.Cursor = Cursors.Hand
        Label22.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label22.Location = New Point(4, 158)
        Label22.Margin = New Padding(0)
        Label22.Name = "Label22"
        Label22.Size = New Size(64, 44)
        Label22.TabIndex = 21
        Label22.Text = "💵"
        Label22.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label21
        ' 
        Label21.Anchor = AnchorStyles.None
        Label21.AutoSize = True
        Label21.Cursor = Cursors.Hand
        Label21.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(7, 14)
        Label21.Margin = New Padding(0)
        Label21.Name = "Label21"
        Label21.Size = New Size(59, 44)
        Label21.TabIndex = 20
        Label21.Text = "🏚️"
        Label21.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label17
        ' 
        Label17.Anchor = AnchorStyles.None
        Label17.AutoSize = True
        Label17.Cursor = Cursors.Hand
        Label17.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(4, 86)
        Label17.Margin = New Padding(0)
        Label17.Name = "Label17"
        Label17.Size = New Size(64, 44)
        Label17.TabIndex = 19
        Label17.Text = "👥"
        Label17.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label20
        ' 
        Label20.Anchor = AnchorStyles.None
        Label20.AutoSize = True
        Label20.Cursor = Cursors.Hand
        Label20.Font = New Font("Roboto", 12F)
        Label20.Location = New Point(134, 388)
        Label20.Margin = New Padding(0)
        Label20.Name = "Label20"
        Label20.Size = New Size(63, 19)
        Label20.TabIndex = 17
        Label20.Text = "Reports"
        Label20.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Cursor = Cursors.Hand
        Label5.Font = New Font("Roboto", 12F)
        Label5.Location = New Point(136, 170)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 19)
        Label5.TabIndex = 18
        Label5.Text = "Payroll"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Cursor = Cursors.Hand
        Label1.Font = New Font("Roboto", 12F)
        Label1.Location = New Point(141, 26)
        Label1.Margin = New Padding(0)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 19)
        Label1.TabIndex = 8
        Label1.Text = "Menu"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Cursor = Cursors.Hand
        Label6.Font = New Font("Roboto", 12F)
        Label6.Location = New Point(132, 314)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 19)
        Label6.TabIndex = 13
        Label6.Text = "Account"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Cursor = Cursors.Hand
        Label2.Font = New Font("Roboto", 12F)
        Label2.Location = New Point(126, 98)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 19)
        Label2.TabIndex = 9
        Label2.Text = "Employee"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Cursor = Cursors.Hand
        Label3.Font = New Font("Roboto", 12F)
        Label3.Location = New Point(112, 242)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 19)
        Label3.TabIndex = 12
        Label3.Text = "Time Records"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox13
        ' 
        PictureBox13.BackColor = Color.White
        PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), Image)
        PictureBox13.Location = New Point(0, 0)
        PictureBox13.Margin = New Padding(4, 3, 4, 3)
        PictureBox13.Name = "PictureBox13"
        PictureBox13.Size = New Size(258, 174)
        PictureBox13.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox13.TabIndex = 18
        PictureBox13.TabStop = False
        ' 
        ' DateHired
        ' 
        DateHired.CustomFormat = "MM/DD/YYYY"
        DateHired.Format = DateTimePickerFormat.Short
        DateHired.Location = New Point(161, 392)
        DateHired.Margin = New Padding(4, 3, 4, 3)
        DateHired.Name = "DateHired"
        DateHired.Size = New Size(207, 27)
        DateHired.TabIndex = 32
        DateHired.Value = New Date(2024, 8, 8, 0, 0, 0, 0)
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Roboto", 12F)
        Label24.Location = New Point(32, 395)
        Label24.Margin = New Padding(4, 0, 4, 0)
        Label24.Name = "Label24"
        Label24.Size = New Size(83, 19)
        Label24.TabIndex = 25
        Label24.Text = "Date Hired"
        ' 
        ' add_employee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1350, 681)
        Controls.Add(Panel1)
        Controls.Add(GroupBox1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "add_employee"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CDM PAYROLL SYSTEM"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        Panel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(PictureBox13, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents NoUnits As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Designation As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Position As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents DateOfBirth As DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents Contact As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Suffix As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Lname As TextBox
    Friend WithEvents Mname As TextBox
    Friend WithEvents Fname As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Department As ComboBox
    Friend WithEvents CivilStatus As ComboBox
    Friend WithEvents Description As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents email As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox13 As PictureBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents DateHired As DateTimePicker
    Friend WithEvents Label24 As Label
End Class
