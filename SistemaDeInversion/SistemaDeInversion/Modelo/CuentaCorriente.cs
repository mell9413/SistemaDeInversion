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
using SistemaDeInversion.DTOs;
using SistemaDeInversion.DataBase;

namespace SistemaDeInversion.Modelo
{
    public class CuentaCorriente : ServicioAhorroInversion
    {
        
        private static int cantidadInstancias = 0;


        public CuentaCorriente(DTOServicioAhorroInversion dtoInversion) : base(dtoInversion)
        {
            base.id = "CntCo#" + cantidadInstancias;
            cantidadInstancias++;
        }

        public override void calcularInteres()
        {

            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() + "CuentaCorriente.xml");
             var intAnual = (from rango in xelement.Elements("row")
                             where (double)rango.Element("rangomax")>=base.montoInversion
                             select rango).First();
             base.interes= Convert.ToDouble(intAnual.Element(base.moneda).Value);
        }

        public override double obtenerSaldoMinimo()
        {

            double saldoMin;
            XElement xelement = XElement.Load(LectorData.obtenerRutaCarpeta() +"CuentaCorriente.xml");
            IEnumerable<XElement> servicios = xelement.Elements();
            saldoMin = Convert.ToDouble(servicios.ToArray()[0].Element("rangomin").Value);
            return saldoMin;

        }

        public override void calcularSaldoFinal()
        {
            this.saldoFinal=this.montoInversion + this.interesGanado;
        }

       
    }
}
