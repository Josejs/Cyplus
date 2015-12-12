Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class FRM_CAP_FERR
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
    Sub OBJ_SPOOL()
        Try
            '  CONECTARBD2()
            CADENA = "SELECT  DISTINCT NUMERO_SPOOL from TBL_SPOOL WHERE NUMERO_ISOMETRICO='" & txisometrico.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBSPOOL.DataSource = DS.Tables(0)
            CBSPOOL.DisplayMember = "NUMERO_SPOOL"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()


        End Try
    End Sub
    Sub llenarGrid()
        Try
            CONECTARBD()

            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable

            'Indico el SP que voy a utilizar
            command = New SqlCommand("M_ferrita", CN)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            With command
                .Parameters.Add("@isometrico", SqlDbType.Int).Value = txisometrico.Text
                .Parameters.Add("@spool", SqlDbType.NVarChar, 100).Value = CBSPOOL.Text

            End With
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
            DataGridView2.DataSource = dtTable
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DataGridView2.AutoGenerateColumns = False
            'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub

    Public Sub Limpiar_TextBox(ByVal formulario As Form)

        'Recorremos todos los controles del formulario que enviamos  
        For Each control As Control In formulario.Controls

            'Filtramos solo aquellos de tipo TextBox 
            If TypeOf control Is TextBox Then
                control.Text = "" ' eliminar el texto  
            End If
        Next

    End Sub

