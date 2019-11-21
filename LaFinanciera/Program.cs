using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaFinanciera.Modelo;
using LaFinanciera.ServiciosTecnicos.Persistencia;

namespace LaFinanciera
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BaseDatos bd = new BaseDatos();

            
            Application.Run(new LaFinanciera.Vista.Autorizacion());
        }
    }
}
