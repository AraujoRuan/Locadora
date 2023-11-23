using Locadora.Infra.Models;

namespace Locadora.Infra.Interfaces
{
    public interface ICompanyRepository
    {
        void Create(Company company);
        void Update(Company company);
        IEnumerable<Company> Get();
        Company GetById(Guid id);
        void DeleteById(Company company);
    }
}
