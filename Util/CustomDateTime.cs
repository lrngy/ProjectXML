﻿using System;
using System.Globalization;

namespace ProjectXML.Util
{
    public class CustomDateTime
    {
        private static readonly string format = "dd/MM/yyyy HH:mm";

        public static string GetNow()
        {
            return DateTime.Now.ToString(format);
        }

        public static bool IsDate(string input)
        {
            DateTime date;
            return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
    }
}