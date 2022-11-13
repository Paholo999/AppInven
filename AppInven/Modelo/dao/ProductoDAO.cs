using AppInven.Modelo.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInven.Modelo.dao
{
    public class ProductoDAO : Conexion
    {
        SqlCommand cmd = new SqlCommand();         // forma 1
        DataTable dt = new DataTable();          // forma 1
        SqlDataAdapter da = new SqlDataAdapter();     // forma 1
        int res;

        public int Grabar(Producto producto)
        {
            res = 0;
            cmd = new SqlCommand(@"Insert into Producto (Codigo, Descripcion, Precio, Cantidad) 
                values(@codigo, @descripcion, @precio, @cantidad)", cn);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
            cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Precio);
            cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);

            try
            {
                Abrir_cn();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }

            return res;
        }

        public DataTable Consultar()
        {
            try
            {
                cmd = new SqlCommand(@"select *
                                         from Producto", cn);

                da = new SqlDataAdapter();
                dt = new DataTable();
                cmd.CommandType = CommandType.Text;

                Abrir_cn();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }
            return dt;
        }
    }
}
