using SuperBooks.Core;
using SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBooks.DAOMock2
{
    public class DAOMock : IDAO
    {
        private List<IPublisher> producers;
        private List<IBook> cars;

        public DAOMock()
        {
            producers = new List<IPublisher>()
            {
                new BO.Producer() { ID = 1, Name = "Skoda" },
                new BO.Producer() { ID = 2, Name = "Fiat" },
            };

            cars = new List<IBook>()
            {
                new BO.Car()
                {
                    ID = 1,
                    Publisher = producers[0],
                    Name = "Fabia",
                    YearPublished = 2020,
                    Type = BookType.Automatic,
                },
                new BO.Car()
                {
                    ID = 2,
                    Publisher = producers[0],
                    Name = "Octavia",
                    YearPublished = 2022,
                    Type = BookType.Automatic,
                },
                new BO.Car()
                {
                    ID = 3,
                    Publisher = producers[1],
                    Name = "Panda",
                    YearPublished = 2019,
                    Type = BookType.Manual,
                },
            };
        }

        public IBook CreateNewBook()
        {
            return new BO.Car();
        }

        public IPublisher CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return cars;
        }

        public IEnumerable<IPublisher> GetAllPublishers()
        {
            return producers;
        }
    }
}
