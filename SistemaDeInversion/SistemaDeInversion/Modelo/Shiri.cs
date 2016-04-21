using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using SistemaDeInversion.Modelo;
namespace SistemaDeInversion.Modelo
{
    class Shiri
    {
        public  ArrayList getMonedas()
        {
            ArrayList tiposM= new ArrayList();
            XElement xelement = XElement.Load(this.getDataPath());
            IEnumerable<XElement> monedas = xelement.Elements();
            // Read the entire XML
            foreach (var moneda in monedas)
            {
                String[] temp= new String [moneda.Elements().Count()];
                for (int i = 0; i != moneda.Elements().Count(); i++) {
                   // temp[i] = (String)moneda.Element(moneda.Value);
                  //  MessageBox.Show((String)moneda.Element(moneda.Value.ToString()));
                }
                    MessageBox.Show(moneda.Element("Nombre").Value.ToString());
                tiposM.Add(moneda.Element("Nombre").Value);
            }
            return tiposM;
        }
         public string getDataPath()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\tiposMoneda.xml");
            return ruta;
        }
        
    }
}
