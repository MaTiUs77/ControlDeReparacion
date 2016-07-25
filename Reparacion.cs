using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using M77;
using System.Drawing;
using System.Xml.Linq;

namespace ControlDeReparacion
{
    public class Reparacion
    {
        public static bool ModoHistorial = false;

        public bool existe = false;

        public string codigo = "";
        public string id = "";
        public int reparaciones = 0;

        // Variables
        public string flag = "";

        public string modelo = "";
        public string lote ="";
        public string panel = "";
        public string id_causa = "";
        public string id_defecto = "";
        public string defecto = "";
        public string id_accion = "";
        public string correctiva = "";
        public string id_origen = "";
        public string estado = "";
        public string fecha = "";
        public string hora = "";

        //Formato
        List<Reparacion> listaReparacion;

        public bool log = false;
        public int historial = 0;
        public string flag_txt = "";
        public Image imagen;
        public string causa = "";
        public string[] referencia;
        public string accion = "";
        public string origen = "";
        public string nombre = "";
        public string apellido = "";
        public string turno = "";
        public string area = "";

        public void Nuevo(string _codigo) { 
            codigo = _codigo;
            Existe();
        }        
        public bool Existe()
        {
            bool rs = false;
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,codigo,estado from reparacion where codigo = '" + codigo + "' and id_sector = '" + Operador.sector_id + "' order by id desc limit 1");
            if (sql.rows)
            {
                id = dt.Rows[0]["id"].ToString();
                flag = dt.Rows[0]["estado"].ToString();
                rs = true;
            }
            existe = rs;
            return rs;
        }
        public void Set(string _modelo, string _lote, string _panel, string _id_causa, string _id_defecto, string _defecto, string _id_accion, string _correctiva, string _id_origen, string _estado) {
            modelo = _modelo;
            lote = _lote;
            panel = _panel;
            id_causa = _id_causa;
            id_defecto = _id_defecto;
            defecto = _defecto;
            id_accion = _id_accion;
            correctiva = _correctiva;
            id_origen = _id_origen;
            estado = _estado;

            object[] fyh = Sistema.fechayhora();
            fecha = fyh[0].ToString();
            hora = fyh[1].ToString();
        }

