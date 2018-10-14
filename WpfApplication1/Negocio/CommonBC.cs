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
        private static EntidadesMO _Entidades;

        public static EntidadesMO Entidades
        {
            get
            {
                if (_Entidades == null) {
                    _Entidades = new EntidadesMO();
                }
                return _Entidades;
            }

        }
        public CommonBC()
        {

        }
    }
}
