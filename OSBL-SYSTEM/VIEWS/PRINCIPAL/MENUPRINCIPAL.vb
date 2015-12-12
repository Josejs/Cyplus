Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Imports System.Deployment.Application

Public Class MENUPRINCIPAL



    Private Sub MTLISTAISO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTLISTAISO.Click
        'BASICDATA.Show()
        Me.Hide()
        FRMINICIOPRODUCCION.Show()

    End Sub



    Private Sub MetroTileItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem5.Click
        LoginAlmacen.Show()

        'ENTRADA_SALIDAS.Show()
        Me.Hide()
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR SESION EN EL SISTEMA?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            Application.ExitThread()
            Application.Exit()

            'FRMINICIPRINCIPAL.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub MetroTileItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        JuntsIsometric.Show()

    End Sub

    Private Sub ACERCADEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACERCADEToolStripMenuItem.Click
        ACERCA.Show()
    End Sub

    Private Sub MetroTileItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem36.Click
        CONECTARBD()
    End Sub

    Private Sub MetroTileItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem6.Click
        BACKUP.Show()
        '  Me.Hide()
        ' PANEL_CONTROL.Show()

    End Sub


    Private Sub MetroTileItem7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem7.Click
        Me.Hide()
        FRMLOGINPINT.Show()


    End Sub

    Private Sub MENUPRINCIPAL_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Dim messageBoxVB As New System.Text.StringBuilder()
        '  messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
        ' messageBoxVB.AppendLine()
        ' messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
        ' messageBoxVB.AppendLine()
        ' MessageBox.Show(messageBoxVB.ToString(), "FormClosing Event")


        If e.CloseReason = CloseReason.UserClosing Then

            If (MessageBox.Show("¿DESEA CERRAR EL SISTEMA?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then

                Application.ExitThread()
                Application.Exit()
            Else
                e.Cancel = True

            End If
        End If

    End Sub

    Private Sub MENUPRINCIPAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ToastNotification.Show(Me, "BIENVENIDO A CYPLUS SYTEM", My.Resources.descarga, 6000, eToastPosition.TopRight)
        '  InstallUpdateSyncWithInfo()


    End Sub

 
    Private Sub MTDIAMETRO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTDIAMETRO.Click
        Me.Hide()
        FRMINICIOCALID.Show()
        'CALIDADFR.Show()

    End Sub

 
  


  
 
    Private Sub MTESPECIFICACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTESPECIFICACION.Click
        DETALLES_SABANA.Show()
    End Sub

    Private Sub MetroTileItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem30.Click
        DETALLES_SABANA.Show()
    End Sub



End Class