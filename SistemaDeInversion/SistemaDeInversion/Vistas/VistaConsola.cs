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
        private int montoInversion;
        private int plazoDias;
        private int tipoMoneda;


        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        private Boolean ingresarDatosCliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su nombre:\n");
            nombre = Console.ReadLine();
            Console.WriteLine(">>> Por favor ingrese unicamente su primer apellido:\n");
            primerApellido = Console.ReadLine();
            Console.WriteLine(">>> Por favor ingrese unicamente su segundo apellido:\n");
            segundoApellido = Console.ReadLine();
            return asignarDatosCliente();
        }

        private Boolean asignarDatosCliente()
        {
            if (!Validacion.Validacion.validarLetras(nombre) || !Validacion.Validacion.validarVacio(nombre))
            {
                Console.WriteLine(">>> No ha ingresado su nombre correctamente intente de nuevo\n>>> Por favor ingrese unicamente su nombre:\n");
                ingresarDatosCliente();
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

            if (consola.ingresarDatosCliente())
            {
                Console.WriteLine(consola.nombre+consola.primerApellido+consola.segundoApellido);
            }
            else
            {
                Console.WriteLine("false");
            }




            //Console.WriteLine("\n>>> Por favor ingrese el Servicio de Inversión y Ahorro:");
            //Console.WriteLine(">>> 1) ---> Cuenta Corriente");
            //Console.WriteLine(">>> 2) ---> Inversión a la Vista Tasa Pactada");
            //Console.WriteLine(">>> 3) ---> Certificado de Inversión\n");
            //asignardato("servicio");
            ////tipoServicio = Int32.Parse(Console.ReadLine().ToString());
            //Console.WriteLine("\n>>> Por favor ingrese el Monto de Inversión y Ahorro:");
            //montoInversion = Int32.Parse(Console.ReadLine().ToString());
            //Console.WriteLine("\n>>> Por favor ingrese el Plazo de la Inversion:");
            //plazoDias = Int32.Parse(Console.ReadLine().ToString());
            //Console.WriteLine("\n>>> Por favor ingrese el Tipo de Moneda de la inversión:");
            //tipoMoneda = Int32.Parse(Console.ReadLine().ToString());

        }
    }
}