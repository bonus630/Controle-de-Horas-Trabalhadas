namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txt_bar_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_login = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_entrar = new System.Windows.Forms.Button();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.lba_bemVindo = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lba_nome = new System.Windows.Forms.Label();
            this.flowLayout_trabalhando = new System.Windows.Forms.FlowLayoutPanel();
            this.lba_trabalhando = new System.Windows.Forms.Label();
            this.panel_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_bar_code
            // 
            this.txt_bar_code.Location = new System.Drawing.Point(90, 12);
            this.txt_bar_code.MaxLength = 8;
            this.txt_bar_code.Name = "txt_bar_code";
            this.txt_bar_code.Size = new System.Drawing.Size(100, 20);
            this.txt_bar_code.TabIndex = 0;
            this.txt_bar_code.TextChanged += new System.EventHandler(this.txt_bar_code_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seu Código.:";
            // 
            // panel_login
            // 
            this.panel_login.Controls.Add(this.button1);
            this.panel_login.Controls.Add(this.label2);
            this.panel_login.Controls.Add(this.btn_entrar);
            this.panel_login.Controls.Add(this.txt_senha);
            this.panel_login.Location = new System.Drawing.Point(6, 38);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(184, 64);
            this.panel_login.TabIndex = 4;
            this.panel_login.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Senha.:";
            // 
            // btn_entrar
            // 
            this.btn_entrar.Location = new System.Drawing.Point(84, 34);
            this.btn_entrar.Name = "btn_entrar";
            this.btn_entrar.Size = new System.Drawing.Size(43, 23);
            this.btn_entrar.TabIndex = 6;
            this.btn_entrar.Text = "Entrar";
            this.btn_entrar.UseVisualStyleBackColor = true;
            this.btn_entrar.Click += new System.EventHandler(this.btn_entrar_Click);
            // 
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(84, 8);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '*';
            this.txt_senha.Size = new System.Drawing.Size(100, 20);
            this.txt_senha.TabIndex = 5;
            this.txt_senha.UseSystemPasswordChar = true;
            // 
            // lba_bemVindo
            // 
            this.lba_bemVindo.AutoSize = true;
            this.lba_bemVindo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_bemVindo.Location = new System.Drawing.Point(4, 44);
            this.lba_bemVindo.Name = "lba_bemVindo";
            this.lba_bemVindo.Size = new System.Drawing.Size(0, 16);
            this.lba_bemVindo.TabIndex = 5;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(42, 112);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(148, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://bonus630.tk/d/141";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Visite";
            // 
            // lba_nome
            // 
            this.lba_nome.AutoSize = true;
            this.lba_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_nome.Location = new System.Drawing.Point(4, 73);
            this.lba_nome.Name = "lba_nome";
            this.lba_nome.Size = new System.Drawing.Size(0, 16);
            this.lba_nome.TabIndex = 5;
            // 
            // flowLayout_trabalhando
            // 
            this.flowLayout_trabalhando.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayout_trabalhando.Location = new System.Drawing.Point(207, 30);
            this.flowLayout_trabalhando.Name = "flowLayout_trabalhando";
            this.flowLayout_trabalhando.Size = new System.Drawing.Size(117, 98);
            this.flowLayout_trabalhando.TabIndex = 8;
            this.flowLayout_trabalhando.Visible = false;
            // 
            // lba_trabalhando
            // 
            this.lba_trabalhando.AutoSize = true;
            this.lba_trabalhando.Location = new System.Drawing.Point(206, 12);
            this.lba_trabalhando.Name = "lba_trabalhando";
            this.lba_trabalhando.Size = new System.Drawing.Size(103, 13);
            this.lba_trabalhando.TabIndex = 0;
            this.lba_trabalhando.Text = "Trabalhando agora.:";
            this.lba_trabalhando.Visible = false;
            // 
            // Main
            // 
            this.AcceptButton = this.btn_entrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 137);
            this.Controls.Add(this.lba_trabalhando);
            this.Controls.Add(this.flowLayout_trabalhando);
            this.Controls.Add(this.panel_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lba_nome);
            this.Controls.Add(this.lba_bemVindo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_bar_code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Conectando ao banco de dados  ...";
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_bar_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_entrar;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Label lba_bemVindo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lba_nome;
        private System.Windows.Forms.FlowLayoutPanel flowLayout_trabalhando;
        private System.Windows.Forms.Label lba_trabalhando;
        private System.Windows.Forms.Button button1;

    }
}