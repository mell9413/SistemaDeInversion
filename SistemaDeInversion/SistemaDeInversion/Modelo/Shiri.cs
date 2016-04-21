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
            XElement xelement = XElement.Load(this.getDataPathTiposServicio());
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
         public string getDataPathTiposServicio()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\tiposServicios.xml");
            return ruta;
        }
         public List<String[]> getServicios()
         {
             List<String[]> tiposS = new List<String[]>();
             XElement xelement = XElement.Load(this.getDataPathTiposServicio());
             IEnumerable<XElement> servicios = xelement.Elements();
             foreach (var servicio in servicios)
             {

                 String[] temp = new String[2];

                 temp[0] = (servicio.Element("Nombre").Value.ToString());
                 temp[1] = (servicio.Element("Clase").Value.ToString());
                 tiposS.Add(temp);
                 MessageBox.Show(servicio.Element("Nombre").Value.ToString());
                 MessageBox.Show(servicio.Element("Clase").Value.ToString());

             }
  
             return tiposS;
         }
        
    }
}
