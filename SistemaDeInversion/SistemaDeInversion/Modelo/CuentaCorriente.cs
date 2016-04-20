using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace SistemaDeInversion.Modelo
{
    class CuentaCorriente : ServicioAhorroInversion, ILector
    {
        posibleInterface x = new posibleInterface();
        private static int cantidadInstancias = 0;

        public CuentaCorriente(Cliente cliente, Moneda moneda, double montoInversion, int plazoDias)
            : base(cliente, moneda, montoInversion, plazoDias)
        {
            base.id = "CntCo#" + cantidadInstancias;
            cantidadInstancias++;
            x = new posibleInterface();
        }

        public override double calcularRendimiento()
        {
            ArrayList tabla = this.x.lol();
            MessageBox.Show(tabla[1].ToString());


            return 2;
        }

        public string getDataPath()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }
    }
}
