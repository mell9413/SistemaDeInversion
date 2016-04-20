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
        protected String id;
        private double montoInversion;
        private int plazoDias;
        private double interes;
        private Moneda moneda;
        private Cliente cliente;

        public ServicioAhorroInversion(Cliente cliente, Moneda moneda, double montoInversion, int plazoDias)
        {
            this.cliente = cliente;
            this.moneda = moneda;
            this.montoInversion = montoInversion;
            this.plazoDias = plazoDias;
            //this.id = "Serv#" + CantidadInstancias;
            cantidadInstancias++;
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

        public double MontoInversion
        {
            get
            {
                return montoInversion;
            }

        }

        public int PlazoDias
        {
            get
            {
                return plazoDias;
            }

        }

        public double Interes
        {
            get
            {
                return interes;
            }
        }

        public Moneda Moneda
        {
            get
            {
                return moneda;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

        }

        public abstract double calcularRendimiento();

    }
}
