using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Controllers;
using Microsoft.EntityFrameworkCore;
using ArvoreGen_2.Server.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar o DbContext para usar o PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registrar o IPessoaService com a implementação PessoaService
builder.Services.AddScoped<IPessoaService, PessoaService>();

builder.Services.AddControllers();

// Swagger e OpenAPI para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
