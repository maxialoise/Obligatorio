using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfEmprendimientos.DTOS
{
    [DataContract]
    public class DTOEmprendimiento
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int PuntajeFinal { get; set; }
        [DataMember]
        public int TiempoPrevisto { get; set; }
        [DataMember]
        public int Costo { get; set; }
        [DataMember]
        public List<DTOPersona> Intregrantes { get; set; }
        [DataMember]
        public List<DTOEvaluador> Evaluadores { get; set; }

        public DTOEmprendimiento(int id, string titulo, string descripcion, int puntajeFinal, int tiempo, int costo)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.PuntajeFinal = puntajeFinal;
            this.TiempoPrevisto = tiempo;
            this.Costo = costo;
        }
        public DTOEmprendimiento()
        {

        }
    }
}