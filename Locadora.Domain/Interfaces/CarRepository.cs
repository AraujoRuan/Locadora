using System;
using System.Collections.Generic;
using System.Linq;
using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface CarRepository
    {
        void Create (Car car);
        void Update (Car car);
        Car GetBayId(Guid id,string brand);
        Car DeleteBayId(Guid id);
    

    }
}
