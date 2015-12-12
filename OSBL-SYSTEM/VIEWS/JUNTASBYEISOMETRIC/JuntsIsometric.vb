Imports System.Data
Imports System.Data.SqlClient

Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class JuntsIsometric

    Dim INDICADOR As Integer
#Region "METODOS"
    Sub OBJ_SERVICIO()
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

            cbservicio.DataSource = DS.Tables(0)
            cbservicio.DisplayMember = "Servicio"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL SERVICIO
    Sub LlenarGrid()

        Try
            CONECTARBD()
            CADENA = "Select*from JUNTAS"
            ADP = New SqlDataAdapter(CADENA, CN)
            Dim dt As New DataTable
            ADP.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub LLENARGRID2()
        Try
            CONECTARBD()
            CADENA = "Select IDENTIFICADOR,CODIGO_MAT,DESCRIPCION,CANTIDAD from MAT_ISO WHERE ISOMETRICO='" & JUNTANUMISO.Text & "' AND HOJA='" & JUNTAHOJA.Text & "' AND NUM_SPOOL='" & JUNTASPOOL.Text & "'"
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

        cbservicio.ResetText()
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
    Sub OBT()
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("OBT_IDMAT", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@IDENTI", SqlDbType.Int).Value = JUNTAID1.Text
                .Parameters.Add("@ISO", SqlDbType.NVarChar, 50).Value = JUNTANUMISO.Text
                .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = JUNTAHOJA.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = JUNTASPOOL.Text
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                JUNTADESC1.Text = DR.GetString(0)

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
                .Parameters.AddWithValue("@ISO", JUNTANUMISO.Text)
                .Parameters.AddWithValue("@HOJA", JUNTAHOJA.Text)
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 255).Value = JUNTASPOOL.Text
            End With
            DR = COMANDO.ExecuteReader()
            Do While DR.Read
                INDICADOR = 1
                JUNTADESC2.Text = DR.GetString(0)

                Exit Do
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
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
    
    Private Sub TODASLASJUNTASPORISOMETRICOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TODASLASJUNTASPORISOMETRICOToolStripMenuItem.Click
        FRMREPORTJUNTAS.Show()
    End Sub

    Private Sub MATERIALESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALESToolStripMenuItem.Click
        '  Me.Hide()
        FRMMATERIALES.Show()
    End Sub

    Private Sub LIBRERIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBRERIAToolStripMenuItem.Click
        LIBRERIA.Show()

    End Sub

   


    Private Sub JUNTAHOJA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JUNTAHOJA.TextChanged
        FRMMATERIALES.TXHOJASPOOL.Text = Me.JUNTAHOJA.Text
    End Sub

    Private Sub JUNTAREVISION_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JUNTAREVISION.TextChanged
        FRMMATERIALES.TXREVSPOOL.Text = Me.JUNTAREVISION.Text
    End Sub

   
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click

    End Sub

    Private Sub JuntsIsometric_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class