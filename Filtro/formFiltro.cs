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
    public partial class formFiltro : Form
    {
        Form1 mainForm;

        public formFiltro(Form1 fm)
        {
            InitializeComponent();
            mainForm = fm;
        }

        private void formFiltro_Load(object sender, EventArgs e)
        {
            chScrap.Checked = Filtros.scrap;
            chPen.Checked = Filtros.pendiente;
            chRep.Checked = Filtros.reparado;
            chBonepile.Checked = Filtros.bonepile;
            chAnalisis.Checked = Filtros.analisis;

            Filtros.codigo = "";

            cargar_comboModelo();
            cargar_comboOperador();
            cargar_comboArea();
            cargar_comboTurno();
            cargar_comboReferencias();

            comboDefecto.Enabled = false;
            comboCausa.Enabled = false;
            comboOrigen.Enabled = false;
            comboReferencia.Enabled = true;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        public void AplicarFiltro()
        {
            if (comboModelo.SelectedIndex < 0) { Filtros.modelo = ""; }
            else
            {
                Filtros.modelo = comboModelo.Text;
            }

            if (comboLote.SelectedIndex < 0) { Filtros.lote = ""; }
            else
            {
                Filtros.lote = comboLote.Text;
            }

            if (comboPlaca.SelectedIndex < 0) { Filtros.panel = ""; }
            else
            {
                Filtros.panel = comboPlaca.Text;
            }

            if (comboOperador.SelectedIndex < 0) { Filtros.operador = ""; }
            else
            {
                Filtros.operador = Combo.valor(comboOperador);
            }

            if (comboArea.SelectedIndex < 0) { Filtros.area = ""; }
            else
            {
                Filtros.area = Combo.valor(comboArea);
            }

            if (comboTurno.SelectedIndex < 0) { Filtros.turno = ""; }
            else
            {
                Filtros.turno = Combo.valor(comboTurno);
            }

            if (comboReferencia.Text.Equals("")) { Filtros.referencia = ""; }
            else
            {
                Filtros.referencia = comboReferencia.Text;
            }

            Filtros.desde = FechaDesde.Value.Year + "-" + FechaDesde.Value.Month + "-" + FechaDesde.Value.Day;
            Filtros.hasta = FechaHasta.Value.Year + "-" + FechaHasta.Value.Month + "-" + FechaHasta.Value.Day;

            mainForm.aplicarFiltro();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            // Reset;
            comboModelo.Text = "";
            comboLote.Text = "";
            comboPlaca.Text = "";

            comboOperador.Text = "";
            comboArea.Text = "";
            comboTurno.Text = "";
            comboReferencia.Text = "";

            FechaDesde.Value = DateTime.Now;
            FechaHasta.Value = DateTime.Now;
            chScrap.Checked = true;
            chPen.Checked = true;
            chRep.Checked = true;
            chBonepile.Checked = true;
            chAnalisis.Checked = true;

            Filtros.limpiar();

            mainForm.aplicarFiltro();
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboModeloChanged();
        }

        public void cargar_comboModelo() {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
            SELECT
            DISTINCT(d.modelo)
            from reparacion d
            where d.id_sector = '" + Operador.sector_id + "' group by d.modelo order by d.modelo asc ");

            foreach (DataRow row in dt.Rows)
            {
                comboModelo.Items.Add(row["modelo"].ToString());
            }
        }

        public void cargar_comboReferencias() {

            comboReferencia.AutoCompleteCustomSource = null;
            comboReferencia.Items.Clear();
            comboReferencia.Text = "";

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            Mysql sql = new Mysql();
            string desde = FechaDesde.Value.Year + "-" + FechaDesde.Value.Month + "-" + FechaDesde.Value.Day;
            string hasta = FechaHasta.Value.Year + "-" + FechaHasta.Value.Month + "-" + FechaHasta.Value.Day;

            DataTable dt = sql.Select(@"SELECT 
            DISTINCT(h.defecto) referencia

            from historial h

            where  

            h.id_sector = '"+Operador.sector_id+@"'  
            and  h.fecha >= '"+desde+@"' 
            and h.fecha <= '"+hasta+@"'  

            group by h.defecto
            ");

            if (sql.rows)
            {
                List<string> lref = new List<string>();

                foreach (DataRow r in dt.Rows)
                {
                    string referencia = r["referencia"].ToString();
                    string[] sep = referencia.Split(',');

                    foreach (string rp in sep)
                    {                        
                        if (!lref.Contains(rp))
                        {
                            data.Add(rp);
                            lref.Add(rp);
                            comboReferencia.Items.Add(rp);
                        }
                    }
                }
            }

            comboReferencia.AutoCompleteCustomSource = data;
        }
        public void cargar_comboOperador()
        {
            comboOperador.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
            SELECT
            DISTINCT(d.id_operador)
            ,o.nombre
            ,o.apellido

            from reparacion d

            left join (
                select id,nombre,apellido from operador
            ) as o
            on o.id = d.id_operador

            where 
            d.id_sector = '" + Operador.sector_id + @"' 
            group by d.id_operador
            order by o.nombre desc");

            foreach (DataRow row in dt.Rows)
            {
                string nombre = row["nombre"].ToString() + " " + row["apellido"].ToString();
                Combo val = new Combo(nombre, row["id_operador"].ToString());
                comboOperador.Items.Add(val);
            }
        }
        public void cargar_comboTurno()
        {
            comboTurno.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"SELECT id ,turno from turno  order by turno desc");

            foreach (DataRow row in dt.Rows)
            {
                Combo val = new Combo(row["turno"].ToString(), row["id"].ToString());
                comboTurno.Items.Add(val);
            }
        }

        public void cargar_comboArea()
        {
            comboArea.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"SELECT id ,area from area  order by area desc");

            foreach (DataRow row in dt.Rows)
            {
                Combo val = new Combo(row["area"].ToString(), row["id"].ToString());
                comboArea.Items.Add(val);
            }
        }   

        public bool comboModeloChanged()
        {
            if (comboModelo.SelectedIndex >= 0)
            {
                comboLote.Items.Clear();
                comboPlaca.Items.Clear();

                Mysql sql = new Mysql();
                DataTable dt = sql.Select(@"
                SELECT
                DISTINCT(d.lote)
                from reparacion d
                where 
                d.modelo = '" + comboModelo.Text + @"' and 
                d.id_sector = '"+Operador.sector_id+ @"' 
                group by d.lote 
                order by d.lote desc");

                foreach (DataRow row in dt.Rows)
                {
                    comboLote.Items.Add(row["lote"].ToString());
                }

                comboLote.Text = "";

                fillPlacas();
            }
            return true;
        }

        public bool fillPlacas()
        {
            comboPlaca.Items.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
            SELECT
            DISTINCT(d.panel)
            from reparacion d
            where 
            d.modelo = '" + comboModelo.Text + @"' and 
            d.id_sector = '" + Operador.sector_id + @"' 
            group by d.panel 
            order by d.panel desc
            ");

            foreach (DataRow row in dt.Rows)
            {
                comboPlaca.Items.Add(row["panel"].ToString());
            }

            comboPlaca.Text = "";

            return true;
        }

        private void chScrap_CheckedChanged(object sender, EventArgs e)
        {
            Filtros.scrap = chScrap.Checked;
        }

        private void chBonepile_CheckedChanged(object sender, EventArgs e)
        {
            Filtros.bonepile = chBonepile.Checked;
        }

        private void chAnalisis_CheckedChanged(object sender, EventArgs e)
        {
            Filtros.analisis = chAnalisis.Checked;
        }

        private void chPen_CheckedChanged(object sender, EventArgs e)
        {
            Filtros.pendiente = chPen.Checked;
        }

        private void chRep_CheckedChanged(object sender, EventArgs e)
        {
            Filtros.reparado = chRep.Checked;
        }

        private void FechaDesde_ValueChanged(object sender, EventArgs e)
        {
            cargar_comboReferencias();
        }

        private void FechaHasta_ValueChanged(object sender, EventArgs e)
        {
            cargar_comboReferencias();
        }
    }
}
