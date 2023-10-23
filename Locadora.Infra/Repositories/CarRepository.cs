using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Validation;
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
 
        public async Task<IEnumerable<Car>> GetCarsCompanysAsync() => await _context.Cars.Include(x =>x.name).AsNoTracking().ToListAsync();
        public async Task<Car> GetCarCompanysAsync(int id) => await _context.Cars.Include(x => x.name).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Car cannot be found by id - {id}");

        public async Task<IEnumerable<Car>> GetCarsCompanysByNameAsync(string carName)
        {
            var names = carName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var query = _context.Cars.Include(x => x.name).AsNoTracking();

            foreach (var name in names)
            {
                query = query.Where(x => x.name.FirstName.Contains(name) || x.name.LastName.Contains(name));
            }

            var cars = await query.ToListAsync();

            if (cars.Count == 0) throw new DomainExceptionValidation($"Car cannot by found by name - {carName}");

            return cars;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();

                return car;
            }
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> DeleteCarAsync(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }

