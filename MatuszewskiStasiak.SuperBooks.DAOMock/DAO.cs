using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.DAOMock.BO;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.DAOMock
{
    public class DAO : IDAO
    {
        private List<IPublisher> publishers;
        private List<IBook> books;

        public DAO()
        {
            var examplePublisher = new Publisher
            {
                ID = Guid.NewGuid(),
                Name = "Test",
                Address = "zielona 2",
                YearCreated = 2022,
                Books = new List<IBook>()
            };

            var exampleBook = new Book
            {
                ID = Guid.NewGuid(),
                Name = "Test",
                Type = BookType.Ebook,
                YearPublished = 2023,
                Publisher = examplePublisher
            };

            examplePublisher.Books.Add(exampleBook);
            publishers = new List<IPublisher>()
            {
                examplePublisher
            };

            books = new List<IBook>()
            {
                exampleBook
            };
        }

        public IBook CreateNewBook(string name, Guid publisherID, int yearPublished, BookType type)
        {
            Publisher? publisher = (Publisher?)GetPublisher(publisherID);
            if (publisher == null)
            {
                throw new ArgumentException("Publisher not found");
            }
            Book book = new Book
            {
                ID = Guid.NewGuid(),
                Name = name,
                Publisher = publisher,
                YearPublished = yearPublished,
                Type = type
            };
            books.Add(book);
            publisher.Books.Add(book);
            return book;
        }

        public IPublisher CreateNewPublisher(string name, string address, int yearCreated)
        {
            var publisher = new Publisher
            {
                ID = Guid.NewGuid(),
                Name = name,
                Address = address,
                YearCreated = yearCreated,
                Books = new List<IBook>()
            };
            publishers.Add(publisher);
            return publisher;
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return books;
        }

        public IEnumerable<IPublisher> GetAllPublishers()
        {
            return publishers;
        }

        public void EditPublisher(Guid id, string name, string address, int yearCreated)
        {
            int i;
            for (i = 0; i < publishers.Count(); i++)
            {
                if (publishers[i].ID.Equals(id))
                {
                    break;
                }
            }
            publishers[i].Name = name;
            publishers[i].Address = address;
            publishers[i].YearCreated = yearCreated;
        }

        public void DeletePublisher(Guid id)
        {
            int i;
            for (i = 0; i < publishers.Count(); i++)
            {
                if (publishers[i].ID.Equals(id))
                {
                    break;
                }
            }
            books.RemoveAll(book => book.Publisher.ID == publishers[i].ID);
            publishers.RemoveAt(i);
        }

        public void EditBook(Guid id, string name, Guid publisherID, int yearPublished, BookType type)
        {
            int i;
            for (i = 0; i < books.Count(); i++)
            {
                if (books[i].ID == id)
                {
                    break;
                }
            }
            Publisher? publisher = (Publisher?)GetPublisher(publisherID);
            if (publisher == null)
            {
                throw new ArgumentException("Publisher not found");
            }
            books[i].Name = name;
            books[i].Publisher = publisher;
            books[i].YearPublished = yearPublished;
            books[i].Type = type;
        }

        public void DeleteBook(Guid id)
        {
            int i;
            for (i = 0; i < books.Count(); i++)
            {
                if (books[i].ID == id)
                {
                    break;
                }
            }
            books.RemoveAt(i);
        }

        public IBook? GetBook(Guid id)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                if (books[i].ID == id)
                {
                    return books[i];
                }
            }
            return null;
        }

        public IPublisher? GetPublisher(Guid id)
        {
            for (int i = 0; i < publishers.Count(); i++)
            {
                if (publishers[i].ID == id)
                {
                    return publishers[i];
                }
            }
            return null;
        }
    }
}
