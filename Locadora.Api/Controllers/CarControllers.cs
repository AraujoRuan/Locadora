using System.Windows.Input;
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("v1/Car")]
    public class CarControllers : Controller
    {
        private readonly ICarRepository _repository;

        [Route("")]
        [HttpGet]
        public IEnumerable<Car> Get(string car)
        {
            return _repository.Get(car);
        }

    }
}
