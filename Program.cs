using System;
using System.Threading;
using System.Windows.Forms;
using ProjectXML.GUI;

namespace ProjectXML
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashGUI splashGui = new SplashGUI();

            Application.Run(splashGui);


        }
    }
}