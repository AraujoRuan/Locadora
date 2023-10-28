using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Locadora.Domain.Entities;
using Locadora.Infra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("/car")]
    public class CarController : Controller
    {
        protected AgenciaContext _agenciaContext;
        public CarController(AgenciaContext dbContext)
        {
            _agenciaContext = dbContext;
        }
        [HttpGet]
        [Route("getCars")]
        public IActionResult GetCars()
        {
            return new JsonResult(_agenciaContext.Cars.FirstOrDefault());
        }

        [HttpPost]
        [Route("postCar")]
        public IActionResult PostCars(Car model)
        {
            Car _car = new Car(model.name, model.color, model.plate, model.model);
            _agenciaContext.SaveChanges();
            return new JsonResult(_car);
        }
    }
}
