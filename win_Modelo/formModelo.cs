using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using M77;

namespace ControlDeReparacion
{
    public partial class formModelo : Form
    {
        libModelo lib = new libModelo();

        public string modo = "add";
        public string sql_id = "";

        public formModelo()
        {
            InitializeComponent();
        }

        private void formCausa_Load(object sender, EventArgs e)
        {

            lib.grid = grid;

            Ingenieria.combo_Modelos(intxt);

            lib.load();

            modoAdd();
        }

        private void modoEdit() {
            modo = "edit";

            boxTitulo.Text = "Editar modelo";
            btAgregar.Text = "Actualizar";

            panelAdd.ColumnStyles[2].Width = 85;
        }
        private void modoAdd() {
            modo = "add";

            boxTitulo.Text = "Agregar modelo";
            btAgregar.Text = "Agregar";

            panelAdd.ColumnStyles[2].Width = 0;
        }

        private void Actualizar() {
            string modelo = intxt.Text.Trim();
            lib.update(sql_id,modelo);
            modoAdd();
        }

        private void causas_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            cellClick(row,col);
        }

        private void cellClick(int row,int col)
        {
            DataGridViewRow cell = grid.Rows[row];

            int editar = cell.Cells["editar"].ColumnIndex;
            int eliminar = cell.Cells["eliminar"].ColumnIndex;
            int paneles = cell.Cells["panel"].ColumnIndex;

            string id = cell.Cells["id"].Value.ToString();
            string causa = cell.Cells["defecto"].Value.ToString();
            
            if (col == editar)
            {
                modoEdit();
                intxt.SelectedIndex = intxt.FindStringExact(causa);
                sql_id = id;
            }
            else if (col == eliminar)
            {
                lib.del(id);
            } 
            else if(col == paneles) 
            {
                formPanel fm = new formPanel();
                fm.sql_id = id;
                fm.ShowDialog();
            }
        }

        public void btAgregar_Click(object sender, EventArgs e)
        {
            string modelo = intxt.Text.Trim();
            if (modelo == "")
            {
                MessageBox.Show("Ingrese el modelo.");
            }
            else
            {
                switch (modo)
                {
                    case "add":
                        lib.add(modelo);
                        modoAdd();
                        break;
                    case "edit":
                        Actualizar();
                        break;
                }
            }
        }
        public void btCancelar_Click(object sender, EventArgs e)
        {
            modoAdd();
        }
        private void inCausa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btAgregar_Click(sender, e);
            }
        }
    }
}
