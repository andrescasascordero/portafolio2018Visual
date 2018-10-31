using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

namespace Negocio
{
    public class Conexion
    {
        private OracleConnection con { get; set; }

        public OracleConnection getConexion()
        {
            if (con == null)
            {
                string conexion = ConfigurationManager.ConnectionStrings["conectar"].ToString();
                con = new OracleConnection(conexion);
            }
            return con; 
        }
    }
}
