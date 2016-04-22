using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
namespace SistemaDeInversion.Modelo
{
    class CertificadoInversion : ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public CertificadoInversion(Cliente cliente, String tipoMoneda, double montoInversion, int plazoDias)
            : base(cliente, tipoMoneda, montoInversion, plazoDias)
        {
            base.id = "Cer#" + cantidadInstancias;
            cantidadInstancias++;
        }

        private double getISR()
        {
            XElement xelement = XElement.Load(base.getDataPath() + "staticData.xml");
            var intAnual = (from rango in xelement.Elements("row")
                            select rango).First();
            //MessageBox.Show(intAnual.Element("ISR").Value);
            return Convert.ToDouble(intAnual.Element("ISR").Value);
        }

        public override void calcularInteres()
        {
            XElement xelement = XElement.Load(base.getDataPath() + "rangosInversionCertificado.xml");
            var intAnual = (from rango in xelement.Elements("row")
                            where (double)rango.Element("rangomax") >= base.plazoDias
                            select rango).First();

            //MessageBox.Show(intAnual.Element(base.moneda).Value);
            double interes = Convert.ToDouble((intAnual.Element(base.moneda).Value));
            base.interes = interes - (interes * 0.08);
        }
    }
}
