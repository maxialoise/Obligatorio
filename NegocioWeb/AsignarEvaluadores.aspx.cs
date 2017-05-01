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

            if (evaluadores.Count <= 0)
            {
                lblAvisoEval.Text = "No hay Evaluadores en el sistema";
            }
            ddlEvaluadores.DataSource = evaluadores;
            ddlEvaluadores.DataTextField = "Nombre";
            ddlEvaluadores.DataValueField = "Id";
            ddlEvaluadores.DataBind();


            List<Emprendimiento> emprendimientos = Emprendimiento.ObtenerEmprendimientos();
            if (emprendimientos.Count <= 0)
            {
                lblAvisoEmpren.Text = "No hay Emprendimientos en el sistema";
            }
            ddlEmprendimientos.DataSource = emprendimientos;
            ddlEmprendimientos.DataTextField = "Titulo";
            ddlEmprendimientos.DataValueField = "Id";
            ddlEmprendimientos.DataBind();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

        }
    }
}