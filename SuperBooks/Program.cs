using SuperBooks.BLC;
using SuperBooks.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"]!;
        BLC blc = new BLC(libraryName);
        foreach (IProducer p in blc.GetProducers())
        {
            Console.WriteLine($"{p.ID}: {p.Name}");
        }
        Console.WriteLine("-------------------");
        foreach (ICar c in blc.GetCars())
        {
            Console.WriteLine($"{c.ID}: {c.Producer.Name} {c.Name} ({c.ProductionYear}) {c.Transmission}");
        }
    }
}