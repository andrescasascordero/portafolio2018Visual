using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio
{
    public class CommonBC
    {
        private static Entidades _Entidades;

        public static Entidades Entidades
        {
            get
            {
                if (_Entidades == null) {
                    _Entidades = new Entidades();
                }
                return _Entidades;
            }

        }
        public CommonBC()
        {

        }
    }
}
