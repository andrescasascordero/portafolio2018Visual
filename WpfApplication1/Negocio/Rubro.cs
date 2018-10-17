﻿using System;
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
    public class Rubro
    {
        public decimal idRubro{ get; set; }
        public string nombreRubro{ get; set; }

        public Rubro()
        {

        }
        public Rubro(decimal idRubro, string nombreRubro)
        {
            this.idRubro = idRubro;
            this.nombreRubro = nombreRubro;
        }
        public List<Rubro> getRubro()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectRubro";
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

            List<Rubro> listaRubro = new List<Rubro>();
            while (dr.Read())
            {
                Rubro objRubro = new Rubro();
                objRubro.idRubro = Convert.ToInt32(dr["id_rubro"]);
                objRubro.nombreRubro = dr["nombre_rubro"].ToString();

                listaRubro.Add(objRubro);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaRubro;


        }

        public void insertarRubro(Rubro pRubro)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertRubro";
            OracleParameter parametro1 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pRubro.nombreRubro;
            cmd.Parameters.Add(parametro1);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarRubro(Rubro pRubro)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateRubro";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pRubro.idRubro;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pRubro.nombreRubro;

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

        public void eliminarPermanenteRubro(Rubro pRubro)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteRubro";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pRubro.idRubro;
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
            return this.nombreRubro;
        }
    }
}
