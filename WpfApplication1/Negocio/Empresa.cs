using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
//using Oracle.ManagedDataAccess.Client;
using DALC;
using System.Reflection;

namespace Negocio
{
    public class Empresa
    {


        public decimal idEmpresa { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }
        public string estado { get; set; }
        public string rut { get; set; }

        public Empresa()
        {

        }

        public Empresa(decimal idEmpresa, string nombre, string razonSocial, string estado, string rut)
        {
            this.idEmpresa = idEmpresa;
            this.nombre = nombre;
            this.razonSocial = razonSocial;
            this.estado = estado;
            this.rut = rut;

        }

        public List<Empresa> getEmpresa()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectEmpresa";
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

            List<Empresa> listaEmpresas = new List<Empresa>();
            while (dr.Read())
            {
                Empresa objEmpresa = new Empresa();
                objEmpresa.idEmpresa = Convert.ToInt32(dr["id_empresa"]);
                objEmpresa.nombre = dr["nombre_empresa"].ToString();
                objEmpresa.razonSocial = dr["Razon_Social"].ToString();
                objEmpresa.estado = dr["estado"].ToString();
                objEmpresa.rut = dr["rut"].ToString();
                listaEmpresas.Add(objEmpresa);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaEmpresas;
            

        }

        public void insertarEmpresa(Empresa pEmpresa)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmpresa";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pEmpresa.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pEmpresa.razonSocial;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pEmpresa.estado;
            parametro4.OracleDbType = OracleDbType.Varchar2;
            parametro4.Value = pEmpresa.rut;
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarEmpresa(Empresa pEmpresa)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateEmpresa";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pEmpresa.idEmpresa;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pEmpresa.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pEmpresa.razonSocial;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pEmpresa.estado;
            parametro4.OracleDbType = OracleDbType.Varchar2;
            parametro4.Value = pEmpresa.rut;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
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

        public void eliminarEmpresa(Empresa pEmpresa)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminarEmpresa";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pEmpresa.idEmpresa;
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

        public void eliminarPermanenteEmpresa(Empresa pEmpresa)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteEmpresa";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pEmpresa.idEmpresa;
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
