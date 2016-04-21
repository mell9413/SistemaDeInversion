using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaDeInversion.Validacion
{
    public static class  Validacion
    {
        // Valida si un string contiene solo letras
        public static bool validarLetras(string palabra)
        {
            foreach(char caracter in palabra)
            {
                if (!char.IsLetter(caracter))
                {
                    return false;
                }
            }
            return true;
        }

        // valida si un string viene vacio
        public static bool validarVacio(string palabra)
        {
            if(palabra == "")
            {
                return false;
            }
            return true;
 
        }

        // valida si un string contiene numeros
        public static bool validarNumeros(string numero)
        {
            foreach(char caracter in numero)
            {
                if (!char.IsDigit(caracter))
                {
                    return false;
                }
            }
            return true;
        }

        //valida si un string es tipo double
        public static bool validarDouble(string numero)
        {
            double resultado;
            if(!Double.TryParse(numero, out resultado))
            {
                return false;
            }
            return true;
        }


        // Metodo inutil, codigo muerto posiblemente
        public static ArrayList GetEnumerableOfType(Type constructorArgs) 
        {
            ArrayList objects = new ArrayList();
            foreach (Type type in
                Assembly.GetAssembly(typeof(Modelo.ServicioAhorroInversion)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Modelo.ServicioAhorroInversion))))
            {
                objects.Add(type);
            }

            return objects;
        }
        
        //returna las monedas registradas en el sistema
        public static List<String[]> getMonedas()
        {
            List<String[]> tiposM = new List<String[]>();
            XElement xelement = XElement.Load(Validacion.getDataPath() + "tiposMoneda.xml");
            IEnumerable<XElement> monedas = xelement.Elements();
            foreach (var moneda in monedas)
            {

                String[] temp = new String[2];

                temp[0] = (moneda.Element("Nombre").Value.ToString());
                temp[1] = (moneda.Element("Símbolo").Value.ToString());
                tiposM.Add(temp);

            }
            return tiposM;
        }
        //retorna la mierda
        public static List<String[]> getServicios()
        {
            List<String[]> tiposS = new List<String[]>();
            XElement xelement = XElement.Load(getDataPath()+"tiposServicios.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            foreach (var servicio in servicios)
            {

                String[] temp = new String[2];

                temp[0] = (servicio.Element("Nombre").Value.ToString());
                temp[1] = (servicio.Element("Clase").Value.ToString());
                tiposS.Add(temp);
               // MessageBox.Show(servicio.Element("Nombre").Value.ToString());
                //MessageBox.Show(servicio.Element("Clase").Value.ToString());

            }

            return tiposS;
        }

        // obtiene la ruta donde se encuentran las monedas
        private static string getDataPath()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }


    }
}
