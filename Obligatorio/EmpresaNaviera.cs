using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EmpresaNaviera
    {
        #region Atributos
        private List<Mecanico> mecanicos;
        private List<Embarcacion> embarcaciones;
        private List<Reparacion> reparaciones;
        private List<Material> materiales;
        #endregion

        #region Propiedades
        public List<Material> Materiales
        {
            get { return materiales; }
            set { materiales = value; }
        }
        public List<Reparacion> Reparaciones
        {
            get { return reparaciones; }
            set { reparaciones = value; }
        }
        public List<Embarcacion> Embarcaciones
        {
            get { return embarcaciones; }
            set { embarcaciones = value; }
        }
        public List<Mecanico> Mecanicos
        {
            get { return mecanicos; }
            set { mecanicos = value; }
        }
        #endregion

        #region Singleton
        private static EmpresaNaviera instancia = null;
        public static EmpresaNaviera GetInstance()
        {
            if (instancia == null)
            {
                instancia = new EmpresaNaviera();
            }
            return instancia;
        }
        private EmpresaNaviera()
        {

        }
        #endregion

        #region MetodosPublicos
        public bool AltaMecanico(string nombre, string telefono, string calle, string numPuerta, string ciudad, string numRegistro, double precioJornal, bool tieneCapExtra)
        {
            bool exito = false;
            if (!ExisteMecanico(numRegistro))
            {
                mecanicos.Add(new Mecanico(nombre, telefono, calle, numPuerta, ciudad, numRegistro, precioJornal, tieneCapExtra));
                exito = true;
            }
            return exito;
        }
        public bool AltaMaterial(string nombre, double peso, double costoCompra, string nombreEmpresa, string paisOrigen)
        {
            bool exito = false;
            if (!ExisteMaterial(nombre))
            {
                materiales.Add(new Importado(nombre, peso, costoCompra, nombreEmpresa, paisOrigen));
                exito = true;
            }
            return exito;
        }
        public bool AltaMaterial(string nombre, double peso, double costoCompra, string nombreEmpresa, int aniosPlaza, double costoFijo)
        {
            bool exito = false;
            if (!ExisteMaterial(nombre))
            {
                materiales.Add(new Nacional(nombre, peso, costoCompra, nombreEmpresa, aniosPlaza, costoFijo));
                exito = true;
            }
            return exito;
        }
        public bool AltaEmbarcacion(int codigo, string nombre, DateTime fechaConstruccion, string tipoMotor)
        {
            bool exito = false;
            if (!ExisteEmbarcacion(codigo))
            {
                embarcaciones.Add(new Embarcacion(codigo, nombre, fechaConstruccion, tipoMotor));
                exito = true;
            }
            return exito;
        }
        public bool AltaReparacion(DateTime fechaIngreso, DateTime fechaPrometidaEngreso, DateTime fechaRealEngreso, int cantidad, Material material, Embarcacion embarcacion, List<Mecanico> mecanicos)
        {
            bool exito = false;
            Reparacion rep = UltimaReparacionDeEmbarcacion(embarcacion.Codigo);
            if (fechaIngreso <= fechaPrometidaEngreso && fechaIngreso <= fechaRealEngreso)
            {
                if (rep != null)
                {
                    //controlar que la fechaRealEgreso de la ultima rep sea menor a fecha ingreso
                    if (rep.FechaRealEngreso <= fechaIngreso)
                    {
                        reparaciones.Add(new Reparacion(fechaIngreso, fechaPrometidaEngreso, fechaRealEngreso, embarcacion, mecanicos));
                        exito = true;
                    }
                }
                else
                {
                    reparaciones.Add(new Reparacion(fechaIngreso, fechaPrometidaEngreso, fechaRealEngreso, embarcacion, mecanicos));
                    exito = true;
                }
            }
            return exito;
        }
        public List<Reparacion> ReparacionesDeEmbarcacion(int codigoEmb)
        {
            List<Reparacion> reps = null;
            foreach (Reparacion r in reparaciones)
            {
                if (r.Embarcacion.Codigo == codigoEmb)
                {
                    reps.Add(r);
                }
            }
            return reps;
        }
        public List<Mecanico> BuscarMecanicosSinCapExtra()
        {
            List<Mecanico> list = null;

            foreach (Mecanico mec in mecanicos)
            {
                if (!mec.TieneCapExtra)
                {
                    list.Add(mec);
                }
            }
            return list;
        }
        public void EstablecerRecargo(double valor)
        {
            Importado.Recargo = valor;
        }
        #endregion

        #region MetodosPrivados
        private bool ExisteMecanico(string numRegistro)
                {
                    bool existe = false;
                    foreach (Mecanico mecanico in mecanicos)
                    {
                        if (mecanico.NumRegistro == numRegistro)
                            existe = true;
                    }
                    return existe;
                }
        private bool ExisteMaterial(string nombre)
                {
                    bool existe = false;
                    foreach (Material material in materiales)
                    {
                        if (material.Nombre == nombre)
                            existe = true;
                    }
                    return existe;
                }
        private bool ExisteEmbarcacion(int codigo)
                {
                    bool existe = false;
                    foreach (Embarcacion embarcacion in embarcaciones)
                    {
                        if (embarcacion.Codigo == codigo)
                            existe = true;
                    }
                    return existe;
                }
        private Reparacion UltimaReparacionDeEmbarcacion(int codigo)
                {
                    Reparacion retorno = null;
                    DateTime? ultimaFechaRep = null;
                    foreach (Reparacion r in ReparacionesDeEmbarcacion(codigo))
                    {
                        if (ultimaFechaRep == null)
                        {
                            ultimaFechaRep = r.FechaRealEngreso;
                            if (r.FechaRealEngreso > ultimaFechaRep)
                                retorno = r;
                        }
                        else if (r.FechaRealEngreso > ultimaFechaRep)
                        {
                            ultimaFechaRep = r.FechaRealEngreso;
                            retorno = r;
                        }
                    }
                    return retorno;
                }
        #endregion

    }
}
