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
    public partial class formSector : Form
    {
        public bool cambiar_sector = true;
        public bool cambiar_area = true;

        public bool iniciarCambio = false;

        public formSector()
        {
            InitializeComponent();
        }

        private void formActual_Load(object sender, EventArgs e)
        {
            load_combo_sector();
            load_combo_area();

            comboSector.SelectedIndex = comboSector.FindStringExact(Operador.sector);
            comboArea.SelectedIndex = comboArea.FindStringExact(Operador.area);

            if (!cambiar_sector)
            {
                comboSector.Enabled = false;
            }
            if (!cambiar_area)
            {
                comboArea.Enabled = false;
            }
        }

        private void load_combo_sector()
        {
            comboSector.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt;

            if (Operador.admin())
            {
                dt = sql.Select("select id,sector from sector order by sector");
            }
            else
            {
                dt = sql.Select("select id,sector from sector where visible = 1 order by sector");
            }

            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboSector.Items.Add(new Combo(r["sector"].ToString(),r["id"].ToString()));
                }
            }
        }

        private void load_combo_area()
        {
            comboArea.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,area from area  order by area");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboArea.Items.Add(new Combo(r["area"].ToString(), r["id"].ToString()));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sector = Combo.valor(comboSector);
            string area = Combo.valor(comboArea);

            if (!Operador.invitado())
            {
                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar("update operador set id_sector = '"+sector+"', id_area = '"+area+"' where id = '"+Operador.id+"' limit 1");
            }

            Operador.sector_id = sector;
            Operador.sector = Combo.nombre(comboSector);

            Operador.area_id = area;
            Operador.area = Combo.nombre(comboArea);

            iniciarCambio = true;
            
            this.Close();
        }
    }
}
