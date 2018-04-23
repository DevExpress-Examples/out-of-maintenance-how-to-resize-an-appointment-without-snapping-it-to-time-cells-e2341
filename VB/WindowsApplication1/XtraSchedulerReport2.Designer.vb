' Developer Express Code Central Example:
' How to resize an appointment without snapping it to time cells
' 
' This example illustrates how to resize an appointment without snapping it to
' timecells.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2341

Namespace WindowsApplication1
    Partial Public Class XtraSchedulerReport2
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.Detail })
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()
        End Sub

        #End Region

        Private Detail As DevExpress.XtraReports.UI.DetailBand
    End Class
End Namespace
