using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    class BitacoraCSV: IEscritor
    {
        private static int cantidadInstancias = 0;
        private static String nombreArchivo = "bitacoraCSV.csv";

        public BitacoraCSV()
        {

        }
        public static int CantidadInstancias
        {
            get
            {
                return cantidadInstancias;
            }

            set
            {
                cantidadInstancias = value;
            }
        }

        public static string NombreArchivo
        {
            get
            {
                return nombreArchivo;
            }

            set
            {
                nombreArchivo = value;
            }
        }

        

        public void crearArchivo()
        {
            File.Create(this.asignarRuta()+nombreArchivo).Close();
        }

        public void escribirMovimiento()
        {
            //throw new NotImplementedException();
        }

        public string asignarRuta()
        {
            String ruta = Path.GetFullPath(@"temp").Replace(@"\", @"/");
            ruta = ruta.Remove(ruta.Length - 14) + "Data/";
            return ruta;
        }
        public string getDataPath() {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }
    }
}
