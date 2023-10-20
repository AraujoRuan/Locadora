using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Repositories;

    public class CarRepository : ICarRepository
    {
        private readonly AgenciaContext _context;
        
        public CarRepository(AgenciaContext context)
        {
            _context = context;
        }

        public  Task<List<Company>> GetCompanysAsync()
        {
            return _context.Companies.ToListAsync();
        }

        public Task<Car> GetCarIdAsync(int id)
        {
            return _context.Cars.GetCarIdAsync(id);
        }

        public Task<IEnumerable<Car>> GetCarsByNameAsync(string carName)
        {
            return _carRepositoryImplementation.GetCarsByNameAsync(carName);
        }

        public Task<Car> CreateCarAsync(Car car)
        {
            return _carRepositoryImplementation.CreateCarAsync(car);
        }

        public Task<Car> UpdateCarAsync(Car car)
        {
            return _carRepositoryImplementation.UpdateCarAsync(car);
        }

        public Task<Car> DeleteCarAsync(Car car)
        {
            return _carRepositoryImplementation.DeleteCarAsync(car);
        }
    }

