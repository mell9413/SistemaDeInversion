using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SistemaDeInversion.Modelo
{
    class CuentaCorriente: ServicioAhorroInversion
    {
        posibleInterface x = new posibleInterface();
        private static int cantidadInstancias = 0;

        public CuentaCorriente (Cliente cliente, Moneda moneda, double montoInversion, int plazoDias): base (cliente,moneda,montoInversion,plazoDias)
        {
           // Id = "CntCo#" + cantidadInstancias;
            cantidadInstancias++;
            x = new posibleInterface();
        }

        public override double calcularRendimiento(){
            ArrayList tabla =this.x.lol();


            return 2;
        }
    }
}
