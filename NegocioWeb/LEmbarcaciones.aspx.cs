using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class LEmbarcaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Embarcacion> lista = EmpresaNaviera.GetInstance().Embarcaciones;
                lista.Sort((y, x) => string.Compare(x.Nombre, y.Nombre));
                CargarEmbaraciones(lista);
            }
        }
        private void CargarEmbaraciones(List<Embarcacion> listaOrdenada)
        {
            grvEmbarcaciones.DataSource = listaOrdenada;
            grvEmbarcaciones.DataBind();
        }
    }
}