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
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        SuspendLayout()
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
        ClientSize = New Size(415, 582)
        FormBorderStyle = FormBorderStyle.None
        Name = "register_fingerprint"
        StartPosition = FormStartPosition.CenterScreen
        Text = "register_fingerprint"
        ResumeLayout(False)
    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
End Class
