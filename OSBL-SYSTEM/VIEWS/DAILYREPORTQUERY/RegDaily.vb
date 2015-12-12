Imports System.Data
Imports System.Data.SqlClient
Public Class RegDaily
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

    Private Sub RegDaily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If CheckBox2.Checked = True Then
                LlamarDatos("SELECT * FROM RDQ ")
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

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            If CheckBox2.Checked = True Then
                LlamarDatos("SELECT * FROM RDQ ")
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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If RadioButton2.Checked Then
            LlamarDatos("SELECT * FROM RDQ WHERE SPOOL LIKE '%" & TextBox2.Text & "%' ")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Not CheckBox2.Checked Then
            TextBox2.Enabled = True

            TextBox2.Text = ""
        Else
            TextBox2.Enabled = False

            TextBox2.Text = ""

        End If
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            DAILYREPORT.TXTIDDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            DAILYREPORT.TXTISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            DAILYREPORT.TXTSPOOLDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            DAILYREPORT.TXTSPOOLUNIDODAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value

            DAILYREPORT.TXTJUNTADAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            DAILYREPORT.TXTTIPOJUNTADAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            DAILYREPORT.TXTXDIAMETRODAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value

            DAILYREPORT.TXTCT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            DAILYREPORT.TXTFONDEODAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            DAILYREPORT.TXTRELLENODAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            DAILYREPORT.TXTCLAVETUBDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            DAILYREPORT.TXTSOLDADURADAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            DAILYREPORT.TXTARMADODAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value


            DAILYREPORT.TXTCODIGODAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            DAILYREPORT.TXTDESCRIPCIONDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            DAILYREPORT.TXTCOLADADAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value

            DAILYREPORT.TXTCODIGODAILY2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            DAILYREPORT.TXTDESC2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            DAILYREPORT.TXTCOLADA2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value



            DAILYREPORT.TXTWPSDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            DAILYREPORT.TXTESPECIFICACIONDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value
            DAILYREPORT.TXTRXDAILY.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
End Class