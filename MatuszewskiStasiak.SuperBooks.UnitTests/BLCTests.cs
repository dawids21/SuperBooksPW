using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.Interfaces;

namespace MatuszewskiStasiak.SuperBooks.UnitTests
{
    public partial class BLCTests
    {
        [Test]
        public void ShouldFilterPublishersByName()
        {
            PublisherMock firstPublisher = new PublisherMock()
            {
                Name = "First Publisher",
                Address = "First Address",
                YearCreated = 2000
            };
            PublisherMock secondPublisher = new PublisherMock()
            {
                Name = "Second Publisher",
                Address = "Second Address",
                YearCreated = 2001
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { firstPublisher, secondPublisher }, new List<BookMock>()));

            IEnumerable<IPublisher> publishers = blc.FilterPublishers("First", "");

            Assert.That(publishers.Count(), Is.EqualTo(1));
            Assert.That(publishers.First().Name, Is.EqualTo("First Publisher"));
        }

        [Test]
        public void ShouldFilterPublishersByYearCreated()
        {
            PublisherMock firstPublisher = new PublisherMock()
            {
                Name = "First Publisher",
                Address = "First Address",
                YearCreated = 2000
            };
            PublisherMock secondPublisher = new PublisherMock()
            {
                Name = "Second Publisher",
                Address = "Second Address",
                YearCreated = 2001
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { firstPublisher, secondPublisher }, new List<BookMock>()));

            IEnumerable<IPublisher> publishers = blc.FilterPublishers("", "2000");

