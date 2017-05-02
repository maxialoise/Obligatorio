using Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioWeb
{
    public partial class GenerarTxt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Emprendimiento> lista = new List<Emprendimiento>();

                ServiceReference1.EmprendimientosClient cliente = new ServiceReference1.EmprendimientosClient();

                if (cliente.ObtenerEmprendimientos() != null)
                {
                    foreach (var emp in cliente.ObtenerEmprendimientos())
                    {
                        Emprendimiento empr = new Emprendimiento();
                        empr.Id = emp.Id;
                        empr.Titulo = emp.Titulo;
                        empr.Costo = emp.Costo;
                        empr.TiempoPrevisto = emp.TiempoPrevisto;
                        empr.PuntajeFinal = emp.PuntajeFinal;
                        string integrantes = "";
                        string evaluadores = "";

                        foreach (var integrante in emp.Intregrantes)
                        {
                            integrantes += integrante.Nombre + ", ";
                        }
                        foreach (var evaluador in emp.Evaluadores)
                        {
                            evaluadores += evaluador.NombreEvaluador + " " + evaluador.Justificacion + ", ";
                        }

                        empr.Descripcion = "Integrantes: " + integrantes + " Evaluadores: " + evaluadores;
                        lista.Add(empr);
                    }

                    string path = @"D:\ListaEmprendimientos.txt";

                    if (!File.Exists(path))
                        File.Create(path).Dispose();

                    using (TextWriter tw = new StreamWriter(path))
                    {
                        foreach (var emp in lista)
                        {
                            tw.WriteLine(emp.Id + "#" + emp.Titulo + "#" + emp.Costo + "#" + emp.TiempoPrevisto + "#" + emp.PuntajeFinal + "#" + emp.Descripcion + ".");
                        }
                        tw.Close();
                        lblMensaje.Text = "Archivo creado correctamente en: " + path;
                    }
                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error generando txt";
            }

        }
    }
}