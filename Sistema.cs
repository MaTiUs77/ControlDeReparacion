using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M77;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace ControlDeReparacion
{
    public class Sistema
    {
        public static string _actualizar = "";
        public static string _mantenimiento = "";

        // Actualizo estado de PC
        public static string host = "";
        public static string flag = "";
        public static string id = "";

        public static object[] fechayhora() {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select CONVERT(STR_TO_DATE(CURDATE(),'%Y-%m-%d') USING latin1) as fecha,CURTIME() as hora");

            object[] date = new object[2];

            if (sql.rows)
            {
                DataRow r = dt.Rows[0];
                date[0] = r["fecha"].ToString();
                date[1] = r["hora"].ToString();
            }
            return date;
        }

        public static void load() {
            Mysql sql = new Mysql();
            DataTable dt = sql.Select("select variable,valor from sistema");
            if (sql.rows)
            {
                foreach (DataRow r in dt.Rows)
                {
                    string variable = r["variable"].ToString();
                    string valor = r["valor"].ToString();

                    switch (variable)
                    {
                        case "forzar_actualizacion":
                            _actualizar = valor;
                        break;
                        case "mantenimiento":
                            _mantenimiento = valor;
                        break;
                    }
                }
            }
        }

        public static bool mantenimiento()
        {
            bool rs = false;
            if (_mantenimiento == "si")
            {
                MessageBox.Show("El ADMINISTRADOR solicito un mantenimiento del sistema, ingrese en unos minutos...");
                rs = true;
            }
            else
            {
                rs = false;
            }
            return rs;
        }

        public static bool actualizar()
        {
            bool rs = false;
            if (_actualizar == "si")
            {
                MessageBox.Show("Se detecto una version nueva, se actualizara el sistema.");
                rs = true;
            }
            else
            {
                rs = false;
            }
            return rs;
        }

        public static void ping()
        {
            if (Sistema.mantenimiento())
            {
                Application.Exit();
            }
            else
            {
                string ver = Utilidades.Version();
                host = Dns.GetHostEntry(Dns.GetHostName()).HostName.ToString();

                Mysql sql = new Mysql();
                string str = "select id,hostname,flag from pc where hostname = '" + host + "' limit 1";
                DataTable rs = sql.Select(str);
                if (sql.rows)
                {
                    DataRow r = rs.Rows[0];
                    flag = r["flag"].ToString();
                    id = r["id"].ToString();

                    switch (flag)
                    {
                        case "A":
                            MessageBox.Show("El ADMINISTRADOR solicito actualizar el Control de Reparacion.", "ADMINISTRACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql.Ejecutar("Update `pc` set flag = '' where id = '" + id + "' limit 1");
                            Utilidades.Actualizar_version();
                            break;
                        case "B":
                            MessageBox.Show("El ADMINISTRADOR bloqueo el acceso de esta PC, pongase en contacto para mas informacion.", "ADMINISTRACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                            break;
                        default:
                            sql.Ejecutar("Update `pc` set `vr` = '" + ver + "', fecha = NOW(), id_operador = '" + Operador.id + "' where id = '" + id + "' limit 1");
                            break;
                    }
                }
                else
                {
                    sql.Ejecutar("INSERT INTO `pc` (`hostname`, `vr`, `fecha`,`id_operador` ) VALUES ('" + host + "', '" + ver + "', NOW(), '" + Operador.id + "');");
                }
            }
        }
    }
}
