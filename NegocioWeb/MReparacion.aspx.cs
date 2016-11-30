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
        static List<Dictionary<string, int>> map = new List<Dictionary<string, int>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = int.Parse(ddlCantidad.SelectedItem.Text);
                string material = ddlMateriales.SelectedItem.Text;
                Dictionary<string, int> dicc = new Dictionary<string, int>();
                dicc.Add(material, cantidad);
                map.Add(dicc);
                lstSeleccion.Items.Add(material + " - " + cantidad);
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
                int codigo = int.Parse(ddlReparaciones.SelectedValue);

                List<string> numRegMecanico = new List<string>();

                for (int i = 0; i < cbMecanicos.Items.Count; i++)
                {
                    if (cbMecanicos.Items[i].Selected)
                    {
                        numRegMecanico.Add(cbMecanicos.Items[i].Value);
                    }
                }

                bool result = EmpresaNaviera.GetInstance().ModificacionDeReparacion(codigo, numRegMecanico, map);

                if (result)
                {
                    lblError.Text = "Modificacion exitosa";
                }
                else
                {
                    lblError.Text = "Error al realizar modificacion";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}