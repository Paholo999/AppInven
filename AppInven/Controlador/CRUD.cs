using AppInven.Modelo.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInven.Controlador
{
    public class CRUD
    {
        public static void Main()
        {
            MenuControlador menuControlador = new MenuControlador();
            menuControlador.btnGuardarMenu += botonGuardar;

        }
        private static void botonGuardar(object sender, formMenu formMenu)
        {
            try
            {
                Producto producto = new Producto();

                producto.Codigo = formMenu.txtCodigo.Text;

                /*ProductoDAO productoDAO = new ProductoDAO();
                

                if (productoDAO.Grabar(producto) > 0)
                {
                    MessageBox.Show("Datos grabados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se grabaron los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                MessageBox.Show("Click y " + formMenu.txtCodigo.Text);

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.ToString());
            }


        }
    }
}
