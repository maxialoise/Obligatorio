using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mecanico
    {
        private string nombre;
        private string telefono;
        private string numRegistro;
        private Direccion direccion;
        private double precioJornal;
        private bool tieneCapExtra;

        public bool TieneCapExtra
        {
            get { return tieneCapExtra; }
            set { tieneCapExtra = value; }
        }

        public double PrecioJornal
        {
            get { return precioJornal; }
            set { precioJornal = value; }
        }

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string NumRegistro
        {
            get { return numRegistro; }
            set { numRegistro = value; }
        }

        public Mecanico(string Nombre, string Telefono, string NumRegistro, string Calle, string NumPuerta, string Ciudad, double PrecioJornal, bool TieneCapExtra)
        {
            direccion = new Direccion(Calle, NumPuerta, Ciudad);
            nombre = Nombre;
            telefono = Telefono;
            numRegistro = NumRegistro;
            precioJornal = PrecioJornal;
            tieneCapExtra = TieneCapExtra;
        }


    }
}
