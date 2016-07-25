namespace ControlDeReparacion
{
    partial class formUsuario
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
            this.btAgregar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.comboSector = new System.Windows.Forms.ComboBox();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.comboAcceso = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inClave = new System.Windows.Forms.TextBox();
            this.inApellido = new System.Windows.Forms.TextBox();
            this.inNombre = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.boxTitulo.SuspendLayout();
            this.panelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxTitulo
            // 
            this.boxTitulo.Controls.Add(this.panelAdd);
            this.boxTitulo.Controls.Add(this.comboArea);
            this.boxTitulo.Controls.Add(this.comboSector);
            this.boxTitulo.Controls.Add(this.comboTurno);
            this.boxTitulo.Controls.Add(this.label7);
            this.boxTitulo.Controls.Add(this.comboAcceso);
            this.boxTitulo.Controls.Add(this.label6);
            this.boxTitulo.Controls.Add(this.label5);
            this.boxTitulo.Controls.Add(this.label4);
            this.boxTitulo.Controls.Add(this.label3);
            this.boxTitulo.Controls.Add(this.label2);
            this.boxTitulo.Controls.Add(this.label1);
            this.boxTitulo.Controls.Add(this.inClave);
            this.boxTitulo.Controls.Add(this.inApellido);
            this.boxTitulo.Controls.Add(this.inNombre);
            this.boxTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxTitulo.Location = new System.Drawing.Point(10, 10);
            this.boxTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.boxTitulo.Name = "boxTitulo";
            this.boxTitulo.Size = new System.Drawing.Size(689, 120);
            this.boxTitulo.TabIndex = 0;
            this.boxTitulo.TabStop = false;
            this.boxTitulo.Text = "Nuevo usuario";
            // 
            // panelAdd
            // 
            this.panelAdd.ColumnCount = 2;
            this.panelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.panelAdd.Controls.Add(this.btAgregar, 0, 0);
            this.panelAdd.Controls.Add(this.btCancelar, 1, 0);
            this.panelAdd.Location = new System.Drawing.Point(502, 27);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.RowCount = 1;
            this.panelAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelAdd.Size = new System.Drawing.Size(164, 73);
            this.panelAdd.TabIndex = 11;
            // 
            // btAgregar
            // 
            this.btAgregar.BackColor = System.Drawing.SystemColors.Control;
            this.btAgregar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAgregar.Location = new System.Drawing.Point(3, 3);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(74, 63);
            this.btAgregar.TabIndex = 7;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = false;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(84, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(74, 63);
            this.btCancelar.TabIndex = 8;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // comboSector
            // 
            this.comboSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSector.FormattingEnabled = true;
            this.comboSector.Location = new System.Drawing.Point(252, 84);
            this.comboSector.Name = "comboSector";
            this.comboSector.Size = new System.Drawing.Size(111, 21);
            this.comboSector.TabIndex = 5;
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(133, 84);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(111, 21);
            this.comboTurno.TabIndex = 4;
            // 
            // comboAcceso
            // 
            this.comboAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAcceso.FormattingEnabled = true;
            this.comboAcceso.Location = new System.Drawing.Point(16, 84);
            this.comboAcceso.Name = "comboAcceso";
            this.comboAcceso.Size = new System.Drawing.Size(111, 21);
            this.comboAcceso.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Sector";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Turno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Acceso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // inClave
            // 
            this.inClave.Location = new System.Drawing.Point(250, 42);
            this.inClave.Name = "inClave";
            this.inClave.PasswordChar = '*';
            this.inClave.Size = new System.Drawing.Size(111, 20);
            this.inClave.TabIndex = 2;
            // 
            // inApellido
            // 
            this.inApellido.Location = new System.Drawing.Point(133, 43);
            this.inApellido.Name = "inApellido";
            this.inApellido.Size = new System.Drawing.Size(111, 20);
            this.inApellido.TabIndex = 1;
            // 
            // inNombre
            // 
            this.inNombre.Location = new System.Drawing.Point(16, 43);
            this.inNombre.Name = "inNombre";
            this.inNombre.Size = new System.Drawing.Size(111, 20);
            this.inNombre.TabIndex = 0;
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
            this.nombre,
            this.apellido,
            this.turno,
            this.sector,
            this.area,
            this.acceso,
            this.pass,
            this.editar,
            this.eliminar});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(8, 138);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(693, 323);
            this.grid.TabIndex = 1;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.causas_grid_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxTitulo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(709, 469);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 69;
            // 
            // apellido
            // 
            this.apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.Width = 69;
            // 
            // turno
            // 
            this.turno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.turno.HeaderText = "Turno";
            this.turno.Name = "turno";
            this.turno.ReadOnly = true;
            this.turno.Width = 60;
            // 
            // sector
            // 
            this.sector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sector.HeaderText = "Sector";
            this.sector.Name = "sector";
            this.sector.ReadOnly = true;
            this.sector.Width = 63;
            // 
            // area
            // 
            this.area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.area.HeaderText = "Area";
            this.area.Name = "area";
            this.area.ReadOnly = true;
            this.area.Width = 54;
            // 
            // acceso
            // 
            this.acceso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.acceso.HeaderText = "Acceso";
            this.acceso.Name = "acceso";
            this.acceso.ReadOnly = true;
            // 
            // pass
            // 
            this.pass.HeaderText = "Clave";
            this.pass.Name = "pass";
            this.pass.ReadOnly = true;
            this.pass.Visible = false;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Area";
            // 
            // comboArea
            // 
            this.comboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(370, 84);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(111, 21);
            this.comboArea.TabIndex = 6;
            // 
            // formUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(580, 507);
            this.Name = "formUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar usuarios";
            this.Load += new System.EventHandler(this.formCausa_Load);
            this.boxTitulo.ResumeLayout(false);
            this.boxTitulo.PerformLayout();
            this.panelAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxTitulo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboSector;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.ComboBox comboAcceso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inClave;
        private System.Windows.Forms.TextBox inApellido;
        private System.Windows.Forms.TextBox inNombre;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.TableLayoutPanel panelAdd;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sector;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewTextBoxColumn acceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
    }
}