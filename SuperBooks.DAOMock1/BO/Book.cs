using SuperBooks.Core;
using SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBooks.DAOMock1.BO
{
    public class Book : IBook
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IPublisher Publisher { get; set; }
        public int YearPublished { get; set; }
        public BookType Type { get; set; }
    }
}
