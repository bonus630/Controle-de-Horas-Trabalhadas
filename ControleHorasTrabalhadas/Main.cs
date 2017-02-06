using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
//using System.Threading;
using System.Diagnostics;
using br.corp.bonus630.ControleHorasTrabalhadas.SystemTime;
using br.corp.bonus630.ControleHorasTrabalhadas.Controllers;
using System.Collections;
using System.Linq;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public partial class Main : Form
    {
        BindingList<People> workers = new BindingList<People>();
        Regex rg = new Regex("^789(?<id>[0-9]{4})[0-9]{1}");
        DbControl dbControl;
        People worker;
        int workerId = 0;
        private int cont = 0;
        private bool conectionOK = false;
        private Timer timer;
        public Main()
        {
            InitializeComponent();
            DbControl.setStringConnection(Properties.Settings.Default.dbserver, Properties.Settings.Default.dbuser, Properties.Settings.Default.dbpassword);
            dbControl = new DbControl();
            timer = new Timer();
            timer.Start();
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            txt_bar_code.Enabled = false;
            this.GotFocus += Main_GotFocus;
            this.Enter += Main_Enter;
            try
            {
                SystemTimeCheck stc = new SystemTimeCheck();
                stc.HttpTimeReady += stc_HttpTimeReady;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        void stc_HttpTimeReady(object obj, HttpUtils.HttpUtilsEventArgs e)
        {
            MessageBox.Show("Hora Certa! \n"+e.Version,"Horário do sistema incorreto pode afetar o aplicativo!");
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            conectionOK = dbControl.checkMysql();
            if (conectionOK)
            {
                timer.Stop();
                timer.Dispose();
                this.Text = "Entre com seu código.";
                cont = 0;
                checkWorkers();
                txt_bar_code.Enabled = true;
                txt_bar_code.Focus();
            }
            else
            {
                timer.Interval = 2000;
                cont++;
                this.Text = "Tentando conectar! " + cont + " tentativa.";
            }
        }

        void Main_Enter(object sender, EventArgs e)
        {
            txt_bar_code.Text = "";
            txt_bar_code.Select();
            txt_bar_code.Focus();
        }

        void Main_GotFocus(object sender, EventArgs e)
        {
            txt_bar_code.Text = "";
            txt_bar_code.Select();
        }
        public int returnId(string barcode)
        {
            Match match = rg.Match(barcode);
            return Int32.Parse(match.Result("${id}"));
        }
        private void button2_Click(object sender, EventArgs e)
        {
           // Badge badge = new Badge(0);
           // badge.Show();
        }

       private void cd_btn_fechar_click(object sender, EventArgs e)
        {
            checkWorkers();
        }
       private Period fillOnePeriod(int periodId)
       {
           Period period = dbControl.getPeriod(worker.Id, periodId);
           period.autoFillHours();
           return period;
       }
        private void startRunner()
        {
           
            string barcode = txt_bar_code.Text; 
            workerId = returnId(barcode);
            if (dbControl.isAdmin(workerId))
            {
                panel_login.Visible = true;
                txt_senha.Focus();
                txt_bar_code.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                lba_bemVindo.Text = "";
                try
                {
                   
                    //worker = dbControl.getWorker(workerId);
                    try
                    {
                        worker = workers.Single(r => r.Id == workerId && r.Active);
                    }
                    catch
                    {
                        lba_bemVindo.Text = "Código não encontrado";
                        return;
                    }
                
                    if (worker != null)
                    {
                        if (!dbControl.endTime(workerId))
                        {
                            if (dbControl.startTime(workerId))
                            {
                                lba_bemVindo.Text = "Bom trabalho,";
                                lba_nome.Text = worker.Name;
                                worker.Working = true;
                            }
                        }
                        else
                        {
                            lba_bemVindo.Text = "Bom descanso,";
                            lba_nome.Text = worker.Name;
                            worker.Working = false;
                        }
                        
                    }
                    else
                    {
                        lba_bemVindo.Text = "Código não encontrado";
                    }
                    if (worker != null)
                    {
                        BackgroundWorker bg = new BackgroundWorker();

                        bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                        bg.DoWork += bg_DoWork;
                        bg.RunWorkerAsync();
                    }
                }
                catch(Exception erro)
                {
                    if (MessageBox.Show(erro.Message, "Abra o mysql e reinicie a aplicação!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        Application.Restart();
                    else
                        Application.Exit();
                    
                }
            }
            //checkWorkers();
            updateUI();
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            int periodId = dbControl.getPeriodId(workerId);
            Period period = fillOnePeriod(periodId);
            People worker = this.worker;
            SaveLoad.save(string.Format("{0}\\{1}{2}_atual_{3}.bon",Cadastre.detailsDir, worker.Name.Replace(" ", "-").ToLower(),workerId,DateTime.Now.ToString("dd-MM-yy")), period);
        }
        private void updateUI()
        {
            flowLayout_trabalhando.Controls.Clear();
            int count = 0;
            foreach (People worker in workers)
            {
                //if (dbControl.isWork(worker.Id))
                if (worker.Working)
                {
                    count++;
                    Label temp = new Label();
                    temp.Text = worker.Name;
                    temp.AutoSize = true;
                    temp.Margin = new Padding(0, 6, 0, 0);
                    temp.ForeColor = Color.Red;
                    flowLayout_trabalhando.Controls.Add(temp);
                }

            }
            if (count == 0)
            {
                flowLayout_trabalhando.Visible = false;
                lba_trabalhando.Visible = false;
                return;
            }
            else
            {
                flowLayout_trabalhando.Visible = true;
                lba_trabalhando.Visible = true;
            }
        }
        private void checkWorkers()
        {
            try
            {
                

                //List<People> workers = dbControl.getAllWorkers();
                this.workers = dbControl.getAllWorkers();
                updateUI();
                //List<People> workersIn = new List<People>();
                
              //  foreach (People worker in workers)
              //  {
              //      if (dbControl.isWork(worker.Id))
              //      {
              //          workersIn.Add(worker);
               //     }
               // }
               // IEnumerable<People> workersIn = workers.Where(r => r.Working == true); 
                //workersIn.cou
                //if (workersIn.Count == 0)
                //{
                //    flowLayout_trabalhando.Visible = false;
                //    lba_trabalhando.Visible = false;
                //    return;
                //}
                //else
                //{
                //    flowLayout_trabalhando.Visible = true;
                //    lba_trabalhando.Visible = true;
                //}
                //foreach (People worker in workersIn)
               
            }
            catch (Exception erro)
            {
                    if (MessageBox.Show(erro.Message, "Abra o servidor mysql e aguarde", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        Process.GetCurrentProcess().Kill();
                    }
            }
        }
        private void txt_bar_code_TextChanged(object sender, EventArgs e)
        {
            if (rg.IsMatch(txt_bar_code.Text))
            {
                startRunner();
                txt_bar_code.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastre cadastre = new Cadastre();
            cadastre.ShowDialog();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            if(txt_senha.Text == Properties.Settings.Default.adminPassword)
            {
                txt_senha.Text = "";
                Cadastre cd = new Cadastre(this.workers);
                button1.Enabled = false;
                cd.FormClosed += cd_FormClosed;
                cd.btn_fechar_click += cd_btn_fechar_click;
                cd.ShowDialog();
            }
        }

        void cd_FormClosed(object sender, FormClosedEventArgs e)
        {
            enableBarCode();
        }

        private void enableBarCode()
        {
            this.Select();
            panel_login.Visible = false;
            txt_bar_code.Enabled = true;
            txt_bar_code.Select();
            checkWorkers();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        #if DEBUG
            System.Diagnostics.Process.Start("http://GOOGLE.COM");
        #else
            System.Diagnostics.Process.Start("http://bonus630.tk/d/141");
        #endif
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            enableBarCode();
        }

    }
}
