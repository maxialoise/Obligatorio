using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Importado : Material
    {
        #region Atributos
        private string paisOrigen;
        private static double recargo = 100;
        #endregion

        #region Propiedades
        public static double Recargo
        {
            get { return recargo; }
            set { recargo = value; }
        }

        public string PaisOrigen
        {
            get { return paisOrigen; }
            set { paisOrigen = value; }
        }
        #endregion

        #region Constructor
        public Importado(string Nombre, double Peso, double CostoCompra, string NombreEmpresa, string PaisOrigen)
            : base(Nombre, Peso, CostoCompra, NombreEmpresa)
        {
            paisOrigen = PaisOrigen;
        }
        #endregion

        #region Metodos
        //REALIZA EL CALCULO ESPECIFICO PARA EL COSTO DE COMPRA DEPENDIENTO DEL PAIS DE ORIGEN.
        public override double CalcularPrecioVenta()
        {
            double d;
            if (paisOrigen == "argentina" || paisOrigen == "brasil")
            {
                d = base.CostoCompra * 1.2 + recargo;
            }
            else
            {
                d = base.CostoCompra * 1.3 + recargo;
            }
            return d;
        }
        #endregion
    }
}
