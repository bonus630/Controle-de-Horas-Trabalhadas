using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;


namespace br.corp.bonus630.ControleHorasTrabalhadas.Updater
{
    public class Updater : ApplicationContext
    {
        private WebClient conect;
        private string diretorio;
        private string arquivo;
        private string appDir;
        private NotifyIcon icone;
        private string appVer;

        public Updater(string[] args)
        {
            diretorio = args[0]+@"\update";
            //diretorio = args[0];
            appDir = args[0];
            appVer = args[1];
            arquivo = "update.zip";
            conect = new WebClient();
            icone = new NotifyIcon();
            icone.Icon = global::br.corp.bonus630.ControleHorasTrabalhadas.Updater.Properties.Resources.Update;
            icone.Visible = true;
            icone.Text = "Atualizador";
            conect.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(conect_DownloadFileCompleted);
            conect.DownloadProgressChanged += new DownloadProgressChangedEventHandler(conect_DownloadProgressChanged);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            if(Directory.Exists(diretorio))
            {
                extractFiles();
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(diretorio);
                    downloadUpdates(diretorio);
                }
                catch (IOException erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        void conect_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage % 10 == 0)
            {
                icone.BalloonTipText = "Baixando atualização " + e.ProgressPercentage+"% concluída";
                icone.ShowBalloonTip(500);
            }
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            icone.Visible = false;
            try
            {
                this.conect.CancelAsync();
            }
            catch (Exception erro)
            { }
            Process[] ps = Process.GetProcessesByName("ControleHorasTrabalhadasUpdater");
            foreach (Process p in ps)
            {
                try
                {
                    p.Kill();
                }
                catch (Exception erro) { Debug.WriteLine(erro.Message); }
            }
            this.ExitThread();
        }

        private void downloadUpdates(string dir)
        {
            try
            {
                conect.DownloadFileAsync(new Uri("http://bonus630.tk/controlehorastrabalhadas/download/update.zip"), diretorio+"\\"+arquivo);
                icone.BalloonTipText = "Baixando Atualização";
                icone.ShowBalloonTip(500);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                Application.Exit();
            }
        }


        private void extractFiles()
        {
            if (File.Exists(diretorio + "\\" + arquivo))
            {
                //MessageBox.Show("extrair");
                if (DialogResult.Yes == MessageBox.Show("Para aplicar a atualização o programa será reiniciado, deseja fazer isso?", "Aplicar Atualização?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    Process[] ps = Process.GetProcessesByName("ControleHorasTrabalhadas");
                    foreach (Process p in ps)
                    {
                        p.Kill();
                    }
                    
                    
                    FastZip fz = new FastZip();
                    try
                    {
                        icone.BalloonTipText = "Aguarde instalando atualização!";
                        icone.ShowBalloonTip(600);
                        fz.ExtractZip(diretorio + "\\" + arquivo, appDir, FastZip.Overwrite.Always, new FastZip.ConfirmOverwriteDelegate(teste), "", "", false);
                        File.Delete(diretorio + "\\" + arquivo);
                        
                        Thread.Sleep(600);
                    }
                    catch(IOException erro)
                    {
                        MessageBox.Show(erro.Message,"Houve um erro na atualização!");
                    }
                    try
                    {
                        System.Diagnostics.Process.Start("ControleHorasTrabalhadas");
                    }
                    catch(Exception erro)
                    {
                        MessageBox.Show(erro.Message,"Não foi possível reabrir o software, abra-o manualmente!");
                    }

                }
                Application.Exit();
            }
            else
            {
                downloadUpdates(diretorio);
            }
        }

        bool teste(string a)
        { return false; }

        void conect_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
           icone.BalloonTipText = "Download Concluído";
           icone.ShowBalloonTip(500);
           extractFiles();
           Application.Exit();
            
        }

    }
}
