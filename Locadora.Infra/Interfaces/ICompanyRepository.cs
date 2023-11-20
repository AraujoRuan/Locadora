using Locadora.Infra.Models;

namespace Locadora.Infra.Interfaces
{
    public interface ICompanyRepository
    {
        void create(Company company);
        void update(Company company);
        Company GetById(Guid id, string cnpj);
        void delete(Company company);
    }
}
