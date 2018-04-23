' Developer Express Code Central Example:
' How to resize an appointment without snapping it to time cells
' 
' This example illustrates how to resize an appointment without snapping it to
' timecells.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2341

Imports System
Namespace WindowsApplication1
    Partial Public Class Form1
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

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeScaleYear1 As New DevExpress.XtraScheduler.TimeScaleYear()
            Dim timeScaleQuarter1 As New DevExpress.XtraScheduler.TimeScaleQuarter()
            Dim timeScaleMonth1 As New DevExpress.XtraScheduler.TimeScaleMonth()
            Dim timeScaleWeek1 As New DevExpress.XtraScheduler.TimeScaleWeek()
            Dim timeScaleDay1 As New DevExpress.XtraScheduler.TimeScaleDay()
            Dim timeScaleHour1 As New DevExpress.XtraScheduler.TimeScaleHour()
            Dim timeScaleFixedInterval1 As New DevExpress.XtraScheduler.TimeScaleFixedInterval()
            Dim timeScaleFixedInterval2 As New DevExpress.XtraScheduler.TimeScaleFixedInterval()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Me.button1 = New System.Windows.Forms.Button()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.barManager1 = New DevExpress.XtraBars.BarManager(Me.components)
            Me.bar2 = New DevExpress.XtraBars.Bar()
            Me.barEditItem1 = New DevExpress.XtraBars.BarEditItem()
            Me.repositoryItemDuration1 = New DevExpress.XtraScheduler.UI.RepositoryItemDuration()
            Me.barButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
            Me.bar3 = New DevExpress.XtraBars.Bar()
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.repositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.carSchedulingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.carsDBDataSet_Renamed = New WindowsApplication1.CarsDBDataSet()
            Me.carSchedulingTableAdapter = New WindowsApplication1.CarsDBDataSetTableAdapters.CarSchedulingTableAdapter()
            Me.filterControl1 = New DevExpress.XtraEditors.FilterControl()
            Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemDuration1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.carSchedulingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.carsDBDataSet_Renamed, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(736, 376)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(75, 23)
            Me.button1.TabIndex = 1
            Me.button1.Text = "button1"
            Me.button1.UseVisualStyleBackColor = True
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerControl1.Location = New System.Drawing.Point(296, 24)
            Me.schedulerControl1.MenuManager = Me.barManager1
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Custom
            Me.schedulerControl1.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always
            Me.schedulerControl1.Size = New System.Drawing.Size(559, 375)
            Me.schedulerControl1.Start = New Date(2010, 3, 25, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 2
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.SnapToCellsMode = DevExpress.XtraScheduler.AppointmentSnapToCellsMode.Never
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.TimeDisplayType = DevExpress.XtraScheduler.AppointmentTimeDisplayType.Clock
            Me.schedulerControl1.Views.DayView.ResourcesPerPage = 1
            Me.schedulerControl1.Views.DayView.RowHeight = 30
            timeRuler1.ShowCurrentTime = DevExpress.XtraScheduler.CurrentTimeVisibility.Never
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.DayView.WorkTime.End = System.TimeSpan.Parse("1.00:00:00")
            Me.schedulerControl1.Views.DayView.WorkTime.Start = System.TimeSpan.Parse("00:00:00")
            Me.schedulerControl1.Views.MonthView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never
            Me.schedulerControl1.Views.MonthView.WeekCount = 1
            Me.schedulerControl1.Views.TimelineView.Appearance.ResourceHeaderCaption.Options.UseTextOptions = True
            Me.schedulerControl1.Views.TimelineView.Appearance.ResourceHeaderCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.schedulerControl1.Views.TimelineView.Appearance.ResourceHeaderCaptionLine.Options.UseTextOptions = True
            Me.schedulerControl1.Views.TimelineView.Appearance.ResourceHeaderCaptionLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.ShowRecurrence = False
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = DevExpress.XtraScheduler.AppointmentSnapToCellsMode.Never
            Me.schedulerControl1.Views.TimelineView.DateTimeScrollbarVisible = False
            Me.schedulerControl1.Views.TimelineView.ResourcesPerPage = 2
            timeScaleYear1.Enabled = False
            timeScaleQuarter1.Enabled = False
            timeScaleMonth1.Enabled = False
            timeScaleHour1.Enabled = False
            timeScaleFixedInterval1.DisplayFormat = "H:mm"
            timeScaleFixedInterval1.Value = System.TimeSpan.Parse("12:00:00")
            timeScaleFixedInterval2.Enabled = False
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleYear1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleQuarter1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleMonth1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleWeek1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleDay1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleHour1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleFixedInterval1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleFixedInterval2)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' barManager1
            ' 
            Me.barManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() { Me.bar2, Me.bar3})
            Me.barManager1.DockControls.Add(Me.barDockControlTop)
            Me.barManager1.DockControls.Add(Me.barDockControlBottom)
            Me.barManager1.DockControls.Add(Me.barDockControlLeft)
            Me.barManager1.DockControls.Add(Me.barDockControlRight)
            Me.barManager1.Form = Me
            Me.barManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.barEditItem1, Me.barButtonItem1})
            Me.barManager1.MainMenu = Me.bar2
            Me.barManager1.MaxItemId = 3
            Me.barManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemTextEdit1, Me.repositoryItemDuration1})
            Me.barManager1.StatusBar = Me.bar3
            ' 
            ' bar2
            ' 
            Me.bar2.BarName = "Main menu"
            Me.bar2.DockCol = 0
            Me.bar2.DockRow = 0
            Me.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
            Me.bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { _
                New DevExpress.XtraBars.LinkPersistInfo(Me.barEditItem1), _
                New DevExpress.XtraBars.LinkPersistInfo(Me.barButtonItem1) _
            })
            Me.bar2.OptionsBar.MultiLine = True
            Me.bar2.OptionsBar.UseWholeRow = True
            Me.bar2.Text = "Main menu"
            ' 
            ' barEditItem1
            ' 
            Me.barEditItem1.Caption = "barEditItem1"
            Me.barEditItem1.Edit = Me.repositoryItemDuration1
            Me.barEditItem1.Id = 1
            Me.barEditItem1.Name = "barEditItem1"
            Me.barEditItem1.Width = 150
            ' 
            ' repositoryItemDuration1
            ' 
            Me.repositoryItemDuration1.AutoHeight = False
            Me.repositoryItemDuration1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repositoryItemDuration1.Name = "repositoryItemDuration1"
            ' 
            ' barButtonItem1
            ' 
            Me.barButtonItem1.Caption = "barButtonItem1"
            Me.barButtonItem1.Id = 2
            Me.barButtonItem1.Name = "barButtonItem1"
            ' 
            ' bar3
            ' 
            Me.bar3.BarName = "Status bar"
            Me.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
            Me.bar3.DockCol = 0
            Me.bar3.DockRow = 0
            Me.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
            Me.bar3.OptionsBar.AllowQuickCustomization = False
            Me.bar3.OptionsBar.DrawDragBorder = False
            Me.bar3.OptionsBar.UseWholeRow = True
            Me.bar3.Text = "Status bar"
            ' 
            ' barDockControlTop
            ' 
            Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlTop.Size = New System.Drawing.Size(855, 24)
            ' 
            ' barDockControlBottom
            ' 
            Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.barDockControlBottom.Location = New System.Drawing.Point(0, 589)
            Me.barDockControlBottom.Size = New System.Drawing.Size(855, 22)
            ' 
            ' barDockControlLeft
            ' 
            Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
            Me.barDockControlLeft.Size = New System.Drawing.Size(0, 565)
            ' 
            ' barDockControlRight
            ' 
            Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.barDockControlRight.Location = New System.Drawing.Point(855, 24)
            Me.barDockControlRight.Size = New System.Drawing.Size(0, 565)
            ' 
            ' repositoryItemTextEdit1
            ' 
            Me.repositoryItemTextEdit1.AutoHeight = False
            Me.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1"
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.TimeZoneId = TimeZoneInfo.Utc.Id
            Me.schedulerStorage1.Resources.ColorSaving = DevExpress.XtraScheduler.ColorSavingType.ArgbColor
            ' 
            ' carSchedulingBindingSource
            ' 
            Me.carSchedulingBindingSource.DataMember = "CarScheduling"
            Me.carSchedulingBindingSource.DataSource = Me.carsDBDataSet_Renamed
            ' 
            ' carsDBDataSet
            ' 
            Me.carsDBDataSet_Renamed.DataSetName = "CarsDBDataSet"
            Me.carsDBDataSet_Renamed.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' carSchedulingTableAdapter
            ' 
            Me.carSchedulingTableAdapter.ClearBeforeFill = True
            ' 
            ' filterControl1
            ' 
            Me.filterControl1.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.filterControl1.Dock = System.Windows.Forms.DockStyle.Left
            Me.filterControl1.Location = New System.Drawing.Point(0, 24)
            Me.filterControl1.Name = "filterControl1"
            Me.filterControl1.Size = New System.Drawing.Size(296, 565)
            Me.filterControl1.TabIndex = 7
            Me.filterControl1.Text = "filterControl1"
            ' 
            ' dateNavigator1
            ' 
            Me.dateNavigator1.HotDate = Nothing
            Me.dateNavigator1.Location = New System.Drawing.Point(302, 414)
            Me.dateNavigator1.Name = "dateNavigator1"
            Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
            Me.dateNavigator1.Size = New System.Drawing.Size(541, 175)
            Me.dateNavigator1.TabIndex = 13
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(855, 611)
            Me.Controls.Add(Me.dateNavigator1)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.filterControl1)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemDuration1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.carSchedulingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.carsDBDataSet_Renamed, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private button1 As System.Windows.Forms.Button
        Private WithEvents schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private WithEvents schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private carsDBDataSet_Renamed As CarsDBDataSet
        Private carSchedulingBindingSource As System.Windows.Forms.BindingSource
        Private carSchedulingTableAdapter As WindowsApplication1.CarsDBDataSetTableAdapters.CarSchedulingTableAdapter
        Private barManager1 As DevExpress.XtraBars.BarManager
        Private bar2 As DevExpress.XtraBars.Bar
        Private bar3 As DevExpress.XtraBars.Bar
        Private barDockControlTop As DevExpress.XtraBars.BarDockControl
        Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Private barDockControlRight As DevExpress.XtraBars.BarDockControl
        Private barEditItem1 As DevExpress.XtraBars.BarEditItem
        Private repositoryItemDuration1 As DevExpress.XtraScheduler.UI.RepositoryItemDuration
        Private repositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Private WithEvents barButtonItem1 As DevExpress.XtraBars.BarButtonItem
        Private WithEvents filterControl1 As DevExpress.XtraEditors.FilterControl
        Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    End Class
End Namespace

