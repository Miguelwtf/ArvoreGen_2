using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Controllers;
using Microsoft.EntityFrameworkCore;
using ArvoreGen_2.Server.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar o DbContext para usar o PostgreSQL e Registrar o IPessoaService com a implementa��o PessoaService
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPessoaService, PessoaService>();

builder.Services.AddControllers();

// Swagger e OpenAPI para documenta��o
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar arquivos est�ticos (deve estar na pasta 'ClientApp/build' ap�s rodar 'npm run build' no React)
app.UseDefaultFiles();  // Carregar o 'index.html' por padr�o
app.UseStaticFiles();   // Servir os arquivos est�ticos gerados do React

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
app.UseRouting();  // Configure a rota para API e arquivos est�ticos
app.UseAuthorization();

app.MapControllers();

// Roteamento do SPA: redireciona todas as requisi��es para o React quando n�o for uma API
app.MapFallbackToFile("/index.html");

app.UseResponseCompression();  // Certifique-se que a resposta est� sendo comprimida corretamente
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Type", "text/html; charset=utf-8");
    await next();
});


app.Run();
