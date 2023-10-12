using Locadora.Domain.Validation;
using Microsoft.IdentityModel.Tokens;

namespace Locadora.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        public string _cpf { get; private set; }

        public Cpf(string cpf)
        {
            if (cpf.Length != 11)
            {
                throw new DomainExceptionValidation("Digite um cpf com exatamente 11 caracteres vállidos");
            }

            if (!checkCpf(cpf))
            {
                throw new DomainExceptionValidation("Digite um cpf válido");
            }
            _cpf = cpf;
        }
        private bool checkCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return false;
            }

            cpf = cpf.Replace(".", "").Replace("-", "");

            // Primeiro dígito verificador

            int digito1 = 0;
            for (int i = 0; i < 9; i++)
            {
                digito1 += (i + 1) * int.Parse(cpf[i].ToString());
            }

            digito1 = 11 - (digito1 % 11);
            if (digito1 > 9)
            {
                digito1 = 0;
            }

            // Segundo dígito verificador

            int digito2 = 0;
            for (int i = 0; i < 10; i++)
            {
                digito2 += (i + 1) * int.Parse(cpf[i].ToString());
            }

            digito2 = 11 - (digito2 % 11);
            if (digito2 > 9)
            {
                digito2 = 0;
            }

            return (digito1 == int.Parse(cpf[9].ToString()) && digito2 == int.Parse(cpf[10].ToString()));
        }
    }
}
