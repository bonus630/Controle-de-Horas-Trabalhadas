using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using br.corp.bonus630.FullText;
using br.corp.bonus630.ControleHorasTrabalhadas.Controllers;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public partial class Relatorio : Form
    {
        private List<RelatorioItem> relatorioItems = new List<RelatorioItem>();
        private Bitmap imagePrint;
        private Period period;
        public Relatorio(List<RelatorioItem> listRelatorioItem)
        {
            InitializeComponent();
            dataGridView1.DataSource = listRelatorioItem;
            for(int i = 0;i<dataGridView1.RowCount;i++)
            {
              //  if(i%2==0)
                   // dataGridView1.Rows[i].
            }
         
        }
        public Relatorio(string filepath)
        {
            InitializeComponent();
            process(loadFile(filepath));
        }
        public Relatorio(Period period)
        {
            InitializeComponent();
            this.period = period;
            this.process(period);
        }
        public Relatorio(Period period,double valueHour)
        {
            InitializeComponent();
            this.period = period;
            this.period.ValueHour = valueHour;
            this.process(period);
        }
        private void process(Period period)
        {
            this.ClientSize = new Size(823, Screen.PrimaryScreen.WorkingArea.Height);
            People worker = period.Worker;
            if (period.ListHours.Count > 0)
            {
                foreach (Hours hour in period.ListHours)
                {
                    relatorioItems.Add(new RelatorioItem(hour, period.Paid));
                }
                
                dataGridView1.DataSource = relatorioItems;
               
                dataGridView1.Columns["DayOfWeek"].HeaderText = "Dia da semana";
                dataGridView1.Columns["DateString"].HeaderText = "Data";
                dataGridView1.Columns["StartHour"].HeaderText = "Horário Inicial";
                dataGridView1.Columns["EndHour"].HeaderText = "Horário Final";
                dataGridView1.Columns["HourWorked"].HeaderText = "Tempo Trabalhado";
                dataGridView1.Columns["StatusString"].HeaderText = "Pagamento";
                dataGridView1.Columns["Status"].Visible = false;
                dataGridView1.Columns["HourId"].Visible = false;
                dataGridView1.Columns["DateStart"].Visible = false;
                dataGridView1.Columns["DateEnd"].Visible = false;
                lba_message.Text = "Lista de Horários:";
            }
            else
            {
                dataGridView1.Visible = false;
                this.lba_message.Text = "Nenhum horário nesse período";
            }
            this.lba_empresa_nome.Text = Properties.Settings.Default.nomeEmpresa;
            picture_box_logo.ImageLocation = Application.StartupPath+"\\logo.jpg";
            this.lba_date.Text = "De " + period.StartDate.ToShortDateString() + " à " + period.EndDate.ToShortDateString();
            lba_name.Text = worker.Name;
            lba_hours.Text = period.TotalHours;
            lba_value.Text = period.TotalValue;
            this.Text = this.Text + " de " + worker.Name + " " + lba_date.Text;
            if (period.totalValue() > 0)
            {
                ToFullText toFullText = new ToFullText();
                try
                {
                    lba_fullText.Text = "(" + toFullText.showText(period.totalValue()) + ")";
                }
                catch (ArgumentException erro)
                {
                    lba_fullText.Text = erro.Message;
                }
            }
            panel_area_impressao.Update();
        }
        public Relatorio(List<Period> periods)
        {
            InitializeComponent();
            foreach (Period period in periods)
            {
                foreach (Hours hour in period.ListHours)
                {
                    relatorioItems.Add(new RelatorioItem(hour,period.Paid));
                }
            }
            dataGridView1.DataSource = relatorioItems;
        }

        private void drawImage()
        {
            dataGridView1.Rows[0].Selected = false;
           imagePrint = new Bitmap(2480, 3508);
            panel_area_impressao.DrawToBitmap(imagePrint, new Rectangle(0, 0, panel_area_impressao.Bounds.Width, panel_area_impressao.Bounds.Height));
            //imagePrint.Save("teste.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            drawImage();
            printDialog1.Document = printDocument1;
            if(printDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private Period loadFile(string filepath)
        {
            Period period = SaveLoad.load(filepath);
            return period;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(imagePrint, 0, 0);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.P)
            {
                btn_imprimir_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "bon";
            sfd.InitialDirectory = Cadastre.detailsDir;
            sfd.Filter = "Relatórios (*.bon)|*.bon";
            sfd.FileName = this.period.StartDate.ToString("dd-MM-yyyy") + "-" + this.period.Worker.Name.Replace(" ", "-").ToLower() + this.period.Worker.Id + "-" + this.period.Id + ".bon";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                SaveLoad.save(sfd.FileName, this.period);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btn_imprimir_Click(null, null);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btn_cancel_Click(null, null);
        }

    }
}
