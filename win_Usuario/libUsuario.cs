using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using M77;

namespace ControlDeReparacion
{
    class libUsuario
    {
        public DataGridView grid;

        public string nombre;
        public string apellido;
        public string clave;
        public string id_acceso;
        public string id_turno;
        public string id_sector;
        public string id_area;

        public void load()
        {
            grid.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
Select 
o.id,o.nombre,o.apellido,o.clave,
a.acceso,
t.turno,
s.sector,
ar.area

from operador as o

left join (
select id,turno from turno 
) as t
on t.id = o.id_turno

left join (
select id,sector from sector 
) as s
on s.id = o.id_sector

left join (
select id,area from area
) as ar
on ar.id = o.id_area

left join (
select flag,acceso from acceso 
) as a
on a.flag = o.flag_acceso

order by apellido
");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    grid.Rows.Add(
                        r["id"].ToString(),
                        r["nombre"].ToString(),
                        r["apellido"].ToString(),
                        r["turno"].ToString(),
                        r["sector"].ToString(),
                        r["area"].ToString(),
                        r["acceso"].ToString(),
                        r["clave"].ToString()
                    );
                }
            }
        }
        public void add()
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar(@"
            INSERT INTO `operador` (`nombre`, `apellido`, `clave`, `flag_acceso`, `id_turno`, `id_sector`, `id_area`) VALUES 
                                   (UPPER('" + nombre + "'),UPPER('" + apellido + "'), '" + clave + "', '" + id_acceso + "', '" + id_turno + "', '" + id_sector + "', '" + id_area + "');");
            if (rs)
            {
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
            bool rs = sql.Ejecutar("DELETE FROM `operador` WHERE `id`='" + id + "' limit 1;");
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
            bool rs = sql.Ejecutar(@"UPDATE `operador` SET `nombre`=UPPER('" + nombre + "'),`apellido`=UPPER('" + apellido + "'),`clave`='" + clave + "',`id_turno`='" + id_turno + "',`id_sector`='" + id_sector + "',`id_area`='" + id_area + "',`flag_acceso`='" + id_acceso + "' WHERE `id`='" + id + "' limit 1;");
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
