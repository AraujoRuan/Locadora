﻿using Locadora.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Domain.ValueObjects
{
    [NotMapped]
    public class Plate : ValueObject
    {
        public string Number
        {
            get; private set;
        }

        private Plate()
        {
        }

        public Plate(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new DomainExceptionValidation(" A placa do carro não pode ser vazio");
            if (number.Trim().Length < 7)
                throw new DomainExceptionValidation("A placa tem conter 7 caracter");
            if (number.Trim().Any(ch => char.IsPunctuation(ch)))
                throw new DomainExceptionValidation("A placa não pode conter caracter especial");
            Number = number.Trim();

        }

        public static implicit operator string(Plate plate) => plate.ToString();
        public static implicit operator Plate(string number) => new Plate(number);

        public override string ToString() => Number;

    }
}
