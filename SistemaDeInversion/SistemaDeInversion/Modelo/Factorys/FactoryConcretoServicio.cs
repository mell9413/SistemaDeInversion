using SistemaDeInversion.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DataBase;
using System.Reflection;
using System.Windows.Forms;

namespace SistemaDeInversion.Modelo.Factorys
{
    class FactoryConcretoServicio: FactoryServicio
    {
        private Hashtable serviciosRegistrados = new Hashtable();



        private void registrarServicioHash (String tipo, Object servicio)
        {
            serviciosRegistrados.Add(tipo, servicio);
            MessageBox.Show("final");
            MessageBox.Show(servicio.ToString());

        }

        public override void registrarServiciosHash()
        {
            foreach(String elemento in LectorData.obtenerServicios())// "Cuenta Corriente" ,, "CuentaCorriente"
            {
                Type clase = Type.GetType("SistemaDeInversion.Modelo." + "");
                MessageBox.Show(clase.ToString());
                registrarServicioHash(elemento, clase);
            }
        }

        public override ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio)
        {
            ServicioAhorroInversion x = new CuentaCorriente(dtoServicio);
            return x;
        }
    }
}
