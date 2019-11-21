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
    public partial class SolicitudCredito : Form,ISolicitudCredito
    {
        private SolicitudCreditoPresentador presentador;
        private Cliente _cliente;
        private List<Plan> _planes;
        private Plan _planSeleccionado;
        private double _montoSolicitado;
        private Credito _credito;

        public SolicitudCredito()
        {
            InitializeComponent();
            this.presentador = new SolicitudCreditoPresentador(this);

            this.presentador.recuperarPlanes();
            this.button3.Enabled = false; 
        }

        public Cliente cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                this._cliente = value;
                if (_cliente != null)
                {
                    this.textBox2.Text = _cliente.Apellido + " " + _cliente.Nombre;
                    this.button3.Enabled = true;
                   // ServiciosTecnicos.SOAP.ResultadoEstadoCliente result = _cliente.presentaDeudas();
                    
                    //if (result.ConsultaValida)
                    //{
                    //    if (_cliente.presentaDeudas().TieneDeudas)
                    //    {
                    //        MessageBox.Show("Cliente presenta deudas");
                    //        this.button3.Enabled = false;
                    //    }
                    //    if (_cliente.presentaCreditosActivos().CantidadCreditosActivos >= 3)
                    //    {
                    //        MessageBox.Show("Cliente supera numero de creditos activos");
                    //       this.button3.Enabled = false;
                    //    }
                    //}
                    //else
                    //{
                    //    this.button3.Enabled = false;
                    //    MessageBox.Show(result.Error);
                    //}
                    
                }
                else
                { MessageBox.Show("Cliente Inexistente en sistema"); }
            }
        }
        public List<Plan> planes
        {
            set
            {
                _planes = value;
                this.comboBox1.DataSource = _planes;
                this.comboBox1.DisplayMember = "descripcion";
            }
        }

        public Plan planSeleccionado { get { return _planSeleccionado; } }

        public Credito credito
        {
            get { return _credito; }
            set
            {
                _credito = value;
                this.dataGridView1.DataSource = _credito.Cuotas;
                this.textBox3.Text = Convert.ToString(_credito.MontoOtorgado);
                this.textBox6.Text = Convert.ToString(_credito.MontoCredito);
            }
        }

        public double montoSolicitado
        {
            get
            {
                if (this.textBox5.Text == "")
                    return 0;
                else
                {

                    //_montoSolicitado = Convert.ToDouble(this.textBox5.Text);
                    if (this.presentador.verificarMonto(Convert.ToDouble(this.textBox5.Text)))
                        _montoSolicitado = Convert.ToDouble(this.textBox5.Text);
                    else
                    {
                        this.textBox5.Clear();
                        _montoSolicitado = 0;
                        MessageBox.Show("El monto maximo es 100000");
                    }

                }
                return _montoSolicitado;
            }
        }

        public double montoPrestado { set => throw new NotImplementedException(); }
        public double montoFinanciado { set => throw new NotImplementedException(); }



        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.presentador.buscarCliente(this.textBox1.Text))
            {
                MessageBox.Show("Cliente inexistente en sistema");
            }

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null) return;
               _planSeleccionado = (Plan)this.comboBox1.SelectedItem;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.presentador.generarCredito();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.presentador.otorgarCredito())
            {
                MessageBox.Show("Credito activo");
                

            }
            else
                MessageBox.Show("Credito Pendiente");

            this.Close();
        }
    }
}
