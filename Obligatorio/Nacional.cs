using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacional : Material
    {
        #region Atributos
        private int aniosPlaza;
        private double costoFijo;
        #endregion

        #region Propiedades
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
        #endregion

        #region Constructor
        public Nacional(string Nombre, double Peso, double CostoCompra, string NombreEmpresa, int AniosPlaza, double CostoFijo) : base(Nombre, Peso, CostoCompra, NombreEmpresa)
        {
            aniosPlaza = AniosPlaza;
            costoFijo = CostoFijo;
        }
        #endregion

        #region Metodos
        //REALIZA EL CALCULO ESPECIFICO PARA EL COSTO DE COMPRA DEPENDIENTO DE LOS AÑOS EN PLAZA Y SU COSTO FIJO
        public override double CalcularPrecioVenta()
        {
            return base.CostoCompra + (aniosPlaza * costoFijo);
        }
        #endregion
    }
}
