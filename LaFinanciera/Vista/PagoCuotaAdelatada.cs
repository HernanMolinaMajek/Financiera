using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaFinanciera.Modelo;
using LaFinanciera.Vista.Interfaces;
using LaFinanciera.Presentador;

namespace LaFinanciera.Vista
{
    public partial class PagoCuotaAdelatada : Form,IPagoCuotaAdelantada
    {
        private PagoCuotaAdelantadaPresentador presentador;
        private Credito _credito;

        public PagoCuotaAdelatada(Credito credito)
        {
            InitializeComponent();
            this.presentador = new PagoCuotaAdelantadaPresentador(this);
            this._credito = credito;
            this.dataGridView1.DataSource = _credito.Cuotas;
        }

        public Credito credito { get { return _credito; } set => throw new NotImplementedException(); }

        private void button1_Click(object sender, EventArgs e)
        {
            this.presentador.pagarPrimeraCuota(Convert.ToDouble(this.textBox1.Text));
            this.Close();
        }
    }
}
