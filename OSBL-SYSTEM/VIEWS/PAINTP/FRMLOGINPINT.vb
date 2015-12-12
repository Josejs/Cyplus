Imports System.Data
Imports System.Data.SqlClient
Public Class FRMLOGINPINT



    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If (MessageBox.Show("¿DESEA SALIR ?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            MENUPRINCIPAL.Show()

        End If
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Me.ERRP.SetError(TXTUSUARIO, "")
        Me.ERRP.SetError(TXTPASS, "")
        Dim VALIDAR As Boolean = False

        If (TXTUSUARIO.Text.Trim = "") Then
            ERRP.SetError(TXTUSUARIO, "DEBES INTRODUCIR EL NOMBRE DE TU USUARIO")
            VALIDAR = True
        End If
        If (TXTPASS.Text.Trim = "") Then
            ERRP.SetError(TXTPASS, "DEBES INTRODUCIR TU CONTRASEÑA DE ACCESO")
            VALIDAR = True
        End If
        If VALIDAR = True Then
            TXTUSUARIO.Focus()
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("LOG_PINT", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
                    .Parameters.Add("@USUARIO", SqlDbType.NVarChar, 50).Value = TXTUSUARIO.Text
                    .Parameters.Add("@PASS", SqlDbType.NVarChar, 50).Value = TXTPASS.Text
                End With

                DR = COMANDO.ExecuteReader

                If DR.HasRows = 0 Then

                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TXTUSUARIO.Clear()
                    TXTPASS.Clear()
                    TXTUSUARIO.Focus()
                    Exit Sub
                Else
                    MessageBox.Show("USUARIO Y CONTRASEÑA CORRECTA", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TXTUSUARIO.Clear()
                    TXTPASS.Clear()
                    Me.Hide()

                    PINTURA.Show()

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DR.Close()
                DECONECTARBD()

            End Try
        End If
    End Sub
End Class