using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        public decimal idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string color { get; set; }
        public string perecible { get; set; }
        public string marca { get; set; }
        public decimal rubroFk { get; set; }

        public Producto()
        {

        }
        public Producto(string nombre, string descripcion, string color, string marca, string perecible, decimal rubroFk)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.color = color;
            this.perecible = perecible;
            this.marca = marca;
            this.rubroFk = rubroFk;
    }
    }

}
