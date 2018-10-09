using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Oferta
    {
        public decimal idOferta { get; set; }
        public decimal cantidadMinima{ get; set; }
        public decimal cantidadMaxima { get; set; }
        public decimal precioNormal { get; set; }
        public decimal precioOferta { get; set; }
        public string imagen { get; set; }
        public DateTime fecha { get; set; }
        public decimal campanaFk { get; set; }
        public decimal productoFk { get; set; }

        public Oferta()
        {

        }
        public Oferta(decimal cantidadMinima, decimal cantidadMaxima, decimal precioNormal, decimal precioOferta, string imagen, DateTime fecha, decimal campanaFk, decimal productoFk)
        {
            this.idOferta = idOferta;
            this.cantidadMinima = cantidadMinima;
            this.cantidadMaxima = cantidadMaxima;
            this.precioNormal = precioNormal;
            this.precioOferta = precioOferta;
            this.imagen = imagen;
            this.fecha = fecha;
            this.campanaFk = campanaFk;
            this.productoFk = productoFk; 
    }
    }

}
