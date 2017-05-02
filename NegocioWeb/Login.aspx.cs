using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = Usuario.BuscarUsuario(txtEmail.Text, txtContrasenia.Text);

            if (user != null)
            {
                lblMensaje.Text = "Se ha logueado el usuario " + user.Email + " con el rol " + user.Rol;
                Session["usuario"] = user;
            }
            else
            {
                lblError.Text = "Usuario o contraseña erroneos";
            }
            txtEmail.Text = string.Empty;
        }
    }
}