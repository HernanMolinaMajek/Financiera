using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinanciera.Modelo;

namespace LaFinanciera.ServiciosTecnicos.Persistencia
{
    public class BaseDatos
    {
        public static List<Empleado> Empleados = new List<Empleado>();
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Credito> Creditos = new List<Credito>();
        
        public static List<Plan> Planes = new List<Plan>();

        
        public static Empleado sesion = null;

        public BaseDatos()
        {
            poblarDb();
        }

        private void poblarDb()
        {

            Financiera.Instancia.MontoMaximo = 100000;
            Financiera.Instancia.CantidadCreditosActivosMaximoEnFinanciera = 3;
            Financiera.Instancia.GastosAdministrativos = 2;
            Financiera.Instancia.FechaVencimietoCuotas = 10;
            Financiera.Instancia.RecargoPorVencimiento = 5;
            Financiera.Instancia.CodigoFinanciera = "70aa6d7c-2c8b-45b1-9b09-9799c50374d8";


            Financiera.Instancia.RazonSocial = "La Financiera";
            Financiera.Instancia.NombreComercial = "La Financiera";
            Financiera.Instancia.Cuit = "30-47362558927-8";

            
            Empleado e1 = new Empleado("11111", "nombre1", "apellido1", "usuario1", "111");
            Empleado e2 = new Empleado("22222", "nombre2", "apellido2", "usuario2", "222");
            Empleado e3 = new Empleado("33333", "nombre3", "apellido3", "usuario3", "333");
            Empleado e4 = new Empleado(null, "admnistrador", "administrador", "admin", "123456");
            Empleados.Add(e1);
            Empleados.Add(e2);
            Empleados.Add(e3);
            Empleados.Add(e4);

            sesion = e1;

            Plan p1 = new PlanAdelantada(1, 3, 5);
            Plan p2 = new PlanVencida(2, 3, 5, 2);
            Plan p3 = new PlanAdelantada(3, 7, 7);
            Plan p4 = new PlanVencida(4, 7, 7,2);
            Planes.Add(p1);
            Planes.Add(p2);
            Planes.Add(p3);
            Planes.Add(p4);

            Cliente c1 = new Cliente("1111", "nombre1", "apellido1", "domicilio1", "3871-235325", 15000);
            Cliente c2 = new Cliente("2222", "nombre2", "apellido2", "domicilio2", "3871-234375", 20000);
            Cliente c3 = new Cliente("3333", "nombre3", "apellido3", "domicilio3", "3871-235625", 44000);


            Credito cre1 = new Credito(1, 10000, p2, e1, c1);
            cre1.EstadoDelCredito = Credito.Estado.Activo;
            Credito cre2 = new Credito(2, 5000, p3, e3, c1);
            cre2.EstadoDelCredito = Credito.Estado.Activo;
            Credito cre3 = new Credito(3, 25000, p4, e2, c2);
            cre3.EstadoDelCredito = Credito.Estado.Activo;
            Credito cre4 = new Credito(4, 50000, p1, e1, c3);
            Credito cre5 = new Credito(5, 70000, p3, e3, c3);
            cre4.EstadoDelCredito = Credito.Estado.Activo;
            cre5.EstadoDelCredito = Credito.Estado.Activo;

            c1.agregarCredito(cre1);
            c1.agregarCredito(cre2);

            c2.agregarCredito(cre3);

            c3.agregarCredito(cre4);
            c3.agregarCredito(cre5);

            Clientes.Add(c1);
            Clientes.Add(c2);
            Clientes.Add(c3);




        }
    }
}
