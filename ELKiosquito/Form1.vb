Public Class Form1
    Private FilaSeleccionada As Integer = -1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBContraseña.UseSystemPasswordChar = True
        ManejarEstadoBotones(True) ' Iniciamos en Estado de Creación
    End Sub

    ' --- MÁQUINA DE ESTADOS ---
    Private Sub ManejarEstadoBotones(modoCreacion As Boolean)
        BTAgrearU.Enabled = modoCreacion
        BTEditarU.Enabled = Not modoCreacion
        BTEliminarU.Enabled = Not modoCreacion
    End Sub

    ' --- FUNCIÓN DE VALIDACIÓN ÚNICA ---
    Private Function ExisteUsuario(nombreUsuario As String, filaIgnorada As Integer) As Boolean
        For Each fila As DataGridViewRow In DGVUsuarios.Rows
            If Not fila.IsNewRow Then
                If fila.Cells("DVUsuario").Value?.ToString().ToLower() = nombreUsuario.ToLower() AndAlso fila.Index <> filaIgnorada Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    ' --- 1. CREATE: Agregar Usuario ---
    Private Sub BTAgrearU_Click(sender As Object, e As EventArgs) Handles BTAgrearU.Click

        ' Validación estricta
        If String.IsNullOrWhiteSpace(TBUsuario.Text) OrElse String.IsNullOrWhiteSpace(TBContraseña.Text) OrElse CBRol.SelectedIndex = -1 Then
            MessageBox.Show("Usuario, Contraseña y Rol son campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If ExisteUsuario(TBUsuario.Text, -1) Then
            MessageBox.Show("El nombre de usuario ya existe.", "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Controlé los datos y rol antes de agregar", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' TODO: INSERT a Base de Datos aquí

            ' El orden debe ser igual al del diseñador de la grilla
            DGVUsuarios.Rows.Add(TBNombre.Text, TBApellido.Text, TBUsuario.Text, CBRol.Text, "Seleccionar", TBContraseña.Text)

            LimpiarCampos()
        End If
    End Sub

    ' --- 2. READ: Clic en "Seleccionar" ---
    Private Sub DGVUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUsuarios.CellContentClick
        If e.RowIndex >= 0 AndAlso DGVUsuarios.Columns(e.ColumnIndex).Name = "DVSeleccionar" Then
            FilaSeleccionada = e.RowIndex
            Dim fila = DGVUsuarios.Rows(FilaSeleccionada)

            TBNombre.Text = fila.Cells("DVNombre").Value?.ToString()
            TBApellido.Text = fila.Cells("DVApellido").Value?.ToString()
            TBUsuario.Text = fila.Cells("DVUsuario").Value?.ToString()
            CBRol.Text = fila.Cells("DVRol").Value?.ToString()

            ' Dejamos la contraseña en blanco. Si escribe algo, la cambia. Si no, conserva la oculta.
            TBContraseña.Clear()

            ManejarEstadoBotones(False) ' Pasamos a Estado de Edición
        End If
    End Sub

    ' --- 3. UPDATE: Editar Usuario ---
    Private Sub BTEditarU_Click(sender As Object, e As EventArgs) Handles BTEditarU.Click
        If FilaSeleccionada >= 0 Then
            If String.IsNullOrWhiteSpace(TBUsuario.Text) OrElse CBRol.SelectedIndex = -1 Then
                MessageBox.Show("Usuario y Rol no pueden estar vacíos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If MessageBox.Show("Controlé los datos y rol antes de editar", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If ExisteUsuario(TBUsuario.Text, FilaSeleccionada) Then
                    MessageBox.Show("El nombre de usuario ya está en uso.", "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim fila = DGVUsuarios.Rows(FilaSeleccionada)

                ' Lógica condicional de contraseña
                Dim nuevaContrasena As String = fila.Cells("DVContraseña").Value?.ToString()
                If Not String.IsNullOrWhiteSpace(TBContraseña.Text) Then
                    nuevaContrasena = TBContraseña.Text ' Solo actualiza si escribió algo nuevo
                End If

                ' TODO: UPDATE a Base de Datos aquí usando nuevaContrasena

                ' Actualizar Grilla
                fila.Cells("DVNombre").Value = TBNombre.Text
                fila.Cells("DVApellido").Value = TBApellido.Text
                fila.Cells("DVUsuario").Value = TBUsuario.Text
                fila.Cells("DVContraseña").Value = nuevaContrasena
                fila.Cells("DVRol").Value = CBRol.Text

                MessageBox.Show("Usuario editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
            End If
        End If
    End Sub

    ' --- 4. DELETE: Eliminar Usuario ---
    Private Sub BTEliminarU_Click(sender As Object, e As EventArgs) Handles BTEliminarU.Click
        If FilaSeleccionada >= 0 Then
            If MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' TODO: DELETE a Base de Datos aquí

                DGVUsuarios.Rows.RemoveAt(FilaSeleccionada)
                LimpiarCampos()
            End If
        End If
    End Sub

    ' --- 5. SEARCH: Buscar Usuario ---
    Private Sub BTBuscarU_Click(sender As Object, e As EventArgs) Handles BTBuscarU.Click
        Dim busqueda As String = TBUsuario.Text.Trim()

        ' Validar que el usuario haya escrito algo en el campo
        If String.IsNullOrWhiteSpace(busqueda) Then
            MessageBox.Show("Por favor, ingrese un nombre de usuario en el campo 'Usuario' para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim encontrado As Boolean = False

        ' Recorrer la grilla para buscar la coincidencia
        For Each fila As DataGridViewRow In DGVUsuarios.Rows
            If Not fila.IsNewRow Then
                Dim usuarioGrilla As String = fila.Cells("DVUsuario").Value?.ToString()

                ' Compara ignorando mayúsculas y minúsculas
                If String.Equals(usuarioGrilla, busqueda, StringComparison.OrdinalIgnoreCase) Then
                    encontrado = True
                    FilaSeleccionada = fila.Index

                    ' Autocompletar los campos con los datos encontrados
                    TBNombre.Text = fila.Cells("DVNombre").Value?.ToString()
                    TBApellido.Text = fila.Cells("DVApellido").Value?.ToString()
                    TBUsuario.Text = fila.Cells("DVUsuario").Value?.ToString()
                    CBRol.Text = fila.Cells("DVRol").Value?.ToString()
                    TBContraseña.Clear()

                    ManejarEstadoBotones(False) ' Pasamos a Estado de Edición

                    ' Opcional: Resaltar la fila en la grilla
                    fila.Selected = True
                    DGVUsuarios.CurrentCell = fila.Cells("DVUsuario") ' Mueve el foco a esa fila

                    Exit For ' Detiene el bucle ya que el usuario es único
                End If
            End If
        Next

        ' Si termina el bucle y no se encontró
        If Not encontrado Then
            MessageBox.Show("No se encontró ningún usuario con el nombre '" & busqueda & "'.", "Búsqueda fallida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Opcional: Limpiar el campo para que intente de nuevo
            TBUsuario.Focus()
            TBUsuario.SelectAll()
        End If
    End Sub

    ' --- 6. CANCEL: Cancelar Acción ---
    Private Sub BTCancelar_Click(sender As Object, e As EventArgs) Handles BTCancelar.Click
        LimpiarCampos()
    End Sub

    ' --- HELPER: Reiniciar UI ---
    Private Sub LimpiarCampos()
        TBNombre.Clear()
        TBApellido.Clear()
        TBUsuario.Clear()
        TBContraseña.Clear()
        CBRol.SelectedIndex = -1
        FilaSeleccionada = -1

        ManejarEstadoBotones(True) ' Volvemos al Estado de Creación
    End Sub

End Class