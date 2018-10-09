using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Empresa
    {


        public decimal idEmpresa { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }


        public Empresa()
        {

        }

        public Empresa(decimal idEmpresa, string nombre, string razonSocial)
        {
            this.idEmpresa = idEmpresa;
            this.nombre = nombre;
            this.razonSocial = razonSocial;
        }

    }
}
