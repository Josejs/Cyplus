Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop 'LIBRERIA PARA MANDAR A EXCEL LOS DATOS
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Configuration.ConfigurationManager
Public Class REGCALIDAD
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


    Private Sub REGCALIDAD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If CheckBox2.Checked = True Then
                LlamarDatos("SELECT * FROM TRAZA ")
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

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            If CheckBox2.Checked = True Then
                LlamarDatos("SELECT * FROM TRAZA ")
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
            LlamarDatos("SELECT * FROM TRAZA WHERE ISOMETRICO_T LIKE '%" & TextBox2.Text & "%' ORDER BY ISOMETRICO_T ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value) Then
                CALIDADFR.TXTXDI.Text = "-"
            Else
                CALIDADFR.TXTXDI.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value) Then
                CALIDADFR.TXTNUMEROISO.Text = "-"
            Else
                CALIDADFR.TXTNUMEROISO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value) Then
                CALIDADFR.TXTXJUNTA.Text = "-"
            Else
                CALIDADFR.TXTXJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value) Then
                CALIDADFR.TXTXPND.Text = "-"
            Else
                CALIDADFR.TXTXPND.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value) Then
                CALIDADFR.TXT1ERATOMA.Text = "-"
            Else
                CALIDADFR.TXT1ERATOMA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value) Then
                CALIDADFR.TXTNOREPORTE1ERATOMA.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTE1ERATOMA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value) Then
                CALIDADFR.TXTFECHAREPORTE1ERATOMA.Text = "-"
            Else
                CALIDADFR.TXTFECHAREPORTE1ERATOMA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value) Then
                CALIDADFR.TXTRESULTADO1ERATOMA.Text = "-"
            Else
                CALIDADFR.TXTRESULTADO1ERATOMA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value) Then
                CALIDADFR.TXTXPRIMERREPARACION.Text = "-"
            Else
                CALIDADFR.TXTXPRIMERREPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value) Then
                CALIDADFR.TXTNOREPORTE1REPARACION.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTE1REPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value) Then
                CALIDADFR.TXTFECHA1REPARACION.Text = "-"
            Else
                CALIDADFR.TXTFECHA1REPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value) Then
                CALIDADFR.TXTFECHA1REPARACION.Text = "-"
            Else
                CALIDADFR.TXTFECHA1REPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value) Then
                CALIDADFR.TXTRESULTADOPRIMERAREPARACION.Text = "-"
            Else
                CALIDADFR.TXTRESULTADOPRIMERAREPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value) Then
                CALIDADFR.TXTXSEGUNDAREPARACION.Text = "-"
            Else
                CALIDADFR.TXTXSEGUNDAREPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value) Then
                CALIDADFR.TXTNOREPSEGUNDAREPARACION.Text = "-"
            Else
                CALIDADFR.TXTNOREPSEGUNDAREPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value) Then
                CALIDADFR.TXTFECHA2REPARACION.Text = "-"
            Else
                CALIDADFR.TXTFECHA2REPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value) Then
                CALIDADFR.TXTRESULTADOSEGUNDAREPARACION.Text = "-"
            Else
                CALIDADFR.TXTRESULTADOSEGUNDAREPARACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value) Then
                CALIDADFR.TXTLIQUIDO.Text = "-"
            Else
                CALIDADFR.TXTLIQUIDO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value) Then
                CALIDADFR.TXTNOREPORTELIQUIDO.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTELIQUIDO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value) Then
                CALIDADFR.TXTFECHAREPORTELIQUIDO.Text = "-"
            Else
                CALIDADFR.TXTFECHAREPORTELIQUIDO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value) Then
                CALIDADFR.TXTXPW.Text = "-"
            Else
                CALIDADFR.TXTXPW.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value) Then
                CALIDADFR.TXTNOREPORTEPWHT.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTEPWHT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value) Then
                CALIDADFR.TXTFECHAPWHT.Text = "-"
            Else
                CALIDADFR.TXTFECHAPWHT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value) Then
                CALIDADFR.TXTXDUREZA.Text = "-"
            Else
                CALIDADFR.TXTXDUREZA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value) Then
                CALIDADFR.TXTNOREPORTEDUREZA.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTEDUREZA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(24).Value) Then
                CALIDADFR.TXTFECHADUREZA.Text = "-"
            Else
                CALIDADFR.TXTFECHADUREZA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(24).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(25).Value) Then
                CALIDADFR.TXTXRESULTADODUREZA.Text = "-"
            Else
                CALIDADFR.TXTXRESULTADODUREZA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(25).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(26).Value) Then
                CALIDADFR.TXTUT.Text = "-"
            Else
                CALIDADFR.TXTUT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(26).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(27).Value) Then
                CALIDADFR.TXTXUTNOREPORT.Text = "-"
            Else
                CALIDADFR.TXTXUTNOREPORT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(27).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(28).Value) Then
                CALIDADFR.TXTUTRESULTADO.Text = "-"
            Else
                CALIDADFR.TXTUTRESULTADO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(28).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(29).Value) Then
                CALIDADFR.TXTXMT.Text = "-"
            Else
                CALIDADFR.TXTXMT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(29).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(30).Value) Then
                CALIDADFR.TXTNOREPORTMT.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTMT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(30).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(31).Value) Then
                CALIDADFR.TXTFECHAREPORTMT.Text = "-"
            Else
                CALIDADFR.TXTFECHAREPORTMT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(31).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(32).Value) Then
                CALIDADFR.TXTXPMI.Text = "-"
            Else
                CALIDADFR.TXTXPMI.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(32).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(33).Value) Then
                CALIDADFR.TXTNOREPORTPMI.Text = "-"
            Else
                CALIDADFR.TXTNOREPORTPMI.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(33).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(34).Value) Then
                CALIDADFR.TXTFECHAREPORTPMI.Text = "-"
            Else
                CALIDADFR.TXTFECHAREPORTPMI.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(34).Value
            End If
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(35).Value) Then
                CALIDADFR.TXTSPOOL.Text = "-"
            Else
                CALIDADFR.TXTSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(35).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(36).Value) Then
                CALIDADFR.CBTI.Text = "-"
            Else
                CALIDADFR.CBTI.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(36).Value
            End If


            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(37).Value) Then
                CALIDADFR.CBSERVICIO.Text = "-"
            Else
                CALIDADFR.CBSERVICIO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(37).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(38).Value) Then
                CALIDADFR.CBESPECIFICACION.Text = "-"
            Else
                CALIDADFR.CBESPECIFICACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(38).Value
            End If


            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(39).Value) Then
                CALIDADFR.CBT2.Text = "-"
            Else
                CALIDADFR.CBT2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(39).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(40).Value) Then
                CALIDADFR.CBSOLDADOR.Text = "-"
            Else
                CALIDADFR.CBSOLDADOR.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(40).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Not CheckBox2.Checked Then
            TextBox2.Enabled = True

            TextBox2.Text = ""
            TXTNUMEROREPORT.Enabled = True
            TXTNUMEROREPORT.Text = ""
            TXTFECHA_REPORTE.Text = ""
            TXTFECHA_REPORTE.Enabled = True
        Else
            TextBox2.Enabled = False

            TextBox2.Text = ""
            TXTNUMEROREPORT.Enabled = False
            TXTNUMEROREPORT.Text = ""
            TXTFECHA_REPORTE.Text = ""
            TXTFECHA_REPORTE.Enabled = False
        End If
    End Sub

    Private Sub TXTNUMEROREPORT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNUMEROREPORT.TextChanged
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM TRAZA WHERE NO_REPORTE LIKE '%" & TXTNUMEROREPORT.Text & "%' ORDER BY NO_REPORTE ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub TXTFECHA_REPORTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFECHA_REPORTE.TextChanged
        If RadioButton3.Checked Then
            LlamarDatos("SELECT * FROM TRAZA WHERE FECHA_REPORTE LIKE '%" & TXTFECHA_REPORTE.Text & "%' ORDER BY FECHA_REPORTE ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub
End Class