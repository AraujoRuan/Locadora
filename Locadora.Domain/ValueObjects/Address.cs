using Locadora.Domain.Validation;

namespace Locadora.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string street, string number, string complement, string district, string city, string state, string zipCode)
        {
            if (string.IsNullOrEmpty(street)) throw new DomainExceptionValidation("Só pode Conter nome de Rua");
            Street = street;
            if (string.IsNullOrEmpty(number)) throw new DomainExceptionValidation("Só pode conter numeros");
            Number = number;
            if (string.IsNullOrEmpty(complement)) throw new DomainExceptionValidation("Só pode conter casa ou  Apartamento");
            Complement = complement;
            if (string.IsNullOrEmpty(district)) throw new DomainExceptionValidation("Só pode conter Distrito");
            District = district;
            if (string.IsNullOrEmpty(city)) throw new DomainExceptionValidation("Só pode conter Cidade");
            City = city;
            if (string.IsNullOrEmpty(state)) throw new DomainExceptionValidation("Só pode conter Estado");
            State = state;
            if (string.IsNullOrEmpty(zipCode)) throw new DomainExceptionValidation("Só pode Conter CEP");
            ZipCode = zipCode;
        }
        public static implicit operator string(Address address) => address.ToString();
        public static implicit operator Address(string street) => new Address(street);
    }
}
