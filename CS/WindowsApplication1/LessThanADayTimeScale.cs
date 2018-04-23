using System;
using DevExpress.XtraScheduler;

namespace Lane_Management
{
    public abstract class LessThanADayTimeScale : TimeScale
    {
        // Holds the scale increment, in minutes.
        int scaleValue;
        TimeSpan scaleValueTime;

        public LessThanADayTimeScale(int ScaleValue)
        {
            scaleValue = ScaleValue;
            scaleValueTime = TimeSpan.FromMinutes(ScaleValue);
        }
        protected LessThanADayTimeScale()
        {
            
        }
        protected LessThanADayTimeScale(string displayName)
            : base(displayName)
        {
            
        }
        protected LessThanADayTimeScale(string displayName, string menuCaption)
            : base(displayName, menuCaption)
        {
            
        }

        // Gets the start of the first time interval.
        protected virtual int FirstIntervalStart(DateTime date)
        {
            //switch (date.DayOfWeek)
            //{
            //    case DayOfWeek.Saturday:
            //        return 9 * 60;
            //    case DayOfWeek.Sunday:
            //        return 10 * 60;
            //    default:
            //        return 9 * 60;
            //}
            return 0;
        }

        // Gets the start of the last time interval.
        protected virtual int LastIntervalStart(DateTime date)
        {
            //switch (date.DayOfWeek)
            //{
            //    case DayOfWeek.Saturday:
            //        return 24 * 60 - scaleValue;
            //    case DayOfWeek.Sunday:
            //        return 22 * 60 - scaleValue;
            //    default:
            //        return 24 * 60 - scaleValue;
            //}
            return 24 * 60 - scaleValue;
        }

        // Gets the value used to order the scales.
        protected override TimeSpan SortingWeight
        {
            get { return TimeSpan.FromMinutes(scaleValue + 1); }
        }

        public override DateTime Floor(DateTime date)
        {
            // Performs edge calculations.
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                return RoundToScaleInterval(date);

            // Rounds down to the last interval in the previous date.
            if (date.TimeOfDay.TotalMinutes < FirstIntervalStart(date))
                return RoundToVisibleIntervalEdge(date.AddDays(-1), LastIntervalStart(date));

            // Rounds down to the last interval in the current date.
            if (date.TimeOfDay.TotalMinutes > LastIntervalStart(date))
                return RoundToVisibleIntervalEdge(date, LastIntervalStart(date));

            // Rounds down to the scale node.
            return RoundToScaleInterval(date);
        }

        protected static DateTime RoundToVisibleIntervalEdge(DateTime dateTime, int minutes)
        {
            return dateTime.Date.AddMinutes(minutes);
        }
        protected DateTime RoundToScaleInterval(DateTime date)
        {
            return DevExpress.XtraScheduler.Native.DateTimeHelper.Floor(date, TimeSpan.FromMinutes(scaleValue));
        }
        // Checks for edge conditions.
        protected override bool HasNextDate(DateTime date)
        {
            return date <= (DateTime.MaxValue - scaleValueTime);
        }

        public override DateTime GetNextDate(DateTime date)
        {
            if (HasNextDate(date))
            {
                return (date.TimeOfDay.TotalMinutes > LastIntervalStart(date) - scaleValue) ?
                    RoundToVisibleIntervalEdge(date.AddDays(1), FirstIntervalStart(date.AddDays(1))) : date.AddMinutes(scaleValue);
            }
            else return date;
        }
    }
}
