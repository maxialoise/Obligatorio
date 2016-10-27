using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        #region Atributos
        private string calle;
        private string numPuerta;
        private string ciudad;
        #endregion

        #region Propiedades

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string NumPuerta
        {
            get { return numPuerta; }
            set { numPuerta = value; }
        }

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        #endregion

        #region Constructor
        public Direccion(string Calle, string NumPuerta, string Ciudad)
        {
            calle = Calle;
            numPuerta = NumPuerta;
            ciudad = Ciudad;
        }
        #endregion
    }
}
