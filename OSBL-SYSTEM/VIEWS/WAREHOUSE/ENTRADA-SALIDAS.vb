Imports System.Data
Imports System.Data.SqlClient
Public Class ENTRADA_SALIDAS

#Region "METODOS Y VARIABLES"
    Dim RESULTADO As Integer
    Dim INDICADOR As Integer
    Sub LIMPIAR()
        TXENTRADACANTIDAD.Clear()
        TXENTRADACERTIFICADOS.Clear()
        TXENTRADACODIGO.Clear()
        TXENTRADACOLADA.Clear()
        TXENTRADADESCRIPCION.Clear()
        TXENTRADAFABRICANTE.Clear()
        TXENTRADALOTE.Clear()
        TXENTRADAMATERIAL.Clear()
        TXENTRADAUNIDAD.Clear()
        TXIDENTRADA.Clear()
        DTENTRADAFECHA.ResetText()
        TXNUMCERTIFICADO.Clear()
        TXTCODCLIENTE.Clear()
        TXDESCCORTA.Clear()
        TXCERTIFICADOTCM.Clear()
        txtcedula2.Clear()
        txtdiametro2.Clear()
        TXTPESOALMACEN.Clear()
        TXTPESOALMACEN.Clear()
        TXTPESTOTAL.Clear()
        TXTCEDULAALMACEN.Clear()
        TXTDIAMETROALMACEN.Clear()
        TXTITEM.Clear()
    End Sub
    Sub OBJ_NUM_ISO()
        Try
            CONECTARBD()
            CADENA = "SELECT NUM_ISO from TBL_ISO"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            SALIDACBISOMETRICO.DataSource = DS.Tables(0)
            SALIDACBISOMETRICO.DisplayMember = "NUM_ISO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL NUMERO DE ISOMETRICO
    Sub OBJ_COD_MAT()

        Try
            CONECTARBD()
            CADENA = "SELECT CODIGO_MATERIAL from ALMACEN"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            SALIDACBCODIGOMATE.DataSource = DS.Tables(0)
            SALIDACBCODIGOMATE.DisplayMember = "CODIGO_MATERIAL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL NUMERO DE ISOMETRICO
    Sub CLEARSALIDA()
        SALIDAID.Clear() 'id del registro
        SALIDACANTIDAD.Clear() ' cantidad de salida
        SALIDAUNIDAD.Clear() ' unidades
        SALIDAOBSERVACION.Clear() ' observaciones
        SALIDAFECHA.ResetText() 'fecha de salida del almacen
        SALIDACBCLAVE.ResetText() 'clave del tubero
        SALIDACBCODIGOMATE.ResetText() 'codigo del material de salida
        SALIDACONSECUTIVO.Clear() 'consecutivo interno del material
        SALIDACBISOMETRICO.ResetText() ' numero del isometrico
        restante.Clear()
        LBVERIFICACION.Clear()
        SALIDACOLADA.Clear()


    End Sub

    Sub LLENAR_CLAVE_TUBERO()
        Try
            CONECTARBD()
            CADENA = "SELECT CLAVE_TUBERO from SALIDA_ALMACEN"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            SALIDACBCLAVE.DataSource = DS.Tables(0)
            SALIDACBCLAVE.DisplayMember = "CLAVE_TUBERO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Sub OBT()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SELECT_OBJS_CLIENT", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Clear()
                .Parameters.AddWithValue("@CODIGO_CLIENTE", TXTCODCLIENTE.Text)
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TXENTRADADESCRIPCION.Text = DR.GetString(0)
                TXENTRADAMATERIAL.Text = DR.GetString(1)
                'TXENTRADACODIGO.Text = DR.GetString(2)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
