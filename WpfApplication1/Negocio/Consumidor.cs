using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Consumidor
    {
        public decimal id_consumidor { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string rut { get; set; }
        public string mailing { get; set; }
        public decimal puntos { get; set; }

        public Consumidor()
        {

        }
        public Consumidor(string nombres, string apellidoPaterno, string apellidoMaterno, string rut , string mailing , decimal puntos)
        {
        this.id_consumidor = id_consumidor;
        this.nombres = nombres;
        this.apellidoPaterno = apellidoPaterno;
        this.apellidoMaterno = apellidoMaterno;
        this.rut = rut;
        this.mailing = mailing;
        this.puntos = puntos;         
    }
    }
}
