﻿using SistemaDeInversion.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInversion.Modelo.Factorys
{
    public abstract class FactoryServicio
    {
        public abstract ServicioAhorroInversion crearServicioAhorroInversion(DTOServicioAhorroInversion dtoServicio);

    }
}
