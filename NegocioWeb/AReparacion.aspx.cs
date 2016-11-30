using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class AReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEmbarcaciones.DataSource = EmpresaNaviera.GetInstance().Embarcaciones;
                ddlEmbarcaciones.DataTextField = "Nombre";
                ddlEmbarcaciones.DataValueField = "Codigo";

                ddlEmbarcaciones.DataBind();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaAltaIngreso = DateTime.Parse(txtFecha.Text);
                DateTime fechaPrometidaEgreso = DateTime.Parse(txtFechaDos.Text);
                int codEmbarcacion = int.Parse(ddlEmbarcaciones.SelectedValue);
                string mensajeError = string.Empty;
                bool ok = EmpresaNaviera.GetInstance().AltaReparacion(fechaAltaIngreso, fechaPrometidaEgreso, codEmbarcacion, out mensajeError);
                if (ok)
                {
                    lblError.Text = "Alta exitosa";
                }
                else
                {
                    lblError.Text = mensajeError;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}