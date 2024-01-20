using MatuszewskiStasiak.SuperBooks.Core;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.DAOMock1.BO
{
    public class Book : IBook
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public IPublisher Publisher { get; set; }
        public int YearPublished { get; set; }
        public BookType Type { get; set; }
    }
}
