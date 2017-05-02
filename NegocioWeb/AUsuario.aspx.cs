using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace NegocioWeb
{
    public partial class AUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtContrasenia.Text;
            string rol = ddlRol.SelectedValue;
            string nombre = txtNombre.Text;
            string cedula = txtCedula.Text;

            if (rol == "Admin")
            {
                Persona pers = new Persona { Nombre = nombre, Cedula = cedula, Email = email, Usuario = new Usuario { Email = email, Password = password, Rol = rol } };
                if (pers.AltaPersona())
                    lblMensaje.Text = "Alta Admin exitosa";
                else
                    lblMensaje.Text = "Error";
            }
            else
            {
                int calif = 0;    
                if (int.TryParse(txtCalif.Text, out calif))
                {
                    Evaluador eval = new Evaluador { Nombre = nombre, Cedula = cedula, Email = email, Telefono = txtTel.Text, Calificacion = calif, Usuario = new Usuario { Email = email, Password = password, Rol = rol } };
                    if (eval.AltaEvaluador())
                        lblMensaje.Text = "Alta evaluador exitosa";
                    else
                        lblMensaje.Text = "Error";
                }
                else
                {
                    lblError.Text = "La calificacion debe ser un entero";
                }
                
            } 
            
           
        }

        private void MostrarOcultar(bool visible)
        {
            txtCalif.Visible = visible;
            lblCalif.Visible = visible;
            txtTel.Visible = visible;
            lblTel.Visible = visible;

        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex == 0)
            {
                MostrarOcultar(false);
            }
            else
            {
                MostrarOcultar(true);
            }
        }
    }
}