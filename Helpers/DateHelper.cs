using System;

namespace CarAppDotNetApi.Helpers
{
    public static class DateHelper
    {
        public static string GetTimeStamp(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy.MM.dd HH:mm:ss");
        }
    }
}