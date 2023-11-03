using BaltaStore.Shared.Entities;

namespace Locadora.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public string Address{ get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

    }
}
