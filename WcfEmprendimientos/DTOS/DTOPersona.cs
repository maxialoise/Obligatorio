using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfEmprendimientos.DTOS
{
    [DataContract]
    public class DTOPersona
    {
        [DataMember]
        public int IdEmprendimiento { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}