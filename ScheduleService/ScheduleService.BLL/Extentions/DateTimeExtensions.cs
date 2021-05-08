using System;

namespace ScheduleService.BLL.Extentions
{
    public static class DateTimeExtensions
    {
        public static int LocalizationDayOfWeek(this DateTime firstDayOfWeek)
        {
            var c = ((int)firstDayOfWeek.DayOfWeek + 6) % 7;
            return c;
        }
    }
}
