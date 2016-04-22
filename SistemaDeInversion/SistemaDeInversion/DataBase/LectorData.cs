using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaDeInversion.DataBase
{
    public static class LectorData
    {
        //returna las monedas registradas en el sistema
        public static ArrayList obtenerMonedas()
        {
            List<String[]> tiposM = new List<String[]>();
            XElement xelement = XElement.Load(obtenerRutaCarpeta() + "tiposMoneda.xml");
            IEnumerable<XElement> monedas = xelement.Elements();
            foreach (var moneda in monedas)
            {

                String[] temp = new String[2];

                temp[0] = (moneda.Element("Nombre").Value.ToString());
                temp[1] = (moneda.Element("Símbolo").Value.ToString());
                tiposM.Add(temp);

            }
            return obtenerNombreMonedas(tiposM);

        }

        private static ArrayList obtenerNombreMonedas(List<String[]> lista)
        {
            ArrayList resultado = new ArrayList();
            foreach (String[] elemento in lista)
            {
                resultado.Add(elemento[0]);

            }
            return resultado;

        }

        // Devuelve los diferentes tipos de servicios de ahorro e inversion
        public static ArrayList obtenerServicios()
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

            return obtenerNombreMonedas(tiposS);
        }

        public static double obtenerSaldoMinCuentaCorriente()
        {
            double saldoMin;
            XElement xelement = XElement.Load(obtenerRutaCarpeta() + "rangosCuentaCorriente.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            saldoMin = Convert.ToDouble(servicios.ToArray()[0].Element("rangomin").Value);
            //MessageBox.Show(saldoMin.ToString());
            return saldoMin;
        }
        // obtiene la ruta donde se encuentran las monedas
        public static string obtenerRutaCarpeta()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }

        //Saldo minimo inversión Vista pactada
        public static double obtenerMinInversionVista(String tipoMoneda)
        {
            double saldoMin;
            XElement xelement = XElement.Load(obtenerRutaCarpeta() + "rangosInversionVistaPactada.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            saldoMin = Convert.ToDouble(servicios.ToArray()[0].Element(tipoMoneda).Value);
            return saldoMin;
        }
        public static double obtenerSaldoMinCertificado(int Dias)
        {
            XElement xelement = XElement.Load(obtenerRutaCarpeta() + "rangosInversionCertificado.xml");
            var saldos = (from rango in xelement.Elements("row")
                          where (double)rango.Element("rangomax") >= Dias
                          select rango).First();
            return Convert.ToDouble(saldos.Element("rangomax").Attribute("Colón").Value);
        }
        public static int obtenerMinDiasInversionVista()
        {
            int minDias;
            XElement xelement = XElement.Load(obtenerRutaCarpeta() + "rangosInversionVistaPactada.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            minDias = Convert.ToInt32(servicios.ToArray()[1].Element("rangomin").Value);
            return minDias;
        }
}

}
