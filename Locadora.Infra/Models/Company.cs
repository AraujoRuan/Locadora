namespace Locadora.Infra.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Cnpj { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }
}