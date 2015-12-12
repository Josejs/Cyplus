Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class FRMPAINT
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

    Private Sub FRMPAINT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Try
        'If CheckBox1.Checked = True Then
        'LlamarDatos("SELECT*FROM TBL_SPOOL")
        ' DT = New DataTable
        '  ADP.Fill(DT)
        '   DataGridView1.DataSource = DT
        '    TextBox1.Enabled = False

        '    End If
        '    Catch ex As Exception
        'MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        '   Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not CheckBox1.Checked Then
            TextBox1.Enabled = True

            TextBox1.Text = ""
        Else
            TextBox1.Enabled = False

            TextBox1.Text = ""

        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
      
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            BASICDATA.TXIDSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value) Then
                BASICDATA.TXNUMEROSPOOL.Text = "-"
            Else
                BASICDATA.TXNUMEROSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value) Then
                BASICDATA.TXSPOOL.Text = "-"
            Else
                BASICDATA.TXSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value) Then
                BASICDATA.TXREVSPOOL.Text = "-"
            Else
                BASICDATA.TXREVSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value) Then
                BASICDATA.CBNUMEROISOMETRICOSPOOL.Text = "-"
            Else
                BASICDATA.CBNUMEROISOMETRICOSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value) Then
                BASICDATA.TXHOJASPOOL.Text = "-"
            Else
                BASICDATA.TXHOJASPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value) Then
                BASICDATA.TXTCANTIDADHOJAS.Text = "-"
            Else
                BASICDATA.TXTCANTIDADHOJAS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value) Then
                BASICDATA.TXESTADOSPOOL.Text = "-"
            Else
                BASICDATA.TXESTADOSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value) Then
                BASICDATA.TXSISTEMASPOOL.Text = "-"
            Else
                BASICDATA.TXSISTEMASPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value) Then
                BASICDATA.TXPESOSPOOL.Text = "-"
            Else
                BASICDATA.TXPESOSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value) Then
                BASICDATA.TXTIPOSPOOL.Text = "-"
            Else
                BASICDATA.TXTIPOSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value) Then
                BASICDATA.DTFECHACORTESPOOL.Text = "-"
            Else
                BASICDATA.DTFECHACORTESPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value) Then
                BASICDATA.DTFECHAARMADOSPOOL.Text = "-"
            Else
                BASICDATA.DTFECHAARMADOSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value) Then
                BASICDATA.DTFECHASOLDSPOOL.Text = "-"
            Else
                BASICDATA.DTFECHASOLDSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value) Then
                BASICDATA.TXESPECIFICACIONSPOOL.Text = "-"
            Else
                BASICDATA.TXESPECIFICACIONSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value) Then
                BASICDATA.TXDIAMETROSPOOL.Text = "-"
            Else
                BASICDATA.TXDIAMETROSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value) Then
                BASICDATA.TXPULGADASPOOL.Text = "-"
            Else
                BASICDATA.TXPULGADASPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value) Then
                BASICDATA.TXOBSERVACIONSPOOL.Text = "-"
            Else
                BASICDATA.TXOBSERVACIONSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value) Then
                BASICDATA.TXJUNTASSPOOL.Text = "-"
            Else
                BASICDATA.TXJUNTASSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value) Then
                BASICDATA.TXREGSPOOL.Text = "-"
            Else
                BASICDATA.TXREGSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value) Then
                BASICDATA.TXCONSECUTIVOINTERNO.Text = "-"
            Else
                BASICDATA.TXCONSECUTIVOINTERNO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value) Then
                BASICDATA.TXTXPND.Text = "-"
            Else
                BASICDATA.TXTXPND.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value) Then
                BASICDATA.CBSERVICIO2W.Text = "-"
            Else
                BASICDATA.CBSERVICIO2W.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value) Then
                BASICDATA.PSAND.Value = Nothing
            Else
                BASICDATA.PSAND.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(24).Value) Then
                BASICDATA.PENLACE.Value = Nothing
            Else
                BASICDATA.PENLACE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(24).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(25).Value) Then
                BASICDATA.PACABADO.Value = Nothing
            Else
                BASICDATA.PACABADO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(25).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(26).Value) Then
                BASICDATA.PLIBERACION.Value = Nothing
            Else
                BASICDATA.PLIBERACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(26).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(27).Value) Then
                BASICDATA.PCOMPAÑIA.Text = "-"
            Else
                BASICDATA.PCOMPAÑIA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(27).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(28).Value) Then
                BASICDATA.PAREA.Text = "-"
            Else
                BASICDATA.PAREA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(28).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(29).Value) Then
                BASICDATA.POBSERVACION.Text = "-"
            Else
                BASICDATA.POBSERVACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(29).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(30).Value) Then
                BASICDATA.PNUMEROREP.Text = "-"
            Else
                BASICDATA.PNUMEROREP.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(30).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(31).Value) Then
                BASICDATA.PNOORDEN.Text = "-"
            Else
                BASICDATA.PNOORDEN.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(31).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(32).Value) Then
                BASICDATA.PFECHAORDEN.Value = Nothing

            Else
                BASICDATA.PFECHAORDEN.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(32).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(33).Value) Then
                BASICDATA.PCANTIDAD.Text = "-"
            Else
                BASICDATA.PCANTIDAD.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(33).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(34).Value) Then
                BASICDATA.PNOEMBARQUE.Text = "-"
            Else
                BASICDATA.PNOEMBARQUE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(34).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(35).Value) Then
                BASICDATA.PFECHAEMBARQUE.Value = Nothing
            Else
                BASICDATA.PFECHAEMBARQUE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(35).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(36).Value) Then
                BASICDATA.TXTNOPACKING.Text = "0"
            Else
                BASICDATA.TXTNOPACKING.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(36).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(37).Value) Then
                BASICDATA.TXTFECHAPACKING.Value = Nothing
            Else
                BASICDATA.TXTFECHAPACKING.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(37).Value

            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(38).Value) Then
                BASICDATA.TXTAREA_SPO.Text = "-"
            Else
                BASICDATA.TXTAREA_SPO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(38).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(39).Value) Then
                BASICDATA.TXTMATERIALIBERACION.Text = "-"
            Else
                BASICDATA.TXTMATERIALIBERACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(39).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(40).Value) Then
                BASICDATA.TXTMTS.Text = "0"
            Else
                BASICDATA.TXTMTS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(40).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(42).Value) Then
                BASICDATA.SPOOL_NO_EST_SUBCONTRATISTA.Text = "-"
            Else
                BASICDATA.SPOOL_NO_EST_SUBCONTRATISTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(42).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(43).Value) Then
                BASICDATA.SPOOL_FECHA_ESTIMACION.Value = Nothing
            Else
                BASICDATA.SPOOL_FECHA_ESTIMACION.Value = Me.DataGridView1.Rows(e.RowIndex).Cells(43).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(44).Value) Then
                BASICDATA.SPOOL_FECHA_MONTADO.Value = Nothing
            Else
                BASICDATA.SPOOL_FECHA_MONTADO.Value = Me.DataGridView1.Rows(e.RowIndex).Cells(44).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(45).Value) Then
                BASICDATA.SPOOL_FECHA_ALINEADO.Value = Nothing
            Else
                BASICDATA.SPOOL_FECHA_ALINEADO.Value = Me.DataGridView1.Rows(e.RowIndex).Cells(45).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(45).Value) Then
                BASICDATA.SPOOL_FECHA_SOLDADO.Value = Nothing
            Else
                BASICDATA.SPOOL_FECHA_SOLDADO.Value = Me.DataGridView1.Rows(e.RowIndex).Cells(45).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            If CheckBox1.Checked = True Then
                LlamarDatos("SELECT * FROM TBL_SPOOL ")
                DT = New DataTable
                ADP.Fill(DT)
                DataGridView1.DataSource = DT
                TextBox1.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    
    Private Sub TXTESTADOSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTESTADOSPOOL.TextChanged
        If RESTADO.Checked Then
            LlamarDatos("SELECT * FROM TBL_SPOOL WHERE ESTADO LIKE '%" & TXTESTADOSPOOL.Text & "%'")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub


  
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If RFECHA.Checked Then
            LlamarDatos("SELECT * FROM TBL_SPOOL WHERE LIBERACION_PND LIKE '%" & TextBox2.Text & "%'")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub VERREGISTROSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VERREGISTROSToolStripMenuItem.Click
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM TBL_SPOOL WHERE NUMERO_ISOMETRICO='" & TextBox1.Text & "'")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub
End Class