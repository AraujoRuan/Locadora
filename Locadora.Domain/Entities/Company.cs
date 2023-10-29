using Locadora.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Domain.Entities;

[NotMapped]
public class Company : Entity
{
    public Company(Name _name, Cnpj _cnpj, Address _address, Phone _phone, Email _email)
    {
        name = _name;
        cnpj = _cnpj;
        address = _address;
        phone = _phone;
        email = _email;
    }

    public Company()
    {
    }

    public Name name { get; private set; }
    public Cnpj cnpj { get; private set; }
    public Address address { get; private set; }
    public Phone phone { get; private set; }
    public Email email { get; private set; }
}