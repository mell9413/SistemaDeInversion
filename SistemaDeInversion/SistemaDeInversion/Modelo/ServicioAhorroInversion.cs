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
        public abstract double getInteres();
        public abstract double calcularRendimiento();

        protected string getDataPath()
        {
            String ruta = Directory.GetCurrentDirectory().Replace("bin\\Debug", "\\Data\\books.xml.xml");
            return ruta;
        }


        public bool mo { get; set; }
    }
}
