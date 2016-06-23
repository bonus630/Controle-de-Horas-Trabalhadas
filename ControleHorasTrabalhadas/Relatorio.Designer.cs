namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    partial class Relatorio
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
            this.panel_area_impressao = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lba_hours = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lba_value = new System.Windows.Forms.Label();
            this.lba_fullText = new System.Windows.Forms.Label();
            this.picture_box_logo = new System.Windows.Forms.PictureBox();
            this.lba_empresa_nome = new System.Windows.Forms.Label();
            this.lba_date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lba_name = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lba_message = new System.Windows.Forms.Label();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_area_impressao.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_area_impressao
            // 
            this.panel_area_impressao.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.panel_area_impressao, 2);
            this.panel_area_impressao.Controls.Add(this.flowLayoutPanel1);
            this.panel_area_impressao.Controls.Add(this.picture_box_logo);
            this.panel_area_impressao.Controls.Add(this.lba_empresa_nome);
            this.panel_area_impressao.Controls.Add(this.lba_date);
            this.panel_area_impressao.Controls.Add(this.label2);
            this.panel_area_impressao.Controls.Add(this.label1);
            this.panel_area_impressao.Controls.Add(this.lba_name);
            this.panel_area_impressao.Controls.Add(this.dataGridView1);
            this.panel_area_impressao.Controls.Add(this.lba_message);
            this.panel_area_impressao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_area_impressao.Location = new System.Drawing.Point(10, 40);
            this.panel_area_impressao.Margin = new System.Windows.Forms.Padding(10);
            this.panel_area_impressao.MaximumSize = new System.Drawing.Size(790, 1100);
            this.panel_area_impressao.MinimumSize = new System.Drawing.Size(790, 1100);
            this.panel_area_impressao.Name = "panel_area_impressao";
            this.panel_area_impressao.Size = new System.Drawing.Size(790, 1100);
            this.panel_area_impressao.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lba_hours);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.lba_value);
            this.flowLayoutPanel1.Controls.Add(this.lba_fullText);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 82);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(642, 20);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Horas Totais:";
            // 
            // lba_hours
            // 
            this.lba_hours.AutoSize = true;
            this.lba_hours.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_hours.Location = new System.Drawing.Point(81, 0);
            this.lba_hours.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lba_hours.Name = "lba_hours";
            this.lba_hours.Size = new System.Drawing.Size(13, 15);
            this.lba_hours.TabIndex = 2;
            this.lba_hours.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total:";
            // 
            // lba_value
            // 
            this.lba_value.AutoSize = true;
            this.lba_value.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_value.Location = new System.Drawing.Point(137, 0);
            this.lba_value.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lba_value.Name = "lba_value";
            this.lba_value.Size = new System.Drawing.Size(13, 15);
            this.lba_value.TabIndex = 2;
            this.lba_value.Text = "0";
            // 
            // lba_fullText
            // 
            this.lba_fullText.AutoSize = true;
            this.lba_fullText.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_fullText.Location = new System.Drawing.Point(153, 0);
            this.lba_fullText.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lba_fullText.Name = "lba_fullText";
            this.lba_fullText.Size = new System.Drawing.Size(0, 15);
            this.lba_fullText.TabIndex = 2;
            // 
            // picture_box_logo
            // 
            this.picture_box_logo.Location = new System.Drawing.Point(659, 4);
            this.picture_box_logo.Name = "picture_box_logo";
            this.picture_box_logo.Size = new System.Drawing.Size(121, 121);
            this.picture_box_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_box_logo.TabIndex = 4;
            this.picture_box_logo.TabStop = false;
            // 
            // lba_empresa_nome
            // 
            this.lba_empresa_nome.AutoSize = true;
            this.lba_empresa_nome.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_empresa_nome.Location = new System.Drawing.Point(10, 14);
            this.lba_empresa_nome.Name = "lba_empresa_nome";
            this.lba_empresa_nome.Size = new System.Drawing.Size(63, 24);
            this.lba_empresa_nome.TabIndex = 3;
            this.lba_empresa_nome.Text = "label4";
            // 
            // lba_date
            // 
            this.lba_date.AutoSize = true;
            this.lba_date.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_date.Location = new System.Drawing.Point(366, 55);
            this.lba_date.Name = "lba_date";
            this.lba_date.Size = new System.Drawing.Size(42, 17);
            this.lba_date.TabIndex = 2;
            this.lba_date.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Período.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Funcionário.:";
            // 
            // lba_name
            // 
            this.lba_name.AutoSize = true;
            this.lba_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_name.Location = new System.Drawing.Point(93, 55);
            this.lba_name.Name = "lba_name";
            this.lba_name.Size = new System.Drawing.Size(42, 17);
            this.lba_name.TabIndex = 2;
            this.lba_name.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(768, 859);
            this.dataGridView1.TabIndex = 1;
            // 
            // lba_message
            // 
            this.lba_message.AutoSize = true;
            this.lba_message.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lba_message.Location = new System.Drawing.Point(10, 107);
            this.lba_message.Name = "lba_message";
            this.lba_message.Size = new System.Drawing.Size(42, 17);
            this.lba_message.TabIndex = 2;
            this.lba_message.Text = "label1";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Location = new System.Drawing.Point(3, 3);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(59, 22);
            this.btn_imprimir.TabIndex = 1;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 686F));
            this.tableLayoutPanel1.Controls.Add(this.btn_imprimir, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_area_impressao, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 1100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(126, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::br.corp.bonus630.ControleHorasTrabalhadas.Properties.Resources.print;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem1.Text = "Imprimir";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::br.corp.bonus630.ControleHorasTrabalhadas.Properties.Resources._3_disc;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem2.Text = "Salvar";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::br.corp.bonus630.ControleHorasTrabalhadas.Properties.Resources.cancel_32;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem3.Text = "Fechar";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // Relatorio
            // 
            this.AcceptButton = this.btn_imprimir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 1100);
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(826, 532);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Relatorio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Relatório";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorio_KeyDown);
            this.panel_area_impressao.ResumeLayout(false);
            this.panel_area_impressao.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_area_impressao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Label lba_date;
        private System.Windows.Forms.Label lba_value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lba_hours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lba_name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lba_message;
        private System.Windows.Forms.Label lba_fullText;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lba_empresa_nome;
        private System.Windows.Forms.PictureBox picture_box_logo;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

    }
}