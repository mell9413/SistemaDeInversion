﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaDeInversion.Modelo;

namespace SistemaDeInversion.Vistas
{
    public partial class VistaGUI : Form
    {
        public VistaGUI()
        {
           
            
            InitializeComponent();
        }

        private void VistaGUI_Load(object sender, EventArgs e)
        {
            posibleInterface t = new posibleInterface();
            t.lol();
            /*Mambiux

            ServicioAhorroInversion x;
            x = new DepositoVistaPactada(new Fisico("Marvin", "fernandez", "Coto"), new Dolar(), 10000, 30);
             t.lol();
             */
            
            



           

            BitacoraXML xml = new BitacoraXML();
            xml.crearArchivo();
            
            BitacoraCSV csv = new BitacoraCSV();
            csv.crearArchivo();
        }
    }
}
