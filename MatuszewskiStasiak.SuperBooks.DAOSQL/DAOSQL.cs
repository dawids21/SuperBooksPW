using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.DAOMock1.BO;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.DAOMock1
{
    public class DAOSQL : IDAO
    {
        private List<IPublisher> publishers;
        private List<IBook> books;

        public DAOSQL()
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

        public IBook CreateNewBook(IBook book)
        {
            book.ID = Guid.NewGuid();
            books.Add(book);
            return book;
        }

        public IPublisher CreateNewPublisher(IPublisher publisher)
        {
            publisher.ID = Guid.NewGuid();
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

        public void EditPublisher(IPublisher publisher)
        {
            int i;
            for (i = 0; i < publishers.Count(); i++)
            {
                if (publishers[i].ID == publisher.ID)
                {
                    break;
                }
            }
            publishers[i] = publisher;
        }

        public void DeletePublisher(IPublisher publisher)
        {
            int i;
            for (i = 0; i < publishers.Count(); i++)
            {
                if (publishers[i].ID == publisher.ID)
                {
                    break;
                }
            }
            publishers.RemoveAt(i);
        }

        public void EditBook(IBook book)
        {
            int i;
            for (i = 0; i < books.Count(); i++)
            {
                if (books[i].ID == book.ID)
                {
                    break;
                }
            }
            books[i] = book;
        }

        public void DeleteBook(IBook book)
        {
            int i;
            for (i = 0; i < books.Count(); i++)
            {
                if (books[i].ID == book.ID)
                {
                    break;
                }
            }
            publishers.RemoveAt(i);
        }

        public IBook GetBook(Guid id)
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

        public IPublisher GetPublisher(Guid id)
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
