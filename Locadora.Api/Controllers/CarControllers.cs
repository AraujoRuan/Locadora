using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("v1/car")]
        public IActionResult Get()
        {
            var cars = _carRepository.Get();
            return Ok(cars);

        }

        [HttpGet]
        [Route("v1/car/{id}")]
        public IActionResult GetById(Guid id)
        {
            var car = _carRepository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        [Route("v1/car")]
        [ProducesResponseType(typeof(Car), 201)]
       
        public IActionResult Post([FromBody] Car car)
        {
            try
            {
                _carRepository.Create(car);

                return Created("Ok", car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/car/")]
        public IActionResult Update(Car car)
        {
            _carRepository.Update(car);
            return Ok(car);
        }
        [HttpDelete]
        [Route("v1/car/")]
        public IActionResult Delete(Car car)
        {
            _carRepository.DeleteById(car);
            return Ok();
        }


    }
}
