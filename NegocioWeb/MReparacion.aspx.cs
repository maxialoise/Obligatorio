using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class MReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlReparaciones.DataSource = EmpresaNaviera.GetInstance().ReparacionesPendientes();
                ddlReparaciones.DataTextField = "NombreEmbarcacion";
                ddlReparaciones.DataValueField = "CodigoEmbarcacion";
                ddlReparaciones.DataBind();

                cbMecanicos.DataSource = EmpresaNaviera.GetInstance().BuscarMecanicoSinAsig();
                cbMecanicos.DataTextField = "Nombre";
                cbMecanicos.DataValueField = "NumRegistro";
                cbMecanicos.DataBind();

                ddlMateriales.DataSource = EmpresaNaviera.GetInstance().Materiales;
                ddlMateriales.DataTextField = "Nombre";
                ddlMateriales.DataValueField = "Nombre";
                ddlMateriales.DataBind();

                ddlCantidad.DataSource = Enumerable.Range(1, 15);
                ddlCantidad.DataBind();

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidad = ddlCantidad.SelectedItem.Text;
            string material = ddlMateriales.SelectedItem.Text;
            lstSeleccion.Items.Add(material + "-" + cantidad);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

        }
    }
}