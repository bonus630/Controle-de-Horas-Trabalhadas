using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace br.corp.bonus630.ControleHorasTrabalhadas
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
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1)
            {
                if (Properties.Settings.Default.firstRun)
                    Application.Run(new Config());
                else
                {
                    if (Properties.Settings.Default.startUpPassword)
                    {
                        if (new Confirmation("Abrir Aplicação?").ShowDialog() == DialogResult.Yes)
                        {
                            Application.Run(new Main());
                        }
                    }
                    else
                        Application.Run(new Main());
                }
            }
            else
                Application.Exit();
        }
    }
}
