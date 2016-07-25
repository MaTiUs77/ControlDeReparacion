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
    public partial class formOnline : Form
    {
        public int minutos = 10;

        public formOnline()
        {
            InitializeComponent();
        }

        private void formOnline_Load(object sender, EventArgs e)
        {
            AutoRefresh();
        }

        private void AutoRefresh()
        {
            Timer t = new Timer();
            timer1.Enabled = true;

            Online();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Online();
        }

        private void Offline_delete() { 
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("delete from pc where fecha < DATE_SUB(NOW(), INTERVAL  "+minutos+" MINUTE)");
        }
        
        private void Online() {

            Offline_delete();

            gridOnline.Rows.Clear();

            Mysql sql = new Mysql();
            DataTable dt = sql.Select(@"
SELECT  
IF(
    p.fecha > DATE_SUB(NOW(), INTERVAL  " + minutos + @" MINUTE)
    ,'ONLINE'
    ,'OFFLINE'
) as estado

,CONCAT(o.nombre ,' ', o.apellido) as operador
,s.sector
,p.hostname
,p.vr

,DATE_FORMAT(p.fecha, '%d/%m/%Y') as fecha
,DATE_FORMAT(p.fecha, '%H:%i') as hora
,ar.area
,f.acceso

from pc p

left join (
    select id,nombre,apellido,id_sector,id_area,flag_acceso from operador
) as o
on o.id = p.id_operador

left join (
    select id,sector from sector
) as s
on s.id = o.id_sector

left join (
    select flag,acceso from acceso
) as f
on f.flag = o.flag_acceso

left join (
    select id,area from area
) as ar
on ar.id = o.id_area

order by estado desc
");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    gridOnline.Rows.Add(
                        r["estado"].ToString() , 
                        r["operador"].ToString(),
                        r["sector"].ToString(),
                        r["area"].ToString(),
                        r["acceso"].ToString(),
                        r["hostname"].ToString(),
                        r["vr"].ToString(),
                        r["fecha"].ToString() ,
                        r["hora"].ToString()                
                    );
                }
            }
        }
    }
}
