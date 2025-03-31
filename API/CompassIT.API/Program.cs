using Microsoft.EntityFrameworkCore;
using CompassIT.Persistence;
using CompassIT.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Configura a persist�ncia do banco de dados e o reposit�rio
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona o servi�o CORS e configura a pol�tica
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()        // Permite qualquer origem
              .AllowAnyMethod()        // Permite qualquer m�todo (GET, POST, etc.)
              .AllowAnyHeader();       // Permite qualquer cabe�alho
    });
});

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

// Habilita o CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
