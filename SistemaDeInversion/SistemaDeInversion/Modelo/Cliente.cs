﻿using System;
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
        private ArrayList serviciosAhorroInversion;
        private string nombre;
        private string primerApellido;
        private string segundoApellido;

        public Cliente(DTOCliente dtoCliente)
        {
            this.nombre = dtoCliente.Nombre;
            this.primerApellido = dtoCliente.PrimerApellido;
            this.segundoApellido = dtoCliente.SegundoApellido;
            this.id = "Clte#" + CantidadInstancias;
            cantidadInstancias++;
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