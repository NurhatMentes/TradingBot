using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime TruncateToMinute(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
        }

        public static DateTime StartOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        public static DateTime EndOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        public static bool IsWeekend(this DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsMarketOpen(this DateTime dt)
        {
            if (dt.IsWeekend()) return false;
            var timeOfDay = dt.TimeOfDay;
            return timeOfDay >= new TimeSpan(9, 30, 0) && timeOfDay <= new TimeSpan(16, 0, 0);
        }
    }
}
