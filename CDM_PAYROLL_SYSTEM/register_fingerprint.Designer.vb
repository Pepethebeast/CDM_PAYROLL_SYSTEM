<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register_fingerprint
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(register_fingerprint))
        TableLayoutPanel1 = New TableLayoutPanel()
        Label2 = New Label()
        ProgressBar1 = New ProgressBar()
        btnRegisterFingerprint = New Button()
        Label3 = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.Transparent
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(ProgressBar1, 0, 1)
        TableLayoutPanel1.Controls.Add(btnRegisterFingerprint, 0, 2)
        TableLayoutPanel1.Location = New Point(12, 260)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.4448128F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.44482F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.11037F))
        TableLayoutPanel1.Size = New Size(298, 164)
        TableLayoutPanel1.TabIndex = 11
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.Maroon
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(292, 54)
        Label2.TabIndex = 4
        Label2.Text = "Start to register fingerprint"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Anchor = AnchorStyles.None
        ProgressBar1.BackColor = Color.White
        ProgressBar1.Location = New Point(30, 69)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(238, 23)
        ProgressBar1.TabIndex = 6
        ' 
        ' btnRegisterFingerprint
        ' 
        btnRegisterFingerprint.Anchor = AnchorStyles.None
        btnRegisterFingerprint.BackColor = Color.DarkSeaGreen
        btnRegisterFingerprint.Location = New Point(55, 116)
        btnRegisterFingerprint.Name = "btnRegisterFingerprint"
        btnRegisterFingerprint.Size = New Size(187, 40)
        btnRegisterFingerprint.TabIndex = 7
        btnRegisterFingerprint.Text = "START"
        btnRegisterFingerprint.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Roboto Medium", 26.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(268, 6)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 46)
        Label3.TabIndex = 10
        Label3.Text = "↩"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(8, 229)
        Label1.Name = "Label1"
        Label1.Size = New Size(308, 28)
        Label1.TabIndex = 9
        Label1.Text = "REGISTER FINGERPRINT"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(68, 44)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(171, 173)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' Timer2
        ' 
        ' 
        ' register_fingerprint
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(321, 452)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "register_fingerprint"
        StartPosition = FormStartPosition.CenterScreen
        Text = "register_fingerprint"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnRegisterFingerprint As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
End Class
