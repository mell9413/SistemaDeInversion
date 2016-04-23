using System;
using System.Collections;
using System.Runtime.InteropServices;
using SistemaDeInversion.DataBase;
using SistemaDeInversion.Validaciones;
using SistemaDeInversion.Controles;
using System.Globalization;
using System.Collections.Generic;

namespace SistemaDeInversion.Vistas
{
    public class VistaConsola
    {

        private IControlador controlador = new Controlador();


        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private int tipoServicio;
        private string nombreServicio;
        private double montoInversion;
        private int plazoDias;
        private int tipoMoneda;
        private string numeroTemporal;
        private Double minimo;
        private int minimoDias;
        private string claseServicio;
        ArrayList servicios = LectorData.obtenerServicios();
        ArrayList clasesServicios = LectorData.obtenerServiciosClase();
        private string nombreMoneda;

        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        private void ingresarNombreCliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su nombre:\n");
            nombre = Console.ReadLine();
            if (validarDatosCliente(nombre))
            {
                ingresarApellido1Cliente();
            }
            else
            {
                ingresarNombreCliente();
            }
        }

        private void ingresarApellido1Cliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su primer apellido:\n");
            primerApellido = Console.ReadLine();
            if (validarDatosCliente(primerApellido))
            {
                ingresarApellido2Cliente();
            }
            else
            {
                ingresarApellido1Cliente();
            }
        }

        private void ingresarApellido2Cliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su segundo apellido:\n");
            segundoApellido = Console.ReadLine();
            if (!validarDatosCliente(segundoApellido))
            {
                ingresarApellido2Cliente();
            }
        }

        private Boolean validarDatosCliente(String dato)
        {
            if (!Validacion.validarLetras(dato) || !Validacion.validarVacio(dato))
            {
                Console.WriteLine(">>> No lo ha ingresado el dato correctamente intente de nuevo");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ingresarServicio()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Servicio de Inversión y Ahorro:");
            int rangoLista = getElementos(servicios);
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                if (validarRango(Int32.Parse(numeroTemporal.ToString()), rangoLista))
                {
                    tipoServicio = Int32.Parse(numeroTemporal.ToString());
                    nombreServicio = servicios[tipoServicio - 1].ToString();
                    claseServicio = clasesServicios[tipoServicio - 1].ToString();
                }
                else
                {
                    Console.WriteLine(">>> El numero ingresado esta fuera del rango de los servicios disponibles, intente de nuevo");
                    ingresarServicio();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente al servicio que desea, intente de nuevo");
                ingresarServicio();
            }
            
        }

        private void ingresarInversion()
        {
            Console.WriteLine("\n>>> Por favor ingrese el Monto de Inversión y Ahorro:");
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarDouble(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                //if (validarMinimos(double.Parse(numeroTemporal, CultureInfo.InvariantCulture)))
                //{
                    montoInversion = Double.Parse(numeroTemporal, CultureInfo.InvariantCulture);
                //}
                //else
                //{
                    Console.WriteLine(">>> Debe ingresar un monto minimo igual o mayor a "+minimo+ "\n>>>Si quiere expresar decimales por favor usar punto");
                    ingresarInversion();
                //}
            }
            else
            {
                Console.WriteLine(">>> Ingrese unicamente números, intente de nuevo");
                ingresarInversion();
            }
        }

        private void ingresarPlazo()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero de días para el Plazo de la Inversion:");
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                if( 0< Int32.Parse(numeroTemporal.ToString())){
                    if (tipoServicio==1 || validarMinimoDias(Int32.Parse(numeroTemporal.ToString()),claseServicio))
                    {
                        plazoDias = Int32.Parse(numeroTemporal.ToString());
                    }
                    else
                    {
                        Console.WriteLine(">>> El plazo mínimo para la inversión es de " + minimoDias + " intente de nuevo");
                        ingresarPlazo();
                    }
                }
                else
                {
                    Console.WriteLine(">>> Ingrese unicamente números enteros mayores a cero, intente de nuevo");
                    ingresarPlazo();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese unicamente números enteros, intente de nuevo");
                ingresarPlazo();
            }
        }

        private void ingresarMoneda(String nombreServicio)
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
            ArrayList monedas = LectorData.obtenerMonedasXinstancia(claseServicio);
            int rangoLista = getElementos(monedas);
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                if (validarRango(Int32.Parse(numeroTemporal.ToString()), rangoLista))
                {
                    tipoMoneda = Int32.Parse(numeroTemporal.ToString());
                    nombreMoneda = monedas[tipoMoneda-1].ToString();
                }
                else
                {
                    Console.WriteLine(">>> El numero ingresado esta fuera del rango de las monedas disponibles, intente de nuevo");
                    ingresarMoneda(this.nombreServicio);
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente a la moneda que desea, intente de nuevo");
                ingresarMoneda(this.nombreServicio);
            }
            
        }

        private Boolean validarRango(int numero, int rango)
        {
            if (0<numero && numero<=rango)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private Boolean validarMinimos(double monto,string claseServicio)
        //{
            
        //    if (0 > monto.CompareTo(claseServicio.obtenerSaldoMinimo()))
        //    {
        //        minimo = LectorData.obtenerSaldoMinCuentaCorriente();
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        private Boolean validarMinimoDias(int dias, string claseServicio)
        {
            minimoDias = LectorData.obtenerMinDias(claseServicio);
            if (dias<minimoDias)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int getElementos(ArrayList lista)
        {
            int i = 0;
            foreach (var elemento in lista)
            {
                Console.WriteLine(">>> " + (i + 1) + ") ---> " + lista[i]);
                i++;
            }
            return i;
        }

        private int getElementos(List<String[]> lista)
        {
            int i = 0;
            foreach (var elemento in lista)
            {
                Console.WriteLine(">>> " + (i + 1) + ") ---> " + lista[i]);
                i++;
            }
            return i;
        }

        private void resultado()
        {
            Console.Clear();
            Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
            Console.WriteLine("***** Datos del cliente y su operación bancaria *****");
            Console.WriteLine("Cliente:\t\t\t"+nombre+" "+primerApellido+" "+segundoApellido);
            Console.WriteLine("Monto de ahorro e inversión:\t" + montoInversion+" "+nombreMoneda);
            Console.WriteLine("Plazo de la inversión en días:\t" + plazoDias+" días");
            Console.WriteLine("Sistema de ahorro e inversión:\t" + nombreServicio);
            Console.WriteLine("Interés anual correspondiente:\t");
            Console.WriteLine("\n***Rendimiento***");
            if (nombreServicio == "Inversión Vista Pactada")
            {
                Console.WriteLine("Plazo en días\tMonto de ahorro e inversión\tIntereses ganados\tImpuesto de Renta\tSaldo Final");
                Console.WriteLine("\t" + plazoDias + "\t\t" + montoInversion + " " + nombreMoneda + "\t\t  " + "8100" + " " + nombreMoneda + "\t\t  " + "9999"+" "+nombreMoneda+ "\t\t  " + "565656");
            }
            else
            {
                Console.WriteLine("Plazo en días\tMonto de ahorro e inversión\tIntereses ganados\tSaldo Final");
                Console.WriteLine("\t" + plazoDias + "\t\t" + montoInversion + " " + nombreMoneda + "\t\t  " + "8100" + " " + nombreMoneda + "\t\t  " + "999999");
            }
            Console.WriteLine("--->Última línea<---");
        }
        public void run()
        {
            NativeMethods.AllocConsole();
            while (true)
            {

                Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
                ingresarNombreCliente();
                ingresarServicio();
                ingresarMoneda(claseServicio);
                ingresarPlazo();
                ingresarInversion();
                //enviardatosalDTO
                //consola.resultado(DTOInversion) al final Consola.run();
                resultado();
                Console.ReadLine();
            }
        }
    }
}