

Public Class Form2

    ' Clase producto
    Public Class Product
        Public Property codigo As Integer
        Public Property nombre As String
        Public Property pprecio As Decimal
    End Class

    ' Generar lista de prueba
    Private Function GenerateSampleProducts(count As Integer) As List(Of Product)
        Dim list As New List(Of Product)
        For i As Integer = 1 To count
            list.Add(New Product With {
            .codigo = i,
            .nombre = $"Producto {i}",
            .pprecio = Math.Round(10D + i * 1.5D, 2)
        })
        Next
        Return list
    End Function

    ' En el Load del formulario o en un botón
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim samples = GenerateSampleProducts(10)
        DataGridView1.DataSource = samples
        ' Asignar la lista de Product directamente a DataGridView2
        DataGridView2.DataSource = samples
        ' Ocultar la columna Stock y ajustar encabezados/formatos si las columnas ya existen
        Try
            If DataGridView2.Columns.Contains("codigo") Then
                DataGridView2.Columns("codigo").HeaderText = "codigo"
            End If
            If DataGridView2.Columns.Contains("nombre") Then
                DataGridView2.Columns("nombre").HeaderText = "Nombre"
            End If
            If DataGridView2.Columns.Contains("pprecio") Then
                DataGridView2.Columns("pprecio").HeaderText = "Precio"
                DataGridView2.Columns("pprecio").DefaultCellStyle.Format = "C2"
            End If
        Catch
            ' Ignorar si las columnas no existen aún
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class