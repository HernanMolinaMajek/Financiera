using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public class PlanVencida : Plan
    {
        private double porcentajeGastos;

        public PlanVencida(int id, int numeroCuotas, double porcentajeMensual,double porcentajeGastos) : base(id, numeroCuotas, porcentajeMensual)
        {
            this.porcentajeGastos = porcentajeGastos;
            this.descripcion = id + ")  " + numeroCuotas + " Cuotas" + " / " + this.porcentajeMensual + " % Interes -Cuota Vencida-";
        }


       

        public override double calcularMontoAprestar(double mSolicitado)
        {
            return mSolicitado - ((porcentajeGastos / 100) * mSolicitado);
        }

        public double PorcentajeGastos { get => porcentajeGastos; set => porcentajeGastos = value; }

       
    }
}
