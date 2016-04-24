﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace SistemaDeInversion.Modelo.Factorys
{
    public class FactoryConcretoControlador : FactoryControlador
    {
        public override Controlador crearIControlador()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("SistemaDeInversion.Modelo.Controlador");
            MessageBox.Show(type.ToString());
            object[] args = {};
            Controlador claseConcreta = (Controlador)Activator.CreateInstance(type);
            return claseConcreta;
        }
    }
}
