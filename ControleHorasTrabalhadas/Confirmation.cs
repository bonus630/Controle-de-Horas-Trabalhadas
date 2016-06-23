using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public partial class Confirmation : Form
    {

        private bool result = false;
        public bool Result { get { return this.result; } }
        public Confirmation()
        {
            InitializeComponent();
            txt_senha.Focus();
        }
        public Confirmation(string msg)
        {
            InitializeComponent();
            txt_senha.Focus();
            this.lba_mensagem.Text = msg;
            this.Width = lba_mensagem.Width + 40;
        }
        public Confirmation(string day,string hours)
        {
            InitializeComponent();
            txt_senha.Focus();
            this.lba_mensagem.Text = day;
            this.lba_message2.Text = hours;
            this.lba_message2.Visible = true;
            this.Width = lba_message2.Width + 40;
        }
        private void btn_sim_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.adminPassword == txt_senha.Text)
            {
                
                result = true;
                this.Dispose();
            }
            else
            {
                txt_senha.Text = "";
                txt_senha.Focus();
            }
        }

        private void btn_nao_Click(object sender, EventArgs e)
        {
            
            result = false;
            this.Dispose();
        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.adminPassword == txt_senha.Text)
            {
                this.btn_sim.DialogResult = DialogResult.Yes;
            }
            else
                this.btn_sim.DialogResult = DialogResult.None;

        }
    }
}
