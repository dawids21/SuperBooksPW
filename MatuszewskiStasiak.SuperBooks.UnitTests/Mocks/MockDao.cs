using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.Interfaces;

namespace MatuszewskiStasiak.SuperBooks.UnitTests
{
    public partial class BLCTests
    {
        public class MockDao : IDAO
        {
            private readonly List<PublisherMock> _publishers = new List<PublisherMock>();
            private readonly List<BookMock> _books = new List<BookMock>();

            public MockDao(List<PublisherMock> publishers, List<BookMock> books)
            {
                _publishers = publishers;
                _books = books;
            }

            public IBook CreateNewBook(string name, Guid publisher, int yearPublished, BookType type)
            {
                throw new NotImplementedException();
            }

            public IPublisher CreateNewPublisher(string name, string address, int yearCreated)
            {
                throw new NotImplementedException();
            }

            public void DeleteBook(Guid id)
            {
                throw new NotImplementedException();
            }

            public void DeletePublisher(Guid id)
            {
                throw new NotImplementedException();
            }

            public void EditBook(Guid id, string name, Guid publisher, int yearPublished, BookType type)
            {
                throw new NotImplementedException();
            }

            public void EditPublisher(Guid id, string name, string address, int yearCreated)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<IBook> GetAllBooks()
            {
                return _books;
            }

            public IEnumerable<IPublisher> GetAllPublishers()
            {
                return _publishers;
            }

            public IBook? GetBook(Guid id)
            {
                throw new NotImplementedException();
            }

            public IPublisher? GetPublisher(Guid id)
            {
                throw new NotImplementedException();
            }
        }
    }
}