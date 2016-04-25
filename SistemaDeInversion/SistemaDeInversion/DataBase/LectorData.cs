using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SistemaDeInversion.DataBase
{
    public static class LectorData
    {
        //Devuelve lista de monedas aceptadas por un tipo de inversion
        public static String[] obtenerMonedasXinstancia(String nombreInstancia)
        {
            List<String[]> tiposM = new List<String[]>();
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "tiposMoneda.xml");
            var monedas =from rango in xelement.Elements("row")
                            select rango ;
            foreach (var moneda in monedas){
                if (Convert.ToString(moneda.Element(nombreInstancia))!="")
                {
                    tiposM.Add(Convert.ToString(moneda.Element(nombreInstancia).Value).Split(','));
                }
            }
            return tiposM[0];
        }

        // Devuelve los diferentes tipos de servicios de ahorro e inversion
        public static List<String[]> obtenerServicios()
        {
            List<String[]> tiposS = new List<String[]>();
            XElement xelement = XElement.Load(obtenerRutaCarpeta() + "tiposServicios.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            foreach (var servicio in servicios)
            {
                String[] temp = new String[2];

                temp[0] = (servicio.Element("Nombre").Value.ToString());
                temp[1] = (servicio.Element("Clase").Value.ToString());
                tiposS.Add(temp);
            }

            return tiposS;
        }
       
        // obtiene la ruta donde se encuentran las monedas
        public static string obtenerRutaCarpeta()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }

        public static int obtenerMinDias(String tipoServicio)
        {
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "minimoDias.xml");
            var servicio = (from rango in xelement.Elements("row")
                            where (String)rango.Element("inversion") == tipoServicio
                            select rango).First();
            MessageBox.Show(Convert.ToString(servicio.Element("minDias").Value) + "foRr?");
            return Convert.ToInt32(servicio.Element("minDias").Value);
        }

        public static double obtenerImpuestoRenta()
        {
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "staticData.xml");
            var isr = (from rango in xelement.Elements("row")
                            select rango).First();
           
            return Convert.ToDouble(isr.Element("ISR").Value);
        }
}

}