#End Region

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

  
    Private Sub BTNGUARDAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNGUARDAR.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("INSERT_ALMACEN", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                '0 ID
                .Parameters.Add("@CODIGO_MATERIAL", SqlDbType.NVarChar, 255).Value = TXENTRADACODIGO.Text '1
                .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 255).Value = TXENTRADAMATERIAL.Text '2
                .Parameters.Add("@CANTIDAD", SqlDbType.Float, 53).Value = TXENTRADACANTIDAD.Text '3
                .Parameters.Add("@NUMERO_LOTE", SqlDbType.NVarChar, 255).Value = TXENTRADALOTE.Text '4
                .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 255).Value = TXENTRADAUNIDAD.Text '5
                .Parameters.Add("@FECHA_RECEPCION_MATERIAL", SqlDbType.Date).Value = DTENTRADAFECHA.Text '6
                .Parameters.Add("@CERTIFICADOS_MATERIAL", SqlDbType.NVarChar, 255).Value = TXENTRADACERTIFICADOS.Text '7
                .Parameters.Add("@COLADA", SqlDbType.NVarChar, 255).Value = TXENTRADACOLADA.Text '8
                .Parameters.Add("@FABRICANTE", SqlDbType.NVarChar, 255).Value = TXENTRADAFABRICANTE.Text '9
                .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = TXENTRADADESCRIPCION.Text '10
                .Parameters.Add("@NUM_CERT", SqlDbType.NVarChar, 255).Value = TXNUMCERTIFICADO.Text '11
                .Parameters.Add("@DESC_CORTA ", SqlDbType.NVarChar, 255).Value = TXDESCCORTA.Text '12
                .Parameters.Add("@COD_CLIENTE", SqlDbType.NVarChar, 255).Value = TXTCODCLIENTE.Text '13
                .Parameters.Add("@CERT_TCM", SqlDbType.NVarChar, 255).Value = TXCERTIFICADOTCM.Text '14
                .Parameters.Add("@DIAMETRO", SqlDbType.NVarChar, 255).Value = TXTDIAMETROALMACEN.Text '15 DIAMETRO UNO
                .Parameters.Add("@CEDULA", SqlDbType.NVarChar, 255).Value = TXTCEDULAALMACEN.Text '16 CEDULA UNO
                .Parameters.Add("@PESO", SqlDbType.Float, 53).Value = TXTPESOALMACEN.Text '17
                .Parameters.Add("@CEDULA2", SqlDbType.NVarChar, 255).Value = txtcedula2.Text '18 CEDULA 2
                .Parameters.Add("@DIAMETRO2", SqlDbType.NVarChar, 255).Value = txtdiametro2.Text '19 DIAMETRO 2
                .Parameters.Add("@PESOT_TOTAL", SqlDbType.Float, 53).Value = TXTPESTOTAL.Text '20
                .Parameters.Add("@CANTIDAD_PRINC", SqlDbType.Float, 53).Value = TXTALTERNO.Text
                .Parameters.Add("@ITEM", SqlDbType.NVarChar, 255).Value = TXTITEM.Text
            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("ENTRADA DE MATERIAL REGISTRADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    LIMPIAR()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' LIMPIAR()
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub BTNEDITAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNEDITAR.Click
        Dim VAL As Boolean = False
        EP.SetError(TXIDENTRADA, "")
        If (TXIDENTRADA.Text.Trim = "") Then
            EP.SetError(TXIDENTRADA, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If

        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("EDIT_ALMACEN", CN)
                COMANDO.CommandType = CommandType.StoredProcedure
                With COMANDO
                    .Parameters.AddWithValue("@ID", TXIDENTRADA.Text)
                    .Parameters.Add("@CODIGO_MATERIAL", SqlDbType.NVarChar, 255).Value = TXENTRADACODIGO.Text
                    .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 255).Value = TXENTRADAMATERIAL.Text
                    .Parameters.Add("@CANTIDAD", SqlDbType.Float, 53).Value = TXENTRADACANTIDAD.Text
                    .Parameters.Add("@NUMERO_LOTE", SqlDbType.NVarChar, 255).Value = TXENTRADALOTE.Text
                    .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 255).Value = TXENTRADAUNIDAD.Text
                    .Parameters.Add("@FECHA_RECEPCION_MATERIAL", SqlDbType.Date).Value = DTENTRADAFECHA.Text
                    .Parameters.Add("@CERTIFICADOS_MATERIAL", SqlDbType.NVarChar, 255).Value = TXENTRADACERTIFICADOS.Text
                    .Parameters.Add("@COLADA", SqlDbType.NVarChar, 255).Value = TXENTRADACOLADA.Text
                    .Parameters.Add("@FABRICANTE", SqlDbType.NVarChar, 255).Value = TXENTRADAFABRICANTE.Text
                    .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = TXENTRADADESCRIPCION.Text
                    .Parameters.Add("@NUM_CERT", SqlDbType.NVarChar, 255).Value = TXNUMCERTIFICADO.Text
                    .Parameters.Add("@DESC_CORTA ", SqlDbType.NVarChar, 255).Value = TXDESCCORTA.Text
                    .Parameters.Add("@COD_CLIENTE", SqlDbType.NVarChar, 255).Value = TXTCODCLIENTE.Text
                    .Parameters.Add("@CERT_TCM", SqlDbType.NVarChar, 255).Value = TXCERTIFICADOTCM.Text
                    .Parameters.Add("@DIAMETRO", SqlDbType.NVarChar, 255).Value = TXTDIAMETROALMACEN.Text
                    .Parameters.Add("@CEDULA", SqlDbType.NVarChar, 255).Value = TXTCEDULAALMACEN.Text
                    .Parameters.Add("@PESO", SqlDbType.Float, 53).Value = TXTPESOALMACEN.Text
                    .Parameters.Add("@CEDULA2", SqlDbType.NVarChar, 255).Value = txtcedula2.Text '18 CEDULA 2
                    .Parameters.Add("@DIAMETRO2", SqlDbType.NVarChar, 255).Value = txtdiametro2.Text
                    .Parameters.Add("@PESOT_TOTAL", SqlDbType.Float, 53).Value = TXTPESTOTAL.Text '20
                    .Parameters.Add("@CANTIDAD_PRINC", SqlDbType.Float, 53).Value = TXTALTERNO.Text
                    .Parameters.Add("@ITEM", SqlDbType.NVarChar, 255).Value = TXTITEM.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE ALMACEN MODIFICADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' LIMPIAR()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' LIMPIAR()
            Finally
                DECONECTARBD()

            End Try
        End If


    End Sub

    Private Sub BTNELIMINAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim VAL As Boolean = False
        EP.SetError(TXIDENTRADA, "")
        If (TXIDENTRADA.Text.Trim = "") Then
            EP.SetError(TXIDENTRADA, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If

        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (MessageBox.Show("¿DESEA ELIMINAR ESTE REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("ELIM_ALMACEN", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXIDENTRADA.Text)
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMPIAR()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMPIAR()
            Finally
                DECONECTARBD()

            End Try

        End If
    End Sub

    Private Sub ButtonX6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX6.Click
        LIMPIAR()
    End Sub

    Private Sub BTNVER_Click(sender As System.Object, e As System.EventArgs) Handles BTNVER.Click
        REGISTROALMACEN.Show()
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            MENUPRINCIPAL.Show()

        End If
    End Sub

    Private Sub BTNCOMPROBAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNCOMPROBAR.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("VERIFICAR", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@NUMERO", SqlDbType.NVarChar, 255).Value = TXCODIGOMATERIALCOMP.Text
            End With
            DR = COMANDO.ExecuteReader()

            Do While DR.Read
                LBVERIFICACION.Text = DR.GetValue(0)
            Loop

            If (LBVERIFICACION.Text > 0) Then
                LBVERIFICACION.ForeColor = Color.Green
                LBVER.Text = "DISPONIBLES"
                LBVER.ForeColor = Color.Green
                BTNGUARDASALIDA.Enabled = True
                BTNEDITARSALIDA.Enabled = True
                BTNELIMINARSALIDA.Enabled = True
                MessageBox.Show("¡EXISTE MATERIAL!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information )
            Else
                LBVER.Text = "NO HAY EN EXISTENCIA"
                LBVERIFICACION.ForeColor = Color.Red
                LBVER.ForeColor = Color.Red
                BTNGUARDASALIDA.Enabled = False
                BTNEDITARSALIDA.Enabled = False
                BTNELIMINARSALIDA.Enabled = False
                MessageBox.Show("¡VERIFICAR PRIMERO SUS EXISTENCIAS!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub BTNGUARDASALIDA_Click(sender As System.Object, e As System.EventArgs) Handles BTNGUARDASALIDA.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("INS_SALIDA_ALMACEN", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@CLAVE_TUBERO", SqlDbType.NVarChar, 255).Value = SALIDACBCLAVE.Text
                .Parameters.Add("@CONSECUTIVO_INTERNO", SqlDbType.NVarChar, 255).Value = SALIDACONSECUTIVO.Text
                .Parameters.Add("@NUMERO_ISOMETRICO ", SqlDbType.NVarChar, 255).Value = SALIDACBISOMETRICO.Text
                .Parameters.Add("@CODIGO_MATERIAL", SqlDbType.NVarChar, 255).Value = SALIDACBCODIGOMATE.Text
                .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 255).Value = SALIDAUNIDAD.Text
                .Parameters.Add("@CANTIDAD", SqlDbType.Float, 53).Value = SALIDACANTIDAD.Text
                .Parameters.Add("@FECHA_SALIDA", SqlDbType.NVarChar, 255).Value = SALIDAFECHA.Text
                .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 255).Value = SALIDAOBSERVACION.Text
                .Parameters.Add("@COLADA", SqlDbType.NVarChar, 255).Value = SALIDACOLADA.Text
            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("SALIDA REGISTRADA EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)


            COMANDO = New SqlCommand("EDITACOLUMNAEXISTENCIA", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.Add("@NUMERO", SqlDbType.NVarChar, 255).Value = restante.Text
                .Parameters.Add("@CODIGO", SqlDbType.NVarChar, 255).Value = SALIDACBCODIGOMATE.Text
            End With


            COMANDO.ExecuteNonQuery()
            MessageBox.Show("¡SUS EXISTENCIAS FUERON ACTUALIZADAS!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '   CLEARSALIDA()




        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' CLEARSALIDA()
        Finally
            DECONECTARBD()


        End Try
    End Sub

    Private Sub ENTRADA_SALIDAS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' OBJ_COD_MAT()
        'OBJ_NUM_ISO()

    End Sub

    Private Sub BTNNUEVOSALIDA_Click(sender As System.Object, e As System.EventArgs) Handles BTNNUEVOSALIDA.Click
        CLEARSALIDA()
        OBJ_COD_MAT()
        OBJ_NUM_ISO()

    End Sub

    Private Sub SALIDACANTIDAD_TextChanged(sender As System.Object, e As System.EventArgs) Handles SALIDACANTIDAD.TextChanged
        restante.Text = Val(LBVERIFICACION.Text) - Val(SALIDACANTIDAD.Text)
    End Sub

    Private Sub BTNEDITARSALIDA_Click(sender As System.Object, e As System.EventArgs) Handles BTNEDITARSALIDA.Click
        Dim VAL As Boolean = False
        EP.SetError(SALIDAID, "")
        If (SALIDAID.Text.Trim = "") Then
            EP.SetError(SALIDAID, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If

        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DE SALIDA DE ALMACEN?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("EDIT_SALIDA_ALMACEN", CN)
                COMANDO.CommandType = CommandType.StoredProcedure


                With COMANDO
                    .Parameters.AddWithValue("@ID", SALIDAID.Text)
                    .Parameters.Add("@CLAVE_TUBERO", SqlDbType.NVarChar, 255).Value = SALIDACBCLAVE.Text
                    .Parameters.Add("@CONSECUTIVO_INTERNO", SqlDbType.NVarChar, 255).Value = SALIDACONSECUTIVO.Text
                    .Parameters.Add("@NUMERO_ISOMETRICO", SqlDbType.NVarChar, 255).Value = SALIDACBISOMETRICO.Text
                    .Parameters.Add("@CODIGO_MATERIAL", SqlDbType.NVarChar, 255).Value = SALIDACBCODIGOMATE.Text
                    .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 255).Value = SALIDAUNIDAD.Text
                    .Parameters.Add("@CANTIDAD", SqlDbType.Float, 53).Value = SALIDACANTIDAD.Text
                    .Parameters.Add("@FECHA_SALIDA", SqlDbType.NVarChar, 255).Value = SALIDAFECHA.Text
                    .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 255).Value = SALIDAOBSERVACION.Text
                    .Parameters.Add("@COLADA", SqlDbType.NVarChar, 255).Value = SALIDACOLADA.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE SALIDA MODIFICADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CLEARSALIDA()

            End Try
        End If

    End Sub

    Private Sub BTNELIMINARSALIDA_Click(sender As System.Object, e As System.EventArgs) Handles BTNELIMINARSALIDA.Click
        Dim VAL As Boolean = False
        EP.SetError(SALIDAID, "")
        If (SALIDAID.Text.Trim = "") Then
            EP.SetError(SALIDAID, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If

        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DE SALIDA DE ALMACEN?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else


            Try
                CONECTARBD()
                COMANDO = New SqlCommand("ELIM_SALIDA_ALMACEN", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", SALIDAID.Text)

                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE SALIDA ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CLEARSALIDA()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CLEARSALIDA()
            Finally
                DECONECTARBD()

            End Try
        End If

    End Sub

    Private Sub BTNVERREGISTRO_Click(sender As System.Object, e As System.EventArgs) Handles BTNVERREGISTRO.Click
        REGISTROSALIDALMACEN.Show()
    End Sub

    Private Sub LLENARLISTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLENARLISTASToolStripMenuItem.Click
        OBJ_COD_MAT()
        OBJ_NUM_ISO()
        LLENAR_CLAVE_TUBERO()
    End Sub

    Private Sub TODASLASSALIDASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODASLASSALIDASToolStripMenuItem.Click
        FRMREPORTESALIDAALMACEN.Show()
    End Sub

    Private Sub TODASLASENTRADASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODASLASENTRADASToolStripMenuItem.Click
        FrmReporteEntradaMaterial.Show()
    End Sub

    Private Sub PORFECHADESALIDAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORFECHADESALIDAToolStripMenuItem.Click
        FRMREPORTEFECHAENTRADA.Show()
    End Sub

    Private Sub PORFECHADESALIDAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORFECHADESALIDAToolStripMenuItem1.Click
        FRMSALIDASFECHAALMACEN.Show()

    End Sub

    Private Sub USUARIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USUARIOSToolStripMenuItem.Click
        USUARIOSALMACEN.Show()
    End Sub
    '***********************************AUTOCOMPLETAR************************************************************
    Private Sub TXENTRADACODIGO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXENTRADACODIGO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select CODIGO_MATERIAL FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CODIGO_MATERIAL").ToString())
            Next
            TXENTRADACODIGO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXENTRADACODIGO.AutoCompleteCustomSource = col
            TXENTRADACODIGO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXTCODCLIENTE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCODCLIENTE.KeyPress
        If e.KeyChar = Chr(13) Then
            ' Ejecuto codigo
            OBT()

        End If

    End Sub

    Private Sub TXTCODCLIENTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCODCLIENTE.TextChanged

        Try
            Dim cmd As New SqlCommand("Select  DISTINCT CODE_NUMBER FROM LIBRERIA", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "LIBRERIA")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CODE_NUMBER").ToString())
            Next
            TXTCODCLIENTE.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTCODCLIENTE.AutoCompleteCustomSource = col
            TXTCODCLIENTE.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try




    End Sub

    Private Sub TXENTRADALOTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXENTRADALOTE.TextChanged
        Try
            Dim cmd As New SqlCommand("Select NUMERO_LOTE FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("NUMERO_LOTE").ToString())
            Next
            TXENTRADALOTE.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXENTRADALOTE.AutoCompleteCustomSource = col
            TXENTRADALOTE.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXENTRADAUNIDAD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXENTRADAUNIDAD.TextChanged
        Try
            Dim cmd As New SqlCommand("Select UNIDAD FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("UNIDAD").ToString())
            Next
            TXENTRADAUNIDAD.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXENTRADAUNIDAD.AutoCompleteCustomSource = col
            TXENTRADAUNIDAD.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXENTRADAFABRICANTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim cmd As New SqlCommand("Select FABRICANTE FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("FABRICANTE").ToString())
            Next
            TXENTRADAFABRICANTE.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXENTRADAFABRICANTE.AutoCompleteCustomSource = col
            TXENTRADAFABRICANTE.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXNUMCERTIFICADO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXNUMCERTIFICADO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select NUM_CERTIFICADO FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("NUM_CERTIFICADO").ToString())
            Next
            TXNUMCERTIFICADO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXNUMCERTIFICADO.AutoCompleteCustomSource = col
            TXNUMCERTIFICADO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SALIDACONSECUTIVO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIDACONSECUTIVO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select CONSECUTIVO_INTERNO FROM SALIDA_ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "SALIDA_ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CONSECUTIVO_INTERNO").ToString())
            Next
            SALIDACONSECUTIVO.AutoCompleteSource = AutoCompleteSource.CustomSource
            SALIDACONSECUTIVO.AutoCompleteCustomSource = col
            SALIDACONSECUTIVO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXCODIGOMATERIALCOMP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXCODIGOMATERIALCOMP.TextChanged
        Try
            Dim cmd As New SqlCommand("Select CODIGO_MATERIAL FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CODIGO_MATERIAL").ToString())
            Next
            TXCODIGOMATERIALCOMP.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXCODIGOMATERIALCOMP.AutoCompleteCustomSource = col
            TXCODIGOMATERIALCOMP.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub CLIENTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLIENTESToolStripMenuItem.Click
        REGLIBRERIA.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        OBT()
        TXENTRADACODIGO.Text = TXTCODCLIENTE.Text
    End Sub

    Private Sub BUSQUEDAAVANZADAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSQUEDAAVANZADAToolStripMenuItem1.Click
        REGISTROALMACEN.Show()

    End Sub

    Private Sub BUSQUEDAAVANZADASALIDASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSQUEDAAVANZADASALIDASToolStripMenuItem.Click
        REGISTROSALIDALMACEN.Show()
    End Sub

    Private Sub TXTPESOALMACEN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPESOALMACEN.TextChanged
        Try
            TXTPESTOTAL.Text = Val(TXENTRADACANTIDAD.Text) * Val(TXTPESOALMACEN.Text)



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TXENTRADACANTIDAD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXENTRADACANTIDAD.TextChanged
        TXTALTERNO.Text = Me.TXENTRADACANTIDAD.Text
    End Sub

    Private Sub TXENTRADACOLADA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXENTRADACOLADA.TextChanged

    End Sub

    Private Sub SALIDACOLADA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIDACOLADA.TextChanged
        Try
            Dim cmd As New SqlCommand("Select COLADA FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("COLADA").ToString())
            Next
            SALIDACOLADA.AutoCompleteSource = AutoCompleteSource.CustomSource
            SALIDACOLADA.AutoCompleteCustomSource = col
            SALIDACOLADA.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub EXISTENCIASDEALMACENToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXISTENCIASDEALMACENToolStripMenuItem.Click
        FRMEXIXTENCIAS.Show()

    End Sub
End Class