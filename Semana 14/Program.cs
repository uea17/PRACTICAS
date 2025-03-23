

public class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

public class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    // Método para insertar un nuevo valor en el árbol binario
    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    // Método recursivo para insertar un valor en el árbol
    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

        return nodo;
    }

    // Método para realizar el recorrido en orden (Inorden)
    public void Inorden()
    {
        Console.WriteLine("Recorrido Inorden:");
        InordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRecursivo(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InordenRecursivo(nodo.Derecho);
        }
    }

    // Método para realizar el recorrido en preorden
    public void Preorden()
    {
        Console.WriteLine("Recorrido Preorden:");
        PreordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRecursivo(nodo.Izquierdo);
            PreordenRecursivo(nodo.Derecho);
        }
    }

    // Método para realizar el recorrido en postorden
    public void Postorden()
    {
        Console.WriteLine("Recorrido Postorden:");
        PostordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRecursivo(nodo.Izquierdo);
            PostordenRecursivo(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // Método para buscar un valor en el árbol
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;

        if (valor == nodo.Valor)
            return true;

        if (valor < nodo.Valor)
            return BuscarRecursivo(nodo.Izquierdo, valor);
        else
            return BuscarRecursivo(nodo.Derecho, valor);
    }
}

class Programa
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        do
        {
            Console.WriteLine("\n========= Menú de Operaciones con Árboles Binarios =========");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Recorrido Inorden");
            Console.WriteLine("3. Recorrido Preorden");
            Console.WriteLine("4. Recorrido Postorden");
            Console.WriteLine("5. Buscar un valor");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    int valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    Console.WriteLine("Valor insertado correctamente.");
                    break;

                case 2:
                    arbol.Inorden();
                    break;

                case 3:
                    arbol.Preorden();
                    break;

                case 4:
                    arbol.Postorden();
                    break;

                case 5:
                    Console.Write("Ingrese el valor a buscar: ");
                    int valorBuscar = int.Parse(Console.ReadLine());
                    bool encontrado = arbol.Buscar(valorBuscar);
                    if (encontrado)
                        Console.WriteLine("El valor " + valorBuscar + " está en el árbol.");
                    else
                        Console.WriteLine("El valor " + valorBuscar + " NO está en el árbol.");
                    break;

                case 6:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}

