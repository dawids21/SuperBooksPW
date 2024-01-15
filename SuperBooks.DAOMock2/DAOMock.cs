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
        private List<IProducer> producers;
        private List<ICar> cars;

        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() { ID = 1, Name = "Skoda" },
                new BO.Producer() { ID = 2, Name = "Fiat" },
            };

            cars = new List<ICar>()
            {
                new BO.Car()
                {
                    ID = 1,
                    Producer = producers[0],
                    Name = "Fabia",
                    ProductionYear = 2020,
                    Transmission = TransmissionType.Automatic,
                },
                new BO.Car()
                {
                    ID = 2,
                    Producer = producers[0],
                    Name = "Octavia",
                    ProductionYear = 2022,
                    Transmission = TransmissionType.Automatic,
                },
                new BO.Car()
                {
                    ID = 3,
                    Producer = producers[1],
                    Name = "Panda",
                    ProductionYear = 2019,
                    Transmission = TransmissionType.Manual,
                },
            };
        }

        public ICar CreateNewCar()
        {
            return new BO.Car();
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IEnumerable<ICar> GetAllCars()
        {
            return cars;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }
    }
}
