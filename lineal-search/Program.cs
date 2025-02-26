using System;
using System.Linq;

class Program
{

    // Método de búsqueda lineal
    static int LinearSearch(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                return i; // Retorna la posición si encuentra el elemento
            }
        }
        return -1; // Retorna -1 si no lo encuentra
    }

    static void BinaryInsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int valorActual = arr[i];
            int izquierda = 0;
            int derecha = i;
            while (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;
                if (valorActual < arr[medio])
                    derecha = medio;
                else
                    izquierda = medio + 1;

            }

            //Desplazamos todos los elementos para hacer espacio en el valor actual
            for (int j = i; j > izquierda; j--)
            {
                arr[j] = arr[j - 1];
            }
            arr[izquierda] = valorActual;

        }
    }
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }

            }

        }
    }
    static void MostrarMenu()
    {
        Console.WriteLine("\n Selecciona el algoritmo de ordenamiento:");
        Console.WriteLine("1. Ordenamiento Binario");
        Console.WriteLine("2. ordenamiento por intercambio  (Bubble Sort)");
        Console.WriteLine("Salir");
    }
    static int ObtenerOpcion()
    {
        while (true)
        {
            try
            {
                int opcion = int.Parse(Console.ReadLine());
                if (opcion >= 1 && opcion <= 3)
                    return opcion;
                else
                    Console.WriteLine("Opcion invalida. Elige un numero entre 1 y 3.");
            }
            catch
            {
                Console.WriteLine("Entrada invalida. Por favor, ingresa un numero");
            }
        }
    }

    //Metodo para mostrar el resultado
    static void MostrarResultado(string algoritmo, int[] arr)
    {
        Console.WriteLine($"\nResultado con el algoritmo de {algoritmo}.");

        Console.WriteLine(string.Join("", arr));
    }

    static void Main()
    {
        Console.WriteLine("Ingrese los elementos de arreglo separados por espacios: ");
        string? input = Console.ReadLine();
        int[] arr = (input ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse)
                                                   .ToArray();

        if (arr.Length == 0)
        {
            Console.WriteLine("El arreglo esta vacio. Intente nuevamente.");
            return;
        }
        while (true)
        {
            MostrarMenu();
            int opcion = ObtenerOpcion();

            if (opcion == 1)
            {
                BinaryInsertionSort(arr);
                MostrarResultado("Ordenamiento Binario", arr);

            }
            else if (opcion == 2)
            {
                BubbleSort(arr);
                MostrarResultado("Ordenamiento por Intercambio (Bubble Sort)", arr);

            }
            else if (opcion == 3)
            {
                Console.WriteLine("Saliendo...");
                break;
            }
        }
    }
}













                 

