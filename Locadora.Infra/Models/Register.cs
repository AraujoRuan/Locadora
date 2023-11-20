namespace Locadora.Infra.Models;

public partial class Register
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Cpf { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime Year { get; set; }
}