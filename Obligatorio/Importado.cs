using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Importado : Material
    {
        private string paisOrigen;
        private static double recargo;


        public double Recargo
        {
            get { return recargo; }
            set { recargo = value; }
        }


        public string PaisOrigen
        {
            get { return paisOrigen; }
            set { paisOrigen = value; }
        }


        public Importado(string Nombre, double Peso, double CostoCompra, string NombreEmpresa, string PaisOrigen, double Recargo)
            : base(Nombre, Peso, CostoCompra, NombreEmpresa)
        {
            paisOrigen = PaisOrigen;
            recargo = Recargo;
        }


        public override double CalcularPrecioVenta()
        {
            throw new NotImplementedException();
        }
    }
}
