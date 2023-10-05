using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface IRegisterRepository
    {
        Task<IEnumerable<Register>> GetRegisterAsync();
        Task<Register> GetRegisterIdAsync(int id);
        Task<IEnumerable<Register>> GetRegisterNameAsync(string registerName);
        Task<Register> CreateRegisterAsync(Register register);
        Task<Register> UpdateRegisterAsync(Register register);
        Task<Register> DeleteRegisterAsync(Register register);
    }
}
