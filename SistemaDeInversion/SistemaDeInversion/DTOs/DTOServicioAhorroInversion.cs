using SistemaDeInversion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.DTOs
{
    public class DTOServicioAhorroInversion
    {
        private double montoInversion;
        private int plazoDias;
        private double interes;
        private double impuestoRenta;
        private Cliente cliente;
        private String moneda;
        private double saldoFinal;
        private double interesGanado;
        private String tipoServicio;

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

        public double ImpuestoRenta
        {
            get
            {
                return impuestoRenta;
            }

            set
            {
                impuestoRenta = value;
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

        public string Moneda
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

        public double SaldoFinal
        {
            get
            {
                return saldoFinal;
            }

            set
            {
                saldoFinal = value;
            }
        }

        public string TipoServicio
        {
            get
            {
                return tipoServicio;
            }

            set
            {
                tipoServicio = value;
            }
        }
        public double InteresGanado
        {
            get
            {
                return interesGanado;
            }

            set
            {
                interesGanado = value;
            }
        }

        public DTOServicioAhorroInversion()
        {

        }
    }
}