#End Region

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub FRM_CAP_FERR_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CYPLUSDataSet.REP_FERRITA' Puede moverla o quitarla según sea necesario.
        ' Me.REP_FERRITATableAdapter.Fill(Me.CYPLUSDataSet.REP_FERRITA)

    End Sub

    Private Sub LLENARTABLAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim VALSD As Boolean = False
        Me.EPR.SetError(txisometrico, "")
        Me.EPR.SetError(CBSPOOL, "")

        If (txisometrico.Text.Trim = "") Then
            EPR.SetError(txisometrico, "DEBE ESPECIFICAR EL ISOMETRICO")
            VALSD = True
        End If

        If (CBSPOOL.Text.Trim = "") Then
            EPR.SetError(CBSPOOL, "DEBE ESPECIFICAR EL NUMERO DE SPOOL")
            VALSD = True
        End If

        If VALSD = True Then
            ToastNotification.Show(Me, "VERIFIQUE QUE HAYA LLENADO LOS CAMPOS OBLIGATORIOS", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Exit Sub
        Else
            Try
                llenarGrid()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()

            End Try

        End If

     
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        OBJ_SPOOL()
    End Sub

    Private Sub txisometrico_TextChanged(sender As System.Object, e As System.EventArgs) Handles txisometrico.TextChanged
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
            txisometrico.AutoCompleteSource = AutoCompleteSource.CustomSource
            txisometrico.AutoCompleteCustomSource = col
            txisometrico.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("CYP_INSERT_FERRITA", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTISOMETRICO.Text
                .Parameters.Add("@RX", SqlDbType.Float, 53).Value = TXTRX.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 50).Value = TXTSPOOL.Text
                .Parameters.Add("@LINEA", SqlDbType.NVarChar, 150).Value = TXTLINEA.Text
                .Parameters.Add("@JUNTA", SqlDbType.Int).Value = TXTJUNTA.Text
                .Parameters.Add("@TIPO1", SqlDbType.NVarChar, 5).Value = TXTTIPO1.Text
                .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 5).Value = TXTTIPO2.Text
                .Parameters.Add("@TIPO_JUNTA", SqlDbType.NVarChar, 50).Value = TXTTIPOJUNTA.Text

                .Parameters.Add("@DIAMETRO", SqlDbType.Float, 53).Value = TXTDIAMETRO.Text
                .Parameters.Add("@CAMP_TALLER", SqlDbType.NVarChar, 10).Value = TXTCAMPO.Text
                .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 100).Value = TXTESPECIFICACION.Text
                .Parameters.Add("@CODIGO_MAT1", SqlDbType.NVarChar, 200).Value = TXTCODIGOMATERIAL1.Text
                .Parameters.Add("@DESCRIP_MAT1", SqlDbType.NVarChar, 200).Value = TXTDESCRIPCION1.Text
                .Parameters.Add("@COLADA_MAT1", SqlDbType.NVarChar, 150).Value = TXTCOLADA1.Text
                .Parameters.Add("@CODIGO_MAT2", SqlDbType.NVarChar, 200).Value = TXTCODIGO2.Text
                .Parameters.Add("@DESCRIP_MAT2", SqlDbType.NVarChar, 150).Value = TXTDESCRIPCION2.Text
                .Parameters.Add("@COLADA_MAT2", SqlDbType.NVarChar, 150).Value = TXTCOLADA2.Text
                .Parameters.Add("@FONDEADOR", SqlDbType.NVarChar, 100).Value = TXTFONDEADOR.Text
                .Parameters.Add("@RELLENADOR", SqlDbType.NVarChar, 100).Value = TXTRELLENADOR.Text
                .Parameters.Add("@INSP_VISUAL", SqlDbType.NVarChar, 100).Value = TXTINSP_VISUAL.Text
                .Parameters.Add("@WPS", SqlDbType.NVarChar, 150).Value = TXTWPS.Text
                .Parameters.Add("@NO_REPORT_FERRITA", SqlDbType.NVarChar, 150).Value = TXTNOREPROTFERRITA.Text
                .Parameters.Add("@FECHA_REPORT_FERRITA", SqlDbType.Date).Value = TXTFECHAREPORTFERRITA.Text
            End With

            COMANDO.ExecuteNonQuery()
            MessageBox.Show("PRUEBA REGISTRADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call Limpiar_TextBox(Me)
            '   Me.REP_FERRITATableAdapter.Fill(Me.CYPLUSDataSet.REP_FERRITA)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Call Limpiar_TextBox(Me)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value) Then
                TXTISOMETRICO.Text = 0
            Else
                TXTISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            End If


            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value) Then
                TXTSPOOL.Text = "-"
            Else
                TXTSPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            End If


            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value) Then
                TXTLINEA.Text = "-"
            Else
                TXTLINEA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            End If





            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value) Then
                TXTJUNTA.Text = "-"
            Else
                TXTJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value) Then
                TXTTIPO1.Text = "-"
            Else
                TXTTIPO1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value) Then
                TXTTIPO2.Text = "-"
            Else
                TXTTIPO2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value) Then
                TXTTIPOJUNTA.Text = "-"
            Else
                TXTTIPOJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value) Then
                TXTCAMPO.Text = "-"
            Else
                TXTCAMPO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value) Then
                TXTDIAMETRO.Text = 0
            Else
                TXTDIAMETRO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value) Then
                TXTESPECIFICACION.Text = "-"
            Else
                TXTESPECIFICACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value) Then
                TXTCODIGOMATERIAL1.Text = "-"
            Else
                TXTCODIGOMATERIAL1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value) Then
                TXTDESCRIPCION1.Text = "-"
            Else
                TXTDESCRIPCION1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value) Then
                TXTCOLADA1.Text = "-"
            Else
                TXTCOLADA1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value) Then
                TXTCODIGO2.Text = "-"
            Else
                TXTCODIGO2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value) Then
                TXTDESCRIPCION2.Text = "-"
            Else
                TXTDESCRIPCION2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value) Then
                TXTCOLADA2.Text = "-"
            Else
                TXTCOLADA2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value) Then
                TXTFONDEADOR.Text = "-"
            Else
                TXTFONDEADOR.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value) Then
                TXTRELLENADOR.Text = "-"
            Else
                TXTRELLENADOR.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value) Then
                TXTINSP_VISUAL.Text = "-"
            Else
                TXTINSP_VISUAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(22).Value 'FECHA SOLDADURA
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value) Then
                TXTWPS.Text = "-"
            Else
                TXTWPS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
            End If

            If IsDBNull(Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value) Then
                TXTRX.Text = 0
            Else
                TXTRX.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(23).Value
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("CYP_EDIT_FERRITA", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@ID", SqlDbType.Int).Value = TXTID.Text
                .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTISOMETRICO.Text
                .Parameters.Add("@RX", SqlDbType.Float, 53).Value = TXTRX.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 50).Value = TXTSPOOL.Text
                .Parameters.Add("@LINEA", SqlDbType.NVarChar, 150).Value = TXTLINEA.Text
                .Parameters.Add("@JUNTA", SqlDbType.Int).Value = TXTJUNTA.Text
                .Parameters.Add("@TIPO1", SqlDbType.NVarChar, 5).Value = TXTTIPO1.Text
                .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 5).Value = TXTTIPO2.Text
                .Parameters.Add("@TIPO_JUNTA", SqlDbType.NVarChar, 50).Value = TXTTIPOJUNTA.Text
                .Parameters.Add("@DIAMETRO", SqlDbType.Float, 53).Value = TXTDIAMETRO.Text
                .Parameters.Add("@CAMP_TALLER", SqlDbType.NVarChar, 10).Value = TXTCAMPO.Text
                .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 100).Value = TXTESPECIFICACION.Text
                .Parameters.Add("@CODIGO_MAT1", SqlDbType.NVarChar, 200).Value = TXTCODIGOMATERIAL1.Text
                .Parameters.Add("@DESCRIP_MAT1", SqlDbType.NVarChar, 200).Value = TXTDESCRIPCION1.Text
                .Parameters.Add("@COLADA_MAT1", SqlDbType.NVarChar, 150).Value = TXTCOLADA1.Text
                .Parameters.Add("@CODIGO_MAT2", SqlDbType.NVarChar, 200).Value = TXTCODIGO2.Text
                .Parameters.Add("@DESCRIP_MAT2", SqlDbType.NVarChar, 150).Value = TXTDESCRIPCION2.Text
                .Parameters.Add("@COLADA_MAT2", SqlDbType.NVarChar, 150).Value = TXTCOLADA2.Text
                .Parameters.Add("@FONDEADOR", SqlDbType.NVarChar, 100).Value = TXTFONDEADOR.Text
                .Parameters.Add("@RELLENADOR", SqlDbType.NVarChar, 100).Value = TXTRELLENADOR.Text
                .Parameters.Add("@INSP_VISUAL", SqlDbType.NVarChar, 100).Value = TXTINSP_VISUAL.Text
                .Parameters.Add("@WPS", SqlDbType.NVarChar, 150).Value = TXTWPS.Text
                .Parameters.Add("@NO_REPORT_FERRITA", SqlDbType.NVarChar, 150).Value = TXTNOREPROTFERRITA.Text
                .Parameters.Add("@FECHA_REPORT_FERRITA", SqlDbType.Date).Value = TXTFECHAREPORTFERRITA.Text
            End With

            COMANDO.ExecuteNonQuery()
            MessageBox.Show("PRUEBA MODIFICADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call Limpiar_TextBox(Me)
            '  Me.REP_FERRITATableAdapter.Fill(Me.CYPLUSDataSet.REP_FERRITA)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        FRM_REG_FERRITA.Show()
        '  ToastNotification.Show(Me, "NO DISPONIBLE, VERIFIQUE LA TABLA INFERIOR", My.Resources.descarga, 6000, eToastPosition.TopRight)
        Exit Sub
    End Sub

    Private Sub INFORMEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INFORMEToolStripMenuItem.Click
        FRM_INFORME_FERRITA.Show()

    End Sub
End Class