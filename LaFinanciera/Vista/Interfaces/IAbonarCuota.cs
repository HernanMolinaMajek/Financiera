using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.Modelo;

namespace LaFinanciera.Vista.Interfaces
{
    public interface IAbonarCuota
    {
        List<Credito> creditosActivos { get; set; }
        Cliente cliente { set; get; }
        List<Cuota> cuotasSeleccionadas { get; }
        List<Cuota> cuotas { get; }
        double total { set; }
        double vuelto { set; }
       
    }
}
