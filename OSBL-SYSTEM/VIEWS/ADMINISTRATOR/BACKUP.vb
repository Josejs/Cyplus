Imports System.Data
Imports System.Data.SqlClient
Public Class BACKUP

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA3.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA3.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try
            CONECTARBD()
            Dim NOMB As String = (Date.Today.Day.ToString & "-" & Date.Today.Month.ToString & "-" & Date.Today.Year.ToString & "-" & Date.Now.Hour.ToString & "-" & Date.Now.Minute.ToString & "-" & Date.Now.Second.ToString & "COPIA CYPLUS")
            'Dim COANDO As String = "BACKUP DATABASE [CYPLUS] TO  DISK = N'C:\BACKUPS\" & NOMB & "' WITH NOFORMAT, NOINIT,  NAME = N'CYPLUS-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
            Dim COANDO As String = " BACKUP DATABASE [CYPLUS] TO  DISK = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\" & NOMB & ".bak ' WITH NOFORMAT, NOINIT,  NAME = N'CYPLUS-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
            COMANDO = New SqlCommand(COANDO, CN)

            COMANDO.ExecuteNonQuery()
            MessageBox.Show("La Copia de Seguridad de ha realizado Correctamente", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        capturaestimacion.Show()
    End Sub
End Class