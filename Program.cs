using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using QPharma.GUI;

namespace QPharma
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            var currentProcess = Process.GetCurrentProcess();
            var runningProcess = Process.GetProcessesByName(currentProcess.ProcessName)
                .FirstOrDefault(p => p.Id != currentProcess.Id);

            if (runningProcess != null)
            {
                runningProcess.Kill();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashGUI());
        }
    }
}