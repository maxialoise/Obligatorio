using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            CargarDatosMateriales();
            CargarDatosMecanicos();
            CargarDatosEmbarcaciones();
            MostrarPrincipal();
        }
        #endregion

        #region CargarDatosDummy
        private static void CargarDatosMecanicos()
        {
            Mecanico mec1 = new Mecanico("pedro perez", "555-1234", "0001", "ellauri", "1234", "montevideo", 900, false);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec1);
            Mecanico mec2 = new Mecanico("juan santos", "555-4321", "1101", "yi", "605", "montevideo", 1200, true);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec2);
            Mecanico mec3 = new Mecanico("pepe ramoz", "555-1423", "9424", "san jose", "3003", "montevideo", 1000, true);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec3);
            Mecanico mec4 = new Mecanico("diego garcia", "555-3241", "6452", "cuareim", "6056", "montevideo", 1000, false);
            EmpresaNaviera.GetInstance().Mecanicos.Add(mec4);
        }

        private static void CargarDatosMateriales()
        {
            Material material1 = new Nacional("madera", 600, 200, "La madera feliz", 15, 50);
            EmpresaNaviera.GetInstance().Materiales.Add(material1);
            Material material2 = new Nacional("piedra", 2000, 400, "Rocky Balboa", 10, 100);
            EmpresaNaviera.GetInstance().Materiales.Add(material2);
            Material material3 = new Nacional("parafina", 900, 150, "Surf & Go", 2, 60);
            EmpresaNaviera.GetInstance().Materiales.Add(material3);
            Material material4 = new Importado("acero", 7000, 800, "El dulce acero", "argentina");
            EmpresaNaviera.GetInstance().Materiales.Add(material4);
            Material material5 = new Importado("bronce", 7100, 600, "bronceV", "brasil");
            EmpresaNaviera.GetInstance().Materiales.Add(material5);
            Material material6 = new Importado("cobre", 8500, 900, "Rocky Balboa", "paraguay");
            EmpresaNaviera.GetInstance().Materiales.Add(material6);


        }

        private static void CargarDatosEmbarcaciones()
        {
            Embarcacion emb1 = new Embarcacion("emb1", new DateTime(2016, 09, 20), "fuera de borda");
            EmpresaNaviera.GetInstance().Embarcaciones.Add(emb1);
            Embarcacion emb2 = new Embarcacion("emb2", new DateTime(2016, 09, 19), "otros");
            EmpresaNaviera.GetInstance().Embarcaciones.Add(emb2);
        }
        #endregion

        #region MenuPrincipal

        private static string MostrarMenuPrincipal()
        {
            Console.Clear();
            MostrarTituloEmpresa();
            Console.WriteLine("Menu: ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1-Registrar mecanico");
            Console.WriteLine("2-Registrar embarcacion");
            Console.WriteLine("3-Ingresar reparacion");
            Console.WriteLine("4-Listado de mecanicos sin capacitacion extra");
            Console.WriteLine("5-Salir");
            Console.WriteLine();
            Console.WriteLine("Ingrese el número de la opción: ");
            return Console.ReadLine();
        }

        private static void MostrarTituloEmpresa()
        {
            Console.WriteLine("Empresa Naviera: El Crustaceo Cascarudo");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
        }

        private static void MostrarPrincipal()
        {
            string opcion = MostrarMenuPrincipal();

            while (opcion.Trim() != "5")
            {
                switch (opcion.ToLower())
                {
                    case "1":
                        AltaMecanico();
                        break;
                    case "2":
                        AltaEmbarcacion();
                        break;
                    case "3":
                        AltaReparacion();
                        break;
                    case "4":
                        ListadoMecSinCapExtra();
                        break;
                    default:
                        Console.WriteLine("Opción inválida, ingrese otra: ");
                        Console.ReadLine();
                        break;
                }

                opcion = MostrarMenuPrincipal();
            }
            Console.WriteLine("Gracias. Presione una tecla para salir");
            Console.ReadKey();
        }
        #endregion

        #region Listados
        private static void ListadoMecSinCapExtra()
        {
            Console.WriteLine("Mecanicos sin capacitacion extra: ");
            Console.WriteLine();
            foreach (Mecanico m in EmpresaNaviera.GetInstance().BuscarMecanicosSinCapExtra())
            {
                Console.WriteLine(m.Nombre);
            }
            Console.WriteLine();
            Console.WriteLine("Presione una telca para volver al menu");
            Console.ReadKey();
        }
        #endregion

        #region AltaReparacion
        //Metodo princiupal de alta de reparacion
        private static void AltaReparacion()
        {
            Console.Clear();
            Console.WriteLine("Alta Reparacion");
            Console.WriteLine();
            Console.WriteLine("Ingrese la fecha de ingreso (dd/MM/yyyy)");
            string altaIngreso = Console.ReadLine();
            DateTime fechaAltaIngreso = new DateTime();
            try
            {
                fechaAltaIngreso = Convert.ToDateTime(altaIngreso);
            }
            catch (Exception)
            {
                errorEnFecha();
                return;
            }
            if (fechaAltaIngreso > DateTime.Now)
            {
                errorEnFecha();
                return;
            }

            Console.WriteLine("Ingrese la fecha prometida de egreso (dd/MM/yyyy)");
            string prometidaEgreso = Console.ReadLine();
            DateTime fechaPrometidaEgreso = new DateTime();
            try
            {
                fechaPrometidaEgreso = Convert.ToDateTime(prometidaEgreso);
            }
            catch (Exception)
            {
                errorEnFecha();
                return;
            }
            if (fechaPrometidaEgreso < DateTime.Now)
            {
                errorEnFecha();
                return;
            }

            Console.WriteLine("Ingrese el codigo de la embarcacion a reparar:");
            string codigo = Console.ReadLine();
            int codEmbaracacion;
            if (!int.TryParse(codigo, out codEmbaracacion))
            {
                Console.WriteLine("Error con el codigo de embarcacion");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
                return;
            }
            if (codEmbaracacion < 0)
            {
                Console.WriteLine("Error con el codigo de embarcacion");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
                return;
            }
            Embarcacion e = EmpresaNaviera.GetInstance().BuscarEmbarcacion(codEmbaracacion);
            if (e == null)
            {
                Console.WriteLine("Error con el codigo de embarcacion");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Ingrese los mecanicos de la reparacion:");
            List<Mecanico> listaMecanicos = new List<Mecanico>();
            listaMecanicos = mostrarMenuAgregarMecanico(listaMecanicos);
            if (listaMecanicos.Count == 0)
            {
                Console.WriteLine("Error. No se agrego ningun mecanico");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
                return;
            }
            Reparacion rep = null;
            bool ok = EmpresaNaviera.GetInstance().AltaReparacion(fechaAltaIngreso, fechaPrometidaEgreso, fechaPrometidaEgreso, e, listaMecanicos, out rep);
            if (ok)
            {
                Console.WriteLine("Seleccione los materiales a ultilizar: ");
                rep = mostrarMenuAgregarProducto(rep);
                Console.WriteLine("Alta exitosa");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrió un error");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
            }
        }
        //menu que da las opciones para agregar producto a la reparacion
        private static Reparacion mostrarMenuAgregarProducto(Reparacion rep)
        {
            string opcion = mostrarOpcionProductos();
            while (opcion.ToLower().Trim() != "n" || rep.Productos == null || rep.Productos.Count() == 0)
            {
                switch (opcion.ToLower())
                {
                    case "s":
                        rep = AgregarMaterial(rep);
                        break;
                    default:
                        Console.WriteLine("Opción inválida/no agrego ningun material todavia, ingrese otra: ");
                        Console.ReadKey();
                        break;
                }
                opcion = mostrarOpcionProductos();
            }
            return rep;
        }
        //ingresar los materiales a la instancia de Reparacion
        private static Reparacion AgregarMaterial(Reparacion rep)
        {
            Console.WriteLine("Elija el material: ");
            foreach (Material m in EmpresaNaviera.GetInstance().Materiales)
            {
                Console.WriteLine(m.Nombre);
            }
            string nombreMaterial = Console.ReadLine();
            foreach (Material ma in EmpresaNaviera.GetInstance().Materiales)
            {
                if (nombreMaterial == ma.Nombre)
                {
                    Console.WriteLine("Ingrese la cantidad del material solicitado: ");
                    string cantidad = Console.ReadLine();
                    int cantidadMat;
                    if (!int.TryParse(cantidad, out cantidadMat))
                    {
                        Console.WriteLine("No se pudo agregar el material");
                        Console.WriteLine("Presione tecla para continuar");
                        Console.ReadKey();
                        return rep;
                    }
                    if (cantidadMat < 0)
                    {
                        Console.WriteLine("No se pudo agregar el material");
                        Console.WriteLine("Presione tecla para continuar");
                        Console.ReadKey();
                        return rep;
                    }
                    Console.WriteLine("Se agrego el material: " + ma.Nombre);
                    Console.WriteLine("Presione tecla para continuar");
                    Console.ReadKey();
                    rep.AltaProducto(cantidadMat, ma);
                    return rep;
                }
            }
            Console.WriteLine("No se encontro el material");
            Console.WriteLine("Presione tecla para continuar");
            Console.ReadKey();
            return rep;
        }

        private static string mostrarOpcionProductos()
        {
            Console.WriteLine("¿Desea ingresar productos?: (s/n)");
            return Console.ReadLine();
        }
        //menu para agregar mecanicos a la reparacion
        private static List<Mecanico> mostrarMenuAgregarMecanico(List<Mecanico> listaMecanicos)
        {
            string opcion = mostrarOpcionMecanicos();
            while (opcion.ToLower().Trim() != "n")
            {
                switch (opcion.ToLower())
                {
                    case "s":
                        listaMecanicos = AgregarMecanico(listaMecanicos);
                        break;
                    default:
                        Console.WriteLine("Opción inválida, ingrese otra: ");
                        Console.ReadKey();
                        break;
                }

                opcion = mostrarOpcionMecanicos();
            }
            return listaMecanicos;
        }
        //agregar un mecanico ya creado a la lista de mecanicos en la instancia de reparacion
        private static List<Mecanico> AgregarMecanico(List<Mecanico> listaMecanicos)
        {
            Console.WriteLine("Ingrese el numeo de registro del mecanico");
            string numRegistro = Console.ReadLine();
            Mecanico mecanico = EmpresaNaviera.GetInstance().BuscarMecanico(numRegistro);
            if (mecanico != null)
            {
                listaMecanicos.Add(mecanico);
                Console.WriteLine("Se agrego al mecanico: " + mecanico.Nombre);
                Console.WriteLine("Presione tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El mecanico no existe");
                Console.WriteLine("Presione tecla para continuar");
                Console.ReadKey();
            }
            return listaMecanicos;
        }

        private static string mostrarOpcionMecanicos()
        {
            Console.WriteLine("¿Desea ingresar mecanicos?: (s/n)");
            return Console.ReadLine();
        }

        private static void errorEnFecha()
        {
            Console.WriteLine("Error en el ingreso de la fecha");
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
        #endregion

        #region AltaEmbarcacion
        private static void AltaEmbarcacion()
        {
            Console.Clear();
            Console.WriteLine("Alta Embarcacion");
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de construccion (dd/MM/yyyy)");
            string fecha = Console.ReadLine();
            DateTime fechaConstruccion = new DateTime();
            try
            {
                fechaConstruccion = Convert.ToDateTime(fecha);
            }
            catch (Exception)
            {
                errorEnFecha();
                return;
            }
            if (fechaConstruccion > DateTime.Now)
            {
                errorEnFecha();
                return;
            }
            Console.WriteLine("Ingrese el tipo de motor:");
            string tipoMotor = Console.ReadLine();

            bool ok = EmpresaNaviera.GetInstance().AltaEmbarcacion(nombre, fechaConstruccion, tipoMotor);
            if (ok)
            {
                Console.WriteLine("Alta exitosa");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrió un error");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
            }
        }
        #endregion

        #region AltaMecanico
        private static void AltaMecanico()
        {
            Console.Clear();
            Console.WriteLine("Alta Mecanico");
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingrese la calle:");
            string calle = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de puerta:");
            string numPuerta = Console.ReadLine();
            Console.WriteLine("Ingrese la ciudad:");
            string ciudad = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de registro:");
            string numRegistro = Console.ReadLine();
            Console.WriteLine("Ingrese el precio del jornal:");
            string jornal = Console.ReadLine();
            double precioJornal = 0;
            if (!double.TryParse(jornal, out precioJornal))
            {
                Console.WriteLine("Error en el ingreso del jornal");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
                return;
            }
            if (precioJornal < 0)
            {
                Console.WriteLine("Error en el ingreso del jornal");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("¿Tiene capacitacion extra? (S/N): ");
            string capExtra = Console.ReadLine();
            bool tieneCapExtra = false;
            switch (capExtra.ToLower())
            {
                case "s":
                    tieneCapExtra = true;
                    break;
                case "n":
                    tieneCapExtra = false;
                    break;
                default:
                    Console.WriteLine("Error al ingresar si tiene capacitacion extra");
                    Console.WriteLine("Presione una tecla para salir");
                    Console.ReadKey();
                    return;
            }
            bool ok = EmpresaNaviera.GetInstance().AltaMecanico(nombre, telefono, calle, numPuerta, ciudad, numRegistro, precioJornal, tieneCapExtra);
            if (ok)
            {
                Console.WriteLine("Alta exitosa");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrió un error");
                Console.WriteLine("Presione una tecla para salir");
                Console.ReadKey();
            }
        }
        #endregion

    }
}
