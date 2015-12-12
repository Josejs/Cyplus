Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class PRODUCIONDIARIA
    Dim INDICADOR As Integer
#Region "METODOS"

    Sub BUSCAISO_REV()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("BUSCAISO_REV", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
               
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DR.Close()
            DECONECTARBD()


        End Try

    End Sub

    Sub OBT_INFO()
        Try
            CONECTARBD()
            CADENA = "SELECT TOTAL_JTA,HOJA,REV,JUNTA,TIPO1,TIPO2,SPOOL,CAMP_TLLER,PLG_STD,DIAM1,DIAM2,TIPO_JTA,DIAM_JTA from JUNTAS WHERE NUM_ISO='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTOTALJUNTAS.DataSource = DS.Tables(0)
            TXTOTALJUNTAS.DisplayMember = "TOTAL_JTA"

            TXTHOJA.DataSource = DS.Tables(0)
            TXTHOJA.DisplayMember = "HOJA"

            TXTREVISION.DataSource = DS.Tables(0)
            TXTREVISION.DisplayMember = "REV"

            TXTJUNTA.DataSource = DS.Tables(0)
            TXTJUNTA.DisplayMember = "JUNTA"

            JUNTATIPO1.DataSource = DS.Tables(0)
            JUNTATIPO1.DisplayMember = "TIPO1"

            JUNTATIPO2.DataSource = DS.Tables(0)
            JUNTATIPO2.DisplayMember = "TIPO2"

            TXTALLERCAMPO.DataSource = DS.Tables(0)
            TXTALLERCAMPO.DisplayMember = "CAMP_TLLER"

            TXTPLGSTD.DataSource = DS.Tables(0)
            TXTPLGSTD.DisplayMember = "PLG_STD"
            TXTSPOOL.DataSource = DS.Tables(0)
            TXTSPOOL.DisplayMember = "SPOOL"

            TXTDIAM.DataSource = DS.Tables(0)
            TXTDIAM.DisplayMember = "DIAM1"

            TXTDIAM2.DataSource = DS.Tables(0)
            TXTDIAM2.DisplayMember = "DIAM2"

            TXTTIPOJUNTA.DataSource = DS.Tables(0)
            TXTTIPOJUNTA.DisplayMember = "TIPO_JTA"

            TXTDIAMETROORIGINAL.DataSource = DS.Tables(0)
            TXTDIAMETROORIGINAL.DisplayMember = "DIAM_JTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT AREA from TBL_ISO WHERE NUM_ISO='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXTAREA.DataSource = DS.Tables(0)
            TXTAREA.DisplayMember = "AREA"

        Catch EX As Exception
            MessageBox.Show(EX.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub OBT_material()
        Try
            CONECTARBD()
            sasa = "SELECT DESCRIP from MATERIAL_GROUP WHERE MATERIAL='" & CBESPEC.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = sasa
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            txtmaterial.DataSource = DS.Tables(0)
            txtmaterial.DisplayMember = "DESCRIP"

        Catch EX As Exception
            MessageBox.Show(EX.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub OBT_LINE()
        Try
            CONECTARBD()
            CADENA = "SELECT LINEA from TBL_ISO WHERE NUM_ISO='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXTLINEAISOMETRIC.DataSource = DS.Tables(0)
            TXTLINEAISOMETRIC.DisplayMember = "LINEA"

        Catch EX As Exception
            MessageBox.Show(EX.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_PLG_STD()
        Try
            CONECTARBD()
            CADENA = "SELECT PLG_STD from JUNTAS WHERE NUM_ISO='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXTPLGSTD.DataSource = DS.Tables(0)
            TXTPLGSTD.DisplayMember = "PLG_STD"

        Catch EX As Exception
            MessageBox.Show(EX.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Sub Limpiar_TextBox()
        TXTALLERCAMPO.ResetText()
        TXTDIAMETROORIGINAL.ResetText()
        CBSERV.ResetText()
        CBESPEC.ResetText()

        TXTAREA.ResetText()
        TXTDIAM.ResetText()
        TXTDIAM2.ResetText()
        TXTF1.Clear()
        JUNTATIPO1.ResetText()
        JUNTATIPO2.ResetText()
        JUNTANUMISO.Clear()
        TXTF2.Clear()
        TXTHOJA.ResetText()
        TXTID.Clear()
        TXTJUNTA.ResetText()
        TXTLINEAISOMETRIC.ResetText()
        txtmaterial.ResetText()
        TXTNOREPORTE.Clear()
        TXTOBSERVACIONES.Clear()
        TXTOTALJUNTAS.ResetText()
        TXTPLGSTD.ResetText()
        TXTR1.Clear()
        TXTR2.Clear()
        TXTREVISION.ResetText()
        TXTSOLDADURA.Clear()
        TXTSPOOL.ResetText()
        TXTTIPOJUNTA.ResetText()
        TXTTUBERO.Clear()
        TXTWPS.ResetText()
        TXTXCEDULA.Clear()
        TXTXFECHARMADO.Clear()


    
    End Sub
    Sub OBJ_SERVICIO()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT SERVICIO from TBL_ISO WHERE NUM_ISO='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBSERV.DataSource = DS.Tables(0)
            CBSERV.DisplayMember = "SERVICIO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub
    Sub OBJ_ESPEC()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT ESPECIFICACION from TBL_ISO WHERE NUM_ISO='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBESPEC.DataSource = DS.Tables(0)
            CBESPEC.DisplayMember = "ESPECIFICACION"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub
    Sub VALIDAR_REGISTRO()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SP_VALIDAR_JUNTA_PRODUCCION", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            ADP = New SqlDataAdapter(COMANDO)
            With COMANDO
                .Parameters.Add("@P_ISOMETRICO_PRODUCCCION", SqlDbType.NVarChar, 100).Value = JUNTANUMISO.Text
                .Parameters.Add("@P_JUNTA_PRODUCCION", SqlDbType.NVarChar, 100).Value = TXTJUNTA.Text
                .Parameters.Add("@P_TIPO_UNO_PRODUCCION", SqlDbType.NVarChar, 100).Value = JUNTATIPO1.Text
                .Parameters.Add("@P_TIPO_DOS_PRODUCCION", SqlDbType.NVarChar, 100).Value = JUNTATIPO2.Text
                .Parameters.Add("@P_SPOOL_PRODUCCION", SqlDbType.NVarChar, 100).Value = TXTSPOOL.Text
                '   .Parameters.Add("@P_NO_SPOOL_PRODUCCION", SqlDbType.NVarChar, 100).Value = P_NO_SPOOL.Text
                Dim msgparam As New SqlParameter("@MSG", SqlDbType.VarChar, 100)
                msgparam.Direction = ParameterDirection.Output
                .Parameters.Add(msgparam)
                Dim rowsAffected As Integer = COMANDO.ExecuteNonQuery()
                Dim mensaje As String = ""
                If rowsAffected > 0 Then
                    Convert.ToString(MessageBox.Show(COMANDO.Parameters("@MSG").Value))
                    'LBLERROR.Text = Convert.ToString(COMANDO.Parameters("@msg").Value)
                    Exit Sub
                Else
                    Convert.ToString(MessageBox.Show(COMANDO.Parameters("@MSG").Value))
                    ' LBLERROR.Text = Convert.ToString(COMANDO.Parameters("@msg").Value)
                End If
            End With
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

        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA3.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA3.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub JUNTANUMISO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JUNTANUMISO.TextChanged
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
            JUNTANUMISO.AutoCompleteSource = AutoCompleteSource.CustomSource
            JUNTANUMISO.AutoCompleteCustomSource = col
            JUNTANUMISO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNINFORMACION.Click
        OBT_INFO()
        OBT_AREA()
        OBT_LINE()
        OBT_PLG_STD()
        OBJ_SERVICIO()
        OBJ_ESPEC()
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim VALIDAR As Boolean = False

        ep.SetError(TXTNOREPORTE, "")
        ep.SetError(TXTXFECHARMADO, "")
        ep.SetError(TXTOTALJUNTAS, "")
        ep.SetError(CBSERV, "")
        ep.SetError(CBESPEC, "")
        ep.SetError(JUNTANUMISO, "")
        ep.SetError(TXTAREA, "")
        ep.SetError(TXTHOJA, "")
        ep.SetError(TXTJUNTA, "")
        ep.SetError(JUNTATIPO1, "")
        ep.SetError(JUNTATIPO2, "")
        ep.SetError(TXTSPOOL, "")
        ep.SetError(TXTDIAM, "")
        ep.SetError(TXTDIAM2, "")
        ep.SetError(TXTTIPOJUNTA, "")
        ep.SetError(TXTREVISION, "")
        ep.SetError(TXTALLERCAMPO, "")
        ep.SetError(TXTF1, "")
        ep.SetError(TXTF2, "")
        ep.SetError(TXTR1, "")
        ep.SetError(TXTR2, "")
        ep.SetError(TXTTUBERO, "")
        ep.SetError(TXTSOLDADURA, "")
        ep.SetError(TXTWPS, "")
        ep.SetError(TXTPLGSTD, "")
        ep.SetError(TXTXCEDULA, "")
        ep.SetError(txtmaterial, "")
        ep.SetError(TXTOBSERVACIONES, "")
        ep.SetError(TXTLINEAISOMETRIC, "")

        If (TXTNOREPORTE.Text.Trim = "") Then
            ep.SetError(TXTNOREPORTE, "DEBE ESPECIFICAR EL CONSECUTIVO DE NUMERO DE REPORTE")
            VALIDAR = True
        End If

        If (TXTXFECHARMADO.Text.Trim = "") Then
            ep.SetError(TXTXFECHARMADO, "DEBE ESPECIFICAR LA FECHA DE ARMADO DEL REPORTE")
            VALIDAR = True
        End If
        If (TXTOTALJUNTAS.Text.Trim = "") Then
            ep.SetError(TXTOTALJUNTAS, "DEBE ESPECIFICAR EL TOTAL DE JUNTAS")
            VALIDAR = True
        End If
        If (CBSERV.Text.Trim = "") Then
            ep.SetError(CBSERV, "DEBE ESPECIFICAR EL SERVICIO")
            VALIDAR = True
        End If
        If (CBESPEC.Text.Trim = "") Then
            ep.SetError(CBESPEC, "DEBE ESPECIFICAR LA ESPECIFICACION")
            VALIDAR = True
        End If
        If (JUNTANUMISO.Text.Trim = "") Then
            ep.SetError(JUNTANUMISO, "DEBE ESPECIFICAR LA JUNTA DEL ISOMETRICO DEL REPORTE")
            VALIDAR = True
        End If
        If (TXTAREA.Text.Trim = "") Then
            ep.SetError(TXTAREA, "DEBE ESPECIFICAR EL AREA")
            VALIDAR = True
        End If
        If (TXTHOJA.Text.Trim = "") Then
            ep.SetError(TXTHOJA, "DEBE ESPECIFICAR EL NUMERO DE HOJA")
            VALIDAR = True
        End If
        If (TXTJUNTA.Text.Trim = "") Then
            ep.SetError(TXTJUNTA, "DEBE ESPECIFICAR EL NUMERO DE JUNTA")
            VALIDAR = True
        End If
        If (JUNTATIPO1.Text.Trim = "") Then
            ep.SetError(JUNTATIPO1, "DEBE ESPECIFICAR EL PRIMER TIPO DE LA JUNTA -,A,C")
            VALIDAR = True
        End If
        If (JUNTATIPO2.Text.Trim = "") Then
            ep.SetError(JUNTATIPO2, "DEBE ESPECIFICAR EL SEGUNDO TIPO DE LA JUNTA -,A,C")
            VALIDAR = True
        End If
        If (TXTSPOOL.Text.Trim = "") Then
            ep.SetError(TXTSPOOL, "DEBE ESPECIFICAR EL SPOOL")
            VALIDAR = True
        End If
        If (TXTDIAM.Text.Trim = "") Then
            ep.SetError(TXTDIAM, "DEBE ESPECIFICAR EL DIAMETRO 1 DE LA JUNTA")
            VALIDAR = True
        End If
        If (TXTDIAM2.Text.Trim = "") Then
            ep.SetError(TXTDIAM2, "DEBE ESPECIFICAR EL DIAMETRO 2 DE LA JUNTA")
            VALIDAR = True
        End If
        If (TXTTIPOJUNTA.Text.Trim = "") Then
            ep.SetError(TXTTIPOJUNTA, "DEBE ESPECIFICAR EL TIPO DE JUNTA")
            VALIDAR = True
        End If
        If (TXTREVISION.Text.Trim = "") Then
            ep.SetError(TXTREVISION, "DEBE ESPECIFICAR LA REVISION")
            VALIDAR = True
        End If


        If (TXTALLERCAMPO.Text.Trim = "") Then
            ep.SetError(TXTALLERCAMPO, "DEBE ESPECIFICAR SI LA JUNTA ES S-F")
            VALIDAR = True
        End If
        If (TXTF1.Text.Trim = "") Then
            ep.SetError(TXTF1, "DEBE ESPECIFICAR EL FONDEADOR 1 DE LA JUNTA")
            VALIDAR = True
        End If
        If (TXTF2.Text.Trim = "") Then
            ep.SetError(TXTF2, "DEBE ESPECIFICAR EL FONDEADOR 2 DE LA JUNTA")
            VALIDAR = True
        End If

        If (TXTR1.Text.Trim = "") Then
            ep.SetError(TXTR1, "DEBE ESPECIFICAR EL RELLENADOR 1 DE LA JUNTA")
            VALIDAR = True
        End If
        If (TXTR2.Text.Trim = "") Then
            ep.SetError(TXTR2, "DEBE ESPECIFICAR EL RELLENADOR 2 DE LA JUNTA")
            VALIDAR = True
        End If

        If (TXTTUBERO.Text.Trim = "") Then
            ep.SetError(TXTTUBERO, "DEBE ESPECIFICAR EL TUBERO DE LA JUNTA")
            VALIDAR = True
        End If

        If (TXTSOLDADURA.Text.Trim = "") Then
            ep.SetError(TXTSOLDADURA, "DEBE ESPECIFICAR LA FECHA DE SOLDADURA DE LA JUNTA")
            VALIDAR = True
        End If


        If (TXTWPS.Text.Trim = "") Then
            ep.SetError(TXTWPS, "DEBE ESPECIFICAR EL WPS DE LA JUNTA")
            VALIDAR = True
        End If



        If (TXTPLGSTD.Text.Trim = "") Then
            ep.SetError(TXTPLGSTD, "DEBE ESPECIFICAR LA PULGADA ESTANDARD DE LA JUNTA")
            VALIDAR = True
        End If
        If (TXTXCEDULA.Text.Trim = "") Then
            ep.SetError(TXTXCEDULA, "DEBE ESPECIFICAR LA CEDULA DE LA JUNTA")
            VALIDAR = True
        End If


        If (txtmaterial.Text.Trim = "") Then
            ep.SetError(txtmaterial, "DEBE ESPECIFICAR EL MATERIAL DE LA JUNTA")
            VALIDAR = True
        End If
        If (TXTOBSERVACIONES.Text.Trim = "") Then
            ep.SetError(TXTOBSERVACIONES, "DEBE ESPECIFICAR LAS OBSERVACIONES")
            VALIDAR = True
        End If
        If (TXTLINEAISOMETRIC.Text.Trim = "") Then
            ep.SetError(TXTLINEAISOMETRIC, "DEBE ESPECIFICAR LA LINEA DE LA JUNTA")
            VALIDAR = True
        End If

        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ToastNotification.Show(Me, "PARA VER LA AYUDA PASE EL CURSOR SOBRE LOS CAMPOS DE TEXTO", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Exit Sub
        Else
            'If (TXTXCEDULA.TextLength < 3) Then
            'MessageBox.Show("DEBES INGRESAR LA CEDULA CORRESPONDIENTE A ESTA JUNTA", "ERROR,", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            Try
                VALIDAR_REGISTRO()
                CONECTARBD()
                COMANDO = New SqlCommand("INS_PRODUCCION_DIARIA", CN)
                COMANDO.CommandType = CommandType.StoredProcedure


                With COMANDO
                    .Parameters.Add("@NO_REPORTE ", SqlDbType.NVarChar, 250).Value = TXTNOREPORTE.Text
                    .Parameters.Add("@FECHA_ARMADO ", SqlDbType.Date).Value = TXTXFECHARMADO.Text
                    .Parameters.Add("@TOTAL_JUNTAS  ", SqlDbType.NVarChar, 250).Value = TXTOTALJUNTAS.Text
                    .Parameters.Add("@ISOMETRICO ", SqlDbType.NVarChar, 250).Value = JUNTANUMISO.Text
                    .Parameters.Add("@NO_HOJA ", SqlDbType.NVarChar, 250).Value = TXTHOJA.Text
                    .Parameters.Add("@REVISION ", SqlDbType.NVarChar, 250).Value = TXTREVISION.Text
                    .Parameters.Add("@JUNTA ", SqlDbType.Int).Value = TXTJUNTA.Text
                    .Parameters.Add("@TIPO1 ", SqlDbType.NVarChar, 250).Value = JUNTATIPO1.Text
                    .Parameters.Add("@TIPO2 ", SqlDbType.NVarChar, 250).Value = JUNTATIPO2.Text
                    .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = TXTSPOOL.Text
                    .Parameters.Add("@AREA ", SqlDbType.NVarChar, 250).Value = TXTAREA.Text
                    .Parameters.Add("@DIAM1 ", SqlDbType.Float, 250).Value = TXTDIAM.Text
                    .Parameters.Add("@DIAM2 ", SqlDbType.Float, 250).Value = TXTDIAM2.Text
                    .Parameters.Add("@TIPO_JTA ", SqlDbType.NVarChar, 250).Value = TXTTIPOJUNTA.Text
                    .Parameters.Add("@CAMP_TALLER ", SqlDbType.NVarChar, 250).Value = TXTALLERCAMPO.Text
                    .Parameters.Add("@FONDEO1 ", SqlDbType.NVarChar, 250).Value = TXTF1.Text
                    .Parameters.Add("@FONDEO2 ", SqlDbType.NVarChar, 250).Value = TXTF2.Text
                    .Parameters.Add("@R1 ", SqlDbType.NVarChar, 250).Value = TXTR1.Text
                    .Parameters.Add("@R2 ", SqlDbType.NVarChar, 250).Value = TXTR2.Text
                    .Parameters.Add("@FECHA_SOLDADURA ", SqlDbType.Date).Value = TXTSOLDADURA.Text
                    .Parameters.Add("@WPS ", SqlDbType.NVarChar, 250).Value = TXTWPS.Text
                    .Parameters.Add("@OBSERVACION ", SqlDbType.NVarChar, 250).Value = TXTOBSERVACIONES.Text
                    .Parameters.Add("@CEDULA ", SqlDbType.NVarChar, 250).Value = TXTXCEDULA.Text
                    .Parameters.Add("@MATERIAL ", SqlDbType.NVarChar, 250).Value = txtmaterial.Text
                    .Parameters.Add("@TUBERO ", SqlDbType.NVarChar, 250).Value = TXTTUBERO.Text
                    .Parameters.Add("@PLG_STD ", SqlDbType.NVarChar, 250).Value = TXTPLGSTD.Text
                    .Parameters.Add("@LINEA ", SqlDbType.NVarChar, 255).Value = TXTLINEAISOMETRIC.Text
                    .Parameters.Add("@SERV", SqlDbType.NVarChar, 255).Value = CBSERV.Text
                    .Parameters.Add("@ESPEC", SqlDbType.NVarChar, 255).Value = CBESPEC.Text
                    .Parameters.Add("@DIAM_JTAS", SqlDbType.Float, 53).Value = TXTDIAMETROORIGINAL.Text
                    Dim msgparam As New SqlParameter("@MSG", SqlDbType.VarChar, 100)
                    msgparam.Direction = ParameterDirection.Output
                    .Parameters.Add(msgparam)
                    Dim rowsAffected As Integer = COMANDO.ExecuteNonQuery()
                    Dim mensaje As String = ""

                    If rowsAffected > 0 Then
                        Convert.ToString(MessageBox.Show(COMANDO.Parameters("@MSG").Value))
                        'LBLERROR.Text = Convert.ToString(COMANDO.Parameters("@msg").Value)
                    Else
                        Convert.ToString(MessageBox.Show(COMANDO.Parameters("@MSG").Value))
                        '  LBLERROR.Text = Convert.ToString(COMANDO.Parameters("@msg").Value)
                    End If



                End With
                COMANDO.ExecuteNonQuery()
                '   MessageBox.Show("REGISTRO INGRESADO CORRECTAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()

            End Try



        End If






    End Sub

    Private Sub PORFECHADESOLDADURAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        diaria.Show()
    End Sub

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click
        REGDIARIOS.Show()
    End Sub

    Private Sub TODOSLAPRODUCCIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODOSLAPRODUCCIONToolStripMenuItem.Click
        TODOSDIARIOS.Show()
    End Sub

    Private Sub TODOSPORFECHAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODOSPORFECHAToolStripMenuItem.Click
        produclineafecha.Show()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        ep.SetError(TXTID, "")
        Dim VALIDAR As Boolean = False
        If (TXTID.Text.Trim = "") Then
            ep.SetError(TXTID, "FALTA EL IDENTIFICADOR")
            VALIDAR = True
        End If
        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("elimPrc_diaria", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTID.Text)
                    End With

                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar_TextBox()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If

        End If


    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        ep.SetError(TXTID, "")
        Dim VALIDAR As Boolean = False
        If (TXTID.Text.Trim = "") Then
            ep.SetError(TXTID, "FALTA EL IDENTIFICADOR")
            VALIDAR = True
        End If
        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_PRODUCTION_DAILY", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure
                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTID.Text)
                        .Parameters.Add("@NO_REPORTE ", SqlDbType.NVarChar, 250).Value = TXTNOREPORTE.Text
                        .Parameters.Add("@FECHA_ARMADO ", SqlDbType.NVarChar, 150).Value = TXTXFECHARMADO.Text
                        .Parameters.Add("@TOTAL_JUNTAS  ", SqlDbType.NVarChar, 250).Value = TXTOTALJUNTAS.Text
                        .Parameters.Add("@ISOMETRICO ", SqlDbType.NVarChar, 250).Value = JUNTANUMISO.Text
                        .Parameters.Add("@NO_HOJA ", SqlDbType.NVarChar, 250).Value = TXTHOJA.Text
                        .Parameters.Add("@REVISION ", SqlDbType.NVarChar, 250).Value = TXTREVISION.Text
                        .Parameters.Add("@JUNTA ", SqlDbType.NVarChar, 250).Value = TXTJUNTA.Text
                        .Parameters.Add("@TIPO1 ", SqlDbType.NVarChar, 250).Value = JUNTATIPO1.Text
                        .Parameters.Add("@TIPO2 ", SqlDbType.NVarChar, 250).Value = JUNTATIPO2.Text
                        .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = TXTSPOOL.Text
                        .Parameters.Add("@AREA ", SqlDbType.NVarChar, 250).Value = TXTAREA.Text
                        .Parameters.Add("@DIAM1 ", SqlDbType.NVarChar, 250).Value = TXTDIAM.Text
                        .Parameters.Add("@DIAM2 ", SqlDbType.NVarChar, 250).Value = TXTDIAM2.Text
                        .Parameters.Add("@TIPO_JTA ", SqlDbType.NVarChar, 250).Value = TXTTIPOJUNTA.Text
                        .Parameters.Add("@CAMP_TALLER ", SqlDbType.NVarChar, 250).Value = TXTALLERCAMPO.Text
                        .Parameters.Add("@FONDEO1 ", SqlDbType.NVarChar, 250).Value = TXTF1.Text
                        .Parameters.Add("@FONDEO2 ", SqlDbType.NVarChar, 250).Value = TXTF2.Text
                        .Parameters.Add("@R1 ", SqlDbType.NVarChar, 250).Value = TXTR1.Text
                        .Parameters.Add("@R2 ", SqlDbType.NVarChar, 250).Value = TXTR2.Text
                        .Parameters.Add("@FECHA_SOLDADURA ", SqlDbType.NVarChar, 250).Value = TXTSOLDADURA.Text
                        .Parameters.Add("@WPS ", SqlDbType.NVarChar, 250).Value = TXTWPS.Text
                        .Parameters.Add("@OBSERVACION ", SqlDbType.NVarChar, 250).Value = TXTOBSERVACIONES.Text
                        .Parameters.Add("@CEDULA ", SqlDbType.NVarChar, 250).Value = TXTXCEDULA.Text
                        .Parameters.Add("@MATERIAL ", SqlDbType.NVarChar, 250).Value = txtmaterial.Text
                        .Parameters.Add("@TUBERO ", SqlDbType.NVarChar, 250).Value = TXTTUBERO.Text
                        .Parameters.Add("@PLG_STD ", SqlDbType.NVarChar, 250).Value = TXTPLGSTD.Text
                        .Parameters.Add("@LINEA ", SqlDbType.NVarChar, 255).Value = TXTLINEAISOMETRIC.Text
                        .Parameters.Add("@SERV", SqlDbType.NVarChar, 255).Value = CBSERV.Text
                        .Parameters.Add("@ESPEC", SqlDbType.NVarChar, 255).Value = CBESPEC.Text
                        .Parameters.Add("@DIAM_JTAS", SqlDbType.Float, 53).Value = TXTDIAMETROORIGINAL.Text
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO MODIFICADO EXITOSAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar_TextBox()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()
                End Try
            End If

        End If

    End Sub


    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        Limpiar_TextBox()
    End Sub

   

    Private Sub TXTXCEDULA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTXCEDULA.TextChanged
       

        Try
            Dim cmd As New SqlCommand("Select CEDULA FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CEDULA").ToString())
            Next
            TXTXCEDULA.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTXCEDULA.AutoCompleteCustomSource = col
            TXTXCEDULA.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub


    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        OBT_material()
    End Sub


    Private Sub MAYORA2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MAYORA2ToolStripMenuItem.Click
        FRMMAYOR_A_DOS.Show()

    End Sub

    Private Sub MENORIGUALA2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MENORIGUALA2ToolStripMenuItem.Click
        FRMMENOR_IGUAL.Show()
    End Sub
End Class