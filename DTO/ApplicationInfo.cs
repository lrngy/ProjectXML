using System.Runtime.InteropServices;

namespace QPharma.DTO;

public class ApplicationInfo
{
    private static readonly Assembly assembly = Assembly.GetExecutingAssembly();
    public static string Title => assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
    public static string Description => assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
    public static string Company => assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
    public static string Product => assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
    public static string Copyright => assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
    public static string Trademark => assembly.GetCustomAttribute<AssemblyTrademarkAttribute>().Trademark;
    public static string AssemblyVersion => assembly.GetName().Version.ToString();
    public static string FileVersion => assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
    public static string GUID => assembly.GetCustomAttribute<GuidAttribute>().Value;
    public static string NeuralLanguage => assembly.GetCustomAttribute<AssemblyCultureAttribute>().Culture;
}