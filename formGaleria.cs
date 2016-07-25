using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using M77;

namespace ControlDeReparacion
{
    public partial class formGaleria : Form
    {
        public string codigo = "";
        public bool foto = false;

        public formGaleria(string _codigo)
        {
            InitializeComponent();
            codigo = _codigo;
            fotosSql();
        }

        private void formHistorial_Load(object sender, EventArgs e)
        {
        }

        private void verImagenCompletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private bool fotosSql() {
            bool rs = false;
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select archivo from fotos where codigo = '"+codigo+"' and id_sector ='"+Operador.sector_id+"' ");

            List<string> fotos = new List<string>();
            string vars = "";

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    fotos.Add(r["archivo"].ToString());
                }

                if (fotos.Count > 0)
                {
                    vars = "?img[]=";
                    vars += string.Join("&img[]=", fotos);
                    rs = true;
                }

                Uri url = new Uri(Config.apache + "galeria.php" + vars);
                webBrowser1.Url = url;
            }
            else
            {
                rs = false;
                MessageBox.Show("No hay imagenes disponibles en este codigo.");
            }
            foto = rs;
            return rs;
        }
    }
}
