' Developer Express Code Central Example:
' How to resize an appointment without snapping it to time cells
' 
' This example illustrates how to resize an appointment without snapping it to
' timecells.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2341

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraScheduler

Namespace Lane_Management
    Public Class Minutes1Scale
        Inherits LessThanADayTimeScale

        Private Const myScaleValue As Integer = 1
        Public Sub New()
            MyBase.New(myScaleValue)
        End Sub
        Public Sub New(ByVal ScaleValue As Integer)
            MyBase.New(ScaleValue)

        End Sub


        Protected Overrides ReadOnly Property DefaultDisplayFormat() As String
            Get
                Return "h:mm tt"
            End Get
            'get { return "HH:mm"; }
        End Property

        Protected Overrides ReadOnly Property DefaultMenuCaption() As String
            Get
                Return "1Minutes"
            End Get
        End Property

    End Class
End Namespace