        public List<Reparacion> Formato()
        {
            Mysql sql = new Mysql();
            DataTable dt = Reparacion.Get();



            listaReparacion = new List<Reparacion>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    Reparacion rp = new Reparacion();
                    if (d["historico"].ToString().Equals("log"))
                    {
                        rp.log = true;
                    }
                    else
                    {
                        rp.log = false;
                    }

                    string _reparaciones = d["reparaciones"].ToString();
                    if (!_reparaciones.Equals(""))
                    {
                        rp.historial = int.Parse(_reparaciones);
                    }

                    rp.flag = d["estado"].ToString();

                    switch (rp.flag)
                    {
                        case "P": rp.flag_txt = "Pendiente"; break;
                        case "R": rp.flag_txt = "Reparado"; break;
                        case "S": rp.flag_txt = "Scrap"; break;
                        case "B": rp.flag_txt = "BonePile"; break;
                        case "A": rp.flag_txt = "Analisis"; break;
                    }

                    if (d["fotos"].ToString().Equals("") || d["fotos"].ToString().Equals("0"))
                    {
                        rp.imagen = new Bitmap(1, 1);
                    }
                    else
                    {
                        rp.imagen = ControlDeReparacion.Properties.Resources.camera;
                    }

                    if (rp.log)
                    {
                        rp.flag_txt = "Cerrado: " + rp.flag_txt;
                    }

                    rp.id = d["id"].ToString();
                    rp.codigo = d["codigo"].ToString();
                    rp.modelo = d["modelo"].ToString();
                    rp.lote = d["lote"].ToString();
                    rp.panel = d["panel"].ToString();
                    rp.defecto = d["defecto"].ToString();
                    rp.causa = d["causa"].ToString();
                    rp.referencia = d["referencia"].ToString().Split(',').ToArray();
                    rp.accion = d["accion"].ToString();
                    rp.correctiva = d["correctiva"].ToString();
                    rp.origen = d["origen"].ToString();
                    rp.nombre = d["nombre"].ToString();
                    rp.apellido = d["apellido"].ToString();
                    rp.turno = d["turno"].ToString();
                    rp.area = d["area"].ToString();
                    rp.fecha = d["fecha"].ToString();
                    rp.hora = d["hora"].ToString();

                    listaReparacion.Add(rp);
                }
            }
            return listaReparacion;
        }

        public bool Ingresar() {
            Mysql sql = new Mysql();
            string addString = @"
                INSERT INTO  `reparacion` (`id` ,`codigo`,`id_operador` ,`modelo` ,`lote` ,`panel` ,`id_causa` ,`id_defecto` ,`defecto` ,`id_accion` ,`correctiva` ,`id_origen` ,`id_turno` ,`fecha` ,`hora`,`estado`,`id_sector`,`id_area`)
                VALUES (NULL , '" + codigo + "' ,  '" + Operador.id + "',  '" + modelo + "',  '" + lote + "',  '" + panel + "',  '" + id_causa + "',  '" + id_defecto + "',  '" + defecto + "', '" + id_accion + "', '" + correctiva + "', '" + id_origen + "',  '" + Operador.turno + "',   '" + fecha + "', '" + hora + "','" + estado + "',  '" + Operador.sector_id + "',  '" + Operador.area_id + "');";
            bool rs = sql.Ejecutar(addString);

            if (rs)
            {
                // Si se inserto el dato genero un HISTORIAL
                Historiar();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Historiar()
        {
            Mysql sql = new Mysql();

            string addString = @"
                INSERT INTO  `historial` (`id` ,`codigo`,`id_operador` ,`modelo` ,`lote` ,`panel` ,`id_causa` ,`id_defecto` ,`defecto` ,`id_accion` ,`correctiva` ,`id_origen` ,`id_turno` ,`fecha` ,`hora`,`estado`,`id_sector`,`id_area`)
                VALUES (NULL , '" + codigo + "' ,  '" + Operador.id + "',  '" + modelo + "',  '" + lote + "',  '" + panel + "',  '" + id_causa + "',  '" + id_defecto + "',  '" + defecto + "', '" + id_accion + "', '" + correctiva + "', '" + id_origen + "',  '" + Operador.turno + "',   '" + fecha + "', '" + hora + "','" + estado + "',  '" + Operador.sector_id + "',  '" + Operador.area_id + "');";
            bool rs = sql.Ejecutar(addString);

            if (rs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Reparar()
        {
            Mysql sql = new Mysql();
            string addString = @"UPDATE `reparacion` SET `id_operador`='" + Operador.id + "',`id_area`='" + Operador.area_id + "',`id_turno`='" + Operador.turno + "', `id_defecto`='" + id_defecto + "',`id_causa`='" + id_causa + "', `defecto`='" + defecto + "', `id_accion`='" + id_accion + "',`correctiva`='" + correctiva + "',`id_origen`='" + id_origen + "', `estado`='" + estado + "',`fecha`='" + fecha + "', `hora`='" + hora + "' WHERE `codigo`='" + codigo + "' and `id`='" + id + "' limit 1";
            bool rs = sql.Ejecutar(addString);
            if (rs)
            {
                // Historiar
                Historiar();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> Modelos_sql()
        {
            List<string> resultado = new List<string>();
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,modelo from modelo where id_sector = '" + Operador.sector_id + "' order by modelo");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    resultado.Add(r["modelo"].ToString());
                }
            }
            return resultado;
        }

        public static List<string> Lotes_ing(string modelo)
        {
            List<string> pcblist = new List<string>();
            try
            {
                string modelo_url = Ingenieria.CARPETA + "" + modelo;
                List<string> lotes = Ingenieria.lotes(modelo_url);

                if (lotes.Count >= 0)
                {
                    foreach (string lote in lotes)
                    {
                        pcblist.Add(lote.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron agregar automaticamente los paneles. Por favor ingrese paneles al modelo.");
            }
            return pcblist;
        }

        public static List<string> Panel_ing(string modelo) {
            List<string> pcblist = new List<string>();
            try
            {
                string modelo_url = Ingenieria.CARPETA + "" + modelo;
                List<string> lotes = Ingenieria.lotes(modelo_url);

                if (lotes.Count >= 0)
                {
                    string lote_path = modelo_url + @"\" + lotes[0];

                    DataTable dt = Ingenieria.leer_lote(lote_path);
                    pcblist = Ingenieria.pcb(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron agregar automaticamente los paneles. Por favor ingrese paneles al modelo.");
            }
            return pcblist;
        }

        
      
        public static DataTable Get()
        {
            #region OLD_QUERY
            /*
            string sql = @"
SELECT 

 z.id
,z.codigo
,operador.nombre
,operador.apellido
,z.modelo
,z.lote
,z.panel
,causa.causa
,defecto.defecto
,z.defecto as referencia
,accion.accion
,origen.origen
,z.correctiva
,z.estado
,turno.turno
,DATE_FORMAT(z.fecha, '%d/%m/%Y') as fecha
,DATE_FORMAT(z.hora, '%H:%i') as hora
,sector.sector
,area.area

,(
    select COUNT(*) from fotos f 
    WHERE  
        f.codigo = z.codigo  AND
        f.id_sector = z.id_sector
    group by f.codigo
) AS fotos

,(
    select COUNT(*) from reparacion rc
    where 
        rc.estado = 'R'
    AND rc.codigo = z.codigo
    AND rc.id_sector = z.id_sector
    group by rc.codigo
) AS reparaciones

,IF(
    (
    select 
    STR_TO_DATE(CONCAT(rh.fecha,' ',rh.hora),'%Y-%m-%d %H:%i:%s') 
    from reparacion rh
    where 
        rh.codigo = z.codigo and
        rh.id_sector = z.id_sector
    order by rh.id desc
    limit 1
    ) = STR_TO_DATE(CONCAT(z.fecha,' ',z.hora),'%Y-%m-%d %H:%i:%s'),'actual','log'
) as historico

from 
area area
,operador operador
,turno turno
,accion accion
,sector sector
,origen origen
,defecto defecto
,causa causa
,reparacion r

-- RECORRER TABLA HISTORIAL
left join (
    select * from historial
    order by id desc
) as z
on 
z.codigo = r.codigo
 
where
    z.id_area = area.id
and z.id_operador = operador.id
and z.id_turno = turno.id
and z.id_accion = accion.id
and z.id_sector = sector.id
and z.id_origen = origen.id
and z.id_defecto = defecto.id
and z.id_causa = causa.id
";
            */
            #endregion


            DataTable dt = new DataTable();

            List<string> parametros = new List<string>();
            List<string> filtroEstados = new List<string>();

            parametros.Add("id_sector=" + Operador.sector_id);

            if (!Filtros.desde.Equals("") && !Filtros.hasta.Equals(""))
            {
                parametros.Add("fecha_desde=" + Filtros.desde);
                parametros.Add("fecha_hasta=" + Filtros.hasta);
            }
            else
            {
                parametros.Add("fecha_desde=curdate");
            }

            if (!Filtros.codigo.Equals(""))
            {
                parametros.Add("barcode=" + Filtros.codigo);
            } else
            {
                if (!Filtros.modelo.Equals(""))
                {
                    parametros.Add("modelo=" + Filtros.modelo);
                }

                if (!Filtros.lote.Equals(""))
                {
                    parametros.Add("lote=" + Filtros.lote);
                }

                if (!Filtros.panel.Equals(""))
                {
                    parametros.Add("panel=" + Filtros.panel);
                }

                if (!Filtros.area.Equals(""))
                {
                    parametros.Add("id_area=" + Filtros.area);
                }

                if (!Filtros.turno.Equals(""))
                {
                    parametros.Add("id_turno=" + Filtros.turno);
                }

                if (!Filtros.operador.Equals(""))
                {
                    parametros.Add("id_operador=" + Filtros.operador);
                }

                if (!Filtros.referencia.Equals(""))
                {
                    parametros.Add("referencia=" + Filtros.referencia);
                }
               
                if (Filtros.scrap)
                {
                    filtroEstados.Add("S");
                }

                if (Filtros.bonepile)
                {
                    filtroEstados.Add("B");
                }
                if (Filtros.analisis)
                {
                    filtroEstados.Add("A");
                }
                if (Filtros.reparado)
                {
                    filtroEstados.Add("R");
                }

                if (Filtros.pendiente)
                {
                    filtroEstados.Add("P");
                }

                if (filtroEstados.Count > 0)
                {
                    parametros.Add("estados="+ string.Join("|", filtroEstados));
                }
            }


            try
            {
                XDocument lista = Service.getFilter(string.Join("&", parametros));
                dt = ServiceCore.XElementToDataTable(lista);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: "+ ex.Message);
            }

            return dt;
        }
      

        public static string Estadisticas() {
            string sql = @"
select 

r.fecha,

r.modelo,
r.lote,
r.panel,

-- Datos calculados por modelo,lote,panel y fecha 
s.scrap,
p.pendiente,
d.reparado

from reparacion r

left join (
    select COUNT(*) as scrap,modelo,lote,panel, estado,fecha from reparacion 
    where 
    estado = 'S'
    group by modelo,lote,panel,fecha
) as s
on
s.modelo = r.modelo and
s.lote = r.lote and
s.panel = r.panel and
s.fecha = r.fecha


left join (
    select COUNT(*) as pendiente,modelo,lote,panel, estado,fecha from reparacion 
    where 
    estado = 'P'
    group by modelo,lote,panel,fecha
) as p
on
p.modelo = r.modelo and
p.lote = r.lote and
p.panel = r.panel and
p.fecha = r.fecha

left join (
    select COUNT(*) as reparado,modelo,lote,panel, estado,fecha from reparacion 
    where 
    estado = 'R'
    group by modelo,lote,panel,fecha
) as d
on
d.modelo = r.modelo and
d.lote = r.lote and
d.panel = r.panel and
d.fecha = r.fecha


/*
WHERE
r.modelo = '318408C' and
r.lote = 'L101' 
-- r.panel = 'MAI' 
*/

group by 

r.modelo
,r.lote
,r.panel
,r.fecha

order by 
r.fecha DESC,
r.hora DESC";
            return sql;
        }
        public static string Stat_estado() {
            string sql = @"
select 

DATE_FORMAT(r.fecha, '%d/%m/%Y') as fecha,

IF(s.scrap IS NULL , 0,s.scrap) as scrap,
IF(p.pendiente IS NULL , 0,p.pendiente) as pendiente,
IF(d.reparado IS NULL , 0,d.reparado) as reparado,

( IF(s.scrap IS NULL , 0,s.scrap) + IF(p.pendiente IS NULL , 0,p.pendiente) + IF(d.reparado IS NULL , 0,d.reparado)) as rechazos

 ,t.turno

from reparacion r

left join (
    select id,turno from turno
) as t
on 
t.id = r.id_turno

left join (
    select COUNT(*) as scrap,estado,fecha,id_sector from reparacion 
    where 
    estado = 'S'
    group by fecha, id_sector
) as s
on
s.fecha = r.fecha and
s.id_sector = r.id_sector


left join (
    select COUNT(*) as pendiente,estado,fecha, id_sector from reparacion 
    where 
    estado = 'P'
    group by fecha, id_sector
) as p
on
p.fecha = r.fecha and
p.id_sector = r.id_sector


left join (
    select COUNT(*) as reparado,estado,fecha, id_sector from reparacion 
    where 
    estado = 'R'
    group by fecha, id_sector
) as d
on
d.fecha = r.fecha and
d.id_sector = r.id_sector


where 

r.id_sector = '"+Operador.sector_id+@"' and

r.fecha >= '" + Filtros.stats_desde + "' and r.fecha <= '" + Filtros.stats_hasta + @"'

group by 

r.fecha,
r.id_sector

order by 
r.fecha asc";
            return sql;
        }
        public static string Stat_turno(int turno)
        {
            string sql = @"
select 

DATE_FORMAT(r.fecha, '%d/%m/%Y') as fecha,

IF(s.scrap IS NULL , 0,s.scrap) as scrap,
IF(p.pendiente IS NULL , 0,p.pendiente) as pendiente,
IF(d.reparado IS NULL , 0,d.reparado) as reparado,

( IF(s.scrap IS NULL , 0,s.scrap) + IF(p.pendiente IS NULL , 0,p.pendiente) + IF(d.reparado IS NULL , 0,d.reparado)) as rechazos

 ,t.turno

from reparacion r

left join (
    select id,turno from turno
) as t
on 
t.id = r.id_turno

left join (
    select COUNT(*) as scrap,estado,fecha,id_turno,id_sector from reparacion 
    where 
    estado = 'S'
    group by fecha, id_turno,id_sector
) as s
on
s.fecha = r.fecha and
s.id_turno = r.id_turno and
s.id_sector = r.id_sector


left join (
    select COUNT(*) as pendiente,estado,fecha, id_turno,id_sector from reparacion 
    where 
    estado = 'P'
    group by fecha, id_turno,id_sector
) as p
on
p.fecha = r.fecha and
p.id_turno = r.id_turno and
p.id_sector = r.id_sector


left join (
    select COUNT(*) as reparado,estado,fecha, id_turno,id_sector from reparacion 
    where 
    estado = 'R'
    group by fecha, id_turno,id_sector
) as d
on
d.fecha = r.fecha and
d.id_turno = r.id_turno and
d.id_sector = r.id_sector

where 

r.id_turno = '" + turno+@"' 
and r.fecha >= '" + Filtros.stats_desde + "' and r.fecha <= '" + Filtros.stats_hasta + @"'
and r.id_sector = '" +Operador.sector_id+@"'

group by 

r.fecha,
t.turno

order by 
r.fecha asc";
            return sql;
        }
        /*
        public static DataTable Info(string codigo)
        {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
SELECT 
r.id,
r.codigo,
op.nombre,
op.apellido,
r.modelo,
r.lote,
r.panel,
a.causa,
de.txt_defecto,
r.defecto,
r.correctiva,
r.estado,
t.turno,
DATE_FORMAT(r.fecha, '%d/%m/%Y') as fecha,
DATE_FORMAT(r.hora, '%H:%i') as hora ,
h.historial

FROM `reparacion` as r

left join (
select id,nombre,apellido from operador 
) as op
on op.id = r.id_operador

left join (
select id,causa from causa
) as a
on a.id = r.id_causa

left join (
select id,defecto as txt_defecto from defecto
) as de
on de.id = r.id_defecto

left join (
select id,turno from turno
) as t
on t.id = r.id_turno

left join (
select COUNT(*) as historial,codigo from historial group by codigo
) as h
on h.codigo = r.codigo

limit 1");
            return dt;
        }
         */ 
        
       /* public static bool Scrap_insertar(string codigo,string estado) { 
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select id,codigo,modelo,lote,panel,id_causa,id_defecto,defecto,id_accion,correctiva,id_origen from reparacion where codigo = '" + codigo + "' and id_sector = '" + Operador.sector_id + "' order by id desc limit 1");

            if (sql.rows)
            {
                DataRow r = dt.Rows[0];
                string modelo = r["modelo"].ToString();
                string lote = r["lote"].ToString();
                string panel = r["panel"].ToString();
                string id_causa = r["id_causa"].ToString();
                string id_defecto = r["id_defecto"].ToString();
                string defecto = r["defecto"].ToString();
                string id_accion = r["id_accion"].ToString();
                string correctiva = r["correctiva"].ToString();
                string id_origen = r["id_origen"].ToString();

                bool rs = Ingresar(codigo, modelo, lote, panel, id_causa, id_defecto, defecto, id_accion, correctiva, id_origen, estado);
                if (rs)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Scrap(string codigo,string estado)
        {
            Mysql sql = new Mysql();
            string addString = @"UPDATE `reparacion` SET `id_operador`='" + Operador.id + "',`id_area`='" + Operador.area_id + "',`id_turno`='" + Operador.turno + "',`estado`='" + estado + "', `fecha`=CURDATE(), `hora`=CURTIME() WHERE `codigo`='" + codigo + "' and id = '" + id + "' limit 1";
            bool rs = sql.Ejecutar(addString);
            if (rs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */ 

        public static string RechazoTotal() {
            string cmd = @"select estado ,COUNT(*) as total  from historial ";

            
            List<string> sqlString = new List<string>();
            
            sqlString.Add(" id_sector = '" + Operador.sector_id + "' ");
            
            if (!Filtros.modelo.Equals("")) {   sqlString.Add(" modelo = '" + Filtros.modelo + "' ");  }
            if (!Filtros.lote.Equals(""))  {    sqlString.Add(" lote = '" + Filtros.lote + "' "); }
            if (!Filtros.panel.Equals("")) {    sqlString.Add(" panel = '" + Filtros.panel + "' ");          }

            if (!Filtros.turno.Equals("")) { sqlString.Add(" id_turno = '" + Filtros.turno + "' "); }
            if (!Filtros.operador.Equals("")) { sqlString.Add(" id_operador = '" + Filtros.operador + "' "); }
            if (!Filtros.area.Equals("")) { sqlString.Add(" id_area = '" + Filtros.area + "' "); }

            if (!Filtros.desde.Equals("") && !Filtros.hasta.Equals(""))
            {
                sqlString.Add(" fecha >= '" + Filtros.desde + "' and fecha <= '" + Filtros.hasta + "' ");
            }
            else
            {
                sqlString.Add(" fecha = CURDATE() ");
            }
            
            if (sqlString.Count > 0)
            {
                cmd += " where ";
                cmd += string.Join(" and ", sqlString);
            }

            cmd += "group by estado";

            return cmd;
        }

        public static int rechazos = 0;
        public static int pendientes = 0;
        public static int reparados = 0;
        public static int scrap = 0;
        public static int bonepile = 0;
        public static int analisis = 0;
    }
}