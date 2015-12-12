Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class REGISTROALMACEN

#Region "METODOS"
    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
#End Region


    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub REGISTROALMACEN_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            If CheckBox1.Checked = True Then
                LlamarDatos("SELECT * FROM ALMACEN ")
                DT = New DataTable
                ADP.Fill(DT)
                DataGridView1.DataSource = DT
                TextBox1.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not CheckBox1.Checked Then
            TextBox1.Enabled = True

            TextBox1.Text = ""
        Else
            TextBox1.Enabled = False

            TextBox1.Text = ""

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM ALMACEN WHERE CODIGO_MATERIAL LIKE '%" & TextBox1.Text & "%' ")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            ENTRADA_SALIDAS.TXIDENTRADA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            ENTRADA_SALIDAS.TXENTRADACODIGO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            ENTRADA_SALIDAS.TXENTRADAMATERIAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            ENTRADA_SALIDAS.TXENTRADACANTIDAD.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
            ENTRADA_SALIDAS.TXENTRADALOTE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            ENTRADA_SALIDAS.TXENTRADAUNIDAD.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            ENTRADA_SALIDAS.DTENTRADAFECHA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            ENTRADA_SALIDAS.TXENTRADACERTIFICADOS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            ENTRADA_SALIDAS.TXENTRADACOLADA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            ENTRADA_SALIDAS.TXENTRADAFABRICANTE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            ENTRADA_SALIDAS.TXENTRADADESCRIPCION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            ENTRADA_SALIDAS.TXNUMCERTIFICADO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            ENTRADA_SALIDAS.TXDESCCORTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            ENTRADA_SALIDAS.TXTCODCLIENTE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            ENTRADA_SALIDAS.TXCERTIFICADOTCM.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            ENTRADA_SALIDAS.TXTDIAMETROALMACEN.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            ENTRADA_SALIDAS.TXTCEDULAALMACEN.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            ENTRADA_SALIDAS.TXTPESOALMACEN.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            ENTRADA_SALIDAS.txtcedula2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            ENTRADA_SALIDAS.txtdiametro2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            ENTRADA_SALIDAS.TXTPESTOTAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value
            ENTRADA_SALIDAS.TXENTRADACOLADA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
            ENTRADA_SALIDAS.TXTITEM.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            If CheckBox1.Checked = True Then
                LlamarDatos("SELECT * FROM ALMACEN ")
                DT = New DataTable
                ADP.Fill(DT)
                DataGridView1.DataSource = DT
                TextBox1.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class