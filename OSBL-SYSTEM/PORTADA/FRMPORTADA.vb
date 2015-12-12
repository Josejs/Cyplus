Imports System.Data
Imports System.Data.SqlClient

Public Class FRMPORTADA
#Region "METODOS"
    Sub OBTENER_INFO()
        Try
            CONECTARBD()

            CADENA = "select NUM_ISO,SERVICIO,ESPECIFICACION,AREA from TBL_ISO where LINEA='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXNOISOMETRICO.DataSource = DS.Tables(0)
            TXNOISOMETRICO.DisplayMember = "NUM_ISO"

            TXPORTADASISTEMA.DataSource = DS.Tables(0)
            TXPORTADASISTEMA.DisplayMember = "SERVICIO"

            TXPORTADACLASE.DataSource = DS.Tables(0)
            TXPORTADACLASE.DisplayMember = "ESPECIFICACION"

            TXPORTADAAREA.DataSource = DS.Tables(0)
            TXPORTADAAREA.DisplayMember = "AREA"



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
    Sub OBTENER_SPOOL()
        Try
            CONECTARBD()

            CADENA = "select NUMERO_SPOOL,HOJA,LIBERACION_PND from TBL_SPOOL where NUMERO_ISOMETRICO='" & TXNOISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXPORTADASPOOL.DataSource = DS.Tables(0)
            TXPORTADASPOOL.DisplayMember = "NUMERO_SPOOL"

            TXPORTADAHOJA.DataSource = DS.Tables(0)
            TXPORTADAHOJA.DisplayMember = "HOJA"

            TXPORTADAFECHA.DataSource = DS.Tables(0)
            TXPORTADAFECHA.DisplayMember = "LIBERACION_PND"




        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub
    Sub OBTENER_JUNTA1()
        Try
            CONECTARBD()

            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXJUNTA1.DataSource = DS.Tables(0)
            TXJUNTA1.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
       
        End Try
    End Sub
    Sub OBTENER_JUNTA2()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA2.DataSource = DS.Tables(0)
            TXJUNTA2.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
       

    End Sub

    Sub OBTENER_JUNTA3()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA3.DataSource = DS.Tables(0)
            TXJUNTA3.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA4()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA4.DataSource = DS.Tables(0)
            TXJUNTA4.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA5()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA5.DataSource = DS.Tables(0)
            TXJUNTA5.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA6()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA6.DataSource = DS.Tables(0)
            TXJUNTA6.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA7()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA7.DataSource = DS.Tables(0)
            TXJUNTA7.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA8()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA8.DataSource = DS.Tables(0)
            TXJUNTA8.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA9()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA9.DataSource = DS.Tables(0)
            TXJUNTA9.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Sub OBTENER_JUNTA10()
        Try
            CADENA = "select JUNTA from JUNTAS where NUM_ISO='" & TXNOISOMETRICO.Text & "' AND SPOOL='" & TXPORTADASPOOL.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            TXJUNTA10.DataSource = DS.Tables(0)
            TXJUNTA10.DisplayMember = "JUNTA"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try



    End Sub

    Sub LIMPIAR_TEXT()
        TXDUREZA.ResetText()
        TXENVIOINCOMPLETO.ResetText()
        TXIDENSPOOLTIPO.ResetText()
        TXIDENTIFICACIONSPOOL.ResetText()
        TXINSPECCIONDIMENSIONAL.ResetText()
        TXIV.ResetText()
        TXJUNTA1.ResetText()
        TXJUNTA10.ResetText()
        TXJUNTA2.ResetText()
        TXJUNTA3.ResetText()
        TXJUNTA4.ResetText()
        TXJUNTA5.ResetText()
        TXJUNTA6.ResetText()
        TXJUNTA7.ResetText()
        TXJUNTA8.ResetText()
        TXJUNTA9.ResetText()
        TXUT.ResetText()

        TXLP.ResetText()
        TXNOISOMETRICO.ResetText()
        TXPINTURA.ResetText()
        TXPM.ResetText()
        TXPMI.ResetText()
        TXPORTADAAREA.ResetText()
        TXPORTADACLASE.ResetText()
        TXPORTADAENVIOCOMPLETO.ResetText()
        TXPORTADAFECHA.ResetText()
        TXPORTADAHOJA.ResetText()
        TXPORTADAID.Clear()
        TXPORTADANOREPORTE.Clear()
        TXPORTADASISTEMA.ResetText()
        TXPORTADASPOOL.ResetText()
        TXPRESION.ResetText()
        TXPULIDO.ResetText()
        TXPWHT.ResetText()
        TXREPARACION.ResetText()
        TXRT.ResetText()
        TXTISOMETRICO.Clear()

    End Sub



