using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.ServiciosTecnicos.Persistencia;
using LaFinanciera.Modelo;

namespace LaFinanciera.Modelo
{
    public class Cuota
    {
        private int numero;
        private bool pagada;
        private double monto;
        private DateTime vencimiento;


        private bool estaVencida;
        private int diasVencida;
        private double recargo;
        private double gastosAdministrativosAlaFecha;

        private double aPagar;
        private List<LineaDePago> lineaDePago;


        public Cuota(int num, double monto, DateTime fechaDelCredito)
        {
            this.lineaDePago = new List<LineaDePago>();

            this.numero = num;
            this.monto = Math.Round(monto,2);
            this.aPagar = Math.Round(monto,2);
            this.pagada = false;

            this.estaVencida = false;
            this.diasVencida = 0;
            this.recargo = 0;
            this.gastosAdministrativosAlaFecha = Financiera.Instancia.GastosAdministrativos;

            fechaDelCredito = fechaDelCredito.AddMonths(num);
            this.vencimiento = new DateTime(fechaDelCredito.Year, fechaDelCredito.Month, Financiera.Instancia.FechaVencimietoCuotas);


        }
        public Cuota() { }

        public void calcularDiasVencida(DateTime fechaActual)
        {
            if (!this.pagada)
            {
                this.diasVencida = fechaActual.Subtract(this.vencimiento).Days;
                if (this.diasVencida > 0)
                {
                    this.estaVencida = true;
                    calcularRecargo();
                }
                else
                    this.estaVencida = false;
            }


        }

        private void calcularRecargo()
        {
            if (!this.pagada)
            {
                if (this.estaVencida)
                {
                    this.recargo = (this.monto * (Financiera.Instancia.RecargoPorVencimiento)/100) * this.diasVencida;
                    this.aPagar = monto + this.recargo;
                }
            }

        }

        public void pagar(double monto)
        {
            this.lineaDePago.Add(new LineaDePago(monto));

            foreach (var pago in this.lineaDePago)
            {

            }
            if (aPagar == 0)
            {
                this.pagada = true;
            }
            

        }
        

        public int Numero { get => numero; set => numero = value; }
        public bool Pagada { get => pagada; set => pagada = value; }
        public double Monto { get => monto; set => monto = value; }
        public DateTime Vencimiento { get => vencimiento; set => vencimiento = value; }
        public bool EstaVencida { get => estaVencida; set => estaVencida = value; }
        public int DiasVencida { get => diasVencida; set => diasVencida = value; }
        public double Recargo { get => recargo; set => recargo = value; }
        public double APagar { get => aPagar; set => aPagar = value; }
        public double GastosAdministrativosAlaFecha { get => gastosAdministrativosAlaFecha; set => gastosAdministrativosAlaFecha = value; }
        public List<LineaDePago> LineaDePago { get => lineaDePago; set => lineaDePago = value; }
    }
}
