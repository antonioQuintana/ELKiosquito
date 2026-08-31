<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        LBNombre = New Label()
        LBApellido = New Label()
        SuspendLayout()
        ' 
        ' LBNombre
        ' 
        LBNombre.AutoSize = True
        LBNombre.Location = New Point(39, 48)
        LBNombre.Name = "LBNombre"
        LBNombre.Size = New Size(51, 15)
        LBNombre.TabIndex = 0
        LBNombre.Text = "Nombre"
        ' 
        ' LBApellido
        ' 
        LBApellido.AutoSize = True
        LBApellido.Location = New Point(39, 81)
        LBApellido.Name = "LBApellido"
        LBApellido.Size = New Size(51, 15)
        LBApellido.TabIndex = 1
        LBApellido.Text = "Apellido"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LBApellido)
        Controls.Add(LBNombre)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LBNombre As Label
    Friend WithEvents LBApellido As Label

End Class
