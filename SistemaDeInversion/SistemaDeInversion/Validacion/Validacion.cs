using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Validacion
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

        public static bool validarVacio(string palabra)
        {
            if(palabra == "")
            {
                return false;
            }
            return true;
 
        }

        // Metodo inutil, codigo muerto posiblemente
        public static ArrayList GetEnumerableOfType(Type constructorArgs) 
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
