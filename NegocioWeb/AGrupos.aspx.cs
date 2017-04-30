using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace NegocioWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Persona> integrantes = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            integrantes = new List<Persona>();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNom.Text;
                string cedula = txtCedula.Text;
                string email = txtEmail.Text;
                integrantes.Add(new Persona());
                lstSeleccion.Items.Add(material + " - " + cantidad);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

        }
    }
}