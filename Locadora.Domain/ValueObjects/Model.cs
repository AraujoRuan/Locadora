using Locadora.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Domain.ValueObjects;

public class Model : ValueObject
{
    public string Fullname { get; private set; }

    public Model(string fullName)
    {
        if (string.IsNullOrEmpty(fullName))
            throw new DomainExceptionValidation(" O nome do modelo carro não pode ser vazio");

        if (fullName.Trim().Length < 2 || fullName.Length > 100)
            throw new DomainExceptionValidation("O modelo do carro deve conter entre 2 e 100 caracteres");

        if (fullName.Trim().Any(ch => char.IsPunctuation(ch)))
            throw new DomainExceptionValidation("o modelo do caro não deve conter caracter especial");

        Fullname = fullName;
    }

    public Model()
    {
    }

    public static implicit operator string(Model model) => model.ToString();
    public static implicit operator Model(string fullName) => new Model(fullName);
    public override string ToString() => Fullname;
}