using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DTOs;

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

        

        public string asignarRuta()
        {
            String ruta = Path.GetFullPath(@"temp").Replace(@"\", @"/");
            ruta = ruta.Remove(ruta.Length - 14) + "Data/";
            return ruta;
        }

        public String escribirMovimiento(DTOs.DTOServicioAhorroInversion dtomovimiento)
        {
            string delimiter = ",";  	 
            string[][] output = new string[][]{  
	                new string[]{dtomovimiento.Cliente.ToString(), dtomovimiento.TipoServicio, dtomovimiento.MontoInversion.ToString(),dtomovimiento.PlazoDias.ToString(), dtomovimiento.Moneda.Nombre}
	        };  
	        StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, output[0]));
            using (StreamWriter outputFile = new StreamWriter(this.getDataPath()+nombreArchivo, true))
            {
                outputFile.WriteLine(sb.ToString().Remove(sb.Length-2));
            }
            return "Se ha realizado correctamente el movimiento";
        }

        public string getDataPath()
        {
            String ruta = Path.GetFullPath(@"temp").Replace(@"\", @"/");
            ruta = ruta.Remove(ruta.Length - 14) + "Data/";
            return ruta;
        }
    }
}
