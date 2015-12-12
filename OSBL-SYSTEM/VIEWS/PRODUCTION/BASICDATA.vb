Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class BASICDATA
#Region "METODOS"
    Sub obt_fabricanteSSSDDDFGHJK()
        Try
            CONECTARBD()

            CADENA = "select FABRICANTE from ALMACEN where CODIGO_MATERIAL='" & MATCODIGOtcm.Text & "' AND DESCRIPCION='" & TXTDESCRIPCIONMAT.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            MATFABRICANTESSSSS.DataSource = DS.Tables(0)
            MATFABRICANTESSSSS.DisplayMember = "FABRICANTE"



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBTENER_CODIGO_CLIENTE()

        Try
            CONECTARBD()
            COMANDO = New SqlCommand("OBT_CODIGO_CLIENTE", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@CODIGO", MATCODIGOtcm.Text)
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                MATERIALCODIGOCLIENTE.Text = DR.GetString(0)

                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_material()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("OBT_MATERIAL", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@CODIGO", MATCODIGOtcm.Text)
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TXTDESCRIPCIONMAT.Text = DR.GetString(0)
                TXTUNIDADMAT.Text = DR.GetString(1)
                TXTDIAMETROMAT.Text = DR.GetString(2)
                XTXTDIAM2.Text = DR.GetString(3)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub obt_colada()
        Try
            CONECTARBD2()
            COMANDO = New SqlCommand("sel_colada", CN2)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@material", MATCODIGOtcm.Text)
            End With
            DR = COMANDO.ExecuteReader

            Do While DR.Read
                INDICADOR = 1
                MATCOLADA.Text = DR.GetString(0)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()

        End Try
    End Sub
    Sub CLEAN_mat()
        MATISOMETRICO.Clear()
        TXTCANTIDADMAT.Clear()
        MATID.Clear()
        MATERIALCODIGOCLIENTE.Clear()
        TXTHOJAMATERIAL.Clear()
        TXTHOJATOTALMATERIAL.Clear()
        'TXTCANTIDADHOJAS.Clear()
        TXTNUMSPOOLMATERIAL.Clear()
        TXTREVSPOOLMATERIAL.Clear()
        TXTSPOOLUNIDOMATERIAL.Clear()
        MATPESO.Clear()
        TXTCATEGORIAMAT.ResetText()
        XTXTDIAM2.Clear()

        MATCODIGOtcm.Clear()
        MATCOLADA.Clear()
        TXTDESCRIPCIONMAT.Clear()
        TXTDIAMETROMAT.Clear()
        MATFABRICANTESSSSS.ResetText()
        MATID.Clear()
        MATIDENTIFICADOR.Clear()
        TXTUNIDADMAT.Clear()
        ' MATISOMETRICO.Clear()


    End Sub

#End Region

#Region "METODOS Y VARIABLES"
    Dim INDICADOR As Integer
    Dim COD_USER As String
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN2
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
    'llena listas
    Sub OBJ_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT AREA from TBL_ISO"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBAREA.DataSource = DS.Tables(0)
            CBAREA.DisplayMember = "AREA"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try
    End Sub 'LLENA LA LISTA DE AREA
    Sub OBJ_ESPECIFICACION_CLASE()
        Try
            CONECTARBD()
            CADENA = "select DISTINCT SERVICIO_CLASE, ESPECIFICACION_CLASE,RX from CLASES ORDER BY SERVICIO_CLASE ASC"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBESPECIFICACIONISOMETRICO.DataSource = DS.Tables(0)
            CBESPECIFICACIONISOMETRICO.DisplayMember = "SERVICIO_CLASE"

            CBSERVICIOISOMETRICO.DataSource = DS.Tables(0)
            CBSERVICIOISOMETRICO.DisplayMember = "ESPECIFICACION_CLASE"
            TXTRX.DataSource = DS.Tables(0)
            TXTRX.DisplayMember = "RX"



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub 'LLENA LA LISTA DE ESPECIFICACION DEL ISOMETRICO
    Sub OBJ_NUM_ISO()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT NUM_ISO from TBL_ISO"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBISOMETRICO.DataSource = DS.Tables(0)
            CBISOMETRICO.DisplayMember = "NUM_ISO"

            cbisospoolnum.DataSource = DS.Tables(0)
            cbisospoolnum.DisplayMember = "NUM_ISO"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub 'LLENA LA LISTA DEL NUMERO DE ISOMETRICO
    Sub OBJ_RX()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT RX from CLASES WHERE SERVICIO_CLASE='" & CBSERVICIOISOMETRICO.Text & "' AND ESPECIFICACION_CLASE='" & CBESPECIFICACIONISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTRX.DataSource = DS.Tables(0)
            TXTRX.DisplayMember = "RX"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DE RX
    Sub OBJ_SERVICIO_CLASE()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT SERVICIO_CLASE from clases"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBSERVICIOISOMETRICO.DataSource = DS.Tables(0)
            CBSERVICIOISOMETRICO.DisplayMember = "SERVICIO_CLASE"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL SERVICIO DEL ISOMETRICO
    Sub OBT_RX_CLASE()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT RX from clases WHERE ESPECIFICACION_CLASE='" & CBSERVICIOISOMETRICO.Text & "' AND SERVICIO_CLASE='" & CBESPECIFICACIONISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTRX.DataSource = DS.Tables(0)
            TXTRX.DisplayMember = "RX"
        Catch EX As Exception
            MessageBox.Show(EX.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try

    End Sub
#Region "METODOS"

    'seccion de juntas

    Sub OBJ_SERVICIOjuntas()

        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT Servicio from tbl_iso where num_iso='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            cbserviciojunta.DataSource = DS.Tables(0)
            cbserviciojunta.DisplayMember = "Servicio"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL SERVICIO
    Sub LlenarGrid()

        Try
            ' CONECTARBD()
            CADENA = "Select*from JUNTAS"
            ADP = New SqlDataAdapter(CADENA, CN)
            Dim dt As New DataTable
            ADP.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  Finally
            '   DECONECTARBD()

        End Try

    End Sub
    Sub BUSCATOTALJUNTAS()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SELEC_TOTAL_JUNTA", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@ISO", SqlDbType.Int).Value = JUNTANUMISO.Text
            End With

            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TOTALJUNTAS.Text = DR.GetInt32(0)
                ' TXREVSPOOL.Text = DR.GetString(1)
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub BUSCA_TOTALPULGADAS()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SELET_TOTAL_PLG", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@ISO", SqlDbType.Int).Value = JUNTANUMISO.Text
            End With

            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                PULGADASJUNTAS.Text = DR.GetValue(0)
                ' TXREVSPOOL.Text = DR.GetString(1)
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub LLENARGRID2()
        Try
            CONECTARBD()
            CADENA = "Select IDENTIFICADOR,CODIGO_MAT,NUM_SPOOL,CODIGO_CLIENTE,DESCRIPCION,COLADA,CANTIDAD from MAT_ISO WHERE ISOMETRICO='" & JUNTANUMISO.Text & "'AND NUM_SPOOL='" & JUNTASPOOL.Text & "'"
            ADP = New SqlDataAdapter(CADENA, CN)
            Dim dt As New DataTable
            ADP.Fill(dt)
            DataGridView2.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub CLEAN()
        IDJUNTA.Clear()
        cbserviciojunta.ResetText()
        CBSERVICIOISOMETRICO.ResetText()
        JUNTACAMPOTALLER.ResetText()
        JUNTADESC1.Clear()
        JUNTADESC2.Clear()
        JUNTADIAM1.Clear()
        JUNTADIAM2.Clear()
        JUNTADIAMJUNTA.Clear()
        JUNTAESPECIFICACION.Clear()
        JUNTAHOJA.Clear()
        JUNTAID1.Clear()
        JUNTAID2.Clear()
        JUNTAJUNTA.Clear()
        JUNTANUMISO.Clear()
        JUNTAREVISION.Clear()
        JUNTASPOOL.Clear()
        JUNTATIPO1.Clear()
        JUNTACOLADA1.Clear()
        JUNTACOLADA2.Clear()
        JUNTATIPO2.Clear()
        JUNTATIPOJUNTA.ResetText()
        PULGADASJUNTAS.Clear()
        TOTALJUNTAS.Clear()
        TXTPLGSTD.Clear()

    End Sub
    Sub OB_ESPC()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("OBJ_ESPECF", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.AddWithValue("@ISOM", JUNTANUMISO.Text)

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                JUNTAESPECIFICACION.Text = DR.GetString(0)

                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DR.Close()
            DECONECTARBD()

        End Try
    End Sub
    'FUNCION PARA NO REPETIR LA MISMA JUNTA
    Sub VALIDAR_JUNTA()
        Try
            INDICADOR = 0
            CONECTARBD()
            COMANDO = New SqlCommand("SEL_VAL_JUNTA", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@NUM_ISO", JUNTANUMISO.Text)
                .Parameters.AddWithValue("@HOJA", JUNTAHOJA.Text)
                .Parameters.AddWithValue("@REV", JUNTAREVISION.Text)
                .Parameters.AddWithValue("@JUNTA", JUNTAJUNTA.Text)
                .Parameters.AddWithValue("@TIPO1", JUNTATIPO1.Text)
                .Parameters.AddWithValue("@TIPO2", JUNTATIPO2.Text)
                .Parameters.AddWithValue("@SPOOL", JUNTASPOOL.Text)
            End With
            DR = COMANDO.ExecuteReader

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
    Sub OBT_MAT()

        Try
            CONECTARBD()
            COMANDO = New SqlCommand("OBT_IDMAT", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@IDENTI", JUNTAID1.Text)
                .Parameters.Add("@ISO", SqlDbType.NVarChar, 50).Value = JUNTANUMISO.Text
                .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = JUNTAHOJA.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = JUNTASPOOL.Text
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                JUNTADESC1.Text = DR.GetString(0)
                JUNTACOLADA1.Text = DR.GetString(1)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_MATCODIGO()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SEL_DESCRIPCION_CLIENTE", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue(" @CODIGO_CLIENTE", JUNTAID1.Text)

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                JUNTADESC1.Text = DR.GetString(0)
                JUNTACOLADA1.Text = DR.GetString(1)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT2()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("OBT_IDMAT", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@IDENTI", JUNTAID2.Text)
                .Parameters.Add("@ISO", SqlDbType.NVarChar, 50).Value = JUNTANUMISO.Text
                .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = JUNTAHOJA.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = JUNTASPOOL.Text
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                JUNTADESC2.Text = DR.GetString(0)
                JUNTACOLADA2.Text = DR.GetString(1)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBT_LINEA()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT LINEA from tbl_iso where num_iso='" & JUNTANUMISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBLINEA.DataSource = DS.Tables(0)
            CBLINEA.DisplayMember = "LINEA"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub
    '==========================


    Private _MyStringProperty As String
    Public Property MyStringProperty() As String
        Get
            Return _MyStringProperty
        End Get
        Set(ByVal value As String)
            _MyStringProperty = value
        End Set
    End Property
    Private _MyIntegerProperty As Integer
    Public Property MyIntegerProperty() As Integer
        Get
            Return _MyIntegerProperty
        End Get
        Set(ByVal value As Integer)
            _MyIntegerProperty = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return MyStringProperty
    End Function


#End Region

    '**************************************************************
    Sub BUSCAISO_REV()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("BUSCAISO_REV", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.AddWithValue("@NUMISO", cbisospoolnum.Text)

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TXSPOOL.Text = DR.GetString(0)
                TXREVSPOOL.Text = DR.GetString(1)
                TXSISTEMASPOOL.Text = DR.GetInt32(2)
                TXESPECIFICACIONSPOOL.Text = DR.GetString(3)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DR.Close()
            DECONECTARBD()

        End Try

    End Sub

    Sub BUSCAR_NUMISO()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("BUSCA_NUM_ISO", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.AddWithValue("@NUM_ISO", COD_USER)

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TXTID.Text = DR.GetInt32(0)
                TXTNUMISOS.Text = DR.GetString(1)
                CBISOMETRICO.Text = DR.GetString(1)
                TXTREV.Text = DR.GetString(2)
                TXTNOLINEA.Text = DR.GetString(3)

                CBSERVICIOISOMETRICO.Text = DR.GetString(4)
                CBESPECIFICACIONISOMETRICO.Text = DR.GetString(5)
                TXTRX.Text = DR.GetInt32(6)

                CBAREA.Text = DR.GetString(7)

                'TXRECIBIDOISO.Text = DR.GetString(9)
                TXTCABEZAL.Text = DR.GetString(10)
                TXTCODPINT.Text = DR.GetString(11)
                '    TXTCATEGORIA.Text = DR.GetString(13)
                ' TXTCODIGO.Text = DR.GetString(14)
                ' TXTDIAMETRO.Text = DR.GetString(15)
                ' TXTCANTIDAD.Text = DR.GetInt32(16)
                ' TXTUNIDAD.Text = DR.GetString(17)
                ' TXTDESCRIPCION.Text = DR.GetString(18)


                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            DR.Close()
            DECONECTARBD()

        End Try
    End Sub
    Sub LIMPIARCAMPOS()
        TXTID.Clear()
        ' TXTISOMETRICOS.Clear()
        TXTCABEZAL.Clear()
        DR.Close()

        TXTCODPINT.Clear()

        TXTNOLINEA.Clear()
        TXTNUMISOS.Clear()
        TXTREV.Clear()
        TXTRX.ResetText()
        TXNUMEROSPOOL.Clear()
        CBAREA.ResetText()
        CBESPECIFICACIONISOMETRICO.ResetText()
        CBISOMETRICO.ResetText()
        CBSERVICIOISOMETRICO.ResetText()
        'TXRECIBIDOISO.Clear()
        '  TXTCATEGORIA.ResetText()
        ' TXTCODIGO.Clear()
        ' TXTDIAMETRO.Clear()
        ' TXTCANTIDAD.Clear()
        ' TXTUNIDAD.Clear()
        ' TXTDESCRIPCION.Clear()

    End Sub
    'METODOS DE LA VISTA SPOOL
    Sub LIMPIARSPOOL()
        CBNUMEROISOMETRICOSPOOL.Clear()
        TXIDSPOOL.Clear()
        TXESTADOSPOOL.Clear()
        TXDIAMETROSPOOL.Clear()
        TXESPECIFICACIONSPOOL.Clear()
        TXHOJASPOOL.ResetText()
        TXTIPOSPOOL.Clear()
        TXOBSERVACIONSPOOL.Clear()
        TXPESOSPOOL.Clear()
        TXPULGADASPOOL.Clear()
        TXTCANTIDADHOJAS.ResetText()
        TXTXPND.Clear()
        TXREVSPOOL.Clear()
        TXSISTEMASPOOL.Clear()
        TXSPOOL.Clear()
        DTFECHAARMADOSPOOL.Clear()
        DTFECHACORTESPOOL.Clear()
        DTFECHASOLDSPOOL.Clear()
        TXNUMEROSPOOL.ResetText()
        TXJUNTASSPOOL.Clear()
        TXCONSECUTIVOINTERNO.Clear()
        CBSERVICIO2W.ResetText()
        '********************************
        PSAND.ResetValue()
        PENLACE.ResetText()
        PACABADO.ResetText()
        PLIBERACION.ResetText()
        PCOMPAÑIA.Clear()
        PAREA.Clear()
        POBSERVACION.Clear()
        PNUMEROREP.Clear()
        PNOORDEN.Clear()
        PFECHAORDEN.ResetText()
        PCANTIDAD.Clear()
        PNOEMBARQUE.Clear()
        PFECHAEMBARQUE.ResetText()
        TXTMATERIALIBERACION.ResetText()
        TXTMTS.Text = "0"
        TXTAREA_SPO.Text = "0"
        TXTNOPACKING.Text = "0"
        PCANTIDAD.Text = "0"

    End Sub
    Sub BUSCASPOOL()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("BUSCA_NUM_SPOOL", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.AddWithValue("@NUM", COD_USER)

            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                TXIDSPOOL.Text = DR.GetInt32(0)
                TXNUMEROSPOOL.Text = DR.GetString(1)
                TXSPOOL.Text = DR.GetString(2)
                TXREVSPOOL.Text = DR.GetString(3)
                CBNUMEROISOMETRICOSPOOL.Text = DR.GetString(4)
                TXHOJASPOOL.Text = DR.GetString(5)
                '  TXRESERVASPOOL.Text = DR.GetString(6)
                '  TXPLANOSPOOL.Text = DR.GetString(7)
                TXESTADOSPOOL.Text = DR.GetString(8)
                TXSISTEMASPOOL.Text = DR.GetString(9)
                TXPESOSPOOL.Text = DR.GetValue(10)
                TXTIPOSPOOL.Text = DR.GetString(11)
                DTFECHACORTESPOOL.Text = DR.GetString(12)
                DTFECHAARMADOSPOOL.Text = DR.GetString(13)
                DTFECHASOLDSPOOL.Text = DR.GetString(14)
                TXESPECIFICACIONSPOOL.Text = DR.GetString(15)
                TXDIAMETROSPOOL.Text = DR.GetString(16)
                TXPULGADASPOOL.Text = DR.GetValue(17)
                '   TXESTIMACIONSPOOL.Text = DR.GetString(18)
                TXOBSERVACIONSPOOL.Text = DR.GetString(19)
                'TXCABEZALSPOOL.Text = DR.GetString(20)
                '  TXDIAMHEADSPOOL.Text = DR.GetValue(21)
                TXJUNTASSPOOL.Text = DR.GetValue(22)
                TXCONSECUTIVOINTERNO.Text = DR.GetString(23)
                Exit Do
            Loop
            DR.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DR.Close()

        Finally
            DR.Close()
            DECONECTARBD()

        End Try
    End Sub
    'funcion para validar que no se repita el mismo SPOOL
    Sub validar_SPOOL()
        INDICADOR = 0
        CONECTARBD()
        COMANDO = New SqlCommand("VALIDAR_SPOOL", CN)
        COMANDO.CommandType = CommandType.StoredProcedure
        With COMANDO
            .Parameters.AddWithValue("@NUMERO", TXSPOOL.Text)
            .Parameters.AddWithValue("@HOJA", TXHOJASPOOL.Text)
            .Parameters.AddWithValue("@ISOM", CBNUMEROISOMETRICOSPOOL.Text)
        End With
        DR = COMANDO.ExecuteReader
        Try
            Do While DR.Read
                INDICADOR = 1
                Exit Do
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ToastNotification.Show(Me, "VERIFIQUE QUE NO ESTE REPITIENDO LA HOJA, EL NUMERO DE ISOMETRICO Y EL SPOOL", 6000)
        Finally
            DR.Close()
            DECONECTARBD()

        End Try

    End Sub
    'METODO QUE VALIDARA QUE NO SE REPITA UN ISOMETRICO
    Sub VALI_ISOMETRICO()
        INDICADOR = 0
        CONECTARBD()
        COMANDO = New SqlCommand("VAL_ISOMETRICO", CN)
        COMANDO.CommandType = CommandType.StoredProcedure
        With COMANDO
            .Parameters.AddWithValue("@ISO", TXTNUMISOS.Text)

        End With
        DR = COMANDO.ExecuteReader
        Try
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
    Sub validar_iso_repetido()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("VALIDA_ISO", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@NUM", SqlDbType.NVarChar, 50).Value = CBNUMEROISOMETRICOSPOOL.Text
            End With
            DR = COMANDO.ExecuteReader

            Do While DR.Read
                INDICADOR = 1
                Exit Do
            Loop
            DR.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DR.Close()
        Finally
            DR.Close()
            DECONECTARBD()

        End Try
    End Sub
    Sub LIM_SOPORTE()
        SOPORTECANT.Clear()
        SOPORTECLASE.Clear()
        SOPORTECLASESOPORT.Clear()
        SOPORTECOMPONENTE.Clear()
        SOPORTEDESIGNACION.Clear()
        SOPORTEDM1.Clear()
        SOPORTEDM2.Clear()
        ' SOPORTEDM3.Clear()
        '   SOPORTEDM4.Clear()
        SOPORTEDN.Clear()
        ' SOPORTEDN2.Clear()
        SOPORTEID.Clear()
        SOPORTENUMISO.ResetText()
        SOPORTEPESO.Clear()
        '  SOPORTEUAN.Clear()
        '  SOPORTEUNIDAD.Clear()

        SOPORTEFECHA.ResetValue()
        SOPORTEOBSERVACION.Clear()
    End Sub
    Sub OBT()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SEL_OBT", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                '      .Parameters.AddWithValue("@CODE", TXTCODIGO.Text)
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                '    TXTDESCRIPCION.Text = DR.GetString(0)
                '   TXTUNIDAD.Text = DR.GetString(1)
                ' TXTDIAMETRO.Text = DR.GetString(2)
                ' XTXTDIAM2.Text = DR.GetString(3)
                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub


#End Region

    Sub OBT_ESTADO()
        Try
            CONECTARBD()
            'GADIEL
            COMANDO = New SqlCommand("SP_OBTENER_ESTADO", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            ADP = New SqlDataAdapter(COMANDO)
            With COMANDO
                .Parameters.Add("@ISOMETRICO", SqlDbType.NVarChar, 100).Value = MATISOMETRICO.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = TXTSPOOLUNIDOMATERIAL.Text
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
                    ' LBLERROR.Text = Convert.ToString(COMANDO.Parameters("@msg").Value)
                End If

            End With

            DS = New DataSet()
            ADP.Fill(DS)

            CBESTADOMATERIAL.DataSource = DS.Tables(0)
            CBESTADOMATERIAL.DisplayMember = "ESTADO"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub





    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            FRMINICIOPRODUCCION.Show()
        End If
    End Sub


    Private Sub BUSQUEDAAVANZADAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSQUEDAAVANZADAToolStripMenuItem1.Click
        REGISTROLISTAISOMETRICO.Show()
    End Sub

    Private Sub BUSQUEDAPORNUMERODEISOMETRICOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        COD_USER = InputBox("INTRODUCE EL NUMERO DE ISOMETRICO", "CYPLUS")
        If (COD_USER.Trim <> "") Then
            BUSCAR_NUMISO()

            If (INDICADOR = 0) Then
                MessageBox.Show("EL REGISTRO QUE BUSCA NO SE ENCUENTRA EN EL SISTEMA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DR.Close()

            End If
        End If
    End Sub

    Private Sub BTNGUARDAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim VAL As Boolean = False
        EP.SetError(TXTNUMISOS, "")
        EP.SetError(CBSERVICIOISOMETRICO, "")
        EP.SetError(CBESPECIFICACIONISOMETRICO, "")
        EP.SetError(TXTCABEZAL, "")
        EP.SetError(TXTREV, "")
        EP.SetError(TXTNOLINEA, "")
        EP.SetError(TXTRX, "")
        EP.SetError(CBAREA, "")
        EP.SetError(TXTCODPINT, "")


        If (TXTNUMISOS.Text.Trim = "") Then
            EP.SetError(TXTNUMISOS, "DEBE INTRODUCIR EL NUMERO DE ISOMETRICO")
            VAL = True
        End If

        If (CBSERVICIOISOMETRICO.Text.Trim = "") Then
            EP.SetError(CBSERVICIOISOMETRICO, "DEBE INTRODUCIR EL SERVICIO DE ISOMETRICO")
            VAL = True
        End If

        If (CBESPECIFICACIONISOMETRICO.Text.Trim = "") Then
            EP.SetError(CBESPECIFICACIONISOMETRICO, "DEBE INTRODUCIR LA ESPECIFICACION DEL ISOMETRICO")
            VAL = True
        End If

        If (TXTCABEZAL.Text.Trim = "") Then
            EP.SetError(TXTCABEZAL, "DEBE INTRODUCIR EL DIAMETRO DE CABEZAL DEL ISOMETRICO")
            VAL = True
        End If

        If (TXTREV.Text.Trim = "") Then
            EP.SetError(TXTREV, "DEBE INTRODUCIR EL NUMERO DE REVISION DEL ISOMETRICO")
            VAL = True
        End If

        If (TXTNOLINEA.Text.Trim = "") Then
            EP.SetError(TXTNOLINEA, "DEBE INTRODUCIR EL NUMERO DE LINEA DEL ISOMETRICO")
            VAL = True
        End If

        If (TXTRX.Text.Trim = "") Then
            EP.SetError(TXTRX, "DEBE INTRODUCIR EL NUMERO DE RX DEL ISOMETRICO")
            VAL = True
        End If

        If (CBAREA.Text.Trim = "") Then
            EP.SetError(CBAREA, "DEBE INTRODUCIR EL NUMERO DE AREA DEL ISOMETRICO")
            VAL = True
        End If

        If (TXTCODPINT.Text.Trim = "") Then
            EP.SetError(TXTCODPINT, "DEBE INTRODUCIR EL CODIGO DE PINTURA DEL ISOMETRICO")
            VAL = True
        End If

        If VAL = True Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ToastNotification.Show(Me, "PARA VER LA AYUDA PASE EL CURSOR SOBRE LOS CAMPOS DE TEXTO", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Exit Sub
        Else

            Try
                VALI_ISOMETRICO()

                CONECTARBD()

                COMANDO = New SqlCommand("INSERT_TBL_ISO", CN)
                COMANDO.CommandType = CommandType.StoredProcedure


                With COMANDO
                    .Parameters.Add("@NUM_ISO", SqlDbType.Int).Value = TXTNUMISOS.Text
                    .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = TXTREV.Text
                    .Parameters.Add("@LINEA", SqlDbType.NVarChar, 250).Value = TXTNOLINEA.Text
                    .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 50).Value = CBSERVICIOISOMETRICO.Text
                    .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 250).Value = CBESPECIFICACIONISOMETRICO.Text
                    .Parameters.Add("@RX", SqlDbType.Float, 53).Value = TXTRX.Text
                    .Parameters.Add("@AREA", SqlDbType.Int).Value = CBAREA.Text

                    .Parameters.Add("@DIAM_HEAD ", SqlDbType.Float, 53).Value = TXTCABEZAL.Text
                    .Parameters.Add("@CODIGO_PINTURA", SqlDbType.Int).Value = TXTCODPINT.Text
                    .Parameters.Add("@TOT_REG", SqlDbType.Int).Value = TXTOT.Text


                End With
                Try
                    If (INDICADOR = 1) Then

                        MessageBox.Show("NO SE PUEDE GUARDAR EL ISOMETRICO YA ESTA REGISTRADO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ' DECONECTARBD()
                        ' Exit Sub
                        If (MessageBox.Show("¿DESEA GUARDAR DE TODAS FORMAS?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                            Exit Sub
                            DECONECTARBD()

                        Else
                            MessageBox.Show("EL ISOMETRICO FUE REGISTRADO EXITOSAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            COMANDO.ExecuteNonQuery()

                            MessageBox.Show("ISOMETRICO REGISTRADO CORRECTAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            DECONECTARBD()
                            'LIMPIARCAMPOS()
                            OBJ_NUM_ISO()
                            '  DESABILITAR()

                        End If
                        DECONECTARBD()
                    Else
                        COMANDO.ExecuteNonQuery()
                        MessageBox.Show("EL ISOMETRICO FUE REGISTRADO EXITOSAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '   DESABILITAR()
                        ToastNotification.Show(Me, "PARA AGREGAR LAS HOJAS DEL ISOMETRICO DEBERA USAR EL MENU HOJAS DE ISOMETRICO", My.Resources.descarga, 6000, eToastPosition.TopRight)

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ' LIMPIARSPOOL()
                Finally
                    DECONECTARBD()

                End Try

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMPIARCAMPOS()
            Finally
                DECONECTARBD()
            End Try


        End If


    End Sub

    Private Sub ButtonX6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        LIMPIARCAMPOS()

        TXTNUMISOS.Enabled = True
    End Sub

    Private Sub BTNEDITAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        Dim VAL As Boolean = False

        EP.SetError(TXTID, "")
        If (TXTID.Text.Trim = "") Then
            EP.SetError(TXTID, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (MessageBox.Show("¿DESEA MODIFICAR LA LISTA DEL ISOMETRICO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("EDIT_TBL_ISO", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", SqlDbType.Int).Value = TXTID.Text
                    .Parameters.Add("@NUM_ISO", SqlDbType.Int).Value = TXTNUMISOS.Text
                    .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = TXTREV.Text
                    .Parameters.Add("@LINEA", SqlDbType.NVarChar, 250).Value = TXTNOLINEA.Text

                    .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 50).Value = CBSERVICIOISOMETRICO.Text
                    .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 250).Value = CBESPECIFICACIONISOMETRICO.Text
                    .Parameters.Add("@RX", SqlDbType.Float, 53).Value = TXTRX.Text

                    .Parameters.Add("@AREA", SqlDbType.Int).Value = CBAREA.Text


                    .Parameters.Add("@DIAM_HEAD ", SqlDbType.Float, 53).Value = TXTCABEZAL.Text
                    .Parameters.Add("@CODIGO_PINTURA", SqlDbType.Int).Value = TXTCODPINT.Text
                    .Parameters.Add("@TOT_REG", SqlDbType.Int).Value = TXTOT.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("LISTA DE ISOMETRICO MODIFICADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMPIARCAMPOS()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub BTNELIMINAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim VAL As Boolean = False

        EP.SetError(TXTID, "")
        If (TXTID.Text.Trim = "") Then
            EP.SetError(TXTID, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DE LISTA DE ISOMETRICO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("DELETE_TBL_ISO", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXTID.Text)

                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE LISTA DE ISOMETRICO ELIMINADO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LIMPIARSPOOL()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMPIARSPOOL()
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub BTNVER_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click
        REGISTROLISTAISOMETRICO.Show()
    End Sub
    'BOTONES DE LA VISTA SPOOL
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Dim VAL As Boolean = False
        EP.SetError(TXNUMEROSPOOL, "")
        EP.SetError(TXSPOOL, "")
        EP.SetError(TXREVSPOOL, "")
        EP.SetError(CBNUMEROISOMETRICOSPOOL, "")
        EP.SetError(TXHOJASPOOL, "")
        EP.SetError(TXTCANTIDADHOJAS, "")
        EP.SetError(TXESTADOSPOOL, "")
        EP.SetError(TXSISTEMASPOOL, "")
        EP.SetError(TXPESOSPOOL, "")
        EP.SetError(TXTIPOSPOOL, "")
        EP.SetError(DTFECHACORTESPOOL, "")
        EP.SetError(DTFECHAARMADOSPOOL, "")
        EP.SetError(DTFECHASOLDSPOOL, "")
        EP.SetError(TXESPECIFICACIONSPOOL, "")
        EP.SetError(TXDIAMETROSPOOL, "")
        EP.SetError(TXPULGADASPOOL, "")
        EP.SetError(TXJUNTASSPOOL, "")
        EP.SetError(TXOBSERVACIONSPOOL, "")
        EP.SetError(TXCONSECUTIVOINTERNO, "")
        EP.SetError(CBSERVICIO2W, "")
        EP.SetError(TXTXPND, "")
        EP.SetError(TXTMATERIALIBERACION, "")
        If (TXTMATERIALIBERACION.Text.Trim = "") Then
            EP.SetError(TXTMATERIALIBERACION, "DEBE ESPECIFICAR EL TIPO DE MATERIAL DEL SPOOL")
            MessageBox.Show("VERIFICAR LA ESPECIFICACION, PARA ELEGIR EL TIPO DE MATERIAL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            VAL = True
        End If



        If (TXNUMEROSPOOL.Text.Trim = "") Then
            EP.SetError(TXNUMEROSPOOL, "DEBE INTRODUCIR EL NUMERO DE SPOOL")
            VAL = True
        End If

        If (TXSPOOL.Text.Trim = "") Then
            EP.SetError(TXSPOOL, "DEBE INTRODUCIR EL SPOOL UNIDO")
            VAL = True
        End If

        If (TXREVSPOOL.Text.Trim = "") Then
            EP.SetError(TXREVSPOOL, "DEBE INTRODUCIR LA REVISION DEL SPOOL")
            VAL = True
        End If

        If (CBNUMEROISOMETRICOSPOOL.Text.Trim = "") Then
            EP.SetError(CBNUMEROISOMETRICOSPOOL, "DEBE INTRODUCIR EL ISOMETRICO DEL SPOOL")
            VAL = True
        End If

        If (TXHOJASPOOL.Text.Trim = "") Then
            EP.SetError(TXHOJASPOOL, "DEBE SELECCIONAR LA HOJA A LA CUAL PERTENECE EL SPOOL")
            VAL = True
        End If

        If (TXTCANTIDADHOJAS.Text.Trim = "") Then
            EP.SetError(TXTCANTIDADHOJAS, "DEBE SELECCIONAR EL TOTAL DE LA  HOJA A LA CUAL PERTENECE EL SPOOL")
            VAL = True
        End If

        If (TXESTADOSPOOL.Text.Trim = "") Then
            EP.SetError(TXESTADOSPOOL, "DEBE INTRODUCIR EL ESTADO DEL SPOOL")
            VAL = True
        End If

        If (TXSISTEMASPOOL.Text.Trim = "") Then
            EP.SetError(TXSISTEMASPOOL, "DEBE INTRODUCIR EL SISTEMA DE PINTURA DEL SPOOL")
            VAL = True
        End If

        If (TXPESOSPOOL.Text.Trim = "") Then
            EP.SetError(TXPESOSPOOL, "DEBE INTRODUCIR EL PESO DEL SPOOL")
            VAL = True
        End If

        If (TXTIPOSPOOL.Text.Trim = "") Then
            EP.SetError(TXTIPOSPOOL, "DEBE INTRODUCIR EL TIPO DEL SPOOL")
            VAL = True
        End If

        If (DTFECHACORTESPOOL.Text.Trim = "") Then
            EP.SetError(DTFECHACORTESPOOL, "DEBE INTRODUCIR LA FECHA DE CORTE DEL SPOOL")
            VAL = True
        End If

        If (DTFECHAARMADOSPOOL.Text.Trim = "") Then
            EP.SetError(DTFECHAARMADOSPOOL, "DEBE INTRODUCIR LA FECHA DE ARMADO DEL SPOOL")
            VAL = True
        End If


        If (DTFECHASOLDSPOOL.Text.Trim = "") Then
            EP.SetError(DTFECHASOLDSPOOL, "DEBE INTRODUCIR LA FECHA DE SOLDADURA DEL SPOOL")
            VAL = True
        End If

        If (TXESPECIFICACIONSPOOL.Text.Trim = "") Then
            EP.SetError(TXESPECIFICACIONSPOOL, "DEBE INTRODUCIR LA ESPECIFICACION DE MATERIAL DEL SPOOL")
            VAL = True
        End If

        If (TXDIAMETROSPOOL.Text.Trim = "") Then
            EP.SetError(TXDIAMETROSPOOL, "DEBE INTRODUCIR LA LONGITUD DEL DIAMETRO PRINCIPAL DEL SPOOL")
            VAL = True
        End If

        If (TXPULGADASPOOL.Text.Trim = "") Then
            EP.SetError(TXPULGADASPOOL, "DEBE INTRODUCIR LAS PULGADAS TOTALES DEL SPOOL")
            VAL = True
        End If

        If (TXJUNTASSPOOL.Text.Trim = "") Then
            EP.SetError(TXJUNTASSPOOL, "DEBE INTRODUCIR EL NUMERO TOTAL DE JUNTAS DEL SPOOL")
            VAL = True
        End If

        If (TXOBSERVACIONSPOOL.Text.Trim = "") Then
            EP.SetError(TXOBSERVACIONSPOOL, "DEBE INTRODUCIR LA OBSERVACION PARA ESTE SPOOL")
            VAL = True
        End If

        If (TXCONSECUTIVOINTERNO.Text.Trim = "") Then
            EP.SetError(TXCONSECUTIVOINTERNO, "DEBE INTRODUCIR EL CONSECUTIVO INTERNO DEL SPOOL")
            VAL = True
        End If

        If (CBSERVICIO2W.Text.Trim = "") Then
            EP.SetError(CBSERVICIO2W, "DEBE INTRODUCIR EL SERVICIO DEL SPOOL")
            VAL = True
        End If

        If (TXTXPND.Text.Trim = "") Then
            EP.SetError(TXTXPND, "DEBE INTRODUCIR LA FECHA DE LIBERACION SPOOL")
            VAL = True
        End If
       
        If VAL = True Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ToastNotification.Show(Me, "PARA VER LA AYUDA PASE EL CURSOR SOBRE LOS CAMPOS DE TEXTO", My.Resources.descarga, 6000, eToastPosition.TopRight)

            Exit Sub
        End If
        Try
            validar_SPOOL()
            CONECTARBD()

            COMANDO = New SqlCommand("INSERT_TBL_SPOOL", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@NUMERO_SPOOL", SqlDbType.NVarChar, 50).Value = TXNUMEROSPOOL.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = TXSPOOL.Text
                .Parameters.Add("@REV_SPOOL", SqlDbType.NVarChar, 50).Value = TXREVSPOOL.Text
                .Parameters.Add("@NUMERO_ISOMETRICO", SqlDbType.Int).Value = CBNUMEROISOMETRICOSPOOL.Text
                .Parameters.Add("@HOJA", SqlDbType.NVarChar, 255).Value = TXHOJASPOOL.Text
                .Parameters.Add("@CANTIDAD", SqlDbType.NVarChar, 50).Value = TXTCANTIDADHOJAS.Text
                '.Parameters.Add("@PLANO_RECIBIDO", SqlDbType.NVarChar, 50).Value = TXPLANOSPOOL.Text
                .Parameters.Add("@SISTEMA_PINTURA", SqlDbType.NVarChar, 50).Value = TXSISTEMASPOOL.Text
                .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 150).Value = TXESTADOSPOOL.Text
                .Parameters.Add("@PESO_SPOOL", SqlDbType.Float, 53).Value = TXPESOSPOOL.Text
                .Parameters.Add("@TIPO_SPOOL", SqlDbType.NVarChar, 50).Value = TXTIPOSPOOL.Text
                .Parameters.Add("@FECHA_CORTE_BISEL", SqlDbType.NVarChar, 250).Value = DTFECHACORTESPOOL.Text
                .Parameters.Add("@FECHA_ARMADO ", SqlDbType.NVarChar, 250).Value = DTFECHAARMADOSPOOL.Text
                .Parameters.Add("@FECHA_SOLDADURA", SqlDbType.NVarChar, 250).Value = DTFECHASOLDSPOOL.Text
                .Parameters.Add("@ESPECIFICACION_MATERIAL", SqlDbType.NVarChar, 50).Value = TXESPECIFICACIONSPOOL.Text
                .Parameters.Add("@DIAMETRO_PRINCIPAL", SqlDbType.NVarChar, 255).Value = TXDIAMETROSPOOL.Text
                .Parameters.Add("@PULGADAS_DIAMETRO", SqlDbType.Float, 53).Value = TXPULGADASPOOL.Text
                .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 255).Value = TXOBSERVACIONSPOOL.Text
                .Parameters.Add("@CANT_JUNTAS", SqlDbType.NVarChar, 255).Value = TXJUNTASSPOOL.Text
                .Parameters.Add("@TOTAL_REG", SqlDbType.Int).Value = TXREGSPOOL.Text
                .Parameters.Add("@CONSEC_INT", SqlDbType.NVarChar, 255).Value = TXCONSECUTIVOINTERNO.Text
                .Parameters.Add("@PND", SqlDbType.NVarChar, 255).Value = TXTXPND.Text
                .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 255).Value = CBSERVICIO2W.Text
                'PINTURA**************************************************************************
                .Parameters.Add("@F_SAND_PRIMARIO", SqlDbType.NVarChar, 250).Value = PSAND.Text
                .Parameters.Add("@F_ENLACE", SqlDbType.NVarChar, 250).Value = PENLACE.Text
                .Parameters.Add("@F_ACABADO", SqlDbType.NVarChar, 250).Value = PACABADO.Text
                .Parameters.Add("@F_LIBERACION_PINTURA", SqlDbType.NVarChar, 250).Value = PLIBERACION.Text
                .Parameters.Add("@COMPAÑIA", SqlDbType.NVarChar, 250).Value = PCOMPAÑIA.Text
                .Parameters.Add("@AREA_A_PINTAR", SqlDbType.NVarChar, 50).Value = PAREA.Text
                .Parameters.Add("@OBSERVACIONES_PINTURA", SqlDbType.NVarChar, 100).Value = POBSERVACION.Text
                .Parameters.Add("@NO_REPORT_PINTURA", SqlDbType.NVarChar, 50).Value = PNUMEROREP.Text
                .Parameters.Add("@NO_ORDEN", SqlDbType.NVarChar, 50).Value = PNOORDEN.Text
                .Parameters.Add("@FECHA_ORDEN", SqlDbType.NVarChar, 250).Value = PFECHAORDEN.Text
                .Parameters.Add("@CANTIDAD_SP", SqlDbType.Int).Value = PCANTIDAD.Text
                .Parameters.Add("@NO_EMBARQUE", SqlDbType.NVarChar, 250).Value = PNOEMBARQUE.Text
                .Parameters.Add("@FECHA_EMBARQUE", SqlDbType.NVarChar, 250).Value = PFECHAEMBARQUE.Text
                .Parameters.Add("@NO_PACKING", SqlDbType.Int).Value = TXTNOPACKING.Text
                .Parameters.Add("@F_PACKING", SqlDbType.NVarChar, 250).Value = TXTFECHAPACKING.Text

                .Parameters.Add("@AREA_ISO", SqlDbType.Int).Value = TXTAREA_SPO.Text
                .Parameters.Add("@MATERIAL_SPOOL", SqlDbType.NVarChar, 50).Value = TXTMATERIALIBERACION.Text
                .Parameters.Add("@MTS2", SqlDbType.Float, 53).Value = TXTMTS.Text
                '****************************************************
                .Parameters.Add("@NO_EST_SUBCONTRATISTA", SqlDbType.NVarChar, 50).Value = SPOOL_NO_EST_SUBCONTRATISTA.Text
                .Parameters.Add("@FECHA_EST_SUBCONTRATISTA", SqlDbType.Date).Value = SPOOL_FECHA_ESTIMACION.Value
                .Parameters.Add("@FECHA_MONTADO", SqlDbType.NVarChar, 50).Value = SPOOL_FECHA_MONTADO.Value
                .Parameters.Add("@FECHA_ALINEADO", SqlDbType.NVarChar, 50).Value = SPOOL_FECHA_ALINEADO.Value
                .Parameters.Add("@FECHA_SOLDADO", SqlDbType.NVarChar, 50).Value = SPOOL_FECHA_SOLDADO.Value




            End With

            Try
                If (INDICADOR = 1) Then

                    MessageBox.Show("NO SE PUEDE GUARDAR EL SPOOL YA ESTA REGISTRADO!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'DECONECTARBD()
                    'Exit Sub
                    ToastNotification.Show(Me, "VERIFIQUE QUE NO SE REPITA NUMERO DE HOJA, ISOMETRICO O EL MISMO SPOOL", My.Resources.descarga, 6000, eToastPosition.MiddleCenter)
                    If (MessageBox.Show("¿DESEA REGISTRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                        Exit Sub
                        DECONECTARBD()

                    Else
                        MessageBox.Show("EL SPOOL DE ISOMETRICO FUE REGISTRADO EXITOSAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        COMANDO.ExecuteNonQuery()
                        MessageBox.Show("SPOOL REGISTRADO CORRECTAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DECONECTARBD()
                        ' LIMPIARSPOOL()
                        OBJ_NUM_ISO()
                        ' OBJ_SPOOL()
                        ToastNotification.Show(Me, "POR FAVOR NO BORRE ESTA INFORMACION HASTA QUE HAYA COMPLETADO LA CAPTURA DE LAS JUNTAS Y MATERIAL DEL ISOMETRICO", My.Resources.descarga, 6000, eToastGlowColor.Red)

                    End If
                    DECONECTARBD()
                Else
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("EL SPOOL FUE REGISTRADO EXITOSAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' LIMPIARSPOOL()
            Finally
                DECONECTARBD()

            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' LIMPIARSPOOL()
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        LIMPIARSPOOL()
        ' OBJ_SPOOL()
        '   OBJ_NUM_ISO()


    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        Dim VAL As Boolean = False

        EP.SetError(TXIDSPOOL, "")
        If (TXIDSPOOL.Text.Trim = "") Then
            EP.SetError(TXIDSPOOL, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MessageBox.Show("¿DESEA MODIFICAR LA LISTA DEL SPOOL?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("EDIT_TBL_SPOOL", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXIDSPOOL.Text)
                    .Parameters.Add("@NUMERO_SPOOL", SqlDbType.NVarChar, 50).Value = TXNUMEROSPOOL.Text
                    .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = TXSPOOL.Text
                    .Parameters.Add("@REV_SPOOL", SqlDbType.NVarChar, 50).Value = TXREVSPOOL.Text
                    .Parameters.Add("@NUMERO_ISOMETRICO", SqlDbType.Int).Value = CBNUMEROISOMETRICOSPOOL.Text
                    .Parameters.Add("@HOJA", SqlDbType.NVarChar, 255).Value = TXHOJASPOOL.Text
                    .Parameters.Add("@CANTIDAD", SqlDbType.NVarChar, 50).Value = TXTCANTIDADHOJAS.Text
                    .Parameters.Add("@SISTEMA_PINTURA", SqlDbType.NVarChar, 50).Value = TXSISTEMASPOOL.Text
                    .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 150).Value = TXESTADOSPOOL.Text
                    .Parameters.Add("@PESO_SPOOL", SqlDbType.Float, 53).Value = TXPESOSPOOL.Text
                    .Parameters.Add("@TIPO_SPOOL", SqlDbType.NVarChar, 50).Value = TXTIPOSPOOL.Text
                    .Parameters.Add("@FECHA_CORTE_BISEL", SqlDbType.NVarChar, 250).Value = DTFECHACORTESPOOL.Text
                    .Parameters.Add("@FECHA_ARMADO ", SqlDbType.NVarChar, 250).Value = DTFECHAARMADOSPOOL.Text
                    .Parameters.Add("@FECHA_SOLDADURA", SqlDbType.NVarChar, 250).Value = DTFECHASOLDSPOOL.Text
                    .Parameters.Add("@ESPECIFICACION_MATERIAL", SqlDbType.NVarChar, 50).Value = TXESPECIFICACIONSPOOL.Text
                    .Parameters.Add("@DIAMETRO_PRINCIPAL", SqlDbType.NVarChar, 255).Value = TXDIAMETROSPOOL.Text
                    .Parameters.Add("@PULGADAS_DIAMETRO", SqlDbType.Float, 53).Value = TXPULGADASPOOL.Text
                    .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 255).Value = TXOBSERVACIONSPOOL.Text
                    .Parameters.Add("@CANT_JUNTAS", SqlDbType.NVarChar, 255).Value = TXJUNTASSPOOL.Text
                    .Parameters.Add("@TOTAL_REG", SqlDbType.Int).Value = TXREGSPOOL.Text
                    .Parameters.Add("@CONSEC_INT", SqlDbType.NVarChar, 255).Value = TXCONSECUTIVOINTERNO.Text
                    .Parameters.Add("@PND", SqlDbType.NVarChar, 255).Value = TXTXPND.Text
                    .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 255).Value = CBSERVICIO2W.Text
                    .Parameters.Add("@F_SAND_PRIMARIO", SqlDbType.NVarChar, 250).Value = PSAND.Text
                    .Parameters.Add("@F_ENLACE", SqlDbType.NVarChar, 250).Value = PENLACE.Text
                    .Parameters.Add("@F_ACABADO", SqlDbType.NVarChar, 250).Value = PACABADO.Text
                    .Parameters.Add("@F_LIBERACION_PINTURA", SqlDbType.NVarChar, 250).Value = PLIBERACION.Text
                    .Parameters.Add("@COMPAÑIA", SqlDbType.NVarChar, 250).Value = PCOMPAÑIA.Text
                    .Parameters.Add("@AREA_A_PINTAR", SqlDbType.NVarChar, 50).Value = PAREA.Text
                    .Parameters.Add("@OBSERVACIONES_PINTURA", SqlDbType.NVarChar, 100).Value = POBSERVACION.Text
                    .Parameters.Add("@NO_REPORT_PINTURA", SqlDbType.NVarChar, 50).Value = PNUMEROREP.Text
                    .Parameters.Add("@NO_ORDEN", SqlDbType.NVarChar, 50).Value = PNOORDEN.Text
                    .Parameters.Add("@FECHA_ORDEN", SqlDbType.NVarChar, 250).Value = PFECHAORDEN.Text
                    .Parameters.Add("@CANTIDAD_SP", SqlDbType.Int).Value = PCANTIDAD.Text
                    .Parameters.Add("@NO_EMBARQUE", SqlDbType.NVarChar, 250).Value = PNOEMBARQUE.Text
                    .Parameters.Add("@FECHA_EMBARQUE", SqlDbType.NVarChar, 250).Value = PFECHAEMBARQUE.Text
                    .Parameters.Add("@NO_PACKING", SqlDbType.Int).Value = TXTNOPACKING.Text
                    .Parameters.Add("@F_PACKING", SqlDbType.NVarChar, 250).Value = TXTFECHAPACKING.Text

                    .Parameters.Add("@MATERIAL_SPOOL", SqlDbType.NVarChar, 50).Value = TXTMATERIALIBERACION.Text
                    .Parameters.Add("@AREA_ISO", SqlDbType.Int).Value = TXTAREA_SPO.Text
                    .Parameters.Add("@MTS2", SqlDbType.Float, 53).Value = TXTMTS.Text

                    '********************************************************
                    .Parameters.Add("@NO_EST_SUBCONTRATISTA", SqlDbType.NVarChar, 50).Value = SPOOL_NO_EST_SUBCONTRATISTA.Text
                    .Parameters.Add("@FECHA_EST_SUBCONTRATISTA", SqlDbType.Date).Value = SPOOL_FECHA_ESTIMACION.Value
                    .Parameters.Add("@FECHA_MONTADO", SqlDbType.NVarChar, 50).Value = SPOOL_FECHA_MONTADO.Value
                    .Parameters.Add("@FECHA_ALINEADO", SqlDbType.NVarChar, 50).Value = SPOOL_FECHA_ALINEADO.Value
                    .Parameters.Add("@FECHA_SOLDADO", SqlDbType.NVarChar, 50).Value = SPOOL_FECHA_SOLDADO.Value





                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("LISTA DE SPOOL MODIFICADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMPIARSPOOL()
                SwitchButton1.Value = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMPIARSPOOL()
            Finally
                DECONECTARBD()

            End Try

        End If

    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        Dim VAL As Boolean = False

        EP.SetError(TXIDSPOOL, "")
        If (TXIDSPOOL.Text.Trim = "") Then
            EP.SetError(TXIDSPOOL, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DE LISTA DE SPOOL?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("DELETE_TBL_SPOOL", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXIDSPOOL.Text)

                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE LISTA DE SPOOL ELIMINADO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LIMPIARCAMPOS()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMPIARCAMPOS()
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        FRMPAINT.Show()
    End Sub

    Private Sub CBISOMETRICO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBISOMETRICO.SelectedIndexChanged
        CBNUMEROISOMETRICOSPOOL.Text = CBISOMETRICO.Text
        cbisospoolnum.Text = CBISOMETRICO.Text

        TXTNUMISOS.Text = CBISOMETRICO.Text
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
        LBHORA2.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA2.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
        LBHORA3.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA3.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")

    End Sub


    Private Sub BUSQUEDAAVANZADAToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSQUEDAAVANZADAToolStripMenuItem2.Click
        FRMPAINT.Show()
    End Sub

    Private Sub BUSQUEDAPORNUMERODESPOOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        COD_USER = InputBox("INTRODUCE EL NUMERO DE SPOOL", "CYPLUS")
        If (COD_USER.Trim <> "") Then
            BUSCASPOOL()

            If (INDICADOR = 0) Then
                MessageBox.Show("EL REGISTRO QUE BUSCA NO SE ENCUENTRA EN EL SISTEMA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DR.Close()
            End If
        End If
    End Sub

    Private Sub cbisospoolnum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbisospoolnum.SelectedIndexChanged
        CBNUMEROISOMETRICOSPOOL.Text = cbisospoolnum.Text
    End Sub

    Private Sub LLENARLISTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLENARLISTASToolStripMenuItem.Click
        Try

            OBJ_AREA()
            OBJ_ESPECIFICACION_CLASE() 'ESPECIFICACION DE ISOMETRICO
            OBJ_NUM_ISO()
            OBJ_RX()
            ' OBJ_SERVICIO_CLASE() 'DEL ISOMETRICO

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub OBJ_SERVICIO_SPOOL()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT SERVICIO from TBL_ISO WHERE NUM_ISO='" & cbisospoolnum.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBSERVICIO2W.DataSource = DS.Tables(0)
            CBSERVICIO2W.DisplayMember = "SERVICIO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL SERVICIO

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTBSEARCH.Click
        EP.SetError(cbisospoolnum, "")
        Dim VALIDAR As Boolean = False
        If (cbisospoolnum.Text.Trim = "") Then
            EP.SetError(cbisospoolnum, "DEBE ELEGIR UN NUMERO DE ISOMERICO DE LA LISTA")
            VALIDAR = True
        End If

        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                BUSCAISO_REV()
                OBJ_SERVICIO_SPOOL()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If


    End Sub

  

    Private Sub TODOSLOSSPOOLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODOSLOSSPOOLToolStripMenuItem1.Click
        TodosSpool.Show()
    End Sub

    Private Sub PORESTADODESPOOLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORESTADODESPOOLToolStripMenuItem1.Click
        ReporteEstadoSpool.Show()
    End Sub

    Private Sub PORESPECIFICACIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORESPECIFICACIONToolStripMenuItem.Click
        FRMREPORTEESPECF.Show()
    End Sub

    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click
        LIM_SOPORTE()

    End Sub

    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        Dim VAL As Boolean = False
        EP.SetError(SOPORTENUMISO, "")
        If (SOPORTENUMISO.Text.Trim = "") Then
            EP.SetError(SOPORTENUMISO, "DEBE INTRODUCIR EL NUMERO DE ISOMETRICO")
            VAL = True
        End If

        If VAL = True Then
            MessageBox.Show("FALTA IFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            CONECTARBD()


            COMANDO = New SqlCommand("INS_SOP", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                '    .Parameters.Add("@UAN", SqlDbType.Int).Value = SOPORTEUAN.Text
                .Parameters.Add("@ISOMETRIC_NUMBER", SqlDbType.NVarChar, 50).Value = SOPORTENUMISO.Text
                '   .Parameters.Add("@CONSTRUCTION_UNIT", SqlDbType.Int).Value = SOPORTEUNIDAD.Text
                .Parameters.Add("@PIPING_CLASS", SqlDbType.NVarChar, 200).Value = SOPORTECLASE.Text
                .Parameters.Add("@COMPONENT_NUMBER", SqlDbType.NVarChar, 200).Value = SOPORTECOMPONENTE.Text
                .Parameters.Add("@DESIGNATION", SqlDbType.NVarChar, 250).Value = SOPORTEDESIGNACION.Text
                .Parameters.Add("@DN ", SqlDbType.Float, 53).Value = SOPORTEDN.Text
                .Parameters.Add("@DIMENSION_1", SqlDbType.Float, 53).Value = SOPORTEDM1.Text
                .Parameters.Add("@DIMENSION_2", SqlDbType.Float, 53).Value = SOPORTEDM2.Text
                '   .Parameters.Add("@DIMENSION_3", SqlDbType.Float, 53).Value = SOPORTEDM3.Text
                ' .Parameters.Add("@DIMENSION_4", SqlDbType.Float, 53).Value = SOPORTEDM4.Text

                .Parameters.Add("@SUPPORT_CLASS", SqlDbType.NVarChar, 200).Value = SOPORTECLASESOPORT.Text
                .Parameters.Add("@QUANTITY", SqlDbType.Float, 53).Value = SOPORTECANT.Text
                .Parameters.Add("@WEIGHT_NO", SqlDbType.NVarChar, 255).Value = SOPORTEPESO.Text
                .Parameters.Add("@DATE_ARM", SqlDbType.NVarChar, 250).Value = SOPORTEFECHA.Text
                .Parameters.Add("@OBSERVATION", SqlDbType.NVarChar, 255).Value = SOPORTEOBSERVACION.Text
            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("SOPORTE REGISTRADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LIM_SOPORTE()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LIM_SOPORTE()
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub ButtonX10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX10.Click
        Dim VAL As Boolean = False

        EP.SetError(SOPORTEID, "")
        If (SOPORTEID.Text.Trim = "") Then
            EP.SetError(SOPORTEID, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MessageBox.Show("¿DESEA MODIFICAR ESTE REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()


                COMANDO = New SqlCommand("EDIT_SOP", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", SOPORTEID.Text)
                    '.Parameters.Add("@UAN", SqlDbType.Int).Value = SOPORTEUAN.Text
                    .Parameters.Add("@ISOMETRIC_NUMBER", SqlDbType.NVarChar, 50).Value = SOPORTENUMISO.Text
                    ' .Parameters.Add("@CONSTRUCTION_UNIT", SqlDbType.Int).Value = SOPORTEUNIDAD.Text
                    .Parameters.Add("@PIPING_CLASS", SqlDbType.NVarChar, 200).Value = SOPORTECLASE.Text
                    .Parameters.Add("@COMPONENT_NUMBER", SqlDbType.NVarChar, 200).Value = SOPORTECOMPONENTE.Text
                    .Parameters.Add("@DESIGNATION", SqlDbType.NVarChar, 250).Value = SOPORTEDESIGNACION.Text
                    .Parameters.Add("@DN ", SqlDbType.Float, 53).Value = SOPORTEDN.Text
                    .Parameters.Add("@DIMENSION_1", SqlDbType.Float, 53).Value = SOPORTEDM1.Text
                    .Parameters.Add("@DIMENSION_2", SqlDbType.Float, 53).Value = SOPORTEDM2.Text
                    ' .Parameters.Add("@DIMENSION_3", SqlDbType.Float, 53).Value = SOPORTEDM3.Text
                    ' .Parameters.Add("@DIMENSION_4", SqlDbType.Float, 53).Value = SOPORTEDM4.Text
                    '.Parameters.Add("@DN_2", SqlDbType.Float, 53).Value = SOPORTEDN2.Text
                    .Parameters.Add("@SUPPORT_CLASS", SqlDbType.NVarChar, 200).Value = SOPORTECLASESOPORT.Text
                    .Parameters.Add("@QUANTITY", SqlDbType.Float, 53).Value = SOPORTECANT.Text
                    .Parameters.Add("@WEIGHT_NO", SqlDbType.NVarChar, 255).Value = SOPORTEPESO.Text
                    .Parameters.Add("@DATE_ARM", SqlDbType.NVarChar, 250).Value = SOPORTEFECHA.Text
                    .Parameters.Add("@OBSERVATION", SqlDbType.NVarChar, 255).Value = SOPORTEOBSERVACION.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE SOPORTE MODIFICADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIM_SOPORTE()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIM_SOPORTE()
            Finally
                DECONECTARBD()
            End Try
        End If
    End Sub

    Private Sub ButtonX12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX12.Click
        Dim VAL As Boolean = False

        EP.SetError(SOPORTEID, "")
        If (SOPORTEID.Text.Trim = "") Then
            EP.SetError(SOPORTEID, "FALTA EL IDENTIFICADOR")
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
                COMANDO = New SqlCommand("ELIM_SOP", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", SOPORTEID.Text)
                End With

                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE SOPORTE ELIMINADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIM_SOPORTE()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIM_SOPORTE()
            Finally
                DECONECTARBD()
            End Try
        End If

    End Sub

    Private Sub ButtonX11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX11.Click
        REGSOPORTE.Show()
    End Sub

    Private Sub ESTADODESOPORTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ESTADODESOPORTEToolStripMenuItem.Click
        SOPORTERIATODOS.Show()
    End Sub

    Private Sub PORCLASEDELINEAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORCLASEDELINEAToolStripMenuItem.Click
        SOPORTERIACLASE.Show()
    End Sub
    '************************************AUTOCOMPLETADO***********************************

    Private Sub TXTNUMISOS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNUMISOS.TextChanged
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
            TXTNUMISOS.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTNUMISOS.AutoCompleteCustomSource = col
            TXTNUMISOS.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SOPORTECLASESOPORT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOPORTECLASESOPORT.TextChanged
        Try
            Dim cmd As New SqlCommand("Select SUPPORT_CLASS FROM SOPORTERIA", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "SOPORTERIA")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("SUPPORT_CLASS").ToString())
            Next
            SOPORTECLASESOPORT.AutoCompleteSource = AutoCompleteSource.CustomSource
            SOPORTECLASESOPORT.AutoCompleteCustomSource = col
            SOPORTECLASESOPORT.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXNUMEROSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim cmd As New SqlCommand("Select NUMERO_SPOOL FROM TBL_SPOOL", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_SPOOL")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("NUMERO_SPOOL").ToString())
            Next
            TXNUMEROSPOOL.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXNUMEROSPOOL.AutoCompleteCustomSource = col
            TXNUMEROSPOOL.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SOPORTENUMISO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOPORTENUMISO.TextChanged
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
            SOPORTENUMISO.AutoCompleteSource = AutoCompleteSource.CustomSource
            SOPORTENUMISO.AutoCompleteCustomSource = col
            SOPORTENUMISO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    'obtiene la clase una vez que se ha elegido un isometrico
    Private Sub SOPORTECLASE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles SOPORTECLASE.Enter
        Try
            CONECTARBD()
            CONECTARBD2()
            cms = New SqlCommand("sel_espc", CN2)
            cms.CommandType = CommandType.StoredProcedure
            Dim LEC As SqlDataReader


            With cms
                .Parameters.AddWithValue("@ISO", SOPORTENUMISO.Text)
            End With

            LEC = cms.ExecuteReader

            Do While LEC.Read
                SOPORTECLASE.Text = LEC.GetString(0)
                SOPORTEDN.Text = LEC.GetString(1)
                Exit Do
            Loop
            LEC.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            DECONECTARBD()
            DECONECTARBD2()
        End Try
    End Sub
    '********************************************************












    Private Sub TXTIPOSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTIPOSPOOL.TextChanged
        Try
            Dim cmd As New SqlCommand("Select TIPO_SPOOL FROM TBL_SPOOL", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_SPOOL")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("TIPO_SPOOL").ToString())
            Next
            TXTIPOSPOOL.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTIPOSPOOL.AutoCompleteCustomSource = col
            TXTIPOSPOOL.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub PORTIPODESPOOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PORTIPODESPOOLToolStripMenuItem.Click
        FRMTIPOSPOOL.Show()

    End Sub

    Private Sub ButtonX7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click

        EP.SetError(CBSERVICIOISOMETRICO, "")
        EP.SetError(TXTNUMISOS, "")
        EP.SetError(CBESPECIFICACIONISOMETRICO, "")
        EP.SetError(TXTCABEZAL, "")
        Dim validar As Boolean = False


        If (CBSERVICIOISOMETRICO.Text.Trim = "") Then
            EP.SetError(CBSERVICIOISOMETRICO, "DEBES ESPECIFICAR EL SERVICIO")
            validar = True
        End If

        If (TXTNUMISOS.Text.Trim = "") Then
            EP.SetError(TXTNUMISOS, "DEBE ESPECIFICAR EL NUMERO DE ISOMETRICO")
            validar = True
        End If

        If (CBESPECIFICACIONISOMETRICO.Text.Trim = "") Then
            EP.SetError(CBESPECIFICACIONISOMETRICO, "DEBE ASIGNAR LA ESPECIFICACION")
            validar = True
        End If

        If (TXTCABEZAL.Text.Trim = "") Then
            EP.SetError(TXTCABEZAL, "DEBE ESPECIFICAR EL DIAMETRO DEL CABEZAL")
            validar = True
        End If

        If (validar = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                Dim palabra1 As String
                Dim palabra2 As String
                Dim palabra3 As String
                Dim palabra4 As String


                palabra1 = CBSERVICIOISOMETRICO.Text
                palabra2 = TXTNUMISOS.Text
                palabra3 = CBESPECIFICACIONISOMETRICO.Text
                palabra4 = TXTCABEZAL.Text



                Dim texto_com = palabra1 + "-" + palabra2 + "-" + palabra3 + "-" + palabra4

                TXTNOLINEA.Text = texto_com
                ToastNotification.Show(Me, "ASIGNE UNA COLMILLA DOBLE AL FINAL DE ESTE TEXTO", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If



    End Sub
  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OBT()

    End Sub

    Private Sub TXTCATEGORIA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim cmd As New SqlCommand("Select DISTINCT CATEGORIA FROM MATERIAL_ISOMETRICO_OPC", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "MATERIAL_ISOMETRICO_OPC")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CATEGORIA").ToString())
            Next
            ' TXTCATEGORIA.AutoCompleteSource = AutoCompleteSource.CustomSource
            ' TXTCATEGORIA.AutoCompleteCustomSource = col
            ' TXTCATEGORIA.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub

    Private Sub BASICDATA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LlenarGrid()
        ' ToastNotification.Show(Me, "PARA VER LA ESPECIFICACION Y SERVICIO PRESIONE EL MENU LLENAR LISTA", My.Resources.descarga, 6000, eToastPosition.TopRight)
        ' LLENARGRID2()
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        '  Try
        'TXTUNIDAD.Text = Me.DVGMATERIAL.Rows(e.RowIndex).Cells(6).Value
        ' TXTDIAMETRO.Text = Me.DVGMATERIAL.Rows(e.RowIndex).Cells(3).Value
        ' XTXTDIAM2.Text = Me.DVGMATERIAL.Rows(e.RowIndex).Cells(4).Value
        ' TXTDESCRIPCION.Text = Me.DVGMATERIAL.Rows(e.RowIndex).Cells(5).Value
        ' Catch ex As Exception
        'MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub TXSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXSPOOL.TextChanged

        FRMMATERIALES.TXSPOOL.Text = TXSPOOL.Text
    End Sub

    Private Sub CBNUMEROISOMETRICOSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNUMEROISOMETRICOSPOOL.TextChanged
        JuntsIsometric.JUNTANUMISO.Text = CBNUMEROISOMETRICOSPOOL.Text

    End Sub



    Private Sub TXREVSPOOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXREVSPOOL.TextChanged
        JuntsIsometric.JUNTAREVISION.Text = TXREVSPOOL.Text
    End Sub

    Private Sub TXNUMEROSPOOL_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXNUMEROSPOOL.TextChanged
        FRMMATERIALES.TXNUMEROSPOOL.Text = TXNUMEROSPOOL.Text
    End Sub

    Private Sub TXHOJASPOOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXHOJASPOOL.SelectedIndexChanged
        JuntsIsometric.JUNTAHOJA.Text = TXHOJASPOOL.Text

    End Sub

    Private Sub TXTCANTIDADHOJAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCANTIDADHOJAS.SelectedIndexChanged
        FRMMATERIALES.TXTCANTIDADHOJAS.Text = TXTCANTIDADHOJAS.Text
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

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

        'FRMMATERIALES.MATISOMETRICO.Text = JUNTANUMISO.Text
        ' LLENARGRID2()
    End Sub

    Private Sub ButtonX19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX19.Click
        OBJ_SERVICIOjuntas()
        OBT_LINEA()
        BUSCATOTALJUNTAS()
        BUSCA_TOTALPULGADAS()
        OB_ESPC()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        JUNTANUMISO.Text = CBNUMEROISOMETRICOSPOOL.Text
        JUNTAHOJA.Text = TXHOJASPOOL.Text

        JUNTAREVISION.Text = TXREVSPOOL.Text
    End Sub


    Private Sub btnid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnid1.Click
        Try
            OBT_MAT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        OBT2()

    End Sub

    Private Sub ButtonX14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX14.Click
        EP.SetError(JUNTANUMISO, "")
        EP.SetError(JUNTAHOJA, "")
        EP.SetError(JUNTAREVISION, "")
        EP.SetError(cbserviciojunta, "")
        EP.SetError(JUNTAJUNTA, "")
        EP.SetError(JUNTATIPO1, "")
        EP.SetError(JUNTATIPO2, "")
        EP.SetError(JUNTASPOOL, "")
        EP.SetError(JUNTADIAM1, "")
        EP.SetError(JUNTADIAM2, "")
        EP.SetError(JUNTATIPOJUNTA, "")
        EP.SetError(JUNTACAMPOTALLER, "")
        EP.SetError(JUNTAESPECIFICACION, "")
        EP.SetError(JUNTADIAMJUNTA, "")
        EP.SetError(TXTPLGSTD, "")
        EP.SetError(JUNTAID1, "")
        EP.SetError(JUNTACOLADA1, "")
        EP.SetError(JUNTACOLADA2, "")
        EP.SetError(JUNTADESC1, "")
        EP.SetError(JUNTADESC2, "")
        Dim VALIDAR As Boolean = False

        If (JUNTANUMISO.Text.Trim = "") Then
            EP.SetError(JUNTANUMISO, "DEBE ESPECIFICAR EL NUMERO DE ISOMETRICO")
            VALIDAR = True
        End If

        If (JUNTAHOJA.Text.Trim = "") Then
            EP.SetError(JUNTAHOJA, "DEBE ESPECIFICAR EL NUMERO DE HOJA")
            VALIDAR = True
        End If

        If (JUNTAREVISION.Text.Trim = "") Then
            EP.SetError(JUNTAREVISION, "DEBE ESPECIFICAR EL NUMERO DE REVISION")
            VALIDAR = True
        End If

        If (cbserviciojunta.Text.Trim = "") Then
            EP.SetError(cbserviciojunta, "DEBE ESPECIFICAR EL SERVICIO")
            VALIDAR = True
        End If

        If (JUNTAJUNTA.Text.Trim = "") Then
            EP.SetError(JUNTAJUNTA, "DEBE ESPECIFICAR EL NUMERO DE JUNTA")
            VALIDAR = True
        End If

        If (JUNTATIPO1.Text.Trim = "") Then
            EP.SetError(JUNTATIPO1, "DEBE ESPECIFICAR EL TIPO 1 DE JUNTA")
            VALIDAR = True
        End If

        If (JUNTATIPO2.Text.Trim = "") Then
            EP.SetError(JUNTATIPO2, "DEBE ESPECIFICAR EL TIPO 2 DE JUNTA")
            VALIDAR = True
        End If

        If (JUNTASPOOL.Text.Trim = "") Then
            EP.SetError(JUNTASPOOL, "DEBE ESPECIFICAR EL NUMERO DE SPOOL")
            VALIDAR = True
        End If

        If (JUNTADIAM1.Text.Trim = "") Then
            EP.SetError(JUNTADIAM1, "DEBE ESPECIFICAR EL DIAMETRO UNO DE LA JUNTA")
            VALIDAR = True
        End If

        If (JUNTADIAM2.Text.Trim = "") Then
            EP.SetError(JUNTADIAM2, "DEBE ESPECIFICAR EL DIAMETRO DOS DE LA JUNTA")
            VALIDAR = True
        End If

        If (JUNTATIPOJUNTA.Text.Trim = "") Then
            EP.SetError(JUNTATIPOJUNTA, "DEBE ESPECIFICAR EL TIPO DE JUNTA")
            VALIDAR = True
        End If

        If (JUNTACAMPOTALLER.Text.Trim = "") Then
            EP.SetError(JUNTACAMPOTALLER, "DEBE ESPECIFICAR SI LA JUNTA ES DE TALLER O CAMPO")
            VALIDAR = True
        End If

        If (JUNTAESPECIFICACION.Text.Trim = "") Then
            EP.SetError(JUNTAESPECIFICACION, "DEBE INTRODUCIR LA ESPECIFICACION DE LA JUNTA")
            VALIDAR = True
        End If

        If (JUNTADIAMJUNTA.Text.Trim = "") Then
            EP.SetError(JUNTADIAMJUNTA, "DEBE ESPECIFICAR EL DIAMETRO DE LA JUNTA")
            VALIDAR = True
        End If

        If (TXTPLGSTD.Text.Trim = "") Then
            EP.SetError(TXTPLGSTD, "DEBE ESPECIFICAR LA PULGADA ESTANDARD DE LA JUNTA")
            VALIDAR = True
        End If
        If (JUNTAID1.Text.Trim = "") Then
            EP.SetError(JUNTAID1, "DEBE ESPECIFICAR EL CODIGO DEL PRIMER MATERIAL")
            VALIDAR = True
        End If
        If (JUNTAID2.Text.Trim = "") Then
            EP.SetError(JUNTAID2, "DEBE ESPECIFICAR EL CODIGO DELSEGUNDO MATERIAL")
            VALIDAR = True
        End If
        If (JUNTACOLADA1.Text.Trim = "") Then
            EP.SetError(JUNTACOLADA1, "DEBE ESPECIFICAR LA COLADA DE PRIMER MATERIAL")
            VALIDAR = True
        End If
        If (JUNTACOLADA2.Text.Trim = "") Then
            EP.SetError(JUNTACOLADA2, "DEBE ESPECIFICAR LA COLADA DE SEGUNDO MATERIAL")
            VALIDAR = True
        End If
        If (JUNTADESC1.Text.Trim = "") Then
            EP.SetError(JUNTADESC1, "DEBE ESPECIFICAR LA DESCRIPCION DEL PRIMER MATERIAL")
            VALIDAR = True
        End If
        If (JUNTADESC2.Text.Trim = "") Then
            EP.SetError(JUNTADESC2, "DEBE ESPECIFICAR LA DESCRIPCION DEL SEGUNDO MATERIAL")
            VALIDAR = True
        End If


        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ToastNotification.Show(Me, "PARA VER LA AYUDA PASE EL CURSOR SOBRE LOS CAMPOS DE TEXTO", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Exit Sub
        Else

            Try
                '  VALIDAR_JUNTA()
                CONECTARBD()
                COMANDO = New SqlCommand("INS_JUNTAS", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.Add("@TOTAL_JTA", SqlDbType.Int).Value = TOTALJUNTAS.Text
                    .Parameters.Add("@T_PLG", SqlDbType.Float, 53).Value = PULGADASJUNTAS.Text
                    .Parameters.Add("@NUM_ISO", SqlDbType.NVarChar, 50).Value = JUNTANUMISO.Text
                    .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = JUNTAHOJA.Text
                    .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = JUNTAREVISION.Text
                    .Parameters.Add("@JUNTA", SqlDbType.Int).Value = JUNTAJUNTA.Text
                    .Parameters.Add("@TIPO1", SqlDbType.NVarChar, 50).Value = JUNTATIPO1.Text
                    .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 50).Value = JUNTATIPO2.Text
                    .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = JUNTASPOOL.Text
                    .Parameters.Add("@DIAM1", SqlDbType.NVarChar, 50).Value = JUNTADIAM1.Text
                    .Parameters.Add("@DIAM2", SqlDbType.NVarChar, 50).Value = JUNTADIAM2.Text
                    .Parameters.Add("@TIPO_JTA", SqlDbType.NVarChar, 50).Value = JUNTATIPOJUNTA.Text
                    .Parameters.Add("@CAMP_TLLER", SqlDbType.NVarChar, 50).Value = JUNTACAMPOTALLER.Text
                    .Parameters.Add("@ESPEC", SqlDbType.NVarChar, 250).Value = JUNTAESPECIFICACION.Text
                    .Parameters.Add("@DIAM_JTA", SqlDbType.Float, 53).Value = JUNTADIAMJUNTA.Text
                    .Parameters.Add("@ID1", SqlDbType.NVarChar, 250).Value = JUNTAID1.Text
                    .Parameters.Add("@ID2", SqlDbType.NVarChar, 250).Value = JUNTAID2.Text
                    .Parameters.Add("@COLADA1", SqlDbType.NVarChar, 250).Value = JUNTACOLADA1.Text
                    .Parameters.Add("@COLADA2", SqlDbType.NVarChar, 250).Value = JUNTACOLADA2.Text
                    .Parameters.Add("@DESCRIP1", SqlDbType.NVarChar, 250).Value = JUNTADESC1.Text
                    .Parameters.Add("@DESCRIP2", SqlDbType.NVarChar, 250).Value = JUNTADESC2.Text
                    .Parameters.Add("@PLG_STD", SqlDbType.Float, 53).Value = TXTPLGSTD.Text
                    .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 255).Value = cbserviciojunta.Text
                    .Parameters.Add("@LINEA", SqlDbType.NVarChar, 50).Value = CBLINEA.Text
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

                '  Try
                'If (INDICADOR = 1) Then
                'MessageBox.Show("NO SE PUEDE GUARDAR ESTA JUNTA CUENTA CON LOS MISMOS DATOS DE UN REGISTRO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)

                '  If (MessageBox.Show("¿DESEA REGISTRAR DE TODAS FORMAS?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                'Exit Sub
                '   DECONECTARBD()

                '    Else
                COMANDO.ExecuteNonQuery()
                '   MessageBox.Show("JUNTA DE ISOMETRICO ASIGNADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '   CLEAN()
                ExpandablePanel1.Expanded = True
                LlenarGrid()

                '  End If
                'DECONECTARBD()
                ' Else
                ' COMANDO.ExecuteNonQuery()
                ' MessageBox.Show("JUNTA DE ISOMETRICO ASIGNADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' End If


                '  Catch ex As Exception
                '     MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                '  End Try


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'CLEAN()
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub ButtonX15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX15.Click
        CLEAN()
    End Sub

    Private Sub ButtonX16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX16.Click
        Dim VAL As Boolean = False

        EP.SetError(IDJUNTA, "")
        If (IDJUNTA.Text.Trim = "") Then
            EP.SetError(IDJUNTA, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else

            If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_JUNTAS", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure
                    With COMANDO
                        .Parameters.AddWithValue("@ID", IDJUNTA.Text)
                        .Parameters.Add("@TOTAL_JTA", SqlDbType.Int).Value = TOTALJUNTAS.Text
                        .Parameters.Add("@T_PLG", SqlDbType.Float, 53).Value = PULGADASJUNTAS.Text
                        .Parameters.Add("@NUM_ISO", SqlDbType.NVarChar, 50).Value = JUNTANUMISO.Text
                        .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = JUNTAHOJA.Text
                        .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = JUNTAREVISION.Text
                        .Parameters.Add("@JUNTA", SqlDbType.Int).Value = JUNTAJUNTA.Text
                        .Parameters.Add("@TIPO1", SqlDbType.NVarChar, 50).Value = JUNTATIPO1.Text
                        .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 50).Value = JUNTATIPO2.Text
                        .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 250).Value = JUNTASPOOL.Text
                        .Parameters.Add("@DIAM1", SqlDbType.NVarChar, 50).Value = JUNTADIAM1.Text
                        .Parameters.Add("@DIAM2", SqlDbType.NVarChar, 50).Value = JUNTADIAM2.Text
                        .Parameters.Add("@TIPO_JTA", SqlDbType.NVarChar, 50).Value = JUNTATIPOJUNTA.Text
                        .Parameters.Add("@CAMP_TLLER", SqlDbType.NVarChar, 50).Value = JUNTACAMPOTALLER.Text
                        .Parameters.Add("@ESPEC", SqlDbType.NVarChar, 250).Value = JUNTAESPECIFICACION.Text
                        .Parameters.Add("@DIAM_JTA", SqlDbType.Float, 53).Value = JUNTADIAMJUNTA.Text
                        .Parameters.Add("@ID1", SqlDbType.NVarChar, 250).Value = JUNTAID1.Text
                        .Parameters.Add("@ID2", SqlDbType.NVarChar, 250).Value = JUNTAID2.Text
                        .Parameters.Add("@COLADA1", SqlDbType.NVarChar, 250).Value = JUNTACOLADA1.Text
                        .Parameters.Add("@COLADA2", SqlDbType.NVarChar, 250).Value = JUNTACOLADA2.Text
                        .Parameters.Add("@DESCRIP1", SqlDbType.NVarChar, 250).Value = JUNTADESC1.Text
                        .Parameters.Add("@DESCRIP2", SqlDbType.NVarChar, 250).Value = JUNTADESC2.Text
                        .Parameters.Add("@PLG_STD", SqlDbType.Float, 53).Value = TXTPLGSTD.Text
                        .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 255).Value = cbserviciojunta.Text
                        .Parameters.Add("@LINEA", SqlDbType.NVarChar, 50).Value = CBLINEA.Text
                    End With

                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("JUNTA DE ISOMETRICO MODIFICADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '  CLEAN()


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CLEAN()
                Finally
                    DECONECTARBD()

                End Try
            End If

        End If

    End Sub

    Private Sub ButtonX18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX18.Click
        Dim VAL As Boolean = False

        EP.SetError(IDJUNTA, "")
        If (IDJUNTA.Text.Trim = "") Then
            EP.SetError(IDJUNTA, "FALTA EL IDENTIFICADOR")
            VAL = True
        End If
        If VAL = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else

            If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_JUNTAS", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", IDJUNTA.Text)
                    End With
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    COMANDO.ExecuteNonQuery()
                    CLEAN()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CLEAN()
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If
    End Sub

    Private Sub ButtonX17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX17.Click
        FrmRegJuntas.Show()
    End Sub

    Private Sub ButtonX13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX13.Click
        LlenarGrid()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            IDJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TOTALJUNTAS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            PULGADASJUNTAS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            JUNTANUMISO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
            JUNTAHOJA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            JUNTAREVISION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            JUNTAJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            JUNTATIPO1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
            JUNTATIPO2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            JUNTASPOOL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            JUNTADIAM1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
            JUNTADIAM2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(11).Value
            JUNTATIPOJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(12).Value
            JUNTACAMPOTALLER.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(13).Value
            JUNTAESPECIFICACION.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(14).Value
            cbserviciojunta.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(15).Value
            JUNTADIAMJUNTA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(16).Value
            JUNTAID1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value
            JUNTAID2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value
            JUNTADESC1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(19).Value
            JUNTADESC2.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(20).Value
            TXTPLGSTD.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(21).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        EP.SetError(JUNTANUMISO, "")
        EP.SetError(JUNTAHOJA, "")
        EP.SetError(JUNTASPOOL, "")
        Dim validar As Boolean = False

        If (JUNTANUMISO.Text.Trim = "") Then
            EP.SetError(JUNTANUMISO, "DEBE ESPECIFICAR EL NUMERO DE ISOMETRICO")
            validar = True
        End If

        If (JUNTAHOJA.Text.Trim = "") Then
            EP.SetError(JUNTAHOJA, "DEBE ESPECIFICAR EL NUMERO DE HOJA")
            validar = True
        End If

        If (JUNTASPOOL.Text.Trim = "") Then
            EP.SetError(JUNTASPOOL, "DEBE ESPECIFICAR EL NUMERO DE JUNTA")
            validar = True
        End If

        If (validar = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                LLENARGRID2()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub MATISOMETRICO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATISOMETRICO.TextChanged
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
            MATISOMETRICO.AutoCompleteSource = AutoCompleteSource.CustomSource
            MATISOMETRICO.AutoCompleteCustomSource = col
            MATISOMETRICO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MATISOMETRICO.Text = JUNTANUMISO.Text
        TXTHOJAMATERIAL.Text = TXHOJASPOOL.Text
        TXTNUMSPOOLMATERIAL.Text = TXNUMEROSPOOL.Text
        TXTSPOOLUNIDOMATERIAL.Text = TXSPOOL.Text
        TXTREVSPOOLMATERIAL.Text = TXREVSPOOL.Text
        TXTHOJATOTALMATERIAL.Text = TXTCANTIDADHOJAS.Text

        OBT_ESTADO()
    End Sub

  

    Private Sub BTNSEARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSEARCH.Click
        OBTENER_CODIGO_CLIENTE()
        obt_fabricanteSSSDDDFGHJK()
        OBT_material() 'OBTIENE LA DESC DE LA TABLA MAT_ISO
        obt_colada()

        ToastNotification.Show(Me, "VERIFIQUE EN LA LISTA DE REGISTROS DE ALMACEN", My.Resources.descarga, 6000, eToastPosition.TopRight)
    End Sub

    Private Sub MATCOLADA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATCOLADA.TextChanged
        Try
            Dim cmd As New SqlCommand("Select DISTINCT COLADA FROM ALMACEN", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ALMACEN")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("COLADA").ToString())
            Next
            MATCOLADA.AutoCompleteSource = AutoCompleteSource.CustomSource
            MATCOLADA.AutoCompleteCustomSource = col
            MATCOLADA.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        obt_fabricanteSSSDDDFGHJK()
    End Sub

    Private Sub ButtonX20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX20.Click
        EP.SetError(MATISOMETRICO, "")
        EP.SetError(TXTHOJAMATERIAL, "")
        EP.SetError(TXTHOJATOTALMATERIAL, "")
        EP.SetError(TXTNUMSPOOLMATERIAL, "")
        EP.SetError(TXTREVSPOOLMATERIAL, "")
        EP.SetError(TXTSPOOLUNIDOMATERIAL, "")
        EP.SetError(MATCODIGOtcm, "")
        EP.SetError(MATIDENTIFICADOR, "")
        EP.SetError(MATPESO, "")
        EP.SetError(MATCOLADA, "")
        EP.SetError(MATFABRICANTESSSSS, "")
        EP.SetError(TXTCATEGORIAMAT, "")
        EP.SetError(TXTCANTIDADMAT, "")
        EP.SetError(TXTUNIDADMAT, "")
        EP.SetError(TXTDIAMETROMAT, "")
        EP.SetError(XTXTDIAM2, "")
        EP.SetError(TXTDESCRIPCIONMAT, "")
        EP.SetError(MATERIALCODIGOCLIENTE, "")
        Dim VALIDAR As Boolean = False

        If (MATISOMETRICO.Text.Trim = "") Then
            EP.SetError(MATISOMETRICO, "DEBE ESPECIFICAR EL NUMERO DEL ISOMETRICO")
            VALIDAR = True
        End If
        If (TXTHOJAMATERIAL.Text.Trim = "") Then
            EP.SetError(TXTHOJAMATERIAL, "DEBE ESPECIFICAR EL NUMERO DE HOJA")
            VALIDAR = True
        End If
        If (TXTHOJATOTALMATERIAL.Text.Trim = "") Then
            EP.SetError(TXTHOJATOTALMATERIAL, "DEBE ESPECIFICAR EL NUMERO DE HOJA TOTAL")
            VALIDAR = True
        End If
        If (TXTNUMSPOOLMATERIAL.Text.Trim = "") Then
            EP.SetError(TXTNUMSPOOLMATERIAL, "DEBE ESPECIFICAR EL NUMERO DE SPOOL")
            VALIDAR = True
        End If
        If (TXTREVSPOOLMATERIAL.Text.Trim = "") Then
            EP.SetError(TXTREVSPOOLMATERIAL, "DEBE ESPECIFICAR EL NUMERO DE REVISION")
            VALIDAR = True
        End If
        If (TXTSPOOLUNIDOMATERIAL.Text.Trim = "") Then
            EP.SetError(TXTSPOOLUNIDOMATERIAL, "DEBE ESPECIFICAR EL NUMERO DE SPOOL UNIDO")
            VALIDAR = True
        End If
        If (MATCODIGOtcm.Text.Trim = "") Then
            EP.SetError(MATCODIGOtcm, "DEBE ESPECIFICAR EL CODIGO TCM DEL MATERIAL")
            VALIDAR = True
        End If
        If (MATIDENTIFICADOR.Text.Trim = "") Then
            EP.SetError(MATIDENTIFICADOR, "DEBE ESPECIFICAR IDENTIFICADOR DEL CODIGO DE MATERIAL")
            VALIDAR = True
        End If
        If (MATPESO.Text.Trim = "") Then
            EP.SetError(MATPESO, "DEBE ESPECIFICAR EL PESO DEL MATERIAL")
            VALIDAR = True
        End If
        If (MATCOLADA.Text.Trim = "") Then
            EP.SetError(MATCOLADA, "DEBE ESPECIFICAR LA COLADA CORRESPONDIENTE AL CODIGO DEL MATERIAL")
            VALIDAR = True
        End If
        If (MATFABRICANTESSSSS.Text.Trim = "") Then
            EP.SetError(MATFABRICANTESSSSS, "DEBE ESPECIFICAR EL NOMBRE DEL FABRICANTE DEL MATERIAL")
            VALIDAR = True
        End If
        If (TXTCATEGORIAMAT.Text.Trim = "") Then
            EP.SetError(TXTCATEGORIAMAT, "DEBE ESPECIFICAR LA CATEGORIA DEL MATERIAL")
            VALIDAR = True
        End If
        If (TXTCANTIDADMAT.Text.Trim = "") Then
            EP.SetError(TXTCANTIDADMAT, "DEBE ESPECIFICAR LA CANTIDAD DE MATERIAL")
            VALIDAR = True
        End If
        If (TXTUNIDADMAT.Text.Trim = "") Then
            EP.SetError(TXTUNIDADMAT, "DEBE ESPECIFICAR EL NUMERO DEL ISOMETRICO")
            VALIDAR = True
        End If
        If (TXTDIAMETROMAT.Text.Trim = "") Then
            EP.SetError(TXTDIAMETROMAT, "DEBE ESPECIFICAR EL DIAMETRO 1 DEL MATERIAL")
            VALIDAR = True
        End If
        If (XTXTDIAM2.Text.Trim = "") Then
            EP.SetError(XTXTDIAM2, "DEBE ESPECIFICAR EL DIAMETRO 2 DEL MATERIAL")
            VALIDAR = True
        End If
        If (TXTDESCRIPCIONMAT.Text.Trim = "") Then
            EP.SetError(TXTDESCRIPCIONMAT, "DEBE ESPECIFICAR LA DESCRIPCION DEL MATERIAL")
            VALIDAR = True
        End If
        If (MATERIALCODIGOCLIENTE.Text.Trim = "") Then
            EP.SetError(MATERIALCODIGOCLIENTE, "DEBE ESPECIFICAR EL CODIGO DE CLIENTE DEL MATERIAL")
            VALIDAR = True
        End If

        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ToastNotification.Show(Me, "PARA VER LA AYUDA PASE EL CURSOR SOBRE LOS CAMPOS DE TEXTO", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_MAT_ISO", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.Add("@ISOMETRICO", SqlDbType.NVarChar, 50).Value = MATISOMETRICO.Text
                    .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = TXTHOJAMATERIAL.Text
                    .Parameters.Add("@CANT_HOJA", SqlDbType.NVarChar, 50).Value = TXTHOJATOTALMATERIAL.Text
                    .Parameters.Add("@NUM_SPOOL", SqlDbType.NVarChar, 50).Value = TXTNUMSPOOLMATERIAL.Text
                    .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = TXTREVSPOOLMATERIAL.Text
                    .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 50).Value = TXTSPOOLUNIDOMATERIAL.Text
                    .Parameters.Add("@CODIGO_MAT", SqlDbType.NVarChar, 50).Value = MATCODIGOtcm.Text
                    .Parameters.Add("@IDENTIFICADOR", SqlDbType.NVarChar, 50).Value = MATIDENTIFICADOR.Text
                    .Parameters.Add("@PESO", SqlDbType.NVarChar, 50).Value = MATPESO.Text
                    .Parameters.Add("@COLADA", SqlDbType.NVarChar, 50).Value = MATCOLADA.Text
                    .Parameters.Add("@FABRICANTE", SqlDbType.NVarChar, 50).Value = MATFABRICANTESSSSS.Text
                    .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 50).Value = TXTDESCRIPCIONMAT.Text
                    .Parameters.Add("@CATEGORIA", SqlDbType.NVarChar, 50).Value = TXTCATEGORIAMAT.Text
                    .Parameters.Add("@CANTIDAD", SqlDbType.NVarChar, 100).Value = TXTCANTIDADMAT.Text
                    .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 50).Value = TXTUNIDADMAT.Text
                    .Parameters.Add("@DIAMETRO", SqlDbType.NVarChar, 50).Value = TXTDIAMETROMAT.Text
                    .Parameters.Add("@DIAM_2", SqlDbType.NVarChar, 50).Value = XTXTDIAM2.Text
                    .Parameters.Add("@COD_CLIENTE", SqlDbType.NVarChar, 250).Value = MATERIALCODIGOCLIENTE.Text
                    .Parameters.Add("@ESTADO_SPOOL", SqlDbType.NVarChar, 100).Value = CBESTADOMATERIAL.Text
                End With
                MessageBox.Show("MATERIAL REGISTRADO EXITOSAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                COMANDO.ExecuteNonQuery()
                ' CLEAN()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '   CLEAN()
            Finally
                DECONECTARBD()

            End Try

        End If





    End Sub

    Private Sub ButtonX22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX22.Click
        Me.EP.SetError(MATID, "")
        Dim VALID As Boolean = False
        If (MATID.Text.Trim = "") Then
            EP.SetError(MATID, "FALTA EL INDICADOR")
            VALID = True
        End If
        If (VALID = True) Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MOFIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_MAT_ISO", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", MATID.Text)
                        .Parameters.Add("@ISOMETRICO", SqlDbType.NVarChar, 50).Value = MATISOMETRICO.Text
                        .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = TXHOJASPOOL.Text
                        .Parameters.Add("@CANT_HOJA", SqlDbType.NVarChar, 50).Value = TXTCANTIDADHOJAS.Text
                        .Parameters.Add("@NUM_SPOOL", SqlDbType.NVarChar, 50).Value = TXNUMEROSPOOL.Text
                        .Parameters.Add("@REV", SqlDbType.NVarChar, 50).Value = TXREVSPOOL.Text
                        .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 50).Value = TXSPOOL.Text
                        .Parameters.Add("@CODIGO_MAT", SqlDbType.NVarChar, 50).Value = MATCODIGOtcm.Text
                        .Parameters.Add("@IDENTIFICADOR", SqlDbType.NVarChar, 50).Value = MATIDENTIFICADOR.Text
                        .Parameters.Add("@PESO", SqlDbType.NVarChar, 50).Value = MATPESO.Text
                        .Parameters.Add("@COLADA", SqlDbType.NVarChar, 50).Value = MATCOLADA.Text
                        .Parameters.Add("@FABRICANTE", SqlDbType.NVarChar, 50).Value = MATFABRICANTESSSSS.Text
                        .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 50).Value = TXTDESCRIPCIONMAT.Text
                        .Parameters.Add("@CATEGORIA", SqlDbType.NVarChar, 50).Value = TXTCATEGORIAMAT.Text
                        '  .Parameters.Add("@COD_TCM", SqlDbType.NVarChar, 50).Value = TXTCODIGO.Text
                        .Parameters.Add("@CANTIDAD", SqlDbType.NVarChar, 50).Value = TXTCANTIDADMAT.Text
                        .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 50).Value = TXTUNIDADMAT.Text
                        .Parameters.Add("@DIAMETRO", SqlDbType.NVarChar, 50).Value = TXTDIAMETROMAT.Text
                        .Parameters.Add("@DIAM_2", SqlDbType.NVarChar, 50).Value = XTXTDIAM2.Text
                        .Parameters.Add("@COD_CLIENTE", SqlDbType.NVarChar, 250).Value = MATERIALCODIGOCLIENTE.Text
                        .Parameters.Add("@ESTADO_SPOOL", SqlDbType.NVarChar, 100).Value = CBESTADOMATERIAL.Text
                    End With
                    MessageBox.Show("REGISTRO MODIFICADO EXITOSAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    COMANDO.ExecuteNonQuery()
                    CLEAN()


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CLEAN()
                Finally
                    DECONECTARBD()

                End Try

            End If
        End If

    End Sub

    Private Sub ButtonX24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX24.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("ELIM_MAT_ISO", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.AddWithValue("@ID", MATID.Text)

            End With
            MessageBox.Show("REGISTRO ELIMINADO EXITOSAMENTE!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            COMANDO.ExecuteNonQuery()
            CLEAN()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CLEAN()
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ButtonX23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX23.Click
        FRMREGMATS.Show()
    End Sub

    Private Sub ButtonX25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX25.Click
        LIBRERIA.Show()
    End Sub

    Private Sub REGISTROSDEALMACENToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTROSDEALMACENToolStripMenuItem.Click
        REGISTROALMACEN.Show()
    End Sub

    Private Sub ButtonX26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX26.Click
        HOJAISO.Show()
    End Sub

    Private Sub LIBRERIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBRERIAToolStripMenuItem.Click
        LIBRERIA.Show()
    End Sub

    Private Sub PRODUCCIONDIARIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCCIONDIARIAToolStripMenuItem.Click
        PRODUCIONDIARIA.Show()
    End Sub

    Private Sub ButtonX21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX21.Click
        CLEAN_mat()
    End Sub

    Private Sub GroupBox12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox12.Enter

    End Sub

    Private Sub ButtonX27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX27.Click
        OBT_RX_CLASE()
    End Sub

    Private Sub JUNTAID1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JUNTAID1.TextChanged
        Try
            Dim cmd As New SqlCommand("Select CODIGO_CLIENTE FROM MAT_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "MAT_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CODIGO_CLIENTE").ToString())
            Next
            JUNTAID1.AutoCompleteSource = AutoCompleteSource.CustomSource
            JUNTAID1.AutoCompleteCustomSource = col
            JUNTAID1.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub JUNTAID2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JUNTAID2.TextChanged
        Try
            Dim cmd As New SqlCommand("Select CODIGO_CLIENTE FROM MAT_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "MAT_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CODIGO_CLIENTE").ToString())
            Next
            JUNTAID2.AutoCompleteSource = AutoCompleteSource.CustomSource
            JUNTAID2.AutoCompleteCustomSource = col
            JUNTAID2.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub


 

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            obt_fabricanteSSSDDDFGHJK()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub MATCODIGOtcm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATCODIGOtcm.TextChanged
        Try
            Dim cmd As New SqlCommand("Select DISTINCT CODE_TCM FROM LIBRERIA", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "LIBRERIA")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("CODE_TCM").ToString())
            Next
            MATCODIGOtcm.AutoCompleteSource = AutoCompleteSource.CustomSource
            MATCODIGOtcm.AutoCompleteCustomSource = col
            MATCODIGOtcm.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

  
    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Try
            JUNTAID1.Text = Me.DataGridView2.Rows(e.RowIndex).Cells(2).Value


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SwitchButton1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles SwitchButton1.ValueChanged
        If (SwitchButton1.Value = True) Then

            PSAND.Enabled = False
            PENLACE.Enabled = False
            PACABADO.Enabled = False
            PLIBERACION.Enabled = False
            PCOMPAÑIA.Enabled = False
            PAREA.Enabled = False
            POBSERVACION.Enabled = False
            PNUMEROREP.Enabled = False
            PNOORDEN.Enabled = False
            PFECHAORDEN.Enabled = False
            PCANTIDAD.Enabled = False
            PNOEMBARQUE.Enabled = False
            PFECHAEMBARQUE.Enabled = False
            TXTFECHAPACKING.Enabled = False
            ' CBNUMEROISOMETRICOSPOOL.Enabled = True

            ' TXESTADOSPOOL.Enabled = True
            ' TXDIAMETROSPOOL.Enabled = True
            'TXESPECIFICACIONSPOOL.Enabled = True
            'TXHOJASPOOL.Enabled = True
            'TXTIPOSPOOL.Enabled = True
            'TXOBSERVACIONSPOOL.Enabled = True
            'TXPESOSPOOL.Enabled = True
            'TXPULGADASPOOL.Enabled = True
            'TXTCANTIDADHOJAS.Enabled = True
            'TXTXPND.Enabled = True
            'TXREVSPOOL.Enabled = True
            'TXSISTEMASPOOL.Enabled = True
            'TXSPOOL.Enabled = True
            'DTFECHAARMADOSPOOL.Enabled = True
            'DTFECHACORTESPOOL.Enabled = True
            'DTFECHASOLDSPOOL.Enabled = True
            'TXNUMEROSPOOL.Enabled = True
            'TXJUNTASSPOOL.Enabled = True
            'TXCONSECUTIVOINTERNO.Enabled = True
            'CBSERVICIO2W.Enabled = True
            '********************************

         
        Else
            FRMINICIPRINCIPAL.Show()
            'CBNUMEROISOMETRICOSPOOL.Enabled = False

            'TXESTADOSPOOL.Enabled = False
            'TXDIAMETROSPOOL.Enabled = False
            'TXESPECIFICACIONSPOOL.Enabled = False
            'TXHOJASPOOL.Enabled = False
            'TXTIPOSPOOL.Enabled = False
            'TXOBSERVACIONSPOOL.Enabled = False
            'TXPESOSPOOL.Enabled = False
            'TXPULGADASPOOL.Enabled = False
            'TXTCANTIDADHOJAS.Enabled = False
            'TXTXPND.Enabled = False
            'TXREVSPOOL.Enabled = False
            'TXSISTEMASPOOL.Enabled = False
            'TXSPOOL.Enabled = False
            'DTFECHAARMADOSPOOL.Enabled = False
            'DTFECHACORTESPOOL.Enabled = False
            'DTFECHASOLDSPOOL.Enabled = False
            'TXNUMEROSPOOL.Enabled = False
            'TXJUNTASSPOOL.Enabled = False
            'TXCONSECUTIVOINTERNO.Enabled = False
            'CBSERVICIO2W.Enabled = False
            '********************************
            '  PENLACE.Enabled = True
            ' PACABADO.Enabled = True
            ' PLIBERACION.Enabled = True
            ' PCOMPAÑIA.Enabled = True
            ' PAREA.Enabled = True
            ' POBSERVACION.Enabled = True
            ' PNUMEROREP.Enabled = True
            ' PNOORDEN.Enabled = True
            ' PFECHAORDEN.Enabled = True
            ' PCANTIDAD.Enabled = True
            ' PNOEMBARQUE.Enabled = True
            'PFECHAEMBARQUE.Enabled = True
        End If
    End Sub

    Private Sub TXTAREA_SPO_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTAREA_SPO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select AREA FROM TBL_ISO WHERE NUM_ISO='" & CBNUMEROISOMETRICOSPOOL.Text & "'", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("AREA").ToString())
            Next
            TXTAREA_SPO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTAREA_SPO.AutoCompleteCustomSource = col
            TXTAREA_SPO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub LIEBRACIONDESPOOLPINTURAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LIEBRACIONDESPOOLPINTURAToolStripMenuItem.Click
        FRMLIBSPOOLREPORT.Show()
    End Sub

    Private Sub STATUSDEISOMETRICOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles STATUSDEISOMETRICOToolStripMenuItem.Click
        FrmEstado_Iso.Show()
    End Sub

    Private Sub INFORMEESTADODESPOOLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INFORMEESTADODESPOOLToolStripMenuItem.Click
        FRMEDO_SPOOL_MTS.Show()
    End Sub

    Private Sub INFORMEESTADODESPOOLMTS2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INFORMEESTADODESPOOLMTS2ToolStripMenuItem.Click
        frmreporteEstado_spool.Show()
    End Sub

    Private Sub ButtonX28_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX28.Click
        HISTORIAL_JUNTA.Show()

    End Sub

    Private Sub GroupBox4_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub PACKINGLISTToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PACKINGLISTToolStripMenuItem.Click
        'PINTURA_PACKINGLIST.Show()
        '   PACKINGCONDICION.Show()
        CYPLUS_VALE.Show()

    End Sub

    Private Sub TXTMATERIALIBERACION_TextChanged(sender As Object, e As System.EventArgs) Handles TXTMATERIALIBERACION.TextChanged
        If (TXTMATERIALIBERACION.Text.Length < 2) Then
            MessageBox.Show("DEBE ELEGIR UN MATERIAL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class