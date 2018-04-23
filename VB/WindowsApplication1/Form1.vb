Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraScheduler.Xml
Imports DevExpress.XtraScheduler.Commands
Imports DevExpress.XtraScheduler.Native
Imports DevExpress.XtraScheduler.Printing
Imports DevExpress.XtraScheduler.UI
Imports DevExpress.Utils
Imports DevExpress.XtraScheduler.Forms
Imports DevExpress.Services
Imports DevExpress.XtraScheduler.Tools
'using DevExpress.XtraScheduler.iCalendar;
Imports System.IO
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraScheduler.Services
Imports DevExpress.Data.Filtering.Helpers

Namespace WindowsApplication1
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            Dim dt As New DataTable()
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Color", GetType(Color))
            dt.Rows.Add(New Object() { 1, "John", Color.Yellow })
            dt.Rows.Add(New Object() { 2, "Jane", Color.Red })
            dt.Rows.Add(New Object() { 3, "Bob", Color.Green })
            schedulerStorage1.Resources.DataSource = dt
            schedulerStorage1.Resources.Mappings.Id = "ID"
            schedulerStorage1.Resources.Mappings.Caption = "Name"

            filterControl1.SourceControl = schedulerStorage1.Resources
            schedulerControl1.Start = Date.Now
        End Sub


        Private Sub filterControl1_FilterChanged(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.FilterChangedEventArgs) Handles filterControl1.FilterChanged
            schedulerControl1.ActiveView.LayoutChanged()
            '     schedulerControl1.FirstDayOfWeek 
        End Sub

        Private Sub schedulerStorage1_FilterResource(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs) Handles schedulerStorage1.FilterResource
            Dim ee As New ExpressionEvaluator(TypeDescriptor.GetProperties(e.Object), filterControl1.FilterCriteria, False)
            Dim obj As Object = ee.Evaluate(e.Object)
            If obj IsNot Nothing Then
                e.Cancel = Not Convert.ToBoolean(obj)
            End If
        End Sub

        Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButtonItem1.ItemClick
            schedulerControl1.BeginUpdate()
            Dim tic As New TimeIntervalCollection()
            tic.Add(New TimeInterval(Date.Today, Date.Today.AddDays(1)))
            tic.Add(New TimeInterval(Date.Today.AddDays(7), Date.Today.AddDays(8)))
            tic.Add(New TimeInterval(Date.Today.AddDays(14), Date.Today.AddDays(15)))
            schedulerControl1.DayView.SetVisibleIntervals(tic)
            schedulerControl1.EndUpdate()
            'schedulerControl1.FirstDayOfWeek 
            'schedulerControl1.DayView.TopRowTime = DateTime.Now;
            'schedulerControl1.DayView.TimeScale = TimeSpan.FromMinutes(15);
            'schedulerStorage1.GetAppointments(DateTime.Now.AddYears(-1),DateTime.Now.AddYears(1))[0].LabelId = 3;
            'schedulerStorage1.Appointments.Items.FindAll(RequiredApt)[0].LabelId = 3;
            'MessageBox.Show(DevExpress.XtraScheduler.Native.SchedulerTimeZoneHelper.Instance.CurrentTimeZone.Id.ToString());
        End Sub
        Private Shared Function RequiredApt(ByVal apt As Appointment) As Boolean
            'if(apt.Subject == "Test")
            Return True
            'else
            '    return false;
        End Function

        Private Sub schedulerControl1_CustomDrawTimeCell(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs) Handles schedulerControl1.CustomDrawTimeCell
            'TimeCell tc = e.ObjectInfo as TimeCell;
            'if(tc.Interval.Contains(DateTime.Now)) {
            '    tc.Appearance.BackColor = Color.Red;
            '}
        End Sub

        Private Sub schedulerControl1_AppointmentResizing(ByVal sender As Object, ByVal e As AppointmentResizeEventArgs) Handles schedulerControl1.AppointmentResized, schedulerControl1.AppointmentResizing
            If schedulerControl1.ActiveViewType = SchedulerViewType.Day Then

                Dim mousePosition_Renamed As Point = schedulerControl1.PointToClient(Form.MousePosition)
                Dim shi As SchedulerHitInfo = schedulerControl1.ActiveView.ViewInfo.CalcHitInfo(mousePosition_Renamed, True)
                Dim borderPos As Integer = If(e.ResizedSide = ResizedSide.AtStartTime, shi.ViewInfo.Bounds.Y, shi.ViewInfo.Bounds.Y + shi.ViewInfo.Bounds.Height)
                If Math.Abs(mousePosition_Renamed.Y - borderPos) > 1 Then
                    Dim perc As Double = CDbl(mousePosition_Renamed.Y - shi.ViewInfo.Bounds.Y) / CDbl(shi.ViewInfo.Bounds.Height)
                    Dim timetoAdd As TimeSpan = TimeSpan.FromMinutes(e.HitInterval.Duration.TotalMinutes * perc)

                    If e.ResizedSide = ResizedSide.AtStartTime Then
                        e.EditedAppointment.Start = e.HitInterval.Start + timetoAdd
                        e.EditedAppointment.End = e.SourceAppointment.End
                    Else
                        e.EditedAppointment.Start = e.SourceAppointment.Start
                        e.EditedAppointment.End = e.HitInterval.Start + timetoAdd
                    End If
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub schedulerControl1_AppointmentResized(ByVal sender As Object, ByVal e As AppointmentResizeEventArgs)
            e.Allow = True
            e.Handled = True
        End Sub

        Private Sub schedulerControl1_InitAppointmentDisplayText(ByVal sender As Object, ByVal e As AppointmentDisplayTextEventArgs) Handles schedulerControl1.InitAppointmentDisplayText
            e.Text = e.Description
            e.Description = ""
        End Sub

        Private Sub schedulerControl1_CustomDrawResourceHeader(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs) Handles schedulerControl1.CustomDrawResourceHeader

        End Sub

        Private Sub schedulerStorage1_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs) Handles schedulerStorage1.FetchAppointments

        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            MessageBox.Show(TimeZoneInfo.Local.Id)
        End Sub

        Private Sub resourcesCheckedListBoxControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Private Sub schedulerControl1_VisibleIntervalChanged(ByVal sender As Object, ByVal e As EventArgs) Handles schedulerControl1.VisibleIntervalChanged
            AddHandler schedulerControl1.DayView.TopRowTimeChanged, AddressOf DayView_TopRowTimeChanged
        End Sub

        Private Sub DayView_TopRowTimeChanged(ByVal sender As Object, ByVal e As ChangeEventArgs)
            '  throw new Exception("The method or operation is not implemented.");
        End Sub

        Private Sub schedulerControl1_AllowAppointmentResize(ByVal sender As Object, ByVal e As AppointmentOperationEventArgs) Handles schedulerControl1.AllowAppointmentResize

        End Sub
    End Class
End Namespace