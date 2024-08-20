namespace QPharma.Util;

public class Currency
{
    public static string FormatCurrency(string amount)
    {
        decimal money = decimal.Parse(amount);
        return String.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0}", money);
    }

    public static string ParseCurrency(string formattedAmount)
    {
        string cleanedAmount = formattedAmount.Replace(".", "").Trim();

        return cleanedAmount;
    }
}