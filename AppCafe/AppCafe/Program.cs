// Sistema de ventas para "Café Manolillo"
using System;

class CafeManolillo
{
    static string[] productos = { "Café", "Té", "Pastel", "Galleta" };
    static double[] precios = { 1.50, 1.20, 2.00, 0.80 };
    static int[] cantidadesVendidas = new int[4];
    static double[,] ventas = new double[100, 3]; // ID producto, cantidad, monto
    static int totalVentas = 0;

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Café Manolillo\n");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Registrar venta");
            Console.WriteLine("3. Ver estadísticas");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

            switch (opcion)
            {
                case 1: MostrarProductos(); break;
                case 2: RegistrarVenta(); break;
                case 3: VerEstadisticas(); break;
                case 4: Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!"); break;
                default: Console.WriteLine("Opción inválida. Presiona ENTER para continuar."); Console.ReadLine(); break;
            }
        } while (opcion != 4);
    }

    static void MostrarProductos()
    {
        Console.Clear();
        Console.WriteLine("Productos disponibles:\n");
        for (int i = 0; i < productos.Length; i++)
            Console.WriteLine($"{i + 1}. {productos[i]} - ${precios[i]:0.00}");
        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }

    static void RegistrarVenta()
    {
        MostrarProductos();
        Console.Write("\nElige el número del producto: ");
        if (!int.TryParse(Console.ReadLine(), out int opcionProd) || opcionProd < 1 || opcionProd > productos.Length)
        {
            Console.WriteLine("Producto inválido. Presiona ENTER para volver al menú.");
            Console.ReadLine();
            return;
        }

        Console.Write("Cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Cantidad inválida. Presiona ENTER para volver al menú.");
            Console.ReadLine();
            return;
        }

        int indice = opcionProd - 1;
        double monto = precios[indice] * cantidad;
        cantidadesVendidas[indice] += cantidad;

        // Registrar en matriz ventas
        ventas[totalVentas, 0] = indice;
        ventas[totalVentas, 1] = cantidad;
        ventas[totalVentas, 2] = monto;
        totalVentas++;

        Console.WriteLine($"\nVenta registrada: {cantidad} x {productos[indice]} = ${monto:0.00}");
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ReadLine();
    }

    static void VerEstadisticas()
    {
        Console.Clear();
        double totalRecaudado = 0;
        int productoMasVendido = 0;

        Console.WriteLine("Estadísticas de ventas:\n");
        for (int i = 0; i < productos.Length; i++)
        {
            double subtotal = cantidadesVendidas[i] * precios[i];
            totalRecaudado += subtotal;
            if (cantidadesVendidas[i] > cantidadesVendidas[productoMasVendido])
                productoMasVendido = i;

            Console.WriteLine($"{productos[i]}: {cantidadesVendidas[i]} unidades - ${subtotal:0.00}");
        }

        Console.WriteLine($"\nTotal recaudado: ${totalRecaudado:0.00}");
        Console.WriteLine($"Producto más vendido: {productos[productoMasVendido]}");
        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }
}
