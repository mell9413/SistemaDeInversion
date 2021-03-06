﻿using System;
using System.Collections;
using System.Runtime.InteropServices;
using SistemaDeInversion.DataBase;
using SistemaDeInversion.Validaciones;
using SistemaDeInversion.Modelo;
using System.Globalization;
using System.Collections.Generic;
using SistemaDeInversion.DTOs;
using SistemaDeInversion.Modelo.Factorys;

namespace SistemaDeInversion.Vistas
{
    public class VistaConsola
    {

        private IControlador controlador = new Controlador();////WTF mae para eso esta el factory del controlador, apoyese en la GUI para q vea como se realiza la relación


        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private int tipoServicio;
        private string nombreServicio;
        private string claseServicio;
        private double montoInversion;
        private int plazoDias;
        private int tipoMoneda;
        private string nombreMoneda;
        private string numeroTemporal;
        private Double minimo;
        private int minimoDias;
        
        List<String[]> servicios = LectorData.obtenerServicios();
        

        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        private void ingresarNombreCliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su nombre:\n");
            nombre = Console.ReadLine();
            if (validarDatosCliente(nombre))
            {
                ingresarApellido1Cliente();
            }
            else
            {
                ingresarNombreCliente();
            }
        }

        private void ingresarApellido1Cliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su primer apellido:\n");
            primerApellido = Console.ReadLine();
            if (validarDatosCliente(primerApellido))
            {
                ingresarApellido2Cliente();
            }
            else
            {
                ingresarApellido1Cliente();
            }
        }

        private void ingresarApellido2Cliente()
        {
            Console.WriteLine(">>> Por favor ingrese unicamente su segundo apellido:\n");
            segundoApellido = Console.ReadLine();
            if (!validarDatosCliente(segundoApellido))
            {
                ingresarApellido2Cliente();
            }
        }

        private Boolean validarDatosCliente(String dato)
        {
            if (!Validacion.validarLetras(dato) || !Validacion.validarVacio(dato))
            {
                Console.WriteLine(">>> No lo ha ingresado el dato correctamente intente de nuevo");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ingresarServicio()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Servicio de Inversión y Ahorro:");
            int rangoLista = getElementos(servicios);
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                if (validarRango(Int32.Parse(numeroTemporal.ToString()), rangoLista))
                {
                    tipoServicio = Int32.Parse(numeroTemporal.ToString());
                    int i = 0;
                    foreach (var elemento in servicios) {
                        if (tipoServicio-1 == i) {
                            nombreServicio = elemento[0];
                            claseServicio = elemento[1];
                        }
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine(">>> El numero ingresado esta fuera del rango de los servicios disponibles, intente de nuevo");
                    ingresarServicio();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente al servicio que desea, intente de nuevo");
                ingresarServicio();
            }
            
        }

        private void ingresarInversion()
        {
            Console.WriteLine("\n>>> Por favor ingrese el Monto de Inversión y Ahorro:");
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarDouble(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                minimo = Validacion.validarMinimos(double.Parse(numeroTemporal, CultureInfo.InvariantCulture), claseServicio,crearDTOInversion());
                if (minimo==0)
                {
                    montoInversion = Double.Parse(numeroTemporal, CultureInfo.InvariantCulture);
                }
                else
                {
                    Console.WriteLine(">>> Debe ingresar un monto minimo igual o mayor a "+minimo+ "\n>>> Si quiere expresar decimales por favor usar punto");
                    ingresarInversion();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese unicamente números, intente de nuevo");
                ingresarInversion();
            }
        }

        private void ingresarPlazo()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero de días para el Plazo de la Inversion:");
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                if( 0< Int32.Parse(numeroTemporal.ToString())){
                    if (validarMinimoDias(Int32.Parse(numeroTemporal.ToString()),claseServicio))
                    {
                        plazoDias = Int32.Parse(numeroTemporal.ToString());
                    }
                    else
                    {
                        Console.WriteLine(">>> El plazo mínimo para la inversión es de " + minimoDias + " intente de nuevo");
                        ingresarPlazo();
                    }
                }
                else
                {
                    Console.WriteLine(">>> Ingrese unicamente números enteros mayores a cero, intente de nuevo");
                    ingresarPlazo();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese unicamente números enteros, intente de nuevo");
                ingresarPlazo();
            }
        }

        private void ingresarMoneda(String nombreServicio)
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
            String[] monedas = LectorData.obtenerMonedasXinstancia(claseServicio);
            int rangoLista = getMonedas(monedas);
            numeroTemporal = Console.ReadLine();
            if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
            {
                if (validarRango(Int32.Parse(numeroTemporal.ToString()), rangoLista))
                {
                    tipoMoneda = Int32.Parse(numeroTemporal.ToString());
                    nombreMoneda = monedas[tipoMoneda-1].ToString();
                }
                else
                {
                    Console.WriteLine(">>> El numero ingresado esta fuera del rango de las monedas disponibles, intente de nuevo");
                    ingresarMoneda(this.nombreServicio);
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente a la moneda que desea, intente de nuevo");
                ingresarMoneda(this.nombreServicio);
            }
            
        }

        private Boolean validarRango(int numero, int rango)
        {
            if (0<numero && numero<=rango)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        private Boolean validarMinimoDias(int dias, string claseServicio)
        {
            minimoDias = LectorData.obtenerMinDias(claseServicio);
            if (dias<minimoDias)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int getMonedas(String[] lista)
        {
            int i = 0;
            foreach (var elemento in lista)
            {
                Console.WriteLine(">>> " + (i + 1) + ") ---> " + elemento);
                i++;
            }
            return i;
        }

        private int getElementos(List<String[]> lista)
        {
            int i = 0;
            foreach (var elemento in lista)
            {
                Console.WriteLine(">>> " + (i + 1) + ") ---> " + elemento[0]);
                i++;
            }
            return i;
        }
        private DTOCliente crearDTOCliente()
        {
            DTOCliente dtoCliente = new DTOCliente();
            dtoCliente.Nombre = nombre;
            dtoCliente.PrimerApellido = primerApellido;
            dtoCliente.SegundoApellido = segundoApellido;
            return dtoCliente;
        }

        private DTOServicioAhorroInversion crearDTOInversion()
        {
            DTOServicioAhorroInversion dtoServicio = new DTOServicioAhorroInversion();
            dtoServicio.Moneda = nombreMoneda;
            dtoServicio.TipoServicio = claseServicio;
            dtoServicio.PlazoDias = plazoDias;
            dtoServicio.MontoInversion = montoInversion;
            return dtoServicio;
        }

        private void resultado()
        {
            DTOCliente cliente = crearDTOCliente();
            DTOServicioAhorroInversion inversion = crearDTOInversion();
            controlador.realizarInversion(inversion, cliente);
            Console.Clear();
            Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
            Console.WriteLine("***** Datos del cliente y su operación bancaria *****");
            Console.WriteLine("Cliente:\t\t\t"+cliente.Nombre+" "+cliente.PrimerApellido+" "+cliente.SegundoApellido);
            Console.WriteLine("Monto de ahorro e inversión:\t" + inversion.MontoInversion+" "+nombreMoneda);
            Console.WriteLine("Plazo de la inversión en días:\t" + inversion.PlazoDias+" días");
            Console.WriteLine("Sistema de ahorro e inversión:\t" + nombreServicio);
            Console.WriteLine("Interés anual correspondiente:\t"+ inversion.Interes);
            Console.WriteLine("\n***Rendimiento***");
            if (claseServicio == "CertificadoInversion")
            {
                Console.WriteLine("Plazo en días\t\t\t" + inversion.PlazoDias);
                Console.WriteLine("Monto de ahorro e inversión\t" + inversion.MontoInversion + " " + nombreMoneda);
                Console.WriteLine("Intereses ganados\t\t" + inversion.InteresGanado);
                Console.WriteLine("Impuesto de Renta\t\t" + inversion.ImpuestoRenta);
                Console.WriteLine("Saldo Final\t\t\t" + inversion.SaldoFinal);
            }
            else
            {
                Console.WriteLine("Plazo en días\t\t\t" + inversion.PlazoDias);
                Console.WriteLine("Monto de ahorro e inversión\t" + inversion.MontoInversion + " " + nombreMoneda);
                Console.WriteLine("Intereses ganados\t\t" + inversion.InteresGanado);
                Console.WriteLine("Saldo Final\t\t\t" + inversion.SaldoFinal);
            }
            Console.WriteLine("--->Última línea<---");

        }
        public void run()
        {
            NativeMethods.AllocConsole();
            while (true)
            {
                
                Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
                ingresarNombreCliente();
                ingresarServicio();
                ingresarMoneda(claseServicio);
                ingresarPlazo();
                ingresarInversion();
                //enviardatosalDTO
                //consola.resultado(DTOInversion) al final Consola.run();
                resultado();
                Console.ReadLine();
            }
        }
    }
}