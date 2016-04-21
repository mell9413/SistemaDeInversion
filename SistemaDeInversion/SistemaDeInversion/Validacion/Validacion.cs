using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using SistemaDeInversion.Modelo;
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

        public static bool validarVacio(string palabra)
        {
            if(palabra == "")
            {
                return false;
            }
            return true;
 
        }

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

        public static string getDataPath()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }

        public static List<String[]> getServicios()
        {
            List<String[]> tiposS = new List<String[]>();
            XElement xelement = XElement.Load(getDataPath() + "tiposServicios.xml");
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

    }
}
