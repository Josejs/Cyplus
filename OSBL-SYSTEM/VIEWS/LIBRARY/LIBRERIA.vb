Imports System.Data
Imports System.Data.SqlClient

Public Class LIBRERIA

    Sub LIMP()
        TXTID.Clear()
        TXTCODIGO.Clear()
        TXTDIM1.Clear()
        TXTDIM2.Clear()
        'TXTPESO.Clear()
        TXTDESC.Clear()
        ' TXTPESO.Clear()
        TXTCCODCLI.Clear()
        TXTXSTANDARD.Clear()
        TXTSUPERFICIE.Clear()
        TXTPESOUNITARIO.Clear()

        TXTMATERIAL.Clear()

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Me.EP.SetError(TXTCODIGO, "")

        Dim VALIDA As Boolean = False

        If (TXTCODIGO.Text.Trim = "") Then
            EP.SetError(TXTCODIGO, "DEBE INTRODUCIR EL CODIGO DEL MATERIAL")
            VALIDA = True
        End If

        If (VALIDA = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_LIB", CN)
                COMANDO.CommandType = CommandType.StoredProcedure


                With COMANDO
                    .Parameters.Add("@CODE_TCM", SqlDbType.NVarChar, 255).Value = TXTCODIGO.Text
                    .Parameters.Add("@CODE_NUMBER", SqlDbType.NVarChar, 255).Value = TXTCCODCLI.Text
                    .Parameters.Add("@DIAM_1", SqlDbType.NVarChar, 255).Value = TXTDIM1.Text
                    .Parameters.Add("@DIAM_2", SqlDbType.NVarChar, 255).Value = TXTDIM2.Text
                    ' .Parameters.Add("@PESO_UNITARIO", SqlDbType.NVarChar, 255).Value = TXTPESO.Text
                    .Parameters.Add("@DESCRIPCION_BREVE", SqlDbType.NVarChar, 255).Value = TXTDESC.Text
                    .Parameters.Add("@UNIDAD_MEDIDA", SqlDbType.NVarChar, 255).Value = TXTXMEDIDA.Text
                    .Parameters.Add("@CED_1", SqlDbType.NVarChar, 255).Value = TXTCEDULA1.Text
                    .Parameters.Add("@CED_2", SqlDbType.NVarChar, 255).Value = TXTCEDULA2.Text
                    .Parameters.Add("@STANDARD", SqlDbType.NVarChar, 255).Value = TXTXSTANDARD.Text
                    .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 255).Value = TXTMATERIAL.Text
                    .Parameters.Add("@SUPERFICIE", SqlDbType.Float, 53).Value = TXTSUPERFICIE.Text
                    .Parameters.Add("@PESO", SqlDbType.Float, 53).Value = TXTPESOUNITARIO.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("MATERIAL REGISTRADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMP()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'LIMP()
            Finally
                DECONECTARBD()

            End Try
        End If


    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        LIMP()
    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        Me.EP.SetError(TXTCODIGO, "")

        Dim VALIDA As Boolean = False

        If (TXTID.Text.Trim = "") Then
            EP.SetError(TXTID, "FALTA EL IDENTIFICADOR")
            VALIDA = True
        End If

        If (VALIDA = True) Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MOFIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_LIB", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTID.Text)
                        .Parameters.Add("@CODE_TCM", SqlDbType.NVarChar, 255).Value = TXTCODIGO.Text
                        .Parameters.Add("@CODE_NUMBER", SqlDbType.NVarChar, 255).Value = TXTCCODCLI.Text
                        .Parameters.Add("@DIAM_1", SqlDbType.NVarChar, 255).Value = TXTDIM1.Text
                        .Parameters.Add("@DIAM_2", SqlDbType.NVarChar, 255).Value = TXTDIM2.Text
                        ' .Parameters.Add("@PESO_UNITARIO", SqlDbType.NVarChar, 255).Value = TXTPESO.Text
                        .Parameters.Add("@DESCRIPCION_BREVE", SqlDbType.NVarChar, 255).Value = TXTDESC.Text
                        .Parameters.Add("@UNIDAD_MEDIDA", SqlDbType.NVarChar, 255).Value = TXTXMEDIDA.Text
                        .Parameters.Add("@CED_1", SqlDbType.NVarChar, 255).Value = TXTCEDULA1.Text
                        .Parameters.Add("@CED_2", SqlDbType.NVarChar, 255).Value = TXTCEDULA2.Text
                        .Parameters.Add("@STANDARD", SqlDbType.NVarChar, 255).Value = TXTXSTANDARD.Text
                        .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 255).Value = TXTMATERIAL.Text
                        .Parameters.Add("@SUPERFICIE", SqlDbType.Float, 53).Value = TXTSUPERFICIE.Text
                        .Parameters.Add("@PESO", SqlDbType.Float, 53).Value = TXTPESOUNITARIO.Text
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("MATERIAL MODIFICADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Me.EP.SetError(TXTCODIGO, "")

        Dim VALIDA As Boolean = False

        If (TXTID.Text.Trim = "") Then
            EP.SetError(TXTID, "FALTA EL IDENTIFICADOR")
            VALIDA = True
        End If

        If (VALIDA = True) Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_LIB", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure

                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTID.Text)

                    End With

                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("EL REGISTRO FUE ELIMINADO CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click
        REGLIBRERIA.Show()
    End Sub

  
End Class