using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace NegocioWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Mecanico mec1 = new Mecanico("pedro perez", "555-1234", "0001", "ellauri", "1234", "montevideo", 900, false);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec1);
            Mecanico mec2 = new Mecanico("juan santos", "555-4321", "1101", "yi", "605", "montevideo", 1200, true);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec2);
            Mecanico mec3 = new Mecanico("pepe ramoz", "555-1423", "9424", "san jose", "3003", "montevideo", 1000, true);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec3);
            Mecanico mec4 = new Mecanico("diego garcia", "555-3241", "6452", "cuareim", "6056", "montevideo", 1000, false);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec4);

            Embarcacion emb1 = new Embarcacion("emb1", new DateTime(2016, 09, 20), "fuera de borda");
            EmpresaNaviera.GetInstance().Embarcaciones.Add(emb1);
            Embarcacion emb2 = new Embarcacion("emb2", new DateTime(2016, 09, 19), "otros");
            EmpresaNaviera.GetInstance().Embarcaciones.Add(emb2);
            Embarcacion emb4 = new Embarcacion("emb4", new DateTime(2016, 09, 22), "acoplado");
            EmpresaNaviera.GetInstance().Embarcaciones.Add(emb4);
            Embarcacion emb3 = new Embarcacion("emb3", new DateTime(2016, 09, 19), "otros");
            EmpresaNaviera.GetInstance().Embarcaciones.Add(emb3);

            Material material1 = new Nacional("madera", 600, 200, "La madera feliz", 15, 50);
            EmpresaNaviera.GetInstance().Materiales.Add(material1);
            Material material2 = new Nacional("piedra", 2000, 400, "Rocky Balboa", 10, 100);
            EmpresaNaviera.GetInstance().Materiales.Add(material2);
            Material material3 = new Nacional("parafina", 900, 150, "Surf & Go", 2, 60);
            EmpresaNaviera.GetInstance().Materiales.Add(material3);
            Material material4 = new Importado("acero", 7000, 800, "El dulce acero", "argentina");
            EmpresaNaviera.GetInstance().Materiales.Add(material4);
            Material material5 = new Importado("bronce", 7100, 600, "bronceV", "brasil");
            EmpresaNaviera.GetInstance().Materiales.Add(material5);
            Material material6 = new Importado("cobre", 8500, 900, "Rocky Balboa", "paraguay");
            EmpresaNaviera.GetInstance().Materiales.Add(material6);
        }
    }
}