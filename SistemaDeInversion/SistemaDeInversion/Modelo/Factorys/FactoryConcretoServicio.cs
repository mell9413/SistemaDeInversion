using SistemaDeInversion.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DataBase;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using SistemaDeInversion.Validaciones;

namespace SistemaDeInversion.Modelo.Factorys
{
    public class FactoryConcretoServicio: FactoryServicio
    {

        public override ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio)
        {

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("SistemaDeInversion.Modelo." + dtoServicio.TipoServicio);
            object[] args = { dtoServicio };
            ServicioAhorroInversion claseConcreta = (ServicioAhorroInversion)Activator.CreateInstance(type, args);
            return claseConcreta;
            

        }
    }
}
