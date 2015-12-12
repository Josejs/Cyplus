Imports System.Data
Imports System.Data.SqlClient

Public Class CLIENTES
    Sub LIMP()
        TXTIDCLIENTE.Clear()
        TXTDESCRIPCIONCLIENTE.Clear()
        TXTCODIGOCLIENTE.Clear()
        TXTMATERIALCLIENTE.Clear()

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()


        End If
    End Sub

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click
        REGISTROSCLIENTES.Show()

    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("INS_CLIENTE", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 250).Value = TXTCODIGOCLIENTE.Text
                .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 250).Value = TXTDESCRIPCIONCLIENTE.Text
                .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 250).Value = TXTMATERIALCLIENTE.Text
            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("CLIENTE REGISTRADO EXITOSAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LIMP()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LIMP()

        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        LIMP()
    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        Me.ErrorProvider1.SetError(TXTIDCLIENTE, "")
        Dim VALID As Boolean = False
        If (TXTIDCLIENTE.Text.Trim = "") Then
            ErrorProvider1.SetError(TXTIDCLIENTE, "FALTA EL IDENTIFICADOR")
            VALID = True

        End If


        If VALID = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("EDIT_CLIENTE", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXTIDCLIENTE.Text)
                    .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 250).Value = TXTCODIGOCLIENTE.Text
                    .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 250).Value = TXTDESCRIPCIONCLIENTE.Text
                    .Parameters.Add("@MATERIAL", SqlDbType.NVarChar, 250).Value = TXTMATERIALCLIENTE.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO MODIFICADO EXITOSAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMP()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMP()

            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Me.ErrorProvider1.SetError(TXTIDCLIENTE, "")
        Dim VALID As Boolean = False
        If (TXTIDCLIENTE.Text.Trim = "") Then
            ErrorProvider1.SetError(TXTIDCLIENTE, "FALTA EL IDENTIFICADOR")
            VALID = True

        End If


        If VALID = True Then
            MessageBox.Show("DEBE BUSCAR UN REGISTRO DE LA BUSQUEDA AVANZADA PRIMERO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("ELIM_CLIENTE", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXTIDCLIENTE.Text)

                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO ELIMINADO EXITOSAMENTE!!", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMP()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMP()

            Finally
                DECONECTARBD()

            End Try
        End If


    End Sub
End Class