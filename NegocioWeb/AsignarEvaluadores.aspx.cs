using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class AsignarEvaluadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = Session["usuario"] as Usuario;

                if (usu == null || usu.Rol != "Admin")
                {
                    Response.Redirect("Login.aspx");
                }

                if (!IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }
        }

        private void BindData()
        {

            List<Evaluador> evaluadores = Evaluador.ObtenerEvaluadores();

            if (evaluadores == null || evaluadores.Count <= 0)
            {
                lblAvisoEval.Text = "No hay Evaluadores en el sistema";
            }
            else
            {
                ddlEvaluadores.DataSource = evaluadores;
                ddlEvaluadores.DataTextField = "Nombre";
                ddlEvaluadores.DataValueField = "IdEvaluador";
                ddlEvaluadores.DataBind();
            }



            List<Emprendimiento> emprendimientos = Emprendimiento.ObtenerEmprendimientos();
            if (emprendimientos == null || emprendimientos.Count <= 0)
            {
                lblAvisoEmpren.Text = "No hay Emprendimientos en el sistema";
            }
            else
            {
                ddlEmprendimientos.DataSource = emprendimientos;
                ddlEmprendimientos.DataTextField = "Titulo";
                ddlEmprendimientos.DataValueField = "Id";
                ddlEmprendimientos.DataBind();
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                lblError.Text = string.Empty;
                bool ret = false;
                string msg = string.Empty;
                int idEvaluador = int.Parse(ddlEvaluadores.SelectedValue);
                int idEmprendimiento = int.Parse(ddlEmprendimientos.SelectedValue);
                Evaluacion evaluacion = new Evaluacion { Evaluador = new Evaluador { Id = idEvaluador } };
                ret = evaluacion.AltaEvaluacion(idEmprendimiento, out msg);
                if (ret)
                {
                    lblMensaje.Text = "Evaluador asignado con exito";
                }
                else
                {
                    lblError.Text = msg;
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }
        }
    }
}