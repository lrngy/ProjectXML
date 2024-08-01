using System;
using System.Windows.Forms;
using QPharma.GUI;

namespace QPharma
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashGUI());
        }
    }
}