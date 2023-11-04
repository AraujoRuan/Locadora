using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Queries;
using Locadora.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AgenciaContext _context;

        public CarRepository(AgenciaContext context)
        {
            _context = context;
        }

        public void Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteBayId(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> Get(string car)
        {
            return _context.Cars.AsNoTracking().Where(CarQueries.Get(car)).OrderBy(x => x.year);
        }

        public Car GetBayId(Guid id, string brand)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id && x.Brand == brand);
        }

        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
