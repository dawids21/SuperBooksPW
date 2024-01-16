using SuperBooks.BLC;
using SuperBooks.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"]!;
        BLC blc = new BLC(libraryName);
        foreach (IPublisher p in blc.GetPublishers())
        {
            Console.WriteLine($"{p.ID}: {p.Name}");
        }
        Console.WriteLine("-------------------");
        foreach (IBook c in blc.GetBooks())
        {
            Console.WriteLine($"{c.ID}: {c.Publisher.Name} {c.Name} ({c.YearPublished}) {c.Type}");
        }
    }
}