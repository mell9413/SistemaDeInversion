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
using SistemaDeInversion.DTOs;
using SistemaDeInversion.Modelo.Factorys;
using SistemaDeInversion.Modelo;

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


        public static double validarMinimos(double monto, string claseServicio, DTOServicioAhorroInversion dtoInversion)
        {
            double minimo = monto;
            FactoryConcretoServicio factory = new FactoryConcretoServicio();
            ServicioAhorroInversion clase = factory.crearServicioAhorroInversion(dtoInversion);
            if (0 > monto.CompareTo(clase.obtenerSaldoMinimo()))
            {
                return minimo = clase.obtenerSaldoMinimo();
            }
            else
            {
                return 0;
            }
        }
    }
}
