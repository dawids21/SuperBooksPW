using MatuszewskiStasiak.SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.DAOSQL.BO
{
    public class Publisher : IPublisher
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int YearCreated { get; set; }
        public List<IBook> Books { get; set; }
    }
}
