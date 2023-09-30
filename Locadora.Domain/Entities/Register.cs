namespace Locadora.Domain.Entities;

public class Register : Entity
{

    public Register(string name, string cPF, string address, string email, string phone)
    {
        Name = name;
        CPF = cPF;
        Address = address;
        Email = email;
        this.Phone = phone;
    }

    public string Name { get; private set; }
    public string CPF { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public DateTime Year { get; private set; }
}
