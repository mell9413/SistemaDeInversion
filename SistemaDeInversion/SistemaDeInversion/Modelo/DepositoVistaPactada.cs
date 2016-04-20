using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    public class DepositoVistaPactada: ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public DepositoVistaPactada (Cliente cliente, Moneda moneda, double montoInversion, int plazoDias): base (cliente,moneda,montoInversion,plazoDias)
        {
            cantidadInstancias++;
        }
        public override double calcularRendimiento()
        {
            return 2;
        }
    }
}
