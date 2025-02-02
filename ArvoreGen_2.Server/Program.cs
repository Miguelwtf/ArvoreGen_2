using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Controllers;
using Microsoft.EntityFrameworkCore;
using ArvoreGen_2.Server.Models;
using Npgsql;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IRelacionamentoService, RelacionamentoService>();

builder.Services.AddControllers();

// Adicionar serviços Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Pessoas",
        Version = "v1"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("https://localhost:56213") //56214
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

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

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Pessoas v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Type", "text/html; charset=utf-8");
    await next();
});

app.Run();
