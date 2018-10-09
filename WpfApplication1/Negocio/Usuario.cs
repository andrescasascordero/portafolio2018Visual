using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {

        public decimal idUsuario { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public decimal rolUsuarioFk { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nombres, string apellidoPaterno, string apellidoMaterno, string correo, decimal rolUsuarioFk)
        {
            this.idUsuario = idUsuario;
            this.nombres = nombres;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.correo = correo;
            this.contrasena = contrasena;
            this.rolUsuarioFk = rolUsuarioFk;
        }

    }
}
