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
    public class RolUsuario
    {
        public decimal idRolUsuario{ get; set; }
        public string nombre{ get; set; }

        public RolUsuario()
        {

        }
        public RolUsuario(decimal idRolUsuario, string nombre)
        {
            this.idRolUsuario = idRolUsuario;
            this.nombre = nombre;
        }

        public List<RolUsuario> getRol() 
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectRolUsuario";
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

            List<RolUsuario> listaRol = new List<RolUsuario>();
            while (dr.Read())
            {
                RolUsuario objRol = new RolUsuario();
                objRol.idRolUsuario = Convert.ToInt32(dr["id_Rol_Usuario"]);
                objRol.nombre = dr["nombre"].ToString();
                listaRol.Add(objRol);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaRol;


        }
        public override string ToString()
        {
            return this.nombre;
        }
        //public override bool Equals(object obj)
        //{
        //    return this.idRolUsuario == (obj as RolUsuario).idRolUsuario;
        //}
    }


}
