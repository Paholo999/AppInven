using AppInven.Modelo.dao;
using AppInven.Modelo.dto;
using AppInven.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AppInven.Controlador
{
    public class ComprasControlador
    {
        formCompras formCompras;
        DataTable dt = new DataTable();
        DateTime dateTime = DateTime.Now;
        ProductoDAO productoDAO = new ProductoDAO();
        Producto producto = new Producto();

        public ComprasControlador(formCompras frmCompras)
        {
            formCompras = frmCompras;


            formCompras.txtCodigo.Text = "SPD" + dateTime.ToString("yyyy") + dateTime.ToString("MM") + "-" + ConsultarID();
            formCompras.btnCrear.Click += new EventHandler(Crear);

        }

        private void Crear(object sender, EventArgs e)
        {           
            
            if(formCompras.txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar descripcion.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(formCompras.txtPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar precio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (formCompras.txtUnidades.Text == "")
            {
                MessageBox.Show("Debe ingresar unidades.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if(formCompras.txtCodigo.Text.Trim() == "")
            {
                producto.Codigo = "";
            }
            else
            {
                producto.Codigo = formCompras.txtCodigo.Text;
                Zen.Barcode.Code128BarcodeDraw mGeneradorCB = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                formCompras.pbCodigodeBarras.Image = mGeneradorCB.Draw(formCompras.txtCodigo.Text,60);
            }
            producto.Descripcion = formCompras.txtDescripcion.Text.ToString().Trim();
            producto.Precio = Convert.ToDouble(formCompras.txtPrecio.Text);
            producto.Cantidad = Convert.ToInt16(formCompras.txtUnidades.Text);


            dt.Clear();
            dt = productoDAO.Obtener(producto.Codigo.ToString());
            if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Producto ya creado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (productoDAO.Grabar(producto) > 0)
                {
                    MessageBox.Show("Datos guardados.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar los datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }



        private string ConsultarID()
        {
            int IDnuevo;
            string IDactual = "";
            dt = productoDAO.ConsultarID();

            foreach (DataRow dr in dt.Rows)
            {
                IDactual = dr["ID"].ToString();
            }

            IDnuevo = Convert.ToInt32(IDactual) + 1;

            return Convert.ToString(IDnuevo);
        }




    }
}
