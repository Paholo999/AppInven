using AppInven.Modelo.dao;
using AppInven.Modelo.dto;
using AppInven.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInven.Controlador
{
    internal class AgregarStockControlador
    {
        formAgregarStock formAgregarStock;
        DataTable dt = new DataTable();
        ProductoDAO productoDAO = new ProductoDAO();
        Producto producto = new Producto();


        public AgregarStockControlador(formAgregarStock frmAgregarStock) 
        {
            formAgregarStock = frmAgregarStock;

            formAgregarStock.btnBuscar.Click += new EventHandler(Buscar);
            formAgregarStock.btnIngresarStock.Click += new EventHandler(IngresarStock);


        }

        private void Buscar(object sender, EventArgs e)
        {
           dt = productoDAO.Obtener(formAgregarStock.txtCodigoBuscar.Text);

           foreach (DataRow dr in dt.Rows)
           {
                formAgregarStock.txtCodigo.Text = dr["Codigo"].ToString();
                formAgregarStock.txtDescripcion.Text = dr["Descripcion"].ToString();
                formAgregarStock.txtStockActual.Text = dr["Cantidad"].ToString();
                formAgregarStock.txtPrecio.Text = dr["Precio"].ToString();
           }

        }

        private void IngresarStock(object sender, EventArgs e)
        {
            int stockActual = 0;
            int stockAgregado = 0;
            int stockFinal = 0;

            dt = productoDAO.Obtener(formAgregarStock.txtCodigoBuscar.Text);

            foreach (DataRow dr in dt.Rows)
            {
               stockActual = Convert.ToInt16(dr["Cantidad"].ToString());
            }

            stockAgregado = Convert.ToInt16(formAgregarStock.txtIngresoStock.Text);

            stockFinal = stockActual + stockAgregado;

            producto.Codigo = formAgregarStock.txtCodigoBuscar.Text;
            producto.Cantidad = stockFinal;

            if (productoDAO.IngresarStock(producto) > 0)
            {
                MessageBox.Show("Datos guardados.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}
