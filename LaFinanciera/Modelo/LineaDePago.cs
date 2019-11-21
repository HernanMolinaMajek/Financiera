using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public class LineaDePago
    {
        private double montoApagar;
        
        public LineaDePago(double montoApagar)
        {
            this.montoApagar = montoApagar;
        }
        public LineaDePago() { }






        public double MontoApagar { get => montoApagar; set => montoApagar = value; }

    }
}
