Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class FRMREGMATS
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

    Private Sub FRMREGMATS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Try
        'If CheckBox1.Checked = True Then
        'LlamarDatos("SELECT * FROM MAT_ISO ")
        'DT = New DataTable
        'ADP.Fill(DT)
        'DataGridView1.DataSource = DT
        'TextBox1.Enabled = False

        'End If
        'Catch ex As Exception
        ' MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' End Try
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

            LlamarDatos("SELECT * FROM MAT_ISO ")
            DT = New DataTable
            ADP.Fill(DT)
            DataGridView1.DataSource = DT


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not CheckBox1.Checked Then
            TextBox1.Enabled = True
           
            TextBox1.Text = ""
        Else
            TextBox1.Enabled = False

            TextBox1.Text = ""
           
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
       
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            BASICDATA.MATID.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value) Then
                BASICDATA.MATISOMETRICO.Text = 0
            Else
                BASICDATA.MATISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value) Then

                BASICDATA.TXTHOJAMATERIAL.Text = "-"
            Else
                BASICDATA.TXTHOJAMATERIAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            End If


            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value) Then

                BASICDATA.TXTHOJATOTALMATERIAL.Text = "-"
            Else
                BASICDATA.TXTHOJATOTALMATERIAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value) Then
                BASICDATA.TXTNUMSPOOLMATERIAL.Text = "-"

            Else
                BASICDATA.TXTNUMSPOOLMATERIAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value) Then

                BASICDATA.TXTREVSPOOLMATERIAL.Text = "-"
            Else
                BASICDATA.TXTREVSPOOLMATERIAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value) Then

                BASICDATA.TXTSPOOLUNIDOMATERIAL.Text = "-"
            Else
                BASICDATA.TXTSPOOLUNIDOMATERIAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value) Then

                BASICDATA.MATCODIGOtcm.Text = "-"
            Else
                BASICDATA.MATCODIGOtcm.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value) Then

                BASICDATA.MATIDENTIFICADOR.Text = 0
            Else
                BASICDATA.MATIDENTIFICADOR.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value) Then

                BASICDATA.MATPESO.Text = 0
            Else
                BASICDATA.MATPESO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value) Then

                BASICDATA.MATCOLADA.Text = "-"
            Else
                BASICDATA.MATCOLADA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value) Then
                BASICDATA.MATFABRICANTESSSSS.Text = "-"

            Else
                BASICDATA.MATFABRICANTESSSSS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value) Then

                BASICDATA.TXTDESCRIPCIONMAT.Text = "-"
            Else
                BASICDATA.TXTDESCRIPCIONMAT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value) Then

                BASICDATA.TXTCATEGORIAMAT.Text = "-"
            Else
                BASICDATA.TXTCATEGORIAMAT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value) Then

                BASICDATA.TXTCANTIDADMAT.Text = "-"
            Else
                BASICDATA.TXTCANTIDADMAT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value) Then
                BASICDATA.TXTUNIDADMAT.Text = "-"

            Else
                BASICDATA.TXTUNIDADMAT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value) Then
                BASICDATA.TXTDIAMETROMAT.Text = "-"

            Else
                BASICDATA.TXTDIAMETROMAT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value) Then

                BASICDATA.XTXTDIAM2.Text = "-"
            Else
                BASICDATA.XTXTDIAM2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value) Then

                BASICDATA.MATERIALCODIGOCLIENTE.Text = "-"
            Else
                BASICDATA.MATERIALCODIGOCLIENTE.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub VERREGISTROSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VERREGISTROSToolStripMenuItem.Click
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM MAT_ISO WHERE ISOMETRICO ='" & TextBox1.Text & "' ORDER BY CODIGO_MAT ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
    End Sub
End Class