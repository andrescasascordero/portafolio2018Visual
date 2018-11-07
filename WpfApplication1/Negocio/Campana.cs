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
    public class Campana
    {
        public decimal idCampana { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public string usuarioFk { get; set; }
        public string tiendaFk { get; set; }

        public Campana()
        {

        }
        public Campana(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime fecha, string estado, string usuarioFk, string tiendaFk)
        {
            this.idCampana = idCampana;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.fecha = fecha;
            this.estado = estado;
            this.usuarioFk = usuarioFk;
            this.tiendaFk = tiendaFk;
        }

        public List<Campana> getCampana()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectCampana";
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

            List<Campana> listaCampana = new List<Campana>();
            while (dr.Read())
            {
                Campana objCampana = new Campana();
                objCampana.idCampana = Convert.ToInt32(dr["id_campana"]);
                objCampana.nombre = dr["nombre_campana"].ToString();
                objCampana.descripcion = dr["descripcion"].ToString();
                objCampana.fechaInicio = Convert.ToDateTime(dr["fecha_inicio"]);
                objCampana.fechaFin = Convert.ToDateTime(dr["fecha_fin"]);
                objCampana.fecha = Convert.ToDateTime(dr["fecha"]);
                objCampana.estado = dr["estado"].ToString();
                objCampana.usuarioFk = dr["creador"].ToString();
                objCampana.tiendaFk = dr["nombre_tienda"].ToString();


                listaCampana.Add(objCampana);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaCampana;


        }

        public void insertarCampana(Campana pCampana)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertCampana";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            OracleParameter parametro7 = new OracleParameter();
            OracleParameter parametro8 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pCampana.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pCampana.descripcion;
            parametro3.OracleDbType = OracleDbType.Date;
            parametro3.Value = pCampana.fechaInicio;
            parametro4.OracleDbType = OracleDbType.Date;
            parametro4.Value = pCampana.fechaFin;
            parametro5.OracleDbType = OracleDbType.Date;
            parametro5.Value = pCampana.fecha;
            parametro6.OracleDbType = OracleDbType.Varchar2;
            parametro6.Value = pCampana.estado;
            parametro7.OracleDbType = OracleDbType.Varchar2;
            parametro7.Value = pCampana.usuarioFk;
            parametro8.OracleDbType = OracleDbType.Varchar2;
            parametro8.Value = pCampana.tiendaFk;
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.Parameters.Add(parametro6);
            cmd.Parameters.Add(parametro7);
            cmd.Parameters.Add(parametro8);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro5.Dispose();
            parametro6.Dispose();
            parametro7.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarCampana(Campana pCampana)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateCampana";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            OracleParameter parametro7 = new OracleParameter();
            OracleParameter parametro8 = new OracleParameter();
            OracleParameter parametro9 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pCampana.idCampana;
            parametro1.OracleDbType = OracleDbType.Varchar2;
            parametro1.Value = pCampana.nombre;
            parametro2.OracleDbType = OracleDbType.Varchar2;
            parametro2.Value = pCampana.descripcion;
            parametro3.OracleDbType = OracleDbType.Date;
            parametro3.Value = pCampana.fechaInicio;
            parametro4.OracleDbType = OracleDbType.Date;
            parametro4.Value = pCampana.fechaFin;
            parametro6.OracleDbType = OracleDbType.Date;
            parametro6.Value = pCampana.fecha;
            parametro7.OracleDbType = OracleDbType.Varchar2;
            parametro7.Value = pCampana.estado;
            parametro8.OracleDbType = OracleDbType.Varchar2;
            parametro8.Value = pCampana.usuarioFk;
            parametro9.OracleDbType = OracleDbType.Varchar2;
            parametro9.Value = pCampana.tiendaFk;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro6);
            cmd.Parameters.Add(parametro7);
            cmd.Parameters.Add(parametro8);
            cmd.Parameters.Add(parametro9);
            cmd.ExecuteNonQuery();
            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro6.Dispose();
            parametro7.Dispose();
            parametro8.Dispose();
            parametro9.Dispose();


            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarCampana(Campana pCampana)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminarCampana";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pCampana.idCampana;
            cmd.Parameters.Add(parametro0);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void eliminarPermanenteCampana(Campana pCampana)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteCampana";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pCampana.idCampana;
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
