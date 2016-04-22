using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.Modelo;

namespace SistemaDeInversion.Modelo
{
    interface IEscritor
    {
        void crearArchivo();
        void escribirMovimiento(DTOs.DTOServicioAhorroInversion dtomovimiento);
        Boolean existeArchivo();
    }
}
