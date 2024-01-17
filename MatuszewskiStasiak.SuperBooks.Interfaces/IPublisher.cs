namespace MatuszewskiStasiak.SuperBooks.Interfaces
{
    public interface IPublisher
    {
        int ID { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        int YearCreated { get; set; }
    }
}