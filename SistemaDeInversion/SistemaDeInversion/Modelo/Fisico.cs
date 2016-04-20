using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    class Fisico:Cliente
    {
        private String nombre;
        private String primerApellido;
        private String segundoApellido;
        public Fisico(String nombre, String primerApellido, String segundoApellido):base()
        {
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
        }

  
    }
}
