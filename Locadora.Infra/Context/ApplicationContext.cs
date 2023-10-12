using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Locadora.Infra.Context;

public class ApplicationContext : DbContext
{
    private readonly IConfiguration configuration;

    public ApplicationContext(DbContextOptions<ApplicationContext> option, IConfiguration _configuration
    ) : base(option)
    {
        configuration = _configuration;
    }


    public DbSet<Car> Cars { get; set; } = null;
    public DbSet<Company> Companys { get; set; } = null;
    public DbSet<Register> Registers { get; set; } = null;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
}