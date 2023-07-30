using AppInven.Controlador;
using System.Windows.Forms;


namespace AppInven
{
    public partial class formMenu : Form
    {
       
        public formMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MenuControlador menuControlador = new MenuControlador(this);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}