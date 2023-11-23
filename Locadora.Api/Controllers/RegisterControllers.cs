using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Locadora.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("api/Register")]
    public class RegisterControllers : Controller
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterControllers(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        [HttpGet]
        [Route("v1/Register")]
        public IActionResult Get() 
        {
            var registers = _registerRepository.Get();
            return Ok(registers);
        }

        [HttpGet]
        [Route("v1/Register/{id}")]
        public IActionResult GetById(Guid id)
        {
            var register = _registerRepository.GetById(id);
            if (register == null)
            {
                return NotFound();
            }
            return Ok(register);
        }

        [HttpPost]
        [Route("v1/company")]
        [ProducesResponseType(typeof(Register), 201)]
        public IActionResult Post([FromBody] Register register)
        {
            try
            {
                _registerRepository.Create(register);

                return Created("Ok", register);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/register")]
        public IActionResult Update(Register register) 
        {
            _registerRepository.Update(register);
            return Ok(register);
        }

        [HttpDelete]
        [Route("v1/Register")]
        public IActionResult Delete(Register register) 
        {
            _registerRepository.DeleteById(register);
            return Ok();
        }
    }
}
