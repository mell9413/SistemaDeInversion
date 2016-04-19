using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    class CuentaCorriente: ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public CuentaCorriente (Cliente cliente, Moneda moneda, double montoInversion, int plazoDias): base (cliente,moneda,montoInversion,plazoDias)
        {
            cantidadInstancias++;
        }
    }
}
