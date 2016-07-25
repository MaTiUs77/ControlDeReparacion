using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using M77;

namespace ControlDeReparacion
{
    class libPanel
    {
        public string id_modelo = "";

        public DataGridView grid;
        public TextBox txt;

        public void load()
        {
            txt.Text = "";
            grid.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
select 
m.modelo,
p.id,
p.panel
from panel p

left join (
select id,modelo,id_sector from modelo
) as m
on m.id = p.id_modelo

where m.id = '" + id_modelo + "' order by p.panel");

            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    grid.Rows.Add(
                        r["id"].ToString(),
                        r["panel"].ToString()
                    );
                }
            }
        }
  
        public bool add(string txt)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("INSERT INTO `panel` (`id_modelo`,`panel`) VALUES ('"+id_modelo+"', '" + txt + "');");
            if (rs)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error al insertar.");
                return false;
            }
        }
        public void del(string id)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("DELETE FROM `panel` WHERE `id`='" + id + "' limit 1;");
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
            bool rs = sql.Ejecutar("UPDATE `panel` SET `panel`='" + txt.Text + "' WHERE `id`='" + id + "' limit 1;");
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
