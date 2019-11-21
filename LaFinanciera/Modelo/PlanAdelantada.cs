using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public class PlanAdelantada : Plan
    {
        public PlanAdelantada(int id, int numeroCuotas, double porcentajeMensual) : base(id, numeroCuotas, porcentajeMensual)
        {
            this.descripcion = id + ")  " + numeroCuotas + " Cuotas" + " / " + this.porcentajeMensual + " % Interes -Cuota Adelantada-";
        }

        public override double calcularMontoAprestar(double mSolicitado)
        {
            return mSolicitado;
        }
    }
}
