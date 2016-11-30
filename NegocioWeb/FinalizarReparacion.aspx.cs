using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class FinalizarReparacion : System.Web.UI.Page
    {
        private static bool hayRepPendientes = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = Session["usuario"] as Usuario;

                if (usu == null || usu.Rol != 1)
                {
                    Response.Redirect("Login.aspx");
                }

                if (!IsPostBack)
                {
                    List<Reparacion> pendientes = EmpresaNaviera.GetInstance().ReparacionesPendientes();

                    if (pendientes.Count <= 0)
                    {
                        hayRepPendientes = false;
                        lblAviso.Text = "No hay reparaciones a finalizar";
                    }

                    ddlReparaciones.DataSource = pendientes;
                    ddlReparaciones.DataTextField = "NombreEmbarcacion";
                    ddlReparaciones.DataValueField = "CodigoEmbarcacion";
                    ddlReparaciones.DataBind();
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (hayRepPendientes)
                {
                    int codigo = int.Parse(ddlReparaciones.SelectedValue);
                    bool result = EmpresaNaviera.GetInstance().FinalizarReparacion(codigo);
                    if (result)
                    {
                        lblError.Text = "Reparacion finalizada";
                    }
                    else
                    {
                        lblError.Text = "Error al finalizar reparacion";
                    }
                }
                else
                {
                    lblError.Text = "No hay reparaciones a finalizar";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}