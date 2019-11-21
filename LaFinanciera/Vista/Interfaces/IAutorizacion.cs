using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.Modelo;

namespace LaFinanciera.Vista.Interfaces
{
    public interface IAutorizacion
    {
        Empleado empleado { get; set; }
    }
}
