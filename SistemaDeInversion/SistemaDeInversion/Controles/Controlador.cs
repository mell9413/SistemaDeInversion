using SistemaDeInversion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SistemaDeInversion.Controles
{
    class Controlador: IControlador
    {
        ArrayList escritor= new ArrayList();
        //FactoryServicio factoryServicio;
        //FactoryCliente factoryCliente;

        public Controlador()
        {
            IEscritor csv = new BitacoraCSV();
            IEscritor xml = new BitacoraXML();
            this.escritor.Add(csv);
            this.escritor.Add(xml);
        }

       public void crearBitacora()
        {

            BitacoraXML xml = new BitacoraXML();
            xml.crearArchivo();

            BitacoraCSV csv = new BitacoraCSV();
            csv.crearArchivo();
        }
    }
}
