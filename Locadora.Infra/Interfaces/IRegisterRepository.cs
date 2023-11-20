using Locadora.Infra.Models;

namespace Locadora.Infra.Interfaces
{
    public interface IRegisterRepository
    {
        void Create(Register register);
        void Update(Register register);
        IEnumerable<Register> Get();
        Register GetById(Guid id, string Name);
        void DeleteById(Register register);
    }
}