            Assert.That(publishers.Count(), Is.EqualTo(1));
            Assert.That(publishers.First().Name, Is.EqualTo("First Publisher"));
        }

        [Test]
        public void ShouldFilterPublishersByNameAndYearCreated()
        {
            PublisherMock firstPublisher = new PublisherMock()
            {
                Name = "First Publisher",
                Address = "First Address",
                YearCreated = 2000
            };
            PublisherMock secondPublisher = new PublisherMock()
            {
                Name = "Second Publisher",
                Address = "Second Address",
                YearCreated = 2001
            };
            PublisherMock thirdPublisher = new PublisherMock()
            {
                Name = "Third Publisher",
                Address = "Third Address",
                YearCreated = 2000
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { firstPublisher, secondPublisher, thirdPublisher }, new List<BookMock>()));

            IEnumerable<IPublisher> publishers = blc.FilterPublishers("First", "2000");

            Assert.That(publishers.Count(), Is.EqualTo(1));
            Assert.That(publishers.First().Name, Is.EqualTo("First Publisher"));
        }

        [Test]
        public void ShouldFilterBooksByName()
        {
            PublisherMock publisher = new PublisherMock()
            {
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            BookMock firstBook = new BookMock()
            {
                Name = "First Book",
                YearPublished = 2000,
                Publisher = publisher,
                Type = BookType.Hardcover
            };
            BookMock secondBook = new BookMock()
            {
                Name = "Second Book",
                YearPublished = 2001,
                Publisher = publisher,
                Type = BookType.Paperback
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { publisher }, new List<BookMock>() { firstBook, secondBook }));

            IEnumerable<IBook> books = blc.FilterBooks("First", "", "", "");

            Assert.That(books.Count(), Is.EqualTo(1));
            Assert.That(books.First().Name, Is.EqualTo("First Book"));
        }

        [Test]
        public void ShouldFilterBooksByYearPublished()
        {
            PublisherMock publisher = new PublisherMock()
            {
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            BookMock firstBook = new BookMock()
            {
                Name = "First Book",
                YearPublished = 2000,
                Publisher = publisher,
                Type = BookType.Hardcover
            };
            BookMock secondBook = new BookMock()
            {
                Name = "Second Book",
                YearPublished = 2001,
                Publisher = publisher,
                Type = BookType.Paperback
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { publisher }, new List<BookMock>() { firstBook, secondBook }));

            IEnumerable<IBook> books = blc.FilterBooks("", "2000", "", "");

            Assert.That(books.Count(), Is.EqualTo(1));
            Assert.That(books.First().Name, Is.EqualTo("First Book"));
        }

        [Test]
        public void ShouldFilterBooksByType()
        {
            PublisherMock publisher = new PublisherMock()
            {
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            BookMock firstBook = new BookMock()
            {
                Name = "First Book",
                YearPublished = 2000,
                Publisher = publisher,
                Type = BookType.Hardcover
            };
            BookMock secondBook = new BookMock()
            {
                Name = "Second Book",
                YearPublished = 2001,
                Publisher = publisher,
                Type = BookType.Paperback
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { publisher }, new List<BookMock>() { firstBook, secondBook }));

            IEnumerable<IBook> books = blc.FilterBooks("", "", "Hardcover", "");

            Assert.That(books.Count(), Is.EqualTo(1));
            Assert.That(books.First().Name, Is.EqualTo("First Book"));
        }

        [Test]
        public void ShouldFilterBooksByPublisher()
        {
            PublisherMock firstPublisher = new PublisherMock()
            {
                ID = Guid.NewGuid(),
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            PublisherMock secondPublisher = new PublisherMock()
            {
                ID = Guid.NewGuid(),
                Name = "Second Publisher",
                Address = "Second Address",
                YearCreated = 2001
            };
            BookMock firstBook = new BookMock()
            {
                Name = "First Book",
                YearPublished = 2000,
                Publisher = firstPublisher,
                Type = BookType.Hardcover
            };
            BookMock secondBook = new BookMock()
            {
                Name = "Second Book",
                YearPublished = 2001,
                Publisher = secondPublisher,
                Type = BookType.Paperback
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { firstPublisher, secondPublisher }, new List<BookMock>() { firstBook, secondBook }));

            IEnumerable<IBook> books = blc.FilterBooks("", "", "", firstPublisher.ID.ToString());

            Assert.That(books.Count(), Is.EqualTo(1));
            Assert.That(books.First().Name, Is.EqualTo("First Book"));
        }

        [Test]
        public void ShouldGetAllYearsCreated()
        {
            PublisherMock firstPublisher = new PublisherMock()
            {
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            PublisherMock secondPublisher = new PublisherMock()
            {
                Name = "Second Publisher",
                Address = "Second Address",
                YearCreated = 2001
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { firstPublisher, secondPublisher }, new List<BookMock>()));

            IEnumerable<int> yearsCreated = blc.GetAllYearsCreated();

            Assert.That(yearsCreated.Count(), Is.EqualTo(2));
            Assert.That(yearsCreated.First(), Is.EqualTo(2000));
            Assert.That(yearsCreated.Last(), Is.EqualTo(2001));
        }

        [Test]
        public void ShouldGetAllYearsPublished()
        {
            PublisherMock publisher = new PublisherMock()
            {
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            BookMock firstBook = new BookMock()
            {
                Name = "First Book",
                YearPublished = 2000,
                Publisher = publisher,
                Type = BookType.Hardcover
            };
            BookMock secondBook = new BookMock()
            {
                Name = "Second Book",
                YearPublished = 2001,
                Publisher = publisher,
                Type = BookType.Paperback
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { publisher }, new List<BookMock>() { firstBook, secondBook }));

            IEnumerable<int> yearsPublished = blc.GetAllYearsPublished();

            Assert.That(yearsPublished.Count(), Is.EqualTo(2));
            Assert.That(yearsPublished.First(), Is.EqualTo(2000));
            Assert.That(yearsPublished.Last(), Is.EqualTo(2001));
        }

        [Test]
        public void ShouldGetPublishersWithBooks()
        {
            PublisherMock firstPublisher = new PublisherMock()
            {
                ID = Guid.NewGuid(),
                Name = "Publisher",
                Address = "Address",
                YearCreated = 2000
            };
            PublisherMock secondPublisher = new PublisherMock()
            {
                ID = Guid.NewGuid(),
                Name = "Second Publisher",
                Address = "Second Address",
                YearCreated = 2001
            };
            BookMock firstBook = new BookMock()
            {
                Name = "First Book",
                YearPublished = 2000,
                Publisher = firstPublisher,
                Type = BookType.Hardcover
            };
            BookMock secondBook = new BookMock()
            {
                Name = "Second Book",
                YearPublished = 2001,
                Publisher = firstPublisher,
                Type = BookType.Paperback
            };
            BLC.BLC blc = new BLC.BLC(getMockedDao(new List<PublisherMock>() { firstPublisher, secondPublisher }, new List<BookMock>() { firstBook, secondBook }));

            IEnumerable<IPublisher> publishers = blc.GetBooksPublishers();

            Assert.That(publishers.Count(), Is.EqualTo(1));
            Assert.That(publishers.First().Name, Is.EqualTo("Publisher"));
        }

        private IDAO getMockedDao(List<PublisherMock> publishers, List<BookMock> books)
        {
            return new MockDao(publishers, books);
        }
    }
}