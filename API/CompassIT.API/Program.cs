using Microsoft.EntityFrameworkCore;
using CompassIT.Persistence;
using CompassIT.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Configura a persistência do banco de dados e o repositório
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona os serviços para controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
