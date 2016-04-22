using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
namespace SistemaDeInversion.Modelo
{
    public class InversionVistaPactada: ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public InversionVistaPactada(Cliente cliente, String tipoMoneda, double montoInversion, int plazoDias)
            : base(cliente, tipoMoneda, montoInversion, plazoDias)
        {
            base.id = "DpVis#" + cantidadInstancias;
            cantidadInstancias++;
        }

        public override void calcularInteres()
        {
            XElement xelement = XElement.Load(base.getDataPath() + "rangosInversionVistaPactada.xml");
            var intAnual = (from rango in xelement.Elements("row")
                            where (double)rango.Element("rangomax") >= base.plazoDias  
                            select rango).First();
            //MessageBox.Show(base.moneda);
           // MessageBox.Show(intAnual.Element(base.moneda).Value);
            base.interes = Convert.ToDouble((intAnual.Element(base.moneda).Value));
        }
        


    }
}
