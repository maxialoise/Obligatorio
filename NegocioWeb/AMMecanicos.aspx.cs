using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class AMMecanicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != 0)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                divBuscar.Visible = false;
                btnModificar.Visible = false;
            }
        }

        protected void ddlOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (ddlOpcion.SelectedValue)
                {
                    case "Alta":
                        divBuscar.Visible = false;
                        btnModificar.Visible = false;
                        btnIngresar.Visible = true;
                        break;
                    case "Modificacion":
                        divBuscar.Visible = true;
                        btnIngresar.Visible = false;
                        btnModificar.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Mecanico mecanico = EmpresaNaviera.GetInstance().BuscarMecanico(txtBuscarReg.Text);
                if (mecanico != null)
                {
                    txtNombre.Text = mecanico.Nombre;
                    txtTelefono.Text = mecanico.Telefono;
                    txtCalle.Text = mecanico.Direccion.Calle;
                    txtNumPuerta.Text = mecanico.Direccion.NumPuerta;
                    txtCiudad.Text = mecanico.Direccion.Ciudad;
                    txtNumRegistro.Text = mecanico.NumRegistro;
                    txtPrecioJornal.Text = mecanico.PrecioJornal.ToString();
                    cbCapExtra.Checked = mecanico.TieneCapExtra;
                }
                else
                {
                    lblError.Text = "No existe el mecanioco para el numero de registro : " + txtBuscarReg.Text;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                string calle = txtCalle.Text;
                string numPuerta = txtNumPuerta.Text;
                string ciudad = txtCiudad.Text;
                string numRegistro = txtNumRegistro.Text;
                string jornal = txtPrecioJornal.Text;
                double precioJornal = 0;
                if (!double.TryParse(jornal, out precioJornal))
                {
                    lblError.Text = "Error en el ingreso del jornal";
                    return;
                }
                if (precioJornal < 0)
                {
                    lblError.Text = "Error en el ingreso del jornal(jornal menor a 0)";
                    return;
                }
                bool tieneCapExtra = cbCapExtra.Checked;
                bool ok = EmpresaNaviera.GetInstance().AltaMecanico(nombre, telefono, calle, numPuerta, ciudad, numRegistro, precioJornal, tieneCapExtra);
                if (ok)
                {
                    lblError.Text = "Alta exitosa";
                    btnLimpiar_Click(null, null);
                }
                else
                    lblError.Text = "Ocurrió un error";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                string calle = txtCalle.Text;
                string numPuerta = txtNumPuerta.Text;
                string ciudad = txtCiudad.Text;
                string numRegistro = txtNumRegistro.Text;
                string jornal = txtPrecioJornal.Text;
                string oldNum = txtBuscarReg.Text;
                double precioJornal = 0;
                if (!double.TryParse(jornal, out precioJornal))
                {
                    lblError.Text = "Error en el ingreso del jornal";
                    return;
                }
                if (precioJornal < 0)
                {
                    lblError.Text = "Error en el ingreso del jornal(jornal menor a 0)";
                    return;
                }
                bool tieneCapExtra = cbCapExtra.Checked;
                bool ok = EmpresaNaviera.GetInstance().ModificacionMecanico(nombre, telefono, calle, numPuerta, ciudad, numRegistro, precioJornal, tieneCapExtra, oldNum);
                if (ok)
                {
                    lblError.Text = "Modificacion exitosa";
                    btnLimpiar_Click(null, null);
                }
                else
                    lblError.Text = "Ocurrió un error";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtNumPuerta.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtNumRegistro.Text = string.Empty;
            txtPrecioJornal.Text = string.Empty;
            cbCapExtra.Checked = false;
            txtBuscarReg.Text = string.Empty;
        }
    }
}