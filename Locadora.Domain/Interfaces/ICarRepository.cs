using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsAsync();
        Task<Car> GetCarIdAsync(int id);
        Task<IEnumerable<Car>> GetCarsNameAsync(string carName);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<Car> DeleteCarAsync(Car car);
    }
}
