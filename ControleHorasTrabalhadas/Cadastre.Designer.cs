namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    partial class Cadastre
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.lba_nome = new System.Windows.Forms.Label();
            this.btn_geraCracha = new System.Windows.Forms.Button();
            this.lba_safefilename = new System.Windows.Forms.Label();
            this.btn_novo = new System.Windows.Forms.Button();
            this.photo = new System.Windows.Forms.PictureBox();
            this.lba_horas = new System.Windows.Forms.Label();
            this.dateTime_iniciar = new System.Windows.Forms.DateTimePicker();
            this.gb_horas = new System.Windows.Forms.GroupBox();
            this.gb_status = new System.Windows.Forms.GroupBox();
            this.rb_tudos = new System.Windows.Forms.RadioButton();
            this.rb_npagos = new System.Windows.Forms.RadioButton();
            this.rb_pagos = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.lba_valor_total = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_valor_hora = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTime_final = new System.Windows.Forms.DateTimePicker();
            this.btn_pagar = new System.Windows.Forms.Button();
            this.btn_relatorio = new System.Windows.Forms.Button();
            this.cb_ativo = new System.Windows.Forms.CheckBox();
            this.panel_inwork = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_open = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_corrigir_data = new System.Windows.Forms.Button();
            this.dateTimePicker_cor_final_day = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_cor_inicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_cor_final = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_horarios = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel_msg = new System.Windows.Forms.FlowLayoutPanel();
            this.lba_inwork_msg = new System.Windows.Forms.Label();
            this.lba_chour = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_funcionarios = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.gb_horas.SuspendLayout();
            this.gb_status.SuspendLayout();
            this.panel_inwork.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_horarios)).BeginInit();
            this.flowLayoutPanel_msg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_funcionarios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Foto:";
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(43, 27);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(315, 20);
            this.txt_nome.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txt_nome, "Digite o nome do funcionário");
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.Location = new System.Drawing.Point(293, 99);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(64, 36);
            this.btn_cadastrar.TabIndex = 3;
            this.btn_cadastrar.Text = "Cadastrar";
            this.toolTip1.SetToolTip(this.btn_cadastrar, "Salva os dados preenchidos nos campos.");
            this.btn_cadastrar.UseVisualStyleBackColor = true;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // lba_nome
            // 
            this.lba_nome.AutoSize = true;
            this.lba_nome.Location = new System.Drawing.Point(15, 419);
            this.lba_nome.Name = "lba_nome";
            this.lba_nome.Size = new System.Drawing.Size(0, 13);
            this.lba_nome.TabIndex = 4;
            // 
            // btn_geraCracha
            // 
            this.btn_geraCracha.Enabled = false;
            this.btn_geraCracha.Location = new System.Drawing.Point(293, 141);
            this.btn_geraCracha.Name = "btn_geraCracha";
            this.btn_geraCracha.Size = new System.Drawing.Size(64, 36);
            this.btn_geraCracha.TabIndex = 7;
            this.btn_geraCracha.Text = "Crachá";
            this.toolTip1.SetToolTip(this.btn_geraCracha, "Gera o crachá do funcionário selecionado");
            this.btn_geraCracha.UseVisualStyleBackColor = true;
            this.btn_geraCracha.Click += new System.EventHandler(this.btn_geraCracha_Click);
            // 
            // lba_safefilename
            // 
            this.lba_safefilename.AutoSize = true;
            this.lba_safefilename.Location = new System.Drawing.Point(53, 52);
            this.lba_safefilename.Name = "lba_safefilename";
            this.lba_safefilename.Size = new System.Drawing.Size(0, 13);
            this.lba_safefilename.TabIndex = 0;
            // 
            // btn_novo
            // 
            this.btn_novo.Enabled = false;
            this.btn_novo.Location = new System.Drawing.Point(293, 57);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(64, 36);
            this.btn_novo.TabIndex = 3;
            this.btn_novo.Text = "Novo";
            this.toolTip1.SetToolTip(this.btn_novo, "Limpa os campos para inserir um novo funcionário.");
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Click += new System.EventHandler(this.btn_novo_Click);
            // 
            // photo
            // 
            this.photo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photo.Location = new System.Drawing.Point(41, 57);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(107, 134);
            this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo.TabIndex = 8;
            this.photo.TabStop = false;
            this.toolTip1.SetToolTip(this.photo, "Selecione a foto do funcionário");
            this.photo.Click += new System.EventHandler(this.photo_Click);
            // 
            // lba_horas
            // 
            this.lba_horas.AutoSize = true;
            this.lba_horas.Location = new System.Drawing.Point(216, 80);
            this.lba_horas.Name = "lba_horas";
            this.lba_horas.Size = new System.Drawing.Size(53, 13);
            this.lba_horas.TabIndex = 10;
            this.lba_horas.Text = "lba_horas";
            // 
            // dateTime_iniciar
            // 
            this.dateTime_iniciar.Enabled = false;
            this.dateTime_iniciar.Location = new System.Drawing.Point(72, 24);
            this.dateTime_iniciar.Name = "dateTime_iniciar";
            this.dateTime_iniciar.Size = new System.Drawing.Size(200, 20);
            this.dateTime_iniciar.TabIndex = 11;
            this.dateTime_iniciar.CloseUp += new System.EventHandler(this.dateTime_iniciar_CloseUp);
            // 
            // gb_horas
            // 
            this.gb_horas.Controls.Add(this.gb_status);
            this.gb_horas.Controls.Add(this.label9);
            this.gb_horas.Controls.Add(this.lba_valor_total);
            this.gb_horas.Controls.Add(this.label8);
            this.gb_horas.Controls.Add(this.txt_valor_hora);
            this.gb_horas.Controls.Add(this.label5);
            this.gb_horas.Controls.Add(this.label4);
            this.gb_horas.Controls.Add(this.label3);
            this.gb_horas.Controls.Add(this.dateTime_final);
            this.gb_horas.Controls.Add(this.dateTime_iniciar);
            this.gb_horas.Controls.Add(this.lba_horas);
            this.gb_horas.Location = new System.Drawing.Point(373, 28);
            this.gb_horas.Name = "gb_horas";
            this.gb_horas.Size = new System.Drawing.Size(456, 111);
            this.gb_horas.TabIndex = 12;
            this.gb_horas.TabStop = false;
            this.gb_horas.Text = "Exibir horas de determinada faixa de tempo.:";
            this.gb_horas.Visible = false;
            // 
            // gb_status
            // 
            this.gb_status.Controls.Add(this.rb_tudos);
            this.gb_status.Controls.Add(this.rb_npagos);
            this.gb_status.Controls.Add(this.rb_pagos);
            this.gb_status.Location = new System.Drawing.Point(284, 19);
            this.gb_status.Name = "gb_status";
            this.gb_status.Size = new System.Drawing.Size(166, 51);
            this.gb_status.TabIndex = 23;
            this.gb_status.TabStop = false;
            this.gb_status.Text = "Status";
            // 
            // rb_tudos
            // 
            this.rb_tudos.AutoSize = true;
            this.rb_tudos.Location = new System.Drawing.Point(6, 19);
            this.rb_tudos.Name = "rb_tudos";
            this.rb_tudos.Size = new System.Drawing.Size(55, 17);
            this.rb_tudos.TabIndex = 20;
            this.rb_tudos.Text = "Todos";
            this.toolTip1.SetToolTip(this.rb_tudos, "Exibe todos períodos");
            this.rb_tudos.UseVisualStyleBackColor = true;
            this.rb_tudos.CheckedChanged += new System.EventHandler(this.rb_tudos_CheckedChanged);
            // 
            // rb_npagos
            // 
            this.rb_npagos.AutoSize = true;
            this.rb_npagos.Location = new System.Drawing.Point(116, 19);
            this.rb_npagos.Name = "rb_npagos";
            this.rb_npagos.Size = new System.Drawing.Size(49, 17);
            this.rb_npagos.TabIndex = 22;
            this.rb_npagos.Text = "Atual";
            this.toolTip1.SetToolTip(this.rb_npagos, "Exibe período atual");
            this.rb_npagos.UseVisualStyleBackColor = true;
            this.rb_npagos.CheckedChanged += new System.EventHandler(this.rb_npagos_CheckedChanged);
            // 
            // rb_pagos
            // 
            this.rb_pagos.AutoSize = true;
            this.rb_pagos.Location = new System.Drawing.Point(61, 19);
            this.rb_pagos.Name = "rb_pagos";
            this.rb_pagos.Size = new System.Drawing.Size(55, 17);
            this.rb_pagos.TabIndex = 21;
            this.rb_pagos.Text = "Pagos";
            this.toolTip1.SetToolTip(this.rb_pagos, "Exibe períodos pagos");
            this.rb_pagos.UseVisualStyleBackColor = true;
            this.rb_pagos.CheckedChanged += new System.EventHandler(this.rb_pagos_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(281, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Valor Total.:";
            // 
            // lba_valor_total
            // 
            this.lba_valor_total.AutoSize = true;
            this.lba_valor_total.Location = new System.Drawing.Point(344, 80);
            this.lba_valor_total.Name = "lba_valor_total";
            this.lba_valor_total.Size = new System.Drawing.Size(13, 13);
            this.lba_valor_total.TabIndex = 17;
            this.lba_valor_total.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Valor Hora.:";
            // 
            // txt_valor_hora
            // 
            this.txt_valor_hora.Location = new System.Drawing.Point(72, 77);
            this.txt_valor_hora.Name = "txt_valor_hora";
            this.txt_valor_hora.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_valor_hora.Size = new System.Drawing.Size(70, 20);
            this.txt_valor_hora.TabIndex = 15;
            this.txt_valor_hora.TextChanged += new System.EventHandler(this.txt_valor_hora_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Horas Totais.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Data final.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Data inicial.:";
            // 
            // dateTime_final
            // 
            this.dateTime_final.Enabled = false;
            this.dateTime_final.Location = new System.Drawing.Point(72, 50);
            this.dateTime_final.Name = "dateTime_final";
            this.dateTime_final.Size = new System.Drawing.Size(200, 20);
            this.dateTime_final.TabIndex = 12;
            this.dateTime_final.CloseUp += new System.EventHandler(this.dateTime_final_CloseUp);
            // 
            // btn_pagar
            // 
            this.btn_pagar.Enabled = false;
            this.btn_pagar.Location = new System.Drawing.Point(206, 31);
            this.btn_pagar.Name = "btn_pagar";
            this.btn_pagar.Size = new System.Drawing.Size(65, 24);
            this.btn_pagar.TabIndex = 24;
            this.btn_pagar.Text = "Pagar";
            this.btn_pagar.UseVisualStyleBackColor = true;
            this.btn_pagar.Click += new System.EventHandler(this.btn_pagar_Click);
            // 
            // btn_relatorio
            // 
            this.btn_relatorio.Location = new System.Drawing.Point(125, 31);
            this.btn_relatorio.Name = "btn_relatorio";
            this.btn_relatorio.Size = new System.Drawing.Size(65, 24);
            this.btn_relatorio.TabIndex = 19;
            this.btn_relatorio.Text = "Detalhes";
            this.toolTip1.SetToolTip(this.btn_relatorio, "Gera um relatório completo do periodo selecionado");
            this.btn_relatorio.UseVisualStyleBackColor = true;
            this.btn_relatorio.Click += new System.EventHandler(this.btn_relatorio_Click);
            // 
            // cb_ativo
            // 
            this.cb_ativo.AutoSize = true;
            this.cb_ativo.Location = new System.Drawing.Point(7, 204);
            this.cb_ativo.Name = "cb_ativo";
            this.cb_ativo.Size = new System.Drawing.Size(108, 17);
            this.cb_ativo.TabIndex = 13;
            this.cb_ativo.Text = "Funcionário Ativo";
            this.toolTip1.SetToolTip(this.cb_ativo, "Marque para funcionário efetivado");
            this.cb_ativo.UseVisualStyleBackColor = true;
            // 
            // panel_inwork
            // 
            this.panel_inwork.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_inwork.Controls.Add(this.tableLayoutPanel2);
            this.panel_inwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_inwork.Location = new System.Drawing.Point(370, 259);
            this.panel_inwork.Margin = new System.Windows.Forms.Padding(0);
            this.panel_inwork.Name = "panel_inwork";
            this.panel_inwork.Size = new System.Drawing.Size(715, 439);
            this.panel_inwork.TabIndex = 14;
            this.panel_inwork.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView_horarios, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel_msg, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(715, 439);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_open);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btn_pagar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btn_relatorio);
            this.panel2.Controls.Add(this.btn_corrigir_data);
            this.panel2.Controls.Add(this.dateTimePicker_cor_final_day);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.dateTimePicker_cor_inicio);
            this.panel2.Controls.Add(this.dateTimePicker_cor_final);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 376);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 63);
            this.panel2.TabIndex = 27;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(5, 32);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(104, 23);
            this.btn_open.TabIndex = 26;
            this.btn_open.Text = "Abrir arquivos";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Início.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Final.:";
            // 
            // btn_corrigir_data
            // 
            this.btn_corrigir_data.Enabled = false;
            this.btn_corrigir_data.Location = new System.Drawing.Point(287, 31);
            this.btn_corrigir_data.Name = "btn_corrigir_data";
            this.btn_corrigir_data.Size = new System.Drawing.Size(65, 24);
            this.btn_corrigir_data.TabIndex = 1;
            this.btn_corrigir_data.Text = "Corrigir";
            this.btn_corrigir_data.UseVisualStyleBackColor = true;
            this.btn_corrigir_data.Click += new System.EventHandler(this.btn_corrigir_data_Click);
            // 
            // dateTimePicker_cor_final_day
            // 
            this.dateTimePicker_cor_final_day.Location = new System.Drawing.Point(365, 5);
            this.dateTimePicker_cor_final_day.Name = "dateTimePicker_cor_final_day";
            this.dateTimePicker_cor_final_day.Size = new System.Drawing.Size(206, 20);
            this.dateTimePicker_cor_final_day.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(44, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker_cor_inicio
            // 
            this.dateTimePicker_cor_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_cor_inicio.Location = new System.Drawing.Point(256, 5);
            this.dateTimePicker_cor_inicio.Name = "dateTimePicker_cor_inicio";
            this.dateTimePicker_cor_inicio.ShowUpDown = true;
            this.dateTimePicker_cor_inicio.Size = new System.Drawing.Size(65, 20);
            this.dateTimePicker_cor_inicio.TabIndex = 3;
            // 
            // dateTimePicker_cor_final
            // 
            this.dateTimePicker_cor_final.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_cor_final.Location = new System.Drawing.Point(577, 5);
            this.dateTimePicker_cor_final.Name = "dateTimePicker_cor_final";
            this.dateTimePicker_cor_final.ShowUpDown = true;
            this.dateTimePicker_cor_final.Size = new System.Drawing.Size(65, 20);
            this.dateTimePicker_cor_final.TabIndex = 3;
            // 
            // dataGridView_horarios
            // 
            this.dataGridView_horarios.AllowUserToAddRows = false;
            this.dataGridView_horarios.AllowUserToDeleteRows = false;
            this.dataGridView_horarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_horarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_horarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_horarios.Location = new System.Drawing.Point(5, 30);
            this.dataGridView_horarios.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dataGridView_horarios.MultiSelect = false;
            this.dataGridView_horarios.Name = "dataGridView_horarios";
            this.dataGridView_horarios.ReadOnly = true;
            this.dataGridView_horarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_horarios.ShowCellToolTips = false;
            this.dataGridView_horarios.ShowEditingIcon = false;
            this.dataGridView_horarios.Size = new System.Drawing.Size(705, 346);
            this.dataGridView_horarios.TabIndex = 2;
            this.dataGridView_horarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_horarios_CellClick);
            this.dataGridView_horarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_horarios_CellDoubleClick);
            // 
            // flowLayoutPanel_msg
            // 
            this.flowLayoutPanel_msg.Controls.Add(this.lba_inwork_msg);
            this.flowLayoutPanel_msg.Controls.Add(this.lba_chour);
            this.flowLayoutPanel_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_msg.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_msg.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel_msg.Name = "flowLayoutPanel_msg";
            this.flowLayoutPanel_msg.Size = new System.Drawing.Size(715, 30);
            this.flowLayoutPanel_msg.TabIndex = 28;
            // 
            // lba_inwork_msg
            // 
            this.lba_inwork_msg.AutoSize = true;
            this.lba_inwork_msg.ForeColor = System.Drawing.Color.Maroon;
            this.lba_inwork_msg.Location = new System.Drawing.Point(3, 6);
            this.lba_inwork_msg.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lba_inwork_msg.Name = "lba_inwork_msg";
            this.lba_inwork_msg.Size = new System.Drawing.Size(83, 13);
            this.lba_inwork_msg.TabIndex = 6;
            this.lba_inwork_msg.Text = "lba_inwork_msg";
            // 
            // lba_chour
            // 
            this.lba_chour.AutoSize = true;
            this.lba_chour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_chour.ForeColor = System.Drawing.Color.Red;
            this.lba_chour.Location = new System.Drawing.Point(129, 6);
            this.lba_chour.Margin = new System.Windows.Forms.Padding(40, 6, 3, 0);
            this.lba_chour.Name = "lba_chour";
            this.lba_chour.Size = new System.Drawing.Size(63, 13);
            this.lba_chour.TabIndex = 7;
            this.lba_chour.Text = "lba_chour";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_nome);
            this.groupBox1.Controls.Add(this.cb_ativo);
            this.groupBox1.Controls.Add(this.btn_cadastrar);
            this.groupBox1.Controls.Add(this.btn_novo);
            this.groupBox1.Controls.Add(this.photo);
            this.groupBox1.Controls.Add(this.btn_fechar);
            this.groupBox1.Controls.Add(this.btn_geraCracha);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 227);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do funcionário.:";
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.Location = new System.Drawing.Point(129, 206);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(0, 0);
            this.btn_exit.TabIndex = 14;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.Enabled = false;
            this.btn_fechar.Location = new System.Drawing.Point(293, 183);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(64, 36);
            this.btn_fechar.TabIndex = 7;
            this.btn_fechar.Text = "Parar";
            this.toolTip1.SetToolTip(this.btn_fechar, "Fecha o horário do funcionário selecionado que esteja trabalhando.");
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 439);
            this.panel1.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridView_funcionarios, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(370, 439);
            this.tableLayoutPanel3.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lista de funcionários.:";
            // 
            // dataGridView_funcionarios
            // 
            this.dataGridView_funcionarios.AllowUserToAddRows = false;
            this.dataGridView_funcionarios.AllowUserToDeleteRows = false;
            this.dataGridView_funcionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_funcionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_funcionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_funcionarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_funcionarios.Location = new System.Drawing.Point(5, 30);
            this.dataGridView_funcionarios.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dataGridView_funcionarios.MultiSelect = false;
            this.dataGridView_funcionarios.Name = "dataGridView_funcionarios";
            this.dataGridView_funcionarios.ReadOnly = true;
            this.dataGridView_funcionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_funcionarios.ShowEditingIcon = false;
            this.dataGridView_funcionarios.Size = new System.Drawing.Size(360, 409);
            this.dataGridView_funcionarios.TabIndex = 16;
            this.dataGridView_funcionarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_funcionarios_CellClick);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_inwork, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gb_horas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 698);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // menuStrip2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip2, 2);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.atualizarToolStripMenuItem,
            this.versãoToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.ShowItemToolTips = true;
            this.menuStrip2.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip2.TabIndex = 18;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.exportarExcelToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "Arquivo";
            this.toolStripMenuItem1.ToolTipText = "Abrir arquivos salvos";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarExcelToolStripMenuItem_Click);
            // 
            // restaurarFuncionárioPeloArquivoToolStripMenuItem
            // 
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem.Name = "restaurarFuncionárioPeloArquivoToolStripMenuItem";
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem.Text = "DB BackUp";
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem.ToolTipText = "Restaura Bando de Dados a partir dos arquivos de Relatório";
            this.restaurarFuncionárioPeloArquivoToolStripMenuItem.Click += new System.EventHandler(this.restaurarFuncionárioPeloArquivoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.ToolTipText = "Fechar o programa";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // atualizarToolStripMenuItem
            // 
            this.atualizarToolStripMenuItem.Name = "atualizarToolStripMenuItem";
            this.atualizarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.atualizarToolStripMenuItem.Text = "Atualizar";
            this.atualizarToolStripMenuItem.ToolTipText = "Atualizar programa";
            this.atualizarToolStripMenuItem.Visible = false;
            this.atualizarToolStripMenuItem.Click += new System.EventHandler(this.atualizarToolStripMenuItem_Click);
            // 
            // versãoToolStripMenuItem
            // 
            this.versãoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.versãoToolStripMenuItem.Enabled = false;
            this.versãoToolStripMenuItem.Name = "versãoToolStripMenuItem";
            this.versãoToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.versãoToolStripMenuItem.Text = "Versão";
            // 
            // Cadastre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(1085, 698);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lba_nome);
            this.Controls.Add(this.lba_safefilename);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(846, 542);
            this.Name = "Cadastre";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Painel de controle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Cadastre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.gb_horas.ResumeLayout(false);
            this.gb_horas.PerformLayout();
            this.gb_status.ResumeLayout(false);
            this.gb_status.PerformLayout();
            this.panel_inwork.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_horarios)).EndInit();
            this.flowLayoutPanel_msg.ResumeLayout(false);
            this.flowLayoutPanel_msg.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_funcionarios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.Label lba_nome;
        private System.Windows.Forms.Button btn_geraCracha;
        private System.Windows.Forms.Label lba_safefilename;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.PictureBox photo;
        private System.Windows.Forms.Label lba_horas;
        private System.Windows.Forms.DateTimePicker dateTime_iniciar;
        private System.Windows.Forms.GroupBox gb_horas;
        private System.Windows.Forms.DateTimePicker dateTime_final;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_ativo;
        private System.Windows.Forms.Panel panel_inwork;
        private System.Windows.Forms.Button btn_corrigir_data;
        private System.Windows.Forms.DataGridView dataGridView_horarios;
        private System.Windows.Forms.DateTimePicker dateTimePicker_cor_final;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_funcionarios;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_valor_hora;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lba_valor_total;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_relatorio;
        private System.Windows.Forms.RadioButton rb_npagos;
        private System.Windows.Forms.RadioButton rb_pagos;
        private System.Windows.Forms.RadioButton rb_tudos;
        private System.Windows.Forms.GroupBox gb_status;
        private System.Windows.Forms.Button btn_pagar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.DateTimePicker dateTimePicker_cor_inicio;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versãoToolStripMenuItem;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ToolStripMenuItem restaurarFuncionárioPeloArquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker_cor_final_day;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_msg;
        private System.Windows.Forms.Label lba_inwork_msg;
        private System.Windows.Forms.Label lba_chour;
    }
}