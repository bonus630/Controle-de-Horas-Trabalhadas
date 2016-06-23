using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using br.corp.bonus630.ControleHorasTrabalhadas.Controllers;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public partial class Cadastre : Form
    {
        public event EventHandler btn_fechar_click;
        
        public Cadastre()
        {
            InitializeComponent();
            funcionario = new People();
           // funcionarios = new List<People>();
            funcionarios = new BindingList<People>();
            dbControl = new DbControl();
            
           // dateTime_iniciar.MaxDate = DateTime.Now.Date;
           // dateTime_final.MaxDate = DateTime.Now.Date;
            versãoToolStripMenuItem.Text = Cadastre.VERSION;
        }
        public Cadastre(BindingList<People> workers)
        {
            InitializeComponent();
            funcionario = new People();
            funcionarios = workers;
            dbControl = new DbControl();
            
            // dateTime_iniciar.MaxDate = DateTime.Now.Date;
            // dateTime_final.MaxDate = DateTime.Now.Date;
            versãoToolStripMenuItem.Text = Cadastre.VERSION;
        }
                
        //Eventos do form
        private void photo_Click(object sender, EventArgs e)
        {
            of = new OpenFileDialog();
            of.Filter = "Imagens (*.jpg,*.bmp,*.jpeg,*.gif)|*.jpg;*.bmp;*.jpeg;*.gif";
            if (of.ShowDialog() == DialogResult.OK)
            {
                photo.ImageLocation = of.FileName;

            }
        }

        private void Cadastre_Load(object sender, EventArgs e)
        {
            formLoad();

        }


        //Eventos cadastro//
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            funcionario.Name = txt_nome.Text;
            if (photo.ImageLocation != Application.StartupPath + "\\fotos\\" && !string.IsNullOrEmpty(photo.ImageLocation))
                funcionario.PhotoName = funcionario.Name.Replace(" ", "-").ToLower() + photo.ImageLocation.Substring(photo.ImageLocation.LastIndexOf('.'));
            else
                funcionario.PhotoName = string.Empty;
               // funcionario.PhotoName = photo.ImageLocation.Remove(0, photo.ImageLocation.LastIndexOf("\\") + 1);
            funcionario.Active = cb_ativo.Checked;

            if (editing)
            {
                if (dbControl.editWorker(funcionario))
                {
                    try
                    {
                        if (of != null)
                        {
                            File.Copy(of.FileName, Application.StartupPath + "\\fotos\\" + funcionario.Name.Replace(" ", "-").ToLower() + of.FileName.Substring(of.FileName.LastIndexOf('.')));
                            of = null;
                        }
                    }
                    catch (IOException erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                    resetFields();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(funcionario.Name))
                {
                    if (dbControl.insertWorker(funcionario))
                    {
                        funcionario.Id = dbControl.getLastWorkId();
                        dbControl.createNewPeriod(funcionario.Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        try
                        {
                            if (of != null)
                            {
                                File.Copy(of.FileName, Application.StartupPath + "\\fotos\\" + funcionario.Name.Replace(" ", "-").ToLower() + of.FileName.Substring(of.FileName.LastIndexOf('.')));
                                of = null;
                            }
                        }
                        catch (IOException erro)
                        {
                            MessageBox.Show(erro.Message);
                        }
                        resetFields();
                    }
                }
            }
            Cadastre_Load(null, null);
        }
        private void dataGridView_funcionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drow = dataGridView_funcionarios.CurrentRow;
            this.funcionario = (People)drow.DataBoundItem;
            fillFields();
        }
        private void btn_geraCracha_Click(object sender, EventArgs e)
        {
            Badge bg = new Badge(funcionario);
            bg.ShowDialog();
        }
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            finalizeWorkerHour();
        }
        //Eventos//
        private void btn_novo_Click(object sender, EventArgs e)
        {
            resetFields();
            txt_nome.Focus();
        }
        private void btn_open_Click(object sender, EventArgs e)
        {
            openFile();

        }
        private void dataGridView_horarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentSelectedHoursRow();
        }
        private void dataGridView_horarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentSelectedHoursRow();
            btn_relatorio_Click(null, null);
        }
        private void setCurrentSelectedHoursRow()
        {
            DataGridViewRow rrow = dataGridView_horarios.CurrentRow;
            if (rb_npagos.Checked)
            {
                RelatorioItem ri = (RelatorioItem)rrow.DataBoundItem;
                hourId = ri.HourId;
                dateTimePicker1.Value = ri.DateStart;
                if (ri.DateEnd == new DateTime(0))
                    dateTimePicker_cor_final_day.Value = DateTime.Now;
                else
                    dateTimePicker_cor_final_day.Value = ri.DateEnd;
                btn_corrigir_data.Enabled = true;
              
                dateTimePicker_cor_inicio.Value = ri.DateStart;
            }
            else
            {

                selectedPeriod = (Period)rrow.DataBoundItem;
                // fillSelectedPeriod(true);
                if (selectedPeriod.Paid)
                {
                    btn_pagar.Enabled = false;
                    
                }
                else
                {
                    btn_pagar.Enabled = true;
                    
                }
                btn_relatorio.Enabled = true;
                salvarToolStripMenuItem.Enabled = true;
                exportarExcelToolStripMenuItem.Enabled = true;
                btn_corrigir_data.Enabled = false;
                
                
            }
        }
        private void btn_corrigir_data_Click(object sender, EventArgs e)
        {
            
            Confirmation co = new Confirmation("Corrigir os horários de " + dateTimePicker1.Value.ToLongDateString() + "."," Entrada às: " + dateTimePicker_cor_inicio.Value.ToShortTimeString() + " Saida às: "+dateTimePicker_cor_final_day.Value.ToLongDateString()+" " + dateTimePicker_cor_final.Value.ToShortTimeString());
            if (co.ShowDialog() == DialogResult.Yes)
            {

                if (dbControl.timeCorrection(hourId, dateTimePicker_cor_inicio.Value.ToString("yyyy-MM-dd HH:mm:ss"),dateTimePicker_cor_final_day.Value.ToString("yyyy-MM-dd")+ dateTimePicker_cor_final.Value.ToString(" HH:mm:ss")))
                {
                    showInWork();
                    btn_corrigir_data.Enabled = false;
                    fillFields();
                }
            }
        }
        private void txt_valor_hora_TextChanged(object sender, EventArgs e)
        {
            calculateValue();
        }
        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            if (selectedPeriod.Paid)
                new Relatorio(selectedPeriod).ShowDialog();
            else
                new Relatorio(selectedPeriod, (double)valorHora).ShowDialog();
        }
        private void rb_npagos_CheckedChanged(object sender, EventArgs e)
        {
            refreshDatePickers();
        }
        private void rb_tudos_CheckedChanged(object sender, EventArgs e)
        {
            refreshDatePickers();
        }

        private void rb_pagos_CheckedChanged(object sender, EventArgs e)
        {
            refreshDatePickers();
        }
        private Period fillOnePeriod(int periodId)
        {
            Period period = dbControl.getPeriod(funcionario.Id, periodId);
            period.autoFillHours();
            return period;
        }
        private void btn_pagar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_valor_hora.Text))
            {
                txt_valor_hora.Focus();
                return;
            }
            try
            {
                //string dateEnd = dateTime_final.Value.ToString("yyyy-MM-dd")+" "+DateTime.Now.ToString("HH:mm:ss");
               // string dateEnd = dateTime_final.Value.ToString("yyyy-MM-dd");
                Confirmation co = new Confirmation("Pagar o período de " + periods[0].StartDate.ToShortDateString() + " à " + dateTime_final.Value.ToShortDateString());
                if (co.ShowDialog() == DialogResult.Yes)
                {
                    //int periodId = 0;
                    int periodId = dbControl.getPeriodId(funcionario.Id);
                    if (dbControl.setPayPeriod(periodId, funcionario.Id, dateTime_final.Value, valorHora))
                    {
                        Period per = fillOnePeriod(periodId);
                        if(per.ListHours.Count==0)
                        {
                            SaveLoad.save(string.Format("{0}\\{1}{2}_{3}_{4}_{5}-empty.bon",Cadastre.detailsDir, funcionario.Name.Replace(" ", "-").ToLower(),funcionario.Id,periods[0].StartDate.ToString("dd-MM-yyyy"),DateTime.Now.ToString("dd-MM-yy"),periodId),per);
                            //SaveLoad.save(Cadastre.detailsDir + "\\" + periods[0].StartDate.ToString("dd-MM-yyyy") + "-" + funcionario.Name.Replace(" ", "-").ToLower() + funcionario.Id + "-" + periodId + "-empty.bon", per);
                              //          string.Format("{0}\\{1}{2}_atual_{3}.bon",Cadastre.detailsDir, worker.Name.Replace(" ", "-").ToLower(),workerId,DateTime.Now.ToString("dd-MM-yy")), period
                        }
                        else
                            SaveLoad.save(string.Format("{0}\\{1}{2}_{3}_{4}_{5}.bon", Cadastre.detailsDir, funcionario.Name.Replace(" ", "-").ToLower(), funcionario.Id, periods[0].StartDate.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yy"), periodId), per);

                            //SaveLoad.save(Cadastre.detailsDir+"\\"+periods[0].StartDate.ToString("dd-MM-yyyy")+"-"+funcionario.Name.Replace(" ","-").ToLower()+funcionario.Id+"-"+periodId+".bon", per);
                        refreshHours();
                    }
                }
            
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private Period loadFile(string filepath)
        {
            Period period = SaveLoad.load(filepath);
            return period;
        }
        private void dateTime_iniciar_CloseUp(object sender, EventArgs e)
        {
            refreshHours(); 
        }
        private void dateTime_final_CloseUp(object sender, EventArgs e)
        {
            refreshHours();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFile();
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\ControleHorasTrabalhadasUpdater.exe", "\"" + Application.StartupPath + "\" \" \"");
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void restaurarFuncionárioPeloArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = Cadastre.detailsDir;
            of.Filter = "Relatórios (*.bon)|*.bon;";
            if (of.ShowDialog() == DialogResult.OK)
            {
                 Period period = SaveLoad.load(of.FileName);
                 if(!funcionarios.Exists(period.Worker.Id) )
                     funcionarios.Add(period.Worker);
                 
                    
                 dbControl.restoreDbFromFile(period);
            }
            fillGridWorkers();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "bon";
            //sfd.InitialDirectory = Cadastre.detailsDir;
            sfd.Filter = "Relatórios (*.bon)|*.bon";
            sfd.FileName = selectedPeriod.StartDate.ToString("dd-MM-yyyy") + "-" + selectedPeriod.Worker.Name.Replace(" ", "-").ToLower() + selectedPeriod.Worker.Id + "-" + selectedPeriod.Id + ".bon";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                SaveLoad.save(sfd.FileName, selectedPeriod);
            }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Adquira por R$ 19,00");
            //SaveFileDialog sf = new SaveFileDialog();
            ////of.InitialDirectory = Cadastre.detailsDir;
            //sf.Filter = "(*.xls)|*.xls;";
            //sf.DefaultExt = "*.xls";
            //if (sf.ShowDialog() == DialogResult.OK)
            //{
            //    SaveLoad.exportExcel(sf.FileName, selectedPeriod);
            //}
        }

      

       

        
    } 
}
