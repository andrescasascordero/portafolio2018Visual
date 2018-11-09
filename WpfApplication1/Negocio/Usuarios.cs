using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using DALC;
using System.Reflection;
using System.Security.Cryptography;

namespace Negocio
{
    public class Usuarios
    {

        public decimal idUsuario { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string rut { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        public string rolUsuarioFk { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(string nombres, string apellidoPaterno, string apellidoMaterno, string contrasena, string correo, string rut, string estado, DateTime fecha, string rolUsuarioFk)
        {
            this.idUsuario = idUsuario;
            this.nombres = nombres;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.correo = correo;
            this.contrasena = contrasena;
            this.rut = rut;
            this.estado = estado;
            this.fecha = fecha;
            this.rolUsuarioFk = rolUsuarioFk;
        }

        public List<Usuarios> getUsuario()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectUsuario";
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

            List<Usuarios> listaUsuario = new List<Usuarios>();
            while (dr.Read())
            {
                Usuarios objUsuario = new Usuarios();
                objUsuario.idUsuario = Convert.ToInt32(dr["id_usuario"]);
                objUsuario.nombres = dr["nombres_usuario"].ToString();
                objUsuario.apellidoPaterno = dr["apellido_paterno"].ToString();
                objUsuario.apellidoMaterno = dr["apellido_materno"].ToString();
                objUsuario.rut = dr["rut"].ToString();
                objUsuario.estado = dr["estado"].ToString();
                objUsuario.rolUsuarioFk = dr["nombre"].ToString();
                objUsuario.fecha = Convert.ToDateTime(dr["fecha"]);
                objUsuario.correo = dr["correo"].ToString();

                listaUsuario.Add(objUsuario);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaUsuario;


        }

        public void insertarUsuarios(Usuarios pUsuario)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertUsuario";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            OracleParameter parametro7 = new OracleParameter();
            OracleParameter parametro8 = new OracleParameter();
            OracleParameter parametro9 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pUsuario.nombres;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pUsuario.apellidoPaterno;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pUsuario.apellidoMaterno;
            parametro4.OracleDbType = OracleDbType.Varchar2;
            parametro4.Value = pUsuario.correo;
            parametro5.OracleDbType = OracleDbType.Varchar2;
            var pass = HashMD5.getMd5Hash(pUsuario.contrasena);
            parametro5.Value = pass.ToString();
            parametro6.OracleDbType = OracleDbType.Varchar2;
            parametro6.Value = pUsuario.rut;
            parametro7.OracleDbType = OracleDbType.Varchar2;
            parametro7.Value = pUsuario.estado;
            parametro8.OracleDbType = OracleDbType.Date;
            parametro8.Value = pUsuario.fecha;
            parametro9.OracleDbType = OracleDbType.Varchar2;
            parametro9.Value = pUsuario.rolUsuarioFk;
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.Parameters.Add(parametro6);
            cmd.Parameters.Add(parametro7);
            cmd.Parameters.Add(parametro8);
            cmd.Parameters.Add(parametro9);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro5.Dispose();
            parametro6.Dispose();
            parametro7.Dispose();
            parametro8.Dispose();
            parametro9.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarUsuario(Usuarios pUsuario)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateUsuario";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            OracleParameter parametro7 = new OracleParameter();
            OracleParameter parametro8 = new OracleParameter();

            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pUsuario.idUsuario;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pUsuario.nombres;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pUsuario.apellidoPaterno;
            parametro3.OracleDbType = OracleDbType.Varchar2;
            parametro3.Value = pUsuario.apellidoMaterno;
            parametro4.OracleDbType = OracleDbType.Varchar2;
            parametro4.Value = pUsuario.correo;
            parametro6.OracleDbType = OracleDbType.Varchar2;
            parametro6.Value = pUsuario.rut;
            parametro7.OracleDbType = OracleDbType.Varchar2;
            parametro7.Value = pUsuario.estado;
            parametro8.OracleDbType = OracleDbType.Varchar2;
            parametro8.Value = pUsuario.rolUsuarioFk;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro6);
            cmd.Parameters.Add(parametro7);
            cmd.Parameters.Add(parametro8);
            cmd.ExecuteNonQuery();
            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro6.Dispose();
            parametro7.Dispose();


            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarUsuario(Usuarios pUsuario)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminarUsuario";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pUsuario.idUsuario;
            cmd.Parameters.Add(parametro0);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();


            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarPermanenteUsuario(Usuarios pUsuario)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteUsuario";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pUsuario.idUsuario;
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
            return this.nombres+" "+this.apellidoPaterno+" "+this.apellidoMaterno ;
        }

        public string getLogin(Usuarios pUsuario)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Login";
            OracleParameter parametro1 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            OracleParameter parametro2 = new OracleParameter();
            parametro2.OracleDbType = OracleDbType.Varchar2;
            var pass = HashMD5.getMd5Hash(pUsuario.contrasena);
            parametro2.Value = pUsuario.correo;
            OracleParameter parametro3 = new OracleParameter();
            parametro3.Value = pass.ToString();
            parametro1.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add("nombre_rol", OracleDbType.Varchar2, 32767, "x".PadRight(500, 'x'), System.Data.ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            var respuesta = cmd.Parameters["nombre_rol"].Value.ToString();
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return respuesta;

        }
        public void editarContrasena(Usuarios pUsuario)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateContrasena";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();

            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pUsuario.idUsuario;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            var pass = HashMD5.getMd5Hash(pUsuario.contrasena);
            parametro1.Value = pass.ToString();
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

    }
}
