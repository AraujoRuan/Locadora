using Locadora.Domain.Validation;

namespace Locadora.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public string Number{ get; private set; }

        public Phone(string number)
        {
            if (string.IsNullOrEmpty(number)) throw new DomainExceptionValidation(" Digite o numero de Celular com o DD");
            Number = number;
        }
        
        public static implicit operator string(Phone number) => number.ToString();
        public static implicit operator Phone(string phone) => new Phone(phone);
        public override string ToString() => Number;
    }
}
