Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class HIS_JUNTA
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

    Private Sub HIS_JUNTA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            If CheckBox2.Checked = True Then
                LlamarDatos("SELECT * FROM JUNTAS ")
                DT = New DataTable
                ADP.Fill(DT)
                DataGridView1.DataSource = DT
                TextBox2.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Not CheckBox2.Checked Then
            TextBox2.Enabled = True

            TextBox2.Text = ""
        Else
            TextBox2.Enabled = False

            TextBox2.Text = ""

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If RadioButton2.Checked Then
            LlamarDatos("SELECT * FROM JUNTAS WHERE NUM_ISO LIKE '%" & TextBox2.Text & "%' ORDER BY NUM_ISO ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub TXTESPECIFICACION_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTESPECIFICACION.TextChanged
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM JUNTAS WHERE ESPEC LIKE '%" & TXTESPECIFICACION.Text & "%' ")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
    End Sub

    Private Sub TSERV_TextChanged(sender As System.Object, e As System.EventArgs) Handles TSERV.TextChanged
        If RSERVICIO.Checked Then
            LlamarDatos("SELECT * FROM JUNTAS WHERE SERVICIO LIKE '%" & TSERV.Text & "%' ")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            ' BASICDATA.IDJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            '   BASICDATA.TOTALJUNTAS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            '  BASICDATA.PULGADASJUNTAS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            HISTORIAL_JUNTA.JUNTANUMISO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
            HISTORIAL_JUNTA.JUNTAHOJA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            HISTORIAL_JUNTA.JUNTAREVISION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            HISTORIAL_JUNTA.JUNTAJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            HISTORIAL_JUNTA.JUNTATIPO1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            HISTORIAL_JUNTA.JUNTATIPO2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            HISTORIAL_JUNTA.JUNTASPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            HISTORIAL_JUNTA.JUNTADIAM1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            HISTORIAL_JUNTA.JUNTADIAM2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            HISTORIAL_JUNTA.JUNTATIPOJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            HISTORIAL_JUNTA.JUNTACAMPOTALLER.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            HISTORIAL_JUNTA.JUNTAESPECIFICACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            HISTORIAL_JUNTA.cbserviciojunta.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            HISTORIAL_JUNTA.JUNTADIAMJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            HISTORIAL_JUNTA.JUNTAID1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            HISTORIAL_JUNTA.JUNTAID2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            HISTORIAL_JUNTA.JUNTACOLADA1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            HISTORIAL_JUNTA.JUNTACOLADA2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value
            HISTORIAL_JUNTA.JUNTADESC1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
            HISTORIAL_JUNTA.JUNTADESC2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value
            HISTORIAL_JUNTA.TXTPLGSTD.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value
            HISTORIAL_JUNTA.CBLINEA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(24).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub
End Class