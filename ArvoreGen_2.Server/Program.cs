using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Controllers;
using Microsoft.EntityFrameworkCore;
using ArvoreGen_2.Server.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar o DbContext para usar o PostgreSQL e Registrar o IPessoaService com a implementação PessoaService
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPessoaService, PessoaService>();

builder.Services.AddControllers();

// Swagger e OpenAPI para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar arquivos estáticos (deve estar na pasta 'ClientApp/build' após rodar 'npm run build' no React)
app.UseDefaultFiles();  // Carregar o 'index.html' por padrão
app.UseStaticFiles();   // Servir os arquivos estáticos gerados do React

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();  // Configure a rota para API e arquivos estáticos
app.UseAuthorization();

app.MapControllers();

// Roteamento do SPA: redireciona todas as requisições para o React quando não for uma API
app.MapFallbackToFile("/index.html");

app.UseResponseCompression();  // Certifique-se que a resposta está sendo comprimida corretamente
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Type", "text/html; charset=utf-8");
    await next();
});


app.Run();
