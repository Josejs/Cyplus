Imports System.Data
Imports System.Data.SqlClient
Public Class HOJAISO
#Region "METODOS"
    Sub LIMPIAR()
        TXTISOMETRICO.Clear()
        TXTXHOJA.Clear()
        TXTXISOMETRICO.Clear()
        TXTXTOTAL.Clear()
        TXTID.Clear()
    End Sub
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
#End Region
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA3.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA3.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        EP.SetError(TXTXISOMETRICO, "")
        EP.SetError(TXTXHOJA, "")
        EP.SetError(TXTXTOTAL, "")
        Dim VALIDA As Boolean = False

        If (TXTXISOMETRICO.Text.Trim = "") Then
            EP.SetError(TXTXISOMETRICO, "DEBE ASIGNAR EL ISOMETRICO")
            VALIDA = True
        End If

        If (TXTXHOJA.Text.Trim = "") Then
            EP.SetError(TXTXHOJA, "DEBE ASIGNAR LA HOJA")
            VALIDA = True
        End If

        If (TXTXTOTAL.Text.Trim = "") Then
            EP.SetError(TXTXTOTAL, "DEBE ASIGNAR EL TOTAL DE HOJAS")
            VALIDA = True
        End If

        If (VALIDA = True) Then

            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Try
                CONECTARBD()
                COMANDO = New SqlCommand("INS_HOJA", CN)
                COMANDO.CommandType = CommandType.StoredProcedure
                With COMANDO
                    .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTXISOMETRICO.Text
                    .Parameters.Add("@HOJA", SqlDbType.Int).Value = TXTXHOJA.Text
                    .Parameters.Add("@TOT_HOJA", SqlDbType.Int).Value = TXTXTOTAL.Text
                End With
                COMANDO.ExecuteNonQuery()
                MessageBox.Show("LA HOJA FUE ASIGNADA CORRECTAMENTE AL ISOMETRICO", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LIMPIAR()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LIMPIAR()
            Finally
                DECONECTARBD()

            End Try
        End If



    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        LIMPIAR()
    End Sub

    Private Sub HOJAISO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            LlamarDatos("SELECT * FROM HOJA_ISOM")
            DT = New DataTable
            ADP.Fill(DT)
            DataGridView1.DataSource = DT
           
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Label5.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub TXTISOMETRICO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTISOMETRICO.TextChanged
        If RadioButton1.Checked Then
            LlamarDatos("SELECT * FROM HOJA_ISOM WHERE NO_ISOMETRICO LIKE '%" & TXTISOMETRICO.Text & "%' ORDER BY NO_ISOMETRICO ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label5.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub TXTXISOMETRICO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTXISOMETRICO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select NUM_ISO FROM TBL_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("NUM_ISO").ToString())
            Next
            TXTXISOMETRICO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTXISOMETRICO.AutoCompleteCustomSource = col
            TXTXISOMETRICO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            TXTID.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TXTXISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TXTXHOJA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TXTXTOTAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub BTNEDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEDITAR.Click
        EP.SetError(TXTID, "")
        Dim VALIDA As Boolean = False

        If (TXTID.Text.Trim = "") Then
            EP.SetError(TXTID, "DEBE ESPECIFICAR UN IDENTIFICADOR")
            VALIDA = True
        End If
        If (VALIDA = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DE LA HOJA?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("EDIT_HOJA", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure
                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTID.Text)
                        .Parameters.Add("@ISOMETRICO", SqlDbType.Int).Value = TXTXISOMETRICO.Text
                        .Parameters.Add("@HOJA", SqlDbType.Int).Value = TXTXHOJA.Text
                        .Parameters.Add("@TOT_HOJA", SqlDbType.Int).Value = TXTXTOTAL.Text
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("EL REGISTRO FUE MODIFICADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMPIAR()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If



    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        EP.SetError(TXTID, "")
        Dim VALIDA As Boolean = False

        If (TXTID.Text.Trim = "") Then
            EP.SetError(TXTID, "DEBE ESPECIFICAR UN IDENTIFICADOR")
            VALIDA = True
        End If
        If (VALIDA = True) Then
            MessageBox.Show("FALTA INFORMACION POR INGRESAR", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (MessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DE LA HOJA?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            Else
                Try
                    CONECTARBD()
                    COMANDO = New SqlCommand("ELIM_HOJA", CN)
                    COMANDO.CommandType = CommandType.StoredProcedure
                    With COMANDO
                        .Parameters.AddWithValue("@ID", TXTID.Text)
                    End With
                    COMANDO.ExecuteNonQuery()
                    MessageBox.Show("EL REGISTRO FUE ELIMINADO EXITOSAMENTE", "CYPLUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LIMPIAR()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DECONECTARBD()

                End Try
            End If
        End If

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try

            LlamarDatos("SELECT * FROM HOJA_ISOM")
            DT = New DataTable
            ADP.Fill(DT)
            DataGridView1.DataSource = DT

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Label5.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub
End Class