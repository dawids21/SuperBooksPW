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
    public class DAOMock : IDAO
    {
        private List<IPublisher> publishers;
        private List<IBook> books;
        private int NextId { get; set; } = 3;

        public DAOMock()
        {
            publishers = new List<IPublisher>()
            {
                new Publisher
                {
                    ID = 1,
                    Name = "Test",
                    Address = "zielona 2",
                    YearCreated = 2022
                }
            };

            books = new List<IBook>()
            {

                new Book
                {
                    ID = 2,
                    Name = "Test",
                    Type = BookType.Ebook,
                    YearPublished = 2023,
                    Publisher = publishers[0]
                }
            };
        }

        public IBook CreateNewBook(IBook book)
        {
            book.ID = NextId;
            NextId += 1;
            books.Add(book);
            return book;
        }

        public IPublisher CreateNewPublisher(IPublisher publisher)
        {
            publisher.ID = NextId;
            NextId += 1;
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
            int i = 0;
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
            int i = 0;
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
            int i = 0;
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
            int i = 0;
            for (i = 0; i < books.Count(); i++)
            {
                if (books[i].ID == book.ID)
                {
                    break;
                }
            }
            publishers.RemoveAt(i);
        }

        public IBook GetBook(int id)
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

        public IPublisher GetPublisher(int id)
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
