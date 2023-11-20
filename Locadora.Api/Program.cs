using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Locadora.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Math.EC.ECCurve;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgenciaContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://0.0.0.0:8090");

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Name = "X-CSRF-TOKEN";
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.HeaderName = "X-CSRF-TOKEN-HEADER";
});
builder.Services.AddCors();

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddTransient<ICarRepository, CarRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    var config = builder.Configuration.GetSection("BusinessName");

    var name = app.Environment.ApplicationName;
    var development = app.Environment.IsDevelopment();
    var production = app.Environment.IsProduction();
    var server = "[" + config.Value + "] " + name +
                 (development ? "-Development" : production ? "-Production" : "-Staging");

    context.Response.Headers["Server"] = server;
    context.Response.Headers["X-Powered-By"] = server;
    context.Response.Headers["X-Author"] = "Ruan The Best";
    await next();
});

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
