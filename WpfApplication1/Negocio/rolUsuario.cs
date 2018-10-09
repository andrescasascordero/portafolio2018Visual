using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class rolUsuario
    {
        decimal idRolUsuario{ get; set; }
        string nombre{ get; set; }

        public rolUsuario()
        {

        }
        public rolUsuario(string nombre)
        {
            this.idRolUsuario = idRolUsuario;
            this.nombre = nombre;
        }
    }

}
