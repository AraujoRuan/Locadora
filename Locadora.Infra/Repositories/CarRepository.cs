using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Microsoft.EntityFrameworkCore;
using Car = Locadora.Infra.Models.Car;

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

        public void DeleteById(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> Get()
        {
            var cars = _context.Cars.ToList();
            return cars;
        }

        public Car GetById(Guid id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
