using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class LMecanicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Mecanico> lista = EmpresaNaviera.GetInstance().Mecanicos;
                lista.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));
                CargarMecanicos(lista);
            }
        }

        private void CargarMecanicos(List<Mecanico> lista)
        {
            grvMecanicos.DataSource = lista;
            grvMecanicos.DataBind();
        }
    }
}