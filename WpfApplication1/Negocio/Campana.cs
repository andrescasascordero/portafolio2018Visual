using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Campana
    {
        public decimal idCampana { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public decimal usuarioFk { get; set; }

        public Campana()
        {

        }
        public Campana(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime fecha)
        {
            this.idCampana = idCampana;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.fecha = fecha;
            this.estado = estado;
            this.usuarioFk = usuarioFk;
    }
    }
}
