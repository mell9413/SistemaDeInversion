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

using System.Reflection;
using SistemaDeInversion.Validaciones;
using SistemaDeInversion.DataBase;
using SistemaDeInversion.Controles;
using SistemaDeInversion.DTOs;



namespace SistemaDeInversion.Vistas
{
    public partial class VistaGUI : Form
    {
        //private FactoryControlador controlador = new Controlador();


        public VistaGUI()
        {
            //ServicioAhorroInversion x;
            //x = new CuentaCorriente(new Fisico("Marvin", "fernandez", "Coto"), "Colón", 1000000, 31);
           //MessageBox.Show( x.calcularRendimiento().ToString());
            InitializeComponent();
            //controlador.crearBitacora();
            
      

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

            // Valida que los datos ingresados sean correctos y devuelve los "datos incorrectos"

            validarTextBoxLetras(textBoxNombre);
            validarTextBoxLetras(textBoxApellido1);
            validarTextBoxLetras(textBoxApellido2);
            validarTextBoxVacios(textBoxNombre);
            validarTextBoxVacios(textBoxApellido1);
            validarTextBoxVacios(textBoxApellido2);
            validarTextBoxNumero(textBoxMonto);
            //validarTextBoxMontoMayor(textBoxMonto);

            // Valida si existe en los nombres "datos incorrectos" y no deja registrar
            realizarInversion();
        }

        private void realizarInversion()
        {
            ArrayList boxList = new ArrayList();
            boxList.Add(textBoxApellido1);
            boxList.Add(textBoxNombre);
            boxList.Add(textBoxApellido2);
            boxList.Add(textBoxMonto);

            if (revisarDatos(boxList))
            {
                crearDTOCliente();
                crearDTOInversion();
                //controlador.realizarInversion();
                MessageBox.Show("linda");
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }

        private DTOCliente crearDTOCliente()
        {
            DTOCliente dtoCliente = new DTOCliente();
            dtoCliente.Nombre = textBoxNombre.Text;
            dtoCliente.PrimerApellido = textBoxApellido1.Text;
            dtoCliente.PrimerApellido = textBoxApellido2.Text;
            return dtoCliente;
        }

        private DTOServicioAhorroInversion crearDTOInversion()
        {
            DTOServicioAhorroInversion dtoServicio = new DTOServicioAhorroInversion();
            dtoServicio.Moneda = comboBoxMoneda.Text;
            dtoServicio.TipoServicio = comboBoxInversion.Text;
            dtoServicio.PlazoDias = Decimal.ToInt32(numericUpDownPlazo.Value);
            return dtoServicio;

        }
        private bool revisarDatos(ArrayList boxList)
        {
            string error = "Dato incorrecto"; 
            foreach(TextBox elemento in boxList)
            {
                if(elemento.Text == error)
                {
                    return false;
                }

            }
            return true;

        }




        private bool validarTextBoxMontoMayor(TextBox box)
        {
            //if (Validacion.Validacion.)
            return true;
        }

        private bool validarTextBoxLetras(TextBox box)
        {
            if (!Validaciones.Validacion.validarLetras(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private bool validarTextBoxVacios(TextBox box)
        {
            if (!Validacion.validarVacio(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private bool validarTextBoxNumero(TextBox box)
        {
            if (!Validacion.validarDouble(box.Text))
            {
                box.Text = "Dato incorrecto";
                box.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private void establecerMonedas()
        {
      
            comboBoxMoneda.DataSource = LectorData.obtenerMonedas();
        }

        private void establecerServicios()
        {
            comboBoxInversion.DataSource = LectorData.obtenerServicios();
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
        private void validarIncorrectos()
        {

        }

        private void comboBoxInversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* ArrayList listaServicios = LectorData.obtenerServicios();
             ArrayList lista = new ArrayList();
             if (comboBoxInversion.Text == listaServicios[0].ToString() || listaServicios[1].ToString() == "Certificado de Inversión")
             {
                 lista.Add(LectorData.obtenerMonedas()[1].ToString());
                 comboBoxMoneda.DataSource = lista;
             }
             else if (comboBoxInversion.Text == listaServicios[3].ToString())
             {

                 comboBoxMoneda.DataSource = LectorData.obtenerMonedas();
            } */




        }

    }
}
