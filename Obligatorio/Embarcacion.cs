using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Embarcacion
    {
        #region Atributos
        private int codigo;
        private static int ultimoCodigo = 0;
        private string nombre;
        private DateTime fechaConstruccion;
        private string tipoMotor;
        #endregion

        #region Propiedades
        public string TipoMotor
        {
            get { return tipoMotor; }
            set { tipoMotor = value; }
        }
        public DateTime FechaConstruccion
        {
            get { return fechaConstruccion; }
            set { fechaConstruccion = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        #endregion

        #region Constructor
        public Embarcacion()
        {
            ultimoCodigo++;
        }
        public Embarcacion(int Codigo, string Nombre, DateTime FechaConstruccion, string TipoMotor)
        {
            codigo = Codigo;
            nombre = Nombre;
            fechaConstruccion = FechaConstruccion;
            tipoMotor = TipoMotor;
            ultimoCodigo++;
        }
        #endregion
    }
}
