using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public class Pago
    {
        private DateTime fecha;
        private Empleado empleado;
        private Cliente cliente;
        private List<LineaDePago> lineaDePago;
        private double monto;
        private double vuelto;

        public Pago(DateTime fecha, Empleado empleado,Cliente cliente)
        {
            this.cliente = cliente;
            this.fecha = fecha;
            this.empleado = empleado;
            this.lineaDePago = new List<LineaDePago>();
        }

        public double calcularMontoTotal()
        {
            double total = 0;
            foreach (LineaDePago lp in this.lineaDePago)
            {
                total += lp.MontoApagar;
            }
            this.monto = total;
            return total;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Empleado Empleado { get => empleado; set => empleado = value; }
        public List<LineaDePago> LineaDePago { get => lineaDePago; set => lineaDePago = value; }
        public double Monto { get => monto; set => monto = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public double Vuelto { get => vuelto; set => vuelto = value; }
    }
}
