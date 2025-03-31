using Microsoft.EntityFrameworkCore;
using CompassIT.Persistence;
using CompassIT.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Configura a persist�ncia do banco de dados e o reposit�rio
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona os servi�os para controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
