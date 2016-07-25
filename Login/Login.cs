using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using M77;

namespace ControlDeReparacion
{
    class Login
    {
        public static bool validar(string clave)
        {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
select 
o.id
,o.nombre
,o.apellido
,o.flag_acceso
,o.id_turno
,o.id_sector
,s.sector 
,o.id_area
,a.area

from operador o

left join (
select id,sector from sector 
) as s
on s.id = o.id_sector 

left join (
select id,area from area 
) as a
on a.id = o.id_area 

where clave = '" + clave+"' limit 1");
            if (sql.rows)
            {
                DataRow r = dt.Rows[0];
                Operador.id = r["id"].ToString(); 
                
                Operador.nombre = r["nombre"].ToString();
                Operador.apellido  = r["apellido"].ToString();

                Operador.acceso = r["flag_acceso"].ToString();

                Operador.sector = r["sector"].ToString();
                Operador.sector_id = r["id_sector"].ToString();

                Operador.area = r["area"].ToString();
                Operador.area_id = r["id_area"].ToString();

                Operador.turno = r["id_turno"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
