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
        Label1 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        GroupBox3 = New GroupBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label25 = New Label()
        Position = New TextBox()
        Label28 = New Label()
        Designation = New TextBox()
        Label24 = New Label()
        Description = New TextBox()
        NoUnits = New TextBox()
        Department = New ComboBox()
        Label27 = New Label()
        DateHired = New DateTimePicker()
        Label4 = New Label()
        Label26 = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label11 = New Label()
        Label14 = New Label()
        Label18 = New Label()
        Contact = New TextBox()
        Label19 = New Label()
        DateOfBirth = New DateTimePicker()
        Button1 = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label7 = New Label()
        PictureBox4 = New PictureBox()
        GroupBox4 = New GroupBox()
        Label23 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Controls.Add(GroupBox3)
        GroupBox1.Location = New Point(2, 1)
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
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Location = New Point(-3, -3)
        GroupBox2.Margin = New Padding(4, 3, 4, 3)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 3, 4, 3)
        GroupBox2.Size = New Size(1088, 100)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Roboto Light", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(1028, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 46)
        Label1.TabIndex = 51
        Label1.Text = "↩️"
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
        GroupBox3.Anchor = AnchorStyles.None
        GroupBox3.BackColor = Color.White
        GroupBox3.Controls.Add(TableLayoutPanel2)
        GroupBox3.Controls.Add(TableLayoutPanel3)
        GroupBox3.Controls.Add(Button1)
        GroupBox3.Controls.Add(TableLayoutPanel1)
        GroupBox3.Controls.Add(GroupBox4)
        GroupBox3.Font = New Font("Roboto", 12F)
        GroupBox3.Location = New Point(3, 103)
        GroupBox3.Margin = New Padding(4, 3, 4, 3)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(4, 3, 4, 3)
        GroupBox3.Size = New Size(1082, 554)
        GroupBox3.TabIndex = 0
        GroupBox3.TabStop = False
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.Controls.Add(Label25, 0, 0)
        TableLayoutPanel2.Controls.Add(Position, 1, 0)
        TableLayoutPanel2.Controls.Add(Label28, 2, 0)
        TableLayoutPanel2.Controls.Add(Designation, 3, 0)
        TableLayoutPanel2.Controls.Add(Label24, 0, 1)
        TableLayoutPanel2.Controls.Add(Description, 3, 1)
        TableLayoutPanel2.Controls.Add(NoUnits, 3, 2)
        TableLayoutPanel2.Controls.Add(Department, 1, 2)
        TableLayoutPanel2.Controls.Add(Label27, 2, 2)
        TableLayoutPanel2.Controls.Add(DateHired, 1, 1)
        TableLayoutPanel2.Controls.Add(Label4, 2, 1)
        TableLayoutPanel2.Controls.Add(Label26, 0, 2)
        TableLayoutPanel2.Location = New Point(50, 310)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Size = New Size(762, 163)
        TableLayoutPanel2.TabIndex = 50
        ' 
        ' Label25
        ' 
        Label25.Anchor = AnchorStyles.None
        Label25.AutoSize = True
        Label25.Font = New Font("Roboto", 12F)
        Label25.Location = New Point(42, 17)
        Label25.Margin = New Padding(4, 0, 4, 0)
        Label25.Name = "Label25"
        Label25.Size = New Size(67, 19)
        Label25.TabIndex = 23
        Label25.Text = "Position"
        Label25.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Position
        ' 
        Position.Anchor = AnchorStyles.None
        Position.Location = New Point(175, 13)
        Position.Margin = New Padding(4, 3, 4, 3)
        Position.Name = "Position"
        Position.Size = New Size(182, 27)
        Position.TabIndex = 4
        ' 
        ' Label28
        ' 
        Label28.Anchor = AnchorStyles.None
        Label28.AutoSize = True
        Label28.Font = New Font("Roboto", 12F)
        Label28.Location = New Point(409, 17)
        Label28.Margin = New Padding(4, 0, 4, 0)
        Label28.Name = "Label28"
        Label28.Size = New Size(94, 19)
        Label28.TabIndex = 31
        Label28.Text = "Designation"
        Label28.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Designation
        ' 
        Designation.Anchor = AnchorStyles.None
        Designation.Location = New Point(555, 13)
        Designation.Margin = New Padding(4, 3, 4, 3)
        Designation.Name = "Designation"
        Designation.Size = New Size(184, 27)
        Designation.TabIndex = 7
        ' 
        ' Label24
        ' 
        Label24.Anchor = AnchorStyles.None
        Label24.AutoSize = True
        Label24.Font = New Font("Roboto", 12F)
        Label24.Location = New Point(34, 71)
        Label24.Margin = New Padding(4, 0, 4, 0)
        Label24.Name = "Label24"
        Label24.Size = New Size(83, 19)
        Label24.TabIndex = 25
        Label24.Text = "Date Hired"
        Label24.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Description
        ' 
        Description.Anchor = AnchorStyles.None
        Description.Location = New Point(555, 67)
        Description.Margin = New Padding(4, 3, 4, 3)
        Description.Name = "Description"
        Description.Size = New Size(184, 27)
        Description.TabIndex = 8
        ' 
        ' NoUnits
        ' 
        NoUnits.Anchor = AnchorStyles.None
        NoUnits.Location = New Point(555, 122)
        NoUnits.Margin = New Padding(4, 3, 4, 3)
        NoUnits.Name = "NoUnits"
        NoUnits.Size = New Size(184, 27)
        NoUnits.TabIndex = 9
        ' 
        ' Department
        ' 
        Department.Anchor = AnchorStyles.None
        Department.FormattingEnabled = True
        Department.Items.AddRange(New Object() {"Institute of Computer Studies", "Institute of Business", "Institute of Education"})
        Department.Location = New Point(175, 124)
        Department.Margin = New Padding(4, 3, 4, 3)
        Department.Name = "Department"
        Department.Size = New Size(182, 27)
        Department.TabIndex = 6
        ' 
        ' Label27
        ' 
        Label27.Anchor = AnchorStyles.None
        Label27.AutoSize = True
        Label27.Font = New Font("Roboto", 12F)
        Label27.Location = New Point(410, 126)
        Label27.Margin = New Padding(4, 0, 4, 0)
        Label27.Name = "Label27"
        Label27.Size = New Size(92, 19)
        Label27.TabIndex = 33
        Label27.Text = "No. of Units"
        Label27.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' DateHired
        ' 
        DateHired.Anchor = AnchorStyles.None
        DateHired.CustomFormat = "MM/DD/YYYY"
        DateHired.Format = DateTimePickerFormat.Short
        DateHired.Location = New Point(175, 67)
        DateHired.Margin = New Padding(4, 3, 4, 3)
        DateHired.Name = "DateHired"
        DateHired.Size = New Size(182, 27)
        DateHired.TabIndex = 5
        DateHired.Value = New Date(2024, 8, 8, 0, 0, 0, 0)
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto", 12F)
        Label4.Location = New Point(411, 71)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(89, 19)
        Label4.TabIndex = 41
        Label4.Text = "Description"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label26
        ' 
        Label26.Anchor = AnchorStyles.None
        Label26.AutoSize = True
        Label26.Font = New Font("Roboto", 12F)
        Label26.Location = New Point(30, 126)
        Label26.Margin = New Padding(4, 0, 4, 0)
        Label26.Name = "Label26"
        Label26.Size = New Size(92, 19)
        Label26.TabIndex = 27
        Label26.Text = "Department"
        Label26.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        TableLayoutPanel3.Controls.Add(TextBox2, 1, 1)
        TableLayoutPanel3.Controls.Add(TextBox1, 1, 0)
        TableLayoutPanel3.Controls.Add(Label11, 0, 0)
        TableLayoutPanel3.Controls.Add(Label14, 0, 1)
        TableLayoutPanel3.Controls.Add(Label18, 0, 2)
        TableLayoutPanel3.Controls.Add(Contact, 1, 2)
        TableLayoutPanel3.Controls.Add(Label19, 0, 3)
        TableLayoutPanel3.Controls.Add(DateOfBirth, 1, 3)
        TableLayoutPanel3.Location = New Point(273, 12)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 4
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel3.Size = New Size(451, 216)
        TableLayoutPanel3.TabIndex = 49
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(172, 67)
        TextBox2.Margin = New Padding(4, 3, 4, 3)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(242, 27)
        TextBox2.TabIndex = 49
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(172, 13)
        TextBox1.Margin = New Padding(4, 3, 4, 3)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(242, 27)
        TextBox1.TabIndex = 48
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.None
        Label11.AutoSize = True
        Label11.Font = New Font("Roboto", 12F)
        Label11.Location = New Point(42, 17)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(51, 19)
        Label11.TabIndex = 47
        Label11.Text = "Name"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.AutoSize = True
        Label14.Font = New Font("Roboto", 12F)
        Label14.Location = New Point(12, 71)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(110, 19)
        Label14.TabIndex = 8
        Label14.Text = "Email Address"
        Label14.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label18
        ' 
        Label18.Anchor = AnchorStyles.None
        Label18.AutoSize = True
        Label18.Font = New Font("Roboto", 12F)
        Label18.Location = New Point(5, 125)
        Label18.Margin = New Padding(4, 0, 4, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(124, 19)
        Label18.TabIndex = 15
        Label18.Text = "Contact Number"
        Label18.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Contact
        ' 
        Contact.Anchor = AnchorStyles.None
        Contact.Location = New Point(172, 121)
        Contact.Margin = New Padding(4, 3, 4, 3)
        Contact.Name = "Contact"
        Contact.Size = New Size(242, 27)
        Contact.TabIndex = 2
        ' 
        ' Label19
        ' 
        Label19.Anchor = AnchorStyles.None
        Label19.AutoSize = True
        Label19.Font = New Font("Roboto", 12F)
        Label19.Location = New Point(18, 179)
        Label19.Margin = New Padding(4, 0, 4, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(98, 19)
        Label19.TabIndex = 17
        Label19.Text = "Date of Birth"
        Label19.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' DateOfBirth
        ' 
        DateOfBirth.Anchor = AnchorStyles.None
        DateOfBirth.CalendarTrailingForeColor = Color.Green
        DateOfBirth.CustomFormat = ""
        DateOfBirth.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateOfBirth.Format = DateTimePickerFormat.Short
        DateOfBirth.Location = New Point(169, 177)
        DateOfBirth.Margin = New Padding(4, 3, 4, 3)
        DateOfBirth.Name = "DateOfBirth"
        DateOfBirth.Size = New Size(247, 24)
        DateOfBirth.TabIndex = 3
        DateOfBirth.Value = New Date(1990, 8, 27, 0, 0, 0, 0)
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.Gold
        Button1.Font = New Font("Roboto", 9F)
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(50, 494)
        Button1.Margin = New Padding(4, 3, 4, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(128, 41)
        Button1.TabIndex = 35
        Button1.Text = "SAVE INFO"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(Label7, 0, 1)
        TableLayoutPanel1.Controls.Add(PictureBox4, 0, 0)
        TableLayoutPanel1.Location = New Point(47, 12)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel1.Size = New Size(196, 202)
        TableLayoutPanel1.TabIndex = 45
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Font = New Font("Microsoft Uighur", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(57, 181)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(82, 21)
        Label7.TabIndex = 46
        Label7.Text = "ADD PICTURE"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Dock = DockStyle.Fill
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(3, 3)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(190, 175)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 47
        PictureBox4.TabStop = False
        ' 
        ' GroupBox4
        ' 
        GroupBox4.BackColor = Color.DarkSeaGreen
        GroupBox4.Controls.Add(Label23)
        GroupBox4.Location = New Point(-6, 234)
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
        ' add_employee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1086, 661)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 3, 4, 3)
        Name = "add_employee"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CDM PAYROLL SYSTEM"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox3 As GroupBox
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
    Friend WithEvents Label14 As Label
    Friend WithEvents Department As ComboBox
    Friend WithEvents Description As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents DateHired As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
