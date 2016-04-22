using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace SistemaDeInversion.Modelo
{
    class CuentaCorriente : ServicioAhorroInversion, ILector
    {
        
        private static int cantidadInstancias = 0;

        public CuentaCorriente(Cliente cliente,String tipoMoneda,double montoInversion, int plazoDias)
            : base(cliente,tipoMoneda,montoInversion, plazoDias)
        {
            base.id = "CntCo#" + cantidadInstancias;
            cantidadInstancias++;
        }

        public override void calcularInteres()
        {
            XElement xelement = XElement.Load(base.getDataPath() + "rangosCuentaCorriente.xml");
             var intAnual = (from rango in xelement.Elements("row")
                             where (double)rango.Element("rangomax")>=base.montoInversion
                             select rango).First();
            
            // foreach (XElement xEle in homePhone)
             //{
               //  MessageBox.Show(xEle.Element("interesAnual").Value);
             //}
             MessageBox.Show(intAnual.Element("interesAnual").Value);
             base.interes= Convert.ToDouble(intAnual.Element("interesAnual").Value);
        }
        

       
    }
}
