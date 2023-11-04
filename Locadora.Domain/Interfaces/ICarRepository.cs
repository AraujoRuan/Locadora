using System;
using System.Collections.Generic;
using System.Linq;
using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface ICarRepository
    {
        void Create (Car car);
        void Update (Car car);
        IEnumerable<Car> Get(string car);
        Car GetBayId(Guid id,string brand);
        void DeleteBayId(Car car);
    }
}
