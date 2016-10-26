using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        private int cantidad;
        private Material material;

        public Material Material
        {
            get { return material; }
            set { material = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public Producto(int Cantidad, Material Material)
        {
            cantidad = Cantidad;
            material = Material;
        }
    }
}
