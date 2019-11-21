using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.ServiciosTecnicos.Persistencia;
using LaFinanciera.ServiciosTecnicos.SOAP;


namespace LaFinanciera.Modelo
{
    public class Cliente
    {
        private string dni;
        private string nombre;
        private string apellido;
        private string domicilio;
        private string telefono;
        private double sueldo;
        private List<Credito> creditos;



        public Cliente(string dni, string nombre, string apellido, string domicilio, string telefono, double sueldo)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.sueldo = sueldo;

            this.creditos = new List<Credito>();
        }

        public Cliente()
        {
            this.creditos = new List<Credito>();
        }

        public void verificarVencimientos()
        {
            foreach (var credito in creditos.FindAll(x => x.EstadoDelCredito == Credito.Estado.Activo || x.EstadoDelCredito == Credito.Estado.Moroso))
            {
                foreach (var cuota in credito.Cuotas)
                {
                    cuota.calcularDiasVencida(DateTime.Now);
                }
            }
        }

        


        public bool agregarCredito(Credito c)
        {
           
               this.creditos.Add(c);
               return true;
          
        }

        //public ResultadoEstadoCliente presentaDeudas()
        //{

        //    ResultadoEstadoCliente result = new ResultadoEstadoCliente();
        //    Servicio s = new Servicio();
        //    result = s.obtenerEstadoCliente(Financiera.Instancia.CodigoFinanciera, Convert.ToInt32(this.dni));

        //    int cantCuotasAdeudadasTotales = 0;
        //    bool deudasExternas = result.TieneDeudas;
        //    foreach (var credito in this.creditos)
        //    {
              
        //        foreach (var cuota in credito.Cuotas)
        //        {
        //            if (cuota.EstaVencida)
        //            {
                        
        //                cantCuotasAdeudadasTotales++;
        //            }
                    
                    
        //        }
                
        //    }

        //    return result;
        //    //if (deudasExternas || cantCuotasAdeudadasTotales >= 2)
        //     //   return true;
        //    //else
        //     //   return false;
        //}

        public void verificarDeudas()
        {
            foreach (var credito in this.creditos)
            {
                int cantCuotasAdudadasDelCredito = 0;
                foreach (var cuota in credito.Cuotas)
                {
                    if (cuota.EstaVencida)
                        cantCuotasAdudadasDelCredito++;
                }
                if (cantCuotasAdudadasDelCredito >= 2)
                    credito.EstadoDelCredito = Credito.Estado.Moroso;

            }
        }


        //public ResultadoEstadoCliente presentaCreditosActivos()
        //{
        //    int creditosActivosMaximosEnFinanciera = Financiera.Instancia.CantidadCreditosActivosMaximoEnFinanciera;
        //    int creditosActivosMaximosFuera = 3;
        //    int creditosActivos =  this.creditos.FindAll(x => x.EstadoDelCredito == Credito.Estado.Activo).Count;

        //    ResultadoEstadoCliente result = new ResultadoEstadoCliente();
        //    Servicio s = new Servicio();
        //    result = s.obtenerEstadoCliente(Financiera.Instancia.CodigoFinanciera, Convert.ToInt32(this.dni));

        //    int creditosActivosFuera = result.CantidadCreditosActivos;

        //    return result;
        //    //if (creditosActivos >= creditosActivosMaximosEnFinanciera || creditosActivosFuera >= creditosActivosMaximosFuera)
        //     //   return true;
        //    //else
        //     //   return false;
        //}





        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public List<Credito> Creditos { get => creditos; set => creditos = value; }

    }
}
