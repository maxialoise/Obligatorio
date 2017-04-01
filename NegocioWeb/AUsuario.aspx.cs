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
            Usuario user = new Usuario();
            user.Email = txtEmail.Text;
            user.Password = txtContrasenia.Text;
            user.Rol = ddlRol.SelectedValue;

            if (user.AltaUsuario())
                lblMensaje.Text = "Alta exitosa";
            else
                lblMensaje.Text = "Error";
        }
    }
}