Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class CALIDADFR

    Dim INDICADOR As Integer

    Sub limpiarCampos()
        TXTXDI.Clear()
        TXTNUMEROISO.ResetText()
        TXTXJUNTA.ResetText()
        TXTXPND.ResetText()
        TXT1ERATOMA.ResetText()
        TXTNOREPORTE1ERATOMA.Clear()
        TXTFECHAREPORTE1ERATOMA.Clear()
        TXTRESULTADO1ERATOMA.Clear()
        TXTXPRIMERREPARACION.ResetText()
        TXTNOREPORTE1REPARACION.Clear()
        TXTFECHA1REPARACION.Clear()
        TXTRESULTADOPRIMERAREPARACION.Clear()
        TXTXSEGUNDAREPARACION.ResetText()
        TXTNOREPSEGUNDAREPARACION.Clear()
        TXTFECHA2REPARACION.Clear()
        TXTRESULTADOSEGUNDAREPARACION.Clear()
        TXTLIQUIDO.ResetText()
        'AÑADIDOS
        CBTI.ResetText()
        CBSERVICIO.ResetText()
        CBESPECIFICACION.ResetText()
        TXTSPOOL.ResetText()
        '***************
        TXTNOREPORTELIQUIDO.Clear()
        TXTFECHAREPORTELIQUIDO.Clear()
        TXTXPW.ResetText()
        TXTNOREPORTEPWHT.Clear()
        TXTFECHAPWHT.Clear()
        TXTXDUREZA.ResetText()
        TXTNOREPORTEDUREZA.Clear()
        TXTFECHADUREZA.Clear()
        TXTXRESULTADODUREZA.Clear()
        TXTUT.ResetText()
        TXTXUTNOREPORT.Clear()
        TXTUTRESULTADO.Clear()
        TXTXMT.ResetText()
        TXTNOREPORTMT.Clear()
        TXTFECHAREPORTMT.Clear()
        TXTXPMI.ResetText()
        TXTNOREPORTPMI.Clear()
        TXTFECHAREPORTPMI.Clear()

    End Sub

    Sub OBJ_NUM_ISO()
        Try
            CONECTARBD2()
            CADENA = "SELECT  DISTINCT NUM_ISO from JUNTAS"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTNUMEROISO.DataSource = DS.Tables(0)
            TXTNUMEROISO.DisplayMember = "NUM_ISO"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()

        End Try
    End Sub 'LLENA LA LISTA DEL NUMERO DE ISOMETRICO
    Sub OBJ_JUNTA()

        Try
            '  CONECTARBD2()
            CADENA = "SELECT  JUNTA,TIPO1,TIPO2 from JUNTAS WHERE NUM_ISO='" & TXTNUMEROISO.Text & "'" ' AND SPOOL='" & TXTSPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTXJUNTA.DataSource = DS.Tables(0)
            TXTXJUNTA.DisplayMember = "JUNTA"
            CBTI.DataSource = DS.Tables(0)
            CBTI.DisplayMember = "TIPO1"

            CBT2.DataSource = DS.Tables(0)
            CBT2.DisplayMember = "TIPO2"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()


        End Try
    End Sub 'LLENA LA LISTA DE JUNTAS
    Sub OBJ_PND()
        Try
            CONECTARBD2()
            CADENA = "SELECT  DISTINCT RX from TBL_ISO WHERE NUM_ISO='" & TXTNUMEROISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTXPND.DataSource = DS.Tables(0)
            TXTXPND.DisplayMember = "RX"

            'TXTXJUNTA.DataSource = DS.Tables(0)
            'TXTXJUNTA.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
 

        End Try
    End Sub 'LLENA LA LISTA DEL NUMERO DE ISOMETRICO
    Sub OBJ_SPOOL()
        Try
            '  CONECTARBD2()
            CADENA = "SELECT  DISTINCT NUMERO_SPOOL from TBL_SPOOL WHERE NUMERO_ISOMETRICO='" & TXTNUMEROISO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTSPOOL.DataSource = DS.Tables(0)
            TXTSPOOL.DisplayMember = "NUMERO_SPOOL"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()


        End Try
    End Sub
    Sub OBJESPECIFICACION_SERV()
        CADENA = "SELECT SERVICIO,ESPECIFICACION FROM TBL_ISO WHERE NUM_ISO='" & TXTNUMEROISO.Text & "'"
        COMANDO = New SqlCommand()
        COMANDO.CommandText = CADENA
        COMANDO.CommandType = CommandType.Text
        COMANDO.Connection = CN2
        ADP = New SqlDataAdapter(COMANDO)
        DS = New DataSet()
        ADP.Fill(DS)

        CBSERVICIO.DataSource = DS.Tables(0)
        CBSERVICIO.DisplayMember = "SERVICIO"

        CBESPECIFICACION.DataSource = DS.Tables(0)
        CBESPECIFICACION.DisplayMember = "ESPECIFICACION"
    End Sub
    Sub OBJ_SOLDADOR()
        Try

            CADENA = "SELECT  DISTINCT FONDEO1_P from PRODUCCION_DIARIA WHERE ISOMETRICO_P='" & TXTNUMEROISO.Text & "' AND JUNTA_P='" & TXTXJUNTA.Text & "' AND SPOOL_P='" & TXTSPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBSOLDADOR.DataSource = DS.Tables(0)
            CBSOLDADOR.DisplayMember = "FONDEO1_P"





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
            FRMINICIOCALID.Show()
        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim VALIDARCAMPO As Boolean = False
        
        EP.SetError(TXTNUMEROISO, "")
        EP.SetError(TXTXJUNTA, "")
        EP.SetError(TXTXPND, "")
        'primera toma
        EP.SetError(TXT1ERATOMA, "")
        EP.SetError(TXTNOREPORTE1ERATOMA, "")
        EP.SetError(TXTFECHAREPORTE1ERATOMA, "")
        EP.SetError(TXTRESULTADO1ERATOMA, "")
        'primera reparacion
        EP.SetError(TXTXPRIMERREPARACION, "")
        EP.SetError(TXTNOREPORTE1REPARACION, "")
        EP.SetError(TXTFECHA1REPARACION, "")
        EP.SetError(TXTRESULTADOPRIMERAREPARACION, "")
        'pruebas segunda reparacion
        EP.SetError(TXTXSEGUNDAREPARACION, "")
        EP.SetError(TXTNOREPSEGUNDAREPARACION, "")
        EP.SetError(TXTFECHA2REPARACION, "")
        EP.SetError(TXTRESULTADOSEGUNDAREPARACION, "")
        'pruebas liquidos
        EP.SetError(TXTLIQUIDO, "")
        EP.SetError(TXTNOREPORTELIQUIDO, "")

        EP.SetError(TXTFECHAREPORTELIQUIDO, "")
        'pruebas pwht
        EP.SetError(TXTXPW, "")
        EP.SetError(TXTNOREPORTEPWHT, "")
        EP.SetError(TXTFECHAPWHT, "")
        'durezas
        EP.SetError(TXTXDUREZA, "")
        EP.SetError(TXTNOREPORTEDUREZA, "")
        EP.SetError(TXTFECHADUREZA, "")
        EP.SetError(TXTXRESULTADODUREZA, "")
        'pruebas ut
        EP.SetError(TXTUT, "")
        EP.SetError(TXTXUTNOREPORT, "")
        EP.SetError(TXTUTRESULTADO, "")
        'prueba mt
        EP.SetError(TXTXMT, "")
        EP.SetError(TXTNOREPORTMT, "")
        EP.SetError(TXTFECHAREPORTMT, "")
        'prueba pmi
        EP.SetError(TXTXPMI, "")
        EP.SetError(TXTNOREPORTPMI, "")
        EP.SetError(TXTFECHAREPORTPMI, "")
        EP.SetError(CBSOLDADOR, "")


        If (TXTNUMEROISO.Text.Trim = "") Then
            EP.SetError(TXTNUMEROISO, "DEBE ESPECIFICAR EL NUMERO DEL ISOMETRICO")
            VALIDARCAMPO = True
        End If

        If (TXTXJUNTA.Text.Trim = "") Then
            EP.SetError(TXTXJUNTA, "DEBE ESPECIFICAR EL NUMERO DE JUNTA")
            VALIDARCAMPO = True
        End If

        If (TXTXPND.Text.Trim = "") Then
            EP.SetError(TXTXPND, "DEBE ESPECIFICAR EL NUMERO DE RX")
            VALIDARCAMPO = True
        End If

        If (TXT1ERATOMA.Text.Trim = "") Then
            EP.SetError(TXT1ERATOMA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTNOREPORTE1ERATOMA.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTE1ERATOMA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTFECHAREPORTE1ERATOMA.Text.Trim = "") Then
            EP.SetError(TXTFECHAREPORTE1ERATOMA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTRESULTADO1ERATOMA.Text.Trim = "") Then
            EP.SetError(TXTRESULTADO1ERATOMA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTXPRIMERREPARACION.Text.Trim = "") Then
            EP.SetError(TXTXPRIMERREPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTNOREPORTE1REPARACION.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTE1REPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTFECHA1REPARACION.Text.Trim = "") Then
            EP.SetError(TXTFECHA1REPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTRESULTADOPRIMERAREPARACION.Text.Trim = "") Then
            EP.SetError(TXTRESULTADOPRIMERAREPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTXSEGUNDAREPARACION.Text.Trim = "") Then
            EP.SetError(TXTXSEGUNDAREPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTNOREPSEGUNDAREPARACION.Text.Trim = "") Then
            EP.SetError(TXTNOREPSEGUNDAREPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTFECHA2REPARACION.Text.Trim = "") Then
            EP.SetError(TXTFECHA2REPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTRESULTADOSEGUNDAREPARACION.Text.Trim = "") Then
            EP.SetError(TXTRESULTADOSEGUNDAREPARACION, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTLIQUIDO.Text.Trim = "") Then
            EP.SetError(TXTLIQUIDO, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTNOREPORTELIQUIDO.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTELIQUIDO, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTFECHAREPORTELIQUIDO.Text.Trim = "") Then
            EP.SetError(TXTFECHAREPORTELIQUIDO, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTXPW.Text.Trim = "") Then
            EP.SetError(TXTXPW, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If


        If (TXTNOREPORTEPWHT.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTEPWHT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTFECHAPWHT.Text.Trim = "") Then
            EP.SetError(TXTFECHAPWHT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If


        If (TXTXDUREZA.Text.Trim = "") Then
            EP.SetError(TXTXDUREZA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTNOREPORTEDUREZA.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTEDUREZA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTFECHADUREZA.Text.Trim = "") Then
            EP.SetError(TXTFECHADUREZA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTXRESULTADODUREZA.Text.Trim = "") Then
            EP.SetError(TXTXRESULTADODUREZA, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If


        If (TXTUT.Text.Trim = "") Then
            EP.SetError(TXTUT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTXUTNOREPORT.Text.Trim = "") Then
            EP.SetError(TXTXUTNOREPORT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTUTRESULTADO.Text.Trim = "") Then
            EP.SetError(TXTUTRESULTADO, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If


        If (TXTXMT.Text.Trim = "") Then
            EP.SetError(TXTXMT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTNOREPORTMT.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTMT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If
        If (TXTFECHAREPORTMT.Text.Trim = "") Then
            EP.SetError(TXTFECHAREPORTMT, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If


        If (TXTXPMI.Text.Trim = "") Then
            EP.SetError(TXTXPMI, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTNOREPORTPMI.Text.Trim = "") Then
            EP.SetError(TXTNOREPORTPMI, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (TXTFECHAREPORTPMI.Text.Trim = "") Then
            EP.SetError(TXTFECHAREPORTPMI, "CAMPO OBLIGATORIO")
            VALIDARCAMPO = True
        End If

        If (CBSOLDADOR.Text.Trim = "") Then
            EP.SetError(CBSOLDADOR, "OBLIGATORIO")
            VALIDARCAMPO = True
            ToastNotification.Show(Me, "DEBE ESPECIFICAR OBLIGATORIAMENTE EL SOLDADOR", My.Resources.descarga, 6000, eToastPosition.TopRight)
        End If


        If (VALIDARCAMPO = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ToastNotification.Show(Me, "ESPECIFIQUE CON UN GUION (-) LOS VALORES QUE NO VAYA A INTRODUCIR EN ESTE MOMENTO YA QUE TODOS LOS CAMPOS SON REQUERIDOS POR EL SISTEMA", My.Resources.descarga, 6000, eToastPosition.TopRight)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_TRAZA", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTNUMEROISO.Text
                    .Parameters.Add("@JUNTA", SqlDbType.Int).Value = TXTXJUNTA.Text
                    .Parameters.Add("@PND", SqlDbType.Float, 53).Value = TXTXPND.Text
                    .Parameters.Add("@PRIMERA_TOMA", SqlDbType.NVarChar, 100).Value = TXT1ERATOMA.Text
                    .Parameters.Add("@NO_REPORTE", SqlDbType.NVarChar, 100).Value = TXTNOREPORTE1ERATOMA.Text
                    .Parameters.Add("@FECHA_REPORTE", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTE1ERATOMA.Text
                    .Parameters.Add("@RESULTADO_PRIMERA_TOMA", SqlDbType.NVarChar, 100).Value = TXTRESULTADO1ERATOMA.Text
                    .Parameters.Add("@PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTXPRIMERREPARACION.Text
                    .Parameters.Add("@NO_REPORTE_PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTNOREPORTE1REPARACION.Text
                    .Parameters.Add("@FECHA_REPORTE_PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTFECHA1REPARACION.Text
                    .Parameters.Add("@RESULTADO_PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTRESULTADOPRIMERAREPARACION.Text
                    .Parameters.Add("@SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTXSEGUNDAREPARACION.Text
                    .Parameters.Add("@NO_REPORTE_SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTNOREPSEGUNDAREPARACION.Text
                    .Parameters.Add("@FECHA_REPORTE_SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTFECHA2REPARACION.Text
                    .Parameters.Add("@RESULTADO_SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTRESULTADOSEGUNDAREPARACION.Text
                    .Parameters.Add("@LIQ_P", SqlDbType.NVarChar, 100).Value = TXTLIQUIDO.Text
                    .Parameters.Add("@NO_REPORTE_LIQ", SqlDbType.NVarChar, 100).Value = TXTNOREPORTELIQUIDO.Text
                    .Parameters.Add("@FECHA_REPORTE_LIQ", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTELIQUIDO.Text
                    .Parameters.Add("@PWHT", SqlDbType.NVarChar, 100).Value = TXTXPW.Text
                    .Parameters.Add("@NO_REPORTE_PWHT", SqlDbType.NVarChar, 100).Value = TXTNOREPORTEPWHT.Text
                    .Parameters.Add("@FECHA_REPORTE_PWHT", SqlDbType.NVarChar, 100).Value = TXTFECHAPWHT.Text
                    .Parameters.Add("@DUREZAS", SqlDbType.NVarChar, 100).Value = TXTXDUREZA.Text
                    .Parameters.Add("@NO_REPORTE_DUREZA", SqlDbType.NVarChar, 100).Value = TXTNOREPORTEDUREZA.Text
                    .Parameters.Add("@FECHA_REPORTE_DUREZA", SqlDbType.NVarChar, 100).Value = TXTFECHADUREZA.Text
                    .Parameters.Add("@RESULTADO_DUREZA", SqlDbType.NVarChar, 100).Value = TXTXRESULTADODUREZA.Text
                    .Parameters.Add("@UT", SqlDbType.NVarChar, 100).Value = TXTUT.Text
                    .Parameters.Add("@NO_REPORTE_UT", SqlDbType.NVarChar, 100).Value = TXTXUTNOREPORT.Text
                    .Parameters.Add("@FECHA_REPORTE_UT", SqlDbType.NVarChar, 100).Value = TXTUTRESULTADO.Text
                    .Parameters.Add("@MT", SqlDbType.NVarChar, 100).Value = TXTXMT.Text
                    .Parameters.Add("@NO_REPORTE_MT", SqlDbType.NVarChar, 100).Value = TXTNOREPORTMT.Text
                    .Parameters.Add("@FECHA_REPORTE_MT", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTMT.Text
                    .Parameters.Add("@PMI", SqlDbType.NVarChar, 100).Value = TXTXPMI.Text
                    .Parameters.Add("@NO_REPORTE_PMI", SqlDbType.NVarChar, 100).Value = TXTNOREPORTPMI.Text
                    .Parameters.Add("@FECHA_REPORTE_PMI", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTPMI.Text
                    .Parameters.Add("@spool", SqlDbType.NVarChar, 100).Value = TXTSPOOL.Text
                    .Parameters.Add("@TIPO", SqlDbType.NVarChar, 100).Value = CBTI.Text
                    .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 50).Value = CBSERVICIO.Text
                    .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 50).Value = CBESPECIFICACION.Text
                    .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 50).Value = CBT2.Text
                    .Parameters.Add("@SOLDADOR", SqlDbType.NVarChar, 50).Value = CBSOLDADOR.Text


                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO ASIGNADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'limpiarCampos()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DECONECTARBD()

            End Try
        End If


    End Sub

    Private Sub CALIDADFR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' OBJ_NUM_ISO()
        '   OBJ_JUNTA()
        '   OBJ_PND()
        '   LlenarGrid()
        '  LlenarGrid2()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try
            'OBJ_JUNTA()
            OBJ_SPOOL()
            OBJESPECIFICACION_SERV()
            '  OBJ_SOLDADOR()

            ' OBJ_PND()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        OBJ_PND()
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        limpiarCampos()

    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        EP.SetError(TXTXDI, "")
        Dim VALIDAR As Boolean = False


        If (TXTXDI.Text.Trim = "") Then
            EP.SetError(TXTXDI, "DEBE ASIGNAR EL IDENTIFICADOR")
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
                    COMANDO = New SqlCommand("EDIT_TRAZA", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTXDI.Text)
                        .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTNUMEROISO.Text
                        .Parameters.Add("@JUNTA", SqlDbType.Int).Value = TXTXJUNTA.Text
                        .Parameters.Add("@PND", SqlDbType.Float, 53).Value = TXTXPND.Text
                        .Parameters.Add("@PRIMERA_TOMA", SqlDbType.NVarChar, 100).Value = TXT1ERATOMA.Text
                        .Parameters.Add("@NO_REPORTE", SqlDbType.NVarChar, 100).Value = TXTNOREPORTE1ERATOMA.Text
                        .Parameters.Add("@FECHA_REPORTE", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTE1ERATOMA.Text
                        .Parameters.Add("@RESULTADO_PRIMERA_TOMA", SqlDbType.NVarChar, 100).Value = TXTRESULTADO1ERATOMA.Text
                        .Parameters.Add("@PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTXPRIMERREPARACION.Text
                        .Parameters.Add("@NO_REPORTE_PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTNOREPORTE1REPARACION.Text
                        .Parameters.Add("@FECHA_REPORTE_PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTFECHA1REPARACION.Text
                        .Parameters.Add("@RESULTADO_PRIMERA_REP", SqlDbType.NVarChar, 100).Value = TXTRESULTADOPRIMERAREPARACION.Text
                        .Parameters.Add("@SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTXSEGUNDAREPARACION.Text
                        .Parameters.Add("@NO_REPORTE_SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTNOREPSEGUNDAREPARACION.Text
                        .Parameters.Add("@FECHA_REPORTE_SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTFECHA2REPARACION.Text
                        .Parameters.Add("@RESULTADO_SEGUNDA_REP", SqlDbType.NVarChar, 100).Value = TXTRESULTADOSEGUNDAREPARACION.Text
                        .Parameters.Add("@LIQ_P", SqlDbType.NVarChar, 100).Value = TXTLIQUIDO.Text
                        .Parameters.Add("@NO_REPORTE_LIQ", SqlDbType.NVarChar, 100).Value = TXTNOREPORTELIQUIDO.Text
                        .Parameters.Add("@FECHA_REPORTE_LIQ", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTELIQUIDO.Text
                        .Parameters.Add("@PWHT", SqlDbType.NVarChar, 100).Value = TXTXPW.Text
                        .Parameters.Add("@NO_REPORTE_PWHT", SqlDbType.NVarChar, 100).Value = TXTNOREPORTEPWHT.Text
                        .Parameters.Add("@FECHA_REPORTE_PWHT", SqlDbType.NVarChar, 100).Value = TXTFECHAPWHT.Text
                        .Parameters.Add("@DUREZAS", SqlDbType.NVarChar, 100).Value = TXTXDUREZA.Text
                        .Parameters.Add("@NO_REPORTE_DUREZA", SqlDbType.NVarChar, 100).Value = TXTNOREPORTEDUREZA.Text
                        .Parameters.Add("@FECHA_REPORTE_DUREZA", SqlDbType.NVarChar, 100).Value = TXTFECHADUREZA.Text
                        .Parameters.Add("@RESULTADO_DUREZA", SqlDbType.NVarChar, 100).Value = TXTXRESULTADODUREZA.Text
                        .Parameters.Add("@UT", SqlDbType.NVarChar, 100).Value = TXTUT.Text
                        .Parameters.Add("@NO_REPORTE_UT", SqlDbType.NVarChar, 100).Value = TXTXUTNOREPORT.Text
                        .Parameters.Add("@FECHA_REPORTE_UT", SqlDbType.NVarChar, 100).Value = TXTUTRESULTADO.Text
                        .Parameters.Add("@MT", SqlDbType.NVarChar, 100).Value = TXTXMT.Text
                        .Parameters.Add("@NO_REPORTE_MT", SqlDbType.NVarChar, 100).Value = TXTNOREPORTMT.Text
                        .Parameters.Add("@FECHA_REPORTE_MT", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTMT.Text
                        .Parameters.Add("@PMI", SqlDbType.NVarChar, 100).Value = TXTXPMI.Text
                        .Parameters.Add("@NO_REPORTE_PMI", SqlDbType.NVarChar, 100).Value = TXTNOREPORTPMI.Text
                        .Parameters.Add("@FECHA_REPORTE_PMI", SqlDbType.NVarChar, 100).Value = TXTFECHAREPORTPMI.Text
                        .Parameters.Add("@spool", SqlDbType.NVarChar, 100).Value = TXTSPOOL.Text
                        .Parameters.Add("@TIPO", SqlDbType.NVarChar, 100).Value = CBTI.Text
                        .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 50).Value = CBSERVICIO.Text
                        .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 50).Value = CBESPECIFICACION.Text
                        .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 50).Value = CBT2.Text
                        .Parameters.Add("@SOLDADOR", SqlDbType.NVarChar, 50).Value = CBSOLDADOR.Text
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO MODIFICADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiarCampos()
                    ' LlenarGrid()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If

        End If


    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        EP.SetError(TXTXDI, "")
        Dim VALIDAR As Boolean = False


        If (TXTXDI.Text.Trim = "") Then
            EP.SetError(TXTXDI, "DEBE ASIGNAR EL IDENTIFICADOR")
            VALIDAR = True
        End If

        If (VALIDAR = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_TRAZA", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure
                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTXDI.Text)
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiarCampos()
                    ' LlenarGrid()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If

    End Sub

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click
        REGCALIDAD.Show()
    End Sub

  


    Private Sub LLENARLISTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLENARLISTASToolStripMenuItem.Click
        Try
            OBJ_NUM_ISO()
            OBJ_JUNTA()
            OBJ_PND()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub



  

    Private Sub DAILYPORISOMETRICOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        REPORTPORISOMETRICO.Show()
    End Sub

    Private Sub DAILYPORISOMETRICOYJUNTAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        REPORTDAILYQUERY.Show()
    End Sub

    Private Sub TXTXJUNTA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTXJUNTA.SelectedIndexChanged

    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        OBJ_JUNTA()
    End Sub

    Private Sub TXTSPOOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSPOOL.SelectedIndexChanged

    End Sub

    Private Sub DAILYPORISOMETRICOYSPOOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmdailycondicion.Show()

    End Sub

    Private Sub TXTNUMEROISO_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TXTNUMEROISO.SelectedIndexChanged
        'OBJESPECIFICACION_SERV()
    End Sub


    Private Sub W10PORISOMETRICOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W10PORISOMETRICOToolStripMenuItem.Click
        FRMW10PORISOMETRICO.Show()
    End Sub

    Private Sub W10PORISOMETRICOYSPOOLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles W10PORISOMETRICOYSPOOLToolStripMenuItem.Click
        FRMW10PORSPOOL.Show()
    End Sub

 

    Private Sub INFORMEPORTADAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INFORMEPORTADAToolStripMenuItem.Click
        FRMPORTADA.Show()
    End Sub

    Private Sub INFORMEQC15ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INFORMEQC15ToolStripMenuItem.Click
        QC15PACK.Show()
    End Sub



    Private Sub SABANAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SABANAToolStripMenuItem.Click
        FRMSABANACAPTURA.Show()
    End Sub

  
 

    Private Sub PORFECHADESOLDADURAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PORFECHADESOLDADURAToolStripMenuItem.Click
        FRMW24.Show()
    End Sub

    Private Sub PORISOMETRICOYSPOOLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PORISOMETRICOYSPOOLToolStripMenuItem.Click
        FRMW24XSPOOL.Show()
    End Sub

    Private Sub TODASPORFECHADESOLDADURACAMPOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TODASPORFECHADESOLDADURACAMPOToolStripMenuItem.Click
        W24CAMPOFECHA.Show()
    End Sub

    Private Sub TODASPORPERIODOCAMPOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TODASPORPERIODOCAMPOToolStripMenuItem.Click
        W24PERIODOS.Show()
    End Sub

    Private Sub MAYORA2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MAYORA2ToolStripMenuItem.Click
        FRMW24MAYORDOS.Show()


    End Sub

    Private Sub MENOROIGUALA2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MENOROIGUALA2ToolStripMenuItem.Click
        FRMW24MENO2.Show()

    End Sub

    Private Sub INDICEDEEMBARQUESToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INDICEDEEMBARQUESToolStripMenuItem.Click
        FRMINDICE.Show()

    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click
        OBJ_SOLDADOR()

    End Sub

    Private Sub PRODUCCIONDECAMPOCONSECUTIVOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PRODUCCIONDECAMPOCONSECUTIVOToolStripMenuItem.Click
        FRM_CAMPO_CONSECUTIVO.Show()

    End Sub

    Private Sub PRODUCCIONDECAMPOPORISOMETRICOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PRODUCCIONDECAMPOPORISOMETRICOToolStripMenuItem.Click
        FRM_W24_GERMAN.Show()
    End Sub
End Class