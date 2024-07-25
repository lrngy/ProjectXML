using System;
using System.Globalization;

namespace QPharma.Util
{
    public class CustomDateTime
    {
        private static readonly string format = "yyyy-MM-dd HH:mm:ss";

        public static string GetNow()
        {
            return DateTime.Now.ToString(format);
        }

        public static bool IsDate(string input)
        {
            DateTime date;
            return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        //public static string GetDateValidate(string input)
        //{

        //    return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture).ToString();
        //}

        public static TimeSpan CompareDateTime(string datetime1, string datetime2)
        {
            var one = DateTime.Parse(datetime1);
            var two = DateTime.Parse(datetime2);
            return one - two;
        }
    }
}