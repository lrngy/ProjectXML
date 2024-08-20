namespace QPharma.Util;

public class CustomDateTime
{
    private static readonly string format = "yyyy-MM-dd HH:mm:ss";

    public static string GetNow()
    {
        return DateTime.Now.ToString(format);
    }

    public static string GetFormattedDate(string dateDMY = "", string dateFormat = "")
    {
        try
        {
            var currentDate = string.IsNullOrEmpty(dateDMY) ? DateTime.Now : DateTime.ParseExact(dateDMY, "dd/MM/yyyy", null);
            var formattedDate = string.Format(string.IsNullOrEmpty(dateFormat) ? Resources.Date_format : dateFormat,
                GetDayOfWeekInVietnamese(currentDate.DayOfWeek),
                currentDate.Day,
                currentDate.Month,
                currentDate.Year);
            return formattedDate;
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private static string GetDayOfWeekInVietnamese(DayOfWeek dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeek.Sunday:
                return Resources.Sunday;
            case DayOfWeek.Monday:
                return Resources.Monday;
            case DayOfWeek.Tuesday:
                return Resources.Tuesday;
            case DayOfWeek.Wednesday:
                return Resources.Wednesday;
            case DayOfWeek.Thursday:
                return Resources.Thursday;
            case DayOfWeek.Friday:
                return Resources.Friday;
            case DayOfWeek.Saturday:
                return Resources.Saturday;
            default:
                return "";
        }
    }

    public static bool IsDate(string input)
    {
        DateTime date;
        return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }


    public static TimeSpan CompareDateTime(string datetime1, string datetime2)
    {
        var one = DateTime.Parse(datetime1);
        var two = DateTime.Parse(datetime2);
        return one - two;
    }
}