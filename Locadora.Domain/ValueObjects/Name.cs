using Locadora.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName
        {
            get; private set;
        }
        public string LastName
        {
            get; private set;
        }

        public Name(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new DomainExceptionValidation("Primeiro nome ou sobrenome não podem ser nulos ou vazios");

            if (firstName.Length < 3 || lastName.Length < 3)
                throw new DomainExceptionValidation("Primeiro nome e sobrenome devem conter mais que 2 caracteres");

            if (firstName.Length > 100 || lastName.Length > 100)
                throw new DomainExceptionValidation("Primeiro nome e sobrenome devem conter menos que 100 caracterers");
        }

        private Name()
        {
        }

        public static implicit operator string(Name name) => name.ToString();

        public static implicit operator Name(string fullname)
        {
            var parts = fullname.Split(" ");

            return new Name(parts[0], parts[1]);
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
