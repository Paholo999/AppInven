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
    public partial class formAgregarStock : Form
    {
        public formAgregarStock()
        {
            InitializeComponent();
        }

        private void formAgregarStock_Load(object sender, EventArgs e)
        {
            AgregarStockControlador agregarStockControlador = new AgregarStockControlador(this);
        }
    }
}
