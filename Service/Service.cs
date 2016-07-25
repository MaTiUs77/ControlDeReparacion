using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ControlDeReparacion
{
    class Service : ServiceCore
    {
        public static XDocument getFilter(string parametros)
        {
            return post("filter", "xml=1&"+parametros);
        }

        #region ALIAS PARA CONSUMO DE SERVICE
        /*
        public static int GetIdPanel()
        {
            string id_panel = ReadTag("id_panel", inspResult.Elements("panel"));
            return Convert.ToInt32(id_panel);
        }

        public static string GetProduccionOp()
        {
            return ReadTag("op", prodResult.Elements("machine"));
        }

        public static string GetPuestoId()
        {
            return ReadTag("puesto_id", prodResult.Elements("machine"));
        }

        public static string GetLineId()
        {
            return ReadTag("line_id", prodResult.Elements("machine"));
        }
        */
        #endregion
    }
}
