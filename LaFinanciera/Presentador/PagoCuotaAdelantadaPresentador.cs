using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.Vista.Interfaces;
using LaFinanciera.Modelo;

namespace LaFinanciera.Presentador
{
    public class PagoCuotaAdelantadaPresentador
    {
        private IPagoCuotaAdelantada vista;

        public PagoCuotaAdelantadaPresentador(IPagoCuotaAdelantada vista)
        {
            this.vista = vista;
        }

        public void pagarPrimeraCuota(double montoAabonar)
        {
            Pago pago = new Pago(this.vista.credito.Fecha,this.vista.credito.Empleado, this.vista.credito.Cliente);
            pago.LineaDePago.Add(new LineaDePago(montoAabonar));
            pago.Vuelto = montoAabonar - this.vista.credito.Cuotas.First().Monto;
            List<Cuota> cuota = new List<Cuota>();
            cuota.Add(this.vista.credito.Cuotas.First());
            Vista.ReciboPago frm = new Vista.ReciboPago(cuota,pago);
            frm.Show();
        }
    }
}
