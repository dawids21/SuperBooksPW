using SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBooks.DAOMock1.BO
{
    public class Publisher : IPublisher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int YearCreated { get; set; }
    }
}
