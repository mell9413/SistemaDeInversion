﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaDeInversion.Modelo.Factorys;
using SistemaDeInversion.Validaciones;
using SistemaDeInversion.Modelo;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.Vistas;

namespace SistemaDeInversion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*
            Modelo.BitacoraXML xml = new Modelo.BitacoraXML();
            xml.crearArchivo();

            Modelo.BitacoraCSV csv = new Modelo.BitacoraCSV();
            csv.crearArchivo();
            */
            Application.Run(new Vistas.VistaGUI());
            VistaConsola consola = new VistaConsola();
            consola.run();

        }
    }
}
