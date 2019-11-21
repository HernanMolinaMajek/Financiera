using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.Modelo;

namespace LaFinanciera.Vista.Interfaces
{
    public interface ISolicitudCredito
    {
        Cliente cliente { get; set; }
        List<Plan> planes { set; }
        Plan planSeleccionado { get; }
        Credito credito { get; set; }
        double montoSolicitado { get; }
        double montoPrestado { set; }
        double montoFinanciado { set; }
        
        

    }
}
