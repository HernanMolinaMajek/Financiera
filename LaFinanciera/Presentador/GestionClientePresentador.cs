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
    public class GestionClientePresentador
    {
        private IGestionCliente vista;

        public GestionClientePresentador(IGestionCliente vista)
        {
            this.vista = vista;
        }

        public void buscarCliente(string dni)
        {
            this.vista.Cliente = BaseDatos.Clientes.FirstOrDefault(x => x.Dni == dni);
        }

        public void guardarCliente()
        {
            Cliente c = BaseDatos.Clientes.FirstOrDefault(x => x.Dni == this.vista.Cliente.Dni);
            if (c == null)
                BaseDatos.Clientes.Add(this.vista.Cliente);
            else
            {
                BaseDatos.Clientes.Remove(c);
                BaseDatos.Clientes.Add(this.vista.Cliente);
            }
        }

        public void borrarCliente()
        {
            
            Cliente c = BaseDatos.Clientes.FirstOrDefault(x => x.Dni == this.vista.Cliente.Dni);
            BaseDatos.Clientes.Remove(c);
              //  this.vista.Cliente = null;
        }

        public bool altaCliente()
        {
            Cliente c = BaseDatos.Clientes.FirstOrDefault(x => x.Dni == this.vista.Cliente.Dni);
            if (c == null)
            {
                BaseDatos.Clientes.Add(this.vista.Cliente);
                return true;
            }
            return false;
        }
    }
}
