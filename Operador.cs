using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeReparacion
{
    class Operador
    {
        public static string id = "1";
        public static string nombre = "Liliana Cabrera";
        public static string apellido = "Liliana Cabrera";
        public static string acceso = "R";
        public static string turno = "2";
        public static string sector_id = "1";
        public static string sector = "Lenovo";

        public static string area_id = "1";
        public static string area = "IA-REPARACION";

        public static bool admin()
        {
            if (acceso == "A") { return true; } else { return false; }
        }

        public static bool invitado()
        {
            if (acceso == "I") { return true; } else { return false; }
        }

        public static bool inspector()
        {
            if (acceso == "N") { return true; } else { return false; }
        }

        public static bool reparador()
        {
            if (acceso == "R" || acceso == "T") { return true; } else { return false; }
        }
    }
}
