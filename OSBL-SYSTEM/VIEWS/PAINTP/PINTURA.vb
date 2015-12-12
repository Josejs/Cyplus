Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class PINTURA
    Dim INDICADOR As Integer

#Region "METODOS"
    Sub LIMP()
        PID.Clear()
        PSPOOL.Clear()
        PESTADO.Clear()
        PSAND.Clear()
        PACABADO.Clear()
        PLIBERACION.Clear()
        PENLACE.Clear()
        PCOMPAÑIA.Clear()
        PSISTEMA.Clear()
        PPESO.Clear()
        PAREA.Clear()
        POBSERVACION.Clear()
        PNUMEROREP.Clear()
        PFECHAORDEN.Clear()
        PNOORDEN.Clear()
    End Sub
    Sub OBT()
        Try
            CONECTARBD2()
            COMANDO = New SqlCommand("OBT_PINT_INFO", CN2)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar).Value = TXTSPOOLIBERACION.Text
       
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TXTCLASELIBERACION.Text = DR.GetString(0)
                TXTSISTEMALIBERACION.Text = DR.GetString(1)
                TXTUNIDADLIBERACION.Text = DR.GetString(2)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
            DR.Close()
        End Try
    End Sub
    Sub SEL_()
        CONECTARBD()
        COMANDO = New SqlCommand("SEL_NO_ORDEN", CN)
        COMANDO.CommandType = CommandType.StoredProcedure
        With COMANDO
            .Parameters.Add("@SPOOL", SqlDbType.NVarChar).Value = TXTSPOOLIBERACION.Text
        End With
        DR = COMANDO.ExecuteReader
        Do While DR.Read
            INDICADOR = 1
            txtno_ord.Text = DR.GetString(0)
            Exit Do

        Loop

    End Sub
    Sub LIMP2()
        TXTCANTIDADLIBERACION.Clear()
        TXTCLASELIBERACION.ResetText()
        TXTIDLIBERACION.Clear()
        TXTMATERIALIBERACION.ResetText()
        TXTMTSLIBERACION.Clear()
        TXTMTSLIBERACION.Clear()
        TXTSISTEMALIBERACION.Clear()
        TXTSPOOLIBERACION.Clear()
        TXTUNIDADLIBERACION.Clear()

    End Sub
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN2
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
    Sub LLENAR_GRID()
        Try

            LlamarDatos("SELECT * FROM LIBERACION_PINT ")
            DT = New DataTable
            ADP.Fill(DT)
            DVGSPOOLCONTROLADO.DataSource = DT

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub LLENARGRID2()
        Try

            LlamarDatos("SELECT * FROM PINTURA ")
            DT = New DataTable
            ADP.Fill(DT)
            DVGASIGNADOS.DataSource = DT

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LIMP_PACK()
        PACKIDENTIFICACION.Clear()
        TXTREV.ResetText()
        txtarea.ResetText()
        TXTISOMETRICO.ResetText()
        PACKKILOS.Clear()
        PACKCOMBO.ResetText()
        PACKDESCRIPCION.Clear()
        '  PACKGROSS.Clear()
        PACKQTY.Clear()
        PACKID.Clear()

    End Sub
    Sub LLENARGRID3()
        Try

            LlamarDatos("SELECT * FROM PCK ")
            DT = New DataTable
            ADP.Fill(DT)
            DVGPACKING.DataSource = DT

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Sub OBTK()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SEL_KILOS", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = PACKIDENTIFICACION.Text

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                PACKKILOS.Text = DR.GetValue(0)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBJ_NUM_ISO()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT NO_PACKING from PCK"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            PACKCOMBO.DataSource = DS.Tables(0)
            PACKCOMBO.DisplayMember = "NO_PACKING"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub 'LLENA LA LISTA DEL NUMERO DE ISOMETRICO

    Sub OBJ_NUM_ISO_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT  NUMERO_ISOMETRICO,REV_SPOOL from TBL_SPOOL WHERE SPOOL='" & PACKIDENTIFICACION.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTISOMETRICO.DataSource = DS.Tables(0)
            TXTISOMETRICO.DisplayMember = "NUMERO_ISOMETRICO"
            TXTREV.DataSource = DS.Tables(0)
            TXTREV.DisplayMember = "REV_SPOOL"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub obj_Area()
        Try
            CONECTARBD()
            CADENA = "SELECT  AREA from TBL_ISO WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            txtarea.DataSource = DS.Tables(0)
            txtarea.DisplayMember = "AREA"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

