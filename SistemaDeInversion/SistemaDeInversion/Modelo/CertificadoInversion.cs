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
    class CertificadoInversion : ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public CertificadoInversion(DTOServicioAhorroInversion dtoInversion): base(dtoInversion)
        {
            
            base.id = "Cer#" + cantidadInstancias;
            cantidadInstancias++;
        }

        private double obtenerImpuestoRenta()
        {
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "staticData.xml");
            var intAnual = (from rango in xelement.Elements("row")
                            select rango).First();
            //MessageBox.Show(intAnual.Element("ISR").Value);
            return Convert.ToDouble(intAnual.Element("ISR").Value);
        }

        public override void calcularInteres()
        {
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "rangosInversionCertificado.xml");
            var intAnual = (from rango in xelement.Elements("row")
                            where (double)rango.Element("rangomax") >= base.plazoDias
                            select rango).First();

            //MessageBox.Show(intAnual.Element(base.moneda).Value);
            double interes = Convert.ToDouble((intAnual.Element(base.moneda).Value));
            base.interes = interes - (interes * 0.08);
        }

        public  override double obtenerSaldoMinimo()
        {
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta()+this.GetType());
            var saldos = (from rango in xelement.Elements("row")
                          where (double)rango.Element("rangomax") >=base.plazoDias
                          select rango).First();
            return Convert.ToDouble(saldos.Element("rangomax").Attribute("Colón").Value);
        }

    }
}
