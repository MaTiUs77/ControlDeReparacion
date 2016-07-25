namespace ControlDeReparacion
{
    partial class formModelo
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
            this.boxTitulo = new System.Windows.Forms.GroupBox();
            this.panelAdd = new System.Windows.Forms.TableLayoutPanel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.intxt = new System.Windows.Forms.ComboBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelini = new System.Windows.Forms.TableLayoutPanel();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.boxTitulo.SuspendLayout();
            this.panelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelini.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxTitulo
            // 
            this.boxTitulo.Controls.Add(this.panelAdd);
            this.boxTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxTitulo.Location = new System.Drawing.Point(8, 8);
            this.boxTitulo.Name = "boxTitulo";
            this.boxTitulo.Size = new System.Drawing.Size(452, 53);
            this.boxTitulo.TabIndex = 0;
            this.boxTitulo.TabStop = false;
            this.boxTitulo.Text = "Nuevo modelo";
            // 
            // panelAdd
            // 
            this.panelAdd.ColumnCount = 3;
            this.panelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.panelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelAdd.Controls.Add(this.btCancelar, 2, 0);
            this.panelAdd.Controls.Add(this.btAgregar, 1, 0);
            this.panelAdd.Controls.Add(this.intxt, 0, 0);
            this.panelAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdd.Location = new System.Drawing.Point(3, 16);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.RowCount = 1;
            this.panelAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAdd.Size = new System.Drawing.Size(446, 34);
            this.panelAdd.TabIndex = 2;
            // 
            // btCancelar
            // 
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(349, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(88, 28);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregar.Location = new System.Drawing.Point(265, 3);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(75, 28);
            this.btAgregar.TabIndex = 1;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // intxt
            // 
            this.intxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intxt.FormattingEnabled = true;
            this.intxt.Location = new System.Drawing.Point(3, 3);
            this.intxt.Name = "intxt";
            this.intxt.Size = new System.Drawing.Size(256, 28);
            this.intxt.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.defecto,
            this.panel,
            this.editar,
            this.eliminar});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(8, 67);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(452, 263);
            this.grid.TabIndex = 1;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.causas_grid_CellContentClick);
            // 
            // panelini
            // 
            this.panelini.ColumnCount = 1;
            this.panelini.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelini.Controls.Add(this.grid, 0, 1);
            this.panelini.Controls.Add(this.boxTitulo, 0, 0);
            this.panelini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelini.Location = new System.Drawing.Point(0, 0);
            this.panelini.Name = "panelini";
            this.panelini.Padding = new System.Windows.Forms.Padding(5);
            this.panelini.RowCount = 2;
            this.panelini.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.panelini.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelini.Size = new System.Drawing.Size(468, 338);
            this.panelini.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // defecto
            // 
            this.defecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.defecto.HeaderText = "Modelo";
            this.defecto.Name = "defecto";
            this.defecto.ReadOnly = true;
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.panel.HeaderText = "";
            this.panel.Name = "panel";
            this.panel.ReadOnly = true;
            this.panel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.panel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.panel.Text = "Paneles";
            this.panel.UseColumnTextForButtonValue = true;
            this.panel.Width = 19;
            // 
            // editar
            // 
            this.editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.editar.HeaderText = "";
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.editar.Text = "Editar";
            this.editar.UseColumnTextForButtonValue = true;
            this.editar.Width = 19;
            // 
            // eliminar
            // 
            this.eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.eliminar.HeaderText = "";
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseColumnTextForButtonValue = true;
            this.eliminar.Width = 19;
            // 
            // formModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 338);
            this.Controls.Add(this.panelini);
            this.Name = "formModelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar modelos";
            this.Load += new System.EventHandler(this.formCausa_Load);
            this.boxTitulo.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelini.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxTitulo;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TableLayoutPanel panelini;
        private System.Windows.Forms.TableLayoutPanel panelAdd;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.ComboBox intxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn defecto;
        private System.Windows.Forms.DataGridViewButtonColumn panel;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
    }
}