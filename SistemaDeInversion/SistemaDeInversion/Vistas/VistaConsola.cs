using System;
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
        private double montoInversion;
        private int plazoDias;
        private int tipoMoneda;
        private string numeroTemporal;


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
            Console.WriteLine(">>> 1) ---> Cuenta Corriente");
            Console.WriteLine(">>> 2) ---> Inversión a la Vista Tasa Pactada");
            Console.WriteLine(">>> 3) ---> Certificado de Inversión\n");
            numeroTemporal = Console.ReadLine();
            if (validarInt(numeroTemporal))
            {
                tipoServicio = Int32.Parse(numeroTemporal.ToString());
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
            if (validarInt(numeroTemporal))
            {
                montoInversion = Int32.Parse(numeroTemporal.ToString());
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
                Console.WriteLine(">>> Ingrese unicamente números, intente de nuevo");
                ingresarPlazo();
            }
        }

        private void ingresarMoneda()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
            Console.WriteLine(">>> 1) ---> Colón");
            Console.WriteLine(">>> 2) ---> Dólar");
            numeroTemporal = Console.ReadLine();
            if (validarInt(numeroTemporal))
            {
                tipoMoneda = Int32.Parse(numeroTemporal.ToString());
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente a la moneda que desea, intente de nuevo");
                ingresarMoneda();
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
            consola.ingresarInversion();
            consola.ingresarPlazo();
            consola.ingresarMoneda();

            Console.WriteLine(consola.nombre+consola.primerApellido+consola.segundoApellido+consola.tipoServicio+consola.plazoDias+consola.montoInversion+consola.tipoMoneda);
 
            Console.ReadLine();
        }
    }
}