using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class Cliente
    {
        private static int cantidadInstancias = 0;
        private String id;
        private System.Collections.ArrayList serviciosTradicionales;

        public Cliente() {
            this.id = "clte"+cantidadInstancias;
            cantidadInstancias++;
            this.serviciosTradicionales = new System.Collections.ArrayList();
        }

        public String toString() {
            return "Id cliente:"+this.id;
        }
    }
}
