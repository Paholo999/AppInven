using AppInven.Modelo.dao;
using AppInven.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInven.Controlador
{
    internal class MenuControlador
    {
        ProductoDAO productoDAO = new ProductoDAO();
        formMenu formMenu;

        public MenuControlador(formMenu frmMenu)
        {
            formMenu = frmMenu;

            formMenu.dataGridViewProducts.DataSource = productoDAO.Consultar();
            formMenu.nuevoProductoStockToolStripMenuItem.Click += new EventHandler(frmCompras);
            formMenu.agregarStockToolStripMenuItem1.Click += new EventHandler(frmAgregarStock);
            formMenu.salirToolStripMenuItem.Click += new EventHandler(Salir);

            
        }


        private void frmCompras(object sender, EventArgs e)
        {
            formCompras formCompras  = new formCompras();
            formCompras.Show();
        }

        private void frmAgregarStock(object sender, EventArgs e)
        {
            formAgregarStock formAgregarStock = new formAgregarStock();
            formAgregarStock.Show();
        }

        private void Salir(object sender, EventArgs e)
        {
            formMenu.Close();
        }

    }
}
