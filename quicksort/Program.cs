using System;

class QuickSort
{
    // Método principal que implementa el algoritmo QuickSort
    public static void QuickSortAlgo(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            Console.WriteLine($"Pivote seleccionado: {arr[pi]} en la posición {pi}");
            Console.WriteLine("Estado del array después de la partición:");
            PrintArray(arr);

            QuickSortAlgo(arr, low, pi - 1);
            QuickSortAlgo(arr, pi + 1, high);
        }
    }

    // Método que realiza la partición del array
    public static int Partition(int[] arr, int low, int high)
    {
        //Aquí puede ser el mas alto, el mas bajo, el punto medio o random.
        int pivot = arr[high];
        Console.WriteLine($"\nIniciando partición con pivote {pivot} en la posición {high}");

        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
                Console.WriteLine($"Intercambio: {arr[i]} <-> {arr[j]}");
                PrintArray(arr);
            }
        }

        Swap(arr, i + 1, high);
        Console.WriteLine($"Colocando pivote {arr[i + 1]} en su posición final:");
        PrintArray(arr);

        return i + 1;
    }

    // Método para intercambiar dos elementos en el array
    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // Método para imprimir el array en consola
    public static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }
    //Metodo de ordenamiento binario (insercion binaria)
    public static void BinaryInsertionSort(int[] arr)
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
            for (int j = i; j > izquierda; j--)
            {
                arr[j] = arr[j - 1];
            }
            arr[izquierda] = valorActual;
        }
    }
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n- i - 1; j++)
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
    //Menu para elegir el algoritmo de ordenamiento
    public static void MostrarMenu()
    {
        Console.WriteLine("\nSelecciona el algoritmo de ordenamiento:");
        Console.WriteLine("1. QuickSort");
        Console.WriteLine("2. Ordenamiento Binario");
        Console.WriteLine("3. Bubble Sort");
        Console.WriteLine("4. Salir");
    }
    public static int ObtenerOpcion()
    {
        while (true)
        {
            try
            {
                int opcion = int.Parse(Console.ReadLine());
                if (opcion >= 1 && opcion <= 4)
                    return opcion;
                else
                    Console.WriteLine("Opcion invalida. Elige un numero entre 1 y 4." );
                
            }
            catch
            {
                 Console.WriteLine("Opcion invalida. Porfavor ingresa un numero. " );
            }
        }
    }
    public static void MostrarResultado(string algoritmo, int[] arr)
    {
        Console.WriteLine($"\nResultado con el algoritmo de {algoritmo}:");
        PrintArray(arr);
    }
    static void Main()
    {
        
        Console.WriteLine("Ingrese los numeros separados por espacios: " );
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
             Console.WriteLine("Entrada invalida. SALIENDO..." );
             return;
            
        }
        int[] arr;
        try
        {
            arr = Array.ConvertAll(input.Split(' '), int.Parse);
        }
        catch (FormatException)
        {
             Console.WriteLine("Opcion invalida. Asegúrate de ingresar solo numeros." );
            return;
        }
        //Menu interactivo
        while (true)
        {
            MostrarMenu();
            int opcion = ObtenerOpcion();

            if (opcion == 1)
            {
                 Console.WriteLine("Ordenando con QuickSort..." );
                 QuickSortAlgo(arr, 0, arr.Length - 1);
                MostrarResultado("QuitckSort", arr);
                    
                
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Utilizando el metodo de Ordenamiento Binario...");
                BinaryInsertionSort(arr);
                MostrarResultado("Ordenamiento Binario", arr);
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Ordenando con Bubble Sort...");
                BubbleSort(arr);
                MostrarResultado("Bubble Sort", arr);
            }
            else if (opcion == 4)
            {
                Console.WriteLine("Saliendo...");
                break;
            }
            
        }
        
        
    }
}
      
