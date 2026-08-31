<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Panel2 = New Panel()
        Label5 = New Label()
        Label4 = New Label()
        TextBox2 = New TextBox()
        Button4 = New Button()
        DataGridView1 = New DataGridView()
        descripcion = New DataGridViewTextBoxColumn()
        cantidad = New DataGridViewTextBoxColumn()
        precio = New DataGridViewTextBoxColumn()
        eliminar = New DataGridViewTextBoxColumn()
        DataGridView2 = New DataGridView()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button1.Location = New Point(427, 638)
        Button1.Name = "Button1"
        Button1.Size = New Size(196, 89)
        Button1.TabIndex = 3
        Button1.Text = "Tarjeta de Crédito"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button2.Location = New Point(225, 638)
        Button2.Name = "Button2"
        Button2.Size = New Size(196, 89)
        Button2.TabIndex = 4
        Button2.Text = "Transferencia / QR"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button3.Location = New Point(23, 638)
        Button3.Name = "Button3"
        Button3.Size = New Size(196, 89)
        Button3.TabIndex = 5
        Button3.Text = "EFECTIVO"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        TextBox1.Location = New Point(12, 28)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(633, 31)
        TextBox1.TabIndex = 7
        TextBox1.Text = "Buscar producto (código)"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveBorder
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(651, 551)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(663, 81)
        Panel1.TabIndex = 8
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(73, 26)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 25)
        Label2.TabIndex = 1
        Label2.Text = "TOTAL:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(334, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 25)
        Label1.TabIndex = 0
        Label1.Text = "$$$$$$"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(15, 23)
        Label3.Name = "Label3"
        Label3.Size = New Size(189, 25)
        Label3.TabIndex = 9
        Label3.Text = "EFECTIVO RECIBIDO:"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ActiveBorder
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(TextBox2)
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(12, 551)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(633, 81)
        Panel2.TabIndex = 10
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(456, 23)
        Label5.Name = "Label5"
        Label5.Size = New Size(72, 25)
        Label5.TabIndex = 12
        Label5.Text = "$$$$$$"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label4.ForeColor = SystemColors.ControlText
        Label4.Location = New Point(366, 23)
        Label4.Name = "Label4"
        Label4.Size = New Size(84, 25)
        Label4.TabIndex = 11
        Label4.Text = "VUELTO:"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(210, 20)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(150, 31)
        TextBox2.TabIndex = 10
        TextBox2.Text = "$$$$$$$"
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button4.Location = New Point(868, 638)
        Button4.Name = "Button4"
        Button4.Size = New Size(295, 89)
        Button4.TabIndex = 11
        Button4.Text = "Confirmar e Imprimir Ticket"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {descripcion, cantidad, precio, eliminar})
        DataGridView1.Location = New Point(651, 28)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(663, 517)
        DataGridView1.TabIndex = 12
        ' 
        ' descripcion
        ' 
        descripcion.Frozen = True
        descripcion.HeaderText = "Descripcion"
        descripcion.MinimumWidth = 8
        descripcion.Name = "descripcion"
        descripcion.ReadOnly = True
        descripcion.Width = 150
        ' 
        ' cantidad
        ' 
        cantidad.Frozen = True
        cantidad.HeaderText = "Cantidad"
        cantidad.MinimumWidth = 8
        cantidad.Name = "cantidad"
        cantidad.ReadOnly = True
        cantidad.Width = 150
        ' 
        ' precio
        ' 
        precio.Frozen = True
        precio.HeaderText = "Precio"
        precio.MinimumWidth = 8
        precio.Name = "precio"
        precio.ReadOnly = True
        precio.Width = 150
        ' 
        ' eliminar
        ' 
        eliminar.Frozen = True
        eliminar.HeaderText = "Eliminar"
        eliminar.MinimumWidth = 8
        eliminar.Name = "eliminar"
        eliminar.ReadOnly = True
        eliminar.Width = 150
        ' 
        ' DataGridView2
        ' 
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Location = New Point(12, 70)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.RowHeadersWidth = 62
        DataGridView2.Size = New Size(633, 475)
        DataGridView2.TabIndex = 13
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1326, 756)
        Controls.Add(DataGridView2)
        Controls.Add(DataGridView1)
        Controls.Add(Button4)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(TextBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form2"
        Text = "Form2"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents eliminar As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
End Class
