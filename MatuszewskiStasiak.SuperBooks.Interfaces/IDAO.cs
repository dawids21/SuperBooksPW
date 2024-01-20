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
        IPublisher CreateNewPublisher(IPublisher publisher);
        IBook CreateNewBook(IBook book);
        void EditPublisher(IPublisher publisher);
        void DeletePublisher(IPublisher publisher);
        void EditBook(IBook book);
        void DeleteBook(IBook book);
        IBook GetBook(Guid id);
        IPublisher GetPublisher(Guid id);

        //TODO get all years publishers and books
    }
}
