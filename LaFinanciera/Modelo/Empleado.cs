using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public class Empleado
    {
       

        private string legajo;
        private string nombre;
        private string apellido;
        private string usuario;
        private string password;
   

        public Empleado(string legajo, string nombre, string apellido, string usuario, string password)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.usuario = usuario;
            this.password = password;
           
        }
        public Empleado() { }

        public string Legajo { get => legajo; set => legajo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
       
    }
}
