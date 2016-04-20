using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    interface IEscritor
    {
        void crearArchivo();
        void escribirMovimiento();
        String asignarRuta();
    }
}
