
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
       private FactoryCliente factoryCliente;
       private FactoryServicio factoryServicio; 
       private ArrayList factoryIEscritor;


        public Controlador()
        {
            this.factoryCliente= new FactoryConcretoCliente();
            this.factoryServicio = new FactoryConcretoServicio();
            this.factoryIEscritor = new ArrayList();
            this.factoryIEscritor.Add(new FactoryConcretoBitacora().crearBitacora("BitacoraCSV"));
            this.factoryIEscritor.Add(new FactoryConcretoBitacora().crearBitacora("BitacoraXML"));

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
            servicio.calcularSaldoFinal();
            try
            {
                CertificadoInversion temp = (CertificadoInversion)servicio;
                dtoServicio.ImpuestoRenta = temp.calcularImpuestoRenta();
            }
            catch
            {

            }
            dtoServicio.InteresGanado = servicio.InteresGanado;
            dtoServicio.Interes = servicio.Interes;
            dtoServicio.SaldoFinal = servicio.SaldoFinal;
            dtoServicio.Cliente = cliente;
            realizarRegistroBitacora(dtoServicio);
            cliente.agregarServicioInversion(servicio);
        }

        public void realizarRegistroBitacora(DTOServicioAhorroInversion dtoInversion) {
            foreach (IEscritor elemento in factoryIEscritor) {
                elemento.escribirMovimiento(dtoInversion);
            }
        }

   }
}
