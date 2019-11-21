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
    class AutorizacionPresentador
    {
        private IAutorizacion vista;

        public AutorizacionPresentador(IAutorizacion vista)
        {
            this.vista = vista;
        }

        public void autenticar()
        {
            Empleado empleado = BaseDatos.Empleados.FirstOrDefault(e => e.Usuario == this.vista.empleado.Usuario && e.Password == this.vista.empleado.Password);

            if (empleado != null)
            {
                BaseDatos.sesion = empleado;
                this.vista.empleado = empleado;
            }
        }
    }
}
