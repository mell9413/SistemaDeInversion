using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.Modelo;

namespace SistemaDeInversion.Modelo
{
    public abstract class IEscritor
    {
        public abstract void crearArchivo();
        public abstract void escribirMovimiento(DTOs.DTOServicioAhorroInversion dtomovimiento);
        public abstract Boolean existeArchivo();
    }
}
