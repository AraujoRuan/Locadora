using Locadora.Domain.Validation;

namespace Locadora.Domain.ValueObjects;

    public class Brand :ValueObject
    {
        public string Fullname { get; set; }

        public Brand(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new DomainExceptionValidation(" A marca do carro não pode ser vazio");

            if (fullName.Trim().Length < 2 || fullName.Length > 100)
                throw new DomainExceptionValidation("A marca do carro deve conter entre 2 e 100 caracteres");

            if (fullName.Trim().Any(ch => char.IsPunctuation(ch)))
                throw new DomainExceptionValidation("A marca do caro não deve conter caracter especial");

            Fullname = fullName;
        }

        public Brand()
        {
        }

        public static implicit operator string(Brand brand) => brand.ToString();
        public static implicit operator Brand(string fullName) => new Brand(fullName);
        public override string ToString() => Fullname;
    }
    

