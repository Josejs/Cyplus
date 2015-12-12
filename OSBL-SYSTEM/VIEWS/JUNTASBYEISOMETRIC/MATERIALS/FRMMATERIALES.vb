Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Public Class FRMMATERIALES
    Dim INDICADOR As Integer


    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA SALIR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            ' JuntsIsometric.Show()

        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
       
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click

    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
       



    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        
    End Sub

    Private Sub BTNVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVER.Click

    End Sub


    Private Sub MATCODIGO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSEARCH.Click
     

    End Sub

    Private Sub MATISOMETRICO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATISOMETRICO.TextChanged
       


    End Sub

 
    Private Sub LIBRERIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBRERIAToolStripMenuItem.Click

    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

  
   

    Private Sub MATCOLADA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATCOLADA.TextChanged
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      

    End Sub

    Private Sub FRMMATERIALES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ALMACENENTRADAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALMACENENTRADAToolStripMenuItem.Click
        REGISTROALMACEN.Show()
    End Sub

    Private Sub MATCODIGO_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATCODIGO.TextChanged
        
    End Sub

    Private Sub CLEAN()
        Throw New NotImplementedException
    End Sub

    Private Sub MATFABRICANTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATFABRICANTE.TextChanged

    End Sub
End Class