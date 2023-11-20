using Locadora.Infra.Models;

namespace Locadora.Infra.Interfaces
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Update(Car car);
        IEnumerable<Car> Get();
        Car GetById(Guid id);
        void DeleteById(Car car);
    }
}
