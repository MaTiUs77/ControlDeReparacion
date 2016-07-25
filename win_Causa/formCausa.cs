using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeReparacion
{
    public partial class formCausa : Form
    {
        libCausa lib = new libCausa();

        public string modo = "add";
        public string sql_id = "";

        public formCausa()
        {
            InitializeComponent();
        }

        private void formCausa_Load(object sender, EventArgs e)
        {
            lib.grid = causa_grid;
            lib.txt = inCausa;

            lib.load();

            modoAdd();
        }

        private void modoEdit() {
            modo = "edit";

            boxTitulo.Text = "Editar causa";
            btAgregar.Text = "Actualizar";

            panelAdd.ColumnStyles[2].Width = 85;
            inCausa.Focus();
        }
        private void modoAdd() {
            modo = "add";

            boxTitulo.Text = "Agregar causa";
            btAgregar.Text = "Agregar";

            inCausa.Text = "";

            panelAdd.ColumnStyles[2].Width = 0;
        }

        private void Actualizar() {
            lib.update(sql_id);
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
            DataGridViewRow cell = causa_grid.Rows[row];

            int editar = cell.Cells["editar"].ColumnIndex;
            int eliminar = cell.Cells["eliminar"].ColumnIndex;
            
            string id = cell.Cells["id"].Value.ToString();
            string causa = cell.Cells["causa"].Value.ToString();
            
            if (col == editar)
            {
                modoEdit();
                inCausa.Text = causa;

                sql_id = id;
            }
            else if (col == eliminar)
            {
                lib.del(id);
            }
        }

        public void btAgregar_Click(object sender, EventArgs e)
        {
            if (inCausa.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la causa.");
            }
            else
            {
                switch (modo)
                {
                    case "add":
                        lib.add();
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
