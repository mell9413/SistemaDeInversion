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
using SistemaDeInversion.Validacion;


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
            establecerMonedas();
            establecerServicios();
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

        private void registrarCliente()
        {

        }

        private void validarTextBoxLetras(TextBox box)
        {
            if (!Validacion.Validacion.validarLetras(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
            }
        }

        private void validarTextBoxVacios(TextBox box)
        {
            if (!Validacion.Validacion.validarVacio(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
            }
        }

        private void validarTextBoxNumero(TextBox box)
        {
            if (!Validacion.Validacion.validarDouble(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
            }
        }

        private void establecerMonedas()
        {
            comboBoxMoneda.DataSource = Validacion.Validacion.getMonedas();
        }

        private void establecerServicios()
        {
            comboBoxInversion.DataSource = Validacion.Validacion.getServicios();
        }

        private void textBoxNombre_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxNombre.ForeColor = Color.Black;
        }

        private void textBoxApellido1_Click(object sender, EventArgs e)
        {
            textBoxApellido1.Text = "";
            textBoxApellido1.ForeColor = Color.Black;
        }

        private void textBoxApellido2_Click(object sender, EventArgs e)
        {
            textBoxApellido2.Text = "";
            textBoxApellido2.ForeColor = Color.Black;
        }

        private void textBoxMonto_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text = "";
            textBoxMonto.ForeColor = Color.Black;
        }
    }
}
