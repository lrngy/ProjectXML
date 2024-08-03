namespace QPharma;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        var currentProcess = Process.GetCurrentProcess();
        var runningProcess = Process.GetProcessesByName(currentProcess.ProcessName)
            .FirstOrDefault(p => p.Id != currentProcess.Id);

        if (runningProcess != null) runningProcess.Kill();

        InitDB();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SplashGUI());


    }

    private static void InitDB()
    {
        string installPath = Application.StartupPath;

        string sourcePath = Path.Combine(installPath, Config.Instance.ConfigureFile.DBFile);

        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Config.Instance.ConfigureFile.LocalResource);
        string targetPath = Path.Combine(appDataPath, Config.Instance.ConfigureFile.DBFile);

        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }

        if (!File.Exists(targetPath))
        {
            File.Copy(sourcePath, targetPath, true);
        }
        Config.Instance.ConfigureFile.Reload();
        string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={targetPath};Integrated Security=True;Connect Timeout=30";
        Config.Instance.ConfigureFile.ConnectionString = connectionString;
        Config.Instance.ConfigureFile.Save();
    }
}