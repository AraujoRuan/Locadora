using Locadora.Domain.Entities;

namespace Locadora.Domain.Interfaces
{
    public interface IRegisterRepository
    {
        Task<IEnumerable<Register>> GetAllRegistersAsync();
        Task<Register> GetRegisterIdAsync(Guid id);
        Task<IEnumerable<Register>> GetRegistersNameAsync(string registersName);
        Task<Register> CreateRegisterAsync(Register register);
        Task<Register> UpdateRegisterAsync(Register register);
        Task<Register> DeleteRegisterAsync(Register register);
    }
}
