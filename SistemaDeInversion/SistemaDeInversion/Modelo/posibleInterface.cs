using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.IO;

namespace SistemaDeInversion.Modelo
{
    class posibleInterface
    {
        

        public ArrayList lol(){
          ArrayList array = new ArrayList();
            String x = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            MessageBox.Show(x);
            string path1 = x + "books.xml.xml";
            MessageBox.Show(path1);
            XmlTextReader reader = new XmlTextReader(path1);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text: //Display the text in each element.
                        MessageBox.Show(reader.Value);
                        array.Add(reader.Value);
                        break;
                }
            }
            array.IndexOf()
            return array;
        }
           
        }


      
    }
}
