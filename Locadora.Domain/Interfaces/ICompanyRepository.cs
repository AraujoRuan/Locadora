using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanyAsync();
        Task<Company> GetCompanyIdAsync(int id);
        Task<IEnumerable<Company>> GetCompanyNameAsync(string companyName);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<Company> DeleteCompanyAsync(Company company);
    }
}
