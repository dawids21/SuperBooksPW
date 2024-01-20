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
        IBook CreateNewBook(IBook book);
        void EditPublisher(Guid id, string name, string address, int yearCreated);
        void DeletePublisher(Guid id);
        void EditBook(IBook book);
        void DeleteBook(IBook book);
        IBook? GetBook(Guid id);
        IPublisher? GetPublisher(Guid id);

        //TODO get all years publishers and books
    }
}
