Imports System.Data
Imports System.Data.SqlClient
Public Class FRMINICIPRINCIPAL

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If (MessageBox.Show("¿DESEA SALIR COMPLETAMENTE DEL SISTEMA?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            BASICDATA.SwitchButton1.Value = True
            Me.Hide()
        End If
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Me.EP.SetError(TXTUSUARIO, "")
        Me.EP.SetError(TXTPASS, "")
        Dim VALIDAR As Boolean = False
        If (TXTUSUARIO.Text.Trim = "") Then
            EP.SetError(TXTUSUARIO, "DEBES INTRODUCIR EL NOMBRE DE TU USUARIO")
            VALIDAR = True
        End If
        If (TXTPASS.Text.Trim = "") Then
            EP.SetError(TXTPASS, "DEBES INTRODUCIR TU CONTRASEÑA DE ACCESO")
            VALIDAR = True
        End If
        If VALIDAR = True Then
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("LOGIN_SI", CN)
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

                    BASICDATA.PENLACE.Enabled = True
                    BASICDATA.PACABADO.Enabled = True
                    BASICDATA.PLIBERACION.Enabled = True
                    BASICDATA.PCOMPAÑIA.Enabled = True
                    BASICDATA.PAREA.Enabled = True
                    BASICDATA.POBSERVACION.Enabled = True
                    BASICDATA.PNUMEROREP.Enabled = True
                    BASICDATA.PNOORDEN.Enabled = True
                    BASICDATA.PFECHAORDEN.Enabled = True
                    BASICDATA.PCANTIDAD.Enabled = True
                    BASICDATA.PNOEMBARQUE.Enabled = True
                    BASICDATA.PFECHAEMBARQUE.Enabled = True
                    BASICDATA.PSAND.Enabled = True
                    BASICDATA.TXTFECHAPACKING.Enabled = True

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DR.Close()
                DECONECTARBD()

            End Try
        End If

    End Sub


    Private Sub FRMINICIPRINCIPAL_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
