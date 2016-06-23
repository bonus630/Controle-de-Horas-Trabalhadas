namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    partial class Confirmation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lba_mensagem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_sim = new System.Windows.Forms.Button();
            this.btn_nao = new System.Windows.Forms.Button();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lba_message2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lba_mensagem
            // 
            this.lba_mensagem.AutoSize = true;
            this.lba_mensagem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_mensagem.ForeColor = System.Drawing.Color.DarkRed;
            this.lba_mensagem.Location = new System.Drawing.Point(15, 38);
            this.lba_mensagem.Name = "lba_mensagem";
            this.lba_mensagem.Size = new System.Drawing.Size(201, 13);
            this.lba_mensagem.TabIndex = 0;
            this.lba_mensagem.Text = "Está é uma operação irreversível.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(16, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Deseja continuar?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Senha.:";
            // 
            // btn_sim
            // 
            this.btn_sim.Location = new System.Drawing.Point(12, 113);
            this.btn_sim.Name = "btn_sim";
            this.btn_sim.Size = new System.Drawing.Size(75, 23);
            this.btn_sim.TabIndex = 1;
            this.btn_sim.Text = "Sim";
            this.btn_sim.UseVisualStyleBackColor = true;
            this.btn_sim.Click += new System.EventHandler(this.btn_sim_Click);
            // 
            // btn_nao
            // 
            this.btn_nao.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_nao.Location = new System.Drawing.Point(93, 113);
            this.btn_nao.Name = "btn_nao";
            this.btn_nao.Size = new System.Drawing.Size(75, 23);
            this.btn_nao.TabIndex = 2;
            this.btn_nao.Text = "Não";
            this.btn_nao.UseVisualStyleBackColor = true;
            this.btn_nao.Click += new System.EventHandler(this.btn_nao_Click);
            // 
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(65, 85);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '*';
            this.txt_senha.Size = new System.Drawing.Size(100, 20);
            this.txt_senha.TabIndex = 0;
            this.txt_senha.TextChanged += new System.EventHandler(this.txt_senha_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 34);
            this.panel1.TabIndex = 3;
            // 
            // lba_message2
            // 
            this.lba_message2.AutoSize = true;
            this.lba_message2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_message2.ForeColor = System.Drawing.Color.DarkRed;
            this.lba_message2.Location = new System.Drawing.Point(15, 60);
            this.lba_message2.Name = "lba_message2";
            this.lba_message2.Size = new System.Drawing.Size(201, 13);
            this.lba_message2.TabIndex = 0;
            this.lba_message2.Text = "Está é uma operação irreversível.";
            this.lba_message2.Visible = false;
            // 
            // Confirmation
            // 
            this.AcceptButton = this.btn_sim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_nao;
            this.ClientSize = new System.Drawing.Size(226, 144);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_senha);
            this.Controls.Add(this.btn_nao);
            this.Controls.Add(this.btn_sim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lba_message2);
            this.Controls.Add(this.lba_mensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(239, 154);
            this.Name = "Confirmation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Confirmação";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lba_mensagem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_sim;
        private System.Windows.Forms.Button btn_nao;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lba_message2;
    }
}