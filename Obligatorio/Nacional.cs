using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacional : Material
    {
        private int aniosPlaza;
        private double costoFijo;

        public double CostoFijo
        {
            get { return costoFijo; }
            set { costoFijo = value; }
        }


        public int AniosPlaza
        {
            get { return aniosPlaza; }
            set { aniosPlaza = value; }
        }

        public Nacional(string Nombre, double Peso, double CostoCompra, string NombreEmpresa, int AniosPlaza, double CostoFijo): base(Nombre, Peso, CostoCompra, NombreEmpresa)
        {
            aniosPlaza = AniosPlaza;
            costoFijo = CostoFijo;
        }


        public override double CalcularPrecioVenta()
        {
            return base.CostoCompra + (aniosPlaza * costoFijo);
        }
    }
}
