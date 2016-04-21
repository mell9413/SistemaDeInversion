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
using System.Reflection;


namespace SistemaDeInversion.Vistas
{
    public partial class VistaGUI : Form
    {
        public VistaGUI()
        {
            Shiri X = new Shiri();
            X.getServicios();
            InitializeComponent();
        }

        private void VistaGUI_Load(object sender, EventArgs e)
        {
            /*Mambiux
            Shiri X;
            X = new Shiri();
            X.getMonedas();
             * 
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
            validarTextBoxLetras(textBoxNombre);
            validarTextBoxLetras(textBoxApellido1);
            validarTextBoxLetras(textBoxApellido2);
            validarTextBoxVacios(textBoxNombre);
            validarTextBoxVacios(textBoxApellido1);
            validarTextBoxVacios(textBoxApellido2);
            validarTextBoxNumero(textBoxMonto);

        }

        private void validarTextBoxLetras(TextBox box)
        {
            if (!Validacion.Validacion.validarLetras(box.Text))
            {
                MessageBox.Show("El dato ingresado '" + box.Text + "' es incorrecto, por favor asegurese que contenga solamente letras");
            }

        }

        private void validarTextBoxVacios(TextBox box)
        {
            if (!Validacion.Validacion.validarVacio(box.Text))
            {
                MessageBox.Show("Por favor ingrese un dato");
            }
        }

        private void validarTextBoxNumero(TextBox box)
        {
            if (!Validacion.Validacion.validarNumeros(box.Text))
            {
                MessageBox.Show("El monto ingresado es incorrecto, por favor ingrese números solamente");
            }
        }
    }
}