#End Region

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR SESION EN EL SISTEMA?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub


    Private Sub TXTISOMETRICO_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTISOMETRICO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select LINEA FROM TBL_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("LINEA").ToString())
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

    Private Sub BTNGUARDAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNGUARDAR.Click
        Try

            CONECTARBD()

            COMANDO = New SqlCommand("INS_CHECK", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.Clear()
                .Parameters.Add("@ISOMETRICO ", SqlDbType.NVarChar, 150).Value = TXTISOMETRICO.Text
                .Parameters.Add("@NO_ISOMETRICO", SqlDbType.Int).Value = TXNOISOMETRICO.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 50).Value = TXPORTADASPOOL.Text
                .Parameters.Add("@HOJA", SqlDbType.NVarChar, 150).Value = TXPORTADAHOJA.Text
                .Parameters.Add("@AREA", SqlDbType.NVarChar, 150).Value = TXPORTADAAREA.Text
                .Parameters.Add("@CLASE", SqlDbType.NVarChar, 150).Value = TXPORTADACLASE.Text
                .Parameters.Add("@SISTEMA", SqlDbType.NVarChar, 150).Value = TXPORTADASISTEMA.Text
                .Parameters.Add("@ENVIO_SPOOL_COMPLETO", SqlDbType.NVarChar, 150).Value = TXPORTADAENVIOCOMPLETO.Text
                .Parameters.Add("@ENVIO_SPOOL_INCOMPLETO", SqlDbType.NVarChar, 150).Value = TXENVIOINCOMPLETO.Text
                .Parameters.Add("@INSPECCION_DIMENSIONAL ", SqlDbType.NVarChar, 150).Value = TXINSPECCIONDIMENSIONAL.Text
                .Parameters.Add("@IDENTIFICACION_SPOOL", SqlDbType.NVarChar, 150).Value = TXIDENTIFICACIONSPOOL.Text
                .Parameters.Add("@JUNTA1", SqlDbType.NVarChar, 150).Value = TXJUNTA1.Text
                .Parameters.Add("@JUNTA2", SqlDbType.NVarChar, 150).Value = TXJUNTA2.Text
                .Parameters.Add("@JUNTA3", SqlDbType.NVarChar, 150).Value = TXJUNTA3.Text
                .Parameters.Add("@JUNTA4", SqlDbType.NVarChar, 150).Value = TXJUNTA4.Text
                .Parameters.Add("@JUNTA5", SqlDbType.NVarChar, 150).Value = TXJUNTA5.Text
                .Parameters.Add("@JUNTA6", SqlDbType.NVarChar, 150).Value = TXJUNTA6.Text
                .Parameters.Add("@JUNTA7", SqlDbType.NVarChar, 150).Value = TXJUNTA7.Text
                .Parameters.Add("@JUNTA8", SqlDbType.NVarChar, 150).Value = TXJUNTA8.Text
                .Parameters.Add("@JUNTA9", SqlDbType.NVarChar, 150).Value = TXJUNTA9.Text
                .Parameters.Add("@JUNTA10", SqlDbType.NVarChar, 150).Value = TXJUNTA10.Text
                .Parameters.Add("@IDEN_SPOOL", SqlDbType.NVarChar, 150).Value = TXIDENTIFICACIONSPOOL.Text
                .Parameters.Add("@PND_LB_IV", SqlDbType.NVarChar, 150).Value = TXIV.Text
                .Parameters.Add("@PND_LB_LP", SqlDbType.NVarChar, 150).Value = TXLP.Text
                .Parameters.Add("@PND_LB_PM", SqlDbType.NVarChar, 150).Value = TXPM.Text
                .Parameters.Add("@PND_LB_UT", SqlDbType.NVarChar, 150).Value = TXUT.Text
                .Parameters.Add("@PND_LB_RT", SqlDbType.NVarChar, 150).Value = TXRT.Text
                .Parameters.Add("@PND_LB_PMI", SqlDbType.NVarChar, 150).Value = TXPMI.Text
                .Parameters.Add("@REPARACION", SqlDbType.NVarChar, 150).Value = TXREPARACION.Text
                .Parameters.Add("@PWHT", SqlDbType.NVarChar, 150).Value = TXPWHT.Text
                .Parameters.Add("@DUREZA", SqlDbType.NVarChar, 150).Value = TXDUREZA.Text
                .Parameters.Add("@PULIDO_PASO_RAIZ", SqlDbType.NVarChar, 150).Value = TXPULIDO.Text
                .Parameters.Add("@PUEBA_PRESION", SqlDbType.NVarChar, 150).Value = TXPRESION.Text
                .Parameters.Add("@PINTURA", SqlDbType.NVarChar, 150).Value = TXPINTURA.Text
                .Parameters.Add("@LIB_PND", SqlDbType.NVarChar, 50).Value = TXPORTADAFECHA.Text
            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("DATOS REGISTRADOS CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LIMPIAR_TEXT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Try
            OBTENER_INFO()
            ' OBTENER_SPOOL()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Try
            OBTENER_SPOOL()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Try
            OBTENER_JUNTA1()
            OBTENER_JUNTA2()
            OBTENER_JUNTA3()
            OBTENER_JUNTA4()
            OBTENER_JUNTA5()
            OBTENER_JUNTA6()
            OBTENER_JUNTA7()
            OBTENER_JUNTA8()
            OBTENER_JUNTA9()
            OBTENER_JUNTA10()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonX6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX6.Click
        LIMPIAR_TEXT()
    End Sub

    Private Sub PORISOMETRICOYSPOOLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PORISOMETRICOYSPOOLToolStripMenuItem.Click
        FRMREPORTEPORTADA.Show()
    End Sub

    Private Sub BTNEDITAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNEDITAR.Click
        Try

            CONECTARBD()

            COMANDO = New SqlCommand("EDIT_CHECK", CN)
            COMANDO.CommandType = CommandType.StoredProcedure
            With COMANDO
                .Parameters.Clear()
                .Parameters.AddWithValue("@ID", TXPORTADAID.Text)
                .Parameters.Add("@ISOMETRICO ", SqlDbType.NVarChar, 150).Value = TXTISOMETRICO.Text
                .Parameters.Add("@NO_ISOMETRICO", SqlDbType.Int).Value = TXNOISOMETRICO.Text
                .Parameters.Add("@SPOOL", SqlDbType.NVarChar, 50).Value = TXPORTADASPOOL.Text
                .Parameters.Add("@HOJA", SqlDbType.NVarChar, 150).Value = TXPORTADAHOJA.Text
                .Parameters.Add("@AREA", SqlDbType.NVarChar, 150).Value = TXPORTADAAREA.Text
                .Parameters.Add("@CLASE", SqlDbType.NVarChar, 150).Value = TXPORTADACLASE.Text
                .Parameters.Add("@SISTEMA", SqlDbType.NVarChar, 150).Value = TXPORTADASISTEMA.Text
                .Parameters.Add("@ENVIO_SPOOL_COMPLETO", SqlDbType.NVarChar, 150).Value = TXPORTADAENVIOCOMPLETO.Text
                .Parameters.Add("@ENVIO_SPOOL_INCOMPLETO", SqlDbType.NVarChar, 150).Value = TXENVIOINCOMPLETO.Text
                .Parameters.Add("@INSPECCION_DIMENSIONAL ", SqlDbType.NVarChar, 150).Value = TXINSPECCIONDIMENSIONAL.Text
                .Parameters.Add("@IDENTIFICACION_SPOOL", SqlDbType.NVarChar, 150).Value = TXIDENTIFICACIONSPOOL.Text
                .Parameters.Add("@JUNTA1", SqlDbType.NVarChar, 150).Value = TXJUNTA1.Text
                .Parameters.Add("@JUNTA2", SqlDbType.NVarChar, 150).Value = TXJUNTA2.Text
                .Parameters.Add("@JUNTA3", SqlDbType.NVarChar, 150).Value = TXJUNTA3.Text
                .Parameters.Add("@JUNTA4", SqlDbType.NVarChar, 150).Value = TXJUNTA4.Text
                .Parameters.Add("@JUNTA5", SqlDbType.NVarChar, 150).Value = TXJUNTA5.Text
                .Parameters.Add("@JUNTA6", SqlDbType.NVarChar, 150).Value = TXJUNTA6.Text
                .Parameters.Add("@JUNTA7", SqlDbType.NVarChar, 150).Value = TXJUNTA7.Text
                .Parameters.Add("@JUNTA8", SqlDbType.NVarChar, 150).Value = TXJUNTA8.Text
                .Parameters.Add("@JUNTA9", SqlDbType.NVarChar, 150).Value = TXJUNTA9.Text
                .Parameters.Add("@JUNTA10", SqlDbType.NVarChar, 150).Value = TXJUNTA10.Text
                .Parameters.Add("@IDEN_SPOOL", SqlDbType.NVarChar, 150).Value = TXIDENTIFICACIONSPOOL.Text
                .Parameters.Add("@PND_LB_IV", SqlDbType.NVarChar, 150).Value = TXIV.Text
                .Parameters.Add("@PND_LB_LP", SqlDbType.NVarChar, 150).Value = TXLP.Text
                .Parameters.Add("@PND_LB_PM", SqlDbType.NVarChar, 150).Value = TXPM.Text
                .Parameters.Add("@PND_LB_UT", SqlDbType.NVarChar, 150).Value = TXUT.Text
                .Parameters.Add("@PND_LB_RT", SqlDbType.NVarChar, 150).Value = TXRT.Text
                .Parameters.Add("@PND_LB_PMI", SqlDbType.NVarChar, 150).Value = TXPMI.Text
                .Parameters.Add("@REPARACION", SqlDbType.NVarChar, 150).Value = TXREPARACION.Text
                .Parameters.Add("@PWHT", SqlDbType.NVarChar, 150).Value = TXPWHT.Text
                .Parameters.Add("@DUREZA", SqlDbType.NVarChar, 150).Value = TXDUREZA.Text
                .Parameters.Add("@PULIDO_PASO_RAIZ", SqlDbType.NVarChar, 150).Value = TXPULIDO.Text
                .Parameters.Add("@PUEBA_PRESION", SqlDbType.NVarChar, 150).Value = TXPRESION.Text
                .Parameters.Add("@PINTURA", SqlDbType.NVarChar, 150).Value = TXPINTURA.Text
                .Parameters.Add("@LIB_PND", SqlDbType.NVarChar, 50).Value = TXPORTADAFECHA.Text
            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("REGISTRO MODIFICADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LIMPIAR_TEXT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub BTNELIMINAR_Click(sender As System.Object, e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim VALIDA As Boolean = False

        EP.SetError(TXPORTADAID, "")
        If (TXPORTADAID.Text.Trim = "") Then
            EP.SetError(TXPORTADAID, "DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO")
            VALIDA = True
        End If

        If VALIDA = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("DESEA ELIMINAR ESTE REGISTRO", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    COMANDO = New SqlCommand("ELIM_CHECK", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXPORTADAID.Text)
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMPIAR_TEXT()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LIMPIAR_TEXT()
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If



    End Sub

    Private Sub BTNVER_Click(sender As System.Object, e As System.EventArgs) Handles BTNVER.Click
        FRMREGISTROPORTADA.Show()
    End Sub
End Class