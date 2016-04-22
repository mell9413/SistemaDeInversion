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

        public void escribirMovimiento(DTOServicioAhorroInversion dtoMovimiento)
        {
            //if existe archivo y sino crearlo
         //   string delimiter = ",";  	 
         //   string[][] output = new string[][]{  
	        //        new string[]{ dtoMovimiento.getCliente().ToString(), dtoMovimiento.getTipoServicio(), dtoMovimiento.getMontoInversion().ToString(), dtoMovimiento.getPlazoDias().ToString(), dtoMovimiento.getMoneda()}
	        //};  
	        //StringBuilder sb = new StringBuilder();
         //   sb.AppendLine(string.Join(delimiter, output[0]));
         //   using (StreamWriter outputFile = new StreamWriter(LectorData.obtenerRutaCarpeta()+nombreArchivo, true))
         //   {
         //       outputFile.WriteLine(sb.ToString().Remove(sb.Length-2));
         //   }
        }
        public Boolean existeArchivo()
        {
            return true;
        }
    }
}
