//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONSUMIDOR
    {
        public CONSUMIDOR()
        {
            this.CUPON_CONSUMIDOR = new HashSet<CUPON_CONSUMIDOR>();
            this.VALORACION = new HashSet<VALORACION>();
        }
    
        public decimal ID_CONSUMIDOR { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string RUT { get; set; }
        public string MAILING { get; set; }
        public decimal PUNTOS { get; set; }
    
        public virtual ICollection<CUPON_CONSUMIDOR> CUPON_CONSUMIDOR { get; set; }
        public virtual ICollection<VALORACION> VALORACION { get; set; }
    }
}
