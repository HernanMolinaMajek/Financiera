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
using LaFinanciera.Vista
    ;
namespace LaFinanciera.Vista
{
    public partial class Autorizacion : Form,IAutorizacion
    {
        private AutorizacionPresentador presentador;
        private Empleado _empleado;

        public Autorizacion()
        {
            InitializeComponent();
            this.presentador = new AutorizacionPresentador(this);
        }

        public Empleado empleado
        {
            get
            {
                _empleado = new Empleado();
                _empleado.Usuario = this.textBox1.Text;
                _empleado.Password = this.textBox2.Text;

                return _empleado;
            }
            set { _empleado = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             this.presentador.autenticar();

            if (_empleado != null)
            {

                PrincipalEmpleado frm = new PrincipalEmpleado();
                    frm.Show();
                
            }
            else
                MessageBox.Show("Usuario o Contraseña Incorrecto");
        }
    }
}
