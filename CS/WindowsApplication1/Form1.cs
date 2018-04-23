using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Xml;
using DevExpress.XtraScheduler.Commands;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.Printing;
using DevExpress.XtraScheduler.UI;
using DevExpress.Utils;
using DevExpress.XtraScheduler.Forms;
using DevExpress.Services;
using DevExpress.XtraScheduler.Tools;
//using DevExpress.XtraScheduler.iCalendar;
using System.IO;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler.Services;
using DevExpress.Data.Filtering.Helpers;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Color", typeof(Color));
            dt.Rows.Add(new object[] { 1, "John", Color.Yellow });
            dt.Rows.Add(new object[] { 2, "Jane", Color.Red });
            dt.Rows.Add(new object[] { 3, "Bob", Color.Green });
            schedulerStorage1.Resources.DataSource = dt;
            schedulerStorage1.Resources.Mappings.Id = "ID";
            schedulerStorage1.Resources.Mappings.Caption = "Name";

            filterControl1.SourceControl = schedulerStorage1.Resources;
            schedulerControl1.Start = DateTime.Now;
        }


        private void filterControl1_FilterChanged(object sender, DevExpress.XtraEditors.FilterChangedEventArgs e)
        {
            schedulerControl1.ActiveView.LayoutChanged();
            //     schedulerControl1.FirstDayOfWeek 
        }

        private void schedulerStorage1_FilterResource(object sender, PersistentObjectCancelEventArgs e)
        {
            ExpressionEvaluator ee = new ExpressionEvaluator(TypeDescriptor.GetProperties(e.Object), filterControl1.FilterCriteria, false);
            object obj = ee.Evaluate(e.Object);
            if (obj != null)
                e.Cancel = !Convert.ToBoolean(obj);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            schedulerControl1.BeginUpdate();
            TimeIntervalCollection tic = new TimeIntervalCollection();
            tic.Add(new TimeInterval(DateTime.Today, DateTime.Today.AddDays(1)));
            tic.Add(new TimeInterval(DateTime.Today.AddDays(7), DateTime.Today.AddDays(8)));
            tic.Add(new TimeInterval(DateTime.Today.AddDays(14), DateTime.Today.AddDays(15)));
            schedulerControl1.DayView.SetVisibleIntervals(tic);
            schedulerControl1.EndUpdate();
            //schedulerControl1.FirstDayOfWeek 
            //schedulerControl1.DayView.TopRowTime = DateTime.Now;
            //schedulerControl1.DayView.TimeScale = TimeSpan.FromMinutes(15);
            //schedulerStorage1.GetAppointments(DateTime.Now.AddYears(-1),DateTime.Now.AddYears(1))[0].LabelId = 3;
            //schedulerStorage1.Appointments.Items.FindAll(RequiredApt)[0].LabelId = 3;
            //MessageBox.Show(DevExpress.XtraScheduler.Native.SchedulerTimeZoneHelper.Instance.CurrentTimeZone.Id.ToString());
        }
        private static bool RequiredApt(Appointment apt)
        {
            //if(apt.Subject == "Test")
            return true;
            //else
            //    return false;
        }

        private void schedulerControl1_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            //TimeCell tc = e.ObjectInfo as TimeCell;
            //if(tc.Interval.Contains(DateTime.Now)) {
            //    tc.Appearance.BackColor = Color.Red;
            //}
        }

        private void schedulerControl1_AppointmentResizing(object sender, AppointmentResizeEventArgs e)
        {
            if (schedulerControl1.ActiveViewType == SchedulerViewType.Day)
            {
                Point mousePosition = schedulerControl1.PointToClient(Form.MousePosition);
                SchedulerHitInfo shi = schedulerControl1.ActiveView.ViewInfo.CalcHitInfo(mousePosition, true);
                int borderPos = e.ResizedSide == ResizedSide.AtStartTime ? shi.ViewInfo.Bounds.Y : shi.ViewInfo.Bounds.Y + shi.ViewInfo.Bounds.Height;
                if (Math.Abs(mousePosition.Y - borderPos) > 1)
                {
                    double perc = (double)(mousePosition.Y - shi.ViewInfo.Bounds.Y) / (double)shi.ViewInfo.Bounds.Height;
                    TimeSpan timetoAdd = TimeSpan.FromMinutes(e.HitInterval.Duration.TotalMinutes * perc);

                    if (e.ResizedSide == ResizedSide.AtStartTime)
                    {
                        e.EditedAppointment.Start = e.HitInterval.Start + timetoAdd;
                        e.EditedAppointment.End = e.SourceAppointment.End;
                    }
                    else
                    {
                        e.EditedAppointment.Start = e.SourceAppointment.Start;
                        e.EditedAppointment.End = e.HitInterval.Start + timetoAdd;
                    }
                    e.Handled = true;
                }
            }
        }

        private void schedulerControl1_AppointmentResized(object sender, AppointmentResizeEventArgs e)
        {
            e.Allow = true;
            e.Handled = true;
        }

        private void schedulerControl1_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            e.Text = e.Description;
            e.Description = "";
        }

        private void schedulerControl1_CustomDrawResourceHeader(object sender, CustomDrawObjectEventArgs e)
        {

        }

        private void schedulerStorage1_FetchAppointments(object sender, FetchAppointmentsEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(TimeZoneInfo.Local.Id);
        }

        private void resourcesCheckedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void schedulerControl1_VisibleIntervalChanged(object sender, EventArgs e)
        {
            schedulerControl1.DayView.TopRowTimeChanged += new ChangeEventHandler(DayView_TopRowTimeChanged);
        }

        void DayView_TopRowTimeChanged(object sender, ChangeEventArgs e)
        {
            //  throw new Exception("The method or operation is not implemented.");
        }

        private void schedulerControl1_AllowAppointmentResize(object sender, AppointmentOperationEventArgs e)
        {

        }
    }
}