using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Evaluacion
    {
        #region Propiedades
        public Evaluador Evaluador { get; set; }

        public int Puntaje { get; set; }

        public string Justificacion { get; set; }

        public DateTime FechaEvaluacion { get; set; }

        #endregion

        #region Constructor
        public Evaluacion()
        {
        }
        #endregion
    }
}
