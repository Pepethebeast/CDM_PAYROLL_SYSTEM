<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class calculations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(calculations))
        Label1 = New Label()
        DataGridView1 = New DataGridView()
        ComboBox1 = New ComboBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Roboto Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(252, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(254, 28)
        Label1.TabIndex = 0
        Label1.Text = "Intructors Rate per Unit"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 69)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(739, 485)
        DataGridView1.TabIndex = 0
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Designation", "Position"})
        ComboBox1.Location = New Point(12, 40)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(127, 23)
        ComboBox1.TabIndex = 1
        ' 
        ' calculations
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(763, 580)
        Controls.Add(ComboBox1)
        Controls.Add(DataGridView1)
        Controls.Add(Label1)
        Name = "calculations"
        StartPosition = FormStartPosition.CenterScreen
        Text = "calculations"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
End Class
