Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationManager
Imports System.Deployment.Application

Module CONEXION
    Public CADENA As String
    Public sasa As String
    Public CN As New SqlConnection(ConnectionStrings("OSBL_SYSTEM.My.MySettings.CYPLUSConnectionString1").ConnectionString.ToString)
    Public CN2 As New SqlConnection(ConnectionStrings("OSBL_SYSTEM.My.MySettings.CYPLUSConnectionString1").ConnectionString.ToString)
    Public COMANDO As New SqlCommand
    Public cms As New SqlCommand
    Public ADP As New SqlDataAdapter
    Public DT As New DataTable
    Public DR As SqlDataReader
    Public DS As DataSet
    Public DSS As New DataSet
    Public ODA As New SqlDataAdapter

    Public Sub InstallUpdateSyncWithInfo()

        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then

            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException

            Catch ioe As InvalidOperationException

            End Try

            If (info.UpdateAvailable) Then

                Try
                    AD.Update()

                    Application.Restart()
                Catch dde As DeploymentDownloadException

                End Try

            End If

        End If
    End Sub


    'METODO PARA CONECTAR A LA BD
    Sub CONECTARBD()
        Try
            CN.Open()
            'MessageBox.Show("CONEXION ESTABLECIDA", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub CONECTARBD2()
        Try
            CN2.Open()
            '  MessageBox.Show("CONEXION ESTABLECIDA", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'METODO DESCONECTAR BD
    Sub DECONECTARBD()
        Try
            CN.Close()
            '  MessageBox.Show("CONEXION CERRADA", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DECONECTARBD2()
        Try
            CN2.Close()
            '  MessageBox.Show("CONEXION CERRADA", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
 

End Module
