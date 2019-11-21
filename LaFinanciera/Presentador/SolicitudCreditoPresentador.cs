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
    public class SolicitudCreditoPresentador
    {
        private ISolicitudCredito vista;

        public SolicitudCreditoPresentador(ISolicitudCredito vista)
        {
            this.vista = vista;
            
        }

        public bool buscarCliente(string dni)
        {

            Cliente c = BaseDatos.Clientes.FirstOrDefault(x => x.Dni == dni);
            if (c != null)
            {
                //c.presentaDeudas();
                //c.presentaCreditosActivos();
                this.vista.cliente = c;
                return true;
            }
            return false;
            

        }

        public void recuperarPlanes()
        {
            this.vista.planes = BaseDatos.Planes;
        }

        public bool verificarMonto(double montoSolicitado)
        {
            if (montoSolicitado <= Financiera.Instancia.MontoMaximo)
            {
                return true;
            }
            else
                return false;
        }

        public void generarCredito()
        {
            int numIdCreditoSiguente = BaseDatos.Creditos.Count + 1;
            Empleado empleado = BaseDatos.sesion;
            Credito c = new Credito(numIdCreditoSiguente,this.vista.montoSolicitado,this.vista.planSeleccionado,empleado,this.vista.cliente);
            this.vista.credito = c;
        }

        public bool otorgarCredito()
        {
            //if (this.vista.credito.informarCreditoOtorgado())
            //{
                this.vista.cliente.agregarCredito(this.vista.credito);


                BaseDatos.Creditos.Add(this.vista.credito);
                BaseDatos.Clientes.Add(this.vista.cliente);

                Vista.ReciboCredito frm = new Vista.ReciboCredito(this.vista.credito);
                frm.Show();

            //if (this.vista.planSeleccionado.GetType() == typeof(PlanAdelantada))
            //{
            //    Vista.PagoCuotaAdelatada frmPago = new Vista.PagoCuotaAdelatada(this.vista.credito);
            //    frmPago.Show();
            //}
            // return true;
            //}
            //else
            //{
            //    this.vista.cliente.agregarCredito(this.vista.credito);


            //    BaseDatos.Creditos.Add(this.vista.credito);
            //    BaseDatos.Clientes.Add(this.vista.cliente);
            //    return false;
            //}
            return true;
            
        }
    }
}
