using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public abstract class Plan
    {
        protected int id;
        protected string descripcion;
        protected int numeroCuotas;
        protected double porcentajeMensual;

        protected Plan(int id, int numeroCuotas, double porcentajeMensual)
        {
            this.id = id;
            
            this.numeroCuotas = numeroCuotas;
            this.porcentajeMensual = porcentajeMensual;
        }


        public abstract double calcularMontoAprestar(double mSolicitado);


        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int NumeroCuotas { get => numeroCuotas; set => numeroCuotas = value; }
        public double PorcentajeMensual { get => porcentajeMensual; set => porcentajeMensual = value; }

        



    }
}
