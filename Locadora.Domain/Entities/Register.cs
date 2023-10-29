using Locadora.Domain.ValueObjects;

namespace Locadora.Domain.Entities;

public class Register : Entity
{
    public Register(Name _name, Cpf _cpf, Address _address, Email _email, Phone _phone)
    {
        name = _name;
        cpf = _cpf;
        address = _address;
        email = _email;
        phone = _phone;
    }

    public Register()
    {
    }

    public Name name { get; private set; }
    public Cpf cpf { get; private set; }
    public Address address { get; private set; }
    public Email email { get; private set; }
    public Phone phone { get; private set; }
    public DateTime Year { get; private set; }
}