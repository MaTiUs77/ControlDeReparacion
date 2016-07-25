using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using M77;

namespace ControlDeReparacion
{
    class libModelo
    {
        public DataGridView grid;

        public void load()
        {
            grid.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"Select id,modelo from modelo where id_sector = '"+Operador.sector_id+"' order by modelo");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    grid.Rows.Add(
                        r["id"].ToString(),
                        r["modelo"].ToString()
                    );
                }
            }
        }

        private string new_modelo(string modelo,string sector)
        {
            string id = "";
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"Select id,modelo from modelo where modelo = '" + modelo + "' and id_sector = '"+sector+"' limit 1");
            if (sql.rows)
            {
                DataRow r = dt.Rows[0];
                id = r["id"].ToString();
            }
            return id;
        }
  
        public void add(string txt)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("INSERT INTO `modelo` (`modelo`,`id_sector`) VALUES ('" + txt + "','" + Operador.sector_id + "');");
            if (rs)
            {

                try
                {
                    string modelo_url = Ingenieria.CARPETA + "" + txt;

                    List<string> lotes = Ingenieria.lotes(modelo_url);

                    if (lotes.Count >= 0)
                    {
                        List<string> pcblist = new List<string>();
                        string lote_path = modelo_url + @"\" + lotes[0];
 
                        DataTable dt = Ingenieria.leer_lote(lote_path);
                        pcblist = Ingenieria.pcb(dt);

                        libPanel npanel = new libPanel();
                        npanel.id_modelo = new_modelo(txt, Operador.sector_id);

                        foreach (string panel in pcblist)
                        {
                            npanel.add(panel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron agregar automaticamente los paneles. Por favor ingrese paneles al modelo.");
                }

                load();

            }
            else
            {
                MessageBox.Show("Error al insertar.");
            }
        }
        public void del(string id)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("DELETE FROM `modelo` WHERE `id`='" + id + "' limit 1;");
            if (rs)
            {
                load();
            }
            else
            {
                MessageBox.Show("Error al eliminar.");
            }
        }
        public void update(string id,string txt)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("UPDATE `modelo` SET `modelo`='" + txt + "' WHERE `id`='" + id + "' limit 1;");
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
