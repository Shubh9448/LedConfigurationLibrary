using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedConfigurationUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize text connections
            LedConfigurationLibrary.GlobalConfig.InitializeConnections(true);

           // Application.Run(new Settings0());

            Application.Run(new MainForm());
        }
    }
}
