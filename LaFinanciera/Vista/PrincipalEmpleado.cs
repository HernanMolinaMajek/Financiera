using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaFinanciera.Vista;

namespace LaFinanciera.Vista
{
    public partial class PrincipalEmpleado : Form
    {
        public PrincipalEmpleado()
        {
            InitializeComponent();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionarClientes frm = new GestionarClientes();
            frm.Show();
        }

        private void solicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolicitudCredito frm = new SolicitudCredito();
            frm.Show();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbonarCuota frm = new AbonarCuota();
            frm.Show();
        }
    }
}
