using Locadora.Domain.Validation;

namespace Locadora.Domain.ValueObjects;

public class Color : ValueObject
{
    public string Cor { get; private set; }

    public Color()
    {
    }

    public Color(string cor)
    {
        if (string.IsNullOrEmpty(cor)) throw new DomainExceptionValidation("Digite a cor desejada");
        Cor = cor;
    }

    public static implicit operator string(Color cor) => cor.ToString();
    public static implicit operator Color(string cor) => new Color(cor);
    public override string ToString() => Cor;
}