using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace br.corp.bonus630.ControleHorasTrabalhadas.Updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!(args.Length > 0))
            {
                Application.Exit();
            }
            else
            {
                Application.Run(new Updater(args));
            }
        }
    }
}
