using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("api/Company")]
    public class CompanyControllers : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyControllers(ICompanyRepository companyRepository) 
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        [Route("api/company")]
        public IActionResult Get()
        {
            var companys = _companyRepository.Get();
            return Ok(companys);

        }

        [HttpGet]
        [Route("api/company/{id}")]
        public IActionResult GetById(Guid id) 
        {
            var company = _companyRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        [Route("v1/company")]
        [ProducesResponseType(typeof(Company), 201)]
        public IActionResult Post([FromBody] Company company)
        {
            try
            {
                _companyRepository.Create(company);

                return Created("Ok", company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/campany")]
        public IActionResult Update( Company company) 
        {
            _companyRepository.Update(company);
            return Ok(company);
        }

        [HttpDelete]
        [Route("v1/company")]
        public IActionResult Delete(Company company) 
        {
            _companyRepository.DeleteById(company);
            return Ok(company);
        }
    }
}
