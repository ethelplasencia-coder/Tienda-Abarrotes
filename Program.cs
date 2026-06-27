using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_TEMA07
{
    internal class Program
    {
        // Lista global del inventario
        static List<string> nombres = new List<string>();
        static List<double> precios = new List<double>();
        static List<int> stocks = new List<int>();

        // ============================================
        // FUNCIÓN: Mostrar Menú Principal
        // ============================================
        static void MostrarMenu()
        {
            Console.WriteLine("\n=====TIENDA DE ABARROTES =====");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Mostrar inventario");
            Console.WriteLine("3. Realizar venta");
            Console.WriteLine("4. Buscar producto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");
        }

        // ============================================
        // FUNCIÓN: Registrar Producto
        // ============================================
        static void RegistrarProducto()
        {
            Console.WriteLine("\n--- REGISTRAR PRODUCTO ---");

            // Leer nombre
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacio.");
                return;
            }

            // Leer precio
            Console.Write("Precio unitario (S/.): ");
            double precio;
            if (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0)
            {
                Console.WriteLine("Error: Precio invalido.");
                return;
            }

            // Leer stock
            Console.Write("Cantidad en stock: ");
            int stock;
            if (!int.TryParse(Console.ReadLine(), out stock) || stock <= 0)
            {
                Console.WriteLine("Error: Cantidad invalida.");
                return;
            }

            // Agregar a las listas
            nombres.Add(nombre);
            precios.Add(precio);
            stocks.Add(stock);

            Console.WriteLine($"Producto '{nombre}' registrado exitosamente.");
        }

        // ============================================
        // FUNCIÓN: Mostrar Inventario
        // ============================================
        static void MostrarInventario()
        {
            Console.WriteLine("\n--- INVENTARIO ---");

            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            // Encabezado de tabla
            Console.WriteLine($"{"N°",-5} {"Nombre",-20} {"Precio",-12} {"Stock",-10}");
            Console.WriteLine(new string('-', 50));

            // Mostrar cada producto
            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine($"{i + 1,-5} {nombres[i],-20} S/.{precios[i],-10} {stocks[i],-10}");
            }
        }

        // ============================================
        // FUNCIÓN: Realizar Venta
        // ============================================
        static void RealizarVenta()
        {
            Console.WriteLine("\n--- REALIZAR VENTA ---");

            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay productos disponibles.");
                return;
            }

            // Buscar producto
            Console.Write("Nombre del producto a vender: ");
            string nombre = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < nombres.Count; i++)
            {
                if (nombres[i].ToLower() == nombre.ToLower())
                {
                    encontrado = true;
                    Console.WriteLine($"Producto: {nombres[i]} | Stock disponible: {stocks[i]}");

                    // Leer cantidad a vender
                    Console.Write("Cantidad a vender: ");
                    int cantVender;
                    if (!int.TryParse(Console.ReadLine(), out cantVender) || cantVender <= 0)
                    {
                        Console.WriteLine("Error: Cantidad invalida.");
                        return;
                    }

                    // Verificar stock
                    if (cantVender <= stocks[i])
                    {
                        stocks[i] -= cantVender;
                        double total = cantVender * precios[i];
                        Console.WriteLine($"Venta exitosa.");
                        Console.WriteLine($"Total a pagar: S/.{total}");
                        Console.WriteLine($"Stock restante: {stocks[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Stock insuficiente. Solo hay {stocks[i]} unidades.");
                    }
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // ============================================
        // FUNCIÓN: Buscar Producto
        // ============================================
        static void BuscarProducto()
        {
            Console.WriteLine("\n--- BUSCAR PRODUCTO ---");

            Console.Write("Nombre a buscar: ");
            string nombre = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < nombres.Count; i++)
            {
                if (nombres[i].ToLower() == nombre.ToLower())
                {
                    encontrado = true;
                    Console.WriteLine($"Producto encontrado:");
                    Console.WriteLine($"  Nombre : {nombres[i]}");
                    Console.WriteLine($"  Precio : S/.{precios[i]}");
                    Console.WriteLine($"  Stock  : {stocks[i]}");
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // ============================================
        // FUNCIÓN PRINCIPAL: Main
        // ============================================
        static void Main(string[] args)
        {
            int opcion = 0;

            // Bucle principal del menú
            do
            {
                MostrarMenu();
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        RegistrarProducto();
                        break;
                    case 2:
                        MostrarInventario();
                        break;
                    case 3:
                        RealizarVenta();
                        break;
                    case 4:
                        BuscarProducto();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }

            } while (opcion != 5);
        }
    }
}
    

