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
    public partial class GestionarClientes : Form,IGestionCliente
    {
        private GestionClientePresentador presentador;
        private Cliente _cliente;
        private enum Accion { Modificacion,alta }
        private Accion accion;

        public GestionarClientes()
        {
            InitializeComponent();
            this.presentador = new GestionClientePresentador(this);
            this.button3.Enabled = false;
            this.button4.Visible = false;
            this.button3.Text = "-";

            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
        }

        public Cliente Cliente
        {
            get
            {
                
                this._cliente.Dni = this.textBox2.Text;
                this._cliente.Nombre = this.textBox4.Text;
                this._cliente.Apellido = this.textBox3.Text;
                this._cliente.Telefono = this.textBox6.Text;
                this._cliente.Sueldo = Convert.ToDouble(this.textBox7.Text);
                this._cliente.Domicilio = this.textBox5.Text;
                return _cliente;
            }
            set
            {
                _cliente = value;
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.presentador.buscarCliente(this.textBox1.Text);
            if (_cliente != null)
            {
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;

                this.textBox2.Text = this._cliente.Dni;
                this.textBox4.Text = this._cliente.Nombre;
                this.textBox3.Text = this._cliente.Apellido;
                this.textBox6.Text = this._cliente.Telefono;
                this.textBox7.Text = Convert.ToString(this._cliente.Sueldo);
                this.textBox5.Text = this._cliente.Domicilio;

                this.button2.Enabled = false;
                this.button3.Enabled = true;
                this.button4.Visible = true;
                this.button3.Text = "ModificarCliente";
                this.accion = Accion.Modificacion;
            }
            else
            {
                MessageBox.Show("Cliente Inexistente");
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox4.Clear();
                this.textBox3.Clear();
                this.textBox6.Clear();
                this.textBox7.Clear();
                this.textBox5.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button3.Text = "Alta Cliente";
            this.accion = Accion.alta;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
            this.textBox6.Enabled = true;
            this.textBox7.Enabled = true;
            this.button3.Enabled = true;
            this.textBox1.Enabled = false;
            _cliente = new Cliente();
            _cliente.Dni = this.textBox2.Text;
            _cliente.Nombre = this.textBox4.Text;
            _cliente.Apellido = this.textBox3.Text;
            _cliente.Domicilio = this.textBox5.Text;
            _cliente.Telefono = this.textBox6.Text;

            if (this.textBox6.Text == "")
                _cliente.Sueldo = 0;
            else
                _cliente.Sueldo = Convert.ToDouble(this.textBox7.Text);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (accion == Accion.alta)
            {
                if (this.presentador.altaCliente())
                {
                    MessageBox.Show("Cliente Creado con Exito");
                    textBox1.Enabled = true;
                    this.button1.Enabled = true;
                }
                else
                    MessageBox.Show("Cliente ya existe");
                this.resetearCampos();
            }
            else if (accion == Accion.Modificacion)
            {
                this.presentador.guardarCliente();
                MessageBox.Show("Cliente modificado");
                this.resetearCampos();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.presentador.borrarCliente();
            this.resetearCampos();

        }


        private void resetearCampos()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox4.Clear();
            this.textBox3.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox5.Clear();
            this.button4.Visible = false;
            this.button3.Text = "-";
            this.button2.Enabled = true;
            this.button3.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
        }
    }
}
