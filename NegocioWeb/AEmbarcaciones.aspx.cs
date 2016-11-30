using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class AEmbarcaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != 0) 
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                //FALTAN CREAR LOS VALIDADORES DE COSO
                string nombre = txtNombre.Text;
                string tipoMotor = txtTipoMotor.Text;
                DateTime fechaConstruccion = new DateTime();
                fechaConstruccion = DateTime.Parse(txtFecha.Text);

                if (fechaConstruccion > DateTime.Now)
                {
                    lblError.Text = "Error en el ingreso de la fecha";
                    return;
                }

                bool ok = EmpresaNaviera.GetInstance().AltaEmbarcacion(nombre, fechaConstruccion, tipoMotor);

                if (ok)
                    lblError.Text = "Alta exitosa";
                else
                    lblError.Text = "Ocurrió un error";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}