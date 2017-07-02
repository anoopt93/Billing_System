Public Class MyPanel
    Inherits System.Windows.Forms.Panel

    Public Sub New()
        Me.BorderStyle = Windows.Forms.BorderStyle.None
    End Sub

    Private bWidth As Integer
    Public Property BorderWidth() As Integer
        Get
            Return Me.bWidth
        End Get
        Set(ByVal value As Integer)
            Me.bWidth = Math.Abs(value)
            Me.Refresh()
        End Set
    End Property

    Private bColor As Color
    Public Property BorderColor() As Color
        Get
            Return Me.bColor
        End Get
        Set(ByVal value As Color)
            Me.bColor = value
            Me.Refresh()
        End Set
    End Property

    Public Overridable Sub MyPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawRectangle(New Pen(Me.bColor, Me.bWidth), Me.ClientRectangle)

    End Sub
End Class
