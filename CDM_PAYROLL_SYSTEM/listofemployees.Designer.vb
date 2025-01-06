<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class List_of_Employees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(List_of_Employees))
        GroupBox4 = New GroupBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        PictureBox11 = New PictureBox()
        PictureBox12 = New PictureBox()
        Label23 = New Label()
        DGVUserData = New DataGridView()
        Panel2 = New Panel()
        PictureBox13 = New PictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label31 = New Label()
        Label30 = New Label()
        Label29 = New Label()
        Label25 = New Label()
        Label24 = New Label()
        Label3 = New Label()
        Label20 = New Label()
        Label5 = New Label()
        Label1 = New Label()
        Label6 = New Label()
        Label2 = New Label()
        Label7 = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        IconButton2 = New IconButton()
        IconButton3 = New IconButton()
        IconButton4 = New IconButton()
        IconButton5 = New IconButton()
        TextBox1 = New TextBox()
        GroupBox4.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(PictureBox11, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox12, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGVUserData, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox13, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox4.BackColor = Color.DarkSeaGreen
        GroupBox4.Controls.Add(TableLayoutPanel2)
        GroupBox4.Controls.Add(Label23)
        GroupBox4.Location = New Point(258, 3)
        GroupBox4.Margin = New Padding(4, 3, 4, 3)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(4, 3, 4, 3)
        GroupBox4.Size = New Size(1090, 72)
        GroupBox4.TabIndex = 24
        GroupBox4.TabStop = False
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel2.BackColor = Color.DarkSeaGreen
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(PictureBox11, 0, 0)
        TableLayoutPanel2.Controls.Add(PictureBox12, 1, 0)
        TableLayoutPanel2.Location = New Point(959, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(131, 72)
        TableLayoutPanel2.TabIndex = 29
        ' 
        ' PictureBox11
        ' 
        PictureBox11.Anchor = AnchorStyles.None
        PictureBox11.BackColor = Color.Transparent
        PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), Image)
        PictureBox11.Location = New Point(4, 3)
        PictureBox11.Margin = New Padding(4, 3, 4, 3)
        PictureBox11.Name = "PictureBox11"
        PictureBox11.Size = New Size(57, 66)
        PictureBox11.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox11.TabIndex = 28
        PictureBox11.TabStop = False
        ' 
        ' PictureBox12
        ' 
        PictureBox12.Anchor = AnchorStyles.None
        PictureBox12.BackColor = Color.Transparent
        PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), Image)
        PictureBox12.Location = New Point(69, 3)
        PictureBox12.Margin = New Padding(4, 3, 4, 3)
        PictureBox12.Name = "PictureBox12"
        PictureBox12.Size = New Size(58, 66)
        PictureBox12.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox12.TabIndex = 27
        PictureBox12.TabStop = False
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.BorderStyle = BorderStyle.FixedSingle
        Label23.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label23.Location = New Point(19, 17)
        Label23.Margin = New Padding(4, 0, 4, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(159, 26)
        Label23.TabIndex = 1
        Label23.Text = "List of Employees"
        ' 
        ' DGVUserData
        ' 
        DGVUserData.AllowUserToAddRows = False
        DGVUserData.AllowUserToDeleteRows = False
        DGVUserData.AllowUserToResizeColumns = False
        DGVUserData.AllowUserToResizeRows = False
        DGVUserData.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DGVUserData.BackgroundColor = Color.White
        DGVUserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVUserData.Location = New Point(262, 129)
        DGVUserData.Margin = New Padding(4, 3, 4, 3)
        DGVUserData.Name = "DGVUserData"
        DGVUserData.Size = New Size(1082, 527)
        DGVUserData.TabIndex = 28
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(PictureBox13)
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(4, 3, 4, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(254, 665)
        Panel2.TabIndex = 29
        ' 
        ' PictureBox13
        ' 
        PictureBox13.BackColor = Color.White
        PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), Image)
        PictureBox13.Location = New Point(6, 0)
        PictureBox13.Margin = New Padding(4, 3, 4, 3)
        PictureBox13.Name = "PictureBox13"
        PictureBox13.Size = New Size(244, 174)
        PictureBox13.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox13.TabIndex = 18
        PictureBox13.TabStop = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.White
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.5714283F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 71.42857F))
        TableLayoutPanel1.Controls.Add(Label31, 0, 5)
        TableLayoutPanel1.Controls.Add(Label30, 0, 4)
        TableLayoutPanel1.Controls.Add(Label29, 0, 3)
        TableLayoutPanel1.Controls.Add(Label25, 0, 2)
        TableLayoutPanel1.Controls.Add(Label24, 0, 1)
        TableLayoutPanel1.Controls.Add(Label3, 0, 0)
        TableLayoutPanel1.Controls.Add(Label20, 1, 5)
        TableLayoutPanel1.Controls.Add(Label5, 1, 2)
        TableLayoutPanel1.Controls.Add(Label1, 1, 0)
        TableLayoutPanel1.Controls.Add(Label6, 1, 4)
        TableLayoutPanel1.Controls.Add(Label2, 1, 1)
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
        Label31.TabIndex = 28
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
        Label30.TabIndex = 27
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
        Label29.TabIndex = 26
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
        Label25.TabIndex = 25
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
        Label24.TabIndex = 24
        Label24.Text = "👥"
        Label24.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Cursor = Cursors.Hand
        Label3.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(5, 14)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 44)
        Label3.TabIndex = 23
        Label3.Text = "🏚️"
        Label3.TextAlign = ContentAlignment.MiddleCenter
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
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Cursor = Cursors.Hand
        Label1.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(132, 26)
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
        Label6.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(123, 314)
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
        Label2.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(117, 98)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 19)
        Label2.TabIndex = 9
        Label2.Text = "Employee"
        Label2.TextAlign = ContentAlignment.MiddleCenter
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
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        FlowLayoutPanel1.BackColor = Color.Transparent
        FlowLayoutPanel1.Controls.Add(IconButton2)
        FlowLayoutPanel1.Controls.Add(IconButton3)
        FlowLayoutPanel1.Controls.Add(IconButton4)
        FlowLayoutPanel1.Controls.Add(IconButton5)
        FlowLayoutPanel1.Controls.Add(TextBox1)
        FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft
        FlowLayoutPanel1.Location = New Point(603, 79)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(741, 44)
        FlowLayoutPanel1.TabIndex = 33
        ' 
        ' IconButton2
        ' 
        IconButton2.BackColor = Color.DarkSeaGreen
        IconButton2.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton2.IconChar = IconChar.None
        IconButton2.IconColor = Color.Black
        IconButton2.IconFont = IconFont.Auto
        IconButton2.IconSize = 16
        IconButton2.Location = New Point(663, 3)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(75, 41)
        IconButton2.TabIndex = 1
        IconButton2.Text = "🔄"
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' IconButton3
        ' 
        IconButton3.BackColor = Color.DarkSeaGreen
        IconButton3.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton3.IconChar = IconChar.None
        IconButton3.IconColor = Color.Black
        IconButton3.IconFont = IconFont.Auto
        IconButton3.IconSize = 16
        IconButton3.Location = New Point(582, 3)
        IconButton3.Name = "IconButton3"
        IconButton3.Size = New Size(75, 41)
        IconButton3.TabIndex = 2
        IconButton3.Text = "🗑️"
        IconButton3.UseVisualStyleBackColor = False
        ' 
        ' IconButton4
        ' 
        IconButton4.BackColor = Color.DarkSeaGreen
        IconButton4.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton4.IconChar = IconChar.None
        IconButton4.IconColor = Color.Black
        IconButton4.IconFont = IconFont.Auto
        IconButton4.IconSize = 16
        IconButton4.Location = New Point(501, 3)
        IconButton4.Name = "IconButton4"
        IconButton4.Size = New Size(75, 41)
        IconButton4.TabIndex = 3
        IconButton4.Text = "📝"
        IconButton4.UseVisualStyleBackColor = False
        ' 
        ' IconButton5
        ' 
        IconButton5.BackColor = Color.DarkSeaGreen
        IconButton5.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point)
        IconButton5.IconChar = IconChar.None
        IconButton5.IconColor = Color.Black
        IconButton5.IconFont = IconFont.Auto
        IconButton5.IconSize = 16
        IconButton5.Location = New Point(420, 3)
        IconButton5.Name = "IconButton5"
        IconButton5.Size = New Size(75, 41)
        IconButton5.TabIndex = 4
        IconButton5.Text = "🔍"
        IconButton5.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(108, 12)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(306, 23)
        TextBox1.TabIndex = 36
        ' 
        ' List_of_Employees
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1350, 661)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Panel2)
        Controls.Add(DGVUserData)
        Controls.Add(GroupBox4)
        Margin = New Padding(4, 3, 4, 3)
        Name = "List_of_Employees"
        StartPosition = FormStartPosition.CenterScreen
        Text = "List_of_Employees"
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        CType(PictureBox11, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox12, ComponentModel.ISupportInitialize).EndInit()
        CType(DGVUserData, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        CType(PictureBox13, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents PictureBox12 As PictureBox
    Friend WithEvents DGVUserData As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label20 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox13 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox1 As TextBox
End Class
