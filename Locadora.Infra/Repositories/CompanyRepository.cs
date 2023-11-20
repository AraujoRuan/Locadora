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

        public void DeleteBayId(Company company)
        {
            _context.Companys.Remove(company);
            _context.SaveChanges();
        }

        public Company GetBayId(Guid id, string cnpj)
        {
            return _context.Companys.FirstOrDefault(x => x.Id == id && x.Cnpj == cnpj);
        }

        public void Update(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
        }

        void ICompanyRepository.create(Company company)
        {
            throw new NotImplementedException();
        }

        void ICompanyRepository.delete(Company company)
        {
            throw new NotImplementedException();
        }

        Company ICompanyRepository.GetById(Guid id, string cnpj)
        {
            throw new NotImplementedException();
        }

        void ICompanyRepository.update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}

