using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanysCarsAsync();
        Task<Company> GetCompanyCarsByIdAsync(int id);
        Task<IEnumerable<Company>> GetCompanysCarsByNameAsync(string companyName);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<Company> DeleteCompanyAsync(Company company);
    }
}
