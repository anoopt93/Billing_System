Imports System.Data.OleDb

Public Class Home
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim da1 As OleDbDataAdapter
    Dim cmd2 As OleDbCommandBuilder
    Dim con As System.Data.OleDb.OleDbConnection

    Private Sub btexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btexit.Click
      
        Select Case MsgBox("Are you sure? you want to Exit?", MsgBoxStyle.YesNo, "Exit?")

            Case MsgBoxResult.Yes

                Me.Close()
                Form1.Close()

            Case MsgBoxResult.No

        End Select
    End Sub

    Private Sub btstock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btstock.Click
        Dim x As Stock1 = New Stock1
        x.Show()

    End Sub

    Private Sub btreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btreport.Click
        Dim r As New Report
        r.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        StaffReg.Show()

    End Sub

    Private Sub btInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInvoice.Click
        Invoice.Show()
        Invoice.Label5.Text = "Admin"
    End Sub

    Private Sub btTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTax.Click

        If tbTax.Text = "" Then
            MsgBox("Enter Tax %  ", MsgBoxStyle.Information)
        Else

            'Update tax% into Tax table
            Select Case MsgBox("Are you sure? you want to Edit the Tax% ?", MsgBoxStyle.YesNo, "Edit Tax")

                Case MsgBoxResult.Yes
                    Try

                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                        myConnection.ConnectionString = connString
                        myConnection.Open()
                        Dim str As String
                        str = "UPDATE Tax SET tax ='" & tbTax.Text & "' "
                        Dim cmd2 As New OleDbCommand(str, myConnection)
                        cmd2.ExecuteNonQuery()
                        cmd2.Dispose()
                        myConnection.Close()

                    Catch ex As Exception

                        MsgBox(ex.Message)

                    End Try
                    tbTax.Clear()
                    MsgBox("Tax updated successfully ", MsgBoxStyle.OkOnly, "Success")

                    Dim f1 As New Home
                    f1.Show()
                    Me.Close()

                Case MsgBoxResult.No

            End Select
        End If
    End Sub

    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load Tax value from Table Tax
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "SELECT tax FROM Tax "
            Dim cmd2 As New OleDbCommand(str, myConnection)
            Dim dr1 As OleDbDataReader = cmd2.ExecuteReader
            If dr1.Read = True Then
                Me.LabelTax.Text = dr1.Item(0)
            End If
            myConnection.Close()
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        'Load Discount% value from Table Discount
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "SELECT discount FROM Discount "
            Dim cmd2 As New OleDbCommand(str, myConnection)
            Dim dr1 As OleDbDataReader = cmd2.ExecuteReader
            If dr1.Read = True Then
                Me.LabelDisc.Text = dr1.Item(0)
            End If
            myConnection.Close()
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDiscount.Click
        If tbDisc.Text = "" Then
            MsgBox("Enter Discount %  ", MsgBoxStyle.Information)
        Else

            'Update discount % into Discount table
            Select Case MsgBox("Are you sure? you want to Edit the Discount% ?", MsgBoxStyle.YesNo, "Edit Discount")

                Case MsgBoxResult.Yes
                    Try

                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                        myConnection.ConnectionString = connString
                        myConnection.Open()
                        Dim str As String
                        str = "UPDATE Discount SET discount ='" & tbDisc.Text & "' "
                        Dim cmd2 As New OleDbCommand(str, myConnection)
                        cmd2.ExecuteNonQuery()
                        cmd2.Dispose()
                        myConnection.Close()

                    Catch ex As Exception

                        MsgBox(ex.Message)

                    End Try
                    tbDisc.Clear()
                    MsgBox("Discount updated successfully ", MsgBoxStyle.OkOnly, "Success")

                    Dim f1 As New Home
                    f1.Show()
                    Me.Close()
                Case MsgBoxResult.No

            End Select
        End If
    End Sub

    Private Sub tbTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTax.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub tbDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDisc.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub
End Class