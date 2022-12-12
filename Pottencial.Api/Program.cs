using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pottencial.Data.Context;
using Pottencial.Data.Repository;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repository;
using Pottencial.Domain.Interfaces.Service;
using Pottencial.Service.Configurations;
using Pottencial.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PottencialContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Pottencial.Api")));

var status = new List<StatusVendaConfiguration>
            {
                new StatusVendaConfiguration(0, "Aguradando pagamento"),
                new StatusVendaConfiguration(1, "Pagamento aprovado"),
                new StatusVendaConfiguration(2, "Enviado para transportadora"),
                new StatusVendaConfiguration(3, "Entregue"),
                new StatusVendaConfiguration(4, "Cancelado"),
            };
builder.Services.AddSingleton(status);

builder.Services.AddScoped<IBaseRepository<ProdutoEntity>, BaseRepository<ProdutoEntity>>();
builder.Services.AddScoped<IBaseRepository<VendaEntity>, BaseRepository<VendaEntity>>();
builder.Services.AddScoped<IBaseRepository<VendedorEntity>, BaseRepository<VendedorEntity>>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendedorService, VendedorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PottencialVenda", Version = "v1" });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
