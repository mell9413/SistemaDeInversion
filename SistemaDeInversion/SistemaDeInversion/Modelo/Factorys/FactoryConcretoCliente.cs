using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DTOs;
using System.Reflection;

namespace SistemaDeInversion.Modelo.Factorys
{
    public class FactoryConcretoCliente : FactoryCliente
    {
        public override Cliente crearCliente(DTOCliente dtoCliente)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("SistemaDeInversion.Modelo.Cliente");
            object[] args = { dtoCliente };
            Cliente claseConcreta = (Cliente)Activator.CreateInstance(type, args);
            return claseConcreta;
        }
    }
}
