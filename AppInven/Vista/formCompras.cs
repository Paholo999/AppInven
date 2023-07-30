using AppInven.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppInven.Vista
{
    public partial class formCompras : Form
    {
        public formCompras()
        {
            InitializeComponent();
        }

        private void formCompras_Load(object sender, EventArgs e)
        {
            ComprasControlador comprasControlador = new ComprasControlador(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }
    }
}
