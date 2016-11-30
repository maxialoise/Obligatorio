﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        #region Atributos
        private string nombreUsu;
        private string contrasenia;
        private byte rol;
        #endregion

        #region Propiedades
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
        #endregion
    }
}
