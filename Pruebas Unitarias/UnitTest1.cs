using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaFinanciera.Modelo;

namespace Pruebas_Unitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificarCalculoDeMontoOtorgadoEnUnCreditoACuotaVencida()
        {
            Financiera.Instancia.FechaVencimietoCuotas = 10;
            Plan planCuotaVencida = new PlanVencida(2, 3, 5, 2);
            Empleado emp = new Empleado("11111", "nombre1", "apellido1", "usuario1", "111");
            Cliente cli = new Cliente("1111", "nombre1", "apellido1", "domicilio1", "3871-235325", 15000);
            double montoSolicitado = 10000;

            double resultadoEsperado = 9800;
            //---------------
            Credito cred = new Credito(1, montoSolicitado, planCuotaVencida, emp, cli);
            //---------------
            Assert.AreEqual(resultadoEsperado, cred.MontoOtorgado);
           
        }


        [TestMethod]
        public void VerificarCalculoDeMontoOtorgadoEnUnCreditoACuotaAdelantada()
        {
            Financiera.Instancia.FechaVencimietoCuotas = 10;
            Plan planCuotaAdelantada = new PlanAdelantada(2, 3, 5);
            Empleado emp = new Empleado("11111", "nombre1", "apellido1", "usuario1", "111");
            Cliente cli = new Cliente("1111", "nombre1", "apellido1", "domicilio1", "3871-235325", 15000);
            double montoSolicitado = 12000;

            double resultadoEsperado = 7400;
            //---------------
            Credito cred = new Credito(1, montoSolicitado, planCuotaAdelantada, emp, cli);
            //---------------
            Assert.AreEqual(resultadoEsperado, cred.MontoOtorgado);

        }


        [TestMethod]
        public void VerificarCalculoDelInteresEnUnCreditoACuotaAdelantadaCon5PoricentoDePorcentajeMensual()
        {
            Financiera.Instancia.FechaVencimietoCuotas = 10;
            Plan planCuotaAdelantada = new PlanAdelantada(2, 3, 5);
            Empleado emp = new Empleado("11111", "nombre1", "apellido1", "usuario1", "111");
            Cliente cli = new Cliente("1111", "nombre1", "apellido1", "domicilio1", "3871-235325", 15000);
            
            double resultadoEsperado = 0.15;
            //---------------
            Credito cred = new Credito(1, 1000, planCuotaAdelantada, emp, cli);
            //---------------
            Assert.AreEqual(resultadoEsperado, cred.Interes,0.1);

        }


        [TestMethod]
        public void VerificarLaComprobacionDeUnaCuotaVencida()
        {
            Financiera.Instancia.FechaVencimietoCuotas = 10;
            DateTime fechaCuota = new DateTime(2019, 8, 23);
            Cuota c1 = new Cuota(1, 5000, fechaCuota);

            DateTime fechaActual= new DateTime(2019, 9, 23);
            bool resultadoEsperado = true;
            //---------------
            c1.calcularDiasVencida(fechaActual);
            //---------------
            Assert.AreEqual(resultadoEsperado, c1.EstaVencida);
        }


        [TestMethod]
        public void VerificarCalculoDeRcargoDeUnaCuotaVencida()
        {
            Financiera.Instancia.FechaVencimietoCuotas = 10;
            Financiera.Instancia.RecargoPorVencimiento = 5;
            DateTime fechaCuota = new DateTime(2019, 8, 10);
            Cuota c1 = new Cuota(1, 5000, fechaCuota);
            DateTime fechaActual = new DateTime(2019, 9, 15); 

            double resultadoEsperado = 1250;
            //--------------
            c1.calcularDiasVencida(fechaActual);
            //--------------
            Assert.AreEqual(resultadoEsperado, c1.Recargo);
        }






    }
}