#End Region

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            FRMLOGINPINT.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub BUSCARESTADODESPOOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSCARESTADODESPOOLToolStripMenuItem.Click
        BUSQUEDASPOOL.Show()
    End Sub
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        EP.SetError(PSPOOL, "")
        EP.SetError(PESTADO, "")
        Dim VALID As Boolean = False


        'VALIDATE TEXT TRIM
        If (PSPOOL.Text.Trim = "") Then
            EP.SetError(PSPOOL, "DEBE ASIGNAR EL SPOOL PARA ESTE REGISTRO")
            VALID = True
        End If
        If (PESTADO.Text.Trim = "") Then
            EP.SetError(PESTADO, "DEBE ESPECIFICAR EL ESTADO DEL SPOOL")
            VALID = True
        End If


        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR, VERIFIQUE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_PINTURA", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.Add("@SPOOL ", SqlDbType.NVarChar, 250).Value = PSPOOL.Text
                    .Parameters.Add("@ESTADO_SPOOL", SqlDbType.NVarChar, 150).Value = PESTADO.Text
                    .Parameters.Add("@F_SAND_PRIMARIO ", SqlDbType.NVarChar, 150).Value = PSAND.Text
                    .Parameters.Add("@F_ACABADO", SqlDbType.NVarChar, 150).Value = PACABADO.Text
                    .Parameters.Add("@F_LIBERACION ", SqlDbType.NVarChar, 150).Value = PLIBERACION.Text
                    .Parameters.Add("@F_ENLACE ", SqlDbType.NVarChar, 150).Value = PENLACE.Text
                    .Parameters.Add("@COMPAÑIA ", SqlDbType.NVarChar, 250).Value = PCOMPAÑIA.Text
                    .Parameters.Add("@SISTEMA_PINTURA ", SqlDbType.NVarChar, 250).Value = PSISTEMA.Text
                    .Parameters.Add("@PESO_SPOOL ", SqlDbType.Float, 53).Value = PPESO.Text
                    .Parameters.Add("@AREA_A_PINTAR ", SqlDbType.NVarChar, 250).Value = PAREA.Text
                    .Parameters.Add("@OBSERVACIONES ", SqlDbType.NVarChar, 250).Value = POBSERVACION.Text
                    .Parameters.Add("@NO_REPORT_PINTURA ", SqlDbType.NVarChar, 250).Value = PNUMEROREP.Text
                    .Parameters.Add("@NO_ORDEN ", SqlDbType.NVarChar, 250).Value = PNOORDEN.Text
                    .Parameters.Add("@FECHA_ORDEN ", SqlDbType.NVarChar, 250).Value = PFECHAORDEN.Text
                    .Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = PCANTIDAD.Text
                End With

                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE PINTURA INGRESADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'LIMP()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' LIMP()
            Finally
                DECONECTARBD()

            End Try
        End If


    End Sub

    Private Sub BTNNUEVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNUEVO.Click
        LIMP()
    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        EP.SetError(PID, "")
        Dim VALID As Boolean = False


        'VALIDATE TEXT TRIM
        If (PID.Text.Trim = "") Then
            EP.SetError(PID, "FALTA EL IDENTIFICADOR")
            VALID = True
        End If

        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR, VERIFIQUE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else

                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_PINTURA", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", PID.Text)
                        .Parameters.Add("@SPOOL ", SqlDbType.NVarChar, 250).Value = PSPOOL.Text
                        .Parameters.Add("@ESTADO_SPOOL", SqlDbType.NVarChar, 150).Value = PESTADO.Text
                        .Parameters.Add("@F_SAND_PRIMARIO ", SqlDbType.NVarChar, 150).Value = PSAND.Text
                        .Parameters.Add("@F_ACABADO", SqlDbType.NVarChar, 150).Value = PACABADO.Text
                        .Parameters.Add("@F_LIBERACION ", SqlDbType.NVarChar, 150).Value = PLIBERACION.Text
                        .Parameters.Add("@F_ENLACE ", SqlDbType.NVarChar, 150).Value = PENLACE.Text
                        .Parameters.Add("@COMPAÑIA ", SqlDbType.NVarChar, 250).Value = PCOMPAÑIA.Text
                        .Parameters.Add("@SISTEMA_PINTURA ", SqlDbType.NVarChar, 250).Value = PSISTEMA.Text
                        .Parameters.Add("@PESO_SPOOL ", SqlDbType.Float, 53).Value = PPESO.Text
                        .Parameters.Add("@AREA_A_PINTAR ", SqlDbType.NVarChar, 250).Value = PAREA.Text
                        .Parameters.Add("@OBSERVACIONES ", SqlDbType.NVarChar, 250).Value = POBSERVACION.Text
                        .Parameters.Add("@NO_REPORT_PINTURA ", SqlDbType.NVarChar, 250).Value = PNUMEROREP.Text
                        .Parameters.Add("@NO_ORDEN ", SqlDbType.NVarChar, 250).Value = PNOORDEN.Text
                        .Parameters.Add("@FECHA_ORDEN ", SqlDbType.NVarChar, 250).Value = PFECHAORDEN.Text
                        .Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = PCANTIDAD.Text
                    End With

                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO MODIFICADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMP()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LIMP()
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        EP.SetError(PID, "")
        Dim VALID As Boolean = False


        'VALIDATE TEXT TRIM
        If (PID.Text.Trim = "") Then
            EP.SetError(PID, "FALTA EL IDENTIFICADOR")
            VALID = True
        End If

        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR, VERIFIQUE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_PINTURA", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", PID.Text)
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LIMP()
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If

    End Sub

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click
        REGPINTURA.Show()
    End Sub

    Private Sub PSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSPOOL.TextChanged
        Try
            Dim cmd As New SqlCommand("Select SPOOL FROM TBL_SPOOL", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_SPOOL")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("SPOOL").ToString())
            Next
            PSPOOL.AutoCompleteSource = AutoCompleteSource.CustomSource
            PSPOOL.AutoCompleteCustomSource = col
            PSPOOL.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

  

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub TODOSLOSREGISTROSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODOSLOSREGISTROSToolStripMenuItem.Click
        RPINTURA.Show()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        EP.SetError(TXTSPOOLIBERACION, "")
        EP.SetError(TXTCLASELIBERACION, "")
        Dim VALID As Boolean = False

        If (TXTSPOOLIBERACION.Text.Trim = "") Then
            EP.SetError(TXTSPOOLIBERACION, "DEBE ESPECIFICAR EL SPOOL")
            VALID = True
        End If
        If (TXTCLASELIBERACION.Text.Trim = "") Then
            EP.SetError(TXTCLASELIBERACION, "DEBE ESPECIFICAR LA CLASE DEL SPOOL")
            VALID = True
        End If
        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_LIBERACION", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = TXTSPOOLIBERACION.Text
                    .Parameters.Add("@CLASE", SqlDbType.NVarChar, 255).Value = TXTCLASELIBERACION.Text
                    .Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = TXTCANTIDADLIBERACION.Text
                    .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 255).Value = TXTUNIDADLIBERACION.Text
                    .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 255).Value = TXTMATERIALIBERACION.Text
                    .Parameters.Add("@SISTEMA_PINTURA", SqlDbType.NVarChar, 255).Value = TXTSISTEMALIBERACION.Text
                    .Parameters.Add("@MTS2", SqlDbType.Float, 53).Value = TXTMTSLIBERACION.Text
                    .Parameters.Add("@ORDEN", SqlDbType.NVarChar, 255).Value = txtno_ord.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO INGRESADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LIMP2()
                LLENAR_GRID()
                LLENARGRID2()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()
            End Try
        End If


    End Sub

    Private Sub TXTSPOOLIBERACION_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSPOOLIBERACION.TextChanged
        Try
            Dim cmd As New SqlCommand("Select SPOOL FROM PINTURA", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "PINTURA")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("SPOOL").ToString())
            Next
            TXTSPOOLIBERACION.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTSPOOLIBERACION.AutoCompleteCustomSource = col
            TXTSPOOLIBERACION.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
            DR.Close()

        End Try
    End Sub

    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        Try
            OBT()
            SEL_()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
            DECONECTARBD2()

        End Try


    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        LIMP2()

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        EP.SetError(TXTIDLIBERACION, "")
        Dim VALID As Boolean = False


        If (TXTIDLIBERACION.Text.Trim = "") Then
            EP.SetError(TXTIDLIBERACION, "DEBE ESPECIFICAR EL IDENTIFICADOR")
            VALID = True
        End If

        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()

                    COMANDO = New SqlCommand("EDIT_LIBERACION", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure


                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTIDLIBERACION.Text)
                        .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = TXTSPOOLIBERACION.Text
                        .Parameters.Add("@CLASE", SqlDbType.NVarChar, 255).Value = TXTCLASELIBERACION.Text
                        .Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = TXTCANTIDADLIBERACION.Text
                        .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 255).Value = TXTUNIDADLIBERACION.Text
                        .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 255).Value = TXTMATERIALIBERACION.Text
                        .Parameters.Add("@SISTEMA_PINTURA", SqlDbType.NVarChar, 255).Value = TXTSISTEMALIBERACION.Text
                        .Parameters.Add("@MTS2", SqlDbType.Float, 53).Value = TXTMTSLIBERACION.Text
                        .Parameters.Add("@ORDEN", SqlDbType.NVarChar, 255).Value = txtno_ord.Text
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO MODIFICADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMP2()
                    LLENAR_GRID()
                    LLENARGRID2()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()
                End Try
            End If

        End If

    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        EP.SetError(TXTIDLIBERACION, "")
        Dim VALID As Boolean = False


        If (TXTIDLIBERACION.Text.Trim = "") Then
            EP.SetError(TXTIDLIBERACION, "DEBE ESPECIFICAR EL IDENTIFICADOR")
            VALID = True
        End If

        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_LIBERACION", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTIDLIBERACION.Text)

                    End With


                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("EL REGISTRO HA SIDO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMP2()
                    LLENAR_GRID()
                    LLENARGRID2()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If

    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        FRMREGLIBERACION.Show()
    End Sub


    Private Sub PINTURA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LLENARGRID3()
            LLENAR_GRID()

            LLENARGRID2()
            '   OBJ_NUM_ISO()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
            DECONECTARBD2()
        End Try

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DVGSPOOLCONTROLADO.CellDoubleClick
        Try
            If IsDBNull(TXTSPOOLIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(1).Value) Then
                TXTSPOOLIBERACION.Text = "-"
            Else
                TXTSPOOLIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(1).Value
            End If
            TXTIDLIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(0).Value

            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(2).Value) Then
                TXTCLASELIBERACION.Text = "-"
            Else
                TXTCLASELIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(2).Value
            End If

            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(3).Value) Then
                TXTCANTIDADLIBERACION.Text = "-"
            Else
                TXTCANTIDADLIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(3).Value
            End If

            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(4).Value) Then
                TXTUNIDADLIBERACION.Text = "-"
            Else
                TXTUNIDADLIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(4).Value
            End If

            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(5).Value) Then
                TXTMATERIALIBERACION.Text = "-"
            Else
                TXTMATERIALIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(5).Value
            End If
            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(6).Value) Then
                TXTSISTEMALIBERACION.Text = "-"
            Else
                TXTSISTEMALIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(6).Value
            End If

            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(7).Value) Then
                TXTMTSLIBERACION.Text = "-"
            Else
                TXTMTSLIBERACION.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(7).Value
            End If

            If IsDBNull(Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(8).Value) Then
                txtno_ord.Text = "-"
            Else
                txtno_ord.Text = Me.DVGSPOOLCONTROLADO.Rows(e.RowIndex).Cells(8).Value
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        LLENAR_GRID()
        LLENARGRID2()


    End Sub

    Private Sub DataGridView2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DVGASIGNADOS.CellDoubleClick
        Try
            TXTSPOOLIBERACION.Text = Me.DVGASIGNADOS.Rows(e.RowIndex).Cells(1).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LIBERACIONDESPOOLPPINTURAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBERACIONDESPOOLPPINTURAToolStripMenuItem.Click
        FRMLIBSPOOLREPORT.Show()
    End Sub


    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        EP.SetError(PACKIDENTIFICACION, "")
        EP.SetError(PACKCOMBO, "")
        Dim VALID As Boolean = False

        If (PACKIDENTIFICACION.Text.Trim = "") Then
            EP.SetError(PACKIDENTIFICACION, "DEBE ESPECIFICAR EL IDENTIFICADOR/SPOOL")
            VALID = True

        End If
        If (PACKCOMBO.Text.Trim = "") Then
            EP.SetError(PACKCOMBO, "DEBE ESPECIFICAR EL NUMERO DE PACKING LIST")
            VALID = True
        End If

        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_PCK", CN)
                COMANDO.CommandType = CommandType.StoredProcedure
                With COMANDO
                    .Parameters.Add("@IDENTIFICATION", SqlDbType.NVarChar, 255).Value = PACKIDENTIFICACION.Text
                    .Parameters.Add("@AREA", SqlDbType.Int).Value = txtarea.Text
                    .Parameters.Add("@WEIGHT_IN_KILOS", SqlDbType.Float, 53).Value = PACKKILOS.Text
                    .Parameters.Add("@FECHA_PACKING_LIST", SqlDbType.NVarChar, 255).Value = TXTFECHAPACKING.Text
                    .Parameters.Add("@QTY", SqlDbType.Int).Value = PACKQTY.Text
                    .Parameters.Add("@MATERIAL_DESCRIPTION", SqlDbType.NVarChar, 255).Value = PACKDESCRIPCION.Text
                    .Parameters.Add("@NO_PACKING", SqlDbType.Int).Value = PACKCOMBO.Text
                    .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTISOMETRICO.Text
                    .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = TXTREV.Text
                    .Parameters.Add("@NOTAS", SqlDbType.NVarChar, 50).Value = TXTNOTAS.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO INGRESADO CORRECTAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMP_PACK()
                LLENARGRID3()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()

            End Try
        End If

    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        LLENARGRID3()
    End Sub

    Private Sub DataGridView3_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DVGPACKING.CellDoubleClick
        Try
            PACKID.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(0).Value


            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(1).Value) Then
                PACKIDENTIFICACION.Text = "-"
            Else
                PACKIDENTIFICACION.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(1).Value
            End If

            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(2).Value) Then
                txtarea.Text = "-"
            Else
                txtarea.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(2).Value
            End If

            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(3).Value) Then
                PACKKILOS.Text = "-"
            Else
                PACKKILOS.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(3).Value
            End If

            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(4).Value) Then
                PACKQTY.Text = "-"
            Else
                PACKQTY.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(4).Value
            End If
            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(5).Value) Then
                PACKDESCRIPCION.Text = "-"
            Else
                PACKDESCRIPCION.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(5).Value
            End If

            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(6).Value) Then
                PACKCOMBO.Text = "-"
            Else
                PACKCOMBO.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(6).Value
            End If

            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(7).Value) Then
                TXTFECHAPACKING.Text = "-"
            Else
                TXTFECHAPACKING.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(7).Value
            End If
            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(8).Value) Then
                TXTISOMETRICO.Text = "-"
            Else
                TXTISOMETRICO.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(8).Value

            End If

            If IsDBNull(Me.DVGPACKING.Rows(e.RowIndex).Cells(9).Value) Then
                TXTREV.Text = "-"
            Else
                TXTREV.Text = Me.DVGPACKING.Rows(e.RowIndex).Cells(9).Value
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonX10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX10.Click
        EP.SetError(PACKID, "")

        Dim VALID As Boolean = False
        If (PACKID.Text.Trim = "") Then
            EP.SetError(PACKID, "DEBE ESPECIFICAR EL IDENTIFICADOR")
            VALID = True
        End If
        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR ESTE REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_PCK", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure
                    With COMANDO
                        .Parameters.AddWithValue("@ID", PACKID.Text)
                        .Parameters.Add("@IDENTIFICATION", SqlDbType.NVarChar, 255).Value = PACKIDENTIFICACION.Text

                        .Parameters.Add("@AREA", SqlDbType.Int).Value = txtarea.Text
                        .Parameters.Add("@WEIGHT_IN_KILOS", SqlDbType.Float, 53).Value = PACKKILOS.Text
                        .Parameters.Add("@FECHA_PACKING_LIST", SqlDbType.NVarChar, 255).Value = TXTFECHAPACKING.Text
                        .Parameters.Add("@QTY", SqlDbType.Int).Value = PACKQTY.Text
                        .Parameters.Add("@MATERIAL_DESCRIPTION", SqlDbType.NVarChar, 255).Value = PACKDESCRIPCION.Text
                        .Parameters.Add("@NO_PACKING", SqlDbType.Int).Value = PACKCOMBO.Text
                        .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTISOMETRICO.Text
                        .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = TXTREV.Text

                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO MODIFICADO CORRECTAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMP_PACK()
                    LLENARGRID3()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If

        End If
    End Sub

    Private Sub ButtonX12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX12.Click
        EP.SetError(PACKID, "")

        Dim VALID As Boolean = False
        If (PACKID.Text.Trim = "") Then
            EP.SetError(PACKID, "DEBE ESPECIFICAR EL IDENTIFICADOR")
            VALID = True
        End If
        If (VALID = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR ESTE REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_PCK", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", PACKID.Text)
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMP_PACK()
                    LLENARGRID3()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try


            End If
        End If

    End Sub

    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click
        LIMP_PACK()
    End Sub

    Private Sub ButtonX11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX11.Click
        PACKINGLIST.Show()
    End Sub

    Private Sub LLENARLISTADEPACKINGLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLENARLISTADEPACKINGLISTToolStripMenuItem.Click
        OBJ_NUM_ISO()
    End Sub

    Private Sub PACKIDENTIFICACION_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PACKIDENTIFICACION.TextChanged
        Try
            Dim cmd As New SqlCommand("Select DISTINCT SPOOL FROM LIBERACION_PINT", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "LIBERACION_PINT")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("SPOOL").ToString())
            Next
            PACKIDENTIFICACION.AutoCompleteSource = AutoCompleteSource.CustomSource
            PACKIDENTIFICACION.AutoCompleteCustomSource = col
            PACKIDENTIFICACION.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OBTK()
        OBJ_NUM_ISO_AREA()
        obj_Area()
        PACKQTY.Text = "1"
        PACKDESCRIPCION.Text = "PIPE SPOOL"
        TXTNOTAS.Text = "-"
    End Sub

    Private Sub TODOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODOSToolStripMenuItem.Click
        REPORTEPACKING.Show()
    End Sub

    Private Sub PORNUMERODEPACKINGLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORNUMERODEPACKINGLISTToolStripMenuItem.Click
        PACKINGCONDICION.Show()
    End Sub

 
End Class