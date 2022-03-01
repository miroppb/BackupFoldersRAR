using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BackupFoldersRAR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs().Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                NativeMethods.AllocConsole();
                Console.WriteLine("hello there");
                Console.ReadLine();
                frmMain.CmdRun();
            }
        }
    }

    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }
}
