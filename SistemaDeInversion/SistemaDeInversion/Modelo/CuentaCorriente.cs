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
        posibleInterface x = new posibleInterface();
        private static int cantidadInstancias = 0;

        public CuentaCorriente(Cliente cliente, Moneda moneda, double montoInversion, int plazoDias)
            : base(cliente, moneda, montoInversion, plazoDias)
        {
            base.id = "CntCo#" + cantidadInstancias;
            cantidadInstancias++;
            x = new posibleInterface();
        }


        private ArrayList getTablaInteres()
        {
            ArrayList listaRangos=new ArrayList();            
            String dataPath = base.getDataPath();
            XmlTextReader reader = new XmlTextReader(dataPath);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                        case XmlNodeType.Text: //Display the text in each element.
                             MessageBox.Show(reader.Value);
                             listaRangos.Add(reader.Value);
                             break;
                }
            }
            return listaRangos;
        }
        public override double getInteres()
        {
           /* ArrayList listaRangos = getTablaInteres();
            for (int i = 0; listaRangos.Count != i; i++)
            {
                if (base.montoInversion <= listaRangos.IndexOf(i))
                {
                    base.interes=
                }
            }*/

            XElement xelement = XElement.Load(base.getDataPath());
            var homePhone = from phoneno in xelement.Elements("row")
                            where (string)phoneno.Element("rangomax")>=base.plazoDias;
                            select phoneno;
            Console.WriteLine("List HomePhone Nos.");
            foreach (XElement xEle in homePhone)
            {
                Console.WriteLine(xEle.Element("Phone").Value);
            }

        }

        public override double calcularRendimiento()
        {
            ArrayList tabla = this.x.lol();
            MessageBox.Show(tabla[1].ToString());


            return 2;
        }



       
    }
}
