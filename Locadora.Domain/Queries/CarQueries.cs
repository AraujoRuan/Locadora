using System.Linq.Expressions;
using Locadora.Domain.Entities;

namespace Locadora.Domain.Queries
{
    public static class CarQueries
    {
        
        public static Expression<Func<Car, bool>> Get(string car)
        {
            return x => x.Brand == car;
        }
    }
}
