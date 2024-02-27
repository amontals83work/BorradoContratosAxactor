Public Class Form1
    Private mc As New MCCommand
    Private openFileDialog As New OpenFileDialog

    Public Sub Form1()
        InitializeComponent()
        CenterToScreen()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Borrar()
    End Sub

    Private Sub Borrar()

        Dim idContrato As String = txtIdContrato.Text.Trim

        Try
            If IsNumeric(idContrato) Then
                mc.CommandText = "SELECT COUNT(*) FROM AXACONTRATOS WHERE idcontratoald = " & idContrato.ToString & ""
                Dim count As Integer = mc.ExecuteScalar()

                If count > 0 Then
                    mc.CommandText = "SELECT fechaBaja FROM AXACONTRATOS WHERE idcontratoald = " & idContrato.ToString & ""
                    Dim fechaBaja As String = mc.ExecuteScalar().ToString
                    If fechaBaja = "" Then
                        mc.CommandText = "UPDATE AXACONTRATOS SET fechaBaja = GETDATE() WHERE idcontratoald = " & idContrato.ToString & ""
                        mc.ExecuteNonQuery()
                        MessageBox.Show("BORRADO: " & idContrato.ToString)
                    Else
                        MessageBox.Show("LA BAJA DE " & idContrato.ToString & " FUE HECHA EL " & fechaBaja)
                    End If
                Else
                    MessageBox.Show("NO EXISTE: " & idContrato.ToString)
                End If
            Else
                MessageBox.Show("NO ES UN NÚMERO: " & idContrato.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR al procesar la solicitud: " & vbCrLf & ex.Message)
        End Try

    End Sub

End Class