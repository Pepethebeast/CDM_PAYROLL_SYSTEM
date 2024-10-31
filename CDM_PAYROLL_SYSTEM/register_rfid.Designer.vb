<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register_rfid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(register_rfid))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Button4 = New Button()
        Label2 = New Label()
        Label3 = New Label()
        ProgressBar1 = New ProgressBar()
        Timer1 = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(75, 38)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(171, 173)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(64, 242)
        Label1.Name = "Label1"
        Label1.Size = New Size(199, 28)
        Label1.TabIndex = 1
        Label1.Text = "REGISTER RFID"
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.DarkSeaGreen
        Button4.Location = New Point(103, 368)
        Button4.Name = "Button4"
        Button4.Size = New Size(110, 39)
        Button4.TabIndex = 3
        Button4.Text = "DONE"
        Button4.UseVisualStyleBackColor = False
        Button4.Visible = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Maroon
        Label2.Location = New Point(61, 294)
        Label2.Name = "Label2"
        Label2.Size = New Size(199, 23)
        Label2.TabIndex = 4
        Label2.Text = "Please Scan your RFID"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Roboto Medium", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(275, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 46)
        Label3.TabIndex = 5
        Label3.Text = "↩"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.BackColor = Color.White
        ProgressBar1.Location = New Point(72, 330)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(171, 23)
        ProgressBar1.TabIndex = 6
        ' 
        ' register_rfid
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(322, 452)
        Controls.Add(ProgressBar1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Button4)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "register_rfid"
        StartPosition = FormStartPosition.CenterScreen
        Text = "register_rfid"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer1 As Timer
End Class
