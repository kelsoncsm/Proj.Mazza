using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Proj.Mazza.Domain.Common.Helpers
{
    public static class DateTimeBrasil
    {
        public static DateTime Convert(DateTime datetime)
        {
            return datetime.AddHours(-3);
            //return TimeZoneInfo.ConvertTime(datetime, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public static DateTime Now()
        {
            return DateTime.UtcNow.AddHours(-3);
            //return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }
    }
}
