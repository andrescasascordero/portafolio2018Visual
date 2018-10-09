using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Tienda
    {
        public decimal idTienda { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public decimal empresaFk { get; set; }
        public decimal usuarioFk { get; set; }

        public Tienda()
        {

        }

        public Tienda(string nombre, string direccion, decimal empresaFk, decimal usuarioFk)
        {
            this.idTienda = idTienda;
            this.nombre = nombre;
            this.direccion = direccion;
            this.empresaFk= empresaFk; 
            this.usuarioFk = usuarioFk;

    }

}
}
