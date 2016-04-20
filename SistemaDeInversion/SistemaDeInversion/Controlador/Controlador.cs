using SistemaDeInversion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Controlador
{
    class Controlador: IControlador
    {
       public void crearBitacora()
        {
            BitacoraXML xml = new BitacoraXML();
            xml.crearArchivo();

            BitacoraCSV csv = new BitacoraCSV();
            csv.crearArchivo();
        }
    }
}
