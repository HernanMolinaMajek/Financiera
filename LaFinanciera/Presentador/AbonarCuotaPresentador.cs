using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.Vista.Interfaces;
using LaFinanciera.ServiciosTecnicos.Persistencia;
using LaFinanciera.Modelo;

namespace LaFinanciera.Presentador
{
    public class AbonarCuotaPresentador
    {
        private IAbonarCuota vista;

        public AbonarCuotaPresentador(IAbonarCuota vista)
        {
            this.vista = vista;
        }

        public void buscarCliente(string dni)
        {
            this.vista.cliente = BaseDatos.Clientes.FirstOrDefault(x => x.Dni == dni);
            this.vista.cliente.verificarDeudas();
            this.vista.cliente.verificarVencimientos();
            //foreach (var credito in this.vista.cliente.Creditos.FindAll(x=>x.EstadoDelCredito==Credito.Estado.Activo || x.EstadoDelCredito==Credito.Estado.Moroso))
            //{
            //    foreach (var cuota in credito.Cuotas)
            //    {
            //        cuota.calcularDiasVencida(DateTime.Now);
            //    }
            //} 


        }

        public double calcularCuotasSeleccionadas()
        {
            double total = 0;

            foreach (Cuota c in this.vista.cuotasSeleccionadas)
            {
                total += c.APagar;
            }
            this.vista.total = total;
            return total;
        }

        public void confirmarPago(double montoApagar,bool sinSeleccionar)
        {
            List<Cuota> cuotasSeleccionadas = new List<Cuota>();
            Pago pago = new Pago(DateTime.Now, BaseDatos.sesion, this.vista.cliente);

            if (sinSeleccionar == false)
            {
                cuotasSeleccionadas = this.vista.cuotasSeleccionadas;
                double vuelto = montoApagar - calcularCuotasSeleccionadas();
                if (vuelto >= 0)
                {
                    this.vista.vuelto = vuelto;
                    foreach (Cuota c in cuotasSeleccionadas)
                    {
                        pago.LineaDePago.Add(new LineaDePago(c.APagar));
                        c.APagar = 0;
                        c.pagar(c.APagar);
                       
                    }
                    pago.Vuelto = vuelto;
                    this.vista.vuelto = vuelto;
                }
                else
                    this.vista.vuelto = 0; ;
            }
            else
            {
                double saldo = montoApagar;
                List<Cuota> cuotasImpagas = this.vista.cuotas.FindAll(x => x.Pagada != true);
                int cantidadDeCuotasImpagas = cuotasImpagas.Count; 

                    foreach (Cuota c in cuotasImpagas)
                    {
                        double sum = 0;
                        foreach (LineaDePago lp in c.LineaDePago)
                            sum += lp.MontoApagar;
                        if (sum == 0 && saldo >= c.Monto)
                        {
                            cuotasSeleccionadas.Add(c);
                            pago.LineaDePago.Add(new LineaDePago(c.Monto));
                            c.APagar = 0;
                            c.pagar(c.Monto);
                            saldo = saldo - c.Monto;
                            if (cantidadDeCuotasImpagas > 0)
                            {
                                cantidadDeCuotasImpagas--;
                                if(cantidadDeCuotasImpagas == 0)
                                this.vista.vuelto = saldo - c.APagar;
                                pago.Vuelto = saldo-c.APagar;
                        }
                        continue;
                        }
                        else
                        {
                            c.APagar = c.Monto - sum;
                            if (saldo > c.APagar)
                            {
                            //c.LineaDePago.Add(new LineaDePago(c.APagar));

                            //c.Pagada = true;
                            cuotasSeleccionadas.Add(c);
                            pago.LineaDePago.Add(new LineaDePago(c.APagar));
                                saldo = montoApagar - c.APagar;
                                c.APagar = 0;
                                c.pagar(c.APagar);
                                
                                if (cantidadDeCuotasImpagas > 0)
                                {
                                     cantidadDeCuotasImpagas--;
                                    if (cantidadDeCuotasImpagas == 0)
                                    this.vista.vuelto = saldo - c.APagar;
                                    pago.Vuelto = saldo - c.APagar;
                            }
                            continue;
                            }
                            else
                            {
                            cuotasSeleccionadas.Add(c);
                            //c.LineaDePago.Add(new LineaDePago(saldo));
                            pago.LineaDePago.Add(new LineaDePago(saldo));
                                c.APagar = c.APagar - saldo;
                                c.pagar(saldo);
                                saldo = 0;
                                pago.Vuelto = 0;
                                break;
                            }

                        }
                    }
                    
               
            }

            foreach (Credito credito in this.vista.creditosActivos)
            {
                if (credito.EstadoDelCredito == Credito.Estado.Activo)
                {
                    int numcuotas = credito.Plan.NumeroCuotas;
                    if (credito.Cuotas.Count(x => x.Pagada == true) == numcuotas)
                        credito.informarCreditoFinalizado();
                }
            }

            Vista.ReciboPago frm = new Vista.ReciboPago(cuotasSeleccionadas, pago);
            frm.Show();
        }
    }
}
