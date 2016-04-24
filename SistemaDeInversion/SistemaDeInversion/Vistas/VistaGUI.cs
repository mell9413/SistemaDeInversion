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
using SistemaDeInversion.Modelo;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.Modelo.Factorys;

namespace SistemaDeInversion.Vistas
{
    public partial class VistaGUI : Form
    {
        private FactoryControlador factoryControl = new FactoryConcretoControlador();
        private List<String> tiposServicios = new List<String>();
        private DTOCliente dtoCliente = new DTOCliente();
        private DTOServicioAhorroInversion dtoServicio = new DTOServicioAhorroInversion();
       


        public VistaGUI()
        {

            InitializeComponent();

        }
        private void ocultarLabels()
        {
            labelNombre.Visible = false;
            labelMonto.Visible = false;
            labelDias.Visible = false;
            labelInversion.Visible = false;
            labelInteres.Visible = false;
            renDias.Visible = false;
            renMonto.Visible = false;
            renInteresesGanados.Visible = false;
            renSaldoFinal.Visible = false;

        }

        private void VistaGUI_Load(object sender, EventArgs e)
        {
            comboBoxInversion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            establecerMonedas();
            establecerServicios();
            ocultarLabels();
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
                asignarDTOCliente();
                asignarDTOInversion();
                procesarInversion();
                MessageBox.Show("linda");
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }

        private void procesarInversion()
        {
            IControlador control = factoryControl.crearIControlador();
            control.realizarInversion(dtoServicio,dtoCliente);
            MessageBox.Show(dtoServicio.Interes.ToString());
            MessageBox.Show(dtoServicio.Interes.ToString());

        }

        private void asignarDTOCliente()
        {
            dtoCliente.Nombre = textBoxNombre.Text;
            dtoCliente.PrimerApellido = textBoxApellido1.Text;
            dtoCliente.PrimerApellido = textBoxApellido2.Text;

          

        }

        private void asignarDTOInversion()
        {
            dtoServicio.MontoInversion = Convert.ToDouble(textBoxMonto.Text);
            dtoServicio.Moneda = comboBoxMoneda.Text;
            dtoServicio.TipoServicio = tiposServicios.ElementAt(comboBoxInversion.SelectedIndex);
            dtoServicio.PlazoDias = Decimal.ToInt32(numericUpDownPlazo.Value);


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
            comboBoxMoneda.DataSource = LectorData.obtenerMonedasXinstancia("CuentaCorriente");
        }

        private void establecerServicios()
        {
            List<String[]> lista = LectorData.obtenerServicios();
            ArrayList listCompleta = new ArrayList();
            foreach(string[] elemento in lista)
            {
                listCompleta.Add(elemento[0]);
                tiposServicios.Add(elemento[1]);

            }
            
            comboBoxInversion.DataSource = listCompleta;

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

             comboBoxMoneda.DataSource = LectorData.obtenerMonedasXinstancia(tiposServicios.ElementAt(comboBoxInversion.SelectedIndex));
        }

    }
}
