using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfEmprendimientos.DTOS
{
    public class DTOEvaluador
    {
        public int IdEmprendimiento { get; set; }
        public string NombreEvaluador { get; set; }
        public string Justificacion { get; set; }
    }
}