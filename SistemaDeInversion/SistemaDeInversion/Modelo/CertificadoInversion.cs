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

        public CertificadoInversion(Cliente cliente, double montoInversion, int plazoDias)
            : base(cliente, montoInversion, plazoDias)
        {
            base.id = "Cer#" + cantidadInstancias;
            cantidadInstancias++;
        }

        public override void calcularInteres()
        {
            XElement xelement = XElement.Load(base.getDataPath());
            var homePhone = (from phoneno in xelement.Elements("row")
                             where (double)phoneno.Element("rangomax") >= base.montoInversion
                             select phoneno).First();

            // foreach (XElement xEle in homePhone)
            //{
            //  MessageBox.Show(xEle.Element("interesAnual").Value);
            //}
            MessageBox.Show(homePhone.Element("interesAnual").Value);
            base.interes = Convert.ToDouble(homePhone.Element("interesAnual").Value);
        }
    }
}
