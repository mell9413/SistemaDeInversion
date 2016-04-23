using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.Controles;

namespace SistemaDeInversion.Modelo.Factorys
{
    public class FactoryConcretoControlador : FactoryControlador
    {
        public override Controlador crearIControlador()
        {
            return null;
        }
    }
}
