using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.ServiciosTecnicos.SOAP
{
    public class ResultadoOperacion
    {
        private bool operacionValida;
        private string error;

    
        public ResultadoOperacion(bool operacionValida, string error)
        {
            this.operacionValida = operacionValida;
            this.error = error;
        }
        public ResultadoOperacion()
        { }

        public bool OperacionValida { get => operacionValida; set => operacionValida = value; }
        public string Error { get => error; set => error = value; }
    }
}
