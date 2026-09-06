Imports Microsoft.Data.SqlClient
Public Class Form1
    Private cadenaConexion As String = "Server=.\SQLEXPRESS;Database=SistemaUsuarios;Integrated Security=true; TrustServerCertificate=True;"
    Private FilaSeleccionada As Integer = -1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBContraseña.UseSystemPasswordChar = True
        ManejarEstadoBotones(True) ' Iniciamos en Estado de Creación
        CargarUsuariosDesdeBD()
    End Sub
    Private Sub CargarUsuariosDesdeBD()
        DGVUsuarios.Rows.Clear()
        Dim query As String = "SELECT Nombre, Apellido, Usuario, Contrasena, Rol FROM Usuarios"
        Try
            Using conexion As New SqlConnection(cadenaConexion)
                Using comando As New SqlCommand(query, conexion)
                    conexion.Open()
                    Using lector As SqlDataReader = comando.ExecuteReader()
                        While lector.Read()
                            DGVUsuarios.Rows.Add(
                                lector("Nombre").ToString(),
                                lector("Apellido").ToString(),
                                lector("Usuario").ToString(),
                                lector("Rol").ToString(),
                                "Seleccionar",
                                lector("Contrasena").ToString()
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

            Dim query As String = "INSERT INTO Usuarios (Nombre, Apellido, Usuario, Contrasena, Rol) VALUES (@nombre, @apellido, @usuario, @contrasena, @rol)"
            Try
                Using conexion As New SqlConnection(cadenaConexion)
                    Using comando As New SqlCommand(query, conexion)
                        comando.Parameters.AddWithValue("@nombre", TBNombre.Text)
                        comando.Parameters.AddWithValue("@apellido", TBApellido.Text)
                        comando.Parameters.AddWithValue("@usuario", TBUsuario.Text)
                        comando.Parameters.AddWithValue("@contrasena", TBContraseña.Text)
                        comando.Parameters.AddWithValue("@rol", CBRol.Text)
                        conexion.Open()
                        comando.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al guardar en BD: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Sale de la función para no agregarlo a la grilla si falló la BD
            End Try

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

                Dim usuarioOriginal As String = fila.Cells("DVUsuario").Value.ToString()
                Dim query As String = "UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, Usuario = @nuevoUsuario, Contrasena = @contrasena, Rol = @rol WHERE Usuario = @usuarioOriginal"

                Try
                    Using conexion As New SqlConnection(cadenaConexion)
                        Using comando As New SqlCommand(query, conexion)
                            comando.Parameters.AddWithValue("@nombre", TBNombre.Text)
                            comando.Parameters.AddWithValue("@apellido", TBApellido.Text)
                            comando.Parameters.AddWithValue("@nuevoUsuario", TBUsuario.Text)
                            comando.Parameters.AddWithValue("@contrasena", nuevaContrasena)
                            comando.Parameters.AddWithValue("@rol", CBRol.Text)
                            comando.Parameters.AddWithValue("@usuarioOriginal", usuarioOriginal)
                            conexion.Open()
                            comando.ExecuteNonQuery()
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar BD: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try

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

                Dim usuarioAEliminar As String = DGVUsuarios.Rows(FilaSeleccionada).Cells("DVUsuario").Value.ToString()
                Dim query As String = "DELETE FROM Usuarios WHERE Usuario = @usuario"

                Try
                    Using conexion As New SqlConnection(cadenaConexion)
                        Using comando As New SqlCommand(query, conexion)
                            comando.Parameters.AddWithValue("@usuario", usuarioAEliminar)
                            conexion.Open()
                            comando.ExecuteNonQuery()
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar de BD: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try

                DGVUsuarios.Rows.RemoveAt(FilaSeleccionada)
                LimpiarCampos()
            End If
        End If
    End Sub

    ' --- 5. SEARCH: Buscar Usuario (Versión SQL) ---
    Private Sub BTBuscarU_Click(sender As Object, e As EventArgs) Handles BTBuscarU.Click
        Dim busqueda As String = TBUsuario.Text.Trim()

        If String.IsNullOrWhiteSpace(busqueda) Then
            MessageBox.Show("Por favor, ingrese un nombre de usuario en el campo 'Usuario' para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query As String = "SELECT Nombre, Apellido, Usuario, Contrasena, Rol FROM Usuarios WHERE Usuario = @usuarioBuscado"

        Try
            Using conexion As New SqlConnection(cadenaConexion)
                Using comando As New SqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@usuarioBuscado", busqueda)

                    conexion.Open()
                    Using lector As SqlDataReader = comando.ExecuteReader()
                        If lector.Read() Then
                            ' El usuario existe en la BD, cargamos los datos en los TextBoxes
                            TBNombre.Text = lector("Nombre").ToString()
                            TBApellido.Text = lector("Apellido").ToString()
                            TBUsuario.Text = lector("Usuario").ToString()
                            CBRol.Text = lector("Rol").ToString()
                            TBContraseña.Clear()

                            ManejarEstadoBotones(False) ' Pasamos a Estado de Edición

                            ' Resaltar la fila correspondiente en la grilla visualmente
                            For Each fila As DataGridViewRow In DGVUsuarios.Rows
                                If Not fila.IsNewRow AndAlso fila.Cells("DVUsuario").Value?.ToString().ToLower() = busqueda.ToLower() Then
                                    fila.Selected = True
                                    DGVUsuarios.CurrentCell = fila.Cells("DVUsuario")
                                    FilaSeleccionada = fila.Index
                                    Exit For
                                End If
                            Next
                        Else
                            MessageBox.Show("No se encontró ningún usuario con el nombre '" & busqueda & "'.", "Búsqueda fallida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TBUsuario.Focus()
                            TBUsuario.SelectAll()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al buscar en la BD: " & ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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