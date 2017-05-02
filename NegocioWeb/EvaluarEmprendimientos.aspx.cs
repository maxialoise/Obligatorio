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
            if (emprendimientos == null || emprendimientos.Count <= 0)
            {
                lblAvisoEmpren.Text = "No hay Emprendimientos para Evaluar";
                LimpiarYOcultar();
            }
            else
            {
                LimpiarYOcultar();
                ddlEmprendimientos.DataSource = emprendimientos;
                ddlEmprendimientos.DataTextField = "Titulo";
                ddlEmprendimientos.DataValueField = "Id";
                ddlEmprendimientos.DataBind();
                ddlEmprendimientos.Items.Insert(0, new ListItem("Seleccione un emprendimiento", "NA"));
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                lblError.Text = string.Empty;
                int puntaje = int.Parse(txtPuntaje.Text);
                if (puntaje >=0  && puntaje <= 4)
                {
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
                else
                {
                    lblError.Text = "El puntaje ingresado debe de estar en el rango de 0 a 4, valor ingresado: " + puntaje;
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
                    lblId.Text = "Id: " + idEmprend.ToString();
                    lblId.Visible = true;
                    lblTitulo.Text = "Título: " + emprendimientos.Find(x => x.Id == idEmprend).Titulo;
                    lblTitulo.Visible = true;
                    lblDescripcion.Text = "Descripción: " + emprendimientos.Find(x => x.Id == idEmprend).Descripcion;
                    lblDescripcion.Visible = true;
                    lblTiempoPrevisto.Text = "Tiempo Previsto: " + emprendimientos.Find(x => x.Id == idEmprend).TiempoPrevisto;
                    lblTiempoPrevisto.Visible = true;
                    lblCosto.Text = "Costo: " + emprendimientos.Find(x => x.Id == idEmprend).Costo;
                    lblCosto.Visible = true;

                    txtPuntaje.Visible = true;
                    txtJustificacion.Visible = true;
                    lblPuntaje.Visible = true;
                    lblJustificacion.Visible = true;
                }

            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }
        }

        private void LimpiarYOcultar()
        {
            try
            {
                lblId.Text = string.Empty;
                lblId.Visible = false;
                lblTitulo.Text = string.Empty;
                lblTitulo.Visible = false;
                lblDescripcion.Text = string.Empty;
                lblDescripcion.Visible = false;
                lblTiempoPrevisto.Text = string.Empty;
                lblTiempoPrevisto.Visible = false;
                lblCosto.Text = string.Empty;
                lblCosto.Visible = false;

                txtPuntaje.Visible = false;
                txtJustificacion.Visible = false;
                lblPuntaje.Visible = false;
                lblJustificacion.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}