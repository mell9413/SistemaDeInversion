using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DTOs;

namespace SistemaDeInversion.Modelo
{
    public class Cliente
    {
        private static int cantidadInstancias = 0;
        private String id;
        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private ArrayList serviciosAhorroInversion;

        public Cliente(DTOCliente dtoCliente)
        {
            cantidadInstancias++;
            this.id = "Clte#" + CantidadInstancias;
            this.nombre = dtoCliente.Nombre;
            this.primerApellido = dtoCliente.PrimerApellido;
            this.segundoApellido = dtoCliente.SegundoApellido;
            this.serviciosAhorroInversion = new ArrayList();

        }

        public static int CantidadInstancias
        {
            get
            {
                return cantidadInstancias;
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

        public void agregarServicioInversion(ServicioAhorroInversion servicio)
        {
            this.serviciosAhorroInversion.Add(servicio);
        }

    }
}