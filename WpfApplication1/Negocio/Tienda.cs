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
    public class Tienda
    {
        public decimal idTienda { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public decimal empresaFk { get; set; }
        public decimal usuarioFk { get; set; }

        public Tienda()
        {

        }

        public Tienda(string nombre, string direccion, string estado, decimal empresaFk, decimal usuarioFk)
        {
            this.idTienda = idTienda;
            this.nombre = nombre;
            this.direccion = direccion;
            this.estado = estado;
            this.empresaFk= empresaFk; 
            this.usuarioFk = usuarioFk;

        }

        public List<Tienda> getTienda()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectTienda";
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

            List<Tienda> listaTienda = new List<Tienda>();
            while (dr.Read())
            {
                Tienda objTienda = new Tienda();
                objTienda.idTienda= Convert.ToInt32(dr["id_tienda"]);
                objTienda.nombre = dr["nombre_tienda"].ToString();
                objTienda.direccion = dr["direccion"].ToString();
                objTienda.estado = dr["estado"].ToString();
                objTienda.empresaFk = Convert.ToInt32(dr["empresa_FK"]);
                objTienda.usuarioFk = Convert.ToInt32(dr["usuario_FK"]);
                
                listaTienda.Add(objTienda);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaTienda;


        }

        public void insertarTienda(Tienda pTienda)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertTienda";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pTienda.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pTienda.direccion;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pTienda.estado;
            parametro4.OracleDbType = OracleDbType.Int32;
            parametro4.Value = pTienda.empresaFk;
            parametro5.OracleDbType = OracleDbType.Int32;
            parametro5.Value = pTienda.usuarioFk;
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro5.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarTienda(Tienda pTienda)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateTienda";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Int32;
            parametro0.Value = pTienda.idTienda;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pTienda.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pTienda.direccion;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pTienda.estado;
            parametro4.OracleDbType = OracleDbType.Int32;
            parametro4.Value = pTienda.empresaFk;
            parametro5.OracleDbType = OracleDbType.Int32;
            parametro5.Value = pTienda.usuarioFk;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);

            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro5.Dispose();



            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarTienda(Tienda pTienda)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminarTienda";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pTienda.idTienda;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = "Eliminada";
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();


            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarPermanenteTienda(Tienda pTienda)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteTienda";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pTienda.idTienda;
            cmd.Parameters.Add(parametro0);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro0.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

    }
}
