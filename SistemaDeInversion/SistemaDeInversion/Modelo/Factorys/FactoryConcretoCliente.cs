using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DTOs;

namespace SistemaDeInversion.Modelo.Factorys
{
    public class FactoryConcretoCliente : FactoryCliente
    {
        public override Cliente crearCliente(DTOCliente dtoCliente)
        {
            return null;
        }
    }
}
