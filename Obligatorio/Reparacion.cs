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
        private DateTime fechaPrometidaEngreso;
        private DateTime fechaRealEngreso;
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
        public DateTime FechaPrometidaEngreso
        {
            get { return fechaPrometidaEngreso; }
            set { fechaPrometidaEngreso = value; }
        }
        public DateTime FechaRealEngreso
        {
            get { return fechaRealEngreso; }
            set { fechaRealEngreso = value; }
        }
        #endregion

        #region Constructor
        public Reparacion(DateTime FechaIngreso, DateTime FechaPrometidaEngreso, DateTime FechaRealEngreso, Embarcacion Embarcacion, List<Mecanico> Mecanicos)
        {

            fechaIngreso = FechaIngreso;
            fechaPrometidaEngreso = FechaPrometidaEngreso;
            fechaRealEngreso = FechaRealEngreso;
            embarcacion = Embarcacion;
            mecanicos = Mecanicos;

        }
        #endregion

        #region Metodos
        
        public double CalcularCosto()
        {
            double resultado = 0;
            foreach (Producto p in productos)
            {
                resultado += p.Material.CalcularPrecioVenta() * p.Cantidad;
            }
            return CalcularManoDeObra() + resultado;
        }
        //Calcula el costo total de mano de obra de una reparaciónn.
        public double CalcularManoDeObra()
        {
            double d = 0;
            double costoTotalJornal = 0;
            TimeSpan dias = fechaRealEngreso - fechaIngreso;

            foreach (Mecanico m in mecanicos)
            {
                costoTotalJornal += m.PrecioJornal;
            }

            d = dias.Days * costoTotalJornal;
            return d;
        }
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
