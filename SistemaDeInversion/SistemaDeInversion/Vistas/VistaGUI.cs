using System;
using System.Collections;
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
            ServicioAhorroInversion x;
            x = new CuentaCorriente(new Fisico("Marvin", "fernandez", "Coto"), "Colón", 1000000, 31);
           MessageBox.Show( x.calcularRendimiento().ToString());
            InitializeComponent();
            
      

        }

        private void VistaGUI_Load(object sender, EventArgs e)
        {
            comboBoxInversion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
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
            //if (validarTextBoxLetras(textBoxNombre) && validarTextBoxLetras(textBoxApellido1) && validarTextBoxLetras(textBoxApellido2) && validarTextBoxVacios(textBoxNombre) && validarTextBoxVacios(textBoxApellido1) && validarTextBoxVacios(textBoxApellido2) && validarTextBoxNumero(textBoxMonto) && validarTextBoxMontoMayor())
            //{
            //    MessageBox.Show("Transaccion realizada con éxito");
            //}


        }

        private bool validarTextBoxMontoMayor(TextBox box)
        {

            return true;
        }

        private bool validarTextBoxLetras(TextBox box)
        {
            if (!Validacion.Validacion.validarLetras(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private bool validarTextBoxVacios(TextBox box)
        {
            if (!Validacion.Validacion.validarVacio(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private bool validarTextBoxNumero(TextBox box)
        {
            if (!Validacion.Validacion.validarDouble(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private void establecerMonedas()
        {
            ArrayList lista = new ArrayList();
            lista.Add(Validacion.Validacion.getMonedas()[1].ToString());
            comboBoxMoneda.DataSource = lista;
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

        private void comboBoxInversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("noob");
            ArrayList lista = new ArrayList();
            if (comboBoxInversion.Text == "Cuenta Corriente" || comboBoxInversion.Text == "Certificado de Inversión")
            {
                lista.Add(Validacion.Validacion.getMonedas()[1].ToString());
                comboBoxMoneda.DataSource = lista;
            }
            else if (comboBoxInversion.Text == "Inversión Vista Pactada")
            {

                comboBoxMoneda.DataSource = Validacion.Validacion.getMonedas();
            }


            

        }

    }
}
