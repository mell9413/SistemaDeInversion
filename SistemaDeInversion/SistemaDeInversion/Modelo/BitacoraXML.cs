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
using SistemaDeInversion.DataBase;

namespace SistemaDeInversion.Modelo
{
    public class BitacoraXML: IEscritor
    {
        private static string nombreArchivo = "bitacoraXML.xml";

        public static string NombreArchivo
        {
            get
            {
                return nombreArchivo;
            }
        }

        public void crearArchivo()
        {
            XmlTextWriter archivoXML = new XmlTextWriter(LectorData.obtenerRutaCarpeta() + nombreArchivo, System.Text.Encoding.UTF8);
            archivoXML.WriteStartDocument();
            archivoXML.WriteStartElement("Registo");
            archivoXML.WriteEndElement();
            archivoXML.Flush();
            archivoXML.Close();
        }

        public void escribirMovimiento(DTOServicioAhorroInversion dtoInversion)
        {
            if (existeArchivo())
            {
                string filepath = LectorData.obtenerRutaCarpeta() + nombreArchivo;
                XmlDocument documento = new XmlDocument();
                documento.Load(filepath);
                XElement xml = XElement.Load(filepath);
                xml.Add(new XElement("Movimiento",
                        new XAttribute("Cliente", dtoInversion.Cliente.Nombre + " " + dtoInversion.Cliente.PrimerApellido + " " + dtoInversion.Cliente.SegundoApellido),
                        new XElement("TipoServicio", dtoInversion.TipoServicio),
                        new XElement("Inversion", dtoInversion.MontoInversion.ToString()),
                        new XElement("PlazoDias", dtoInversion.PlazoDias.ToString()),
                        new XElement("Moneda", dtoInversion.Moneda)));
                xml.Save(filepath);
            }
            else
            {
                crearArchivo();
                escribirMovimiento(dtoInversion);
            }
            
        }

        public Boolean existeArchivo() {
            if (File.Exists(LectorData.obtenerRutaCarpeta() + nombreArchivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
