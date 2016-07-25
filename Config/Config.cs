using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows.Forms;
using System.Net;
using System.Data;
using System.Deployment.Application;
using M77;

namespace ControlDeReparacion
{
    class Config
    {
        public static int reparacion_limite = 2;
        public static int version_ini = 4;

        public static string current_modelo = "";
        public static string current_lote = "";
        public static string current_panel = "";

        public static string reparacion_folder = @"C:\M77\control_de_reparacion\";
        public static string server = "10.30.10.22";
        public static string apache = "http://10.30.10.22/reparacion/";

        public static string config_file = "";
        public static INIFile ini;

        public static void set(string ini_path)
        {
            config_file = ini_path;
            ini = new INIFile(config_file);
        }

        public static void start()
        {
            Config.set(Config.reparacion_folder+"config.ini");

            if (Config.exist_path())
            {
                if (Config.exist_ini())
                {
                    Config.load();
                    if (!version())
                    {
                        save_new();
                    }
                }
                else
                {
                    save_new();
                }
            }
            else
            {
                MessageBox.Show("No existe y no se puede crear la carpeta " + Config.config_file + " por favor verifique que exista.");
                Application.Exit();
            }
        }

        public static bool version() {
            string ver = ini.Read("version", "ver");
            if (ver == "")
            {
                return false;
            } else {
                int vr = int.Parse(ver);

                if (vr == Config.version_ini)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void save_new() {
            Config.save(
                            Config.server,
                            "reparacion",
                            "reparador",
                            "acceso",
                            @"\\ush-nt-3\v1\Users\INSAUT\PLANTA_3\TECNICOS_3\Programacion\LISTAS\"
                        );

            Config.load();
        }

        public static void load()
        {
            //Config.apache= ini.Read("rutas", "apache");
            Config.server = ini.Read("servidor", "server");
            Ingenieria.CARPETA = ini.Read("rutas", "listas");

            Mysql.server = ini.Read("servidor", "server");
            Mysql.database = Utilidades.Decrypt_byte(ini.Read("servidor", "database"));
            Mysql.user = Utilidades.Decrypt_byte(ini.Read("servidor", "user"));
            Mysql.password = Utilidades.Decrypt_byte(ini.Read("servidor", "pass"));

            Ingenieria.iniciar();
        }
        public static void save(string server,string database,string user,string pass,string listas)
        {
            ini.Write("servidor", "server", server);

            ini.Write("servidor", "database", Utilidades.Encrypt_byte(database));
            ini.Write("servidor", "user", Utilidades.Encrypt_byte(user));
            ini.Write("servidor", "pass", Utilidades.Encrypt_byte(pass));

            ini.Write("rutas", "listas", listas);
            ini.Write("rutas", "apache", Config.apache.ToString());
            ini.Write("version","ver",Config.version_ini.ToString());
        }

        public static bool exist_ini()
        {
            return Archivos.existe(config_file);
        }

        public static bool exist_path()
        {
            return Archivos.crear_carpeta(config_file);
        }
    }
}
