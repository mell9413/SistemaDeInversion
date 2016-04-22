using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemaDeInversion.Modelo
{
    public abstract class ServicioAhorroInversion:ILector
    {
        private static int cantidadInstancias = 0;
        protected String id;
        protected double montoInversion;
        protected int plazoDias;
        protected double interes;
        protected String moneda;
        private Cliente cliente;

        public ServicioAhorroInversion(Cliente cliente,String tipoMoneda, double montoInversion, int plazoDias)
        {
            this.cliente = cliente;
            this.montoInversion = montoInversion;
            this.plazoDias = plazoDias;
            this.moneda = tipoMoneda;
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

      

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

        }
        public abstract void calcularInteres();

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

        protected string getDataPath()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\");
            return ruta;
        }


        public bool mo { get; set; }
    }
}
