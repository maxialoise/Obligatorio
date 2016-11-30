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
        private static List<Dictionary<string, int>> map = new List<Dictionary<string, int>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = Session["usuario"] as Usuario;

                if (usu == null || usu.Rol != 0)
                {
                    Response.Redirect("Login.aspx");
                }

                if (!IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error en carga de pagina";
            }
        }

        private void BindData()
        {
            List<Reparacion> repPendientes = EmpresaNaviera.GetInstance().ReparacionesPendientes();

            if (repPendientes.Count <= 0)
            {
                lblAviso.Text = "No hay Embarcaciones en reparacion";
            }
            ddlReparaciones.DataSource = repPendientes;
            ddlReparaciones.DataTextField = "NombreEmbarcacion";
            ddlReparaciones.DataValueField = "CodigoEmbarcacion";
            ddlReparaciones.DataBind();

            

            cbMecanicos.DataSource = EmpresaNaviera.GetInstance().BuscarMecanicosSinAsig();
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
                if (map.Count > 0)
                {
                    int codigo = int.Parse(ddlReparaciones.SelectedValue);
                    bool mecanicoSeleccionado = false;

                    List<string> numRegMecanico = new List<string>();

                    for (int i = 0; i < cbMecanicos.Items.Count; i++)
                    {
                        if (cbMecanicos.Items[i].Selected)
                        {
                            mecanicoSeleccionado = true;
                            numRegMecanico.Add(cbMecanicos.Items[i].Value);
                        }
                    }
                    if (mecanicoSeleccionado)
                    {
                        bool result = EmpresaNaviera.GetInstance().ModificacionDeReparacion(codigo, numRegMecanico, map);

                        if (result)
                        {
                            LimpiarListBox();
                            BindData();
                            lblError.Text = "Modificacion exitosa";
                        }
                        else
                        {
                            lblError.Text = "Error al realizar modificacion";
                        }
                    }
                    else
                    {
                        lblError.Text = "Se debe asignar algun mecanico";
                    }                   
                }
                else
                {
                    lblError.Text = "Debe seleccionar algun material";
                }
              
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void LimpiarListBox()
        {
            map.Clear();
            lstSeleccion.Items.Clear();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarListBox();
        }
    }
}