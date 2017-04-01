using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        #region Propiedades

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public Usuario Usuario { get; set; }

        #endregion

        #region Constructor
        public Persona()
        {
        }

        #endregion
    }
}
