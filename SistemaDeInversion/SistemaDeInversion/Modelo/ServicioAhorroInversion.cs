using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SistemaDeInversion.DTOs;
using System.Windows.Forms;

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
        protected double saldoFinal;
        protected Cliente cliente;
        protected double interesGanado;

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
        public double SaldoFinal
        {
            get
            {
                return this.saldoFinal;
            }
        }
        public double InteresGanado
        {
            get
            {
                return this.interesGanado;
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

        public void calcularRendimiento()
        {
            this.verificarSaldo();
            this.calcularInteres();
            double rendimiento = 0;
            for (int i = 1; i != this.plazoDias; i++)
            {
                rendimiento += this.montoInversion * (this.interes / 360);
            }
            
            this.interesGanado=rendimiento;

        }
        private void calcularSaldofinal()
        {
            this.saldoFinal=this.montoInversion + this.interesGanado;
        }
        private void verificarSaldo()
        {
            MessageBox.Show(obtenerSaldoMinimo().ToString());
            if(this.montoInversion < obtenerSaldoMinimo())
            {
                throw new System.ArgumentException("El saldo mínimo requerido es de " + obtenerSaldoMinimo().ToString(), "Saldo Mínimo");
            }
        }
    }
}
