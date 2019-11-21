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
    public partial class ReciboPago : Form
    {
        public ReciboPago(List<Cuota> cuotas,Pago p)
        {
            InitializeComponent();
            this.reportViewer1.RefreshReport();

            ReportParameterCollection parametros = new ReportParameterCollection();
            parametros.Add(new ReportParameter("cliente", p.Cliente.Apellido+" "+p.Cliente.Nombre));
            parametros.Add(new ReportParameter("empleado", p.Empleado.Nombre));
            parametros.Add(new ReportParameter("fecha", Convert.ToString(p.Fecha)));
            parametros.Add(new ReportParameter("vuelto", Convert.ToString("$ "+p.Vuelto)));
            parametros.Add(new ReportParameter("total", Convert.ToString("$ "+p.calcularMontoTotal())));

            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",cuotas));
            this.reportViewer1.LocalReport.SetParameters(parametros);
            //this.myData = GetDataSource();

            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Person", myData));

            this.reportViewer1.RefreshReport();
            this.Controls.Add(this.reportViewer1);
        }
    }
}
