using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class EvaluarEmprendimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = Session["usuario"] as Usuario;

                if (usu == null || usu.Rol != "Evaluador")
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
            Usuario usu = Session["usuario"] as Usuario;            
            string email = usu.Email;
            List<Emprendimiento> emprendimientos = Emprendimiento.ObtenerEmprendimientosPorEvaluador(email);
            if (emprendimientos.Count <= 0)
            {
                lblAvisoEmpren.Text = "No hay Emprendimientos para Evaluar";
            }
            ddlEmprendimientos.DataSource = emprendimientos;
            ddlEmprendimientos.DataTextField = "Titulo";
            ddlEmprendimientos.DataValueField = "Id";
            ddlEmprendimientos.DataBind();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlEmprendimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cuando se seleccione un emprendimiento
                //mostrar sus datos (id, nombre, desctipcion)
                //mostrar campos para modificar evaluacion (puntaje, justificacion, fecha(hoy))
                lblMensaje.Text = string.Empty;
                lblError.Text = string.Empty;
                bool ret = false;
                int idEmprendimiento = int.Parse(ddlEmprendimientos.SelectedValue);
                //Evaluacion evaluacion = new Evaluacion { Evaluador = new Evaluador { Id = idEvaluador } };
                //ret = evaluacion.AltaEvaluacion(idEmprendimiento);
                if (ret)
                {
                    //lblMensaje.Text = "Evaluador asignado con exito";
                }
                else
                {
                    //lblError.Text = msg;
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }           
        }
    }
}