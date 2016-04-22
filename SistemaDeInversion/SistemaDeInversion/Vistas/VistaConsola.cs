﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.DataBase;
using SistemaDeInversion.Validaciones;
using SistemaDeInversion.Controles;

namespace SistemaDeInversion.Vistas
{
    class VistaConsola
    {

        private IControlador controlador = new Controlador();


        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private int tipoServicio;
        private string nombreServicio;
        private double montoInversion;
        private int plazoDias;
        private int tipoMoneda;
        private string numeroTemporal;
        private Double minimo;
        private int minimoDias;
        ArrayList servicios = LectorData.obtenerServicios();
        ArrayList monedas = LectorData.obtenerMonedas();
        private string nombreMoneda;

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
                    nombreServicio = servicios[tipoServicio - 1].ToString();
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
                if (validarMinimos(Double.Parse(numeroTemporal)))
                {
                    montoInversion = Double.Parse(numeroTemporal);
                }
                else
                {
                    Console.WriteLine(">>> Debe ingresar un monto minimo igual o mayor a "+minimo);
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
                    if (validarMinimoDias(Int32.Parse(numeroTemporal.ToString())))
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

        private void ingresarMoneda()
        {
            Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
            int rangoLista = getElementos(monedas);
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
                    ingresarMoneda();
                }
            }
            else
            {
                Console.WriteLine(">>> Ingrese el numero correspondiente a la moneda que desea, intente de nuevo");
                ingresarMoneda();
            }
        }
        private void ingresarMoneda(String nombreServicio)
        {
            if (nombreServicio == "Inversión Vista Pactada")
            {
                ingresarMoneda();
            }
            else
            {
                Console.WriteLine("\n>>> Por favor ingrese el numero correspondiente al Tipo de Moneda de la inversión:");
                Console.WriteLine(">>> 1) ---> Colones");
                numeroTemporal = Console.ReadLine();
                if (Validacion.validarNumeros(numeroTemporal) && Validacion.validarVacio(numeroTemporal))
                {
                    if (validarRango(Int32.Parse(numeroTemporal.ToString()), 1))
                    {
                        tipoMoneda = Int32.Parse(numeroTemporal.ToString());
                        nombreMoneda = "Colones";
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

        private Boolean validarMinimos(double monto)
        {
            if (this.tipoServicio == 1 && 0>monto.CompareTo(LectorData.obtenerSaldoMinCuentaCorriente()))
            {
                minimo = LectorData.obtenerSaldoMinCuentaCorriente();
                return false;
            }
            else if (this.tipoServicio == 3 && 0 > monto.CompareTo(LectorData.obtenerMinInversionVista(nombreMoneda)))
            {
                minimo = LectorData.obtenerMinInversionVista(nombreMoneda);
                return false;
            }



            else
            {
                return true;
            }
        }
        private Boolean validarMinimoDias(int dias)
        {
            minimoDias = LectorData.obtenerMinDiasInversionVista();
            if (this.tipoServicio == 3 && dias<minimoDias)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    private int getElementos(ArrayList lista)
        {
            int i = 0;
            foreach (var elemento in lista)
            {
                Console.WriteLine(">>> " + (i + 1) + ") ---> " + lista[i]);
                i++;
            }
            return i;
        }

        private void resultado()
        {
            Console.Clear();
            Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
            Console.WriteLine("***** Datos del cliente y su operación bancaria *****");
            Console.WriteLine("Cliente:\t\t\t"+nombre+" "+primerApellido+" "+segundoApellido);
            Console.WriteLine("Monto de ahorro e inversión:\t" + montoInversion+" "+nombreMoneda);
            Console.WriteLine("Plazo de la inversión en días:\t" + plazoDias+" días");
            Console.WriteLine("Sistema de ahorro e inversión:\t" + nombreServicio);
            Console.WriteLine("Interés anual correspondiente:\t");
            Console.WriteLine("\n***Rendimiento***");
            if (nombreServicio == "Inversión Vista Pactada")
            {
                Console.WriteLine("Plazo en días\tMonto de ahorro e inversión\tIntereses ganados\tImpuesto de Renta\tSaldo Final");
                Console.WriteLine("\t" + plazoDias + "\t\t" + montoInversion + " " + nombreMoneda + "\t\t  " + "8100" + " " + nombreMoneda + "\t\t  " + "9999"+" "+nombreMoneda+ "\t\t  " + "565656");
            }
            else
            {
                Console.WriteLine("Plazo en días\tMonto de ahorro e inversión\tIntereses ganados\tSaldo Final");
                Console.WriteLine("\t" + plazoDias + "\t\t" + montoInversion + " " + nombreMoneda + "\t\t  " + "8100" + " " + nombreMoneda + "\t\t  " + "999999");
            }
            Console.WriteLine("--->Última línea<---");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                VistaConsola consola = new VistaConsola();
                NativeMethods.AllocConsole();
                Console.WriteLine("***** Sistema de Inversión y Ahorro *****\n");
                consola.ingresarNombreCliente();
                consola.ingresarServicio();
                consola.ingresarMoneda(consola.nombreServicio);
                consola.ingresarPlazo();
                consola.ingresarInversion();
                //enviardatosalDTO
                //consola.resultado(DTOInversion) al final Consola.run();
                consola.resultado();
                Console.ReadLine();
            }
        }
    }
}