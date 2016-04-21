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
        public List<String[]> getMonedas()
        {
            List< String[]> tiposM= new List< String[]>();
            XElement xelement = XElement.Load(this.getDataPath());
            IEnumerable<XElement> monedas = xelement.Elements();
            foreach (var moneda in monedas)
            {

               String[] temp = new String[2];
             
                   temp[0]=(moneda.Element("Nombre").Value.ToString());
                   temp[1]=(moneda.Element("Símbolo").Value.ToString());
                   tiposM.Add(temp);
                   MessageBox.Show(moneda.Element("Nombre").Value.ToString());
                    
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
