﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            XmlTextWriter archivoXML = new XmlTextWriter (this.asignarRuta()+nombreArchivo, System.Text.Encoding.UTF8);
            archivoXML.WriteStartDocument(true);
            archivoXML.Close();
        }

        public void escribirMovimiento()
        {
            
        }

        public string asignarRuta()
        {
            String ruta = Path.GetFullPath(@"temp").Replace(@"\", @"/");
            ruta = ruta.Remove(ruta.Length - 14) + "Data/";
            return ruta;
        }
    }
}
