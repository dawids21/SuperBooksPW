using SuperBooks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBooks.Interfaces
{
    public interface ICar
    {
        int ID { get; set; }
        string Name { get; set; }
        IProducer Producer { get; set; }
        int ProductionYear { get; set; }
        TransmissionType Transmission { get; set; }
    }
}
