Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class FRM_REG_FERRITA
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
    Sub LLENARGRID2()
        Try
            CONECTARBD()

            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable

            'Indico el SP que voy a utilizar
            command = New SqlCommand("CYP_SELECT_FERRITA", CN)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            'Aquí ejecuto el SP y lo lleno en el DataTable
            adapter.Fill(dtTable)
            'Enlazo mis datos obtenidos en el DataTable con el grid
            DataGridView1.DataSource = dtTable
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DataGridView1.AutoGenerateColumns = False
            'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub

#End Region

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        LLENARGRID2()

    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub FRM_REG_FERRITA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LLENARGRID2()

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If RadioButton1.Checked Then
            Try
                LlamarDatos("SELECT * FROM REP_FERRITA WHERE ISOMETRICO LIKE '%" & TextBox1.Text & "%'")
                DT = New DataTable

                ADP.Fill(DT)
                DataGridView1.DataSource = DT
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
        If (TextBox1.Text.Trim = "") Then
            LLENARGRID2()


        End If

    End Sub
End Class