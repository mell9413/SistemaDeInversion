using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace SistemaDeInversion.Modelo
{
    class posibleInterface
    {
        

        public ArrayList lol(){
            ArrayList array= new ArrayList();
            string path1 = "C:\\Users\\xXMAMBOXx\\Desktop\\books.xml.xml";
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
            return array;
           
        }


      
    }
}
