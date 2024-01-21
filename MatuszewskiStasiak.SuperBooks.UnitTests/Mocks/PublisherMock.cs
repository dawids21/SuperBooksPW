using MatuszewskiStasiak.SuperBooks.Interfaces;

namespace MatuszewskiStasiak.SuperBooks.UnitTests
{
    public partial class BLCTests
    {
        public class PublisherMock : IPublisher
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public int YearCreated { get; set; }
            public List<IBook> Books { get; set; }
        }
    }
}