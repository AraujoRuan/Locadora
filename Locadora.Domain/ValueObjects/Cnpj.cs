using Locadora.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.ValueObjects
{
    public class Cnpj :ValueObject
    {
        public string Number
        {
            get; private set;
        }
        public Cnpj(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new DomainExceptionValidation("Digite o numero");
            Number = number;
        }
        private Cnpj()
        {
        }

        public static implicit operator string(Cnpj cnpj) => cnpj.ToString();
        public static implicit operator Cnpj(string number) => new Cnpj(number);

        public override string ToString() => Number;
    }
}
