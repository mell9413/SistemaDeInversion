﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeInversion.Modelo;

namespace SistemaDeInversion.Modelo
{
    interface IEscritor:IData
    {
        void crearArchivo();
        void escribirMovimiento();
        String asignarRuta();
    }
}
