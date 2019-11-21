using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFinanciera.Modelo
{
    public class Financiera
    {
        private static Financiera instancia = null;
        private string nombreComercial;
        private string razonSocial;
        private string domicilio;
        private string cuit;
        private int cantidadCreditosActivosMaximoEnFinanciera;
        private double gastosAdministrativos;
        private int fechaVencimietoCuotas;
        private double recargoPorVencimiento;
        private double montoMaximo;
        private string codigoFinanciera;

        private Financiera()
        { }

        public static Financiera Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Financiera();
                   
                    return instancia;
                }
                return instancia;
            }
           

        }

      


        public string NombreComercial { get => nombreComercial; set => nombreComercial = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public int CantidadCreditosActivosMaximoEnFinanciera { get => cantidadCreditosActivosMaximoEnFinanciera; set => cantidadCreditosActivosMaximoEnFinanciera = value; }
        public double GastosAdministrativos { get => gastosAdministrativos; set => gastosAdministrativos = value; }
        public int FechaVencimietoCuotas { get => fechaVencimietoCuotas; set => fechaVencimietoCuotas = value; }
        public double RecargoPorVencimiento { get => recargoPorVencimiento; set => recargoPorVencimiento = value; }
        public double MontoMaximo { get => montoMaximo; set => montoMaximo = value; }
        public string CodigoFinanciera { get => codigoFinanciera; set => codigoFinanciera = value; }
    }
}
