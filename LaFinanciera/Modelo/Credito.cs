using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.ServiciosTecnicos.SOAP;
using LaFinanciera.ServiciosTecnicos.Persistencia;

namespace LaFinanciera.Modelo
{
    public class Credito
    {
        public enum Estado { Pendiente, Activo, Finalizado, Moroso, PendienteFinalizacion }

        private int numeroId;
        private Estado estadoDelCredito;
        private DateTime fecha;
        private Empleado empleado;
        private Cliente cliente;

        private Plan plan;
        private double interes;
        private List<Cuota> cuotas;

        private double montoSolicitado;
        private double montoOtorgado;
        private double montoCredito;

       

        public Credito(int id,double mSolicitado, Plan plan, Empleado empleado, Cliente cliente)
        {
           
            this.numeroId = id;
            this.empleado = empleado;
            this.cliente = cliente;
            this.estadoDelCredito = Estado.Pendiente;
            this.fecha = DateTime.Now;
            this.plan = plan;
            this.montoSolicitado = mSolicitado;
            this.interes = calcularInteres();
            this.montoCredito = calcularMontoCredito();
            this.cuotas = new List<Cuota>();
            
            for (int i = 1; i <= plan.NumeroCuotas; i++)
                this.cuotas.Add(new Cuota(i, calcularMontoCuota(), DateTime.Now));
            
            this.montoOtorgado = Math.Round(calcularMontoOtorgado(), 2); 

            
        }

     


        public bool informarCreditoOtorgado()
        {

            ResultadoOperacion result = new ResultadoOperacion();
            Servicio s = new Servicio();
            result = s.InformarCreditoOtorgado(Financiera.Instancia.CodigoFinanciera, Convert.ToInt32(this.cliente.Dni), Convert.ToString(this.numeroId), this.montoOtorgado);

            
                if (result.OperacionValida)
                {
                    this.estadoDelCredito = Estado.Activo;
                    return true;
                }
                else
                {
                this.estadoDelCredito = Estado.Pendiente;
                return false;
                }
        }

        public void informarCreditoFinalizado()
        {
            
            ResultadoOperacion result = new ResultadoOperacion();
            Servicio s = new Servicio();
            result = s.InformarCreditoFinalizado(Financiera.Instancia.CodigoFinanciera, Convert.ToInt32(this.cliente.Dni), Convert.ToString(this.numeroId));
            if (result.OperacionValida)
                this.estadoDelCredito = Estado.Finalizado;
            else
                this.estadoDelCredito = Estado.PendienteFinalizacion;

        }

        private double calcularInteres()
        {
            return this.plan.NumeroCuotas * (this.plan.PorcentajeMensual / 100);
        }

        private double calcularMontoCredito()
        {
            return this.montoSolicitado + (this.montoSolicitado * this.interes);
        }

        private double calcularMontoCuota()
        {
            return this.montoCredito / this.plan.NumeroCuotas;
        }

        private double calcularMontoOtorgado()
        {
            double montoAOtorgar = this.plan.calcularMontoAprestar(this.montoSolicitado);
            if (montoAOtorgar == this.montoSolicitado)
            {
                this.cuotas.First().Pagada = true;
                this.cuotas.First().APagar = 0;
                return montoAOtorgar - calcularMontoCuota();
            }
            else
                return montoAOtorgar;
        }


        public int NumeroId { get => numeroId; set => numeroId = value; }
        public Estado EstadoDelCredito { get => estadoDelCredito; set => estadoDelCredito = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Empleado Empleado { get => empleado; set => empleado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Plan Plan { get => plan; set => plan = value; }
        public double Interes { get => interes; set => interes = value; }
        public List<Cuota> Cuotas { get => cuotas; set => cuotas = value; }
        public double MontoSolicitado { get => montoSolicitado; set => montoSolicitado = value; }
        public double MontoOtorgado { get => montoOtorgado; set => montoOtorgado = value; }
        public double MontoCredito { get => montoCredito; set => montoCredito = value; }

    }
}
