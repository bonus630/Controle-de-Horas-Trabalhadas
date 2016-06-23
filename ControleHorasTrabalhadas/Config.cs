using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using io = System.IO;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Configuration;


namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public partial class Config : Form
    {
        private OpenFileDialog of;
        string starupPath = Application.StartupPath;
       
        public Config()
        {
            InitializeComponent();
            txt_dbpassword.Text = Properties.Settings.Default.dbpassword;
            txt_dbuser.Text = Properties.Settings.Default.dbuser;
            txt_dbserver.Text = Properties.Settings.Default.dbserver;
            this.loadConfigs();
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            of = new OpenFileDialog();
            of.Filter = "Imagens (*.jpg)|*.jpg;";
            if (of.ShowDialog() == DialogResult.OK)
            {
                lba_logo.Text = of.SafeFileName;
                btn_logo.BackgroundImage = Image.FromFile(of.FileName);
                btn_logo.Text = "";
                btn_logo.FlatAppearance.BorderSize = 0;
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            saveConfigs(); 
            
        }
       private void loadConfigs()
        {
            Properties.Settings.Default.GetPreviousVersion("nomeEmpresa");
        }
        private void saveConfigs()
        {
            if (!string.IsNullOrEmpty(txt_nomeEmpresa.Text) && !string.IsNullOrEmpty(txt_senha.Text) && of != null && checkConection()) {
                if (txt_senha.Text == txt_resenha.Text)
                {
                    btn_salvar.Enabled = false;
                    progressBar1.Visible = true;
                    if (io.File.Exists(starupPath + "\\logo.jpg"))
                        System.IO.File.Delete(starupPath + "\\logo.jpg");
                    addProgress(2);
                    System.IO.File.Copy(of.FileName, starupPath + "\\logo.jpg");
                    if (!io.Directory.Exists(starupPath+"\\fotos"))
                        io.Directory.CreateDirectory(starupPath+"\\fotos");
                    addProgress(2);
                    if (!io.Directory.Exists(Properties.Settings.Default.detailsDir))
                        io.Directory.CreateDirectory(Properties.Settings.Default.detailsDir);
                    addProgress(2);
                    
                    Properties.Settings.Default.adminPassword = txt_senha.Text;
                    Properties.Settings.Default.nomeEmpresa = txt_nomeEmpresa.Text;
                    Properties.Settings.Default.firstRun = false;
                    Properties.Settings.Default.dbpassword = txt_dbpassword.Text;
                    Properties.Settings.Default.dbuser= txt_dbuser.Text;
                    Properties.Settings.Default.dbserver = txt_dbserver.Text;
                    Properties.Settings.Default.startUpPassword = cb_senha.Checked;
                    addProgress(4);
                    if (!saveRegistryRun())
                        MessageBox.Show("A inicialização do aplicativo deve ser feita manualmente");
                    addProgress(10);
                    if (!createIcon())
                        MessageBox.Show("O icone do aplicativo deve ser criado manualmente");
                    addProgress(10);
                    if (!createBd())
                        MessageBox.Show("O banco de dados deve ser criado manualmente");
                    addProgress(10);
                    //Properties.Settings.Default.Upgrade();
                    //Properties.Settings.Default.settingUpgrade = false;
                    Properties.Settings.Default.Save();
                    addProgress(10);
                    Application.Restart();
                }
                else
                    MessageBox.Show("As senhas não batem");
             }
               
        }
        private bool createIcon()
        {
            try
            {
                io.DirectoryInfo DesktopFolder = new io.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                io.FileInfo fileOriginal = new io.FileInfo(Application.ExecutablePath);
                WshShell shell = new WshShell();


                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(DesktopFolder + "\\Controle de Horas Trabalhadas.lnk");
                link.IconLocation = starupPath + "\\startup.ico";
                link.WorkingDirectory = starupPath;
                link.TargetPath = starupPath + "\\ControleHorasTrabalhadas.exe";
                link.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void addProgress(int value)
        {
            progressBar1.Value += value;
        }

        private bool saveRegistryRun()
        {
            RegistryKey rk;
            try
            {
                string exeName = Application.ExecutablePath;
                rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                try
                {
                    rk.SetValue("ControleHorasTrabalhadas.exe", "\"" + exeName + "\"");
                    rk.Close();
                    return true;
                }
                catch (KeyNotFoundException erro)
                {
                    MessageBox.Show(erro.Message);
                    rk.Close();
                }
            }
            catch (UnauthorizedAccessException erro)
            {
                MessageBox.Show(erro.Message + " - " + erro.Source);
            }
            return false;
        }
        private bool createBd()
        {
            try
            {
                createDb(io.File.ReadAllText(starupPath + "\\banco-dados.sql"));
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void btn_dir_details_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                Properties.Settings.Default.detailsDir = folderBrowserDialog1.SelectedPath+"\\horas-trabalhadas";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkConection();
                    
        }
        private bool checkConection()
        {
            string conectionString = "Persist Security Info=False;server=" + txt_dbserver.Text + ";user=" + txt_dbuser.Text + ";database=information_schema;port=3306;password=" + txt_dbpassword.Text + ";";

            try
            {
                MySqlConnection conn = new MySqlConnection(conectionString);
                conn.Open();
                conn.Close();
                lba_test.ForeColor = Color.Green;
                lba_test.Text = "Sucess!!!";
                return true;
            }
            catch
            {
                lba_test.ForeColor = Color.Red;
                lba_test.Text = "Error!!!";
                return false;
            }
        }
        private void createDb(string query)
        {
            try
            {
                string connStr = "Persist Security Info=False;server=" + txt_dbserver.Text + ";user=" + txt_dbuser.Text + ";port=3306;password=" + txt_dbpassword.Text + ";";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlScript script = new MySqlScript(conn, query);
                script.Delimiter = ";";
                script.Execute();

            }
            catch (Exception erro)
            {
                throw erro;
            }



        }
    }
}
