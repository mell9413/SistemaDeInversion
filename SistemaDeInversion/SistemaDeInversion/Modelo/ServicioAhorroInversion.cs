using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo
{
    public abstract class ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;
        private String id;
        private double montoInversion;
        private int plazoDias;
        private double interes;
        private Moneda moneda;
        private Cliente cliente;

        public ServicioAhorroInversion(Cliente cliente, Moneda moneda, double montoInversion, int plazoDias)
        {
            this.Cliente = cliente;
            this.Moneda = moneda;
            this.MontoInversion = montoInversion;
            this.PlazoDias = plazoDias;
            this.Id = "Serv#" + CantidadInstancias;
            CantidadInstancias++;
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

            set
            {
                id = value;
            }
        }

        public double MontoInversion
        {
            get
            {
                return montoInversion;
            }

            set
            {
                montoInversion = value;
            }
        }

        public int PlazoDias
        {
            get
            {
                return plazoDias;
            }

            set
            {
                plazoDias = value;
            }
        }

        public double Interes
        {
            get
            {
                return interes;
            }

            set
            {
                interes = value;
            }
        }

        public Moneda Moneda
        {
            get
            {
                return moneda;
            }

            set
            {
                moneda = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }
    }
}
