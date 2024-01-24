using System;
namespace Member.Domain.Utils
{
	public class DateUtil
	{
        public static DateTime GetCurrentDate()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
        }
    }
}

