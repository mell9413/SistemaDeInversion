using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaDeInversion.Modelo;
namespace SistemaDeInversion
{
    interface ILector:IData
    {
        ArrayList getTablaInteres();
    }
}
