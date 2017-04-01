using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Emprendimiento
    {
        #region Propiedades

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public int PuntajeFinal { get; set; }


        #endregion

        #region Constructor
        public Emprendimiento()
        {
        }
        #endregion
    }
}
