using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
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

        public override void calcularInteres()
        {

            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "CertificadoInversion.xml");

            var intAnual = (from rango in xelement.Elements("row")
                            where (double)rango.Element("rangomax") >= base.plazoDias
                            select rango).First();

            base.interes = Convert.ToDouble((intAnual.Element(base.moneda).Value));

        }

        public  override double obtenerSaldoMinimo()
        {

            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "CertificadoInversion.xml");

            var saldos = (from rango in xelement.Elements("row")
                          where (double)rango.Element("rangomax") >=base.plazoDias
                          select rango).First();

            return Convert.ToDouble(saldos.Element("rangomax").Attribute("Colones").Value);
        }

        public override void calcularSaldoFinal()
        {
            this.saldoFinal = this.montoInversion +(this.interesGanado- this.calcularImpuestoRenta());
        }

        public double calcularImpuestoRenta()
        {
            return (this.interesGanado * LectorData.obtenerImpuestoRenta());
        }
       

    }
}
