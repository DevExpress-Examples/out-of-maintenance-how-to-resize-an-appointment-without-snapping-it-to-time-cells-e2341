Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraScheduler

Namespace Lane_Management
	Public MustInherit Class LessThanADayTimeScale
		Inherits TimeScale
		' Holds the scale increment, in minutes.
		Private scaleValue As Integer
		Private scaleValueTime As TimeSpan

		Public Sub New(ByVal ScaleValue As Integer)
			Me.scaleValue = ScaleValue
			scaleValueTime = TimeSpan.FromMinutes(ScaleValue)
		End Sub
		Protected Sub New()

		End Sub
		Protected Sub New(ByVal displayName As String)
			MyBase.New(displayName)

		End Sub
		Protected Sub New(ByVal displayName As String, ByVal menuCaption As String)
			MyBase.New(displayName, menuCaption)

		End Sub

		' Gets the start of the first time interval.
		Protected Overridable Function FirstIntervalStart(ByVal [date] As DateTime) As Integer
			'switch (date.DayOfWeek)
			'{
			'    case DayOfWeek.Saturday:
			'        return 9 * 60;
			'    case DayOfWeek.Sunday:
			'        return 10 * 60;
			'    default:
			'        return 9 * 60;
			'}
			Return 0
		End Function

		' Gets the start of the last time interval.
		Protected Overridable Function LastIntervalStart(ByVal [date] As DateTime) As Integer
			'switch (date.DayOfWeek)
			'{
			'    case DayOfWeek.Saturday:
			'        return 24 * 60 - scaleValue;
			'    case DayOfWeek.Sunday:
			'        return 22 * 60 - scaleValue;
			'    default:
			'        return 24 * 60 - scaleValue;
			'}
			Return 24 * 60 - scaleValue
		End Function

		' Gets the value used to order the scales.
		Protected Overrides ReadOnly Property SortingWeight() As TimeSpan
			Get
				Return TimeSpan.FromMinutes(scaleValue + 1)
			End Get
		End Property

		Public Overrides Function Floor(ByVal [date] As DateTime) As DateTime
			' Performs edge calculations.
			If [date] = DateTime.MinValue OrElse [date] = DateTime.MaxValue Then
				Return RoundToScaleInterval([date])
			End If

			' Rounds down to the last interval in the previous date.
			If [date].TimeOfDay.TotalMinutes < FirstIntervalStart([date]) Then
				Return RoundToVisibleIntervalEdge([date].AddDays(-1), LastIntervalStart([date]))
			End If

			' Rounds down to the last interval in the current date.
			If [date].TimeOfDay.TotalMinutes > LastIntervalStart([date]) Then
				Return RoundToVisibleIntervalEdge([date], LastIntervalStart([date]))
			End If

			' Rounds down to the scale node.
			Return RoundToScaleInterval([date])
		End Function

		Protected Shared Function RoundToVisibleIntervalEdge(ByVal dateTime As DateTime, ByVal minutes As Integer) As DateTime
			Return dateTime.Date.AddMinutes(minutes)
		End Function
		Protected Function RoundToScaleInterval(ByVal [date] As DateTime) As DateTime
			Return DevExpress.XtraScheduler.Native.DateTimeHelper.Floor([date], TimeSpan.FromMinutes(scaleValue))
		End Function
		' Checks for edge conditions.
		Protected Overrides Function HasNextDate(ByVal [date] As DateTime) As Boolean
			Return [date] <= (DateTime.MaxValue - scaleValueTime)
		End Function

		Public Overrides Function GetNextDate(ByVal [date] As DateTime) As DateTime
			If HasNextDate([date]) Then
				If ([date].TimeOfDay.TotalMinutes > LastIntervalStart([date]) - scaleValue) Then
					Return RoundToVisibleIntervalEdge([date].AddDays(1), FirstIntervalStart([date].AddDays(1)))
				Else
					Return [date].AddMinutes(scaleValue)
				End If
			Else
				Return [date]
			End If
		End Function
	End Class
End Namespace
