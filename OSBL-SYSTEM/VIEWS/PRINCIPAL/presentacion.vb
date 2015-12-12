
Public NotInheritable Class presentacion

    'TODO: Este formulario se puede establecer fácilmente como pantalla de presentación para la aplicación desde la ficha "Aplicación"
    '  del Diseñador de proyectos ("Propiedades" bajo el menú "Proyecto").


    Private Sub presentacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = True
        Timer1.Interval = 5
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ProgressBar1.Value = ProgressBar1.Value + 1
        Label1.Text = "CARGANDO  " + ProgressBar1.Value.ToString + "%"


        If ProgressBar1.Value >= 100 Then

            Timer1.Enabled = False

            Me.Hide()
            MENUPRINCIPAL.Show()
            Timer1.Stop()
            ProgressBar1.Value = 0
        End If

    End Sub

   
End Class
