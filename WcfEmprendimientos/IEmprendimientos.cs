using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfEmprendimientos
{
    
    [ServiceContract]
    public interface IEmprendimientos
    {

        [OperationContract]
        List<DTOS.DTOEmprendimiento> ObtenerEmprendimientos();

    }
}
