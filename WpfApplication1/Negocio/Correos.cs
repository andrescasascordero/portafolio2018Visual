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
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;


namespace Negocio
{
    public class Correos
    {
        public Decimal idMailList { get; set; }
        public String suscrito { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }


        public Correos()
        {

        }

        public Correos( Decimal idMailList, String suscrito, string nombre, string apellido, string correo)
        {
            this.idMailList = idMailList;
            this.suscrito = suscrito;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
        }

        public List<Correos> getCorreos()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectCorreos";
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

            List<Correos> listaCorreos = new List<Correos>();
            while (dr.Read())
            {
                Correos objCorreos = new Correos();
                objCorreos.idMailList = Convert.ToInt32(dr["id_Maillist"]);
                objCorreos.suscrito = dr["suscrito"].ToString();
                objCorreos.nombre = dr["nombres_usuario"].ToString();
                objCorreos.apellido = dr["apellido_paterno"].ToString();
                objCorreos.correo = dr["correo"].ToString();

                listaCorreos.Add(objCorreos);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaCorreos;

        }

        public void enviarCorreos(List<Correos> listaCorreos)
        {
            foreach (var item in listaCorreos)
            {
                Uri siteuri = new Uri("https://misofertas.azurewebsites.net/GeneraMail/rest/usuario/data/");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(siteuri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        nombre = item.nombre.ToString(),
                        apellido = item.apellido.ToString(),
                        correo = item.correo.ToString()
                    });

                    streamWriter.Write(json);
                    //streamWriter.Flush();
                    //streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }

        }
    }
}
