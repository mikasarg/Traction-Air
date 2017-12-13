using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TractionAir.Forms;

namespace TractionAir
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
            splashForm splash = new splashForm();
            splash.Show();
            Application.Run(new TractionAirForm(splash));
        }
    }
}
