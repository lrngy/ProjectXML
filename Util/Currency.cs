namespace QPharma.Util;

public class Currency
{
    public static string FormatCurrency(string amount)
    {
        int number = int.Parse(amount);
        return String.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0}", number) + "đ";
    }

    public static string ParseCurrency(string formattedAmount)
    {
        string cleanedAmount = formattedAmount.Replace(".", "").Replace("đ", "").Trim();

        return cleanedAmount;
    }
}