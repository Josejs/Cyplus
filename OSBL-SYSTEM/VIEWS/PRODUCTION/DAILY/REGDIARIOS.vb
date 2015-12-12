Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop


Public Class REGDIARIOS
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

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            If CheckBox2.Checked = True Then
                LlamarDatos("SELECT * FROM PRODUCCION_DIARIA ")
                DT = New DataTable
                ADP.Fill(DT)
                DataGridView2.DataSource = DT
                TextBox2.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Label1.Text = Me.DataGridView2.Rows.Count & " REGISTROS"
    End Sub

    Private Sub REGDIARIOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        'If CheckBox2.Checked = True Then
        ' LlamarDatos("SELECT * FROM PRODUCCION_DIARIA ")
        ' DT = New DataTable
        ' ADP.Fill(DT)
        ' DataGridView2.DataSource = DT
        ' TextBox2.Enabled = False

        'End If
        'Catch ex As Exception
        'MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'Label1.Text = Me.DataGridView2.Rows.Count & " REGISTROS"
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView2)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        '   If RadioButton2.Checked Then
        'LlamarDatos("SELECT * FROM PRODUCCION_DIARIA WHERE ISOMETRICO_P LIKE '%" & TextBox2.Text & "%'")
        'DT = New DataTable

        'ADP.Fill(DT)
        'DataGridView2.DataSource = DT
        'End If
        'Label1.Text = Me.DataGridView2.Rows.Count & " REGISTROS"
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

    Private Sub DataGridView2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Try
            
            PRODUCIONDIARIA.TXTID.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(0).Value



            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(1).Value) Then
                PRODUCIONDIARIA.TXTNOREPORTE.Text = "-"
            Else
                PRODUCIONDIARIA.TXTNOREPORTE.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(1).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(2).Value) Then
                PRODUCIONDIARIA.TXTXFECHARMADO.Text = "-"
            Else
                PRODUCIONDIARIA.TXTXFECHARMADO.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(2).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(3).Value) Then
                PRODUCIONDIARIA.TXTOTALJUNTAS.Text = "-"
            Else
                PRODUCIONDIARIA.TXTOTALJUNTAS.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(3).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(4).Value) Then
                PRODUCIONDIARIA.JUNTANUMISO.Text = "-"
            Else
                PRODUCIONDIARIA.JUNTANUMISO.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(4).Value
            End If



            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(5).Value) Then
                PRODUCIONDIARIA.TXTAREA.Text = "-"
            Else
                PRODUCIONDIARIA.TXTAREA.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(5).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(6).Value) Then
                PRODUCIONDIARIA.TXTHOJA.Text = "-"
            Else
                PRODUCIONDIARIA.TXTHOJA.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(6).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(7).Value) Then
                PRODUCIONDIARIA.TXTREVISION.Text = "-"
            Else
                PRODUCIONDIARIA.TXTREVISION.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(7).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(8).Value) Then
                PRODUCIONDIARIA.TXTJUNTA.Text = "-"
            Else
                PRODUCIONDIARIA.TXTJUNTA.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(8).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(9).Value) Then
                PRODUCIONDIARIA.JUNTATIPO1.Text = "-"
            Else
                PRODUCIONDIARIA.JUNTATIPO1.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(9).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(10).Value) Then
                PRODUCIONDIARIA.JUNTATIPO2.Text = "-"
            Else
                PRODUCIONDIARIA.JUNTATIPO2.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(10).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(11).Value) Then
                PRODUCIONDIARIA.TXTSPOOL.Text = "-"
            Else
                PRODUCIONDIARIA.TXTSPOOL.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(11).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(12).Value) Then
                PRODUCIONDIARIA.TXTDIAM.Text = "-"
            Else
                PRODUCIONDIARIA.TXTDIAM.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(12).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(13).Value) Then
                PRODUCIONDIARIA.TXTDIAM2.Text = "-"
            Else
                PRODUCIONDIARIA.TXTDIAM2.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(13).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(14).Value) Then
                PRODUCIONDIARIA.TXTTIPOJUNTA.Text = "-"
            Else
                PRODUCIONDIARIA.TXTTIPOJUNTA.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(14).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(15).Value) Then
                PRODUCIONDIARIA.TXTALLERCAMPO.Text = "-"
            Else
                PRODUCIONDIARIA.TXTALLERCAMPO.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(15).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(16).Value) Then
                PRODUCIONDIARIA.TXTF1.Text = "-"

            Else
                PRODUCIONDIARIA.TXTF1.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(16).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(17).Value) Then
                PRODUCIONDIARIA.TXTF2.Text = "-"
            Else
                PRODUCIONDIARIA.TXTF2.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(17).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(18).Value) Then
                PRODUCIONDIARIA.TXTR1.Text = "-"
            Else
                PRODUCIONDIARIA.TXTR1.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(18).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(19).Value) Then
                PRODUCIONDIARIA.TXTR2.Text = "-"
            Else
                PRODUCIONDIARIA.TXTR2.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(19).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(20).Value) Then
                PRODUCIONDIARIA.TXTSOLDADURA.Text = "-"
            Else
                PRODUCIONDIARIA.TXTSOLDADURA.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(20).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(21).Value) Then
                PRODUCIONDIARIA.TXTWPS.Text = "-"
            Else
                PRODUCIONDIARIA.TXTWPS.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(21).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(22).Value) Then
                PRODUCIONDIARIA.TXTOBSERVACIONES.Text = "-"
            Else
                PRODUCIONDIARIA.TXTOBSERVACIONES.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(22).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(23).Value) Then
                PRODUCIONDIARIA.TXTXCEDULA.Text = "-"
            Else
                PRODUCIONDIARIA.TXTXCEDULA.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(23).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(24).Value) Then
                PRODUCIONDIARIA.txtmaterial.Text = "-"
            Else
                PRODUCIONDIARIA.txtmaterial.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(24).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(25).Value) Then
                PRODUCIONDIARIA.TXTTUBERO.Text = "-"
            Else
                PRODUCIONDIARIA.TXTTUBERO.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(25).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(26).Value) Then
                PRODUCIONDIARIA.TXTPLGSTD.Text = "-"
            Else
                PRODUCIONDIARIA.TXTPLGSTD.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(26).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(27).Value) Then
                PRODUCIONDIARIA.TXTLINEAISOMETRIC.Text = "-"
            Else
                PRODUCIONDIARIA.TXTLINEAISOMETRIC.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(27).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(28).Value) Then
                PRODUCIONDIARIA.CBSERV.Text = "-"
            Else
                PRODUCIONDIARIA.CBSERV.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(28).Value
            End If


            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(29).Value) Then
                PRODUCIONDIARIA.CBESPEC.Text = "-"
            Else
                PRODUCIONDIARIA.CBESPEC.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(29).Value
            End If

            If IsDBNull(Me.DataGridView2.Rows(e.RowIndex).Cells(30).Value) Then
                PRODUCIONDIARIA.TXTDIAMETROORIGINAL.Text = "-"
            Else
                PRODUCIONDIARIA.TXTDIAMETROORIGINAL.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(30).Value
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   
    Private Sub DateTimeInput1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInput1.Click
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM PRODUCCION_DIARIA WHERE FECHA_SOLDADURA_P LIKE '%" & DateTimeInput1.Text & "%'")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView2.DataSource = DT
        End If
        Label1.Text = Me.DataGridView2.Rows.Count & " REGISTROS"
    End Sub

    Private Sub VERREGISTROSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VERREGISTROSToolStripMenuItem.Click
        LlamarDatos("SELECT * FROM PRODUCCION_DIARIA WHERE ISOMETRICO_P='" & TextBox2.Text & "'")
        DT = New DataTable
        ADP.Fill(DT)
        DataGridView2.DataSource = DT
    End Sub
End Class