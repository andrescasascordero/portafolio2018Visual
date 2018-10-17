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
    public class Tramo
    {
        public decimal idTramo { get; set; }
        public decimal minimo { get; set; }
        public decimal maximo { get; set; }

        public Tramo()
        {

        }

        public Tramo(decimal idTramo, decimal minimo, decimal maximo)
        {
            this.idTramo = idTramo;
            this.minimo = minimo;
            this.maximo = maximo;
        }

        public List<Tramo> getTramo()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectTramo";
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

            List<Tramo> listaTramo = new List<Tramo>();
            while (dr.Read())
            {
                Tramo objTramo = new Tramo();
                objTramo.idTramo = Convert.ToInt32(dr["id_Tramo"]);
                objTramo.minimo = Convert.ToInt32(dr["minimo"].ToString());
                objTramo.maximo = Convert.ToInt32(dr["maximo"].ToString());
                listaTramo.Add(objTramo);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaTramo;


        }

        public void insertarTramo(Tramo pTramo)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertTramo";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            parametro2.OracleDbType = OracleDbType.Decimal;
            parametro2.Value = pTramo.maximo;
            parametro1.OracleDbType = OracleDbType.Decimal;
            parametro1.Value = pTramo.minimo;
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro1);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarTramo(Tramo pTramo)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateTramo";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pTramo.idTramo;

            parametro2.OracleDbType = OracleDbType.Decimal;
            parametro2.Value = pTramo.maximo;
            parametro1.OracleDbType = OracleDbType.Decimal;
            parametro1.Value = pTramo.minimo;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro1);
            cmd.ExecuteNonQuery();
            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();
            parametro2.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarPermanenteTramo(Tramo pTramo)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteTramo";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pTramo.idTramo;
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
