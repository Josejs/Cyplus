Imports System.Data
Imports System.Data.SqlClient

Public Class FRMINICIOADMIN

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If (MessageBox.Show("¿DESEA SALIR ?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            MENUPRINCIPAL.Show()

        End If
    End Sub
End Class