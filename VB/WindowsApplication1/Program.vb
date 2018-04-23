Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WindowsApplication1
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("de-DE")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de-DE")
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End Sub
    End Class
End Namespace