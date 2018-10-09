using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Valoracion
    {
        public decimal idValoracion { get; set; }
        public System.DateTime fecha { get; set; }
        public string imagen { get; set; }
        public decimal escalaFk { get; set; }
        public decimal consumidorFk { get; set; }
        public decimal ofertaFk { get; set; }

        public Valoracion()
        {

        }

        public Valoracion(DateTime fecha, string imagen, decimal escalaFk, decimal consumidorFk, decimal ofertaFk )
        {
            this.idValoracion = idValoracion; 
            this.fecha = fecha;
            this.imagen = imagen;
            this.escalaFk = escalaFk;
            this.consumidorFk = consumidorFk;
            this.ofertaFk = ofertaFk;

        }
    }
}
