using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.Controles;
using System.Reflection;

namespace SistemaDeInversion.Modelo.Factorys
{
    public class FactoryConcretoIControlador : FactoryIControlador
    {
        public override Controlador crearIControlador()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("SistemaDeInversion.Modelo.Controlador");
            object[] args = {};
            Controlador claseConcreta = (Controlador)Activator.CreateInstance(type, args);
            return claseConcreta;
        }
    }
}
