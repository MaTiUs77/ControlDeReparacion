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
    public partial class formUsuario : Form
    {
        libUsuario lib = new libUsuario();

        public string modo = "add";
        public string sql_id = "";

        public formUsuario()
        {
            InitializeComponent();
        }

        private void formCausa_Load(object sender, EventArgs e)
        {
            lib.grid = grid;

            lib.load();

            load_combo_sector();
            load_combo_area();
            load_combo_turno();
            load_combo_acceso();

            modoAdd();
        }

        private void modoEdit() {
            modo = "edit";

            boxTitulo.Text = "Editar usuario";
            btAgregar.Text = "Actualizar";

            panelAdd.ColumnStyles[1].Width = 83;
            inNombre.Focus();
        }

        private void modoAdd() {
            modo = "add";

            boxTitulo.Text = "Agregar usuario";
            btAgregar.Text = "Agregar";

            inNombre.Text = "";
            inApellido.Text = "";
            inClave.Text = "";

            comboAcceso.SelectedIndex = -1;
            comboTurno.SelectedIndex = -1;
            comboSector.SelectedIndex = -1;
            comboArea.SelectedIndex = -1;

            panelAdd.ColumnStyles[1].Width= 0;

            inNombre.Focus();
        }

        private void Actualizar() {

            lib.nombre = inNombre.Text;
            lib.apellido = inApellido.Text;
            lib.clave = inClave.Text;
            lib.id_acceso = Combo.valor(comboAcceso);
            lib.id_turno = Combo.valor(comboTurno);
            lib.id_sector = Combo.valor(comboSector);
            lib.id_area = Combo.valor(comboArea);
            lib.update(sql_id);
            modoAdd();
        }

        private void load_combo_acceso() {
            comboAcceso.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select flag,acceso from acceso order by acceso");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboAcceso.Items.Add(new Combo(r["acceso"].ToString(), r["flag"].ToString()));
                }
            }
        }
        private void load_combo_turno()
        {
            comboTurno.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,turno from turno order by turno");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboTurno.Items.Add(new Combo(r["turno"].ToString(), r["id"].ToString()));
                }
            }
        }
        private void load_combo_sector()
        {
            comboSector.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,sector from sector order by sector");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboSector.Items.Add(new Combo(r["sector"].ToString(), r["id"].ToString()));
                }
            }
        }
        private void load_combo_area()
        {
            comboArea.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,area from area order by area");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboArea.Items.Add(new Combo(r["area"].ToString(), r["id"].ToString()));
                }
            }
        }   

        private void causas_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            cellClick(row,col);
        }

        private void cellClick(int row,int col)
        {
            if (row >= 0)
            {
                DataGridViewRow cell = grid.Rows[row];

                int editar = cell.Cells["editar"].ColumnIndex;
                int eliminar = cell.Cells["eliminar"].ColumnIndex;

                string id = cell.Cells["id"].Value.ToString();

                string Nombre = cell.Cells["nombre"].Value.ToString();
                string Apellido = cell.Cells["apellido"].Value.ToString();
                string Turno = cell.Cells["turno"].Value.ToString();
                string Sector = cell.Cells["sector"].Value.ToString();
                string Acceso = cell.Cells["acceso"].Value.ToString();
                string Area = cell.Cells["area"].Value.ToString();
                string Clave = cell.Cells["pass"].Value.ToString();

                if (col == editar)
                {
                    modoEdit();

                    inNombre.Text = Nombre;
                    inApellido.Text = Apellido;
                    inClave.Text = Clave;

                    comboTurno.SelectedIndex = comboTurno.FindStringExact(Turno);
                    comboSector.SelectedIndex = comboSector.FindStringExact(Sector);
                    comboArea.SelectedIndex = comboArea.FindStringExact(Area);
                    comboAcceso.SelectedIndex = comboAcceso.FindStringExact(Acceso);

                    sql_id = id;
                }
                else if (col == eliminar)
                {
                    if (MessageBox.Show(Nombre + " " + Apellido + ", confirma eliminar?", "Borrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lib.del(id);
                    }
                }
            }
        }

        public void btAgregar_Click(object sender, EventArgs e)
        {
            if (
                inNombre.Text.Trim() == "" ||
                inApellido.Text.Trim() == "" ||
                inClave.Text.Trim() == "" ||
                comboAcceso.SelectedIndex < 0 ||
                comboTurno.SelectedIndex < 0 ||
                comboArea.SelectedIndex < 0 ||
                comboSector.SelectedIndex < 0
               )
            {
                MessageBox.Show("Complete los campos!");
            }
            else
            {
                switch (modo)
                {
                    case "add":
            
                        lib.nombre = inNombre.Text;
                        lib.apellido = inApellido.Text;
                        lib.clave = inClave.Text;
                        lib.id_acceso = Combo.valor(comboAcceso);
                        lib.id_turno = Combo.valor(comboTurno);
                        lib.id_sector = Combo.valor(comboSector);
                        lib.id_area = Combo.valor(comboArea);

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
