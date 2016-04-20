using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Validacion
{
    public static class  Validacion
    {
        // Valida si un string contiene solo letras
        public static bool validarLetras(string nombre)
        {
            foreach(char caracter in nombre)
            {
                if (!char.IsLetter(caracter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
