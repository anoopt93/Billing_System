Imports System.Data.OleDb

Public Class Login
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim da1 As OleDbDataAdapter
    Dim con As System.Data.OleDb.OleDbConnection
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub btlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btlogin.Click
    
        If tbuser.Text = "admin" And tbpass.Text = "admin" Then
            Home.Show()
            'Me.Close()
            tbuser.Clear()
            tbpass.Clear()
        Else
            Try

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "SELECT * FROM [Staff] WHERE [Sname] = '" & tbuser.Text & "' AND [Password]='" & tbpass.Text & "'"
            Dim cmd As New OleDbCommand(str, myConnection)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            ' the following variable is hold true if user is found, and false if user is not found
            Dim userFound As Boolean = False
            ' the following variables will hold the user first and last name if found.
            Dim Sname As String = ""
            'if found:
            While dr.Read
                userFound = True
                Sname = dr("Sname").ToString
            End While
            'checking the result
            If userFound = True Then
                Invoice.Show()
                Invoice.Label5.Text = Sname
            Else
                MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "Invalid Login")
            End If
                myConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        tbuser.Clear()
        tbpass.Clear()


    End Sub

    Private Sub btreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btreset.Click
        Form1.Close()
        Me.Close()
    End Sub

    Private Sub tbpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbpass.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            'SendKeys.Send("{TAB}")
            'e.Handled = True

            If tbuser.Text = "admin" And tbpass.Text = "admin" Then
                Home.Show()
                'Me.Close()
                tbuser.Clear()
                tbpass.Clear()
            Else
                Try

                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                    myConnection.ConnectionString = connString
                    myConnection.Open()
                    Dim str As String
                    str = "SELECT * FROM [Staff] WHERE [Sname] = '" & tbuser.Text & "' AND [Password]='" & tbpass.Text & "'"
                    Dim cmd As New OleDbCommand(str, myConnection)
                    Dim dr As OleDbDataReader = cmd.ExecuteReader
                    ' the following variable is hold true if user is found, and false if user is not found
                    Dim userFound As Boolean = False
                    ' the following variables will hold the user first and last name if found.
                    Dim Sname As String = ""
                    'if found:
                    While dr.Read
                        userFound = True
                        Sname = dr("Sname").ToString
                    End While
                    'checking the result
                    If userFound = True Then
                        Invoice.Show()
                        Invoice.Label5.Text = Sname
                    Else
                        MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "Invalid Login")
                    End If
                    myConnection.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            tbuser.Clear()
            tbpass.Clear()

        End If
    End Sub

    Private Sub tbuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbuser.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
End Class
