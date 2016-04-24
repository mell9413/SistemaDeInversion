using SistemaDeInversion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo.Factorys
{
    class FactoryConcretoXML : FactoryIEscritor
    {
        public override IEscritor crearBitacora()
        { 
            var assembly = Assembly.GetExecutingAssembly();
            //MessageBox.Show(dtoServicio.TipoServicio.ToString());
            var type = assembly.GetType("SistemaDeInversion.Modelo.BitacoraXML");
            object[] args = {  };
            //MessageBox.Show("aqui");
            IEscritor claseConcreta = (IEscritor)Activator.CreateInstance(type, args);
            return claseConcreta;
        }

        
    }
}
