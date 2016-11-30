using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class AMateriales : System.Web.UI.Page
    {
        bool seIngresoAlgunMaterial = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = Session["usuario"] as Usuario;

            if (usu == null || usu.Rol != 0)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                divNacional.Visible = false;
                divImportado.Visible = true;
            }
        }

        protected void ddTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (ddTipo.SelectedValue)
                {
                    case "Nacional":
                        divNacional.Visible = true;
                        divImportado.Visible = false;
                        break;
                    case "Importado":
                        divNacional.Visible = false;
                        divImportado.Visible = true;
                        break;
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
                seIngresoAlgunMaterial = true;
                string nombre = txtNombre.Text;
                double peso = double.Parse(txtPeso.Text);
                double costoCompra =  double.Parse(txtCostoCompra.Text);
                string nombreEmpresa = txtNombreEmp.Text;
                bool ok = false;

                switch (ddTipo.SelectedValue)
                {
                    case "Nacional":
                        int aniosPlaza = int.Parse(txtAnioPlaza.Text);
                        double costoFijo = double.Parse(txtCostoFijo.Text);
                        ok = EmpresaNaviera.GetInstance().AltaMaterial(nombre, peso, costoCompra, nombreEmpresa, aniosPlaza, costoFijo);
                        break;
                    case "Importado":
                        string paisOrigen = txtPais.Text;
                        ok = EmpresaNaviera.GetInstance().AltaMaterial(nombre, peso, costoCompra, nombreEmpresa, paisOrigen);
                        break;
                }
                if (ok)
                {
                    lblError.Text = "Alta de material correcta";
                }
                else
                {
                    lblError.Text = "Ya existe el material " + nombre + ", favor de ingresar otro nombre";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtCostoCompra.Text = string.Empty;
            txtNombreEmp.Text = string.Empty;
            txtAnioPlaza.Text = string.Empty;
            txtCostoFijo.Text = string.Empty;
            txtPais.Text = string.Empty;
        }
    }
}
