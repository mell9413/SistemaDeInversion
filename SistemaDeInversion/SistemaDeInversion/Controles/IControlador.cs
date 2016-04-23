using SistemaDeInversion.DTOs;
using SistemaDeInversion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Controles
{
    interface IControlador
    {
        void crearBitacora();
        ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio);
        Cliente crearCliente(DTOCliente dtoCliente);
        void realizarInversion(DTOServicioAhorroInversion dtoServicio);
    }
}
