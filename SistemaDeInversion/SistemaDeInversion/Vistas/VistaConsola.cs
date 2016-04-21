using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Vistas
{
    class VistaConsola
    {
        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private int tipoServicio;
        private string nombreServicio;
        private double montoInversion;
        private int plazoDias;
        private int tipoMoneda;
        private string numeroTemporal;
        private double minimo;
        ArrayList servicios = Validacion.Validacion.getServicios();
        ArrayList monedas = Validacion.Validacion.getMonedas();
        private string nombreMoneda;

        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        private void ingresarDatosCliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su nombre:\n");
            nombre = Console.ReadLine();
            if (validarDatosCliente(nombre))
            {
                Console.WriteLine(">>> Por favor ingrese unicamente su primer apellido:\n");
                primerApellido = Console.ReadLine();
                if (validarDatosCliente(primerApellido))
                {
                    Console.WriteLine(">>> Por favor ingrese unicamente su segundo apellido:\n");
                    segundoApellido = Console.ReadLine();
                    if (!validarDatosCliente(segundoApellido))
                    {
                        ingresarDatosCliente();
                    }
                }
                else
                {
                    ingresarDatosCliente();
                }
            }
            else
            {
                ingresarDatosCliente();
            }
        }

        private Boolean validarDatosCliente(String dato)
        {
            if (!Validacion.Validacion.validarLetras(dato) || !Validacion.Validacion.validarVacio(dato))
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
            if (validarInt(numeroTemporal))
            {
                if (validarRango(Int32.Parse(numeroTemporal.ToString()), rangoLista))
                {
                    tipoServicio = Int32.Parse(numeroTemporal.ToString());
                    nombreServicio = servicios[tipoServicio - 1].ToString();
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
            if (validarDouble(numeroTemporal))
            {
                
                if (validarMinimos(Int32.Parse(numeroTemporal.ToString())))
                {
                    montoInversion = Int32.Parse(numeroTemporal.ToString());
                }
                else
                {
                    Console.WriteLine(">>> Debe ingresar un monto minimo igual o mayor a "+minimo);
                    ingresarInversion();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese unicamente números, intente de nuevo");
                ingresarInversion();
            }
        }

        private void ingresarPlazo()
        {
            Console.WriteLine("\n>>> Por favor ingrese el Plazo de la Inversion:");
            numeroTemporal = Console.ReadLine();
            if (validarInt(numeroTemporal))
            {
                plazoDias = Int32.Parse(numeroTemporal.ToString());
            }
            else
            {
                Console.WriteLine(">>> Ingrese unicamente números enteros, intente de nuevo");
                ingresarPlazo();
            }
        }

        private void ingresarMoneda()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
            int rangoLista = getElementos(monedas);
            numeroTemporal = Console.ReadLine();
            if (validarInt(numeroTemporal))
            {
                if (validarRango(Int32.Parse(numeroTemporal.ToString()), rangoLista))
                {
                    tipoMoneda = Int32.Parse(numeroTemporal.ToString());
                    nombreMoneda = monedas[tipoMoneda-1].ToString();
                }
                else
                {
                    Console.WriteLine(">>> El numero ingresado esta fuera del rango de las monedas disponibles, intente de nuevo");
                    ingresarMoneda();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente a la moneda que desea, intente de nuevo");
                ingresarMoneda();
            }
        }
        private void ingresarMoneda(String nombreServicio)
        {
            if (nombreServicio == "Inversión Vista Pactada")
            {
                ingresarMoneda();
            }
            else
            {
                Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
                Console.WriteLine(">>> 1) ---> Colón");
                numeroTemporal = Console.ReadLine();
                if (validarInt(numeroTemporal))
                {
                    if (validarRango(Int32.Parse(numeroTemporal.ToString()), 1))
                    {
                        tipoMoneda = Int32.Parse(numeroTemporal.ToString());
                        nombreMoneda = "Colón";
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
        }
        private Boolean validarInt(String numero)
        {
            if ( !Validacion.Validacion.validarNumeros(numero) || !Validacion.Validacion.validarVacio(numero))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean validarDouble(String numero)
        {
            if (!Validacion.Validacion.validarDouble(numero) || !Validacion.Validacion.validarDouble(numero))
            {
                return false;
            }
            else
            {
                return true;
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

        private Boolean validarMinimos(int monto)
        {
            if (this.tipoServicio==1 && monto < Validacion.Validacion.getSaldoMinCC())
            {
                minimo = Validacion.Validacion.getSaldoMinCC();
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
        static void Main(string[] args)
        {
            while (false)
            {
                //NativeMethods.AllocConsole();
                //Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
                //Console.WriteLine("\n>>> Por favor ingrese su nombre completo:");
            }
            VistaConsola consola = new VistaConsola();
            NativeMethods.AllocConsole();
            Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");

            consola.ingresarDatosCliente();
            consola.ingresarServicio();
            consola.ingresarMoneda(consola.nombreServicio);
            consola.ingresarPlazo();
            consola.ingresarInversion();
            //consola.ingresarInversion();
            //consola.ingresarPlazo();
            //consola.ingresarMoneda(consola.nombreServicio);

            Console.WriteLine(consola.nombre+consola.primerApellido+consola.segundoApellido+consola.tipoServicio+consola.plazoDias+consola.montoInversion+consola.tipoMoneda);
            Console.WriteLine(consola.nombreMoneda+"    "+consola.nombreServicio);

            Console.ReadLine();
        }
    }
}