using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Escala
    {
        public decimal idEscala { get; set; }
        public string nombre { get; set; }

        public Escala()
        {

        }
        public Escala(string nombre)
        {
            this.idEscala = idEscala;
            this.nombre = nombre;
    }
    }
}
