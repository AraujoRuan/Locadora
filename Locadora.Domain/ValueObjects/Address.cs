using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Locadora.Domain.Validation;

namespace Locadora.Domain.ValueObjects
{
    [NotMapped]
    public class Address : ValueObject
    {
        [Key] public int Id { get; protected set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address()
        {
        }

        public Address(string street, string number, string complement, string district, string city, string state,
            string zipCode)
        {
            if (string.IsNullOrEmpty(street)) throw new DomainExceptionValidation("Só pode Conter nome de Rua");
            Street = street;
            if (string.IsNullOrEmpty(number)) throw new DomainExceptionValidation("Só pode conter numeros");
            Number = number;
            if (!string.IsNullOrEmpty(complement))
            {
                if (complement.IndexOf("casa") > 0 || complement.IndexOf("ap") > 0)
                {
                    throw new DomainExceptionValidation("Só pode conter casa ou Apartamento(ap)");
                }
            }

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

        public static implicit operator Address(string adress)
        {
            // adressComplete = "Rua One,12,,Bairro,RJ,SP,021"
            string[] adressComplete = adress.Split(",");
            string street = adressComplete[0];
            string number = adressComplete[1];
            string complement = adressComplete[2];
            string district = adressComplete[3];
            string city = adressComplete[4];
            string state = adressComplete[5];
            string zipCode = adressComplete[6];

            return new Address(street, number, complement, district, city, state, zipCode);
        }

        public override string ToString() => $"{Street} {Number} {Complement} {District} {City} {State} {ZipCode} ";
    }
}