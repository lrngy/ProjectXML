using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Util
{
    public class CustomDateTime
    {
        static string format = "dd-MM-yyyy HH:mm";
        public static string GetNow()
        {
            return DateTime.Now.ToString(format);
        }

        public static bool IsDate(string input)
        {
            DateTime date;
            return DateTime.TryParseExact(input, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
        }

    }
}
