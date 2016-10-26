using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class EmpresaNaviera
    {
        private static EmpresaNaviera instancia = null;
        

        private EmpresaNaviera()
        {
            //inicializar alguna variable??
        }

        public static EmpresaNaviera GetInstance()
        {
            if (EmpresaNaviera.instancia == null)
            {
                EmpresaNaviera.instancia = new EmpresaNaviera();
            }
            return EmpresaNaviera.instancia;
        }


    }
}
