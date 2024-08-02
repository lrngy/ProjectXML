using QPharma.GUI;

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
        string sourcePath = Path.Combine(installPath, "QlyHieuThuoc.mdf");

        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Development.Default.LocalResource);
        string targetPath = Path.Combine(appDataPath, "QlyHieuThuoc.mdf");

        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }

        if (!File.Exists(targetPath))
        {
            File.Copy(sourcePath, targetPath, true);
        }

        string connectionString = string.Format(Development.Default.ConnectionString, targetPath);
        Development.Default.ConnectionString = connectionString;
        Development.Default.Save();
    }
}