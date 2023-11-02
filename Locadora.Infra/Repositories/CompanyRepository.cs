
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Validation;
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

        public async Task<IEnumerable<Company>> GetCompanysCarsAsync() => await _context.Companies.Include(x => x.name).AsNoTracking().ToListAsync();
        
        public async Task<Company> GetCompanyCarsByIdAsync(Guid id) => await _context.Companies.Include(X => X.name).AsNoTracking().SingleOrDefaultAsync(X => X.Id == id) ?? throw new DomainExceptionValidation($"Company cannot be found by id - {id}");

        public async Task<IEnumerable<Company>> GetCompanysCarsByNameAsync(string companyName)
        {
          var names = companyName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
          var query = _context.Companies.Include(x => x.name).AsNoTracking();

          foreach (var name in names)
          { 
              query = query.Where(x => x.cnpj.Number.Contains(name));
          }

          var companies = await query.ToListAsync();

          if (companies.Count == 0) throw new DomainExceptionValidation($"Company cannot by found by name - {companyName}");

          return companies;
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }
        
        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }


        public async Task<Company> DeleteCompanyAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return company;
        }
    }
}
