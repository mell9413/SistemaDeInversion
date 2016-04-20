using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    class CertificadoInversion: ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;

        public CertificadoInversion (Cliente cliente, Moneda moneda, double montoInversion, int plazoDias): base (cliente,moneda,montoInversion,plazoDias)
        {
          //  Id = "cerIn#"+cantidadInstancias;
            cantidadInstancias++;
        }

        public override double calcularRendimiento()
        {
            return 2;
        }

    }
}
