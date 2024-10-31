<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FaceRecognitionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FaceRecognitionForm))
        PictureBox4 = New PictureBox()
        Label4 = New Label()
        Button1 = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Button2 = New Button()
        ComboBox1 = New ComboBox()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.Location = New Point(44, 72)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(696, 381)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 7
        PictureBox4.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(315, 7)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 25)
        Label4.TabIndex = 10
        Label4.Text = "Camera"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(251, 510)
        Button1.Name = "Button1"
        Button1.Size = New Size(214, 39)
        Button1.TabIndex = 12
        Button1.Text = "Open Camera"
        Button1.TextImageRelation = TextImageRelation.TextAboveImage
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Microsoft YaHei", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkRed
        Label1.ImageAlign = ContentAlignment.TopLeft
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.No
        Label1.Size = New Size(696, 50)
        Label1.TabIndex = 16
        Label1.Text = "NO FACE DETECTED"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkSeaGreen
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(44, 454)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(696, 50)
        Panel2.TabIndex = 16
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkSeaGreen
        Panel3.Controls.Add(Label4)
        Panel3.Location = New Point(44, 37)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(696, 40)
        Panel3.TabIndex = 17
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(480, 510)
        Button2.Name = "Button2"
        Button2.Size = New Size(210, 39)
        Button2.TabIndex = 18
        Button2.Text = "Register Face"
        Button2.TextImageRelation = TextImageRelation.TextAboveImage
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(84, 520)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(147, 23)
        ComboBox1.TabIndex = 19
        ' 
        ' FaceRecognitionForm
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoValidate = AutoValidate.Disable
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(792, 603)
        Controls.Add(ComboBox1)
        Controls.Add(Button2)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Button1)
        Controls.Add(PictureBox4)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FaceRecognitionForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Face Recognition"
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox1 As ComboBox
End Class
