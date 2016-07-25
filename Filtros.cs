using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeReparacion
{
    class Filtros
    {
        public static string stats_desde = "";
        public static string stats_hasta = "";

        public static string modelo = "";
        public static string lote = "";
        public static string panel = "";

        public static string operador = "";
        public static string area = "";
        public static string turno = "";

        public static string desde = "";
        public static string hasta = "";

        public static string codigo = "";
        public static string referencia = "";

        public static bool scrap = true;
        public static bool reparado = true;
        public static bool pendiente = true;
        public static bool bonepile = true;
        public static bool analisis = true;

        public static void limpiar() {
            modelo = "";
            lote = "";
            panel = "";
            operador = "";
            area = "";
            turno = "";
            desde = "";
            hasta = "";
            codigo = "";
            referencia = "";
            scrap = true;
            reparado = true;
            pendiente = true;
            bonepile = true;
            analisis = true;
            stats_desde = "";
            stats_hasta = "";
        }
    }
}
