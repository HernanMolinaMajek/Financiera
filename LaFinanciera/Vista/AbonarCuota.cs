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
using LaFinanciera.ServiciosTecnicos.Persistencia;
using LaFinanciera.Vista.Interfaces;
using LaFinanciera.Presentador;

namespace LaFinanciera.Vista
{
    public partial class AbonarCuota : Form,IAbonarCuota
    {
        private AbonarCuotaPresentador presentador;
        private List<Credito> _creditos;
        private List<Cuota> _cuotas;
        private Cliente _cliente;
        private List<Cuota> _cuotasSeleccionadas;
        private double _total;
        private double _vuelto;
        private bool sePagaSeleccionadas;

        public AbonarCuota()
        {
            InitializeComponent();
            this.presentador = new AbonarCuotaPresentador(this);
            _cuotasSeleccionadas = new List<Cuota>();
            this.textBox4.Enabled = false;
            this.button3.Enabled = false;
            sePagaSeleccionadas = true;
        }

        public List<Credito> creditosActivos
        {
            get { return _creditos; }
            set
            {
                this._creditos = value;
                _cuotas = new List<Cuota>();
                foreach (Credito credito in this._creditos.FindAll(x=>x.EstadoDelCredito==Credito.Estado.Activo || x.EstadoDelCredito==Credito.Estado.Moroso))
                    foreach (Cuota cu in credito.Cuotas)
                        _cuotas.Add(cu);
                this.dataGridView1.DataSource = _cuotas;
            }
                
        }

        public Cliente cliente { get { return _cliente; } set { _cliente = value; this.textBox2.Text = _cliente.Apellido + " " + _cliente.Nombre; } }

        public List<Cuota> cuotasSeleccionadas { get { return _cuotasSeleccionadas; } }

        public double total { set { _total = value;this.textBox3.Text = Convert.ToString(_total); } }

        public double vuelto { set { this._vuelto = value; this.textBox5.Text = Convert.ToString(_vuelto); } }

        public List<Cuota> cuotas { get { return _cuotas; } }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == false)
            {
                this.button3.Enabled = true;
                this.textBox4.Enabled = true;
                this._cuotasSeleccionadas.Clear();
                bool band = false;
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    Cuota c = (Cuota)row.DataBoundItem;
                    if (!c.Pagada)
                        _cuotasSeleccionadas.Add((Cuota)row.DataBoundItem);
                    else
                        band = true;
                }
                if (band)
                    MessageBox.Show("Se han omitido las cuotas pagadas");
                this.presentador.calcularCuotasSeleccionadas();
                
            }
        }
                
                    


        private void button1_Click(object sender, EventArgs e)
        {
            this.presentador.buscarCliente(this.textBox1.Text);
            this.creditosActivos = _cliente.Creditos.FindAll(x=>x.EstadoDelCredito==Credito.Estado.Activo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sePagaSeleccionadas)
            {
                if (Convert.ToDouble(this.textBox4.Text) >= this._total)
                {
                    this.presentador.confirmarPago(Convert.ToDouble(this.textBox4.Text), this.checkBox1.Checked);
                }
                else
                {
                    MessageBox.Show("Monto Insuficiente");
                    this.textBox4.Clear();
                }
            }
            else
                this.presentador.confirmarPago(Convert.ToDouble(this.textBox4.Text), this.checkBox1.Checked);

            this.dataGridView1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.button2.Enabled = false;
                this.button3.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox4.Clear();
                this.textBox3.Clear();
                this.sePagaSeleccionadas = false;
            }
            else
            {
                this.sePagaSeleccionadas = true;
                this.textBox3.Clear();
                this.button3.Enabled =false;
                this.textBox4.Clear();
                this.textBox4.Enabled = false;
                this.button2.Enabled = true;
            }
        }
    }
}
            
