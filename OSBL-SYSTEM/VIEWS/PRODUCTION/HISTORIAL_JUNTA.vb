Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar

Public Class HISTORIAL_JUNTA
    Dim INDICADOR As Integer
    Sub CLEAN()
        IDJUNTA.Clear()
        cbserviciojunta.ResetText()

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
     
        TXTPLGSTD.Clear()

    End Sub
    Sub VALIDAR_JUNTA()
        Try
            INDICADOR = 0
            CONECTARBD()
            COMANDO = New SqlCommand("SEL_VAL_JUNTA2", CN)
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
    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub BUSCARUNAJUNTAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BUSCARUNAJUNTAToolStripMenuItem.Click
        HIS_JUNTA.Show()

    End Sub

    Private Sub ButtonX14_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX14.Click
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
                VALIDAR_JUNTA()
                CONECTARBD()
                COMANDO = New SqlCommand("INS_HITORIAL_JUNTA", CN)
                COMANDO.CommandType = CommandType.StoredProcedure

                With COMANDO
             
                    .Parameters.Add("@NUMERO_ISO", SqlDbType.NVarChar, 50).Value = JUNTANUMISO.Text
                    .Parameters.Add("@NUMERO_SPOOL", SqlDbType.NVarChar, 250).Value = JUNTASPOOL.Text
                    .Parameters.Add("@LINEA", SqlDbType.NVarChar, 50).Value = CBLINEA.Text


                    .Parameters.Add("@HOJA", SqlDbType.NVarChar, 50).Value = JUNTAHOJA.Text
                    .Parameters.Add("@REVISION", SqlDbType.NVarChar, 50).Value = JUNTAREVISION.Text
                    .Parameters.Add("@JUNTA", SqlDbType.Int).Value = JUNTAJUNTA.Text
                    .Parameters.Add("@TIPO1", SqlDbType.NVarChar, 50).Value = JUNTATIPO1.Text
                    .Parameters.Add("@TIPO2", SqlDbType.NVarChar, 50).Value = JUNTATIPO2.Text

                    .Parameters.Add("@DIAMETRO1", SqlDbType.NVarChar, 50).Value = JUNTADIAM1.Text
                    .Parameters.Add("@DIAMETRO2", SqlDbType.NVarChar, 50).Value = JUNTADIAM2.Text
                    .Parameters.Add("@TIPO_JUNTA", SqlDbType.NVarChar, 50).Value = JUNTATIPOJUNTA.Text
                    .Parameters.Add("@CAMP_TALLER", SqlDbType.NVarChar, 50).Value = JUNTACAMPOTALLER.Text
                    .Parameters.Add("@SERVICIO", SqlDbType.NVarChar, 255).Value = cbserviciojunta.Text
                    .Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar, 250).Value = JUNTAESPECIFICACION.Text
                    .Parameters.Add("@DIAMETRO_PRINCIPAL", SqlDbType.Float, 53).Value = JUNTADIAMJUNTA.Text
                    .Parameters.Add("@COD_MAT1", SqlDbType.NVarChar, 250).Value = JUNTAID1.Text
                    .Parameters.Add("@DESCRIP1", SqlDbType.NVarChar, 250).Value = JUNTADESC1.Text
                    .Parameters.Add("@COLADA1", SqlDbType.NVarChar, 250).Value = JUNTACOLADA1.Text
                    .Parameters.Add("@COD_MAT2", SqlDbType.NVarChar, 250).Value = JUNTAID2.Text
                    .Parameters.Add("@DESCRIP2", SqlDbType.NVarChar, 250).Value = JUNTADESC2.Text
                    .Parameters.Add("@COLADA2", SqlDbType.NVarChar, 250).Value = JUNTACOLADA2.Text
                    .Parameters.Add("@PULGADA_STD", SqlDbType.Float, 53).Value = TXTPLGSTD.Text
                End With

                Try
                    If (INDICADOR = 1) Then
                        MessageBox.Show("NO SE PUEDE GUARDAR ESTA JUNTA CUENTA CON LOS MISMOS DATOS DE UN REGISTRO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        If (MessageBox.Show("¿DESEA REGISTRAR DE TODAS FORMAS?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                            Exit Sub
                            DECONECTARBD()

                        Else
                            COMANDO.ExecuteNonQuery()
                            MessageBox.Show("JUNTA DE ISOMETRICO ASIGNADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                     

                        End If
                        DECONECTARBD()
                    Else
                        COMANDO.ExecuteNonQuery()
                        MessageBox.Show("JUNTA DE ISOMETRICO ASIGNADA CORRECTAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try


            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'CLEAN()
            Finally
                DECONECTARBD()

            End Try
        End If
    End Sub

    Private Sub ButtonX15_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX15.Click
        CLEAN()

    End Sub

    Private Sub ButtonX17_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX17.Click
        REGISTROS_HISTORIAL.Show()

    End Sub
End Class