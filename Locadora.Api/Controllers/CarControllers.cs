using System.Windows.Input;
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("api/Car")]
    public class CarControllers : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarControllers(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

    }
}
