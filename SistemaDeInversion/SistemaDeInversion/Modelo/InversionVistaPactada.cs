using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.DataBase;

namespace SistemaDeInversion.Modelo
{
    public class InversionVistaPactada: ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public InversionVistaPactada(DTOServicioAhorroInversion dtoInversion) : base(dtoInversion)
        {
            base.id = "DpVis#" + cantidadInstancias;
            cantidadInstancias++;
        }

        public override void calcularInteres()
        {
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "InversionVistaPactada.xml");
            var intAnual = (from rango in xelement.Elements("row")
                            where (double)rango.Element("rangomax") >= base.plazoDias  
                            select rango).First();
            //MessageBox.Show(base.moneda);
           // MessageBox.Show(intAnual.Element(base.moneda).Value);
            base.interes = Convert.ToDouble((intAnual.Element(base.moneda).Value));
        }

        //Saldo minimo inversión Vista pactada
        public override double obtenerSaldoMinimo()
        {
            double saldoMin;
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "InversionVistaPactada.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            saldoMin = Convert.ToDouble(servicios.ToArray()[0].Element(base.moneda).Value);
            return saldoMin;
        }
        public override void calcularSaldofinal()
        {
            this.saldoFinal = this.montoInversion + this.interesGanado;
        }


    }
}
