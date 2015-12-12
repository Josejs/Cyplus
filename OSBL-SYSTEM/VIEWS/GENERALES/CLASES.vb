Imports System.Data
Imports System.Data.SqlClient

Public Class CLASES
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
   


    Private Sub CLASESBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.CLASESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CYPLUSDataSet)

    End Sub

    Private Sub CLASES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CYPLUSDataSet.CLASES' Puede moverla o quitarla según sea necesario.
        Me.CLASESTableAdapter.Fill(Me.CYPLUSDataSet.CLASES)
        ' OBT_PORCENTAJE_RX()

    End Sub


   
End Class