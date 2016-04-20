﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace SistemaDeInversion.Modelo
{
    class CuentaCorriente : ServicioAhorroInversion, ILector
    {
        
        private static int cantidadInstancias = 0;

        public CuentaCorriente(Cliente cliente, Moneda moneda, double montoInversion, int plazoDias)
            : base(cliente, moneda, montoInversion, plazoDias)
        {
            base.id = "CntCo#" + cantidadInstancias;
            cantidadInstancias++;
        }

         public override double getInteres()
        {
             XElement xelement = XElement.Load(base.getDataPath());
             var homePhone = (from phoneno in xelement.Elements("row")
                             where (double)phoneno.Element("rangomax")>=base.montoInversion
                             select phoneno).First();
            
            // foreach (XElement xEle in homePhone)
             //{
               //  MessageBox.Show(xEle.Element("interesAnual").Value);
             //}
             MessageBox.Show(homePhone.Element("interesAnual").Value);
             return Convert.ToDouble(homePhone.Element("interesAnual").Value);
        }
        
        public override double calcularRendimiento()
        {
           
           return 2;
        }



       
    }
}
