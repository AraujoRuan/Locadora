using Locadora.Domain.ValueObjects;

namespace Locadora.Domain.Entities;

public class Company : Entity
{
    public Company(Name _name, int cNPJ, string address, int phone, string email)
    {
        name = _name;
        CNPJ = cNPJ;
        Address = address;
        Phone = phone;
        Email = email;
    }

    public Name name { get; private set; }
    public int CNPJ { get; private set; }
    public string Address { get; private set; }
    public int Phone { get; private set; }
    public string Email { get; private set; }
    
}
