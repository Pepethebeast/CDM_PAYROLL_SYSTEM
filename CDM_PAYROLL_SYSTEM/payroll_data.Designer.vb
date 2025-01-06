<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payroll_data
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payroll_data))
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label1 = New Label()
        ComboBox1 = New ComboBox()
        rangedate = New ComboBox()
        rangeyear = New ComboBox()
        IconButton5 = New IconButton()
        IconButton2 = New IconButton()
        IconButton1 = New IconButton()
        DGVUserData = New DataGridView()
        GroupBox4 = New GroupBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox11 = New PictureBox()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label31 = New Label()
        Label30 = New Label()
        Label29 = New Label()
        Label25 = New Label()
        Label24 = New Label()
        Label23 = New Label()
        Label20 = New Label()
        Label5 = New Label()
        Label9 = New Label()
        Label6 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        PictureBox2 = New PictureBox()
        FlowLayoutPanel1.SuspendLayout()
        CType(DGVUserData, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.BackColor = Color.White
        FlowLayoutPanel1.Controls.Add(Label1)
        FlowLayoutPanel1.Controls.Add(ComboBox1)
        FlowLayoutPanel1.Controls.Add(rangedate)
        FlowLayoutPanel1.Controls.Add(rangeyear)
        FlowLayoutPanel1.Controls.Add(IconButton5)
        FlowLayoutPanel1.Controls.Add(IconButton2)
        FlowLayoutPanel1.Controls.Add(IconButton1)
        FlowLayoutPanel1.Controls.Add(DGVUserData)
        FlowLayoutPanel1.Location = New Point(263, 70)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(1084, 576)
        FlowLayoutPanel1.TabIndex = 34
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(3, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 19)
        Label1.TabIndex = 32
        Label1.Text = "Pay Period:"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.None
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(98, 6)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(87, 23)
        ComboBox1.TabIndex = 24
        ' 
        ' rangedate
        ' 
        rangedate.Anchor = AnchorStyles.None
        rangedate.DropDownStyle = ComboBoxStyle.DropDownList
        rangedate.FormattingEnabled = True
        rangedate.Location = New Point(191, 6)
        rangedate.Name = "rangedate"
        rangedate.Size = New Size(165, 23)
        rangedate.TabIndex = 32
        ' 
        ' rangeyear
        ' 
        rangeyear.Anchor = AnchorStyles.None
        rangeyear.DropDownStyle = ComboBoxStyle.DropDownList
        rangeyear.FormattingEnabled = True
        rangeyear.Location = New Point(362, 6)
        rangeyear.Name = "rangeyear"
        rangeyear.Size = New Size(74, 23)
        rangeyear.TabIndex = 33
        ' 
        ' IconButton5
        ' 
        IconButton5.Anchor = AnchorStyles.None
        IconButton5.BackColor = Color.DarkSeaGreen
        IconButton5.Font = New Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton5.IconChar = IconChar.None
        IconButton5.IconColor = Color.Black
        IconButton5.IconFont = IconFont.Auto
        IconButton5.IconSize = 16
        IconButton5.Location = New Point(442, 3)
        IconButton5.Name = "IconButton5"
        IconButton5.Size = New Size(75, 30)
        IconButton5.TabIndex = 32
        IconButton5.Text = "Refresh"
        IconButton5.UseVisualStyleBackColor = False
        ' 
        ' IconButton2
        ' 
        IconButton2.Anchor = AnchorStyles.None
        IconButton2.BackColor = Color.DarkSeaGreen
        IconButton2.Font = New Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton2.IconChar = IconChar.None
        IconButton2.IconColor = Color.Black
        IconButton2.IconFont = IconFont.Auto
        IconButton2.IconSize = 16
        IconButton2.Location = New Point(523, 3)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(133, 30)
        IconButton2.TabIndex = 33
        IconButton2.Text = "Export as Excel"
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' IconButton1
        ' 
        IconButton1.BackColor = Color.Red
        IconButton1.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton1.IconChar = IconChar.ArrowLeft
        IconButton1.IconColor = Color.Black
        IconButton1.IconFont = IconFont.Auto
        IconButton1.IconSize = 20
        IconButton1.Location = New Point(789, 3)
        IconButton1.Margin = New Padding(130, 3, 3, 3)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(55, 30)
        IconButton1.TabIndex = 32
        IconButton1.UseVisualStyleBackColor = False
        ' 
        ' DGVUserData
        ' 
        DGVUserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVUserData.Location = New Point(3, 39)
        DGVUserData.Name = "DGVUserData"
        DGVUserData.RowTemplate.Height = 25
        DGVUserData.Size = New Size(1081, 529)
        DGVUserData.TabIndex = 36
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox4.BackColor = Color.DarkSeaGreen
        GroupBox4.Controls.Add(PictureBox3)
        GroupBox4.Controls.Add(PictureBox4)
        GroupBox4.Controls.Add(PictureBox11)
        GroupBox4.Controls.Add(Label2)
        GroupBox4.Controls.Add(PictureBox1)
        GroupBox4.Location = New Point(260, 0)
        GroupBox4.Margin = New Padding(4, 3, 4, 3)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(4, 3, 4, 3)
        GroupBox4.Size = New Size(1088, 63)
        GroupBox4.TabIndex = 33
        GroupBox4.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(1840, 3)
        PictureBox3.Margin = New Padding(4, 3, 4, 3)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(63, 60)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 23
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(1907, 2)
        PictureBox4.Margin = New Padding(4, 3, 4, 3)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(63, 60)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 22
        PictureBox4.TabStop = False
        ' 
        ' PictureBox11
        ' 
        PictureBox11.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox11.BackColor = Color.Transparent
        PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), Image)
        PictureBox11.Location = New Point(2718, 3)
        PictureBox11.Margin = New Padding(4, 3, 4, 3)
        PictureBox11.Name = "PictureBox11"
        PictureBox11.Size = New Size(63, 60)
        PictureBox11.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox11.TabIndex = 21
        PictureBox11.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Cursor = Cursors.Hand
        Label2.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(21, 18)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 22)
        Label2.TabIndex = 20
        Label2.Text = "PAYSLIP"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(2785, 2)
        PictureBox1.Margin = New Padding(4, 3, 4, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(63, 60)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 19
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(TableLayoutPanel1)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Location = New Point(2, -2)
        Panel2.Margin = New Padding(4, 3, 4, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(254, 665)
        Panel2.TabIndex = 32
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.5714283F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 71.42857F))
        TableLayoutPanel1.Controls.Add(Label31, 0, 5)
        TableLayoutPanel1.Controls.Add(Label30, 0, 4)
        TableLayoutPanel1.Controls.Add(Label29, 0, 3)
        TableLayoutPanel1.Controls.Add(Label25, 0, 2)
        TableLayoutPanel1.Controls.Add(Label24, 0, 1)
        TableLayoutPanel1.Controls.Add(Label23, 0, 0)
        TableLayoutPanel1.Controls.Add(Label20, 1, 5)
        TableLayoutPanel1.Controls.Add(Label5, 1, 2)
        TableLayoutPanel1.Controls.Add(Label9, 1, 0)
        TableLayoutPanel1.Controls.Add(Label6, 1, 4)
        TableLayoutPanel1.Controls.Add(Label8, 1, 1)
        TableLayoutPanel1.Controls.Add(Label7, 1, 3)
        TableLayoutPanel1.Location = New Point(3, 202)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 6
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        TableLayoutPanel1.Size = New Size(244, 435)
        TableLayoutPanel1.TabIndex = 32
        ' 
        ' Label31
        ' 
        Label31.Anchor = AnchorStyles.None
        Label31.AutoSize = True
        Label31.Cursor = Cursors.Hand
        Label31.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label31.Location = New Point(2, 375)
        Label31.Margin = New Padding(0)
        Label31.Name = "Label31"
        Label31.Size = New Size(64, 44)
        Label31.TabIndex = 26
        Label31.Text = "📖"
        Label31.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label30
        ' 
        Label30.Anchor = AnchorStyles.None
        Label30.AutoSize = True
        Label30.Cursor = Cursors.Hand
        Label30.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label30.Location = New Point(6, 302)
        Label30.Margin = New Padding(0)
        Label30.Name = "Label30"
        Label30.Size = New Size(57, 44)
        Label30.TabIndex = 25
        Label30.Text = "🔒"
        Label30.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label29
        ' 
        Label29.Anchor = AnchorStyles.None
        Label29.AutoSize = True
        Label29.Cursor = Cursors.Hand
        Label29.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label29.Location = New Point(2, 230)
        Label29.Margin = New Padding(0)
        Label29.Name = "Label29"
        Label29.Size = New Size(64, 44)
        Label29.TabIndex = 24
        Label29.Text = "🕙"
        Label29.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label25
        ' 
        Label25.Anchor = AnchorStyles.None
        Label25.AutoSize = True
        Label25.Cursor = Cursors.Hand
        Label25.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label25.Location = New Point(2, 158)
        Label25.Margin = New Padding(0)
        Label25.Name = "Label25"
        Label25.Size = New Size(64, 44)
        Label25.TabIndex = 23
        Label25.Text = "💵"
        Label25.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label24
        ' 
        Label24.Anchor = AnchorStyles.None
        Label24.AutoSize = True
        Label24.Cursor = Cursors.Hand
        Label24.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label24.Location = New Point(2, 86)
        Label24.Margin = New Padding(0)
        Label24.Name = "Label24"
        Label24.Size = New Size(64, 44)
        Label24.TabIndex = 22
        Label24.Text = "👥"
        Label24.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label23
        ' 
        Label23.Anchor = AnchorStyles.None
        Label23.AutoSize = True
        Label23.Cursor = Cursors.Hand
        Label23.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label23.Location = New Point(5, 14)
        Label23.Margin = New Padding(0)
        Label23.Name = "Label23"
        Label23.Size = New Size(59, 44)
        Label23.TabIndex = 21
        Label23.Text = "🏚️"
        Label23.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label20
        ' 
        Label20.Anchor = AnchorStyles.None
        Label20.AutoSize = True
        Label20.Cursor = Cursors.Hand
        Label20.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label20.Location = New Point(125, 388)
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
        Label5.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(127, 170)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 19)
        Label5.TabIndex = 18
        Label5.Text = "Payroll"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.None
        Label9.AutoSize = True
        Label9.Cursor = Cursors.Hand
        Label9.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(132, 26)
        Label9.Margin = New Padding(0)
        Label9.Name = "Label9"
        Label9.Size = New Size(49, 19)
        Label9.TabIndex = 8
        Label9.Text = "Menu"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Cursor = Cursors.Hand
        Label6.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(123, 314)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 19)
        Label6.TabIndex = 13
        Label6.Text = "Account"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.None
        Label8.AutoSize = True
        Label8.Cursor = Cursors.Hand
        Label8.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(117, 98)
        Label8.Margin = New Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New Size(78, 19)
        Label8.TabIndex = 9
        Label8.Text = "Employee"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Cursor = Cursors.Hand
        Label7.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(103, 242)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(106, 19)
        Label7.TabIndex = 12
        Label7.Text = "Time Records"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.White
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(6, 0)
        PictureBox2.Margin = New Padding(4, 3, 4, 3)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(244, 174)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 18
        PictureBox2.TabStop = False
        ' 
        ' payroll_data
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1350, 661)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(GroupBox4)
        Controls.Add(Panel2)
        Name = "payroll_data"
        StartPosition = FormStartPosition.CenterScreen
        Text = "payroll_data"
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        CType(DGVUserData, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents rangedate As ComboBox
    Friend WithEvents rangeyear As ComboBox
    Friend WithEvents IconButton5 As IconButton
    Friend WithEvents IconButton1 As IconButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents DGVUserData As DataGridView
    Friend WithEvents IconButton2 As IconButton
End Class
