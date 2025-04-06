class Vuelo
{
    public string Origen;
    public string Destino;
    public int Costo;

    public Vuelo(string origen, string destino, int costo)
    {
        Origen = origen;
        Destino = destino;
        Costo = costo;
    }
}

class Program
{
    static void Main()
    {
        List<Vuelo> vuelos = new List<Vuelo>();

        vuelos.Add(new Vuelo("Quito", "Bogotá", 100));
        vuelos.Add(new Vuelo("Quito", "Lima", 300));
        vuelos.Add(new Vuelo("Bogotá", "Panamá", 150));
        vuelos.Add(new Vuelo("Panamá", "Lima", 200));

        string origen = "Quito";
        string destino = "Lima";

        int costoDirecto = int.MaxValue;
        int costoConEscala = int.MaxValue;

        // Buscar vuelo directo
        foreach (var vuelo in vuelos)
        {
            if (vuelo.Origen == origen && vuelo.Destino == destino)
                costoDirecto = vuelo.Costo;
        }

        // Buscar vuelo con escala
        foreach (var vuelo1 in vuelos)
        {
            if (vuelo1.Origen == origen)
            {
                foreach (var vuelo2 in vuelos)
                {
                    if (vuelo1.Destino == vuelo2.Origen && vuelo2.Destino == destino)
                    {
                        int total = vuelo1.Costo + vuelo2.Costo;
                        if (total < costoConEscala)
                            costoConEscala = total;
                    }
                }
            }
        }

        int costoMinimo = Math.Min(costoDirecto, costoConEscala);

        Console.WriteLine($"El vuelo más barato de {origen} a {destino} cuesta: ${costoMinimo}");
    }
}
