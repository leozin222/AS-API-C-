using Microsoft.EntityFrameworkCore;
using SistemaPedidosFornecedores.Data;
using SistemaPedidosFornecedores.Repositories;
using SistemaPedidosFornecedores.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço do Entity Framework Core com SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registra os repositórios na injeção de dependência
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();

// Adiciona o serviço do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); // Registra os controladores para a API

var app = builder.Build();

// Configura o middleware para a aplicação
  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Ativa o Swagger apenas em ambientes de desenvolvimento
    app.UseSwaggerUI(); // Interface gráfica do Swagger
}

app.UseHttpsRedirection(); // Redireciona todas as requisições HTTP para HTTPS

app.MapControllers(); // Mapeia os controladores para os endpoints

app.Run();