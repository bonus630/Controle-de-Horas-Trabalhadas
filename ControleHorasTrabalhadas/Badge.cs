using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using br.corp.bonus630.ControleHorasTrabalhadas.badgeCreator;
using br.corp.bonus630.ControleHorasTrabalhadas.Controllers;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public partial class Badge : Form
    {
        private BadgeCreator bc;
        public Badge(People funcionario)
        {
            InitializeComponent();
            bc = new BadgeCreator(new Size(315, 472));
            bc.Code = funcionario.Id;
            bc.Name = funcionario.Name;
            bc.PhotoName = funcionario.PhotoName;
            bc.NomeEmpresa = Properties.Settings.Default.nomeEmpresa;
            bc.StartupPath = Application.StartupPath;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }

        private void Badge_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bc.getImageReady();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_font_color_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                btn_font_color.BackColor = colorDialog1.Color;
                pictureBox1.Image = bc.getImageReady(colorDialog1.Color);
            }
        }

        private void Badge_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.P)
            {
                button1_Click(null, null);
            }
        }
    }
}
