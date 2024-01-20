using MatuszewskiStasiak.SuperBooks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IPublisher> GetAllPublishers();
        IEnumerable<IBook> GetAllBooks();
        IPublisher CreateNewPublisher(string name, string address, int yearCreated);
        IBook CreateNewBook(string name, Guid publisher, int yearPublished, BookType type);
        void EditPublisher(Guid id, string name, string address, int yearCreated);
        void DeletePublisher(Guid id);
        void EditBook(Guid id, string name, Guid publisher, int yearPublished, BookType type);
        void DeleteBook(Guid id);
        IBook? GetBook(Guid id);
        IPublisher? GetPublisher(Guid id);

        //TODO get all years publishers and books
    }
}
