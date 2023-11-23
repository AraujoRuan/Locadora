using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Infra.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly AgenciaContext _context;


        public CompanyRepository(AgenciaContext context)
        {
            _context = context;
        }

        public void Create(Company company)
        {
            _context.Companys.Add(company);
            _context.SaveChanges();
        }

        public void DeleteById(Company company)
        {
            _context.Remove(company);
            _context.SaveChanges();
        }

        public IEnumerable<Company> Get()
        {
            var companys = _context.Companys.ToList();
            return companys;
        }

        public Company GetById(Guid id)
        {
            return _context.Companys.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

