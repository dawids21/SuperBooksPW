using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.Interfaces;

namespace MatuszewskiStasiak.SuperBooks.UnitTests
{
    public partial class BLCTests
    {
        public class BookMock : IBook
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public IPublisher Publisher { get; set; }
            public int YearPublished { get; set; }
            public BookType Type { get; set; }
        }
    }
}