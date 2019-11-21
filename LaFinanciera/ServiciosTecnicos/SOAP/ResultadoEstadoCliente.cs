using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.ServiciosTecnicos.SOAP
{
    public class ResultadoEstadoCliente
    {
        private bool tieneDeudas;
        private string error;
        private int cantidadCreditosActivos;
        private bool consultaValida;

        public ResultadoEstadoCliente(bool tieneDeudas, int cantidadCreditosActivos, bool consultaValida, string error)
        {
            this.tieneDeudas = tieneDeudas;
            this.error = error;
            this.cantidadCreditosActivos = cantidadCreditosActivos;
            this.consultaValida = consultaValida;
        }
        public ResultadoEstadoCliente()
        { }


        public bool TieneDeudas { get => tieneDeudas; set => tieneDeudas = value; }
        public string Error { get => error; set => error = value; }
        public int CantidadCreditosActivos { get => cantidadCreditosActivos; set => cantidadCreditosActivos = value; }
        public bool ConsultaValida { get => consultaValida; set => consultaValida = value; }
    }
    
}
