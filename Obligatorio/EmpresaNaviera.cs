﻿using System;
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
        public void EstablecerRecargo(double valor)
        {
            Importado.Recargo = valor;
        }
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
