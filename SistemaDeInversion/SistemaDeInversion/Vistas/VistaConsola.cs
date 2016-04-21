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
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }
        static void Main(string[] args)
        {
            while (false)
            {
                //NativeMethods.AllocConsole();
                //Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
                //Console.WriteLine("\n>>> Por favor ingrese su nombre completo:");
            }
            NativeMethods.AllocConsole();
            Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
            Console.WriteLine(">>> Por favor ingrese su nombre completo:\n");
            string nombre = Console.ReadLine();
            Console.WriteLine("\n>>> Por favor ingrese el Servicio de Inversión y Ahorro:");
            Console.WriteLine(">>> 1) ---> Cuenta Corriente");
            Console.WriteLine(">>> 2) ---> Inversión a la Vista Tasa Pactada");
            Console.WriteLine(">>> 3) ---> Certificado de Inversión\n");
            int tipoServicio = Int32.Parse(Console.ReadLine());
        }
    }
}