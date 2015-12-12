Imports System.Data
Imports System.Data.SqlClient

Public Class frmdailyweld
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
    Sub OBJ_SPOOL()

        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT NUMERO_SPOOL from TBL_SPOOL where NUMERO_ISOMETRICO='" & TextBox1.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            ComboBox1.DataSource = DS.Tables(0)
            ComboBox1.DisplayMember = "NUMERO_SPOOL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL SERVICIO
    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub



    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Dim cmd As New SqlCommand("Select NUM_ISO FROM TBL_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("NUM_ISO").ToString())
            Next
            TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
            TextBox1.AutoCompleteCustomSource = col
            TextBox1.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            OBJ_SPOOL()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable

        'Indico el SP que voy a utilizar
        command = New SqlCommand("SP_DAILY_WELD_ISO_SPOOL", CN)
        command.CommandType = CommandType.StoredProcedure
        adapter = New SqlDataAdapter(command)
        dtTable = New DataTable
        With command
            'Envió los parámetros que necesito
            .Parameters.Add("@ISO", SqlDbType.Int).Value = TextBox1.Text
            .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = ComboBox1.Text
        End With
        Try
            'Aquí ejecuto el SP y lo lleno en el DataTable
            adapter.Fill(dtTable)
            'Enlazo mis datos obtenidos en el DataTable con el grid
            DataGridView1.DataSource = dtTable
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DataGridView1.AutoGenerateColumns = False


        Catch expSQL As SqlException
            MessageBox.Show(expSQL.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub
End Class