using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Xml;

namespace ControlDeReparacion
{
    class ServiceCore
    {
        public static string url = "";

        /// <summary>
        /// Realiza el pedido del service, retorna string XML 
        /// </summary>
        /// <param name="service"></param>
        /// <returns>XML</returns>
        public static IEnumerable<XElement> get(string route)
        {
            XDocument xml = Util.LoadXMLFromUrl(url + route + "?xml");
            return xml.Descendants("service");
        }

        public static XDocument post(string route, string parametros)
        {
            XDocument xml = Util.LoadXMLFromUrl(url + route, "POST", parametros);

            return xml;

        }

        /// <summary>
        /// Lee un tag especifico del archivo XML
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static string ReadTag(string tag, IEnumerable<XElement> root)
        {
            string value = null;
            IEnumerable<XElement> elements = root.Elements(tag);
            if (elements.Count() > 0)
            {
                value = elements.First().Value;
            }
            return value;
        }

        public static DataTable XElementToDataTable(XDocument x)
        {
            DataTable dtable = new DataTable();


            IEnumerable<XElement> reparacion = x.Descendants("service").First().Descendants("reparacion");

            if (reparacion.Descendants().Count() > 0)
            {
                IEnumerable<XElement> reparaciones = reparacion.Descendants().First().Descendants();

                // build your DataTable
                foreach (XElement xe in reparaciones)
                {
                    dtable.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string))); // add columns to your dt
                }

                IEnumerable<XNode> nodeIt = reparacion.Descendants().Where(p => p.Name.LocalName.Contains("item_"));
                foreach (XNode node in nodeIt)
                {
                    if (node is XElement)
                    {
                        XElement element = (XElement)node;
                        DataRow dr = dtable.NewRow();
                        foreach (XElement xe2 in element.Descendants())
                        {
                            dr[xe2.Name.ToString()] = xe2.Value; //add in the values
                        }
                        dtable.Rows.Add(dr);
                    }
                }
            }

            
            
            return dtable;
        }

    }
}
