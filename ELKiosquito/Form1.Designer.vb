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
        LBUsuario = New Label()
        LBPass = New Label()
        LBRol = New Label()
        TBNombre = New TextBox()
        TBApellido = New TextBox()
        TBUsuario = New TextBox()
        TBContraseña = New TextBox()
        CBRol = New ComboBox()
        DGVUsuarios = New DataGridView()
        DVNombre = New DataGridViewTextBoxColumn()
        DVApellido = New DataGridViewTextBoxColumn()
        DVUsuario = New DataGridViewTextBoxColumn()
        DVRol = New DataGridViewTextBoxColumn()
        DVSeleccionar = New DataGridViewButtonColumn()
        DVContraseña = New DataGridViewTextBoxColumn()
        BTAgrearU = New Button()
        BTEditarU = New Button()
        BTBuscarU = New Button()
        BTEliminarU = New Button()
        BTCancelar = New Button()
        CType(DGVUsuarios, ComponentModel.ISupportInitialize).BeginInit()
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
        ' LBUsuario
        ' 
        LBUsuario.AutoSize = True
        LBUsuario.Location = New Point(39, 115)
        LBUsuario.Name = "LBUsuario"
        LBUsuario.Size = New Size(47, 15)
        LBUsuario.TabIndex = 2
        LBUsuario.Text = "Usuario"
        ' 
        ' LBPass
        ' 
        LBPass.AutoSize = True
        LBPass.Location = New Point(39, 150)
        LBPass.Name = "LBPass"
        LBPass.Size = New Size(67, 15)
        LBPass.TabIndex = 3
        LBPass.Text = "Contraseña"
        ' 
        ' LBRol
        ' 
        LBRol.AutoSize = True
        LBRol.Location = New Point(39, 181)
        LBRol.Name = "LBRol"
        LBRol.Size = New Size(24, 15)
        LBRol.TabIndex = 4
        LBRol.Text = "Rol"
        ' 
        ' TBNombre
        ' 
        TBNombre.Location = New Point(121, 45)
        TBNombre.Name = "TBNombre"
        TBNombre.Size = New Size(121, 23)
        TBNombre.TabIndex = 5
        ' 
        ' TBApellido
        ' 
        TBApellido.Location = New Point(121, 78)
        TBApellido.Name = "TBApellido"
        TBApellido.Size = New Size(121, 23)
        TBApellido.TabIndex = 6
        ' 
        ' TBUsuario
        ' 
        TBUsuario.Location = New Point(121, 112)
        TBUsuario.Name = "TBUsuario"
        TBUsuario.Size = New Size(121, 23)
        TBUsuario.TabIndex = 7
        ' 
        ' TBContraseña
        ' 
        TBContraseña.Location = New Point(121, 144)
        TBContraseña.Name = "TBContraseña"
        TBContraseña.Size = New Size(121, 23)
        TBContraseña.TabIndex = 8
        ' 
        ' CBRol
        ' 
        CBRol.FormattingEnabled = True
        CBRol.Items.AddRange(New Object() {"Vendedor", "Repositor", "Admin", "Gerente"})
        CBRol.Location = New Point(121, 177)
        CBRol.Name = "CBRol"
        CBRol.Size = New Size(121, 23)
        CBRol.TabIndex = 9
        ' 
        ' DGVUsuarios
        ' 
        DGVUsuarios.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGVUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVUsuarios.Columns.AddRange(New DataGridViewColumn() {DVNombre, DVApellido, DVUsuario, DVRol, DVSeleccionar, DVContraseña})
        DGVUsuarios.Location = New Point(39, 233)
        DGVUsuarios.Name = "DGVUsuarios"
        DGVUsuarios.Size = New Size(723, 193)
        DGVUsuarios.TabIndex = 10
        ' 
        ' DVNombre
        ' 
        DVNombre.HeaderText = "Nombre"
        DVNombre.Name = "DVNombre"
        ' 
        ' DVApellido
        ' 
        DVApellido.HeaderText = "Apellido"
        DVApellido.Name = "DVApellido"
        ' 
        ' DVUsuario
        ' 
        DVUsuario.HeaderText = "Usuario"
        DVUsuario.Name = "DVUsuario"
        ' 
        ' DVRol
        ' 
        DVRol.HeaderText = "Rol"
        DVRol.Name = "DVRol"
        ' 
        ' DVSeleccionar
        ' 
        DVSeleccionar.HeaderText = "Seleccionar"
        DVSeleccionar.Name = "DVSeleccionar"
        ' 
        ' DVContraseña
        ' 
        DVContraseña.HeaderText = "Contraseña"
        DVContraseña.Name = "DVContraseña"
        DVContraseña.Visible = False
        ' 
        ' BTAgrearU
        ' 
        BTAgrearU.BackColor = Color.GreenYellow
        BTAgrearU.Location = New Point(259, 45)
        BTAgrearU.Name = "BTAgrearU"
        BTAgrearU.Size = New Size(153, 23)
        BTAgrearU.TabIndex = 11
        BTAgrearU.Text = "Agregar Usuario"
        BTAgrearU.UseVisualStyleBackColor = False
        ' 
        ' BTEditarU
        ' 
        BTEditarU.BackColor = Color.SandyBrown
        BTEditarU.Location = New Point(259, 111)
        BTEditarU.Name = "BTEditarU"
        BTEditarU.Size = New Size(153, 23)
        BTEditarU.TabIndex = 12
        BTEditarU.Text = "Editar Usuario"
        BTEditarU.UseVisualStyleBackColor = False
        ' 
        ' BTBuscarU
        ' 
        BTBuscarU.BackColor = SystemColors.ActiveCaption
        BTBuscarU.Location = New Point(259, 77)
        BTBuscarU.Name = "BTBuscarU"
        BTBuscarU.Size = New Size(153, 23)
        BTBuscarU.TabIndex = 13
        BTBuscarU.Text = "Buscar Usuario"
        BTBuscarU.UseVisualStyleBackColor = False
        ' 
        ' BTEliminarU
        ' 
        BTEliminarU.BackColor = Color.Firebrick
        BTEliminarU.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTEliminarU.ForeColor = SystemColors.ControlLightLight
        BTEliminarU.Location = New Point(259, 144)
        BTEliminarU.Name = "BTEliminarU"
        BTEliminarU.Size = New Size(153, 23)
        BTEliminarU.TabIndex = 14
        BTEliminarU.Text = "Eliminar Usuario"
        BTEliminarU.UseVisualStyleBackColor = False
        ' 
        ' BTCancelar
        ' 
        BTCancelar.BackColor = Color.LightGray
        BTCancelar.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTCancelar.ForeColor = SystemColors.ActiveCaptionText
        BTCancelar.Location = New Point(259, 177)
        BTCancelar.Name = "BTCancelar"
        BTCancelar.Size = New Size(153, 23)
        BTCancelar.TabIndex = 15
        BTCancelar.Text = "Cancelar accion"
        BTCancelar.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(BTCancelar)
        Controls.Add(BTEliminarU)
        Controls.Add(BTBuscarU)
        Controls.Add(BTEditarU)
        Controls.Add(BTAgrearU)
        Controls.Add(DGVUsuarios)
        Controls.Add(CBRol)
        Controls.Add(TBContraseña)
        Controls.Add(TBUsuario)
        Controls.Add(TBApellido)
        Controls.Add(TBNombre)
        Controls.Add(LBRol)
        Controls.Add(LBPass)
        Controls.Add(LBUsuario)
        Controls.Add(LBApellido)
        Controls.Add(LBNombre)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(DGVUsuarios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LBNombre As Label
    Friend WithEvents LBApellido As Label
    Friend WithEvents LBUsuario As Label
    Friend WithEvents LBPass As Label
    Friend WithEvents LBRol As Label
    Friend WithEvents TBNombre As TextBox
    Friend WithEvents TBApellido As TextBox
    Friend WithEvents TBUsuario As TextBox
    Friend WithEvents TBContraseña As TextBox
    Friend WithEvents CBRol As ComboBox
    Friend WithEvents DGVUsuarios As DataGridView
    Friend WithEvents BTAgrearU As Button
    Friend WithEvents BTEditarU As Button
    Friend WithEvents BTBuscarU As Button
    Friend WithEvents BTEliminarU As Button
    Friend WithEvents DVNombre As DataGridViewTextBoxColumn
    Friend WithEvents DVApellido As DataGridViewTextBoxColumn
    Friend WithEvents DVUsuario As DataGridViewTextBoxColumn
    Friend WithEvents DVRol As DataGridViewTextBoxColumn
    Friend WithEvents DVSeleccionar As DataGridViewButtonColumn
    Friend WithEvents BTCancelar As Button
    Friend WithEvents DVContraseña As DataGridViewTextBoxColumn

End Class
