using Locadora.Domain.Entities;


namespace Locadora.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsCompanysAsync();
        Task<Car> GetCarCompanysAsync(int id);
        Task<IEnumerable<Car>> GetCarsCompanysByNameAsync(string carName);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<Car> DeleteCarAsync(Car car);
    }
}
