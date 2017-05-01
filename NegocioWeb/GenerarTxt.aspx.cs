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
            List<Emprendimiento> lista = new List<Emprendimiento>();
            //Llamar WCF 
            ServiceReference1.EmprendimientosClient cliente = new ServiceReference1.EmprendimientosClient();
            foreach (var emp in cliente.ObtenerEmprendimientos())
            {
                lista.Add(new Emprendimiento { Id = emp.Id, Titulo = emp.Titulo, Costo = emp.Costo, TiempoPrevisto = emp.TiempoPrevisto, Descripcion = emp.Descripcion, PuntajeFinal = emp.PuntajeFinal });
            }


            // Generar TXT
            string path = @"E:\AppServ\Example.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (var emp in lista)
                {
                    tw.WriteLine(emp.Id + "#" + emp.Titulo + "#" + emp.Costo + "#" + emp.TiempoPrevisto + "#" + emp.PuntajeFinal + "#" + emp.Descripcion + ".");
                }
                tw.Close();
            }
        }
    }
}