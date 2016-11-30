using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reparacion
    {
        #region Atributos
        private DateTime fechaIngreso;
        private DateTime fechaPrometidaEgreso;
        private DateTime ?fechaRealEngreso;
        private List<Producto> productos;
        private Embarcacion embarcacion;
        private List<Mecanico> mecanicos;
        #endregion

        #region Propiedades
        public List<Mecanico> Mecanicos
        {
            get { return mecanicos; }
            set { mecanicos = value; }
        }
        public Embarcacion Embarcacion
        {
            get { return embarcacion; }
            set { embarcacion = value; }
        }
        public string NombreEmbarcacion
        {
            get { return embarcacion.Nombre; }
        }

        public int CodigoEmbarcacion
        {
            get { return embarcacion.Codigo; }
        }

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        public DateTime FechaPrometidaEgreso
        {
            get { return fechaPrometidaEgreso; }
            set { fechaPrometidaEgreso = value; }
        }
        public DateTime ?FechaRealEngreso
        {
            get { return fechaRealEngreso; }
            set { fechaRealEngreso = value; }
        }
        #endregion

        #region Constructor
        public Reparacion(DateTime FechaIngreso, DateTime FechaPrometidaEngreso, DateTime FechaRealEngreso, Embarcacion Embarcacion, List<Mecanico> Mecanicos)
        {
            fechaIngreso = FechaIngreso;
            fechaPrometidaEgreso = FechaPrometidaEngreso;
            fechaRealEngreso = FechaRealEngreso;
            embarcacion = Embarcacion;
            mecanicos = Mecanicos;
            productos = new List<Producto>();
        }

        public Reparacion(DateTime FechaIngreso, DateTime FechaPrometidaEngreso, Embarcacion Embarcacion)
        {
            fechaIngreso = FechaIngreso;
            fechaPrometidaEgreso = FechaPrometidaEngreso;
            embarcacion = Embarcacion;
            fechaRealEngreso = null;
            mecanicos = new List<Mecanico>();
            productos = new List<Producto>();
        }
        #endregion

        #region Metodos
        //CALCULO PARA EL COSTO TOTAL DE UNA REPARACIÓN.
        public double CalcularCosto()
        {
            double resultado = 0;
            foreach (Producto p in productos)
            {
                resultado += p.Material.CalcularPrecioVenta() * p.Cantidad;
            }
            return CalcularManoDeObra() + resultado;
        }
        //CALCULO DEL COSTO TOTAL DE MANO DE OBRA MULTIPLICANDO LA CANTIDAD DE DIAS EL CUAL ESTUVO ESA REPARACIÓN
        //POR EL COSTO DEL JORNAL DE TODOS LOS MECANICOS.
        public double CalcularManoDeObra()
        {
            double d = 0;
            double costoTotalJornal = 0;
            TimeSpan dias = Convert.ToDateTime(fechaRealEngreso) - fechaIngreso;

            foreach (Mecanico m in mecanicos)
            {
                costoTotalJornal += m.PrecioJornal;
            }

            d = dias.Days * costoTotalJornal;
            return d;
        }
        //REALIZA LA CREACION DE UN PRODUCTO QUE CONTIENE LA CANTIDAD DE MATERIALES UTILIZADOS PARA LA REPARACIÓN.
        public bool AltaProducto(int cantidad, Material material)
        {
            bool d = false;
            Producto p = new Producto(cantidad, material);
            productos.Add(p);
            return d;
        }
        #endregion
    }
}
