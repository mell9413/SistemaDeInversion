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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            //posibleInterface t = new posibleInterface();
            //t.lol();
            /*Mambiux

            ServicioAhorroInversion x;
            x = new DepositoVistaPactada(new Fisico("Marvin", "fernandez", "Coto"), new Dolar(), 10000, 30);
             t.lol();
             */

           /* BitacoraXML xml = new BitacoraXML();
            xml.crearArchivo();
            
            BitacoraCSV csv = new BitacoraCSV();
            csv.crearArchivo();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validarTextBoxLetras(textBoxNombre);
            validarTextBoxLetras(textBoxApellido1);
            validarTextBoxLetras(textBoxApellido2);
            Type clase = typeof(ServicioAhorroInversion);
            MessageBox.Show(Validacion.Validacion.GetEnumerableOfType(clase)[0].ToString()) ;

        }

        private void validarTextBoxLetras(TextBox box)
        {
            if (!Validacion.Validacion.validarLetras(box.Text))
            {
                MessageBox.Show("El dato ingresado '" + box.Text + "' es incorrecto, por favor asegurese que contenga solamente letras");
            }

        }
    }
}
