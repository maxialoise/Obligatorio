using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class LReparacionesPendientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != 0)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                List<Reparacion> lista = EmpresaNaviera.GetInstance().ReparacionesPendientes();
                CargarPendientes(lista);
            }
        }

        private void CargarPendientes(List<Reparacion> lista)
        {
            grvPendientes.DataSource = lista;
            grvPendientes.DataBind();
        }
    }
}
