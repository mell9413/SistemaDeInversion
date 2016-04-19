using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    class BitacoraXML: IEscritor
    {
        private static int cantidadInstancias = 0;
        private static String nombreArchivo = "bitacoraXML";

        public BitacoraXML()
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
            //throw new NotImplementedException();
        }

        public void escribirMovimiento()
        {
            //throw new NotImplementedException();
        }
    }
}
