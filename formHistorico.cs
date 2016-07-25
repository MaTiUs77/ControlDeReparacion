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
    public partial class formHistorico : Form
    {
        public formHistorico()
        {
            InitializeComponent();
        }

        private void formHistorico_Load(object sender, EventArgs e)
        {
            // Guardo filtros aplicados anteriormente...
            bool pen = Filtros.pendiente;
            bool rep = Filtros.reparado;
            bool scr = Filtros.scrap;
            bool bon = Filtros.bonepile;
            bool ana = Filtros.analisis;

            // Activo todos los filtros
            Filtros.pendiente = true;
            Filtros.reparado = true;
            Filtros.scrap = true;
            Filtros.bonepile = true;
            Filtros.analisis = true;


            load_reporte_placas();
            Filtros.codigo = ""; // Reseteo codigo para que la main principal no lo tome como filtro al refrescar

            // Reestablezo filtros.
            Filtros.pendiente = pen;
            Filtros.reparado = rep;
            Filtros.scrap = scr;
            Filtros.bonepile = bon;
            Filtros.analisis = ana;
        }

        public void load_reporte_placas()
        {
            Cursor.Current = Cursors.WaitCursor;

            gridPlacas.Rows.Clear();

//            Mysql sql = new Mysql();
            DataTable dt = Reparacion.Get();

            int i = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    string log = d["historico"].ToString();

                    string historial = d["reparaciones"].ToString();
                    int his = 0;
                    if (historial == "")
                    {
                        his = 0;
                    }
                    else
                    {
                        his = int.Parse(historial);
                    }

                    string flag = d["estado"].ToString();
                    string flag_txt = "";

                    switch (flag)
                    {
                        case "P": flag_txt = "Pendiente"; break;
                        case "R": flag_txt = "Reparado"; break;
                        case "S": flag_txt = "Scrap"; break;
                        case "B": flag_txt = "Bonepile"; break;
                        case "A": flag_txt = "Analisis"; break;
                    }

                    Image pic;
                    if (d["fotos"].ToString() == "" || d["fotos"].ToString() == "0")
                    {
                        pic = new Bitmap(1, 1);
                    }
                    else
                    {
                        pic = ControlDeReparacion.Properties.Resources.camera;
                    }

                    i = gridPlacas.Rows.Add(
                         d["id"],
                         pic,
                         his,
                         flag_txt,
                         d["codigo"],
                         d["modelo"],
                         d["lote"],
                         d["panel"],
                         d["defecto"],
                         d["causa"],
                         d["referencia"],
                         d["accion"],
                         d["correctiva"],
                         d["origen"],
                         d["nombre"] + " " + d["apellido"],
                         d["turno"],
                         d["area"],
                         d["fecha"],
                         d["hora"]);


                    if (flag == "P")
                    {
                        rowPendiente(gridPlacas.Rows[i]);
                    }

                    if (flag == "S")
                    {
                        rowScrap(gridPlacas.Rows[i]);
                    }

                    if (flag == "B")
                    {
                        rowBonepile(gridPlacas.Rows[i]);
                    }

                    if (flag == "A")
                    {
                        rowAnalisis(gridPlacas.Rows[i]);
                    }

                    if (log == "log")
                    {
                        rowHistorico(gridPlacas.Rows[i]);
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void rowPendiente(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#FBFF7A");
        }

        private void rowBonepile(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#88D12E");
        }
        private void rowAnalisis(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#00fffa");
        }
        private void rowScrap(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#000000", "#FF6B6B");
        }
        private void rowHistorico(DataGridViewRow row)
        {
            Utilidades.rowColor(row, "#7A7A7A", "#C2C2C2");
        }

        private void gridPlacas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            switch (col)
            {
                case 1: // Columna de imagen
                    string cod = gridPlacas.Rows[row].Cells["rcodigo"].Value.ToString();
                    formGaleria fh = new formGaleria(cod);
                    if (fh.foto)
                    {
                        fh.Show();
                    }
                break;
            }
        }      
    }
}
