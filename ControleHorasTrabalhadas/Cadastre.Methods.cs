using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using br.corp.bonus630.ControleHorasTrabalhadas.HttpUtils;
using br.corp.bonus630.ControleHorasTrabalhadas.Controllers;
using System.ComponentModel;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public static class Extensions
    {
        public static bool Exists(this BindingList<People> list, int id )
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Id == id)
                    return true;
            }
            return false;
            
        }
        public static void UpdateItem(this BindingList<People> list, int id, bool working)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == id)
                    list[i].Working = working;
            }
        }
    }

    /********
        //Fazer alguns refleshs ao:

        //Clicar em uma linha do gridView_funcionarios
            //1; 3
        //Alterar a data nos datetimerpicker iniciar e final
             //1
        //modificar a seleção de checkbox
            //1; 3
        //Corrigir um horário e parar um horário
            //2
        //Editar e adicionar um novo funcionario
            //2	

        //Lista de refleshs

        //1 Atualizar o gridView_horários
        //2 Atualizar o gridView_funcionarios
        //3 Atualizar os datetimerpicker iniciar e final
    ************/
    partial class Cadastre
    {
        public delegate void UpdateButtonAtualizarDelegate(bool update,string text);
        public UpdateButtonAtualizarDelegate updateDelegate;
        private People funcionario;
       // private List<People> funcionarios;
        private BindingList<People> funcionarios;
        private bool editing = false;
        private OpenFileDialog of;
        private DbControl dbControl;
        private int hourId;
        private List<Hours> hoursList = new List<Hours>();
        List<Period> periods = new List<Period>();
        private double totalHours = 0;
        private decimal valorHora = 0;
        private Period selectedPeriod;
        private Regex mValue = new Regex(@"(?<num>[0-9]{0,},?[0-9]{0,2})?"); 
        public static string detailsDir = Properties.Settings.Default.detailsDir;
        public static string  VERSION = "1.0.0.18";
        //notas
           
        //erro no max date, e value
      

         private void formLoad()
        {
            HttpToolRequest httpRequest = new HttpToolRequest();
            try
            {
                httpRequest.httpAscync(Cadastre.VERSION, HttpOpType.VERSIONCHECK);
            }
             catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            httpRequest.httpRequestComplete += httpRequest_httpRequestComplete;
            fillGridWorkers();
            salvarToolStripMenuItem.Enabled = false;
            exportarExcelToolStripMenuItem.Enabled = false;
              
        }
        void fillGridWorkers()
         {
             try
             {
                 dataGridView_funcionarios.DataSource = funcionarios;
                 //dataGridView_funcionarios.u
                 //this.funcionarios = dbControl.getAllWorkers();
                 foreach (People funcionario in funcionarios)
                 {
                     if (dbControl.isAdmin(funcionario.Id))
                         this.Text = "Painel de Controle - Bem-vindo " + funcionario.Name;
                     break;
                 }
                 
                 dataGridView_funcionarios.Columns["PhotoName"].Visible = false;
                 dataGridView_funcionarios.Columns["Id"].Visible = false;
                 dataGridView_funcionarios.Columns["Active"].Visible = false;
                 dataGridView_funcionarios.Columns["Name"].HeaderText = "Nome";
                 dataGridView_funcionarios.Columns["Working"].HeaderText = "Trabalhando";
                 dataGridView_funcionarios.Rows[0].Selected = false;
                 //(dataGridView_funcionarios.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", "Name");
             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message);
             }
         }
         void httpRequest_httpRequestComplete(object obj, HttpUtilsEventArgs e)
         {
             // atualizarToolStripMenuItem.Enabled = ((HttpToolRequest)sender as HttpToolRequest).result;
             try
             {
                 //  atualizarToolStripMenuItem.Enabled = e.Update;
                 updateDelegate = new UpdateButtonAtualizarDelegate(updateButtonAtualizar);
                 this.Invoke(updateDelegate, e.Update,e.Version);
             }
             catch (Exception erro)
             { MessageBox.Show(erro.Message, "Catch invoke"); }
         }
        private void updateButtonAtualizar(bool update,string version)
         {
             atualizarToolStripMenuItem.Visible = update; 
             atualizarToolStripMenuItem.ToolTipText = "Atualizar para versão " + version;
         }
         
        private void fillFields()
        {
            editing = true;
            txt_nome.Text = funcionario.Name;
            //lba_safefilename.Text = funcionario.PhotoName;
            photo.ImageLocation = Application.StartupPath+"\\fotos\\" + funcionario.PhotoName;
            cb_ativo.Checked = funcionario.Active;
            btn_cadastrar.Text = "Editar";
            btn_geraCracha.Enabled = true;
            btn_novo.Enabled = true;
            gb_horas.Visible = true;
            btn_fechar.Enabled = funcionario.Working;
            rb_npagos.Checked = true;
            lba_chour.Text = "";
            refreshHours();

        }
        private void refreshHours()
        {
            if (rb_npagos.Checked)
            {
               showInWork();
            }
            if (rb_pagos.Checked)
            {
                btn_relatorio.Enabled = false;
                salvarToolStripMenuItem.Enabled = false;
                exportarExcelToolStripMenuItem.Enabled = false;
                showPaid();
            }
            if (rb_tudos.Checked)
            {
                btn_relatorio.Enabled = false;
                salvarToolStripMenuItem.Enabled = false;
                exportarExcelToolStripMenuItem.Enabled = false;
                showAll();
            }
           // activeBtn_pagar();
           
            btn_corrigir_data.Enabled = false;
        }
        private void openFile()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = Cadastre.detailsDir;
            of.Filter = "Relatórios (*.bon)|*.bon;";
            if (of.ShowDialog() == DialogResult.OK)
                new Relatorio(of.FileName).ShowDialog();
        }
        private void refreshDatePickers()
        {  
            if (rb_npagos.Checked)
            {
                DateTime startDate = dbControl.getFirstDatePeriod(funcionario.Id,"n", true).Date;
                DateTime endDate = dbControl.getFirstDatePeriod(funcionario.Id, "n", false).Date;
                try
                {
                    dateTime_final.MinDate =  startDate;
                    dateTime_iniciar.MinDate = startDate;
                }
                catch
                { }
                try
                {
                    dateTime_iniciar.Value = startDate;
                    //dateTime_iniciar.MinDate = periods[0].StartDate.Date;
                    dateTime_final.Value = endDate;
                }
                catch
                { }
               
                dateTime_iniciar.Enabled = false;
                dateTime_final.Enabled = true;
            }
            if (rb_pagos.Checked)
            {
                DateTime startDate = dbControl.getFirstDatePeriod(funcionario.Id, "y", true).Date;
                DateTime endDate = dbControl.getFirstDatePeriod(funcionario.Id, "y", false).Date;
                dateTime_iniciar.Enabled = dateTime_final.Enabled = true;
               try
                {
                    dateTime_iniciar.MinDate = startDate;
               
                    dateTime_final.MinDate = startDate;
                  }
                catch
                { }
                try
                {
                    dateTime_iniciar.Value = startDate;
                    dateTime_final.Value = endDate;
                }
                catch 
                { }
               
            }
            if (rb_tudos.Checked)
            {
                DateTime startDate = dbControl.getFirstDatePeriod(funcionario.Id, "", true).Date;
                DateTime endDate = dbControl.getFirstDatePeriod(funcionario.Id, "", false).Date;
                try
                {
                    dateTime_iniciar.MinDate = startDate;
                    dateTime_final.MinDate = startDate;
                  }
                catch
                { }
                try
                {
                    dateTime_iniciar.Value = startDate;
                    dateTime_final.Value = endDate;
                 }
                catch
                { }
               
                dateTime_iniciar.Enabled = dateTime_final.Enabled = true;
            }
            refreshHours();
               
        }
        private string checkValue(string value)
        {
            Match m = mValue.Match(value);
            return m.Result("$1");
        }
        private void resetFields()
        {
            editing = false;
            txt_nome.Text = "";
            //lba_safefilename.Text = "";
            photo.Image = null;
            photo.ImageLocation = string.Empty;
            btn_cadastrar.Text = "Cadastrar";
            btn_geraCracha.Enabled = false;
            btn_novo.Enabled = false;
            gb_horas.Visible = false;
            cb_ativo.Checked = true;
        }
        private void showPaid()
        {//Temos que mudar isso 
            if (rb_pagos.Checked)
            {
                
                btn_pagar.Enabled = false;
                periods.Clear();
                string startDate = dateTime_iniciar.Value.ToString("yyyy-MM-dd");
                string endDate = dateTime_final.Value.ToString("yyyy-MM-dd");
                periods = dbControl.getPayPeriodsInInterval(funcionario.Id,startDate,endDate);
                lba_inwork_msg.Text = dateTime_iniciar.Value.ToShortDateString() + " à " + dateTime_final.Value.ToShortDateString() + " - Mostrando períodos pagos";
              //  if (periods.Count > 0)
               // {
                    
              //  }
                //gera um bug
                //dateTime_iniciar.Value = dateTime_iniciar.MinDate;
                
                hoursList.Clear();
                fillPeriods();
                periods.Sort();
                foreach (Period period in periods)
                {
                    hoursList.AddRange(period.ListHours);
                    hoursList.Sort();
                }
                // hoursList = periods

                //Faz laço infinito, pq?
                //foreach (Period period in periods)
                // {
                //     period.autoFillHours();
                // }
                if (periods.Count > 0)
                {
                    fillDataGridViewHorarios();
                    panel_inwork.Visible = true;
                }
                else
                    panel_inwork.Visible = false;
            }
        }
        private void fillDataGridViewHorarios()
        {
            dataGridView_horarios.DataSource = periods;
            dataGridView_horarios.Columns["StartDate"].HeaderText = "Horário Inicial";
            dataGridView_horarios.Columns["EndDate"].HeaderText = "Horário Final";
            dataGridView_horarios.Columns["PayDate"].HeaderText = "Data Pagamento";
            dataGridView_horarios.Columns["Paid"].HeaderText = "Pago";
            dataGridView_horarios.Columns["TotalHours"].HeaderText = "Total de horas";
            dataGridView_horarios.Columns["TotalValue"].HeaderText = "Valor Total";
            dataGridView_horarios.Columns["Id"].Visible = false;
            dataGridView_horarios.Columns["WorkerId"].Visible = false;
            dataGridView_horarios.Columns["Worker"].Visible = false;
            dataGridView_horarios.Columns["Status"].Visible = false;
            dataGridView_horarios.Columns["ValueHour"].HeaderText = "Valor da hora";
            
            dataGridView_horarios.Rows[0].Selected = false;
        }
        private void showAll()
        {//temos que mudar isso
            if (rb_tudos.Checked)
            {
                
                btn_pagar.Enabled = false;
               
                periods.Clear();
                periods = dbControl.getAllPeriods(funcionario.Id);
               // if (periods.Count > 0)
               // {
                   
              //  }

                lba_inwork_msg.Text = dateTime_iniciar.Value.ToShortDateString() + " à " + dateTime_final.Value.ToShortDateString() + " - Mostrando todos os períodos trabalhados";
                
                hoursList.Clear();
                hoursList = dbControl.inWork(funcionario.Id);
               // fillPeriods();
                periods.Sort();
                foreach (Period period in periods)
                { 
                    
                    //hoursList.Sort();
                   // hoursList.AddRange(period.ListHours);
                    //period.addListHours(hoursList);
                    period.autoFillHours();
                   
                }

               // if (hoursList.Count > 0)
                if(periods.Count>0) 
                {
                    fillDataGridViewHorarios();
                    panel_inwork.Visible = true;
                   
                }
                else
                    panel_inwork.Visible = false;
            }
        }
        private void showInWork()
        {
            selectedPeriod = null;
            
            if (rb_npagos.Checked)
            {
                fillHoras();
                calculateValue();
               // dateTime_iniciar.Enabled = dateTime_final.Enabled = false;
               
                periods.Clear();
                periods = dbControl.getNotPayPeriods(funcionario.Id);
                
                if (periods.Count > 0)
                {
                    selectedPeriod = periods[0];
                   
                }
                //gera um bug
                // dateTime_iniciar.Value = dateTime_iniciar.MinDate;
                if(selectedPeriod==null)
                {
                    rb_pagos.Checked = true;
                    return;
                }
                hoursList.Clear();
                selectedPeriod.ListHours.Clear();
                hoursList = dbControl.inWork(funcionario.Id);
                //string hourCorr = "";
                if(hoursList.Count >0)
                {
                    int cont = 0;
                    foreach(Hours hour in hoursList)
                    {
                        if(hour.Start.Date <= dateTime_final.Value.Date)
                        {
                            cont++;
                        }
                    }
                    if (cont > 0)
                    {
                        btn_pagar.Enabled = false;
                       // hourCorr = " " + hoursList.Count + " Horários para corrigir.";
                        lba_chour.Text = string.Format("Horários não finalizados devem ser corrigidos: {0} Horários para corrigir.", hoursList.Count);
                    }
                    else
                    {
                        btn_pagar.Enabled = true;
                        lba_chour.Text = "";
                        //hourCorr = "";
                    }
                }
                else
                {
                    btn_pagar.Enabled = true;
                }

                if (selectedPeriod == null)
                {
                    lba_inwork_msg.Text = dateTime_iniciar.Value.ToShortDateString() + " à " + dateTime_final.Value.ToShortDateString() + " - Lista com horários deste intervalo.";
                    //lba_chour.Text = string.Format("Horários não finalizados devem ser corrigidos.", hourCorr);
                }
                else
                {
                    lba_inwork_msg.Text = periods[0].StartDate.ToShortDateString() + " à " + dateTime_final.Value.ToShortDateString() + " - Lista com horários deste intervalo.";
                   // lba_chour.Text = string.Format("Horários não finalizados devem ser corrigidos.", hourCorr);
                }
                hoursList.AddRange(dbControl.inWorked(funcionario.Id, periods[0].StartDate.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd")));
                hoursList.Sort();
                if (hoursList.Count > 0)
                {
                    List<RelatorioItem> relatorioItems = new List<RelatorioItem>();
                    foreach (Hours hour in hoursList)
                    {
                        relatorioItems.Add(new RelatorioItem(hour, selectedPeriod.Paid));
                    }

                    dataGridView_horarios.DataSource = relatorioItems;

                    dataGridView_horarios.Columns["DayOfWeek"].HeaderText = "Dia da semana";
                    dataGridView_horarios.Columns["DateString"].HeaderText = "Data";
                    dataGridView_horarios.Columns["StartHour"].HeaderText = "Horário Inicial";
                    dataGridView_horarios.Columns["EndHour"].HeaderText = "Horário Final";
                    dataGridView_horarios.Columns["HourWorked"].HeaderText = "Tempo Trabalhado";
                    dataGridView_horarios.Columns["StatusString"].HeaderText = "Pagamento";
                    dataGridView_horarios.Columns["Status"].Visible = false;
                    dataGridView_horarios.Columns["HourId"].Visible = false;
                    dataGridView_horarios.Columns["DateStart"].Visible = false;
                    dataGridView_horarios.Columns["DateEnd"].Visible = false;
                    //dataGridView_horarios.DataSource = hoursList;
                    //dataGridView_horarios.Columns["Start"].HeaderText = "Horário Inicial";
                    //dataGridView_horarios.Columns["End"].HeaderText = "Horário Final";
                    //dataGridView_horarios.Columns["Id"].Visible = false;
                    btn_relatorio.Enabled = true;
                    salvarToolStripMenuItem.Enabled = true;
                    exportarExcelToolStripMenuItem.Enabled = true;
                   // btn_pagar.Enabled = false;
                    panel_inwork.Visible = true;
                    dataGridView_horarios.Rows[0].Selected = false;
                   
                    selectedPeriod.ListHours = hoursList;
                   // lba_valor_total.Text = selectedPeriod.TotalValue;
                }
                else
                {
                   // btn_pagar.Enabled = true;
                    panel_inwork.Visible = false;
                }
            }
        }
        private void fillHoras()
        {
            dateTime_final.MinDate = dateTime_iniciar.Value;
            try
            {
                TimeSpan timer = dbControl.getSumHours(funcionario.Id,dateTime_iniciar.Value.ToString("yyyy-MM-dd"),dateTime_final.Value.ToString("yyyy-MM-dd"));
                totalHours = timer.TotalHours;
                lba_horas.Text = totalHours.ToString("0.00");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void finalizeWorkerHour()
        {
            if(dbControl.endTime(funcionario.Id))
            {
                funcionarios.UpdateItem(funcionario.Id, false);
                fillGridWorkers();
            }

            //dataGridView_funcionarios.DataSource = dbControl.getAllWorkers();
            btn_fechar.Enabled = false;
            if (btn_fechar_click != null)
                btn_fechar_click(null, null);
        }



        private void calculateValue()
        {
            string text = txt_valor_hora.Text;
            txt_valor_hora.Text = checkValue(text);
            txt_valor_hora.SelectionStart =text.Length;
           
             try
                {
                    valorHora = decimal.Parse(txt_valor_hora.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands);
                    
                }
                catch (Exception erro)
                {
                    lba_valor_total.Text = erro.Message;
                }
           lba_valor_total.Text = (totalHours * (double)valorHora).ToString("C2");
        }

        private void fillPeriods()
        {

            foreach (Period period in periods)
            {
                period.ListHours = fillHoursList();
            }
        }
        private void fillSelectedPeriod(bool all)
        {
            //Mudando aqui 
            selectedPeriod.ListHours = dbControl.inWorked(funcionario.Id, selectedPeriod.StartDate.ToString("yyyy-MM-dd HH:mm:ss"), selectedPeriod.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if(!selectedPeriod.Paid)
                selectedPeriod.ListHours.AddRange(dbControl.inWork(funcionario.Id));
            selectedPeriod.ListHours.Sort();
        }
        private List<Hours> fillHoursList()
        {
            List<Hours> horarios = dbControl.inWorked(funcionario.Id, dateTime_iniciar.Value.ToString("yyyy-MM-dd HH:mm:ss"),dateTime_final.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            horarios.Sort();
            return horarios;
        }

        private void activeBtn_pagar()
        {
            if (hoursList.Count == 0 && rb_npagos.Checked)
                btn_pagar.Enabled = true;
            else
                btn_pagar.Enabled = false;
        }
    }
}
