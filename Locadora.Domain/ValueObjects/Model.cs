using Locadora.Domain.Validation;

namespace Locadora.Domain.ValueObjects;

    public class Model : ValueObject
{
   public string Fullname { get; private set; }
    public Model(string fullName)
    {
        if (string.IsNullOrEmpty(fullName)) throw new DomainExceptionValidation(" O nome do modelo carro não pode ser vazio");
         Fullname = fullName;
    }

    public static implicit operator string(Model model) => model.ToString();
    public static implicit operator Model(string fullName) => new Model(fullName); 
    public override string ToString() => Fullname;
}
