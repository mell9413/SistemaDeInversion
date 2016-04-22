using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    public class Cliente
    {
        private static int cantidadInstancias = 0;
        private String id;
        private ArrayList serviciosAhorroInversion;
        private string nombre;
        private string primerApellido;
        private string segundoApellido;

        public Cliente()
        {
            this.id = "Clte#" + CantidadInstancias;
            CantidadInstancias++;
            this.serviciosAhorroInversion = new ArrayList();
        }

        public static int CantidadInstancias
        {
            get
            {
                return cantidadInstancias;
            }

            set
            {
                cantidadInstancias = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public ArrayList ServiciosAhorroInversion
        {
            get
            {
                return serviciosAhorroInversion;
            }

            set
            {
                serviciosAhorroInversion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string PrimerApellido
        {
            get
            {
                return primerApellido;
            }

            set
            {
                primerApellido = value;
            }
        }

        public string SegundoApellido
        {
            get
            {
                return segundoApellido;
            }

            set
            {
                segundoApellido = value;
            }
        }
    }
}