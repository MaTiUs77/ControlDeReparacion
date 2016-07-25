namespace ControlDeReparacion
{
    partial class formHistorico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridPlacas = new System.Windows.Forms.DataGridView();
            this.rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.rHistorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPanel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDefecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rCausa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xRefe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rCorrectiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rReparador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlacas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPlacas
            // 
            this.gridPlacas.AllowUserToAddRows = false;
            this.gridPlacas.AllowUserToDeleteRows = false;
            this.gridPlacas.AllowUserToResizeColumns = false;
            this.gridPlacas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlacas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPlacas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlacas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rid,
            this.Foto,
            this.rHistorial,
            this.rEstado,
            this.rcodigo,
            this.rModelo,
            this.rLote,
            this.rPanel,
            this.rDefecto,
            this.rCausa,
            this.xRefe,
            this.rCorrectiva,
            this.rAccion,
            this.rOrigen,
            this.rReparador,
            this.rTurno,
            this.rArea,
            this.rFecha,
            this.rHora});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPlacas.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridPlacas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlacas.Location = new System.Drawing.Point(0, 0);
            this.gridPlacas.Name = "gridPlacas";
            this.gridPlacas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlacas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridPlacas.RowHeadersVisible = false;
            this.gridPlacas.Size = new System.Drawing.Size(1248, 210);
            this.gridPlacas.TabIndex = 3;
            this.gridPlacas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlacas_CellClick);
            // 
            // rid
            // 
            this.rid.HeaderText = "id";
            this.rid.Name = "rid";
            this.rid.ReadOnly = true;
            this.rid.Visible = false;
            // 
            // Foto
            // 
            this.Foto.HeaderText = "";
            this.Foto.Name = "Foto";
            this.Foto.ReadOnly = true;
            this.Foto.Width = 28;
            // 
            // rHistorial
            // 
            this.rHistorial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rHistorial.HeaderText = "Count";
            this.rHistorial.Name = "rHistorial";
            this.rHistorial.ReadOnly = true;
            this.rHistorial.Width = 60;
            // 
            // rEstado
            // 
            this.rEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rEstado.HeaderText = "Estado";
            this.rEstado.Name = "rEstado";
            this.rEstado.ReadOnly = true;
            this.rEstado.Width = 65;
            // 
            // rcodigo
            // 
            this.rcodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rcodigo.HeaderText = "Codigo";
            this.rcodigo.Name = "rcodigo";
            this.rcodigo.ReadOnly = true;
            this.rcodigo.Width = 65;
            // 
            // rModelo
            // 
            this.rModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rModelo.HeaderText = "Modelo";
            this.rModelo.Name = "rModelo";
            this.rModelo.ReadOnly = true;
            this.rModelo.Width = 67;
            // 
            // rLote
            // 
            this.rLote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rLote.HeaderText = "Lote";
            this.rLote.Name = "rLote";
            this.rLote.ReadOnly = true;
            this.rLote.Width = 53;
            // 
            // rPanel
            // 
            this.rPanel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rPanel.HeaderText = "Panel";
            this.rPanel.Name = "rPanel";
            this.rPanel.ReadOnly = true;
            this.rPanel.Width = 59;
            // 
            // rDefecto
            // 
            this.rDefecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rDefecto.HeaderText = "Defecto";
            this.rDefecto.Name = "rDefecto";
            this.rDefecto.ReadOnly = true;
            this.rDefecto.Width = 70;
            // 
            // rCausa
            // 
            this.rCausa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rCausa.HeaderText = "Causa";
            this.rCausa.Name = "rCausa";
            this.rCausa.ReadOnly = true;
            this.rCausa.Width = 62;
            // 
            // xRefe
            // 
            this.xRefe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xRefe.HeaderText = "Referencia";
            this.xRefe.Name = "xRefe";
            this.xRefe.ReadOnly = true;
            this.xRefe.Width = 84;
            // 
            // rCorrectiva
            // 
            this.rCorrectiva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rCorrectiva.HeaderText = "Correctiva";
            this.rCorrectiva.Name = "rCorrectiva";
            this.rCorrectiva.ReadOnly = true;
            this.rCorrectiva.Width = 80;
            // 
            // rAccion
            // 
            this.rAccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rAccion.HeaderText = "Observacion";
            this.rAccion.Name = "rAccion";
            this.rAccion.ReadOnly = true;
            this.rAccion.Width = 92;
            // 
            // rOrigen
            // 
            this.rOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rOrigen.HeaderText = "Origen";
            this.rOrigen.Name = "rOrigen";
            this.rOrigen.ReadOnly = true;
            this.rOrigen.Width = 63;
            // 
            // rReparador
            // 
            this.rReparador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rReparador.HeaderText = "Reparador";
            this.rReparador.Name = "rReparador";
            this.rReparador.ReadOnly = true;
            this.rReparador.Width = 82;
            // 
            // rTurno
            // 
            this.rTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rTurno.HeaderText = "Turno";
            this.rTurno.Name = "rTurno";
            this.rTurno.ReadOnly = true;
            this.rTurno.Width = 60;
            // 
            // rArea
            // 
            this.rArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rArea.HeaderText = "Area";
            this.rArea.Name = "rArea";
            this.rArea.ReadOnly = true;
            this.rArea.Width = 54;
            // 
            // rFecha
            // 
            this.rFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rFecha.HeaderText = "Fecha";
            this.rFecha.Name = "rFecha";
            this.rFecha.ReadOnly = true;
            this.rFecha.Width = 62;
            // 
            // rHora
            // 
            this.rHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rHora.HeaderText = "Hora";
            this.rHora.Name = "rHora";
            this.rHora.ReadOnly = true;
            this.rHora.Width = 55;
            // 
            // formHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 210);
            this.Controls.Add(this.gridPlacas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "formHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro historico";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlacas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPlacas;
        private System.Windows.Forms.DataGridViewTextBoxColumn rid;
        private System.Windows.Forms.DataGridViewImageColumn Foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn rHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn rcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDefecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn rCausa;
        private System.Windows.Forms.DataGridViewTextBoxColumn xRefe;
        private System.Windows.Forms.DataGridViewTextBoxColumn rCorrectiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn rReparador;
        private System.Windows.Forms.DataGridViewTextBoxColumn rTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn rHora;
    }
}