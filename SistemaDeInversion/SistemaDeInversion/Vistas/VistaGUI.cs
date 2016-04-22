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
            /*Mambiux Inversión Pactada y validacion de saldo
             * ServicioAhorroInversiox;
                x = new InversionVistaPactada(new Fisico("Marvin", "fernandez", "Coto"), "Colón", 1200000, 56);
                MessageBox.Show(Validacion.Validacion.getSaldoMinIVP("Dólar").ToString());
                MessageBox.Show((x.calcularRendimiento()).ToString());
             * 
            Mambiux Cuenta corriente 
             *  ServicioAhorroInversion x;
                x = new CuentaCorriente(new Fisico("Marvin", "fernandez", "Coto"), new Dolar(), 10000, 30);
             
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
            if (!Validacion.Validacion.validarDouble(box.Text))
            {
                MessageBox.Show("El monto ingresado es incorrecto, por favor ingrese números solamente");
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


    }
}
