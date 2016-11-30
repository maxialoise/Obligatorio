using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class DetalleReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != 1)
            {
                Response.Redirect("Login.aspx");
            }

            int CodigoEmbarcacion = 0;
            Reparacion rep = null;
            bool ok = false;

            if (Request.QueryString["code"] != null)
            {
                ok = int.TryParse(Request.QueryString["code"], out CodigoEmbarcacion);
            }

            if (ok) rep = EmpresaNaviera.GetInstance().DetallesRep(CodigoEmbarcacion);

            if (rep != null)
            {
                grvMateriales.DataSource = rep.Productos;
                grvMateriales.DataBind();
                grvMecanicos.DataSource = rep.Mecanicos;
                grvMecanicos.DataBind();
            }
            else
            {
                Response.Redirect("LReparacionesFinalizadas.aspx");
            }
        }
    }
}