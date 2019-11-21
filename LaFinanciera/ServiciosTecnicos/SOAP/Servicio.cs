using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.ServicioPublicoOnline;

namespace LaFinanciera.ServiciosTecnicos.SOAP
{
    public class Servicio
    {
        private ServicioPublicoCreditoClient servicio;


        public Servicio()
        {
            try
            {
                servicio = new ServicioPublicoCreditoClient();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public ResultadoEstadoCliente obtenerEstadoCliente(string codigoFinanciera, int dni)
        //{
        //    ServicioPublicoOnline.ResultadoEstadoCliente result = this.servicio.ObtenerEstadoCliente(codigoFinanciera, dni);
        //    ResultadoEstadoCliente estadoCliente = new ResultadoEstadoCliente(result.TieneDeudas, result.CantidadCreditosActivos, result.ConsultaValida, result.Error);
        //    return estadoCliente;

        //}

        public ResultadoOperacion InformarCreditoOtorgado(string codigoFinanciera, int dni, string identificadorCredito, double montoOtorgado)
        {
            ServicioPublicoOnline.ResultadoOperacion resutado = this.servicio.InformarCreditoOtorgado(codigoFinanciera, dni, identificadorCredito, montoOtorgado);
            ResultadoOperacion resultadoOperacion = new ResultadoOperacion(resutado.OperacionValida, resutado.Error);
            return resultadoOperacion;
        }

        public ResultadoOperacion InformarCreditoFinalizado(string codigoFinanciera, int dni, string identificadorCredito)
        {
            ServicioPublicoOnline.ResultadoOperacion resultado = this.servicio.InformarCreditoFinalizado(codigoFinanciera, dni, identificadorCredito);
            ResultadoOperacion resultadoOperacion = new ResultadoOperacion(resultado.OperacionValida, resultado.Error);
            return resultadoOperacion;
        }

    }
}
