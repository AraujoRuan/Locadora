namespace Locadora.Domain.Entities
{
    public class Register : Entity
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime Year { get; private set; }
    }
}
