using SistemaDeInversion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    interface IControlador
    {
        void realizarRegistro(DTOServicioAhorroInversion dtoInversion);
        ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio);
        Cliente crearCliente(DTOCliente dtoCliente);
        void realizarInversion(DTOServicioAhorroInversion dtoServicio, DTOCliente dtoCliente);
    }
}
