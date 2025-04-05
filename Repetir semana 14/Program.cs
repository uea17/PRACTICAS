// Descripcion : Implementacion de un catalogo de revistas utilizando un arbol binario
// Autor : [ Myrian Chacaguasay]
class Revista
{
    public string Titulo { get; set; }
    public Revista Izquierda { get; set; }
    public Revista Derecha { get; set; }

    public Revista(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}

class CatalogoRevistas
{
    public Revista Raiz { get; set; }

    public void Insertar(string titulo)
    {
        Raiz = InsertarRecursivo(Raiz, titulo);
    }

    private Revista InsertarRecursivo(Revista nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Revista(titulo);
        }

        int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);
        if (comparacion < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, titulo);
        }
        else if (comparacion > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, titulo);
        }

        return nodo;
    }

    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(Raiz, titulo);
    }

    private bool BuscarRecursivo(Revista nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);
        if (comparacion == 0)
        {
            return true;
        }
        else if (comparacion < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, titulo);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        string[] titulos = {
            "Ciencia Hoy", "National Geographic", "Muy Interesante",
            "Time", "Nature", "Scientific American",
            "Forbes", "Reader's Digest", "Popular Mechanics", "Discovery"
        };

        foreach (var titulo in titulos)
        {
            catalogo.Insertar(titulo);
        }

        while (true)
        {
            Console.WriteLine("\n--- Menú del Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese el título de la revista a buscar: ");
                string tituloBusqueda = Console.ReadLine();

                bool encontrado = catalogo.Buscar(tituloBusqueda);
                Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
            }
            else if (opcion == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}

