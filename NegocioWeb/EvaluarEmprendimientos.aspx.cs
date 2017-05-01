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
        private static List<Emprendimiento> emprendimientos = new List<Emprendimiento>();
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
            emprendimientos = Emprendimiento.ObtenerEmprendimientosPorEvaluador(email);
            if (emprendimientos.Count <= 0)
            {
                lblAvisoEmpren.Text = "No hay Emprendimientos para Evaluar";
            }
            ddlEmprendimientos.DataSource = emprendimientos;
            ddlEmprendimientos.DataTextField = "Titulo";
            ddlEmprendimientos.DataValueField = "Id";
            ddlEmprendimientos.DataBind();
            ddlEmprendimientos.Items.Insert(0, new ListItem("Seleccione un emprendimiento", "NA"));
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                lblError.Text = string.Empty;
                int puntaje = int.Parse(txtPuntaje.Text);
                string justif = txtJustificacion.Text;
                bool ret = false;
                int idEmprend = int.Parse(ddlEmprendimientos.SelectedValue);
                int idEval = 0;
                //buscar el id de evaluacion en los emprendimientos
                idEval = emprendimientos.Find(x => x.Id == idEmprend).Evaluaciones[0].IdEvaluacion;
                Evaluacion evaluacion = new Evaluacion { IdEvaluacion = idEval, Puntaje = puntaje, Justificacion = justif };
                ret = evaluacion.ActualizarEvaluacion();

                if (ret)
                {
                    lblMensaje.Text = "Emprendimiento evaluado con exito";
                    BindData();
                }
                else
                {
                    lblError.Text = "Error al evaluar emprendimiento: " + idEmprend;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;                
            }
            
        }

        protected void ddlEmprendimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                lblError.Text = string.Empty;
                
                int idEmprend = int.Parse(ddlEmprendimientos.SelectedValue);
                if (idEmprend.ToString() != "NA")
                {
                    lblId.Text = idEmprend.ToString();
                    lblId.Visible = true;
                    lblTitulo.Text = emprendimientos.Find(x => x.Id == idEmprend).Titulo;
                    lblTitulo.Visible = true;
                    lblDescripcion.Text = emprendimientos.Find(x => x.Id == idEmprend).Descripcion;
                    lblDescripcion.Visible = true;

                    txtPuntaje.Visible = true;
                    txtJustificacion.Visible = true;
                }

            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }           
        }
    }
}