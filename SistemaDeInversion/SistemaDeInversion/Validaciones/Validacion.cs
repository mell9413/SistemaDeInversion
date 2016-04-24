using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SistemaDeInversion.DataBase;

namespace SistemaDeInversion.Validaciones
{
    public static class  Validacion
    {
        // Valida si un string contiene solo letras
        public static bool validarLetras(string palabra)
        {
            foreach(char caracter in palabra)
            {
                if (!char.IsLetter(caracter))
                {
                    return false;
                }
            }
            return true;
        }

        //public static bool validarMontoInversion(string inversion, double monto)
        //{
        //    if (inversion ==  "Cuenta Corriente")
        //    {
        //        validarMontoCC(monto);
        //    }

        //    return true;
        //}

        //private static bool validarMontoCC(double cantidad)
        //{
        //    return LectorData.obtenerSaldoMinCuentaCorriente() <= cantidad;

        //}

        //private static bool validarMontoIVP(double cantidad, string moneda)
        //{
        //    return LectorData.obtenerMinInversionVista(moneda) <= cantidad;

        //}

        private static bool validarMontoCertificado(double cantidad, string moneda)
        {
            return true;

        }
        // valida si un string viene vacio
        public static bool validarVacio(string palabra)
        {
            if(palabra == "")
            {
                return false;
            }
            return true;
 
        }

        // valida si un string contiene numeros
        public static bool validarNumeros(string numero)
        {
            foreach(char caracter in numero)
            {
                if (!char.IsDigit(caracter))
                {
                    return false;
                }
            }
            return true;
        }

        //valida si un string es tipo double
        public static bool validarDouble(string numero)
        {
            double resultado;
            if(!Double.TryParse(numero, out resultado))
            {
                return false;
            }
            return true;
        }


        // Metodo inutil, codigo muerto posiblemente
        public static ArrayList GetEnumerableOfType() 
        {
            ArrayList objects = new ArrayList();
            foreach (Type type in
                Assembly.GetAssembly(typeof(Modelo.ServicioAhorroInversion)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Modelo.ServicioAhorroInversion))))
            {
                objects.Add(type);
            }

            return objects;
        }
        

    }
}
