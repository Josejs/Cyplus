Imports System.Data
Imports System.Data.SqlClient

Public Class FRMUSUARIOSPINT

#Region "METODS"
    Sub CLEAN()
        TXTID.Clear()
        TXTPASSWORD.Clear()
        TXTUSUARIO.Clear()
    End Sub

    Sub LlenarGrid()

        Try
            CONECTARBD()
            CADENA = "Select*from USUARIO_PINT"
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
#End Region



    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("INS_USUARIO_PINT", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            With COMANDO
                .Parameters.Add("@US", SqlDbType.NVarChar, 50).Value = TXTUSUARIO.Text
                .Parameters.Add("@PAS", SqlDbType.NVarChar, 50).Value = TXTPASSWORD.Text

            End With
            COMANDO.ExecuteNonQuery()
            MessageBox.Show("USUARIO REGISTRADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CLEAN()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CLEAN()
        Finally
            DECONECTARBD()

        End Try

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL USUARIO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("EDIT_USU_PINT", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXTID.Text)
                    .Parameters.Add("@US", SqlDbType.NVarChar, 50).Value = TXTUSUARIO.Text
                    .Parameters.Add("@PAS", SqlDbType.NVarChar, 50).Value = TXTPASSWORD.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("USUARIO MODIFICADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CLEAN()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CLEAN()
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        If (MessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL USUARIO?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("ELIM_USU_PINT", CN)

                With COMANDO
                    .Parameters.AddWithValue("@ID", TXTID.Text)

                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("REGISTRO DE USUARIO ELIMINADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CLEAN()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CLEAN()
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        LlenarGrid()
    End Sub

    Private Sub FRMUSUARIOSPINT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            TXTID.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TXTUSUARIO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TXTPASSWORD.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub
End Class