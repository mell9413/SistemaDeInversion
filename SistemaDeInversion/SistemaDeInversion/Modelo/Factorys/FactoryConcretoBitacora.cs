using SistemaDeInversion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo.Factorys
{
    class FactoryConcretoBitacora : FactoryIEscritor
    {
        public override IEscritor crearBitacora(String tipoBitacora)
        { 
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("SistemaDeInversion.Modelo."+tipoBitacora);
            object[] args = {};
            IEscritor claseConcreta = (IEscritor)Activator.CreateInstance(type, args);
            return claseConcreta;
        }

        
    }
}
