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
                string pass = txtPassword.Text;
                integrantes.Add(new Persona { Nombre = nombre, Cedula = cedula, Email = email, Usuario = new Usuario {Email = email,
                   Rol = "Postulante", Password = pass}  });
                lstSeleccion.Items.Add(nombre);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            integrantes.Clear();
            lstSeleccion.Items.Clear();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (integrantes != null && integrantes.Count > 0)
                {
                    string titulo = txtTitulo.Text;
                    string desc = txtDescripcion.Text;
                    Emprendimiento empr = new Emprendimiento { Titulo = titulo, Descripcion = desc };
                    //alta empre

                    foreach (var integrante in integrantes)
                    {
                        integrante.Usuario.AltaUsuario();
                        //integrante.AltaPersona(empr.Id);                        
                    }
                   
                    //if (result)
                    //{
                    //    //LimpiarListBox();
                    //    lblError.Text = "Creacion exitosa";
                    //}
                    //else
                    //{
                    //    lblError.Text = "Error al Crear";
                    //}

                }
                else
                {
                    lblError.Text = "Debe Agragar algun Participante";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}