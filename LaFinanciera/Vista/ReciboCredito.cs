using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using LaFinanciera.Modelo;

namespace LaFinanciera.Vista
{
    public partial class ReciboCredito : Form
    {
        public ReciboCredito(Credito c)
        {
            
            InitializeComponent();

            //reportViewer1.Reset();
            //reportViewer1.LocalReport.ReportPath = "C:\\Users\\Hernan\\Desktop\\Financiera\\Financiera3\\LaFinanciera\\LaFinanciera\\Credito.rdlc";

            this.reportViewer1.RefreshReport();

            
            
            ReportParameterCollection parametros = new ReportParameterCollection();
            parametros.Add(new ReportParameter("cliente",c.Cliente.Apellido+" "+c.Cliente.Nombre));
            parametros.Add(new ReportParameter("empleado", c.Empleado.Nombre));
            parametros.Add(new ReportParameter("idCredito",Convert.ToString(c.NumeroId)));
            parametros.Add(new ReportParameter("fecha",Convert.ToString(c.Fecha)));
            parametros.Add(new ReportParameter("descripcionPlan",c.Plan.Descripcion));
            parametros.Add(new ReportParameter("montoSolicitado",Convert.ToString(c.MontoSolicitado)));
            parametros.Add(new ReportParameter("montoOtorgado", Convert.ToString(c.MontoOtorgado)));
            parametros.Add(new ReportParameter("montoCredito", Convert.ToString(c.MontoCredito)));
            parametros.Add(new ReportParameter("montoCuota",Convert.ToString(c.Cuotas.First().Monto)));

            
            this.reportViewer1.LocalReport.SetParameters(parametros);
            //this.myData = GetDataSource();

            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Person", myData));

            this.reportViewer1.RefreshReport();
            this.Controls.Add(this.reportViewer1);
           
        }
    }
}
