namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    partial class Config
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
            this.btn_salvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nomeEmpresa = new System.Windows.Forms.TextBox();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.txt_resenha = new System.Windows.Forms.TextBox();
            this.btn_logo = new System.Windows.Forms.Button();
            this.lba_logo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_senha = new System.Windows.Forms.CheckBox();
            this.btn_dir_details = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lba_test = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_dbuser = new System.Windows.Forms.TextBox();
            this.txt_dbserver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dbpassword = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(420, 337);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_salvar.TabIndex = 0;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Empresa.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Senha.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Re-senha.:";
            // 
            // txt_nomeEmpresa
            // 
            this.txt_nomeEmpresa.Location = new System.Drawing.Point(93, 17);
            this.txt_nomeEmpresa.Name = "txt_nomeEmpresa";
            this.txt_nomeEmpresa.Size = new System.Drawing.Size(185, 20);
            this.txt_nomeEmpresa.TabIndex = 0;
            // 
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(93, 45);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '*';
            this.txt_senha.Size = new System.Drawing.Size(185, 20);
            this.txt_senha.TabIndex = 1;
            this.txt_senha.UseSystemPasswordChar = true;
            // 
            // txt_resenha
            // 
            this.txt_resenha.Location = new System.Drawing.Point(93, 73);
            this.txt_resenha.Name = "txt_resenha";
            this.txt_resenha.PasswordChar = '*';
            this.txt_resenha.Size = new System.Drawing.Size(185, 20);
            this.txt_resenha.TabIndex = 2;
            this.txt_resenha.UseSystemPasswordChar = true;
            // 
            // btn_logo
            // 
            this.btn_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_logo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logo.Location = new System.Drawing.Point(300, 15);
            this.btn_logo.Name = "btn_logo";
            this.btn_logo.Size = new System.Drawing.Size(177, 130);
            this.btn_logo.TabIndex = 3;
            this.btn_logo.Text = "Clique aqui para carregar sua Logo";
            this.btn_logo.UseVisualStyleBackColor = true;
            this.btn_logo.Click += new System.EventHandler(this.btn_logo_Click);
            // 
            // lba_logo
            // 
            this.lba_logo.AutoSize = true;
            this.lba_logo.Location = new System.Drawing.Point(31, 109);
            this.lba_logo.Name = "lba_logo";
            this.lba_logo.Size = new System.Drawing.Size(0, 13);
            this.lba_logo.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_senha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_dir_details);
            this.groupBox1.Controls.Add(this.btn_logo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_resenha);
            this.groupBox1.Controls.Add(this.txt_nomeEmpresa);
            this.groupBox1.Controls.Add(this.txt_senha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 161);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Admin";
            // 
            // cb_senha
            // 
            this.cb_senha.AutoSize = true;
            this.cb_senha.Location = new System.Drawing.Point(22, 126);
            this.cb_senha.Name = "cb_senha";
            this.cb_senha.Size = new System.Drawing.Size(127, 17);
            this.cb_senha.TabIndex = 8;
            this.cb_senha.Text = "Pedir senha ao iniciar";
            this.cb_senha.UseVisualStyleBackColor = true;
            // 
            // btn_dir_details
            // 
            this.btn_dir_details.Location = new System.Drawing.Point(174, 122);
            this.btn_dir_details.Name = "btn_dir_details";
            this.btn_dir_details.Size = new System.Drawing.Size(104, 23);
            this.btn_dir_details.TabIndex = 3;
            this.btn_dir_details.Text = "Diretório Relatórios";
            this.btn_dir_details.UseVisualStyleBackColor = true;
            this.btn_dir_details.Click += new System.EventHandler(this.btn_dir_details_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lba_test);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_dbuser);
            this.groupBox2.Controls.Add(this.txt_dbserver);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_dbpassword);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 153);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados Mysql";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Testar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lba_test
            // 
            this.lba_test.AutoSize = true;
            this.lba_test.Location = new System.Drawing.Point(90, 123);
            this.lba_test.Name = "lba_test";
            this.lba_test.Size = new System.Drawing.Size(0, 13);
            this.lba_test.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Server.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Usúario.:";
            // 
            // txt_dbuser
            // 
            this.txt_dbuser.Location = new System.Drawing.Point(93, 57);
            this.txt_dbuser.Name = "txt_dbuser";
            this.txt_dbuser.Size = new System.Drawing.Size(185, 20);
            this.txt_dbuser.TabIndex = 1;
            // 
            // txt_dbserver
            // 
            this.txt_dbserver.Location = new System.Drawing.Point(93, 27);
            this.txt_dbserver.Name = "txt_dbserver";
            this.txt_dbserver.Size = new System.Drawing.Size(185, 20);
            this.txt_dbserver.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Senha.:";
            // 
            // txt_dbpassword
            // 
            this.txt_dbpassword.Location = new System.Drawing.Point(93, 87);
            this.txt_dbpassword.Name = "txt_dbpassword";
            this.txt_dbpassword.PasswordChar = '*';
            this.txt_dbpassword.Size = new System.Drawing.Size(185, 20);
            this.txt_dbpassword.TabIndex = 2;
            this.txt_dbpassword.UseSystemPasswordChar = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 337);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 367);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lba_logo);
            this.Controls.Add(this.btn_salvar);
            this.Name = "Config";
            this.Text = "Configurações";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nomeEmpresa;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.TextBox txt_resenha;
        private System.Windows.Forms.Button btn_logo;
        private System.Windows.Forms.Label lba_logo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_dbuser;
        private System.Windows.Forms.TextBox txt_dbserver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_dbpassword;
        private System.Windows.Forms.Button btn_dir_details;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cb_senha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lba_test;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}