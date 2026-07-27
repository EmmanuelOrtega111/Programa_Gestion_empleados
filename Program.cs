using Programa_Gestion_Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa_Gestion_Empleados
{
    internal class Program
    {
        static List<Empleado> empleados = new List<Empleado>();
        //Esto le da formato al texto que se le pase, en la posición que se le indique
        static void textoFormato(string texto, int x, int y)
        {
            Console.SetCursorPosition(x, y); //Posicion en la que se mostrará el texto
            Console.Write(texto); //texto a mostrar
        }

        static void menu(int x, int y)
        {
            textoFormato("======== MENÚ DE GESTIÓN ========", x, y);
            textoFormato("| 1. Agregar empleado          |", x, y + 1);
            textoFormato("| 2. Mostrar empleados         |", x, y + 2);
            textoFormato("| 3. Buscar empleado por ID    |", x, y + 3);
            textoFormato("| 4. Eliminar empleado por ID  |", x, y + 4);
            textoFormato("| 5. Salir                     |", x, y + 5);
            textoFormato("================================", x, y + 6);
        }

        static void Main(string[] args)
        {
            empleados.Add(new EmpleadoPorHora("Carlos", "E001", 10m, 40));
            empleados.Add(new EmpleadoAsalariado("María", "E002", 800m));
            empleados.Add(new EmpleadoComisionista("José", "E003", 500m, 2000m, 0.10m));
            Principal(empleados);
        }

        static void Principal(List<Empleado> empleados)
        {
            bool bucle = true;
            while (bucle)
            {
                Console.Clear();
                textoFormato("SISTEMA DE GESTIÓN DE EMPLEADOS", 35, 2);
                menu(35, 4);

                Console.ForegroundColor = ConsoleColor.Green;
                textoFormato("Ingrese una opción (1-5): ", 35, 12);
                Console.ResetColor();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MenuAgregarEmpleado(empleados);
                        break;
                    case "2":
                        MostrarEmpleados(empleados);
                        break;
                    case "3":
                        BuscarEmpleadoMenu(empleados);
                        break;
                    case "4":
                        EliminarEmpleadoMenu(empleados);
                        break;
                    case "5":
                        bucle = false;
                        Console.Clear();
                        textoFormato("¡Gracias por utilizar el sistema!", 35, 5);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        textoFormato("Opción inválida. Presione cualquier tecla para continuar...", 35, 14);
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuAgregarEmpleado(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR NUEVO EMPLEADO ===");
            Console.WriteLine("1. Empleado Asalariado");
            Console.WriteLine("2. Empleado Por Hora");
            Console.WriteLine("3. Empleado Comisionista");
            Console.Write("\nSeleccione el tipo de empleado: ");
            string tipo = Console.ReadLine();

            string id = LeerIdUnico(empleados);
            Console.Write("Ingrese el nombre completo: ");
            string nombre = Console.ReadLine();

            switch (tipo)
            {
                case "1":
                    decimal sueldoFijo = LeerDecimalPositivo("Ingrese el sueldo mensual fijo: $");
                    empleados.Add(new EmpleadoAsalariado(nombre, id, sueldoFijo));
                    break;

                case "2":
                    decimal sueldoHora = LeerDecimalPositivo("Ingrese el sueldo por hora: $");
                    double horas = LeerDoublePositivo("Ingrese las horas trabajadas: ");
                    empleados.Add(new EmpleadoPorHora(nombre, id, sueldoHora, horas));
                    break;

                case "3":
                    decimal sueldoBase = LeerDecimalPositivo("Ingrese el sueldo base: $");
                    decimal ventas = LeerDecimalPositivo("Ingrese el total de ventas realizadas: $");
                    decimal comision = LeerDecimalPositivo("Ingrese el porcentaje de comisión (ej. 0.10 para 10%): ");
                    empleados.Add(new EmpleadoComisionista(nombre, id, sueldoBase, ventas, comision));
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nTipo de empleado no válido.");
                    Console.ResetColor();
                    Pausar();
                    return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n¡Empleado agregado exitosamente!");
            Console.ResetColor();
            Pausar();
        }

        static void MostrarEmpleados(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE EMPLEADOS Y SALARIOS CALCULADOS ===");

            if (empleados.Count == 0)
            {
                Console.WriteLine("\nNo hay empleados registrados.");
            }
            else
            {
                foreach (var emp in empleados)
                {
                    // Polimorfismo: Llama al ToString() y CalcularSalario() sobrescrito de cada clase
                    Console.WriteLine(emp.ToString());
                }
            }
            Pausar();
        }
        //Función para buscar un empleado por su ID
        static void BuscarEmpleadoMenu(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR EMPLEADO POR ID ===");
            Console.Write("Ingrese el ID del empleado: ");
            string id = Console.ReadLine();

            try
            {
                Empleado emp = BuscarPorId(empleados, id);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nEmpleado Encontrado:");
                Console.WriteLine(emp.ToString());
                Console.ResetColor();
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{ex.Message}");
                Console.ResetColor();
            }

            Pausar();
        }

        static void EliminarEmpleadoMenu(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR EMPLEADO POR ID ===");
            Console.Write("Ingrese el ID del empleado a eliminar: ");
            string id = Console.ReadLine();

            try
            {
                Empleado emp = BuscarPorId(empleados, id);
                empleados.Remove(emp);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n¡Empleado con ID '{id}' eliminado con éxito!");
                Console.ResetColor();
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{ex.Message}");
                Console.ResetColor();
            }

            Pausar();
        }
        //Funcion que busca el empleado por su ID, si no lo encuentra lanza una excepción personalizada
        static Empleado BuscarPorId(List<Empleado> empleados, string id)
        {
            Empleado encontradoEmp = null;

            try
            {
                bool encontrado = false;

                foreach (Empleado empleado in empleados)
                {
                    if (empleado.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n===== EMPLEADO ENCONTRADO =====");
                        Console.WriteLine(empleado);
                        Console.WriteLine("===============================");
                        Console.ResetColor();
                        encontrado = true;
                        encontradoEmp = empleado;
                        break;
                    }
                }

                if (!encontrado)
                {
                    throw new EmpleadoNoEncontradoException($"No existe un empleado con el ID '{id}'.");
                }
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR: " + ex.Message);
                Console.ResetColor();
            }

            return encontradoEmp;
        }
        //Función que asegura que el ID ingresado sea único, si ya existe un empleado con ese ID, solicita otro
        static string LeerIdUnico(List<Empleado> empleados)
        {
            //Bucle que se repite hasta que el usuario ingrese un ID único
            while (true)
            {
                //Solicita al usuario que ingrese el ID del empleado
                Console.Write("Ingrese el ID del empleado: ");
                string id = Console.ReadLine()?.Trim();
                //Verifica si el ID ingresado está vacío o es nulo
                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("El ID no puede estar vacío.");
                    continue;
                }
                //Verifica si ya existe un empleado con el mismo ID (ignorando mayúsculas y minúsculas)
                bool yaExiste = empleados.Exists(e => e.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
                if (yaExiste)
                {
                    Console.WriteLine("Error: Ya existe un empleado registrado con ese ID.");
                }
                else
                {
                    return id;
                }
            }
        }
        //Función que asegura que el valor ingresado sea un decimal positivo, si no lo es, solicita otro
        static decimal LeerDecimalPositivo(string mensaje)
        {
            //Bucle que se repite hasta que el usuario ingrese un valor decimal positivo
            decimal valor;
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                {
                    return valor;
                }
                Console.WriteLine("Entrada inválida. Debe ser un valor numérico mayor o igual a 0.");
            }
        }
        //Función que asegura que el valor ingresado sea un double positivo, si no lo es, solicita otro
        static double LeerDoublePositivo(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                {
                    return valor;
                }
                Console.WriteLine("Entrada inválida. Debe ser un número positivo.");
            }
        }
        //Función que pausa la ejecución del programa hasta que el usuario presione una tecla
        static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}