using SistemaDeInversion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.Modelo.Factorys;

namespace SistemaDeInversion.Controles
{
    class Controlador: IControlador
    {
       // private FactoryCliente factoryCliente = new FactoryCliente();
        private FactoryServicio factoryServicio = new FactoryConcretoServicio();
      //  private FactoryBitacora factoryBitacora = new FactoryBitacora();

        public Controlador()
        {
        }

       public void crearBitacora()
        {
            //factoryBitacora();
            
        }

        public Cliente crearCliente(DTOCliente dtoCliente)
        {
            throw new NotImplementedException();
        }

        public ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio)
        {
            throw new NotImplementedException();
        }

        public void realizarInversion(DTOServicioAhorroInversion dtoServicio, DTOCliente dtoCliente)
        {
            throw new NotImplementedException();
        }
    }
}
