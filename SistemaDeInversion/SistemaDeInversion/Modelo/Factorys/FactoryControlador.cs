using SistemaDeInversion.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo.Factorys
{
    public abstract class FactoryControlador
    {
        public abstract Controlador crearIControlador(); 
    }
}
