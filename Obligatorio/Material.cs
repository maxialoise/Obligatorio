using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Material
    {
        #region Atributos
        private string nombre;
        private double peso;
        private double costoCompra;
        private string nombreEmpresa;
        #endregion

        #region Propiedades
        public string NombreEmpresa
        {
            get { return nombreEmpresa; }
            set { nombreEmpresa = value; }
        }

        public double CostoCompra
        {
            get { return costoCompra; }
            set { costoCompra = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        #region Constructor
        public Material(string Nombre, double Peso, double CostoCompra, string NombreEmpresa)
        {
            nombre = Nombre;
            peso = Peso;
            costoCompra = CostoCompra;
            nombreEmpresa = NombreEmpresa;
        }
        #endregion

        #region Métodos
        //MÉTODO ABSTRACTO EL CUAL SE UTILIZARA EN LA CLASES HEREDADAS PARA REALIZAR SUS CORRESPONDIENTES CALCULOS.
        public abstract double CalcularPrecioVenta();
        #endregion
    }
}
