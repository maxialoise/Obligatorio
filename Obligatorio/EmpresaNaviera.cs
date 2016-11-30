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
            if (EmpresaNaviera.instancia == null)
            {
                EmpresaNaviera.instancia = new EmpresaNaviera();
            }
            return EmpresaNaviera.instancia;
        }
        private EmpresaNaviera()
        {
            this.embarcaciones = new List<Embarcacion>();
            this.mecanicos = new List<Mecanico>();
            this.reparaciones = new List<Reparacion>();
            this.materiales = new List<Material>();
        }
        #endregion

        #region MetodosPublicos
        //REALIZA EL ALTA DEL MECANICO VALIDANDO QUE NO EXISTA EL MISMO POR EL NUMERO DE REGISTRO
        public bool AltaMecanico(string nombre, string telefono, string calle, string numPuerta, string ciudad, string numRegistro, double precioJornal, bool tieneCapExtra)
        {
            bool exito = false;
            if (!ExisteMecanico(numRegistro))
            {
                mecanicos.Add(new Mecanico(nombre, telefono, numRegistro, calle, numPuerta, ciudad, precioJornal, tieneCapExtra));
                exito = true;
            }
            return exito;
        }
        //REALIZA EL ALTA DEL MECANICO VALIDANDO QUE NO EXISTA EL MISMO POR EL NOMBRE DEL MATERIAL
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
        //REALIZA EL ALTA DEL MECANICO VALIDANDO QUE NO EXISTA EL MISMO POR EL NOMBRE DEL MATERIAL
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
        //REALIZA EL ALTA DE LA EMBARCACION VALIDANDO QUE NO EXISTA EL MISMO POR EL NOMBRE DE LA EMBARCACION
        public bool AltaEmbarcacion(string nombre, DateTime fechaConstruccion, string tipoMotor)
        {
            bool exito = false;
            if (!ExisteEmbarcacion(nombre))
            {
                embarcaciones.Add(new Embarcacion(nombre, fechaConstruccion, tipoMotor));
                exito = true;
            }
            return exito;
        }
        //REALIZA EL ALTA DE LA REPARACIONES VALIDANDO QUE LAS FECHAS DE LA REPARACION INGRESADA PARA UNA MISMA EMBARCACION EXISTENTE SEAN DIFERENTES EN CUANTO
        // A SU FECHA DE INGRESO CON FECHA REAL DE EGRESO PARA QUE NO SE ENCUENTREN DOS REPARACIONES DE UNA EMBARCACION EN LA MISMA FECHA. SOLO SE PUEDE REPARAR
        // UNA EMBARCACION SI LA FECHA INGRESADA ES MAYOR A LA FECHA REAL DE EGRESO
        public bool AltaReparacion(DateTime fechaIngreso, DateTime fechaPrometidaEngreso, DateTime fechaRealEngreso, Embarcacion embarcacion, List<Mecanico> mecanicos, out Reparacion repa)
        {
            bool exito = false;
            Reparacion rep = UltimaReparacionDeEmbarcacion(embarcacion.Codigo);
            repa = new Reparacion(fechaIngreso, fechaPrometidaEngreso, fechaRealEngreso, embarcacion, mecanicos);
            if (fechaIngreso <= fechaPrometidaEngreso && fechaIngreso <= fechaRealEngreso)
            {
                if (rep != null)
                {
                    //controlar que la fechaRealEgreso de la ultima rep sea menor a fecha ingreso
                    if (rep.FechaRealEngreso <= fechaIngreso)
                    {
                        reparaciones.Add(repa);
                        exito = true;
                    }
                }
                else
                {
                    reparaciones.Add(repa);
                    exito = true;
                }
            }
            return exito;
        }
        public bool AltaReparacion(DateTime fechaIngreso, DateTime fechaPrometidaEgreso, int codEmbarcacion, out string mensajeError)
        {
            bool exito = false;
            mensajeError = string.Empty;
            Embarcacion embarcacion = BuscarEmbarcacion(codEmbarcacion);
            if (embarcacion != null)
            {
                if (fechaIngreso <= fechaPrometidaEgreso)
                {
                    // buscar que esa repa no este siendo reparada (fechar real egreso != null)
                    if (!EmbarcacionEnReparacion(embarcacion))
                    {
                        reparaciones.Add(new Reparacion(fechaIngreso, fechaPrometidaEgreso, embarcacion));
                        exito = true;
                    }
                    else
                    {
                        mensajeError = "Error. Embarcacion actualmente en reparacion";
                    }
                }
                else
                {
                    mensajeError = "Error. Fecha de Egreso menor a la de ingreso";
                }
            }
            else
            {
                mensajeError = "Error. Embarcacion no existe";
            }
            return exito;
        }
        //Con la lista de todas las reparaciones de una embarcacion, revisa si esta siendo reparada en este momento
        private bool EmbarcacionEnReparacion(Embarcacion embarcacion)
        {
            bool ret = false;
            List<Reparacion> reps = ReparacionesDeEmbarcacion(embarcacion.Codigo);
            foreach (var rep in reps)
            {
                if (rep.FechaRealEngreso == null)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        //REALIZA LA MODIFICACION DEL MECANICO
        public bool ModificacionMecanico(string nombre, string telefono, string calle, string numPuerta, string ciudad, string numRegistro, double precioJornal, bool tieneCapExtra, string oldNumRegistro)
        {
            bool exito = false;

            foreach (Mecanico m in mecanicos)
            {
                if (oldNumRegistro == m.NumRegistro)
                {
                    m.Direccion.Calle = calle;
                    m.Direccion.Ciudad = ciudad;
                    m.Direccion.NumPuerta = numPuerta;
                    m.Nombre = nombre;
                    m.NumRegistro = numRegistro;
                    m.PrecioJornal = precioJornal;
                    m.Telefono = telefono;
                    m.TieneCapExtra = tieneCapExtra;
                    exito = true;
                }
            }
            return exito;
        }
        public List<Reparacion> ReparacionesDeEmbarcacion(int codigoEmb)
        {
            List<Reparacion> reps = new List<Reparacion>(); ;
            if (reparaciones.Count > 0)
            {
                foreach (Reparacion r in reparaciones)
                {
                    if (r.Embarcacion.Codigo == codigoEmb)
                    {
                        reps.Add(r);
                    }
                }
            }

            return reps;
        }
        // METODO PARA OBTENER LA LISTA DE MECANICOS SIN CAP EXTRA
        public List<Mecanico> BuscarMecanicosSinCapExtra()
        {
            List<Mecanico> list = new List<Mecanico>();

            foreach (Mecanico mec in mecanicos)
            {
                if (!mec.TieneCapExtra)
                {
                    list.Add(mec);
                }
            }
            return list;
        }
        // METODO COMPARTIDO PARA ESTABLECER EL RECARGO, NO SE UTILIZA EN ESTA INSTANCIA.
        public void EstablecerRecargo(double valor)
        {
            Importado.Recargo = valor;
        }
        // METODO QUE DEVUELVE UNA EMBARCACION PEDIDA, VALIDANDO POR SU CODIGO
        public Embarcacion BuscarEmbarcacion(int codigo)
        {
            Embarcacion emb = null;
            foreach (Embarcacion e in embarcaciones)
            {
                if (codigo == e.Codigo)
                {
                    emb = new Embarcacion();
                    emb = e;
                }
            }
            return emb;
        }
        // METODO QUE DEVUELVE UN MECANICO VALIDANDO POR SU NUMERO DE REGISTRO. SI NO LO ENCUENTRA, DEVUELVE VACIO
        public Mecanico BuscarMecanico(string numRegistro)
        {
            Mecanico mec = null;
            foreach (Mecanico m in mecanicos)
            {
                if (numRegistro == m.NumRegistro)
                {
                    mec = m;
                }
            }
            return mec;
        }

        public List<Mecanico> BuscarMecanicoSinAsig()
        {
            List<Mecanico> lstMec = new List<Mecanico>();
            List<Reparacion> lst = ReparacionesPendientes();
            foreach (Mecanico mecanico in Mecanicos)
            {
                if (!lst.Exists(x => x.Mecanicos.Exists(y => y.NumRegistro == mecanico.NumRegistro)))
                {
                    lstMec.Add(mecanico);
                }
            }
            return lstMec;
        }
        // METODO QUE DEVUELVE UN MATERIAL, VALIDANDO POR SU NOMBRE. SI NO LO ENCUENTRA, DEVUELVE VACIO
        public Material BuscarMaterial(string nombre)
        {
            Material mat = null;
            foreach (Material m in materiales)
            {
                if (m.Nombre == nombre)
                {
                    mat = m;
                }
            }
            return mat;
        }
        //Listado de todas las reparaciones pendientes
        public List<Reparacion> ReparacionesPendientes()
        {
            List<Reparacion> ret = new List<Reparacion>();
            foreach (Reparacion r in Reparaciones)
            {
                if (r.FechaRealEngreso == null)
                {
                    ret.Add(r);
                }
            }
            return ret;
        }
        #endregion
        #region MetodosPrivados
        // METODO QUE VALIDA LA EXISTENCIA DE UN MECANICO POR SU NUMERO DE REGISTRO
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
        // METODO QUE VALIDA LA EXISTENCIA DE UN MATERIAL POR SU NOMBRE
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
        // METODO QUE VALIDA LA EXISTENCIA DE UNA EMBARCACION VALIDANDO POR SU NOMBRE
        private bool ExisteEmbarcacion(string nombre)
        {
            bool existe = false;
            foreach (Embarcacion embarcacion in embarcaciones)
            {
                if (embarcacion.Nombre == nombre)
                    existe = true;
            }
            return existe;
        }
        // METODO QUE VALIDA LO ANTERIOR COMENTADO EN "ALTAREPARACION"
        private Reparacion UltimaReparacionDeEmbarcacion(int codigo)
        {
            Reparacion retorno = null;
            DateTime? ultimaFechaRep = null;
            if (ReparacionesDeEmbarcacion(codigo).Count > 0)
            {
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
            }

            return retorno;
        }
        #endregion
    }
}
