
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.Modelo.Factorys;

namespace SistemaDeInversion.Modelo
{
    public class Controlador: IControlador
    {
       private FactoryCliente factoryCliente = new FactoryConcretoCliente();
       private FactoryServicio factoryServicio = new FactoryConcretoServicio();
        private ArrayList factoryIEscritor = new ArrayList { new FactoryConcretoXML().crearBitacora(), new FactoryConcretoCSV().crearBitacora() };


        public Controlador()
        {
        }

        public Cliente crearCliente(DTOCliente dtoCliente)
        {
            return factoryCliente.crearCliente(dtoCliente);
        }

        public ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio)
        {
            return factoryServicio.crearServicioAhorroInversion(dtoServicio);
        }

        public void realizarInversion(DTOServicioAhorroInversion dtoServicio, DTOCliente dtoCliente)
        {
            ServicioAhorroInversion servicio= this.crearServicioAhorroInversion(dtoServicio);
            Cliente cliente = this.crearCliente(dtoCliente);
            dtoServicio.Cliente = this.crearCliente(dtoCliente);
            servicio.calcularRendimiento();
            servicio.calcularSaldofinal();
            try
            {
                CertificadoInversion temp = (CertificadoInversion)servicio;
                dtoServicio.ImpuestoRenta = temp.calcacularImpuestoRenta();
            }
            catch
            {

            }
            dtoServicio.InteresGanado = servicio.InteresGanado;
            dtoServicio.Interes = servicio.Interes;
            dtoServicio.SaldoFinal = servicio.SaldoFinal;
            dtoServicio.Cliente = cliente;
            realizarRegistro(dtoServicio);
        }

        public void realizarRegistro(DTOServicioAhorroInversion dtoInversion) {
            foreach (IEscritor elemento in factoryIEscritor) {
                elemento.escribirMovimiento(dtoInversion);
            }
        }
    }
}
