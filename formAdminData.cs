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
    public partial class formAdminData : Form
    {
        public formAdminData()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> t = new List<string>();

            foreach (DataGridViewRow row in gridHasta.Rows)
            {
                string txt = row.Cells[1].Value.ToString().Trim();
                t.Add(txt);
            }

            sqlAdd(t);
        }

        public List<string> sqlAdded() {
            string info = Combo.valor(comboInfo);

            List<string> added = new List<string>();

            Mysql sql = new Mysql();
            string query = "select * from `" + info + "` where id_sector = '"+Operador.sector_id+"'";
            DataTable dt = sql.Select(query);
            if (sql.rows)
            {
                foreach(DataRow r in dt.Rows) {
                    added.Add(r[info].ToString());
                }
            }
            return added;
        }

        public void sqlAdd(List<string> txt_list)
        {
            string info = Combo.valor(comboInfo);

            List<string> prepare = new List<string>();
            List<string> added = sqlAdded();


            foreach (string txt in txt_list)
            {
                if(!added.Contains(txt.Trim())) {
                    prepare.Add("('" + txt + "','" + Operador.sector_id + "')");
                } 
            }

            if (prepare.Count > 0)
            {
                Mysql sql = new Mysql();
                string query = "INSERT INTO `" + info + "` (`" + info + "`,`id_sector`) VALUES " + String.Join(",", prepare) + ";";

                bool rs = sql.Ejecutar(query);
                if (rs)
                {
                    MessageBox.Show("Cambios guardados!");
                }
                else
                {
                    MessageBox.Show("Error al guardar cambios.");
                }
            }
            else
            {
                MessageBox.Show("Sin cambios.");
            }
        }
        
        private void formAdminData_Load(object sender, EventArgs e)
        {
            load_combo_sector();
            comboInfo.Items.Add(new Combo("Origen", "origen"));
            comboInfo.Items.Add(new Combo("Defectos", "defecto"));
            comboInfo.Items.Add(new Combo("Causas", "causa"));
            comboInfo.Items.Add(new Combo("Accion correctiva", "accion"));
        }

        public void loadDesde(string id_sector,string info)
        {
            gridDesde.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"Select id," + info + " from " + info + "  where id_sector = '" + id_sector + "'  order by " + info + "");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    gridDesde.Rows.Add(
                        r["id"].ToString(),
                        r[info].ToString()
                    );
                }
            }
        }

        public void loadHasta(string info)
        {
            gridHasta.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"Select id," + info + " from " + info + "  where id_sector = '" + Operador.sector_id + "'  order by " + info + "");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    gridHasta.Rows.Add(
                        r["id"].ToString(),
                        r[info].ToString()
                    );
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id_sector = Combo.valor(comboSector);
            string info = Combo.valor(comboInfo);
            loadDesde(id_sector,info);
            loadHasta(info);
            lblDesde.Text = Combo.nombre(comboSector) + " - " + Combo.nombre(comboInfo);
            lblHasta.Text = Operador.sector + " - " + Combo.nombre(comboInfo);
        }

        // Cargar sectores
        private void load_combo_sector()
        {
            comboSector.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,sector from sector  order by sector");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboSector.Items.Add(new Combo(r["sector"].ToString(), r["id"].ToString()));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridDesde.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                gridDesde.Rows.Remove(row);
                gridHasta.Rows.Add(rowData);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridDesde.Rows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                gridHasta.Rows.Add(rowData);
            }
            gridDesde.Rows.Clear();
        }

        private void gridHasta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            if (col == 2)
            {
                DataGridViewRow erow = gridHasta.Rows[row];
                object[] rowData = new object[erow.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = erow.Cells[i].Value;
                }
//                gridDesde.Rows.Add(rowData);
                gridHasta.Rows.RemoveAt(row);
            }
        }

        private void gridDesde_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            if (col == 2)
            {
                DataGridViewRow erow = gridDesde.Rows[row];
                object[] rowData = new object[erow.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = erow.Cells[i].Value;
                }
                gridDesde.Rows.RemoveAt(row);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> clip = Utilidades.GetClipboard();
            foreach (string fila in clip)
            {
                gridHasta.Rows.Add("",fila);
            }
        }
    }
}
