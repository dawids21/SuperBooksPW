using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBooks.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<ICar> GetAllCars();
        IProducer CreateNewProducer();
        ICar CreateNewCar();
    }
}
