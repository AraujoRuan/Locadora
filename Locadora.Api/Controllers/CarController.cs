using Locadora.Domain.Entities;
using Locadora.Infra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("/car")]
    public class CarController : Controller
    {
        private AgenciaContext _agenciaContext;
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
            Car _car = new Car(model.brand, model.color, model.plate, model.model);
            _agenciaContext.SaveChanges();
            return new JsonResult(_car);
        }
    }
}
