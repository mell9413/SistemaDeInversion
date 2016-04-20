using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
namespace SistemaDeInversion.Modelo
{
    public class DepositoVistaPactada: ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public DepositoVistaPactada (Cliente cliente, Moneda moneda, double montoInversion, int plazoDias): base (cliente,moneda,montoInversion,plazoDias)
        {
            base.id = "DpVis#" + cantidadInstancias;
            cantidadInstancias++;
        }
        public override double calcularRendimiento()
        {
            return 2;
        }
        public override double getInteres()
        {
            XElement xelement = XElement.Load(base.getDataPath());
            var homePhone = from phoneno in xelement.Elements("row")
                            where (double)phoneno.Element("rangomax") >= base.montoInversion
                            select phoneno;
            Console.WriteLine("List HomePhone Nos.");
            foreach (XElement xEle in homePhone)
            {
                MessageBox.Show(xEle.Element("interesAnual").Value);
            }

            return 2;
        }
    }
}
