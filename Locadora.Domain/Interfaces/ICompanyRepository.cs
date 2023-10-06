using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanysAsync();
        Task<Company> GetCompanyIdAsync(int id);
        Task<IEnumerable<Company>> GetCompanysNameAsync(string companysName);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<Company> DeleteCompanyAsync(Company company);
    }
}
