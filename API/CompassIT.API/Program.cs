using Microsoft.EntityFrameworkCore;
using CompassIT.Persistence;
using CompassIT.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Configura a persistência do banco de dados e o repositório
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona o serviço CORS e configura a política
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()        // Permite qualquer origem
              .AllowAnyMethod()        // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader();       // Permite qualquer cabeçalho
    });
});

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

// Habilita o CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
