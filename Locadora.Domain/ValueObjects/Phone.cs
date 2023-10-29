using Locadora.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.RegularExpressions;

namespace Locadora.Domain.ValueObjects
{
    [NotMapped]
    public class Phone : ValueObject
    {
        const string Pattern = @"\w+@\w+\.\w+";

        public string Number{ get; private set; }

        public Verification Verification { get; set; } = new Verification();

        private static Regex NumberRegex() => new Regex(Pattern);

        private Phone()
        {

        }

        public Phone(string number)
        {

            if (string.IsNullOrEmpty(number)) throw new Exception("O numero não pode ser vazio");

            if (Number.Length < 5) throw new Exception("O numero deve conter mais que 5 digito");

            if (!NumberRegex().IsMatch(Number)) throw new Exception("O numero inserido não está com formato válido");

            Number = number.Trim().ToLower();
        }
        
        public static implicit operator string(Phone phone) => phone.ToString();
        public static implicit operator Phone(string phone) => new Phone(phone);
        public override string ToString() => Number;

        public void ResendVerification() => Verification = new Verification();
    }
}
