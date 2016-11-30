using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class LReparacionesFinalizadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Reparacion> lista = EmpresaNaviera.GetInstance().ReparacionesFinalizadas();
                CargarPendientes(lista);
            }
        }
        private void CargarPendientes(List<Reparacion> lista)
        {
            grvFinalizadas.DataSource = lista;
            grvFinalizadas.DataBind();
        }
    }
}