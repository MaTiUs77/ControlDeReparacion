namespace ControlDeReparacion
{
    partial class formIngresoPlaca
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inCodigo = new System.Windows.Forms.Label();
            this.comboPanel = new System.Windows.Forms.ComboBox();
            this.comboLote = new System.Windows.Forms.ComboBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.Lote = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxDeclaracion = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inAccion = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataReferencias = new System.Windows.Forms.DataGridView();
            this.adel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.aref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboReferencias = new System.Windows.Forms.ComboBox();
            this.comboOrigen = new System.Windows.Forms.ComboBox();
            this.comboAccion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboCausa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboDefecto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnFotoPc = new System.Windows.Forms.Button();
            this.btnFotoCamara = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.boxDeclaracion.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReferencias)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // inCodigo
            // 
            this.inCodigo.BackColor = System.Drawing.Color.Black;
            this.inCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inCodigo.ForeColor = System.Drawing.Color.White;
            this.inCodigo.Location = new System.Drawing.Point(3, 40);
            this.inCodigo.Name = "inCodigo";
            this.inCodigo.Size = new System.Drawing.Size(514, 34);
            this.inCodigo.TabIndex = 0;
            this.inCodigo.Text = "REP0000000";
            // 
            // comboPanel
            // 
            this.comboPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPanel.FormattingEnabled = true;
            this.comboPanel.Location = new System.Drawing.Point(345, 34);
            this.comboPanel.Name = "comboPanel";
            this.comboPanel.Size = new System.Drawing.Size(162, 28);
            this.comboPanel.TabIndex = 2;
            this.comboPanel.SelectedIndexChanged += new System.EventHandler(this.comboPanel_SelectedIndexChanged);
            // 
            // comboLote
            // 
            this.comboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLote.FormattingEnabled = true;
            this.comboLote.Location = new System.Drawing.Point(177, 34);
            this.comboLote.Name = "comboLote";
            this.comboLote.Size = new System.Drawing.Size(162, 28);
            this.comboLote.TabIndex = 1;
            this.comboLote.SelectedIndexChanged += new System.EventHandler(this.comboLote_SelectedIndexChanged);
            // 
            // comboModelo
            // 
            this.comboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Location = new System.Drawing.Point(9, 34);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(162, 28);
            this.comboModelo.TabIndex = 0;
            this.comboModelo.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            this.comboModelo.SelectedValueChanged += new System.EventHandler(this.comboModelo_SelectedValueChanged);
            // 
            // Lote
            // 
            this.Lote.AutoSize = true;
            this.Lote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lote.Location = new System.Drawing.Point(176, 16);
            this.Lote.Name = "Lote";
            this.Lote.Size = new System.Drawing.Size(36, 17);
            this.Lote.TabIndex = 3;
            this.Lote.Text = "Lote";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Modelo";
            // 
            // btnReportar
            // 
            this.btnReportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportar.Location = new System.Drawing.Point(261, 455);
            this.btnReportar.Name = "btnReportar";
            this.btnReportar.Size = new System.Drawing.Size(244, 54);
            this.btnReportar.TabIndex = 9;
            this.btnReportar.Text = "Ingreso a reparacion";
            this.btnReportar.UseVisualStyleBackColor = true;
            this.btnReportar.Click += new System.EventHandler(this.btnReportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxDeclaracion);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.btnReportar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboOrigen);
            this.groupBox1.Controls.Add(this.comboAccion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboCausa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboDefecto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboPanel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboLote);
            this.groupBox1.Controls.Add(this.Lote);
            this.groupBox1.Controls.Add(this.comboModelo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(514, 515);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // boxDeclaracion
            // 
            this.boxDeclaracion.Controls.Add(this.button1);
            this.boxDeclaracion.Controls.Add(this.button2);
            this.boxDeclaracion.Controls.Add(this.button3);
            this.boxDeclaracion.Location = new System.Drawing.Point(12, 451);
            this.boxDeclaracion.Name = "boxDeclaracion";
            this.boxDeclaracion.Size = new System.Drawing.Size(243, 58);
            this.boxDeclaracion.TabIndex = 15;
            this.boxDeclaracion.TabStop = false;
            this.boxDeclaracion.Text = "Declaracion especial";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(5, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Scrap";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnScrap_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(73, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "Bonepile";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnBonePile_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(156, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 33);
            this.button3.TabIndex = 9;
            this.button3.Text = "Analisis";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 279);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(498, 169);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inAccion);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(252, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(243, 163);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Observacion";
            // 
            // inAccion
            // 
            this.inAccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inAccion.Location = new System.Drawing.Point(5, 18);
            this.inAccion.Multiline = true;
            this.inAccion.Name = "inAccion";
            this.inAccion.Size = new System.Drawing.Size(233, 140);
            this.inAccion.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataReferencias);
            this.groupBox5.Controls.Add(this.comboReferencias);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(243, 163);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ingresar referencias";
            // 
            // dataReferencias
            // 
            this.dataReferencias.AllowUserToAddRows = false;
            this.dataReferencias.AllowUserToDeleteRows = false;
            this.dataReferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataReferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.adel,
            this.aref});
            this.dataReferencias.Location = new System.Drawing.Point(6, 40);
            this.dataReferencias.Name = "dataReferencias";
            this.dataReferencias.ReadOnly = true;
            this.dataReferencias.RowHeadersVisible = false;
            this.dataReferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataReferencias.Size = new System.Drawing.Size(231, 118);
            this.dataReferencias.TabIndex = 11;
            this.dataReferencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataReferencias_CellContentClick);
            // 
            // adel
            // 
            this.adel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.adel.DefaultCellStyle = dataGridViewCellStyle1;
            this.adel.HeaderText = "";
            this.adel.Name = "adel";
            this.adel.ReadOnly = true;
            this.adel.Text = "X";
            this.adel.UseColumnTextForButtonValue = true;
            this.adel.Width = 5;
            // 
            // aref
            // 
            this.aref.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aref.HeaderText = "Referencia";
            this.aref.Name = "aref";
            this.aref.ReadOnly = true;
            this.aref.Width = 84;
            // 
            // comboReferencias
            // 
            this.comboReferencias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboReferencias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboReferencias.BackColor = System.Drawing.Color.Maroon;
            this.comboReferencias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboReferencias.ForeColor = System.Drawing.Color.White;
            this.comboReferencias.FormattingEnabled = true;
            this.comboReferencias.Location = new System.Drawing.Point(6, 17);
            this.comboReferencias.Name = "comboReferencias";
            this.comboReferencias.Size = new System.Drawing.Size(231, 21);
            this.comboReferencias.TabIndex = 10;
            this.comboReferencias.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            // 
            // comboOrigen
            // 
            this.comboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOrigen.FormattingEnabled = true;
            this.comboOrigen.Location = new System.Drawing.Point(9, 190);
            this.comboOrigen.Name = "comboOrigen";
            this.comboOrigen.Size = new System.Drawing.Size(498, 28);
            this.comboOrigen.TabIndex = 5;
            // 
            // comboAccion
            // 
            this.comboAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAccion.FormattingEnabled = true;
            this.comboAccion.Location = new System.Drawing.Point(9, 241);
            this.comboAccion.Name = "comboAccion";
            this.comboAccion.Size = new System.Drawing.Size(498, 28);
            this.comboAccion.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Origen";
            // 
            // comboCausa
            // 
            this.comboCausa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCausa.FormattingEnabled = true;
            this.comboCausa.Location = new System.Drawing.Point(9, 139);
            this.comboCausa.Name = "comboCausa";
            this.comboCausa.Size = new System.Drawing.Size(498, 28);
            this.comboCausa.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Accion correctiva";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Causa";
            // 
            // comboDefecto
            // 
            this.comboDefecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDefecto.FormattingEnabled = true;
            this.comboDefecto.Location = new System.Drawing.Point(9, 87);
            this.comboDefecto.Name = "comboDefecto";
            this.comboDefecto.Size = new System.Drawing.Size(498, 28);
            this.comboDefecto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Defecto";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.inCodigo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.titulo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 595);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(3, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(514, 40);
            this.titulo.TabIndex = 11;
            this.titulo.Text = "INGRESAR A REPARACION";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 595);
            this.panel1.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 520;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 595);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCapturar);
            this.groupBox4.Controls.Add(this.btnFotoPc);
            this.groupBox4.Controls.Add(this.btnFotoCamara);
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(662, 595);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Adjuntar imagen";
            // 
            // btnCapturar
            // 
            this.btnCapturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturar.ForeColor = System.Drawing.Color.Red;
            this.btnCapturar.Location = new System.Drawing.Point(531, 513);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(119, 73);
            this.btnCapturar.TabIndex = 11;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Visible = false;
            this.btnCapturar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFotoPc
            // 
            this.btnFotoPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFotoPc.Location = new System.Drawing.Point(12, 513);
            this.btnFotoPc.Name = "btnFotoPc";
            this.btnFotoPc.Size = new System.Drawing.Size(168, 73);
            this.btnFotoPc.TabIndex = 10;
            this.btnFotoPc.Text = "Foto de PC";
            this.btnFotoPc.UseVisualStyleBackColor = true;
            this.btnFotoPc.Click += new System.EventHandler(this.btnFotoPc_Click);
            // 
            // btnFotoCamara
            // 
            this.btnFotoCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFotoCamara.Location = new System.Drawing.Point(186, 513);
            this.btnFotoCamara.Name = "btnFotoCamara";
            this.btnFotoCamara.Size = new System.Drawing.Size(166, 73);
            this.btnFotoCamara.TabIndex = 9;
            this.btnFotoCamara.Text = "Foto de Camara";
            this.btnFotoCamara.UseVisualStyleBackColor = true;
            this.btnFotoCamara.Click += new System.EventHandler(this.btnFotoCamara_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(12, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formIngresoPlaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1186, 595);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formIngresoPlaca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reparacion de placa";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formIngresoPlaca_FormClosed);
            this.Load += new System.EventHandler(this.formIngresoPlaca_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.boxDeclaracion.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataReferencias)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label inCodigo;
        private System.Windows.Forms.ComboBox comboPanel;
        private System.Windows.Forms.ComboBox comboLote;
        private System.Windows.Forms.ComboBox comboModelo;
        private System.Windows.Forms.Label Lote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboDefecto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inAccion;
        private System.Windows.Forms.ComboBox comboCausa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboOrigen;
        private System.Windows.Forms.ComboBox comboAccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnFotoCamara;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnFotoPc;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboReferencias;
        private System.Windows.Forms.DataGridView dataReferencias;
        private System.Windows.Forms.DataGridViewButtonColumn adel;
        private System.Windows.Forms.DataGridViewTextBoxColumn aref;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox boxDeclaracion;
        private System.Windows.Forms.Button button3;
    }
}