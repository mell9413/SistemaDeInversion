using System;
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
            /*Mambiux

            ServicioAhorroInversion x;
            x = new CuentaCorriente(new Fisico("Marvin", "fernandez", "Coto"), new Dolar(), 10000, 30);
             t.lol();
             */

            /* BitacoraXML xml = new BitacoraXML();
             xml.crearArchivo();
            
             BitacoraCSV csv = new BitacoraCSV();
             csv.crearArchivo();
             *  ServicioAhorroInversion x;
             x = new CuentaCorriente(new Fisico("Marvin", "fernandez", "Coto"), new Dolar(), 2500001, 30);
             x.getInteres();
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validacion.Validacion.validarLetras(textBoxNombre.Text))
            {
                MessageBox.Show("Bien");
            }
            else
            {
                MessageBox.Show("Mal");
            }
        }
    }
}
