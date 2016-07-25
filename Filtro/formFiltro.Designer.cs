namespace ControlDeReparacion
{
    partial class formFiltro
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
            this.comboPlaca = new System.Windows.Forms.ComboBox();
            this.comboLote = new System.Windows.Forms.ComboBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btQuitar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chRep = new System.Windows.Forms.CheckBox();
            this.chPen = new System.Windows.Forms.CheckBox();
            this.chAnalisis = new System.Windows.Forms.CheckBox();
            this.chBonepile = new System.Windows.Forms.CheckBox();
            this.chScrap = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.comboOrigen = new System.Windows.Forms.ComboBox();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.comboDefecto = new System.Windows.Forms.ComboBox();
            this.comboCausa = new System.Windows.Forms.ComboBox();
            this.comboReferencia = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboPlaca
            // 
            this.comboPlaca.BackColor = System.Drawing.Color.LightGray;
            this.comboPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPlaca.FormattingEnabled = true;
            this.comboPlaca.Location = new System.Drawing.Point(18, 130);
            this.comboPlaca.Name = "comboPlaca";
            this.comboPlaca.Size = new System.Drawing.Size(154, 24);
            this.comboPlaca.TabIndex = 8;
            // 
            // comboLote
            // 
            this.comboLote.BackColor = System.Drawing.Color.LightGray;
            this.comboLote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLote.FormattingEnabled = true;
            this.comboLote.Location = new System.Drawing.Point(18, 85);
            this.comboLote.Name = "comboLote";
            this.comboLote.Size = new System.Drawing.Size(154, 24);
            this.comboLote.TabIndex = 7;
            // 
            // comboModelo
            // 
            this.comboModelo.BackColor = System.Drawing.Color.LightGray;
            this.comboModelo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Location = new System.Drawing.Point(18, 40);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(154, 24);
            this.comboModelo.TabIndex = 6;
            this.comboModelo.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Modelo";
            // 
            // FechaHasta
            // 
            this.FechaHasta.CustomFormat = "dd/MM/yyyy";
            this.FechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaHasta.Location = new System.Drawing.Point(178, 267);
            this.FechaHasta.Name = "FechaHasta";
            this.FechaHasta.Size = new System.Drawing.Size(154, 24);
            this.FechaHasta.TabIndex = 12;
            this.FechaHasta.ValueChanged += new System.EventHandler(this.FechaHasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Desde";
            // 
            // FechaDesde
            // 
            this.FechaDesde.CustomFormat = "dd/MM/yyyy";
            this.FechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaDesde.Location = new System.Drawing.Point(19, 267);
            this.FechaDesde.Name = "FechaDesde";
            this.FechaDesde.Size = new System.Drawing.Size(154, 24);
            this.FechaDesde.TabIndex = 14;
            this.FechaDesde.ValueChanged += new System.EventHandler(this.FechaDesde_ValueChanged);
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Location = new System.Drawing.Point(43, 388);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(260, 45);
            this.btGuardar.TabIndex = 16;
            this.btGuardar.Text = "Filtrar";
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btQuitar
            // 
            this.btQuitar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btQuitar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuitar.Location = new System.Drawing.Point(43, 439);
            this.btQuitar.Name = "btQuitar";
            this.btQuitar.Size = new System.Drawing.Size(260, 30);
            this.btQuitar.TabIndex = 16;
            this.btQuitar.Text = "Quitar filtro";
            this.btQuitar.UseVisualStyleBackColor = false;
            this.btQuitar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btQuitar);
            this.groupBox1.Controls.Add(this.comboTurno);
            this.groupBox1.Controls.Add(this.comboOrigen);
            this.groupBox1.Controls.Add(this.comboArea);
            this.groupBox1.Controls.Add(this.comboOperador);
            this.groupBox1.Controls.Add(this.comboDefecto);
            this.groupBox1.Controls.Add(this.comboModelo);
            this.groupBox1.Controls.Add(this.btGuardar);
            this.groupBox1.Controls.Add(this.comboCausa);
            this.groupBox1.Controls.Add(this.comboLote);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboReferencia);
            this.groupBox1.Controls.Add(this.comboPlaca);
            this.groupBox1.Controls.Add(this.FechaDesde);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FechaHasta);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 483);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chRep);
            this.groupBox2.Controls.Add(this.chPen);
            this.groupBox2.Controls.Add(this.chAnalisis);
            this.groupBox2.Controls.Add(this.chBonepile);
            this.groupBox2.Controls.Add(this.chScrap);
            this.groupBox2.Location = new System.Drawing.Point(20, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 85);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar estado";
            // 
            // chRep
            // 
            this.chRep.AutoSize = true;
            this.chRep.Checked = true;
            this.chRep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chRep.Location = new System.Drawing.Point(32, 52);
            this.chRep.Name = "chRep";
            this.chRep.Size = new System.Drawing.Size(78, 17);
            this.chRep.TabIndex = 0;
            this.chRep.Text = "Reparados";
            this.chRep.UseVisualStyleBackColor = true;
            this.chRep.CheckedChanged += new System.EventHandler(this.chRep_CheckedChanged);
            // 
            // chPen
            // 
            this.chPen.AutoSize = true;
            this.chPen.Checked = true;
            this.chPen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chPen.Location = new System.Drawing.Point(32, 29);
            this.chPen.Name = "chPen";
            this.chPen.Size = new System.Drawing.Size(79, 17);
            this.chPen.TabIndex = 0;
            this.chPen.Text = "Pendientes";
            this.chPen.UseVisualStyleBackColor = true;
            this.chPen.CheckedChanged += new System.EventHandler(this.chPen_CheckedChanged);
            // 
            // chAnalisis
            // 
            this.chAnalisis.AutoSize = true;
            this.chAnalisis.Checked = true;
            this.chAnalisis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAnalisis.Location = new System.Drawing.Point(214, 29);
            this.chAnalisis.Name = "chAnalisis";
            this.chAnalisis.Size = new System.Drawing.Size(61, 17);
            this.chAnalisis.TabIndex = 0;
            this.chAnalisis.Text = "Analisis";
            this.chAnalisis.UseVisualStyleBackColor = true;
            this.chAnalisis.CheckedChanged += new System.EventHandler(this.chAnalisis_CheckedChanged);
            // 
            // chBonepile
            // 
            this.chBonepile.AutoSize = true;
            this.chBonepile.Checked = true;
            this.chBonepile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBonepile.Location = new System.Drawing.Point(135, 52);
            this.chBonepile.Name = "chBonepile";
            this.chBonepile.Size = new System.Drawing.Size(67, 17);
            this.chBonepile.TabIndex = 0;
            this.chBonepile.Text = "Bonepile";
            this.chBonepile.UseVisualStyleBackColor = true;
            this.chBonepile.CheckedChanged += new System.EventHandler(this.chBonepile_CheckedChanged);
            // 
            // chScrap
            // 
            this.chScrap.AutoSize = true;
            this.chScrap.Checked = true;
            this.chScrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chScrap.Location = new System.Drawing.Point(135, 29);
            this.chScrap.Name = "chScrap";
            this.chScrap.Size = new System.Drawing.Size(54, 17);
            this.chScrap.TabIndex = 0;
            this.chScrap.Text = "Scrap";
            this.chScrap.UseVisualStyleBackColor = true;
            this.chScrap.CheckedChanged += new System.EventHandler(this.chScrap_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(174, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Origen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(174, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Area";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(174, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Turno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(174, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Operador";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Defecto";
            // 
            // comboTurno
            // 
            this.comboTurno.BackColor = System.Drawing.Color.LightGray;
            this.comboTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(177, 130);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(154, 24);
            this.comboTurno.TabIndex = 6;
            // 
            // comboOrigen
            // 
            this.comboOrigen.BackColor = System.Drawing.Color.LightGray;
            this.comboOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOrigen.FormattingEnabled = true;
            this.comboOrigen.Location = new System.Drawing.Point(177, 221);
            this.comboOrigen.Name = "comboOrigen";
            this.comboOrigen.Size = new System.Drawing.Size(154, 24);
            this.comboOrigen.TabIndex = 6;
            // 
            // comboArea
            // 
            this.comboArea.BackColor = System.Drawing.Color.LightGray;
            this.comboArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(177, 40);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(154, 24);
            this.comboArea.TabIndex = 6;
            // 
            // comboOperador
            // 
            this.comboOperador.BackColor = System.Drawing.Color.LightGray;
            this.comboOperador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Location = new System.Drawing.Point(177, 85);
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.Size = new System.Drawing.Size(154, 24);
            this.comboOperador.TabIndex = 6;
            // 
            // comboDefecto
            // 
            this.comboDefecto.BackColor = System.Drawing.Color.LightGray;
            this.comboDefecto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboDefecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDefecto.FormattingEnabled = true;
            this.comboDefecto.Location = new System.Drawing.Point(19, 176);
            this.comboDefecto.Name = "comboDefecto";
            this.comboDefecto.Size = new System.Drawing.Size(154, 24);
            this.comboDefecto.TabIndex = 6;
            this.comboDefecto.SelectedIndexChanged += new System.EventHandler(this.comboModelo_SelectedIndexChanged);
            // 
            // comboCausa
            // 
            this.comboCausa.BackColor = System.Drawing.Color.LightGray;
            this.comboCausa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboCausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCausa.FormattingEnabled = true;
            this.comboCausa.Location = new System.Drawing.Point(177, 176);
            this.comboCausa.Name = "comboCausa";
            this.comboCausa.Size = new System.Drawing.Size(154, 24);
            this.comboCausa.TabIndex = 7;
            // 
            // comboReferencia
            // 
            this.comboReferencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboReferencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboReferencia.BackColor = System.Drawing.Color.LightGray;
            this.comboReferencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboReferencia.FormattingEnabled = true;
            this.comboReferencia.Location = new System.Drawing.Point(19, 221);
            this.comboReferencia.Name = "comboReferencia";
            this.comboReferencia.Size = new System.Drawing.Size(154, 24);
            this.comboReferencia.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(174, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Causa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Referencia";
            // 
            // formFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 493);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formFiltro";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formFiltro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPlaca;
        private System.Windows.Forms.ComboBox comboLote;
        private System.Windows.Forms.ComboBox comboModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker FechaDesde;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btQuitar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chPen;
        private System.Windows.Forms.CheckBox chRep;
        private System.Windows.Forms.CheckBox chScrap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboOrigen;
        private System.Windows.Forms.ComboBox comboDefecto;
        private System.Windows.Forms.ComboBox comboCausa;
        private System.Windows.Forms.ComboBox comboReferencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chBonepile;
        private System.Windows.Forms.CheckBox chAnalisis;
    }
}