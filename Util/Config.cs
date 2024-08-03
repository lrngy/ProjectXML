namespace QPharma.Util;

public sealed class Config
{
    private static readonly Lazy<Config> lazy = new(() => new Config());
    public static Config Instance => lazy.Value;

#if Development
    public Development ConfigureFile { get; } = Development.Default;
#elif Production
    internal Production ConfigureFile { get; } = Production.Default;
#endif


    public string CurrentDirectory => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
}