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
    public partial class formActual : Form
    {
        public formActual()
        {
            InitializeComponent();
        }

        private void formActual_Load(object sender, EventArgs e)
        {
            load_combo_modelo();

            string modelo = Config.current_modelo; // Config.ini.Read("local", "modelo").ToUpper();
            string lote = Config.current_lote; // Config.ini.Read("local", "lote").ToUpper();
            string panel = Config.current_panel; // Config.ini.Read("local", "panel").ToUpper();

            comboModelo.SelectedIndex = comboModelo.FindStringExact(modelo);
            comboLote.SelectedIndex = comboLote.FindStringExact(lote);
            comboPanel.SelectedIndex = comboPanel.FindStringExact(panel);
        }

        private void load_combo_modelo()
        {
            comboModelo.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,modelo from modelo where id_sector = '" + Operador.sector_id + "'  order by modelo");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Combo val = new Combo(r["modelo"].ToString(), Ingenieria.CARPETA + r["modelo"].ToString());
                    comboModelo.Items.Add(val);
                }
            }
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_lote();
        }

        private void comboLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_panel();
        }
        
        private void combo_lote()
        {
            if (comboModelo.SelectedIndex >= 0)
            {
                comboLote.Items.Clear();
                Ingenieria.combo_Lotes(Combo.valor(comboModelo), comboLote);
            }
        }
        private void combo_panel()
        {
            if (comboLote.SelectedIndex >= 0)
            {
                load_combo_panel();
            }
        }

        private void load_combo_panel()
        {
            comboPanel.Items.Clear();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
select 
m.modelo,
p.panel
from panel p

left join (
select id,modelo,id_sector from modelo
) as m
on m.id = p.id_modelo

where m.id_sector = '" + Operador.sector_id + "' and m.modelo = '" + Combo.nombre(comboModelo) + "' order by p.panel");

            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    comboPanel.Items.Add(r["panel"].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string modelo = Combo.nombre(comboModelo);
            string lote = Combo.nombre(comboLote);
            string panel = comboPanel.Items[comboPanel.SelectedIndex].ToString();

            Config.current_modelo = modelo;
            Config.current_lote = lote;
            Config.current_panel = panel;

            //Config.ini.Write("local","modelo",modelo);
            //Config.ini.Write("local", "lote", lote);
            //Config.ini.Write("local", "panel", panel);
            this.Close();
        }
    }
}
