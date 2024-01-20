namespace MatuszewskiStasiak.SuperBooks.Interfaces
{
    public interface IPublisher
    {
        Guid ID { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        int YearCreated { get; set; }
        List<IBook> Books { get; set; }
    }
}