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
        static void Main(string[] args)
        {
            cargarDatosMateriales();
            cargarDatosMecanicos();
            MostrarPrincipal();
        }

        private static void cargarDatosMecanicos()
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

        private static void cargarDatosMateriales()
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

        private static string mostrarMenuPrincipal()
        {
            Console.Clear();
            mostrarTituloEmpresa();
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

        private static void mostrarTituloEmpresa()
        {
            Console.WriteLine("Empresa Naviera: El Crustaceo Cascarudo");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
        }

        private static void MostrarPrincipal()
        {
            string opcion = mostrarMenuPrincipal();

            while (opcion.Trim() != "5")
            {
                switch (opcion)
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

                opcion = mostrarMenuPrincipal();
            }
            Console.WriteLine("Gracias. Presione una tecla para salir");
            Console.ReadKey();
        }

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
            string tipoMotor = Console.ReadLine();


            //bool ok = EmpresaNaviera.GetInstance().AltaEmbarcacion(nombre, fechaConstruccion, tipoMotor);
            //if (ok)
            //{
            //    Console.WriteLine("Alta exitosa");
            //    Console.WriteLine("Presione una tecla para salir");
            //    Console.ReadKey();
            //}
            //else
            //{
            //    Console.WriteLine("Ocurrió un error");
            //    Console.WriteLine("Presione una tecla para salir");
            //    Console.ReadKey();
            //}
            //MostrarPrincipal();
        }

        private static void errorEnFecha()
        {
            Console.WriteLine("Error en el ingreso de la fecha");
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }

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
            MostrarPrincipal();
        }

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
                MostrarPrincipal();
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
                    MostrarPrincipal();
                    break;
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
            MostrarPrincipal();
        }
    }
}
