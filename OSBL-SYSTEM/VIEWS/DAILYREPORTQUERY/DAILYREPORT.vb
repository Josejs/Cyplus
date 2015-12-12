Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar

Public Class DAILYREPORT
    Dim indicador As Integer
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
#Region "METODOS"
    Sub LIMPIAR()
        TXTARMADODAILY.ResetText()

        TXTCLAVETUBDAILY.ResetText()
        TXTCODIGODAILY.ResetText()

        TXTDESCRIPCIONDAILY.ResetText()
        TXTESPECIFICACIONDAILY.ResetText()
      
        TXTFONDEODAILY.ResetText()
        TXTIDDAILY.Clear()
        TXTJUNTADAILY.ResetText()
        TXTCT.ResetText()
        TXTCOLADADAILY.ResetText()
        TXTCODIGODAILY2.ResetText()
        TXTDESC2.ResetText()
        TXTCOLADA2.ResetText()
        TXTISOMETRICO.Clear()
        TXTRELLENODAILY.ResetText()
        TXTRXDAILY.ResetText()

        TXTSOLDADURADAILY.ResetText()
        TXTSPOOLDAILY.ResetText()
        TXTSPOOLUNIDODAILY.ResetText()
        TXTTIPOJUNTADAILY.ResetText()
        TXTWPSDAILY.ResetText()
        TXTXDIAMETRODAILY.ResetText()

    End Sub
    Sub OBTENER_SPOOL_UNIDO()
        Try
            CONECTARBD()
            CADENA = "SELECT spool from TBL_SPOOL WHERE NUMERO_ISOMETRICO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTSPOOLDAILY.DataSource = DS.Tables(0)
            TXTSPOOLDAILY.DisplayMember = "spool"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub OBJ_NUM_SPOOL()
        Try
            CONECTARBD()
            CADENA = "SELECT NUMERO_SPOOL from TBL_SPOOL WHERE SPOOL='" & TXTSPOOLDAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTSPOOLUNIDODAILY.DataSource = DS.Tables(0)
            TXTSPOOLUNIDODAILY.DisplayMember = "NUMERO_SPOOL"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_TIPOJU()
        Try
            CONECTARBD()
            CADENA = "SELECT TIPO1 FROM JUNTAS WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'AND JUNTA='" & TXTJUNTADAILY.Text & "'" ' AND SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBTI1.DataSource = DS.Tables(0)
            CBTI1.DisplayMember = "TIPO1"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR21", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Sub OBJ_JUNTA()
        Try
            CONECTARBD()
            CADENA = "SELECT JUNTA,TIPO1 FROM JUNTAS WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'AND SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'" ' AND JUNTA='" & TXTJUNTADAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTJUNTADAILY.DataSource = DS.Tables(0)
            TXTJUNTADAILY.DisplayMember = "JUNTA"
            CBTI1.DataSource = DS.Tables(0)
            CBTI1.DisplayMember = "TIPO1"
            

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub
    Sub OBJ_TIPO_JUNTA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT TIPO_JTA from JUNTAS WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTTIPOJUNTADAILY.DataSource = DS.Tables(0)
            TXTTIPOJUNTADAILY.DisplayMember = "TIPO_JTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBJ_DIAM_JUNTA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT DIAM_JTA from JUNTAS WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'" ' AND SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'AND TIPO_JTA='" & TXTTIPOJUNTADAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTXDIAMETRODAILY.DataSource = DS.Tables(0)
            TXTXDIAMETRODAILY.DisplayMember = "DIAM_JTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBJ_CAMP_TLLER()
        Try
            CONECTARBD()
            CADENA = "SELECT CAMP_TLLER from JUNTAS WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'AND JUNTA='" & TXTJUNTADAILY.Text & "'" 'AND TIPO1='" & CBTI1.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTCT.DataSource = DS.Tables(0)
            TXTCT.DisplayMember = "CAMP_TLLER"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR23", MessageBoxButtons.OK, MessageBoxIcon.Error)
       

        End Try
    End Sub
    Sub obt_fondeo_r1_tubero()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT FONDEO1_P,R1_P,TUBERO_P from PRODUCCION_DIARIA WHERE ISOMETRICO_P='" & TXTISOMETRICO.Text & "'" 'AND SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTFONDEODAILY.DataSource = DS.Tables(0)
            TXTFONDEODAILY.DisplayMember = "FONDEO1_P"

            TXTRELLENODAILY.DataSource = DS.Tables(0)
            TXTRELLENODAILY.DisplayMember = "R1_P"

            TXTCLAVETUBDAILY.DataSource = DS.Tables(0)
            TXTCLAVETUBDAILY.DisplayMember = "TUBERO_P"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_DESCRIPCION()
        Try
            '  CONECTARBD2()
            CADENA = "SELECT DESCRIP1,DESCRIP2 FROM JUNTAS WHERE JUNTA='" & TXTJUNTADAILY.Text & "'AND NUM_ISO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXTDESCRIPCIONDAILY.DataSource = DS.Tables(0)
            TXTDESCRIPCIONDAILY.DisplayMember = "DESCRIP1"

            TXTDESC2.DataSource = DS.Tables(0)
            TXTDESC2.DisplayMember = "DESCRIP2"
        Catch ex As Exception

        End Try
    End Sub
    Sub obt_codigo()
        CADENA = "SELECT DISTINCT CODIGO_CLIENTE, COLADA from MAT_ISO WHERE DESCRIPCION='" & TXTDESCRIPCIONDAILY.Text & "'"

        COMANDO = New SqlCommand()
        COMANDO.CommandText = CADENA
        COMANDO.CommandType = CommandType.Text
        COMANDO.Connection = CN
        ADP = New SqlDataAdapter(COMANDO)
        DS = New DataSet()
        ADP.Fill(DS)

        TXTCODIGODAILY.DataSource = DS.Tables(0)
        TXTCODIGODAILY.DisplayMember = "CODIGO_CLIENTE"
        TXTCOLADADAILY.DataSource = DS.Tables(0)
        TXTCOLADADAILY.DisplayMember = "COLADA"

        '  TXTCODIGODAILY2.DataSource = DS.Tables(0)
        ' TXTCODIGODAILY2.DisplayMember = "CODIGO_MAT"


    End Sub
    Sub obt_codigo2()
        CADENA = "SELECT DISTINCT CODIGO_CLIENTE, COLADA from MAT_ISO WHERE DESCRIPCION='" & TXTDESC2.Text & "'"

        COMANDO = New SqlCommand()
        COMANDO.CommandText = CADENA
        COMANDO.CommandType = CommandType.Text
        COMANDO.Connection = CN
        ADP = New SqlDataAdapter(COMANDO)
        DS = New DataSet()
        ADP.Fill(DS)

        TXTCODIGODAILY2.DataSource = DS.Tables(0)
        TXTCODIGODAILY2.DisplayMember = "CODIGO_CLIENTE"
        TXTCOLADA2.DataSource = DS.Tables(0)
        TXTCOLADA2.DisplayMember = "COLADA"

        '  TXTCODIGODAILY2.DataSource = DS.Tables(0)
        ' TXTCODIGODAILY2.DisplayMember = "CODIGO_MAT"


    End Sub
    Sub OBT_FECHA_ARM_SOLDADURA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT FECHA_ARMADO_P,FECHA_SOLDADURA_P from PRODUCCION_DIARIA WHERE ISOMETRICO_P='" & TXTISOMETRICO.Text & "'" 'AND SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTARMADODAILY.DataSource = DS.Tables(0)
            TXTARMADODAILY.DisplayMember = "FECHA_ARMADO_P"

            TXTSOLDADURADAILY.DataSource = DS.Tables(0)
            TXTSOLDADURADAILY.DisplayMember = "FECHA_SOLDADURA_P"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_COD_MAT2_DEC2_COL2()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT CODIGO_MAT,COLADA from MAT_ISO WHERE ISOMETRICO='" & TXTISOMETRICO.Text & "' AND NUM_SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTCODIGODAILY2.DataSource = DS.Tables(0)
            TXTCODIGODAILY2.DisplayMember = "CODIGO_MAT"

            TXTCODIGODAILY2.DataSource = DS.Tables(0)
            TXTCODIGODAILY2.DisplayMember = "CODIGO_MAT"

            ' TXTDESC2.DataSource = DS.Tables(0)
            'TXTDESC2.DisplayMember = "DESCRIPCION"
            TXTCOLADA2.DataSource = DS.Tables(0)
            TXTCOLADA2.DisplayMember = "COLADA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_COD_MAT_DESC_COLADA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT CODIGO_MAT, COLADA from MAT_ISO WHERE ISOMETRICO='" & TXTISOMETRICO.Text & "' AND NUM_SPOOL='" & TXTSPOOLUNIDODAILY.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTCODIGODAILY.DataSource = DS.Tables(0)
            TXTCODIGODAILY.DisplayMember = "CODIGO_MAT"


            ' TXTDESCRIPCIONDAILY.DataSource = DS.Tables(0)
            'TXTDESCRIPCIONDAILY.DisplayMember = "DESCRIPCION"

            TXTCOLADADAILY.DataSource = DS.Tables(0)
            TXTCOLADADAILY.DisplayMember = "COLADA"

            ' TXTCODIGODAILY2.DataSource = DS.Tables(0)
            ' TXTCODIGODAILY2.DisplayMember = "CODIGO_MAT"

            ' TXTDESC2.DataSource = DS.Tables(0)
            ' TXTDESC2.DisplayMember = "DESCRIPCION"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub OBT_WPS()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT WPS_P from PRODUCCION_DIARIA WHERE ISOMETRICO_P='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTWPSDAILY.DataSource = DS.Tables(0)
            TXTWPSDAILY.DisplayMember = "WPS_P"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_ESPC_RX()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT ESPECIFICACION,RX from TBL_ISO WHERE NUM_ISO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTESPECIFICACIONDAILY.DataSource = DS.Tables(0)
            TXTESPECIFICACIONDAILY.DisplayMember = "ESPECIFICACION"

            TXTRXDAILY.DataSource = DS.Tables(0)
            TXTRXDAILY.DisplayMember = "RX"


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
            FRMINICIOCALID.Show()
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        ERP.SetError(TXTSPOOLDAILY, "")
        ERP.SetError(TXTSPOOLUNIDODAILY, "")
        ERP.SetError(TXTJUNTADAILY, "")
        ERP.SetError(TXTISOMETRICO, "")

        Dim valida As Boolean = False

        If (TXTISOMETRICO.Text.Trim = "") Then
            ERP.SetError(TXTISOMETRICO, "DEBE ASIGNAR EL NUMERO DE ISOMETRICO")
        End If

        If (TXTSPOOLDAILY.Text.Trim = "") Then
            ERP.SetError(TXTSPOOLDAILY, "DEBE ASIGNAR EL NUMERO DEL SPOOL")
            valida = True
        End If
        If (TXTSPOOLUNIDODAILY.Text.Trim = "") Then
            ERP.SetError(TXTSPOOLUNIDODAILY, "DEBE ASIGNAR EL SPOOL")
            valida = True
        End If

        If (valida = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INSERTAR_RDQ", CN)
                COMANDO.CommandType = CommandType.StoredProcedure
                With COMANDO
                    .Parameters.Add("@ISOMETRICO", SqlDbType.NVarChar, 250).Value = TXTISOMETRICO.Text
                    .Parameters.Add("@SPOOL_UNIDO", SqlDbType.NVarChar, 250).Value = TXTSPOOLDAILY.Text
                    .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = TXTSPOOLUNIDODAILY.Text
                    .Parameters.Add("@JUNTA", SqlDbType.NVarChar, 255).Value = TXTJUNTADAILY.Text
                    .Parameters.Add("@TIPO_JUNTA", SqlDbType.NVarChar, 250).Value = TXTTIPOJUNTADAILY.Text
                    .Parameters.Add("@DIAMETRO_JUNTA", SqlDbType.Float, 53).Value = TXTXDIAMETRODAILY.Text
                    .Parameters.Add("@C_T", SqlDbType.NVarChar, 250).Value = TXTCT.Text
                    .Parameters.Add("@FONDEO", SqlDbType.NVarChar, 250).Value = TXTFONDEODAILY.Text
                    .Parameters.Add("@RELLENO", SqlDbType.NVarChar, 250).Value = TXTRELLENODAILY.Text
                    .Parameters.Add("@CLAVE_TUBERO", SqlDbType.NVarChar, 250).Value = TXTCLAVETUBDAILY.Text

                    .Parameters.Add("@FECHA_SOLDADURA", SqlDbType.NVarChar, 250).Value = TXTSOLDADURADAILY.Text
                    .Parameters.Add("@FECHA_ARMADO", SqlDbType.NVarChar, 250).Value = TXTARMADODAILY.Text

                    .Parameters.Add("@CODIGO_MAT", SqlDbType.NVarChar, 250).Value = TXTCODIGODAILY.Text
                    .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 250).Value = TXTDESCRIPCIONDAILY.Text
                    .Parameters.Add("@COLADA", SqlDbType.NVarChar, 250).Value = TXTCOLADADAILY.Text
                    .Parameters.Add("@CODIGO_MAT2", SqlDbType.NVarChar, 250).Value = TXTCODIGODAILY2.Text
                    .Parameters.Add("@DESCRIPCION2", SqlDbType.NVarChar, 250).Value = TXTDESC2.Text
                    .Parameters.Add("@COLADA2", SqlDbType.NVarChar, 250).Value = TXTCOLADA2.Text
                    .Parameters.Add("@WPS", SqlDbType.NVarChar, 250).Value = TXTWPSDAILY.Text
                    .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 250).Value = TXTESPECIFICACIONDAILY.Text
                    .Parameters.Add("@RX", SqlDbType.Float, 53).Value = TXTRXDAILY.Text
                    .Parameters.Add("@TIPO1", SqlDbType.NVarChar, 100).Value = CBTI1.Text
                    ' .Parameters.Add("@CLAVE_TUB", SqlDbType.NVarChar, 250).Value = TXTCLAVETUBDAILY.Text

                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO GUARDADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMPIAR()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()

            End Try
        End If



    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        ERP.SetError(TXTIDDAILY, "")
        Dim valida As Boolean = False

        If (TXTIDDAILY.Text.Trim = "") Then
            ERP.SetError(TXTIDDAILY, "DEBE ESPECIFICAR EL IDENTIFICADOR")
            valida = True

        End If


        If (valida = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR ESTE REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDITAR_RDQ", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTIDDAILY.Text)
                        .Parameters.Add("@ISOMETRICO", SqlDbType.NVarChar, 250).Value = TXTISOMETRICO.Text
                        .Parameters.Add("@SPOOL_UNIDO", SqlDbType.NVarChar, 250).Value = TXTSPOOLDAILY.Text
                        .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = TXTSPOOLUNIDODAILY.Text
                        .Parameters.Add("@JUNTA", SqlDbType.NVarChar, 255).Value = TXTJUNTADAILY.Text
                        .Parameters.Add("@TIPO_JUNTA", SqlDbType.NVarChar, 250).Value = TXTTIPOJUNTADAILY.Text
                        .Parameters.Add("@DIAMETRO_JUNTA", SqlDbType.Float, 53).Value = TXTXDIAMETRODAILY.Text
                        .Parameters.Add("@C_T", SqlDbType.NVarChar, 250).Value = TXTCT.Text
                        .Parameters.Add("@FONDEO", SqlDbType.NVarChar, 250).Value = TXTFONDEODAILY.Text
                        .Parameters.Add("@RELLENO", SqlDbType.NVarChar, 250).Value = TXTRELLENODAILY.Text
                        .Parameters.Add("@CLAVE_TUBERO", SqlDbType.NVarChar, 250).Value = TXTCLAVETUBDAILY.Text

                        .Parameters.Add("@FECHA_SOLDADURA", SqlDbType.NVarChar, 250).Value = TXTSOLDADURADAILY.Text
                        .Parameters.Add("@FECHA_ARMADO", SqlDbType.NVarChar, 250).Value = TXTARMADODAILY.Text

                        .Parameters.Add("@CODIGO_MAT", SqlDbType.NVarChar, 250).Value = TXTCODIGODAILY.Text
                        .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 250).Value = TXTDESCRIPCIONDAILY.Text
                        .Parameters.Add("@COLADA", SqlDbType.NVarChar, 250).Value = TXTCOLADADAILY.Text
                        .Parameters.Add("@CODIGO_MAT2", SqlDbType.NVarChar, 250).Value = TXTCODIGODAILY2.Text
                        .Parameters.Add("@DESCRIPCION2", SqlDbType.NVarChar, 250).Value = TXTDESC2.Text
                        .Parameters.Add("@COLADA2", SqlDbType.NVarChar, 250).Value = TXTCOLADA2.Text
                        .Parameters.Add("@WPS", SqlDbType.NVarChar, 250).Value = TXTWPSDAILY.Text
                        .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 250).Value = TXTESPECIFICACIONDAILY.Text
                        .Parameters.Add("@RX", SqlDbType.Float, 53).Value = TXTRXDAILY.Text
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO MODIFICADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMPIAR()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        ERP.SetError(TXTIDDAILY, "")
        Dim valida As Boolean = False

        If (TXTIDDAILY.Text.Trim = "") Then
            ERP.SetError(TXTIDDAILY, "DEBE ESPECIFICAR EL IDENTIFICADOR")
            valida = True

        End If


        If (valida = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR ESTE REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIMINAR_RDQ", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure


                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTIDDAILY.Text)

                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMPIAR()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If

    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        LIMPIAR()
    End Sub

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click

        RegDaily.Show()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNENTER.Click
        ERP.SetError(TXTISOMETRICO, "")
        ERP.SetError(TXTISOMETRICO, "")

        Dim VALIDA As Boolean = False


        If (TXTISOMETRICO.Text.Trim = "") Then
            ERP.SetError(TXTISOMETRICO, "DEBE ESPECIFICAR EL NUMERO DE ISOMETRICO")
            VALIDA = True
        End If

        If (VALIDA = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                OBTENER_SPOOL_UNIDO() '
                OBJ_NUM_SPOOL() '


                OBJ_JUNTA() '
                OBJ_TIPO_JUNTA() '
                OBJ_DIAM_JUNTA() '
                OBJ_CAMP_TLLER() '
                ' OBT_COD_MAT_DESC_COLADA()
                'OBT_COD_MAT2_DEC2_COL2()
                obt_codigo() '
                obt_codigo2() '
                OBT_DESCRIPCION() '
                OBT_WPS() '
                obt_fondeo_r1_tubero()
                OBT_FECHA_ARM_SOLDADURA()
                OBT_ESPC_RX()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        OBJ_NUM_SPOOL()
    End Sub

    Private Sub TXTISOMETRICO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTISOMETRICO.TextChanged
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
            TXTISOMETRICO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTISOMETRICO.AutoCompleteCustomSource = col
            TXTISOMETRICO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        OBJ_JUNTA()

    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        OBJ_TIPO_JUNTA()
        ' OBT_COD_MAT_DESC_COLADA()
        ' OBT_COD_MAT2_DEC2_COL2()
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        OBJ_DIAM_JUNTA()
    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        OBJ_CAMP_TLLER()
    End Sub

    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        obt_fondeo_r1_tubero()
    End Sub

    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click
        OBT_FECHA_ARM_SOLDADURA()
    End Sub

    Private Sub ButtonX10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX10.Click
        OBT_COD_MAT_DESC_COLADA()
        OBT_COD_MAT2_DEC2_COL2()
        MessageBox.Show("VERIFIQUE EN LA TABLA DE MATERIALES", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonX11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX11.Click
        OBT_WPS()
        OBT_ESPC_RX()
    End Sub

    Private Sub VISTAGENERALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VISTAGENERALToolStripMenuItem.Click
        'vistaConsulta.Show()
    End Sub





    Private Sub LLENARLISTADEJUNTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLENARLISTADEJUNTASToolStripMenuItem.Click
        ERP.SetError(TXTISOMETRICO, "")
        Dim VALIDAR As Boolean = False
        If (TXTISOMETRICO.Text.Trim = "") Then
            ERP.SetError(TXTISOMETRICO, "DEBE ASIGNAR PRIMERO EL NUMERO DE ISOMETRICO")
            VALIDAR = True
        End If
        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try

                LlamarDatos("SELECT NUM_ISO,SPOOL,JUNTA,TIPO1,TIPO_JTA,DIAM_JTA,CAMP_TLLER,CMAT1,DESCRIP1,COLADA1,CMAT2,DESCRIP2,COLADA2 FROM JUNTAS WHERE NUM_ISO ='" & TXTISOMETRICO.Text & "' ORDER BY JUNTA ASC")
                DT = New DataTable

                ADP.Fill(DT)
                DataGridView1.DataSource = DT


                LlamarDatos("SELECT ISOMETRICO_P,SPOOL_P ,JUNTA_P,TIPO1_P,FONDEO1_P,R1_P,TUBERO_P ,FECHA_SOLDADURA_P,FECHA_ARMADO_P FROM PRODUCCION_DIARIA WHERE ISOMETRICO_P ='" & TXTISOMETRICO.Text & "' ORDER BY JUNTA_P ASC")
                DT = New DataTable

                ADP.Fill(DT)
                DataGridView2.DataSource = DT

                LlamarDatos("SELECT ISOMETRICO,NUM_SPOOL,HOJA,CODIGO_MAT,DESCRIPCION,COLADA FROM MAT_ISO WHERE ISOMETRICO ='" & TXTISOMETRICO.Text & "'")
                DT = New DataTable

                ADP.Fill(DT)
                DataGridView3.DataSource = DT
                '----------------------------------------
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub TXTJUNTADAILY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTJUNTADAILY.SelectedIndexChanged
        Try
            OBT_DESCRIPCION()
            ' OBJ_CAMP_TLLER()
            obt_codigo()
            obt_codigo2()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR22", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ButtonX12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX12.Click
        CALIDADFR.Show()
    End Sub



    Private Sub CLASESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLASESToolStripMenuItem.Click
        CLASES.Show()
    End Sub

    Private Sub ESTADODESPOOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ESTADODESPOOLToolStripMenuItem.Click
        FRMPAINT.Show()

    End Sub

    Private Sub LIBERACIONPARAPINTURAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBERACIONPARAPINTURAToolStripMenuItem.Click
        FRMREGLIBERACION.Show()
    End Sub

    Private Sub RPACKINGLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPACKINGLISTToolStripMenuItem.Click
        PACKINGLIST.Show()
    End Sub





    Private Sub ButtonX1_Click_1(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        OBT_TIPOJU()
    End Sub

    Private Sub W10ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        FRMW10.Show()

    End Sub

    Private Sub W10PORISOMETRICOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W10PORISOMETRICOToolStripMenuItem.Click
        FRMW10PORISOMETRICO.Show()
    End Sub

    Private Sub W10PORISOMETRICOYSPOOLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W10PORISOMETRICOYSPOOLToolStripMenuItem.Click
        FRMW10PORSPOOL.Show()
    End Sub

    Private Sub W24ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W24ToolStripMenuItem.Click
        FRMW24.Show()

    End Sub

    Private Sub W24POSPOOLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W24POSPOOLToolStripMenuItem.Click
        FRMW24XSPOOL.Show()
    End Sub

    Private Sub PORTADAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PORTADAToolStripMenuItem.Click
        FRMPORTADA.Show()

    End Sub

    Private Sub QC15ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QC15ToolStripMenuItem.Click
        QC15PACK.Show()
    End Sub

    Private Sub PRUEBASToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PRUEBASToolStripMenuItem.Click
        CALIDADFR.Show()
    End Sub

    Private Sub PACKINGLISTToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PACKINGLISTToolStripMenuItem.Click

    End Sub
End Class