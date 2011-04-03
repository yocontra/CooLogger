using System;

namespace CooLoader.Util.Time
{
    public static class DateTimeExtensions
    {
        private static DateTime _jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long CurrentTimeMillis(this DateTime d)
        {
            return (long)((DateTime.UtcNow - _jan1St1970).TotalMilliseconds);
        }
    }
}
