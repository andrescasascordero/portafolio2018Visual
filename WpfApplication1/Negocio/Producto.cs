using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using DALC;
using System.Reflection;

namespace Negocio
{
    public class Producto
    {
        public decimal idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string color { get; set; }
        public string perecible { get; set; }
        public string marca { get; set; }
        public string rubroFk { get; set; }

        public Producto()
        {

        }
        public Producto(string nombre, string descripcion, string color, string marca, string perecible, string rubroFk)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.color = color;
            this.perecible = perecible;
            this.marca = marca;
            this.rubroFk = rubroFk;
        }

        public List<Producto> getProducto()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectProducto";
            OracleParameter parametro1 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.RefCursor;
            parametro1.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(parametro1);
            cmd.ExecuteNonQuery();
            OracleRefCursor cursor = (OracleRefCursor)parametro1.Value;
            OracleDataReader dr = cursor.GetDataReader();
            FieldInfo fi = dr.GetType().GetField("m_rowSize", BindingFlags.Instance | BindingFlags.NonPublic);
            int rowsize = Convert.ToInt32(fi.GetValue(dr));
            dr.FetchSize = rowsize * 100;

            List<Producto> listaProducto = new List<Producto>();
            while (dr.Read())
            {
                Producto objProducto = new Producto();
                objProducto.idProducto = Convert.ToInt32(dr["id_producto"]);
                objProducto.nombre = dr["nombre_producto"].ToString();
                objProducto.descripcion = dr["descripcion"].ToString();
                objProducto.color = dr["color"].ToString();
                objProducto.perecible = dr["perecible"].ToString();
                objProducto.marca = dr["marca"].ToString();
                objProducto.rubroFk = dr["nombre_rubro"].ToString();


                listaProducto.Add(objProducto);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaProducto;


        }

        public void insertarProducto(Producto pProducto)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertProducto";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pProducto.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pProducto.descripcion;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pProducto.color;
            parametro4.OracleDbType = OracleDbType.Varchar2;
            parametro4.Value = pProducto.perecible;
            parametro5.OracleDbType = OracleDbType.Varchar2;
            parametro5.Value = pProducto.marca;
            parametro6.OracleDbType = OracleDbType.Int32;
            parametro6.Value = pProducto.rubroFk;
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.Parameters.Add(parametro6);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro5.Dispose();
            parametro6.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarProducto(Producto pProducto)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateProducto";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pProducto.idProducto;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pProducto.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pProducto.descripcion;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pProducto.color;
            parametro4.OracleDbType = OracleDbType.Varchar2;
            parametro4.Value = pProducto.perecible;
            parametro5.OracleDbType = OracleDbType.Varchar2;
            parametro5.Value = pProducto.marca;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.ExecuteNonQuery();
            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }


        public void eliminarProducto(Producto pProducto)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteProducto";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pProducto.idProducto;
            cmd.Parameters.Add(parametro0);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro0.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }
        public override string ToString()
        {
            return this.nombre;
        }

    }

}
