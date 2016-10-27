using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        #region Atributos
        private int cantidad;
        private Material material;
        #endregion

        #region Propiedades
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
        #endregion

        #region Constructor
        public Producto(int Cantidad, Material Material)
        {
            cantidad = Cantidad;
            material = Material;
        }
        #endregion
    }
}
