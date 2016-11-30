using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private string nombreUsu;
        private string contrasenia;
        private byte rol;

        public byte Rol
        {
            get { return rol; }
            set { rol = value; }
        }


        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }


        public string NombreUsu
        {
            get { return nombreUsu; }
            set { nombreUsu = value; }
        }


    }
}
