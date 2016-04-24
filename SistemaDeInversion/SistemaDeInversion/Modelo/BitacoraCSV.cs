using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.DataBase;

namespace SistemaDeInversion.Modelo
{
    class BitacoraCSV: IEscritor
    {
        private static String nombreArchivo = "bitacoraCSV.csv";

        public static string NombreArchivo
        {
            get
            {
                return nombreArchivo;
            }

        }

        public void crearArchivo()
        {
            File.Create(LectorData.obtenerRutaCarpeta()+ nombreArchivo).Close();
        }

        public void escribirMovimiento(DTOServicioAhorroInversion dtoInversion)
        {
            if (existeArchivo())
            {
                string delimiter = ",";
                string[][] output = new string[][]{
                    new string[]{ dtoInversion.Cliente.Nombre+" "+ dtoInversion.Cliente.PrimerApellido+" "+ dtoInversion.Cliente.SegundoApellido,
                        dtoInversion.MontoInversion.ToString(), dtoInversion.PlazoDias.ToString(), dtoInversion.TipoServicio, dtoInversion.Moneda }
                    };
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Join(delimiter, output[0]));
                using (StreamWriter outputFile = new StreamWriter(LectorData.obtenerRutaCarpeta() + nombreArchivo, true))
                {
                    outputFile.WriteLine(sb.ToString().Remove(sb.Length - 2));
                }
            }
            else
            {
                crearArchivo();
                escribirMovimiento(dtoInversion);
            }
        }
        public Boolean existeArchivo()
        {
            if (File.Exists(LectorData.obtenerRutaCarpeta() + nombreArchivo)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
