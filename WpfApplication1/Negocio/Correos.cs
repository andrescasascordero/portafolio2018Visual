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

        public Correos(Decimal idMailList, String suscrito, string nombre, string apellido, string correo)
        {
            this.idMailList = idMailList;
            this.suscrito = suscrito;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
        }
        public Correos(string nombre, string apellido, string correo)
        {
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

        //public List<Correos> getCorreos()
        //{
        //    Conexion con = new Conexion();
        //    OracleConnection cn = con.getConexion();
        //    cn.Open();
        //    OracleCommand cmd = cn.CreateCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "selectCorreos";
        //    OracleParameter parametro1 = new OracleParameter();
        //    parametro1.OracleDbType = OracleDbType.RefCursor;
        //    parametro1.Direction = System.Data.ParameterDirection.Output;
        //    cmd.Parameters.Add(parametro1);
        //    cmd.ExecuteNonQuery();
        //    OracleRefCursor cursor = (OracleRefCursor)parametro1.Value;
        //    OracleDataReader dr = cursor.GetDataReader();
        //    FieldInfo fi = dr.GetType().GetField("m_rowSize", BindingFlags.Instance | BindingFlags.NonPublic);
        //    int rowsize = Convert.ToInt32(fi.GetValue(dr));
        //    dr.FetchSize = rowsize * 100;

        //    List<Correos> listaCorreos = new List<Correos>();
        //    while (dr.Read())
        //    {
        //        Correos objCorreos = new Correos();
        //        objCorreos.idMailList = Convert.ToInt32(dr["id_Maillist"]);
        //        objCorreos.suscrito = dr["suscrito"].ToString();
        //        objCorreos.nombre = dr["nombres_usuario"].ToString();
        //        objCorreos.apellido = dr["apellido_paterno"].ToString();
        //        objCorreos.correo = dr["correo"].ToString();

        //        listaCorreos.Add(objCorreos);
        //    }
        //    cn.Close();
        //    parametro1.Dispose();
        //    cmd.Dispose();
        //    cn.Dispose();
        //    con = null;
        //    return listaCorreos;

        //}
        class itemcrre
        {
            public string nombre;
            public string apellido;
            public string correo;

            public itemcrre(string nmb, string apll, string crre)
            {
                this.nombre = nmb;
                this.apellido = apll;
                this.correo = crre;
            }
            public itemcrre()
            {

            }
        }
        public void enviarCorreos(List<Correos> listaCorreos)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            foreach (var item in listaCorreos)
            {

                Uri siteuri = new Uri("http://misofertas.azurewebsites.net/GeneraMail/rest/usuario/data/get/" + item.correo);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(siteuri);
                String respuesta = String.Empty;

                httpWebRequest.Method = "GET";
                httpWebRequest.KeepAlive = true;

                using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    respuesta = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }

        }
        public void enviarCorreosPost(List<Correos> listaCorreos)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            foreach (var item in listaCorreos)
            {

                Uri siteuri = new Uri("https://misofertas.azurewebsites.net/GeneraMail/rest/usuario/data/post");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(siteuri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.UserAgent = "(Apache-HttpClient/4.1.1(java 1.5)";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream(), Encoding.UTF8))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        nombre = item.nombre.ToString(),
                        apellido = item.apellido.ToString(),
                        email = item.correo.ToString()
                    });

                    streamWriter.Write(json);
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8, true))
                {
                    var result = streamReader.ReadToEnd();
                }
            }

        }
    }
}
