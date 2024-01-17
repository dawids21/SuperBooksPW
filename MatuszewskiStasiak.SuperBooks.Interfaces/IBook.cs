using MatuszewskiStasiak.SuperBooks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.Interfaces
{
    public interface IBook
    {
        int ID { get; set; }
        string Name { get; set; }
        IPublisher Publisher { get; set; }
        int YearPublished { get; set; }
        BookType Type { get; set; }
    }
}
