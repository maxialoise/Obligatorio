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
            if (this.txtUsuario.Text == "" || this.txtContrasenia.Text == "")
            {
                lblMensaje.Text = "Debe ingresar usuario y contraseña";
            }
            else
            {
                Usuario usu = EmpresaNaviera.GetInstance().Login(this.txtUsuario.Text, this.txtContrasenia.Text);

                if (usu == null)
                {
                    lblMensaje.Text = "El usuario o la contraseña ingresados no son correctos";
                }
                else
                {
                    lblMensaje.Text = "¡Bienvenido " + usu.NombreUsu + "!";
                    Session["usuario"] = usu;
                }
            }
        }
    }
}