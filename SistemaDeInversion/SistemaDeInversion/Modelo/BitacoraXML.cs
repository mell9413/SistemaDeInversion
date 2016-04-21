using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SistemaDeInversion.DTOs;
using System.Xml.Linq;

namespace SistemaDeInversion.Modelo
{
    class BitacoraXML: IEscritor
    {
        private static int cantidadInstancias = 0;
        private static string nombreArchivo = "bitacoraXML.xml";

        public BitacoraXML()
        {
            
        }

        public static int CantidadInstancias
        {
            get
            {
                return cantidadInstancias;
            }

            set
            {
                cantidadInstancias = value;
            }
        }

        public static string NombreArchivo
        {
            get
            {
                return nombreArchivo;
            }

            set
            {
                nombreArchivo = value;
            }
        }

        public void crearArchivo()
        {
            XmlTextWriter archivoXML = new XmlTextWriter(this.asignarRuta() + nombreArchivo, System.Text.Encoding.UTF8);
            archivoXML.WriteStartDocument();
            archivoXML.WriteStartElement("Registo");
            archivoXML.WriteEndElement();
            archivoXML.Flush();
            archivoXML.Close();
        }

        public string asignarRuta()
        {
            String ruta = Path.GetFullPath(@"temp").Replace(@"\", @"/");
            ruta = ruta.Remove(ruta.Length - 14) + "Data/";
            return ruta;
        }

        public string escribirMovimiento(DTOs.DTOServicioAhorroInversion dtomovimiento)
        {
            string filepath =this.asignarRuta() + nombreArchivo;
            XmlDocument documento = new XmlDocument();
            documento.Load(filepath);
            XElement xml = XElement.Load(filepath);
            xml.Add(new XElement("Movimiento",
                    new XAttribute("Cliente", dtomovimiento.Cliente.ToString()),
                    new XElement("TipoServicio", dtomovimiento.TipoServicio.ToString()),
                    new XElement("Inversion", dtomovimiento.MontoInversion.ToString()),
                    new XElement("PlazoDias", dtomovimiento.PlazoDias.ToString()),
                    new XElement("Moneda", dtomovimiento.Moneda.Nombre)));
            xml.Save(filepath);
            return "";
        }
    }
}
