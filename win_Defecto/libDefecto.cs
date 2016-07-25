using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using M77;

namespace ControlDeReparacion
{
    class libDefecto
    {
        public DataGridView grid;
        public TextBox txt;

        public void load()
        {
            grid.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"Select id,defecto from defecto where id_sector = '" + Operador.sector_id + "' order by defecto");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    grid.Rows.Add(
                        r["id"].ToString(),
                        r["defecto"].ToString()
                    );
                }
            }
        }
  
        public void add()
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("INSERT INTO `defecto` (`defecto`,`id_sector`) VALUES ('" + txt.Text + "','" + Operador.sector_id + "');");
            if (rs)
            {
                load();
                txt.Text = "";
            }
            else
            {
                MessageBox.Show("Error al insertar.");
            }
        }
        public void del(string id)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("DELETE FROM `defecto` WHERE `id`='" + id + "' limit 1;");
            if (rs)
            {
                load();
            }
            else
            {
                MessageBox.Show("Error al eliminar.");
            }
        }
        public void update(string id)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("UPDATE `defecto` SET `defecto`='" + txt.Text + "' WHERE `id`='" + id + "' limit 1;");
            if (rs)
            {
                load();
            }
            else
            {
                MessageBox.Show("Error al editar.");
            }
        }
    }
}
