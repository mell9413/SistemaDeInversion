using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.Modelo;
using SistemaDeInversion.DTOs;
namespace SistemaDeInversion.Modelo
{
    public interface IEscritor
    {
        void crearArchivo();
        void escribirMovimiento(DTOServicioAhorroInversion dtoInversion);
        Boolean existeArchivo();
    }
}
