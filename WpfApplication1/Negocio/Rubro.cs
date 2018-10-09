using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Rubro
    {
        public decimal idRubro{ get; set; }
        public string nombre{ get; set; }

        public Rubro()
        {

        }
        public Rubro(string nombre)
        {
            this.idRubro = idRubro;
            this.nombre = nombre;
        }

    }
}
