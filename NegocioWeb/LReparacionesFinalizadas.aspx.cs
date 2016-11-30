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
        static List<Reparacion> lstNew = new List<Reparacion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != 1)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                List<Reparacion> lista = EmpresaNaviera.GetInstance().ReparacionesFinalizadas();
                lista.Sort((x, y) => DateTime.Compare(x.FechaIngreso, y.FechaIngreso));
                CargarPendientes(lista);
                lstNew = lista;
            }
        }
        private void CargarPendientes(List<Reparacion> lista)
        {
            grvFinalizadas.DataSource = lista;
            grvFinalizadas.DataBind();
        }

        protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow filaSeleccionada = this.grvFinalizadas.Rows[int.Parse(e.CommandArgument.ToString())];
            if (e.CommandName == "detalle")
            {
                Reparacion r = lstNew[filaSeleccionada.RowIndex];
                Response.Redirect("DetalleReparacion.aspx?code=" + r.CodigoEmbarcacion);
            }
        }
    }
}