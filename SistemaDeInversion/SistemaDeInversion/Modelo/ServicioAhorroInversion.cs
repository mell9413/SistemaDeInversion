using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SistemaDeInversion.DTOs;

namespace SistemaDeInversion.Modelo
{
    public abstract class ServicioAhorroInversion
    {
        private static int cantidadInstancias = 0;
        protected String id;
        protected double montoInversion;
        protected int plazoDias;
        protected double interes;
        protected String moneda;
        protected Cliente cliente;

        public ServicioAhorroInversion(DTOServicioAhorroInversion dtoInversion)
        {
            this.montoInversion = dtoInversion.MontoInversion;
            this.plazoDias = dtoInversion.PlazoDias;
            this.interes = dtoInversion.Interes;
            this.moneda = dtoInversion.Moneda;
            this.cliente = dtoInversion.Cliente;
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

      

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

        }

        public abstract void calcularInteres();
        public abstract double obtenerSaldoMinimo();

        public double calcularRendimiento()
        {
            this.calcularInteres();
            double rendimiento = 0;
            for (int i = 0; i != this.plazoDias; i++)
            {
                rendimiento += this.montoInversion * (this.interes / 360);
            }
            return rendimiento;

        }
        private void verificarSaldo()
        {
            if(!this.montoInversion < obtenerSaldoMinimo())
            {
               // throw new Ex
            }
        }
    }
}
